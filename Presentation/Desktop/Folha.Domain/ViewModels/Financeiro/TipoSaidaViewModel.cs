using Folha.Domain.Models.Financeiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.ViewModels.Financeiro
{
    public class TipoSaidaViewModel:TipoSaida
    {
        public bool Checa { get; set; }
    }
}
