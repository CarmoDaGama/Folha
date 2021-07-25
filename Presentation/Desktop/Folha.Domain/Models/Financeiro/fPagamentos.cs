using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Models.Financeiro
{
   public  class fPagamentos
    {
        public int codigo { get; set; }
        public string NameKey { get { return "codigo"; } }
        public string descricao { get; set; }
        public string Movimentar { get; set; }
        public string  CodConta { get; set; }
        public int Sistema { get; set; }
    }
}
