using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.ViewModels.Frame.Financeiro
{
    public class BuscaDocNotaPagamentoViewModel
    {
        public int Codigo { get; set; }
        public string Entidade { get; set; }
        public DateTime Data { get; set; }
        public string Hora { get; set; }
        public string Estado { get; set; }
        public string Usuario { get; set; }
    }
}
