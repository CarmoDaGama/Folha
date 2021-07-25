using Folha.Domain.Models.Hospitalar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.ViewModels.Hospitalar
{
    public class SalasHospitalarViewModel
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }

        public AreaHospitalar AreaHospitalar { get; set; }
        public string Sala { get; set; }

        //Registro provisorio
        public int Codpaciente { get; set; }
        public string paciente { get; set; }


    }
}
