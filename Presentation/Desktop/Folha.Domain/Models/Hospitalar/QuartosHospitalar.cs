using Folha.Domain.ViewModels.Hospitalar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Models.Hospitalar
{
   public class QuartosHospitalar
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public string Tipo { get; set; }
        public string Area { get; set; }
        public string Manutencao { get; set; }
        public int CodAreasHospitalar { get; set; }
        public int CodTiposQuartosHospitalar { get; set; }

        public List<CamasQuartosHospitalarViewModel> CamasdoQuarto { get; set; }

    }
}
