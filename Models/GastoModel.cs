using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aviario_Campo_Alegre.Models
{
    public class GastoModel
    {
        public int Id { get; set; }
        public int IdLote { get; set; }
        public DateOnly Data { get; set; }
        public String Descricao { get; set; }
        public decimal Valor { get; set; }
    }
}