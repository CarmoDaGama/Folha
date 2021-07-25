namespace Folha.Domain.ViewModels.Inventario
{
    public  class ComposicaoProdutosViewModel 
    {
        public int Codigo { get; set; }
        public int CodArtigo { get; set; }
        public int CodArtigoComponente{ get; set; }
        public string Nome { get; set; }
        public decimal Qtde { get; set; }
        public ProdutosViewModel Produtos { get; set; }
    }
}
