using Aviario_Campo_Alegre.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Aviario_Campo_Alegre.Interface;
using Aviario_Campo_Alegre.Service;



var builder = WebApplication.CreateBuilder(args);
string key = builder.Configuration.GetSection("Jwt").ToString() ?? "123456";
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#region DbContext
builder.Services.AddDbContext<OrganizadorContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoPadrao")));
#endregion
#region Bearer Authentication
builder.Services.AddAuthentication(option =>{
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(option =>{
            option.TokenValidationParameters = new TokenValidationParameters{
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
            };
            });
#endregion
#region Dependency Injection
builder.Services.AddAuthorization();
builder.Services.AddScoped<IAdmService,AdmService>();
builder.Services.AddScoped<ILoteService,LoteService>();
builder.Services.AddScoped<IRacaoService,RacaoService>();
builder.Services.AddScoped<IRefeicaoService,RefeicaoService>(); 
builder.Services.AddScoped<IRelatorioService,RelatorioService>();
builder.Services.AddScoped<ITokenService,TokenService>();
builder.Services.AddScoped<IVacinaService,VacinaService>();
builder.Services.AddScoped<IVendasService,VendaService>();
builder.Services.AddScoped<IGastoService,GastoService>();
#endregion

builder.Services.AddSwaggerGen(options => {
    options.MapType<DateOnly>(() => new OpenApiSchema { 
        Type = "string",
        Format = "date" });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme{
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Insira o tokne JWT aqui: "
                });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement { 
                    {
                        new OpenApiSecurityScheme{
                            Reference = new OpenApiReference{
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
});

#region CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "localHost",
                      policy =>
                      {
                          policy
                            .WithOrigins("http://localhost:3000","https://localhost:3000").AllowAnyHeader().AllowAnyMethod(); // specifying the allowed origin
                      });
});
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("localHost");
app.Run();
