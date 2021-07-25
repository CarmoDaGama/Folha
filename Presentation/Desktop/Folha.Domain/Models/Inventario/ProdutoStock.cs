using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Models.Inventario
{
    public class ProdutoStock
    {
        public int Codigo { get; set; }
        public int CodProduto { get; set; }
        public int CodArmazem { get; set; }
        public decimal Custo { get; set; }
        public decimal Quantidade { get; set; }
        public decimal StockMin { get; set; }
        public decimal StockMax { get; set; }
         public Produtos Artigo { get; set; } = new Produtos();
    }
}
