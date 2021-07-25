using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Models.Hospitalar
{
    public class FarmacoReceita
    {
        public int Codigo { get; set; }
        public int CodPaciente { get; set; }
        public int CodFarmaco { get; set; }
        public DateTime Data { get; set; }
        public int CodReceita { get; set; }
        public int CodAtendimento { get; set; }
    }
}
