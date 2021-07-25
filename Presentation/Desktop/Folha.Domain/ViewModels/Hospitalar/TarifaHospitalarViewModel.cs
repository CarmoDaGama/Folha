using Folha.Domain.ViewModels.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.ViewModels.Hospitalar
{
    public class TarifaHospitalarViewModel
    {

        public int Codigo { get; set; }
        public string NameKey { get { return "Codigo"; } }
        public string Descricao { get; set; }
        public int CodTiposQuartosHospitalar { get; set; }
        public int CodTiposCamasHospitalar { get; set; }
        public int CodImposto { get; set; }
        public int CodMotivoIsencao { get; set; }
        public string TipoTarifa { get; set; }
        public int Horas { get; set; }
        public decimal Valor { get; set; }
        


        public TiposQuartosHospitalarViewModel TiposQuartosHospitalar { get; set; } = new TiposQuartosHospitalarViewModel();
        public ForeignKey FKeyTiposQuartosHospitalar
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

        public ImpostoViewModel Imposto { get; set; } = new ImpostoViewModel();
        public ForeignKey FKeyImposto
        {
            get
            {
                return new ForeignKey()
                {
                    NameTable = "Imposto",
                    NameEntity = "Imposto",
                    NameFieldThis = "CodImposto",
                    NameFieldOrigin = "Codigo"
                };
            }
        }

        public MotivoIsencaoViewModel MotivoIsencao { get; set; } = new MotivoIsencaoViewModel();
        public ForeignKey FKeyMotivoIsencao
        {
            get
            {
                return new ForeignKey()
                {
                    NameTable = "MotivoIsencao",
                    NameEntity = "MotivoIsencao",
                    NameFieldThis = "CodMotivoIsencao",
                    NameFieldOrigin = "Codigo"
                };
            }
        }
    }
}
