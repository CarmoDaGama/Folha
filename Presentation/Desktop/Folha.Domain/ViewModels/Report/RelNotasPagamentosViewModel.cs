using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.ViewModels.Report
{
    public class RelNotasPagamentosViewModel
    {
        public string Data { get; set; }
        public string Hora { get; set; }
        public string Entidade { get; set; }
        public string Finalidade { get; set; }
        public string Valor { get; set; }
        public string NomeOperacao { get; set; }
        public string Usuario { get; set; }
        public string strData { get { return Convert.ToDateTime(Data).ToShortDateString(); } }
        public string strValor { get { return Convert.ToDouble(Valor).ToString("N2"); } }
    }
}
