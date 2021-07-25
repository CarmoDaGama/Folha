using Folha.Domain.ViewModels.Hospitalar;
using System.Collections.Generic;

namespace Folha.Domain.Models.Hospitalar
{
    public class ProfissinalSaude
    {
        public int Codigo { get; set; }
        public int CodEntidade { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public Entidades.Entidades Entidades { get; set; } = new Entidades.Entidades();
        public int status { get; set; }
        public List<AreaSaudeProfissinalViewModel> AreaSaude { get; set; }

        //public ProfissionalSaudeViewModel Profissional { get; set; }

    }
}
