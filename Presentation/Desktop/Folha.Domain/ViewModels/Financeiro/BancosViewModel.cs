namespace Folha.Domain.ViewModels.Financeiro
{
    public class BancosViewModel 
    {
        public int codigo { get; set; }
        public string NameKey { get { return "codigo"; } }
        public string descricao { get; set; }
    }
}
