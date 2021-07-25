using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.ViewModels.Hoteleiro
{
    public class HospedagemViewModel
    {
        public int Quarto { get; set; }
        public int Tipo { get; set; }
        public int Tarifa { get; set; }
        public int CheckIn { get; set; }
        public int CheckOut { get; set; }
        public int Qtdade { get; set; }
        public int Preco { get; set; }
        public int Total { get; set; }

    }
}
