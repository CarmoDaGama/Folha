using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.ViewModels.Report
{
    public class DadosReportViewModel
    {
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public string Caixa { get; set; }
        public string Conta { get; set; }
        public string NomeEntidade { get; set; }
        public string Usuario { get; set; }
        public double Total { get; set; }
        public string Armazem { get; set; }
        public string Titulo { get; set; }
        public string Cliente { get; set; }
        public int CodCliente { get; set; }

    }
}
