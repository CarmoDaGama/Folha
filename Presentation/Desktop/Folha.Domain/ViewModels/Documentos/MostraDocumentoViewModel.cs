using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.ViewModels.Documentos
{
    public class MostraDocumentoViewModel
    {
        public int Codigo { get; set; }
        public string Data { get; set; }
        public string Hora { get; set; }
        public string Documento { get; set; }
        public string Area { get; set; }
        public string Cliente { get; set; }
        public double Total { get; set; }
        public string Estado { get; set; }
        public string Usuario { get; set; }
        public int CodOperacao { get; set; }
        public int CodCliente { get; set; }
        public string Tipo { get; set; }
        public string Descritivo { get; set; }
    }
}
