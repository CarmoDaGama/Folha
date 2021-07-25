using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.ViewModels.Financeiro
{
    public class MostraMoedasViewModel:MoedasViewModel
    {
        public bool Padrao { get; set; }
        public string PadraoStr { get; set; }
    }
}
