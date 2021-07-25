using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.ViewModels.Financeiro
{
    public class LiquidacaoDocumentoViewModel
    {
        public int Codigo { get; set; }
        public DateTime Data { get; set; }
        public DateTime Hora { get; set; }
        public string Documento { get; set; }
        public int Total { get; set; }
        public string Entidade { get; set; }
    }
}
