using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.ViewModels.Hospitalar
{
    public class ConsultaViewModel
    {

        public int Codigo { get; set; }
        public int CodAtendimento { get; set; }
        public string DataConsulta { get; set; }
        public string Observacao { get; set; }
        public string TempoEstimado { get; set; }
        public decimal ValorConsulta { get; set; }
        public string Facturado { get; set; }
        public string Atendido { get; set; }
        public string Motivoisencao { get; set; }
        public string DescricaoImposto { get; set; }
        public decimal ImpostoPercentagem { get; set; }
        public string TipoConsultasDescricao { get; set; }
        public string CodImposto { get; set; }
        public string DetalheImposto { get; set; }
        public string TipoImposto { get; set; }
    }
}
