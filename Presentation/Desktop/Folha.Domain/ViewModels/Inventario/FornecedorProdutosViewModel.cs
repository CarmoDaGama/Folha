namespace Folha.Domain.ViewModels.Inventario
{
    using Folha.Domain.Models.Entidades;

    public  class FornecedorProdutosViewModel
      {
        public int Codigo { get; set; }
        public int CodProduto { get; set; }
        public decimal Custo { get; set; }
        public int CodFornecedor { get; set; }
        public string Nome { get; set; }
        public FornecedorBusca Fornecedor { get; set; }



    }

}

