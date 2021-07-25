namespace Folha.Domain.Models.Inventario
{
    public class ArtigoStock 
    {

        public int codigo { get; set; }
        public string NameKey {  get { return "codigo"; } }
        public int CodProduto { get; set; }

        public Produtos Artigo { get; set; } = new Produtos();
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

        public Armazens Armazem { get; set; } = new Armazens();
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
        public int qtde { get; set; }
        public int stockMin { get; set; }
        public int stockMax { get; set; }
    }
}
