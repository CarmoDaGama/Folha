using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Models.Hospitalar
{
    public class ExamesAtendimento
    {
        public int Codigo { get; set; }
        public int CodPaciente { get; set; }
        public int CodExame { get; set; }        
        public DateTime Data { get; set; }
        public int CodAtendimento { get; set; }

    }
}
