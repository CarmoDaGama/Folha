using System;

namespace Folha.Domain.Models.Hospitalar
{
    public class PacienteInternado
     {
        public int Codigo { get; set; }
        public int CodTarifaHospitalar { get; set; }
        public int CodQuartosHospitalar { get; set; }
        public int CodCamasHospitalar { get; set; }
        public int CodAtendimentoHospitalar { get; set; }
        public string Facturado { get; set; }

        public string Tarifa { get; set; }
        public string Paciente { get; set; }
        public string Quarto { get; set; }
        public string Cama { get; set; }
        public int Dias { get; set; }      
        public DateTime DataEntrada { get; set; }
        public DateTime DataSaida { get; set; }
        public decimal Valor { get; set; }
        public decimal Total { get; set; }
        public string Estado { get; set; }


        public TarifaHospitalar TarifaHospitalar { get; set; }
        public QuartosHospitalar QuartosHospitalar { get; set; }
        public CamasHospitalar CamasHospitalar { get; set; }
        public AtendimentoHospitalar AtendimentoHospitalar { get; set; }


    }
}
