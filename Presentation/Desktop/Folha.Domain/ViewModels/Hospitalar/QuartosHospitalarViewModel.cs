using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.ViewModels.Hospitalar
{
    public class QuartosHospitalarViewModel
    {
        #region Relacionamento
        public QuartosHospitalarViewModel()
        {
            CamasQuarto = new List<CamasQuartosHospitalarViewModel>();
        }
        #endregion
        public List<CamasQuartosHospitalarViewModel> CamasQuarto { get; set; }
        public int Codigo { get; set; }
        public string NameKey { get { return "Codigo"; } }
        public int CodAreasHospitalar { get; set; }
        public string Descricao { get; set; }
        public int CodTiposQuartosHospitalar { get; set; }
        public AreasHospitalarViewModel AreasHospitalar { get; set; } = new AreasHospitalarViewModel();
        public ForeignKey FKeyAreasHospitalar
        {
            get
            {
                return new ForeignKey()
                {
                    NameTable = "AreasHospitalar",
                    NameEntity = "AreasHospitalar",
                    NameFieldThis = "CodAreasHospitalar",
                    NameFieldOrigin = "Codigo"
                };
            }
        }
        public TiposQuartosHospitalarViewModel TiposQuartosHospitalar { get; set; } = new TiposQuartosHospitalarViewModel();
        public ForeignKey FKeyCodTiposQuartosHospitalar
        {
            get
            {
                return new ForeignKey()
                {
                    NameTable = "TiposQuartosHospitalar",
                    NameEntity = "TiposQuartosHospitalar",
                    NameFieldThis = "CodTiposQuartosHospitalar",
                    NameFieldOrigin = "Codigo"
                };
            }
        }

    }
}
