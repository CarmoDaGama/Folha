using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Models.Entidades
{
    public class Fornecedores 
    {
        public int codigo { get; set; }
        public string NameKey { get { return "codigo"; } }
        public int CodEntidade { get; set; }
        public Entidades Entidade { get; set; } = new Entidades();
        public ForeignKey FKEntidade {
            get {
                return new ForeignKey() {
                    NameTable = "Entidades",
                    NameEntity = "Entidade",
                    NameFieldThis = "CodEntidade",
                    NameFieldOrigin = "Codigo"
                };
            }
        }
    }
}
