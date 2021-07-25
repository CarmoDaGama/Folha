using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.ViewModels.Hospitalar
{
    public class InternaViewModel
    {
        /*"SELECT PacienteInternado.Codigo," +
                               "PacienteInternado.DataEntrada, " +
                               "PacienteInternado.Facturado," +
                               "PacienteInternado.Total, " +
                               "TarifaHospitalar.Descricao, " +
                               "Imposto.Percentagem" +*/
        public int Codigo { get; set; }
        public DateTime DataEntrada { get; set; }
        public string Facturado { get; set; }
        public decimal Total { get; set; }
        public string Descricao { get; set; }
        public decimal Percentagem { get; set; }
        public string ImpostoDescricao { get; set; }
        public string CodImposto { get; set; }
        public string DetalheImposto { get; set; }
        public string TipoImposto { get; set; }

    }
}
