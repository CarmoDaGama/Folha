using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Models.Hospitalar
{
    public class Medicos
    {
        public int Codigo { get; set; }
        public int CodPessoa { get; set; }
        public string NumeroCarteira { get; set; }
        public int CodEscala { get; set; }
        public int status { get; set; }

    }
}
