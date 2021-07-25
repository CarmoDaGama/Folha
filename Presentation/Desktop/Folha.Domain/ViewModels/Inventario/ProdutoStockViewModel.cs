namespace Folha.Domain.ViewModels.Inventario
{
    public class ProdutoStockViewModel
    {
        public int codigo { get; set; }
        public string NameKey { get { return "codigo"; } }

        public int CodProduto { get; set; }

        public ProdutosViewModel Artigo { get; set; } = new ProdutosViewModel();
        public ForeignKey FKeyArtigo
        {
            get
            {
                return new ForeignKey()
                {
                    NameTable = "Produtos",
                    NameEntity = "Artigo",
                    NameFieldThis = "CodProduto",
                    NameFieldOrigin = "Codigo"
                };
            }
        }

        public int CodArmazem { get; set; }

        public ArmazensViewModel Armazem { get; set; } = new ArmazensViewModel();
        public ForeignKey FKeyArmazem
        {
            get
            {
                return new ForeignKey()
                {
                    NameTable = "Armazens",
                    NameEntity = "Armazem",
                    NameFieldThis = "CodArmazem",
                    NameFieldOrigin = "codigo"
                };
            }
        }
        public decimal qtde { get; set; }
        public decimal stockMin { get; set; }
        public decimal stockMax { get; set; }

    }
}
