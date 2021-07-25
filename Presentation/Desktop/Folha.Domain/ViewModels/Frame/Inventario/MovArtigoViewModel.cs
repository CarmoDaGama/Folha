using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.ViewModels.Frame.Inventario
{
    public class MovArtigoViewModel
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public decimal PRECO { get; set; }
        public decimal Qtdade { get; set; }
        public decimal TOTAL { get; set; }
        public string Retencao { get; set; }
    }
}
