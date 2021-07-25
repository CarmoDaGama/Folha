using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.ViewModels.Report
{
    public class RelOpercoesViewModel
    {
        public int Codigo { get; set; }
        public int CodOperacao { get; set; }
        public DateTime Data { get; set; }
        public string Hora { get; set; }
        public string Documento { get; set; }
        public string Tipo { get; set; }
        public double Total { get; set; }
        public string Cliente { get; set; }
        public string Usuario { get; set; }
        public bool Checa { get; set; }
    }
}
