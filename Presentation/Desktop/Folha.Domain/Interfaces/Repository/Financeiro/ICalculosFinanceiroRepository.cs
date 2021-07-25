using Folha.Domain.Models.Financeiro;
using Folha.Domain.ViewModels.Financeiro;
using Folha.Domain.ViewModels.Report;
using System;
using System.Collections.Generic;

namespace Folha.Domain.Interfaces.Repository.Financeiro
{
    public  interface ICalculosRepository
    {
        //Saldos SaldosDocumentos(DateTime dataInicial, DateTime dataFinal);
        //Double SaldoCaixa(Guid caixaID);
        //bool PodeCreditar(Guid CodCliente, double Valor);
        //Double SaldoContaBancarica(Guid contaBancariaID);
        //double LimiteDebitoCliente(Guid CodCliente);
       // double Saldo_Conta(Guid CodCliente, bool usuarioSistema);
        double TaxadeCambio(int CodCambio);
        IEnumerable<SaldoClienteViewModel> BuscarSaldoClientes(string dataInicio, string dataFim);
        IEnumerable<FluxoCaixaViewModel> ListarFluxo(string dtInicio, string dtFim, string CodCaixa, string CodConta, string Tipo);
        IEnumerable<FluxoCaixaViewModel> buscarContaCorrente(string dataInicio, string dataFim, int codEntidade);
        IEnumerable<SaldoClienteViewModel> BuscarDividasClientes(string dataInicio, string dataFim);
        IEnumerable<RelNotasPagamentosViewModel> BuscarNotasPagamentos(string dataInicio, string dataFim);
        DataViewModel RetortaDataSaldoCaixaConta();
        string MostraTotal(string dataInicio, string dataFim, int CodTipoSaida);
        DataViewModel RetornaDataDocumento();
        DataViewModel RetortaDataNotasPagamentos();
        Saldos MostraSaldo(string data);
    }
}
