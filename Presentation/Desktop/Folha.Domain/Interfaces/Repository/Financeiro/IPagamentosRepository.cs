using Folha.Domain.Models.Financeiro;
using Folha.Domain.ViewModels.Frame.Financeiro;
using System;
using System.Collections.Generic;
using Folha.Domain.ViewModels.Frame;
using Folha.Domain.ViewModels.Frame.Documentos;

namespace Folha.Domain.Interfaces.Repository.Financeiro
{
    public  interface IPagamentosRepository : IRepositoryBase<Folha.Domain.ViewModels.Financeiro.PagamentosViewModel>
    {
        List<Folha.Domain.ViewModels.Financeiro.PagamentosViewModel> GetAllByDoc(int codDocumento, string movFin);
        int GetUltimoNumeroPagamentoNotaCredito();
        List<Folha.Domain.ViewModels.Financeiro.PagamentosViewModel> GetAllCreditosAbertos(int CodCliente);
        int GetUltimoNumeroPagamentoRecibo();
        List<Folha.Domain.ViewModels.Financeiro.PagamentosViewModel> GetAllPorIdDocumento(int codDocumento);
        List<Folha.Domain.ViewModels.Financeiro.PagamentosViewModel> GetMovFinDeDocumentosRecibo(DateTime dataInicio, DateTime datafim);
        decimal GetTotalMovFinDeDocumentosRecibo(DateTime dataInicio, DateTime datafim, string movFin);
        Folha.Domain.ViewModels.Financeiro.PagamentosViewModel GetPorIdDocumento(int codDocumento);
        object GetCodLast();
        double buscarSaldoBanco(Guid bancoID);
        double Saldo_Conta(Guid ClienteID, bool admin);
        IEnumerable<Pagamentos> BuscarPagamentosEntidade(string crit);
        IEnumerable<Pagamentos> MostraPagamentosCx(string criterios);
        IEnumerable<Pagamentos> MostraPagamentosBn(string criterios);
        void EfectuarPagamentosCx(DadosPagamentoViewModel dados);
        void EfectuarPagamentosBn(DadosPagamentoViewModel dados);
        string ReceberPagamentos(Pagamentos pagamento, bool forma, int Turno_Sistema_Numero);
        string ReceberContaCorrente(Pagamentos pagamento, bool forma, int Turno_Sistema_Numer);
        string ReceberTroco(Pagamentos pagamento, int Turno_Sistema_Numero);
        IEnumerable<ListarMovBancariosViewModel> ListarMovBancarios(string criterios);

        IEnumerable<MovimentosCaixaViewModel> ListarMovCaixa(string criterios);
        IEnumerable<Caixas> Meus_Caixas();
        List<PagamentosViewModel> ListarPagamentos(string critarios);

        IEnumerable<PagamentosViewModel> CarregarPagamentos(string crit);
        List<Folha.Domain.ViewModels.Financeiro.PagamentosViewModel> GetAllCriditoByDoc(int codigo);
    }
}
