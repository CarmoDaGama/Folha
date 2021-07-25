using Folha.Domain.ViewModels.Documentos;
using Folha.Domain.ViewModels.Entidades;

namespace Folha.Domain.ViewModels.Hospitalar
{
    public class MovHospitalarViewModel
    {
        public DocumentosViewModel Documento { get; set; } = new DocumentosViewModel();
        public ForeignKey FkDocumento
        {
            get
            {
                return new ForeignKey()
                {
                    NameEntity = "Documento",
                    NameFieldOrigin = "Codigo",
                    NameFieldThis = "CodDocumento",
                    NameTable = "Documentos"
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
         public int Codigo { get; set; }
        public string NameKey { get { return "Codigo"; } }
        public int CodDocumento { get; set; }
        public int CodQuartosHospitalar { get; set; }
        public int CodTarifaHospitalar { get; set; }
        public string Checkin { get; set; }
        public int Horas { get; set; }
        public string Quantidade { get; set; }
        public string Preco { get; set; }

    }
}
