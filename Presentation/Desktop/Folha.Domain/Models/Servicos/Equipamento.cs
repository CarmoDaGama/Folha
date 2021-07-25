using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Models.Servicos
{
   public class Equipamento : Entity
    {
        public Modelo Modelo { get; set; }
        public Fabricante Fabricante { get; set; }
        public string Matricula { get; set; }
        public string NumeroSerie { get; set; }
    }
}
