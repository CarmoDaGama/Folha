using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.ViewModels.Principal
{
    public class PostoVendaViewModel
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public int Preco { get; set; }
        public int Desconto { get; set; }
        public int IPC { get; set; }
        public int Arm { get; set; }
        public int Qtdade { get; set; }
        public int Total { get; set; }
    }
}
