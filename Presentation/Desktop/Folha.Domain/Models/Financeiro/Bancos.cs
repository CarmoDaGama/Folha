namespace Folha.Domain.Models.Financeiro
{
    public class Bancos 
    {
        public int codigo { get; set; }
        public string NameKey { get { return "codigo"; } }

        public string descricao { get; set; }
    }
}
