using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aviario_Campo_Alegre.Context;
using Aviario_Campo_Alegre.DTOs;
using Aviario_Campo_Alegre.Interface;
using Aviario_Campo_Alegre.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Aviario_Campo_Alegre.Service
{
    public class LoteService : ILoteService
    {
        private readonly OrganizadorContext _context;
        private IVendasService vendaService;
        public LoteService(OrganizadorContext context)
        {   
            this._context = context;
            this.vendaService = new VendaService(context);
        }



        public LoteModel TransformarDTO(LoteDTO loteDTO)
        {
              var lote = new LoteModel {
                 DataEntrada = loteDTO.DataEntrada,
                 QuantidadeAnimais = loteDTO.QuantidadeAnimais,
                 Linhagem = loteDTO.Linhagem,
                 AviarioOrigem = loteDTO.AviarioOrigem,
                 QuantidadeConsumo = 0,
                 QuantidadeMortos = 0,
                 PrecoLote = loteDTO.PrecoLote,
                 DataVenda = loteDTO.DataVenda,
                 Vendido = false
             };   
             return lote;
        }
        public void CadastrarLote(LoteModel lote)
        {
            _context.Lotes.Add(lote);
            _context.SaveChanges();
            
        }
        public List<LoteModel> ListarLotes(){
            var lotes = _context.Lotes.ToList();
            lotes = vendaService.GetVendas(lotes);
            return lotes;
        }
        public LoteModel GetLote(int idLote){
            return _context.Lotes.Find(idLote);
        }
        

        public LoteModel AdicionarMortalidade(LoteModel lote, int qntdMortos)
        {
            lote.QuantidadeMortos = lote.QuantidadeMortos+qntdMortos;
            _context.Lotes.Update(lote);
            _context.SaveChanges();
            return lote;
        }


        public LoteModel AdicionarConsumo(LoteModel lote, int qntdConsumo){
            lote.QuantidadeConsumo = lote.QuantidadeConsumo+qntdConsumo;
            _context.Lotes.Update(lote);
            _context.SaveChanges();
            return lote;
        }

        public LoteModel AdicionarVenda(LoteModel lote, VendaDTO vendaDTO){
            var listaVendas = vendaService.GetVendas(lote.Id);
            if(listaVendas == null)
                lote.QuantidadeVendas = new List<VendaAnimal>();
            long limiteVenda = 0;
            foreach(var venda in listaVendas){
                limiteVenda = limiteVenda + venda.Quantidade;
            }
            if(limiteVenda == 0 && lote.Vendido == false){lote.Vendido = true;_context.Lotes.Update(lote); _context.SaveChanges(); return null;}
            if(limiteVenda + vendaDTO.Quantidade > lote.QuantidadeAnimais){return null;}
            if(limiteVenda + vendaDTO.Quantidade == lote.QuantidadeAnimais){lote.Vendido = true;}
            var novaVenda = vendaService.TransformarDTO(vendaDTO);
            listaVendas.Add(novaVenda);
            lote.QuantidadeVendas = listaVendas;
            _context.Lotes.Update(lote);
            vendaService.Cadastrar(novaVenda);
            _context.SaveChanges();
            return lote;
        }

        
    }

}