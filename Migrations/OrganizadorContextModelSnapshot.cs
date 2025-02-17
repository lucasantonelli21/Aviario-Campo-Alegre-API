﻿// <auto-generated />
using System;
using Aviario_Campo_Alegre.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Aviario_Campo_Alegre.Migrations
{
    [DbContext(typeof(OrganizadorContext))]
    partial class OrganizadorContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Aviario_Campo_Alegre.Models.AdministradorModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Perfil")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.ToTable("Administradores");
                });

            modelBuilder.Entity("Aviario_Campo_Alegre.Models.GastoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("Data")
                        .HasColumnType("date");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdLote")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Gastos");
                });

            modelBuilder.Entity("Aviario_Campo_Alegre.Models.LoteModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AviarioOrigem")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("DataEntrada")
                        .HasColumnType("date");

                    b.Property<DateOnly?>("DataVenda")
                        .HasColumnType("date");

                    b.Property<string>("Linhagem")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PrecoLote")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long>("QuantidadeAnimais")
                        .HasColumnType("bigint");

                    b.Property<long>("QuantidadeConsumo")
                        .HasColumnType("bigint");

                    b.Property<long>("QuantidadeMortos")
                        .HasColumnType("bigint");

                    b.Property<bool>("Vendido")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Lotes");
                });

            modelBuilder.Entity("Aviario_Campo_Alegre.Models.RacaoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("QuantidadeDiasAplicacao")
                        .HasColumnType("int");

                    b.Property<string>("TipoDaRacao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Racoes");
                });

            modelBuilder.Entity("Aviario_Campo_Alegre.Models.RefeicaoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("DataAdministracao")
                        .HasColumnType("date");

                    b.Property<int>("IdRacao")
                        .HasColumnType("int");

                    b.Property<int>("NumeroLote")
                        .HasColumnType("int");

                    b.Property<decimal>("PrecoAplicao")
                        .HasColumnType("decimal(18,2)");

                    b.Property<double>("QuantidadeRacao")
                        .HasColumnType("float");

                    b.Property<int>("RacaoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RacaoId");

                    b.ToTable("Refeicoes");
                });

            modelBuilder.Entity("Aviario_Campo_Alegre.Models.VacinaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("DataAplicacao")
                        .HasColumnType("date");

                    b.Property<DateOnly>("DataProxAplicacao")
                        .HasColumnType("date");

                    b.Property<string>("Laboratorio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumeroLote")
                        .HasColumnType("int");

                    b.Property<string>("NumeroNota")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateOnly>("Validade")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.ToTable("Vacinas");
                });

            modelBuilder.Entity("Aviario_Campo_Alegre.Models.VendaAnimal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("DataVenda")
                        .HasColumnType("date");

                    b.Property<int?>("LoteModelId")
                        .HasColumnType("int");

                    b.Property<string>("NomeComprador")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumeroLote")
                        .HasColumnType("int");

                    b.Property<decimal>("PrecoVenda")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long>("Quantidade")
                        .HasColumnType("bigint");

                    b.Property<string>("cpfComprador")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LoteModelId");

                    b.ToTable("Vendas");
                });

            modelBuilder.Entity("Aviario_Campo_Alegre.Models.RefeicaoModel", b =>
                {
                    b.HasOne("Aviario_Campo_Alegre.Models.RacaoModel", "Racao")
                        .WithMany()
                        .HasForeignKey("RacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Racao");
                });

            modelBuilder.Entity("Aviario_Campo_Alegre.Models.VendaAnimal", b =>
                {
                    b.HasOne("Aviario_Campo_Alegre.Models.LoteModel", null)
                        .WithMany("QuantidadeVendas")
                        .HasForeignKey("LoteModelId");
                });

            modelBuilder.Entity("Aviario_Campo_Alegre.Models.LoteModel", b =>
                {
                    b.Navigation("QuantidadeVendas");
                });
#pragma warning restore 612, 618
        }
    }
}
