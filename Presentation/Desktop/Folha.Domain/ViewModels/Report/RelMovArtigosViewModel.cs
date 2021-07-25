using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.ViewModels.Report
{
    public class RelMovArtigosViewModel
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public double Entradas { get; set; }
        public double Saidas { get; set; }
        public double Stock { get; set; }
        public string Tipo { get; set; }
        public double Quantidade { get; set; }
    }
}
