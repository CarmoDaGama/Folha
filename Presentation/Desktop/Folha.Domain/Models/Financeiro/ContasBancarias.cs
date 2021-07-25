using Folha.Domain.Models.Entidades;
using System;

namespace Folha.Domain.Models.Financeiro
{
    public   class ContasBancarias
    {
        public int codigo { get; set; }
        public string Numero { get; set; }
        public string Iban { get; set; }
        public string Natureza { get; set; }
        public string Sequencia { get; set; }
        public string Swift { get; set; }
        public int CodBanco { get; set; }
        public string Banco { get; set; }
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
        public string Descricao { get; set; }

        public Empresa.Empresa CabecalhoEmpresa { get; set; }

    }
}
