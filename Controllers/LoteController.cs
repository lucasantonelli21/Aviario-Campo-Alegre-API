using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aviario_Campo_Alegre.Context;
using Aviario_Campo_Alegre.DTOs;
using Aviario_Campo_Alegre.Interface;
using Aviario_Campo_Alegre.Models;
using Aviario_Campo_Alegre.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Aviario_Campo_Alegre.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Roles = "Adm")]
    public class LoteController : ControllerBase
    {
        private readonly OrganizadorContext _context;
        private ILoteService loteService;
        public LoteController(OrganizadorContext context)
        {
            this._context = context;
            this.loteService = new LoteService(context);
        }

        [HttpPost]
        public IActionResult Cadastrar(LoteDTO loteDTO){
            var lote = loteService.TransformarDTO(loteDTO);
            loteService.CadastrarLote(lote);
            return Ok(lote);
        }

        [HttpGet] 
        public IActionResult Listar() {
            var listaLote = loteService.ListarLotes();
            return Ok(listaLote);
        }


        [HttpPut("AdicionarMortalidade")]
        public IActionResult AdicionarMortalidade(MortalidadeDTO mortalidadeDTO){
            var lote = loteService.GetLote(mortalidadeDTO.idLote);
            if(lote == null){return NotFound();}
            lote = loteService.AdicionarMortalidade(lote,mortalidadeDTO.qntdMortos);
            return Ok(lote);
        }
        
        [HttpPut("AdicionarConsumo")]
        public IActionResult AdicionarConsumo(ConsumoDTO consumoDTO){
            var lote = loteService.GetLote(consumoDTO.idLote);
            if(lote == null){return NotFound();}
            lote = loteService.AdicionarConsumo(lote,consumoDTO.qntdConsumo);
            return Ok(lote);
        }

        
        [HttpPut("AdicionarVenda")]
        public IActionResult Vender(VendaDTO vendaDTO){
            var lote = loteService.GetLote(vendaDTO.NumeroLote);
            if(lote == null){return NotFound();}
            lote = loteService.AdicionarVenda(lote,vendaDTO);
            if(lote == null){return BadRequest();}
            return Ok(lote);
        }
        
    }
}