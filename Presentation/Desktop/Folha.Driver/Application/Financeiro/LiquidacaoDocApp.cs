using Folha.Domain.Interfaces.Application.Financeiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Folha.Domain.ViewModels.Frame.Financeiro;
using Folha.Domain.Interfaces.Repository.Financeiro;

namespace Folha.Driver.Application.Financeiro
{
    public class LiquidacaoDocApp : ILiquidacaoDocApp
    {
        private readonly ILiquidacaoDocRepository _LiquidacaoDocRepository;
        public LiquidacaoDocApp(ILiquidacaoDocRepository LiquidacaoDocRepository)
        {
            _LiquidacaoDocRepository = LiquidacaoDocRepository;
        }

        public void Delete(LiquidacaoDocViewModel delete)
        {
            _LiquidacaoDocRepository.Delete(delete);
        }

        public IEnumerable<LiquidacaoDocViewModel> Listar(string CodEntidade)
        {
           return _LiquidacaoDocRepository.Listar(CodEntidade);
        }

        public IEnumerable<LiquidacaoDocViewModel> ListarContaPagar()
        {
            return _LiquidacaoDocRepository.ListarContaPagar();
        }

        public IEnumerable<LiquidacaoDocViewModel> ListarContasReceber(string CodEntidade)
        {
            return _LiquidacaoDocRepository.ListarContasReceber(CodEntidade);
        }
    }
}
