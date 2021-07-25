using Folha.Domain.Models.Sistema;
using Folha.Domain.ViewModels.Sistema;
using Folha.Domain.ViewModels.Frame.Admin;
using System.Collections.Generic;

namespace Folha.Domain.Interfaces.Repository.Sistema
{
    public  interface IUsuariosRepository : IRepositoryBase<UsuariosViewModel>
    {
        bool UsuarioAlterado(int codUsuario);
        UsuariosViewModel GetUsuarioPor(string login, string senha);
        bool CredenciasDoUsuarioValidas(string login, string senha);
        int GetCodigoUsuarioPorSenhaAndLogin(string login, string senha);
        string GetNomeUsuarioPorSenhaAndLogin(string login, string senha);
        List<UsuarioViewModel> ListarUsuarios(string criterios);
    }
}
