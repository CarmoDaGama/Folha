using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.ViewModels.Admin
{
   public class NotificaoManutencaoViewModel
    {
        public int Codigo { get; set; }
        public int CodSector { get; set; }
        public string Data { get; set; }
        public string Descricao { get; set; }
        public string DataInicio { get; set; }
        public string DataTermino { get; set; }
        public int CodTecnico { get; set; }
        public int CodUsuario { get; set; }
        public int status { get; set; }
    }
}
