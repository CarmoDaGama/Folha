using System;
using System.Collections.Generic;
using Folha.Domain.Interfaces.Application.Sistema;
using Folha.Domain.Models.Sistema;
using Folha.Domain.Interfaces.Repository.Sistema;
using Folha.Domain.ViewModels.Frame.Admin;
using Folha.Domain.ViewModels.Sistema;

namespace Folha.Driver.Application.Sistema
{

    public class UsuariosApp : IUsuariosApp
    {

        private readonly IUsuariosRepository _Repository;

        public UsuariosApp(IUsuariosRepository Repository)
        {
            _Repository = Repository;
        }
        public void addUsuario(UsuariosViewModel entity)
        {
            _Repository.Insert(entity);
        }

        public bool CredenciasDoUsuarioValidas(string login, string senha)
        {
            return _Repository.CredenciasDoUsuarioValidas(login, senha);
        }

        public void EditUsuario(UsuariosViewModel entity)
        {
            _Repository.Update(entity);
        }

        public UsuariosViewModel GetById(int usuarioCodigo)
        {
            return (UsuariosViewModel)_Repository.Get(new UsuariosViewModel() { codigo = usuarioCodigo });
        }

        public int GetCodigoUsuarioPorSenhaAndLogin(string login, string senha)
        {
            return _Repository.GetCodigoUsuarioPorSenhaAndLogin(login, senha);
        }

        public string GetNomeUsuarioPorSenhaAndLogin(string login, string senha)
        {
            return _Repository.GetNomeUsuarioPorSenhaAndLogin(login, senha);
        }

        public UsuariosViewModel GetUsuarioPor(string login, string senha)
        {
            return _Repository.GetUsuarioPor(login, senha);
        }

        public List<UsuarioViewModel> Listar() { 
            throw new NotImplementedException();

        }

        public bool UsuarioAlterado(int codUsuario)
        {
            return _Repository.UsuarioAlterado(codUsuario);
        }
    }
}
