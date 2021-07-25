using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.ViewModels.Frame.Inventario
{
    public class LerProdutosViewModel
    {
        public int CodDocumento { get; set; }
        public int CodProd { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public string Armazem { get; set; }
        public double Quantidade { get; set; }
        public double Total { get; set; }
        public double Custo { get; set; }
        public double Imposto { get; set; }
        public double Desconto { get; set; }
        public double TotalReceita { get; set; }
        public double Lucro { get; set; }
        public double TotalCusto { get; set; }
        public double TotalImposto { get; set; }

    }
}
