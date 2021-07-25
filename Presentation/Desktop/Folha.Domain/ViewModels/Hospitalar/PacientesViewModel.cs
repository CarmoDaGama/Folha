using Folha.Domain.Models.Entidades;
using Folha.Domain.ViewModels.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.ViewModels.Hospitalar
{
   public class PacientesViewModel
    {
        public int CodPessoa { get; set; }
        public string NameKey { get { return "Codigo"; } }
        public EntidadesPessoaViewModel EntidadesPessoa { get; set; } = new EntidadesPessoaViewModel();
        public ForeignKey FKeyEntidade
        {
            get
            {
                return new ForeignKey()
                {
                    NameTable = "EntidadesPessoa",
                    NameEntity = "EntidadesPessoa",
                    NameFieldThis = "CodPessoa",
                    NameFieldOrigin = "CodEntidade"
                };
            }
        }
    }
}
