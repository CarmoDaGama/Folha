namespace Folha.Domain.ViewModels.Entidades
{
    public class CondicoesPagamentosViewModel
    {
        public int Codigo { get; set; }
        public string NameKey { get { return "Codigo"; } }
        public string Descricao { get; set; }
        public int Dias { get; set; }
    }
}
