using Folha.Domain.Interfaces.Repository;
using Folha.Domain.ViewModels.Entidades;
using System.Collections.Generic;

namespace Folha.Domain.Interfaces.Repository.Entidades
{
    public interface IComissoesRepository : IRepositoryBase<ComissoesViewModel>
    {
        bool VerificarSeExisteEntidadeNaComissao(int entidadeId, int documentoId);
        List<ComissaoViewModel> CarregaComissoes(int documentoId);
    }
}
