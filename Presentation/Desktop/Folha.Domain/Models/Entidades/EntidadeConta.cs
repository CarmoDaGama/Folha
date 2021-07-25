using Folha.Domain.Models.Financeiro;

namespace Folha.Domain.Models.Entidades
{
    public class EntidadeConta
    {
        public int codigo { get; set; }
        public int CodBanco { get; set; }
        public Bancos Banco { get; set; }
        public int CodEntidade { get; set; }
        public Entidades Entidade { get; set; }
        public string Numero { get; set; }
        public string Natureza { get; set; }
        public string Sequencia { get; set; }
        public string iban { get; set; }
        public string swift { get; set; }

    }
}
