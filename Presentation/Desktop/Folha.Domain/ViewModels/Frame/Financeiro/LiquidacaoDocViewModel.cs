using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.ViewModels.Frame.Financeiro
{
    public class LiquidacaoDocViewModel
    {
        public int Codigo { get; set; }
        public DateTime Data { get; set; }
        public string Hora { get; set; }
        public string Documento { get; set; }
        public string Total { get; set; }
        public string CodEntidade { get; set; }
        public string Entidade { get; set; }
        public string Estado { get; set; }
    }
}
