using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Models.Financeiro
{
 public   class Saldos
    {
        public double Debito { get; set; }
        public double Credito { get; set; }
        public DateTime Data { get; set; }
        public string DataStr { get; set; }

        public double Total()
        {
            return Credito - Debito;
        }
    }
}
