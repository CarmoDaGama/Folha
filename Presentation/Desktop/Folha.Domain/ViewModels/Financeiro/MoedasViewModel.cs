namespace Folha.Domain.ViewModels.Financeiro
{
    public class MoedasViewModel
    {
        public int Codigo { get; set; }
        public string NameKey { get { return "codigo"; } }
        public string Descricao { get; set; }
        public string Sigla { get; set; }
        public int moedapadrao { get; set; }

    }
}
