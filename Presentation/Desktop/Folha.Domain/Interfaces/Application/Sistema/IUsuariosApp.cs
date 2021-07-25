using Folha.Domain.Models.Sistema;
using Folha.Domain.ViewModels.Sistema;
using Folha.Domain.ViewModels.Frame.Admin;
using System.Collections.Generic;

namespace Folha.Domain.Interfaces.Application.Sistema
{
    public interface IUsuariosApp
    {
        bool UsuarioAlterado(int codUsuario);
        UsuariosViewModel GetUsuarioPor(string login, string senha);
        bool CredenciasDoUsuarioValidas(string login, string senha);
        int GetCodigoUsuarioPorSenhaAndLogin(string login, string senha);
        string GetNomeUsuarioPorSenhaAndLogin(string login, string senha);
        void addUsuario(UsuariosViewModel entity);
        void EditUsuario(UsuariosViewModel entity);
        List<UsuarioViewModel> Listar();
        UsuariosViewModel GetById(int usuarioCodigo);
    }
}
