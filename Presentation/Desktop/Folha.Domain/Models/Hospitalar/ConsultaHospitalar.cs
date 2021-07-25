using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Models.Hospitalar
{
    public class ConsultaHospitalar
    {
        public int Codigo { get; set; }
        public int CodPaciente { get; set; }
        public int CodTipoConsulta { get; set; }
        public DateTime Data { get; set; }
        public string HoraInicial { get; set; }
        public string TempoEstimado { get; set; }
        public double ValorConsulta { get; set; }
        public int CodPrioridade { get; set; }
        public int CodTipoServico { get; set; }
        public int CodMedico { get; set; }
        public int CodImposto { get; set; }
        public int CodMotivoIsencao { get; set; }
        public string Observacao { get; set; }
        public int status { get; set; }
        public string Atendido { get; set; }
        public string Facturado { get; set; }
        public int CodAtendimento{ get; set; }


        public string Anaminizes { get; set; }
        public string QueixaPrincipal { get; set; }
        public string EvolucaoTratamento { get; set; }

    }
}
