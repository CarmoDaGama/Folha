using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Models.Inventario
{
    public class ProdutoComposicao
    {
        public int Codigo { get; set; }
        public int CodProduto { get; set; }
        public int CodigoProduto { get; set; }
        public decimal Qtde { get; set; }
        public Produtos Artigo { get; set; } = new Produtos();


    }
}
