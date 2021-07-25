using Folha.Domain.Models.Hospitalar;
using Folha.Domain.ViewModels.Hospitalar;
using System.Collections.Generic;

namespace Folha.Domain.Interfaces.Application.Hospitalar
{
    public interface IProfissinalSaudeApp
    {
        ProfissinalSaude Gravar(ProfissinalSaude profissinal);
        ProfissinalSaude Eliminar(ProfissinalSaude profissinal);
        ProfissionalSaudeViewModel GetById(int codigo);
        void EditProfissinal(ProfissionalSaudeViewModel entity);
        void RemoverProfisional(ProfissionalSaudeViewModel profissional);
        void DeleteArea(AreaSaudeProfissinalViewModel delete);
        bool VerificarDup(string nomeTabela, Dictionary<string, object> dicionario);
        List<AreaSaudeProfissinalViewModel> GetArea(int codProfissional);
        List<ProfissionalSaudeViewModel> GetAll();
        IEnumerable<ProfissinalSaude> Listar(string criterios, bool Pesquisa);
    }
}
