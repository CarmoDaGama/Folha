using Folha.Domain.ViewModels.Frame.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.ViewModels.Report
{
    public class RelMedicoViewModel: AllEntidadeViewModel
    {
        
        public string Contacto1 { get; set; }
        public string Contacto2 { get; set; }
        public string Morada { get; set; }
        public string NumeroCarteira { get; set; }
        public string Contribuinte { get; set; }
    }
}
