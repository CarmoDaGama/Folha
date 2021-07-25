using Folha.Domain.Interfaces.Application.UtilitariosConfiguracoes;
using Folha.Domain.Models.UtilitariosConfiguracoes;
using Folha.Domain.ViewModels.UtilitariosConfiguracoes;
using Folha.Domain.Interfaces.Repository.UtilitariosConfiguracoes;
using System.Collections.Generic;

namespace Folha.Driver.Application.UtilitariosConfiguracoes
{
    public class PeriodoBackupApp : IPeriodoBackupApp
    {
        private readonly IPeriodoBackupRepository _Repository;

        public PeriodoBackupApp(IPeriodoBackupRepository Repository)
        {
            _Repository = Repository;
        }

        public List<PeriodoBackupViewModel> GetAll()
        {
            return (List<PeriodoBackupViewModel>)_Repository.GetAll(new PeriodoBackupViewModel());
        }

        public PeriodoBackupViewModel GetById(int Codigo)
        {
            return (PeriodoBackupViewModel)_Repository.Get(new PeriodoBackupViewModel() { Codigo = Codigo });
        }

        public PeriodoBackup Gravar(PeriodoBackup var)
        {
            return _Repository.Gravar(var);
        }

        public IEnumerable<PeriodoBackup> Listar()
        {
            return (List<PeriodoBackup>)_Repository.Listar();
        }
    }
}
