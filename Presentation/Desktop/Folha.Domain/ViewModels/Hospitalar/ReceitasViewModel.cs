using Folha.Domain.Models.Hospitalar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.ViewModels.Hospitalar
{
   public  class ReceitasViewModel : Receitas

    {
        public string NomeMedico { get; set; }
        public string TipoConsulta { get; set; }
        public string Atendido { get; set; }
    }
}
