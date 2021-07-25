using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise.Domain.Entities.Stock
{
    public class StockContagem:Entity
    {
        public int CodProduto { get; set; }
        public string Descricao { get; set; }
        public Armazem Armazem { get; set; }
        public int CodArmazem { get; set; }
    }
}
