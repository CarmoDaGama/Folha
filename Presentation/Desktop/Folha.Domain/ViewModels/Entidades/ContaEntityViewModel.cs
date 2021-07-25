using Folha.Domain.ViewModels.Financeiro;

namespace Folha.Domain.ViewModels.Entidades
{
    public class ContaEntityViewModel
    {
        public int codigo { get; set; }
        public int CodBanco { get; set; }
        public BancosViewModel Banco { get; set; }
        public string NameBank { get { return Equals(Banco, null) ? string.Empty : Banco.descricao; } }
        public int CodEntidade { get; set; }
        public string Numero { get; set; }
        public string Natureza { get; set; }
        public string Sequencia { get; set; }
        public string iban { get; set; }
        public string swift { get; set; }
    }
}
