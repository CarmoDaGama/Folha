using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Models.Escolar
{
    public class Disciplina:Entity
    {
        public string Descricao { get; set; }
        public string Abreviatura { get; set; }
    }
}
