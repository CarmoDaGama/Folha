using Folha.Domain.ViewModels.Frame.Documentos;
using Folha.Domain.ViewModels.Financeiro;
using System;
using System.Collections.Generic;

namespace Folha.Domain.Interfaces.Application.Documentos
{
    using Folha.Domain.Models.Documentos;
    using Folha.Domain.ViewModels.Documentos;
    using Folha.Domain.ViewModels.Report;
    using Folha.Domain.ViewModels.Sistema;

    public interface IDocumentosApp
    {
        DocumentosViewModel SetHashDocumento(DocumentosViewModel documento);
        int GetNovoNumeroDocumento(string App);
        DocumentosViewModel CriarNovoDocumento(string App, decimal total, int codCliente);
        DocumentosViewModel GetUltimoDocumento(string app, string estadoDocumento);
        int GetCodDocumentoLastPorCodOperacao(int operacaoId);
        AnuladosViewModel GetAnuladosPor(int documentoId);
        bool LerDocumento(int CodOperacao, int CodArea, int CodMesa);
        List<PendenteViewModel> CarregarDocumentosPendentes();
        void DeixarPendenteDocumento(int documentoID, string cliente);
        DocumentosViewModel GetUltimoDocumentoAberto(int operacaoId);
        void AnularDocumento(int documentoID, int usuarioId, string Motivo);
        bool ContemDucumentosAberto(int turnoId);
        DocumentosViewModel GetUltimoDocumentoAberto();
        List<DocumentoViewModel> Listar(string criterios);
        IEnumerable<MinhasContasBancariasViewModel> ListarMinhasContasBancarias();
        IEnumerable<Mostrar> MostrarFPagamento();
        IEnumerable<DocumentoViewModel> ListarDocumentos(string CodTurno, string comissionarioID);
        object ListarPorCriterio(string docNome, int v);
        int GetCodLast();
        void Delete(DocumentosViewModel documento);
        void Update(DocumentosViewModel documento);
        void Insert(DocumentosViewModel documento);
        DocumentosViewModel GetById(int id);
        List<DocumentosViewModel> GetAll();
        //void EfectuarPagamentosCx(DadosPagamentoViewModel transfDadosPagamentoViewModel);
        //void EfectuarPagamentosBn(DadosPagamentoViewModel Dados);
        void EfectuarTransferenciaCx(DadosPagamentoViewModel Dados);

        void ReceberPagamentos(DadosPagamentoViewModel transfDadosPagamentoViewModel);
        void ReceberTroco(DadosPagamentoViewModel transfDadosPagamentoViewModel);
        int LerNumeroDocumentoAberto(int OperacaoID, int AreaID, int mesaID, int usuarioID);
        void FecharDocumento(int documentoID, int entidadeID, double Total, string Descritivo);
        int CriarDocumento(Documentos documento);
        DocumentosViewModel GetUltimoDocumento(int operacaoId, string estadoDocumento);
        void EfectuarTransferenciaBn(DadosPagamentoViewModel Dados);
        IEnumerable<MostraDocumentoViewModel> MostraDocumentos(string criterios);
        IEnumerable<RelOpercoesViewModel> LerOperacoes(string dataInicio, string dataFim, object[] CodOperacoes);
        IEnumerable<OpAcessoViewModel> Meus_Documentos(string _TiposDocumentos);
        int GetDocumentoLastPorCodOperacao(int operacaoId);
    }
}
