using Folha.Domain.Models.Inventario;
using System.Collections.Generic;

namespace Folha.Domain.ViewModels.Inventario
{
    public  class ProdutosViewModel
    {
        #region Relacionamento
        public ProdutosViewModel()
        {
            Substitutos = new List<SubistitutoViewModel>();
            //Fornecedores = new List<FornecedorProdutosViewModel>();
            Composicaos = new List<ComposicaoProdutosViewModel>();
        }
        #endregion

        #region Declaração

        public int Codigo { get; set; }
        public string NameKey { get { return "Codigo"; } }
        public string descricao { get; set; }

        public int Codcategoria { get; set; }
        public int CodImposto { get; set; }
        public string MotivoIsencao{ get; set; }
        public CategoriaViewModel Familia { get; set; } = new CategoriaViewModel();
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
        public ImpostoViewModel EntityImposto { get; set; } = new ImpostoViewModel();
        public decimal Imposto { get; set; }
        public ForeignKey FKeyImposto
        {
            get
            {
                return new ForeignKey()
                {
                    NameTable = "Imposto",
                    NameEntity = "EntityImposto",
                    NameFieldThis = "CodImposto",
                    NameFieldOrigin = "Codigo"
                };
            }
        }
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
        //public decimal Imposto { get; set; }
        //public string CodEmpresa { get; set; }
        #endregion

        #region Implementação
        public List<SubistitutoViewModel> Substitutos { get; set; }
       // public List<FornecedorProdutosViewModel> Fornecedores { get; set; }
        public List<ComposicaoProdutosViewModel> Composicaos { get; set; }
        //public List<ArmazenProdutosViewModel> LisatArmazens { get; set; }
        public List<ProdutoStock> LisatArmazens { get; set; }

        #endregion
    }
}
