using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.ViewModels.Frame.Financeiro
{
    public class RegistoVendasViewModel
    {
        public int Codigo { get; set; }
        public DateTime Data { get; set; }
        public DateTime Hora { get; set; }
        public string Documento { get; set; }
        public string Area { get; set; }
        public string Entidade { get; set; }
        public decimal Total { get; set; }
        public string Estado { get; set; }
        public string NomeDocumento { get; set; }
        public string Tipo { get; set; }
        public string Usuario { get; set; }
        public string Descritivo { get; set; }
    }
}
