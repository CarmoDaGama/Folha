using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.ViewModels.Report
{
    public class RelListagemArtigosViewModel
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }
        public double Preco1 { get; set; }
        public double Preco2 { get; set; }
        public double Preco3 { get; set; }
        public double Quantidade  { get; set; }
        public double Custo { get; set; }
        public string Familia { get; set; }
        public double StockMin { get; set; }
        public double Retencao { get; set; }
        public int Total { get; set; }
    }
}
