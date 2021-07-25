using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Models.Hospitalar
{
    public class TarifaHospitalar
    {

        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public int CodTiposQuartosHospitalar { get; set; }
        public int CodTiposCamasHospitalar { get; set; }
        public int CodImposto { get; set; }
        public int CodMotivoIsencao { get; set; }
        public string TipoTarifa { get; set; }
        public int Horas { get; set; }
        public decimal Valor { get; set; }

        public string TipoQuarto { get; set; }
        public string TipoCama { get; set; }
        public string TipoImposto { get; set; }
        public string NomeIsencao { get; set; }

    }
}
