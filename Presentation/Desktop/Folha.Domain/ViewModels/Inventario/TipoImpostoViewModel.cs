using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.ViewModels.Inventario
{
    public class TipoImpostoViewModel
    {
        public int Codigo { get; set; }
        public string NameKey { get { return "Codigo"; } }
        public string Sigla { get; set; }
        public string Descricao { get; set; }
    }
}
