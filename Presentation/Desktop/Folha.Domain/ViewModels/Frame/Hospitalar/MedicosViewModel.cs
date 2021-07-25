using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.ViewModels.Frame.Hospitalar
{
    public class MedicosViewModel
    {
        public int CodEntidade { get; set; }
        public int CodMedico{ get; set; }
        public string Nome { get; set; }
        public string Especialidade { get; set; }
        public string NumeroCarteira { get; set; }
        public string Sexo { get; set; }
        public int status { get; set; }
        public int CodEscala { get; set; }
    }
}
