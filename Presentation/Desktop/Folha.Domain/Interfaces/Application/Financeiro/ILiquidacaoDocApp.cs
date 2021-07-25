using Folha.Domain.ViewModels.Frame.Financeiro;
using System.Collections.Generic;

namespace Folha.Domain.Interfaces.Application.Financeiro
{
    public interface ILiquidacaoDocApp
    {
        IEnumerable<LiquidacaoDocViewModel> Listar(string CodEntidade);
        IEnumerable<LiquidacaoDocViewModel> ListarContasReceber(string CodEntidade);
        void Delete(LiquidacaoDocViewModel delete);
        IEnumerable<LiquidacaoDocViewModel> ListarContaPagar();
    }
}
