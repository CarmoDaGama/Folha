using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Models.Financeiro
{
    public class Moedas
    {
        public int codigo { get; set; }
        public string NameKey { get { return "codigo"; } }
        public string Descricao { get; set; }
        public string Sigla { get; set; }
        public int moedapadrao { get; set; }
    }
}
