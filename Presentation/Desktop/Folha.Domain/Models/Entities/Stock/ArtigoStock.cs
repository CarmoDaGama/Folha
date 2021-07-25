using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise.Domain.Entities.Stock
{
    public class ArtigoStock : Entity
    {
        public Artigo Artigo { get; set; }
        //[CodArmazem]
        public Armazem Armazem { get; set; }
        //[qtde]
        public int Qtdade { get; set; }
        //[stockMin]
        public int StockMin { get; set; }
        //[stockMax]
        public int StockMax { get; set; }
        //[CodEmpresa]
        //public Entidades Empresa { get; set; }
    }
}
