using Folha.Domain.Interfaces.Application.UtilitariosConfiguracoes;
using Folha.Domain.Models.UtilitariosConfiguracoes;
using Folha.Domain.ViewModels.UtilitariosConfiguracoes;
using Folha.Domain.Interfaces.Repository.UtilitariosConfiguracoes;
using System;
using System.Collections.Generic;

namespace Folha.Driver.Application.UtilitariosConfiguracoes
{
    public class PerfilNovoApp : IPerfilNovoApp
    {
        private readonly IPerfilNovoRepository _perfilRepository;

        public PerfilNovoApp(IPerfilNovoRepository perfilRepository)
        {
            _perfilRepository = perfilRepository;

        }

        public List<string> CarregarAcessos(string login, string senha)
        {
            return _perfilRepository.CarregarAcessos(login, senha);
        }

        public void Delete(Perfil perfil)
        {
            _perfilRepository.Delete(perfil);
        }

        public List<PerfilViewModel> GetAll()
        {
            return (List<PerfilViewModel>)_perfilRepository.GetAll(new PerfilViewModel());

        }

        public Perfil GetById(int codigo)
        {
            throw new NotImplementedException();
        }

        public void Insert(Perfil entity)
        {
            _perfilRepository.Insert(entity);
        }

        public IEnumerable<Perfil> Listar(string criterios, bool Pesquisa)
        {
            return (List<Perfil>)_perfilRepository.Listar(criterios);

        }

        public void Update(Perfil entity)
        {
            _perfilRepository.Update(entity);
        }
    }
}
