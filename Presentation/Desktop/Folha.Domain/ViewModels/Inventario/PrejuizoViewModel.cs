using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.ViewModels.Inventario
{
    public class PrejuizoViewModel
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public string Armazem { get; set; }
        public string Stock { get; set; }
        public string Fisico { get; set; }
        public string Info { get; set; }
        public string Difenca { get; set; }
        public string Prejuizo { get; set; }
    }
}
