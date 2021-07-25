using Folha.Domain.ViewModels.Frame.Financeiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Interfaces.Repository.Financeiro
{
   public interface ILiquidacaoDocRepository 
    {
        IEnumerable<LiquidacaoDocViewModel> Listar(string CodEntidade);
        IEnumerable<LiquidacaoDocViewModel> ListarContasReceber(string CodEntidade);
        void Delete(LiquidacaoDocViewModel delete);
        IEnumerable<LiquidacaoDocViewModel> ListarContaPagar();

    }
}
