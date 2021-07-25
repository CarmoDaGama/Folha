using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Models.Inventario
{
    public class ProdutoFornecedor
    {
        public int Codigo { get; set; }
        public int CodProduto { get; set; }
        public int CodFornecedor { get; set; }
        public decimal Custo { get; set; }
        //public Folha.Domain.Models.Entidades.Fornecedores Artigo { get; set; } = new Entidades.Fornecedores();
        public Folha.Domain.Models.Entidades.Entidades Entidades { get; set; } = new Entidades.Entidades();

    }
}
