using Folha.Domain.Models.Hospitalar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.ViewModels.Hospitalar
{
    public class CamasQuartosHospitalarViewModel
    {
        public int Codigo { get; set; }
        public int CodCamasHospitalar { get; set; }
        public int CodQuartosHospitalar { get; set; }
        public string Descricao { get; set; }
        public string Tipo { get; set; }
        public CamasHospitalar CamasHospitalar { get; set; }
    }
}
