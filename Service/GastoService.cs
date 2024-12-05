using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aviario_Campo_Alegre.Context;
using Aviario_Campo_Alegre.DTOs;
using Aviario_Campo_Alegre.Interface;
using Aviario_Campo_Alegre.Models;

namespace Aviario_Campo_Alegre.Service
{
    public class GastoService : IGastoService
    {
        private readonly OrganizadorContext _context;
        public GastoService(OrganizadorContext context)
        {   
            this._context = context;
        }

        public void Cadastrar(GastoDTO gastoDTO)
        {
            var gasto = TransformarDTO(gastoDTO);
            _context.Gastos.Add(gasto);
            _context.SaveChanges();
        }

        public List<GastoModel> ListarGastos(int idLote)
        {
            return _context.Gastos.Where( x => x.IdLote == idLote ).ToList();
        }

        public GastoModel TransformarDTO(GastoDTO gastoDTO)
        {
            var gasto = new GastoModel {
                 IdLote = gastoDTO.IdLote,
                 Data = gastoDTO.Data,
                 Descricao = gastoDTO.Descricao,
                 Valor = gastoDTO.Valor
             };   
             return gasto;
        }
    }
}