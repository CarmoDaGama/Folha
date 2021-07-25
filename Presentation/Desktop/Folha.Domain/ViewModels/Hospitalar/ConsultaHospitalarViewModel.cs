using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.ViewModels.Hospitalar
{
    public class ConsultaHospitalarViewModel
    {
        public int Codigo { get; set; }
        public int CodTipoConsulta { get; set; }
        public int CodPrioridade { get; set; }
        public int CodTipoServico { get; set; }
        public int CodMedico { get; set; }
        public int CodEntidade { get; set; }
        public int CodAtendimento { get; set; }
        public int CodEspecialidade { get; set; }
        public int CodImposto { get; set; }
        public int CodMotivoIsencao { get; set; }
        public string TipoConsulta { get; set; }
        public string Prioridade { get; set; }
        public string TipoServico { get; set; }
        public string NomeMedico { get; set; }
        public string Atendido { get; set; }
        public string Data { get; set; }
        public string HoraInicial { get; set; }
        public string TempoEstimado { get; set; }
        public double ValorConsulta { get; set; }
        public string Observacao { get; set; }
        public string Imposto { get; set; }
        public string MotivoIsencao { get; set; }
        public string Percentagem { get; set; }

    }
}
