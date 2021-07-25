namespace Folha.Domain.ViewModels.Genericos
{
    public class PaisViewModel
    {
        public int codigo { get; set; }
        public string NameKey { get { return "codigo"; } }
        public string Descricao { get; set; }
    }
}
