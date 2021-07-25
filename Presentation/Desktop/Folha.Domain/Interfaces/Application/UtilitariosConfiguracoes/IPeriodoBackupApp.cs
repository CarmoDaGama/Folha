using Folha.Domain.Models.UtilitariosConfiguracoes;
using Folha.Domain.ViewModels.UtilitariosConfiguracoes;
using System.Collections.Generic;

namespace Folha.Domain.Interfaces.Application.UtilitariosConfiguracoes
{
    public interface IPeriodoBackupApp
    {
        PeriodoBackup Gravar(PeriodoBackup var);
        List<PeriodoBackupViewModel> GetAll();
        PeriodoBackupViewModel GetById(int Codigo);
        IEnumerable<PeriodoBackup> Listar();
    }
}
