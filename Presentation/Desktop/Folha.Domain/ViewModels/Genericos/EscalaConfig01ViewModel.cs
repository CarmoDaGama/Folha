using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.ViewModels.Genericos
{
    public class EscalaConfig01ViewModel
    {
        public int Codigo { get; set; }
        public int CodEscala{ get; set; }
        public string DescricaoDias { get; set; }
        public string Entrada { get; set; }
        public string Saida { get; set; }
        public bool Checa { get; set; }
    }
}
