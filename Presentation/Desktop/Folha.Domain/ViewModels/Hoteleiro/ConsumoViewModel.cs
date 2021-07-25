using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.ViewModels.Hoteleiro
{
    public class ConsumoViewModel
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public int Preco { get; set; }
        public int Desconto { get; set; }
        public int Imposto { get; set; }
        public int Arm { get; set; }
        public int Qtdade { get; set; }
        public int Total { get; set; }
    }
}
