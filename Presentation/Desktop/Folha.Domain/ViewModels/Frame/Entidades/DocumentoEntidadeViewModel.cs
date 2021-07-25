using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.ViewModels.Frame.Entidades
{
    public class DocumentoEntidadeViewModel
    {       
        public string Codigo { get; set; }
        public string CodTipoDocumento { get; set; }
        public string TipoDocumento { get; set; }
        public string Numero { get; set; }
        public DateTime Emissao { get; set; }
        public DateTime Validade { get; set; }
    }
}
