using Folha.Domain.Models.UtilitariosConfiguracoes;
using Folha.Domain.ViewModels.UtilitariosConfiguracoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Interfaces.Application.UtilitariosConfiguracoes
{
    public interface IUsuarioNovoApp
    {
        bool UsuarioAlterado(int codUsuario);
        Usuarios Gravar(Usuarios usuario);
        List<UsuariosViewModel> GetAll();
        UsuariosViewModel GetById(int codigo);
        void Delete(Usuarios usuario);
        IEnumerable<Usuarios> Listar(string criterios, bool Pesquisa);
        bool VerificarDup(string nomeTabela, Dictionary<string, object> dicionario);

    }
}
