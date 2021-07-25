using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.ViewModels.Report
{
    public class SaldoBancoViewModel
    {
        public string Conta { get; set; }
        public string Banco { get; set; }
        public double Saldo { get; set; }
    }
}
