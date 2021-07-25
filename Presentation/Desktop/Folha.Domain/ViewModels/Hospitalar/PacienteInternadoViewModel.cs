using System;

namespace Folha.Domain.ViewModels.Hospitalar
{
    public class PacienteInternadoViewModel
    {

        public int Codigo { get; set; }

        public int CodQuartosHospitalar { get; set; }
        public int CodCamasHospitalar { get; set; }
        public int CodTarifaHospitalar { get; set; }
        public int Dias { get; set; }
        public decimal Valor { get; set; }
        public decimal Total { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime DataSaida { get; set; }
        public string Estado { get; set; }


        public string Facturado { get; set; }
        public int CodAtendimentoHospitalar { get; set; }


        public TarifaHospitalarViewModel TarifaHospitalar { get; set; } = new TarifaHospitalarViewModel();
        public ForeignKey FkTarifaHospitalar
        {
            get
            {
                return new ForeignKey()
                {
                    NameEntity = "TarifaHospitalar",
                    NameTable = "TarifaHospitalar",
                    NameFieldOrigin = "Codigo",
                    NameFieldThis = "CodTarifaHospitalar"
                };
            }
        }
        public QuartosHospitalarViewModel QuartosHospitalar { get; set; } = new QuartosHospitalarViewModel();
        public ForeignKey FkQuartosHospitalar
        {
            get
            {
                return new ForeignKey()
                {
                    NameEntity = "QuartosHospitalar",
                    NameTable = "QuartosHospitalar",
                    NameFieldOrigin = "Codigo",
                    NameFieldThis = "CodQuartosHospitalar"
                };
            }
        }
        public CamasHospitalarViewModel CamasHospitalar { get; set; } = new CamasHospitalarViewModel();
        public ForeignKey FKeyCamasHospitalar
        {
            get
            {
                return new ForeignKey()
                {
                    NameTable = "CamasHospitalar",
                    NameEntity = "CamasHospitalar",
                    NameFieldThis = "CodCamasHospitalar",
                    NameFieldOrigin = "Codigo"
                };
            }
        }
        public AtendimentoHospitalarViewModel AtendimentoHospitalar { get; set; } = new AtendimentoHospitalarViewModel();
        public ForeignKey FKeyAtendimentoHospitalar
        {
            get
            {
                return new ForeignKey()
                {
                    NameTable = " AtendimentoHospitalar",
                    NameEntity = " AtendimentoHospitalar",
                    NameFieldThis = "Cod AtendimentoHospitalar",
                    NameFieldOrigin = "Codigo"
                };
            }
        }


    }
}
