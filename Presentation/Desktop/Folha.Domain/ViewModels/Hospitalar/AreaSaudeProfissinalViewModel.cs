using Folha.Domain.ViewModels.Genericos;

namespace Folha.Domain.ViewModels.Hospitalar
{
    public class AreaSaudeProfissinalViewModel
    {
        public int Codigo { get; set; }
        public int CodAreaSaude { get; set; }
        public int CodProfissional { get; set; }
        public string Descricao { get; set; }

        public AreaSaudeViewModel AreaSaude { get; set; }

    }

}
