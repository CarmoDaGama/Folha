namespace Folha.Domain.ViewModels.Inventario
{
    public class SubistitutoViewModel
    {
        public int Codigo { get; set; }
        public int CodNovo { get; set; }
        public int CodigoSubstituto { get; set; }
        public string Nome { get; set; }
        public ProdutosViewModel Produtos { get; set; }

    }
}
