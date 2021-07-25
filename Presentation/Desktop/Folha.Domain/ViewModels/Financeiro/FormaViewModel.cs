namespace Folha.Domain.ViewModels.Financeiro
{
    public class FormaViewModel
    {
        public int codigo { get; set; }
        public string descricao { get; set; }
        public decimal Valor { get; set; } = 0.0m;
        public decimal Troco { get; set; } = 0.0m;
        public int CodConta { get; set; } = 1;
    }
}
