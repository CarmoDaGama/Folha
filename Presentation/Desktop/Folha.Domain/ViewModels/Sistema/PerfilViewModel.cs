namespace Folha.Domain.ViewModels.Sistema
{
   public class PerfilViewModel
    {
        public int codigo { get; set; }
        public string NameKey { get { return "codigo"; } }
        public string Descricao { get; set; }
        public string Acessos { get; set; }
    }
}
