using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.ViewModels.Escolar
{
    public class AlunosViewModel
    {
        
        public int Codigo { get; set; }
        public int CodEntidade { get; set; }
        public string Nome { get; set; }
        public string Data { get; set; }
        public string Sexo { get; set; }
        public int  status { get; set; }
    }
}
