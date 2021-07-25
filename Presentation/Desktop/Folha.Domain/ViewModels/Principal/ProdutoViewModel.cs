using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.ViewModels.Principal
{
    public class ProdutoViewModel
    {
        public string Armazem { get; set; }
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int Qtdade { get; set; }
        public string Familia { get; set; }
        public int StkMin { get; set; }
        public int StkMax { get; set; }
        public int Controla { get; set; }
        public int Vender { get; set; }
    }
}
