using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aviario_Campo_Alegre.Context;
using Aviario_Campo_Alegre.DTOs;
using Aviario_Campo_Alegre.Interface;
using Aviario_Campo_Alegre.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Aviario_Campo_Alegre.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Roles = "Adm")]

    public class GastoController : ControllerBase
    {
        private readonly OrganizadorContext _context;
        private IGastoService gastoService;
        public GastoController(OrganizadorContext context)
        {
            this._context = context;
            this.gastoService = new GastoService(context);
        }


        [HttpPost]
        public IActionResult Cadastrar(GastoDTO gastoDTO){
            gastoService.Cadastrar(gastoDTO);
            return Ok(gastoDTO);
        }

        [HttpGet] 
        public IActionResult Listar(int idLote) {
            var listaGastos = gastoService.ListarGastos( idLote);
            return Ok(listaGastos);
        }
    }
}