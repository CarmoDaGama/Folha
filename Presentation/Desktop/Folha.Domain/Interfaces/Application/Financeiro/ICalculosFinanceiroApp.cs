using Folha.Domain.Models.Financeiro;
using Folha.Domain.ViewModels.Financeiro;
using Folha.Domain.ViewModels.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Interfaces.Application.Financeiro
{
    public interface ICalculosFinanceiroApp
    {
        IEnumerable<FluxoCaixaViewModel> ListarFluxo(string dtInicio, string dtFim, string CodCaixa, string CodConta, string Tipo);
        double TaxadeCambio(int CodCambio);
        IEnumerable<FluxoCaixaViewModel> buscarContaCorrente(string dataInicio, string dataFim, int codEntidade);
        IEnumerable<SaldoClienteViewModel> BuscarSaldoClientes(string dataInicio, string dataFim);
        IEnumerable<SaldoClienteViewModel> BuscarDividasClientes(string dataInicio, string dataFim);
        IEnumerable<RelNotasPagamentosViewModel> BuscarNotasPagamentos(string dataInicio, string dataFim);
        string MostraTotal(string dataInicio, string dataFim, int CodTipoSaida);
        DataViewModel RetortaDataSaldoCaixaConta();
        DataViewModel RetornaDataDocumento(); 
        DataViewModel RetortaDataNotasPagamentos();
        Saldos MostraSaldo(string data);
    }
}
