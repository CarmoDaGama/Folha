using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Models.Hospitalar
{
    public class Farmacos
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }

        //-----------------------------------------
        public int CodFarmacoReceita { get; set; }
    }
}
