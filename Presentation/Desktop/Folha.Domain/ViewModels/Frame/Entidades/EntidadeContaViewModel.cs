using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.ViewModels.Frame.Entidades
{
    public class EntidadeContaViewModel
    {
        public string Codigo { get; set; }
        public string CodBanco { get; set; }
        public string Banco { get; set; }
        public string Numero { get; set; }
        public string Natureza { get; set; }
        public string Sequencia { get; set; }
        public string Iban { get; set; }
        public string Swift { get; set; }
    }
}
