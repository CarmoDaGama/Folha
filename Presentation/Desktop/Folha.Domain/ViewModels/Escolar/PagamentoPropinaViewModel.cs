using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.ViewModels.Escolar
{
    public class PagamentoPropinaViewModel
    {
        
        public int Codigo { get; set; }
        public int CodEmolumento { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public double Multa { get; set; }
        public double Desconto { get; set; }
        public double Total { get; set; }
        public int status { get; set; }
    }
}
