using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.ViewModels.Hospitalar
{
    public class FarmacoReceitaViewModel
    {
        public int CodFarmaco { get; set; }
        public int CodFarmacoReceita { get; set; }
        public int CodPaciente { get; set; }
        public int CodReceita{ get; set; }
        public string Descricao { get; set; }
        public int CodAtendimento { get; set; }
    }
}
