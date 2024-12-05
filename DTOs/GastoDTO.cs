using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aviario_Campo_Alegre.DTOs
{
    public class GastoDTO
    {
        public int IdLote { get; set; }
        public DateOnly Data { get; set; }
        public String Descricao { get; set; }
        public decimal Valor { get; set; }
    }
}