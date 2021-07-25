using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.ViewModels.Financeiro
{
    public class FluxoCaixaViewModel
    {
        public string Data { get; set; }
        public string Hora { get; set; }
        public string Descricao { get; set; }
        public string Tipo { get; set; }
        public string Valor { get; set; }
        public int NumeroDoc { get; set; }
        public string Operacao { get; set; }
        public string Usuario { get; set; }

        public string strData { get { return Convert.ToDateTime(Data).ToShortDateString(); } }
        public string strValor { get { return Convert.ToDouble(Valor).ToString("N2"); } }
    }
}
