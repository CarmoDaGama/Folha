using Folha.Domain.Models.Entidades;
using Folha.Domain.Models.Hospitalar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.ViewModels.Hospitalar
{
    public class InternamentoViewModel
    {

        public InternamentoViewModel()
        {
            Camas = new List<Camas>();
            TiposHabitacoesHospitalar = new List<TiposHabitacoesHospitalar>();
        }

        public int Codigo { get; set; }
        public int CodPessoa { get; set; }
        public int CodPaciente { get; set; }
        public int CodAreasHospitalar { get; set; }
        public int CodSalasHospitalar { get; set; }
        public int CodCama { get; set; }
        public DateTime Entrada { get; set; }

        public string Nome { get; set; }
        public Paciente Paciente { get; set; }


        public AreaHospitalar AreasHospitalar { get; set; }
        public SalasHospitalar SalasHospitalar { get; set; }
        public Camas CamasHospitalar { get; set; }
        public TiposHabitacoesHospitalar TiposHabitacaoHospitalar { get; set; }

        public List<Camas> Camas { get; set; }
        public List<TiposHabitacoesHospitalar> TiposHabitacoesHospitalar { get; set; }

    }
}
