using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.ViewModels.Admin
{
   public class NotificaoTarefasViewModel
    {
        public int codigo { get; set; }
        public string Descricao { get; set; }
        public string DataHora { get; set; }
        public int CodFuncionario { get; set; }
        public int CodUsuario { get; set; }
        public string Estado { get; set; }
    }
}
