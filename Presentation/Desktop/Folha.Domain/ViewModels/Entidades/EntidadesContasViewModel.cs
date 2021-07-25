using Folha.Domain.Models.Financeiro;
using Folha.Domain.ViewModels.Financeiro;

namespace Folha.Domain.ViewModels.Entidades
{
    public class EntidadesContasViewModel
    {
        public int codigo { get; set; }
        public string NameKey { get { return "codigo"; } }
        public int CodBanco { get; set; }
        public BancosViewModel Banco { get; set; } = new BancosViewModel();
        public ForeignKey FKeyBanco
        {
            get
            {
                return new ForeignKey()
                {
                    NameTable = "Bancos",
                    NameEntity = "Banco",
                    NameFieldThis = "CodBanco",
                    NameFieldOrigin = "codigo"
                };
            }
        }
        public int CodEntidade { get; set; }
        public string Numero { get; set; }
        public string Natureza { get; set; }
        public string Sequencia { get; set; }
        public string iban { get; set; }
        public string swift { get; set; }

    }
}
