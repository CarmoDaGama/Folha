using Folha.Domain.Models.Financeiro;
using Folha.Domain.ViewModels.Financeiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Interfaces.Repository.Financeiro
{
    public interface ITipoSaidaRepository : IRepositoryBase<TipoSaida>
    {
        IEnumerable<TipoSaidaViewModel> Listar(string criterios);
        IEnumerable<TipoSaida> BuscarPorCod(string Codigo);
    }
}
