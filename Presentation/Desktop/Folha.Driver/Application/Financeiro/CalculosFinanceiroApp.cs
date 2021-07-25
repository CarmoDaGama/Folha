using Folha.Domain.Interfaces.Application.Financeiro;
using Folha.Domain.Interfaces.Repository.Financeiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Folha.Domain.ViewModels.Financeiro;
using Folha.Domain.ViewModels.Report;
using Folha.Domain.Models.Financeiro;

namespace Folha.Driver.Application.Financeiro
{
    public class CalculosFinanceiroApp : ICalculosFinanceiroApp
    {
        private readonly ICalculosRepository _CalculosRepository;

        public CalculosFinanceiroApp(ICalculosRepository CalculosRepository)
        {
            _CalculosRepository = CalculosRepository;
        }

        public IEnumerable<FluxoCaixaViewModel> buscarContaCorrente(string dataInicio, string dataFim, int codEntidade)
        {
            return _CalculosRepository.buscarContaCorrente(dataInicio, dataFim, codEntidade);
        }

        public IEnumerable<SaldoClienteViewModel> BuscarDividasClientes(string dataInicio, string dataFim)
        {
            return _CalculosRepository.BuscarDividasClientes(dataInicio,dataFim);
        }

        public IEnumerable<RelNotasPagamentosViewModel> BuscarNotasPagamentos(string dataInicio, string dataFim)
        {
            return _CalculosRepository.BuscarNotasPagamentos(dataInicio, dataFim);
        }

        public IEnumerable<SaldoClienteViewModel> BuscarSaldoClientes(string dataInicio, string dataFim)
        {
            return _CalculosRepository.BuscarSaldoClientes(dataInicio, dataFim);
        }

        public IEnumerable<FluxoCaixaViewModel> ListarFluxo(string dtInicio, string dtFim, string CodCaixa, string CodConta, string Tipo)
        {
            return _CalculosRepository.ListarFluxo(dtInicio, dtFim, CodCaixa,CodConta,Tipo);
        }

        public Saldos MostraSaldo(string data)
        {
            return _CalculosRepository.MostraSaldo(data);
        }

        public string MostraTotal(string dataInicio, string dataFim, int CodTipoSaida)
        {
            return _CalculosRepository.MostraTotal(dataInicio, dataFim, CodTipoSaida);
        }

        public DataViewModel RetornaDataDocumento()
        {
            return _CalculosRepository.RetornaDataDocumento();
        }

        public DataViewModel RetortaDataNotasPagamentos()
        {
            return _CalculosRepository.RetortaDataNotasPagamentos();
        }

        public DataViewModel RetortaDataSaldoCaixaConta()
        {
            return _CalculosRepository.RetortaDataSaldoCaixaConta();
        }

        public double TaxadeCambio(int CodCambio)
        {
            return _CalculosRepository.TaxadeCambio(CodCambio);
        }
    }
}
