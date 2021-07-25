using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Models.Escolar
{
    public class Alunos
    {
        public int Codigo  { get; set; }
        public int CodEntidade { get; set; }
        public int status { get; set; }
        public string DataRegisto { get; set; }
    }
}
