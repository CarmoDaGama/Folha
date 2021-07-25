namespace Folha.Domain.ViewModels.Admin
{
    public class NotificaoRuturaViewModel
    {
        public int codigo { get; set; }
        public int CodProduto { get; set; }
        public int CodArmazem { get; set; }
        public decimal qtde { get; set; }
        public decimal stockMin { get; set; }
        public decimal stockMax { get; set; }
    }
}
