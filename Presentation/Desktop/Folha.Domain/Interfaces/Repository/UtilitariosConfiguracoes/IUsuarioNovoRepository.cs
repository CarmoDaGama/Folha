using Folha.Domain.Interfaces.Repository;
using Folha.Domain.Models.UtilitariosConfiguracoes;
using Folha.Domain.ViewModels.UtilitariosConfiguracoes;
using System.Collections.Generic;

namespace Folha.Domain.Interfaces.Repository.UtilitariosConfiguracoes
{
    public interface IUsuarioNovoRepository : IRepositoryBase<UsuariosViewModel>
    {
        bool UsuarioAlterado(int codUsuario);
        IEnumerable<Usuarios> Listar(string criterios);
        void Delete(Usuarios usuario);
        Usuarios Gravar(Usuarios usuario);
        List<UsuariosViewModel> GetAll();
        bool VerificarDup(string nomeTabela, Dictionary<string, object> dicionario);

    }
}
