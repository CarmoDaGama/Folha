using Folha.Domain.Models.Financeiro;
using Folha.Domain.ViewModels.Financeiro;
using Folha.Domain.ViewModels.Frame.Financeiro;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Interfaces.Repository.Financeiro
{
   public interface INotasPagamentosRepository : IRepositoryBase<NotaPagamento>
    {
        //IEnumerable<NotaPagamento> ListarNotasPagamentos(string Criterio);
        List<NotaPagamentoViewModel> ListarNotasPagamentos(int codDocumento);
        List<NotaPagamento> BuscarTabela_com_Criterio(string criterios);       
        List<BuscaDocNotaPagamentoViewModel> BuscarDocumento(string Criterio);
    }

    
}
