using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.ViewModels.Entidades
{
    public class FornecedoresViewModel 
    {
        public int codigo { get; set; }
        public string NameKey { get { return "codigo"; } }
        public int CodEntidade { get; set; }
        public EntidadesViewModel Entidade { get; set; } = new EntidadesViewModel();
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
