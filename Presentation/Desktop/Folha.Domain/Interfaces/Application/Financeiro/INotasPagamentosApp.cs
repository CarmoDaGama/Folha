using Folha.Domain.Models.Financeiro;
using Folha.Domain.ViewModels.Financeiro;
using Folha.Domain.ViewModels.Frame.Financeiro;
using System.Collections.Generic;

namespace Folha.Domain.Interfaces.Application.Financeiro
{
    public interface INotasPagamentosApp
    {
        NotaPagamentoViewModel GetNotaPagamento(int cod);
        List<NotaPagamento> Listar(string criterios);
        List<NotaPagamentoViewModel> ListarNotasPagamentos(int codDocumento);
        List<NotaPagamento> BuscarTabela_com_Criterio(string criterios);        
        void addNotaPagamento(NotaPagamento NotaPagamento);
        List<BuscaDocNotaPagamentoViewModel> BuscaDocumento(string criterios);
    }
}
