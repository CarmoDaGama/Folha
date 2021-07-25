using Folha.Domain.ViewModels.Documentos;

namespace Folha.Domain.ViewModels.Inventario
{
    public class MovProdutosViewModel
    {
        public int codigo { get; set; }
        public string NameKey { get { return "codigo"; } }
        public int CodDocumento { get; set; }
        public DocumentosViewModel Documento { get; set; } = new DocumentosViewModel();
        public ForeignKey FKeyDocumento
        {
            get {
                return new ForeignKey() {
                    NameTable = "Documentos",
                    NameEntity = "Documento",
                    NameFieldThis = "CodDocumento",
                    NameFieldOrigin = "codigo"
                };
            }
        }
        public int CodArmazem { get; set; }
        public ArmazensViewModel Armazem { get; set; } = new ArmazensViewModel();
        public ForeignKey FKeyArmazem
        {
            get {
                return new ForeignKey() {
                    NameTable = "Armazens",
                    NameEntity = "Armazem",
                    NameFieldThis = "CodArmazem",
                    NameFieldOrigin = "codigo"
                };
            }
        }
        //public int CodHabitacao { get; set; }
        public int CodProduto { get; set; }
        public ProdutosViewModel Artigo { get; set; } = new ProdutosViewModel();
        public ForeignKey FKeyArtigo
        {
            get {
                return new ForeignKey() {
                    NameTable = "Produtos",
                    NameEntity = "Artigo",
                    NameFieldThis = "CodProduto",
                    NameFieldOrigin = "Codigo"
                };
            }
        }
        public int CodStock { get; set; }
        public ProdutoStockViewModel ArtigoStock { get; set; } = new ProdutoStockViewModel();
        public ForeignKey FKeyArtigoStock
        {
            get
            {
                return new ForeignKey()
                {
                    NameTable = "ProdutoStock",
                    NameEntity = "ArtigoStock",
                    NameFieldThis = "CodStock",
                    NameFieldOrigin = "codigo"
                };
            }
        }
        public string Descricao { get; set; }
        public string DescricaoImposto { get; set; }
        public string ArtigoAbstrato { get; set; } = string.Empty;
        public string TipoImposto { get; set; }
        public string CodImposto { get; set; }
        public decimal Preco { get; set; }
        public decimal Imposto { get; set; }
        public decimal Desconto { get; set; }
        public decimal DescontoGeral { get; set; }
        public decimal Retencao { get; set; }
        public decimal Qtdade { get; set; }
        public decimal Total { get; set; }
        public decimal Custo { get; set; }
    }
}
