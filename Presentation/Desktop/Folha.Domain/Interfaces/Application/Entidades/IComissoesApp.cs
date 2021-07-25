using Folha.Domain.ViewModels.Entidades;
using System.Collections.Generic;

namespace Folha.Domain.Interfaces.Application.Entidades
{
    public interface IComissoesApp
    {
        void Insert(ComissoesViewModel comissao);
        void Delete(ComissoesViewModel comissao);
        bool VerificarSeExisteEntidadeNaComissao(int entidadeId, int documentoId);
        List<ComissaoViewModel> CarregaComissoes(int documentoId);
    }
}
