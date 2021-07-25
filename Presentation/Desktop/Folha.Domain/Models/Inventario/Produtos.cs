using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Models.Inventario
{
  public  class Produtos
    {
        #region Relacionamento
        public Produtos()
        {
         Substitutos = new List<ProdutoSubstituto>();
        Fornecedores = new List<ProdutoFornecedor>();
        Composicaos = new List<ProdutoComposicao>();
        }
        #endregion

        #region Declaração

        public int Codigo { get; set; }
        public string NameKey { get { return "Codigo"; } }
        public string descricao { get; set; }
        public int Codcategoria { get; set; }
        public Categoria Familia { get; set; } = new Categoria();
        public ForeignKey FKeyFamilia
        {
            get
            {
                return new ForeignKey()
                {
                    NameTable = "Categoria",
                    NameEntity = "Familia",
                    NameFieldThis = "Codcategoria",
                    NameFieldOrigin = "codigo"
                };
            }
        }
        //public int Codunidade { get; set; }
        //public Unidade Unidade { get; set; } = new Unidade();
        //public ForeignKey FKeyUnidade
        //{
        //    get
        //    {
        //        return new ForeignKey()
        //        {
        //            NameTable = "Unidade",
        //            NameEntity = "Unidade",
        //            NameFieldThis = "Codunidade",
        //            NameFieldOrigin = "codigo"
        //        };
        //    }
        //}
        //public string taxa { get; set; }
        public decimal Retencao { get; set; }
        public decimal preco1 { get; set; }
        public decimal preco2 { get; set; }
        public decimal preco3 { get; set; }
        public int movimentaStock { get; set; }
        public int Vender { get; set; }
        public decimal custo { get; set; }
        public string data_fabrico { get; set; }
        public string data_validade { get; set; }
        public byte[] Imagem { get; set; }

        public string Barra { get; set; }
        public int status { get; set; }
        public decimal Imposto { get; set; }
        //public string CodEmpresa { get; set; }
        #endregion

        #region Implementação
        public List<ProdutoSubstituto> Substitutos { get; set; }
        public List<ProdutoFornecedor> Fornecedores { get; set; }
        public List<ProdutoComposicao> Composicaos { get; set; }
        #endregion
    }
}
