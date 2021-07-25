using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Models.Entidades
{
   public class PessoaFisica
    {
        public DateTime DataNascimento { get; set; }
        public string NomeDocumento { get; set; }
        public List<PessoaFisica> Dependentes { get; set; }
    }
}
