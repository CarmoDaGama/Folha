using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Models.Sistema
{
   public class Perfil
    {
        public int codigo { get; set; }
        public string NameKey { get { return "codigo"; } }
        public string Name { get; set; }
        public string Descricao { get; set; }
        public string Acessos { get; set; }
    }
}
