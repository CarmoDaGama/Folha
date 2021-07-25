using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.ViewModels.Frame.Inventario
{
    public class DetalheProdutoViewModel
    {
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public decimal Custo { get; set; }
        public decimal Preco { get; set; }
        public decimal Quantidade  { get; set; }
        public decimal Imposto { get; set; }
        public decimal TotalReceitas { get; set; }
        public decimal Lucro { get; set; }
        public decimal TotalCusto { get; set; }
        public decimal TotalImposto { get; set; }
    }
}
