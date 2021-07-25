using Folha.Domain.Models.UtilitariosConfiguracoes;
using Folha.Domain.ViewModels.UtilitariosConfiguracoes;
using System.Collections.Generic;

namespace Folha.Domain.Interfaces.Application.UtilitariosConfiguracoes
{
    public interface IPerfilNovoApp
    {
        Perfil GetById(int codigo);
        IEnumerable<Perfil> Listar(string criterios, bool Pesquisa);
        void Insert(Perfil entity);
        void Update(Perfil entity);
        void Delete(Perfil perfil);
        List<PerfilViewModel> GetAll();
        List<string> CarregarAcessos(string login, string senha);

    }
}
