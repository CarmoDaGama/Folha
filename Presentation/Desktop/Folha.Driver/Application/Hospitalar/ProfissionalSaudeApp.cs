using System;
using System.Collections.Generic;
using Folha.Domain.Interfaces.Application.Hospitalar;
using Folha.Domain.Models.Hospitalar;
using Folha.Domain.ViewModels.Hospitalar;
using Folha.Domain.Interfaces.Repository.Hospitalar;

namespace Folha.Driver.Application.Hospitalar
{
    public class ProfissionalSaudeApp : IProfissinalSaudeApp
    {
        private readonly IProfissinalSaudeRepository _profSaudeRepository;
        public ProfissionalSaudeApp(IProfissinalSaudeRepository profSaudeRepository)
        {
            _profSaudeRepository = profSaudeRepository;
        }
        public void DeleteArea(AreaSaudeProfissinalViewModel delete)
        {
            _profSaudeRepository.DeleteArea(delete);
        }

        public void EditProfissinal(ProfissionalSaudeViewModel entity)
        {
            _profSaudeRepository.Update(entity);
        }

        public ProfissinalSaude Eliminar(ProfissinalSaude profissinal)
        {
            return _profSaudeRepository.Eliminar(profissinal);
        }

        public List<ProfissionalSaudeViewModel> GetAll()
        {
            return (List<ProfissionalSaudeViewModel>)_profSaudeRepository.GetAll(new ProfissionalSaudeViewModel());
        }

        public List<AreaSaudeProfissinalViewModel> GetArea(int codProfissional)
        {
            return _profSaudeRepository.GetArea(codProfissional);
        }

        public ProfissionalSaudeViewModel GetById(int codigo)
        {
            return (ProfissionalSaudeViewModel)_profSaudeRepository.Get(new ProfissionalSaudeViewModel() { Codigo = codigo });
        }

        public ProfissinalSaude Gravar(ProfissinalSaude profissinal)
        {
            return _profSaudeRepository.Gravar(profissinal);
        }

        public IEnumerable<ProfissinalSaude> Listar(string criterios, bool Pesquisa)
        {
            return (List<ProfissinalSaude>)_profSaudeRepository.Listar(criterios);
        }

        public void RemoverProfisional(ProfissionalSaudeViewModel profissional)
        {
            _profSaudeRepository.Delete(profissional);
        }

        public bool VerificarDup(string nomeTabela, Dictionary<string, object> dicionario)
        {
            return _profSaudeRepository.VerificarDup(nomeTabela, dicionario);
        }
    }
}
