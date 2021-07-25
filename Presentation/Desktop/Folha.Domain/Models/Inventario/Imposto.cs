using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Models.Inventario
{
    public class Imposto
    {
        public int Codigo { get; set; }
        public string NameKey { get { return "Codigo"; } }
        public string Descricao { get; set; }
        public decimal Percentagem { get; set; }


        public Empresa.Empresa CabecalhoEmpresa { get; set; }
         
    }
}
