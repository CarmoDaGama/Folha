using Folha.Domain.Interfaces.Repository;
using Folha.Domain.Models.UtilitariosConfiguracoes;
using Folha.Domain.ViewModels.UtilitariosConfiguracoes;
using System.Collections.Generic;

namespace Folha.Domain.Interfaces.Repository.UtilitariosConfiguracoes
{
    public interface IPeriodoBackupRepository : IRepositoryBase<PeriodoBackupViewModel>
    {
        PeriodoBackup Gravar(PeriodoBackup var);
        List<PeriodoBackupViewModel> GetAll();
        PeriodoBackupViewModel GetById(int Codigo);
        IEnumerable<PeriodoBackup> Listar();
    }
}
