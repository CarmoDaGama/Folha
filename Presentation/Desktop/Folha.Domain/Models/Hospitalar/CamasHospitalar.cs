using Folha.Domain.ViewModels.Hospitalar;

namespace Folha.Domain.Models.Hospitalar
{
    public  class CamasHospitalar
    {
        public int Codigo { get; set; }
        public string NameKey { get { return "Codigo"; } }
        public string Descricao { get; set; }
        public string Tipo { get; set; }
        public string Ocupado { get; set; }
        public int CodTiposCamasHospitalar { get; set; }
        public TiposCamasHospitalarViewModel TiposCamasHospitalar { get; set; } = new TiposCamasHospitalarViewModel();
        public ForeignKey FKeyTiposCamasHospitalar
        {
            get
            {
                return new ForeignKey()
                {
                    NameTable = "TiposCamasHospitalar",
                    NameEntity = "TiposCamasHospitalar",
                    NameFieldThis = "CodTiposCamasHospitalar",
                    NameFieldOrigin = "Codigo"
                };
            }
        }
    }
}
