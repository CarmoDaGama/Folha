namespace Folha.Domain.Models.Inventario
{
    public class MovProdutos
    {
        public int codigo { get; set; }
        public string NameKey { get { return "codigo"; } }
        public int CodDocumento { get; set; }
        public Documentos.Documentos Documento { get; set; } = new Documentos.Documentos();
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
        public Armazens Armazem { get; set; } = new Armazens();
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
        public int CodProduto { get; set; }
        public Produtos Artigo { get; set; } = new Produtos();
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
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public decimal Imposto { get; set; }
        public decimal Desconto { get; set; }
        public decimal Retencao { get; set; }
        public decimal Qtdade { get; set; }
        public decimal Total { get; set; }
        public decimal Custo { get; set; }

    }
}
