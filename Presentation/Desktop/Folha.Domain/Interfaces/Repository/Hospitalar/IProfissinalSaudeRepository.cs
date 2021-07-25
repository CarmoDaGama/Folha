using Folha.Domain.Interfaces.Repository;
using Folha.Domain.Models.Hospitalar;
using Folha.Domain.ViewModels.Hospitalar;
using System.Collections.Generic;

namespace Folha.Domain.Interfaces.Repository.Hospitalar
{
    public interface IProfissinalSaudeRepository : IRepositoryBase<ProfissionalSaudeViewModel>
    {
        ProfissinalSaude Gravar(ProfissinalSaude profissinal);
        ProfissinalSaude Eliminar(ProfissinalSaude profissinal);
        List<ProfissionalSaudeViewModel> GetAll();
        List<AreaSaudeProfissinalViewModel> GetArea(int codProfissional);
        void DeleteArea(AreaSaudeProfissinalViewModel delete);
        bool VerificarDup(string nomeTabela, Dictionary<string, object> dicionario);
        IEnumerable<ProfissinalSaude> Listar(string criterios);

    }
}
