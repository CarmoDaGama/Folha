using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.ViewModels.Hoteleiro
{
    public class PagamentoViewModel
    {
        public int N { get; set; }
        public DateTime Data { get; set; }
        public string Descricao { get; set; }
        public int Forma { get; set; }
        public int Tipo { get; set; }
        public int Valor { get; set; }
        public int Moeda { get; set; }
        public int Estado { get; set; }
    }
}
