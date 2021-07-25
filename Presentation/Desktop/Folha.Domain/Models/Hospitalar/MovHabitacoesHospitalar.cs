using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Models.Hospitalar
{
    public class MovHabitacoesHospitalar
    {
        public int Codigo { get; set; }
        public int CodDocumento { get; set; }
        public int CodQuartosHospitalar { get; set; }
        public int CodTarifa { get; set; }
        public string Checkin { get; set; }
        public string CheckOut { get; set; }
        public string Preco { get; set; }
        public string Total { get; set; }
        


    }
}
