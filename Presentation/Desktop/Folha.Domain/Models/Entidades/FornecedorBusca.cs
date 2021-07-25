using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Models.Entidades
{
    public class FornecedorBusca
    {
        public int Codigo { get; set; }
        public string NameKey { get { return "Codigo"; } }
        public string Nome { get; set; }
        public int CodEntidade { get; set; }
        public Entidades Entidade { get; set; } = new Entidades();
        public ForeignKey FKEntidade
        {
            get
            {
                return new ForeignKey()
                {
                    NameTable = "Entidades",
                    NameEntity = "Entidade",
                    NameFieldThis = "CodEntidade",
                    NameFieldOrigin = "Codigo"
                };
            }
        }
        public Empresa.Empresa CabecalhoEmpresa { get; set; }
    }
}
