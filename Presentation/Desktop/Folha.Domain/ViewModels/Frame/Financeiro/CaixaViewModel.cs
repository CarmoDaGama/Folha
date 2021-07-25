namespace Folha.Domain.ViewModels.Frame.Financeiro
{
    public class CaixaViewModel
    {
        public CaixaViewModel(string item, string descricao)
        {
            ItemCaixa = item;
            Descricao = descricao;
        }
        public string ItemCaixa { get; set; }
        public string Descricao { get; set; }

    }
}
