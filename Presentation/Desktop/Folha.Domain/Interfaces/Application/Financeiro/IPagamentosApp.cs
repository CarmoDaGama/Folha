using Folha.Domain.Models.Financeiro;
using Folha.Domain.ViewModels.Frame;
using Folha.Domain.ViewModels.Frame.Documentos;
using Folha.Domain.ViewModels.Frame.Financeiro;
using System.Collections.Generic;

namespace Folha.Domain.Interfaces.Application.Financeiro
{
    public interface IPagamentosApp
    {
        List<Folha.Domain.ViewModels.Financeiro.PagamentosViewModel> GetAllByDoc(int codDocumento, string movFin);
        int GetUltimoNumeroPagamentoNotaCredito();
        List<Folha.Domain.ViewModels.Financeiro.PagamentosViewModel> GetAllCreditosAbertos(int CodCliente);
        void CriarCreditoSemDividas(Folha.Domain.ViewModels.Financeiro.PagamentosViewModel pagamento);
        List<Folha.Domain.ViewModels.Financeiro.PagamentosViewModel> GetAllCriditoByDoc(int codigo);
        int GetUltimoNumeroPagamentoRecibo();
        IEnumerable<Pagamentos> MostraPagamentosCx(string criterios);
        int GetCodLast();
        IEnumerable<ListarMovBancariosViewModel> ListarMovBancarios(string criterios);
        IEnumerable<MovimentosCaixaViewModel> ListarMovCaixa(string criterios);
        IEnumerable<Caixas> Meus_Caixas();
        List<PagamentosViewModel> ListarPagamentos(string CodTurno, string ComissionarioID);
        List<PagamentosViewModel> ListarPagamentos(string CodTurno, string ComissionarioID, int codDocumento);
        void Insert(Folha.Domain.ViewModels.Financeiro.PagamentosViewModel pagamento);
        void Update(Folha.Domain.ViewModels.Financeiro.PagamentosViewModel pagamento);
        void Delete(Folha.Domain.ViewModels.Financeiro.PagamentosViewModel pagamento);
        Folha.Domain.ViewModels.Financeiro.PagamentosViewModel GetById(int id);
        List<Folha.Domain.ViewModels.Financeiro.PagamentosViewModel> GetAll();
        void EfectuarPagamentosCx(DadosPagamentoViewModel dados);
        void EfectuarPagamentosBn(DadosPagamentoViewModel dados);
        List<Folha.Domain.ViewModels.Financeiro.PagamentosViewModel> GetAllByDoc(int codigo);
    }
}
