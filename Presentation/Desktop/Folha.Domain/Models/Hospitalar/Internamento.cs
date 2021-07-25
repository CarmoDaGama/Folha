using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Models.Hospitalar
{
    public class Internamento
    {
        public int Codigo { get; set; }
        public int CodPaciente { get; set; }
        public int CodAreasHospitalar { get; set; }
        public int CodSalasHospitalar { get; set; }
        public int CodCama { get; set; }
        public DateTime Entrada { get; set; }
        public DateTime Saida { get; set; }

        public List<Paciente> Pacientes { get; set; } = new List<Paciente>();
        public List<SalasHospitalar> SalasHospitalar { get; set; } = new List<SalasHospitalar>();
        public List<TiposHabitacoesHospitalar> TiposHabitacoesHospitalar { get; set; } = new List<TiposHabitacoesHospitalar>();
        public List<Camas> Camas { get; set; } = new List<Camas>();
    }
}
