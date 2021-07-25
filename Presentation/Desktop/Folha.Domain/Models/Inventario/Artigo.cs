using Folha.Domain.Models.Compras;
using Folha.Domain.ViewModels.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Models.Inventario
{
   public class Artigo
    {
        #region Declaração

        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public int Codcategoria { get; set; }
        public Categoria Familia { get; set; } = new Categoria();
        public int CodImposto { get; set; }
        public Imposto Imposto { get; set; } = new Imposto();
        public string MotivoIsencao { get; set; }
        public decimal Retencao { get; set; }
        public decimal Preco1 { get; set; }
        public decimal Preco2 { get; set; }
        public decimal Preco3 { get; set; }
        public int movimentaStock { get; set; }
        public int Vender { get; set; }
        public decimal Custo { get; set; }
        public DateTime? Data_fabrico { get; set; }
        public DateTime? Data_validade { get; set; }
        public byte[] Imagem { get; set; }

        public string Barra { get; set; }
        public int status { get; set; }
        //public decimal Imposto { get; set; }

        public List<SubistitutoViewModel> Substitutos { get; set; }
        public List<ProdutoStock> Armazens { get; set; }
        public List<FornecedorProdutosViewModel> Fornecedores { get; set; }
        public List<ComposicaoProdutosViewModel> Composicao { get; set; }

        #endregion
    }
}
