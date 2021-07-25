using System;
using System.Collections.Generic;
using Folha.Domain.Interfaces.Application.UtilitariosConfiguracoes;
using Folha.Domain.Models.UtilitariosConfiguracoes;
using Folha.Domain.ViewModels.UtilitariosConfiguracoes;
using Folha.Domain.Interfaces.Repository.UtilitariosConfiguracoes;

namespace Folha.Driver.Application.UtilitariosConfiguracoes
{
    public class UsuarioNovoApp : IUsuarioNovoApp
    {
        private readonly IUsuarioNovoRepository _usuariosRepository;

        public UsuarioNovoApp(IUsuarioNovoRepository usuariosRepository)
        {
            _usuariosRepository = usuariosRepository;
        }

        public void Delete(Usuarios usuario)
        {
            _usuariosRepository.Delete(usuario);
        }
        public IEnumerable<Usuarios> Listar(string criterios, bool Pesquisa)
        {
            return (List<Usuarios>)_usuariosRepository.Listar(criterios);
        }
        public List<UsuariosViewModel> GetAll()
        {
            return (List<UsuariosViewModel>)_usuariosRepository.GetAll(new UsuariosViewModel());
        }
        public UsuariosViewModel GetById(int codigo)
        {
            return (UsuariosViewModel)_usuariosRepository.Get(new UsuariosViewModel() { codigo = codigo });
        }
        public Usuarios Gravar(Usuarios usuario)
        {
            return _usuariosRepository.Gravar(usuario);
        }

        public bool VerificarDup(string nomeTabela, Dictionary<string, object> dicionario)
        {
            return _usuariosRepository.VerificarDup(nomeTabela, dicionario);
        }
        public bool UsuarioAlterado(int codUsuario)
        {
            return _usuariosRepository.UsuarioAlterado(codUsuario);
        }
    }
}
