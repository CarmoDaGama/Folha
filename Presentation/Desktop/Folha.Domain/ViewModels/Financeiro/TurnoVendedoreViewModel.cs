using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.ViewModels.Financeiro
{
    public class TurnoVendedoreViewModel
    {
        public int Codigo { get; set; }
        public string Estado { get; set; }
        public string Usuario { get; set; }
        public DateTime Abertura { get; set; }
        public string Fecho { get; set; }
        public int Inicial { get; set; }
        public int Informado { get; set; }
        public int Vendas { get; set; }
        public int Total { get; set; }
        public int Quebra { get; set; }
        public string Caixa { get; set; }
        public string Supervisor { get; set; }
        public string DataConfirmacao { get; set; }
    }
}
