namespace Folha.Domain.ViewModels.Entidades
{
    public class DepartamentosViewModel
    {
        //
        public int Codigo { get; set; }
        public string NameKey { get { return "Codigo"; } }
        public string Descricao { get; set; }
    }
}
