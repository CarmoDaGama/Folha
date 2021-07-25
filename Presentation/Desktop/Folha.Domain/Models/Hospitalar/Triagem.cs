using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Models.Hospitalar
{
    public class Triagem
    {
        public int Codigo { get; set; }
        public int CodPaciente { get; set; }
        public decimal Temperatura { get; set; }
        public string TemperaturaArterial { get; set; }
        public decimal Peso { get; set; }
        public decimal FrequenciaRespiratoria { get; set; }
        public decimal FrequenciaCardiaca { get; set; }
        public int CodAtendimento { get; set; }
    }
}
