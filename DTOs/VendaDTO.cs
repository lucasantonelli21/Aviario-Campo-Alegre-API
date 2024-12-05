using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aviario_Campo_Alegre.DTOs
{
    public class VendaDTO
    {
        public int NumeroLote { get; set;}
        public long Quantidade { get; set; }
        public decimal PrecoVenda { get; set; }
        public DateOnly DataVenda { get; set; }
        public string NomeComprador { get; set; }
        public string cpfComprador { get; set; }
    }
}