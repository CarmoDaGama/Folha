using Folha.Domain.Interfaces.Repository;
using Folha.Domain.Models.UtilitariosConfiguracoes;
using Folha.Domain.ViewModels.UtilitariosConfiguracoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Interfaces.Repository.UtilitariosConfiguracoes
{
   public interface IPerfilNovoRepository : IRepositoryBase<PerfilViewModel>
    {
        IEnumerable<Perfil> Listar(string criterios);
        void Insert(Perfil entity);
        void Update(Perfil perfil);
        void Delete(Perfil perfil);
        List<string> CarregarAcessos(string login, string senha);
    }
}
