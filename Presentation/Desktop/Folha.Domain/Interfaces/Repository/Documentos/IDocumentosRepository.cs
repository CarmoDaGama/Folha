using Folha.Domain.Models.Documentos;
using Folha.Domain.Models.Financeiro;
using Folha.Domain.Models.Inventario;
using Folha.Domain.ViewModels.Frame.Documentos;
using Folha.Domain.ViewModels.Financeiro;
using System;
using System.Collections.Generic;

namespace Folha.Domain.Interfaces.Repository.Documentos
{
    using Folha.Domain.Models.Documentos;
    using Folha.Domain.Models.Sistema;
    using Folha.Domain.ViewModels.Documentos;
    using Folha.Domain.ViewModels.Report;
    using Folha.Domain.ViewModels.Sistema;

    public interface IDocumentosRepository : IRepositoryBase<DocumentosViewModel>
    {
        DocumentosViewModel GetUltimoDocumentoPor(string app, string estadoDocumento);
        int GetCodDocumentoLastPorCodOperacao(int operacaoId);
        decimal GetTotalMovFinDeDocumentosRecibo(DateTime dataInicio, DateTime datafim, string movFin);
        List<DocumentosViewModel> GetMovFinDeDocumentosRecibo(DateTime dataInicio, DateTime datafim);
        decimal GetTotalMovFinDeDocumentosConferencias(DateTime dataInicio, DateTime datafim, string movFin);
        decimal GetTotalMovFinDeDocumentosVenda(DateTime dataInicio, DateTime datafim, string movFin);
        List<DocumentosViewModel> GetMovFinDeDocumentosVenda(DateTime dataInicio, DateTime datafim);
        List<DocumentosViewModel> GetMovFinDeDocumentosMovimento(DateTime dataInicio, DateTime datafim);
        List<DocumentosViewModel> GetMovFinDeDocumentosConferencias(DateTime dataInicio, DateTime datafim);
        List<DocumentosViewModel> GetMovFinDeDocumentos(DateTime dataInicio, DateTime datafim, string movFin);
        decimal GetTotalMovFinDeDocumentos(DateTime dataInicio, DateTime datafim, string movFin);
        int GetNumeroDeDocumentosFacturadoOuAnulado(DateTime dataInicio, DateTime datafim);
        List<DocumentosViewModel> GetDocumentosPor(DateTime dataInicio, DateTime datafim);
        DocumentosViewModel GetUltimoDocumentoPor(int operacaoId, string estadoDocumento);
        DocumentosViewModel GetDocumentoLastPorCodOperacao(int operacaoId);
        AnuladosViewModel GetAnuladosPor(int documentoId);
        bool LerDocumento(int CodOperacao, int CodArea, int CodMesa);
        List<PendenteViewModel> CarregarDocumentosPendentes();
        bool ContemDucumentosAberto(int turnoId);
        IEnumerable<Documentos> DocumentosPorUsuarios(string _TiposDocumentos, int usuarioID, bool admin);
        int CriaDocumento(Documentos documento);
        void ActualizaTotalDocumento(Guid documentoID, Guid entidadeID, double Total);
        void FecharDocumento(int documentoID, int entidadeID, double Total, string Descritivo);
        IEnumerable<Documentos> BuscarDocumentosPorEntidade(string crit);
        void AnularDocumento(int documentoID, int usuarioId, string Motivo);
        void DeixarPendenteDocumento(int documentoID, string clienteID);
        int BuscarUltimoDocumento(int OperacaoID, int UsuarioID);
        Guid BuscarUltimoDocumentoAberto(Guid usuarioID, Guid operacaoID);
        int LerNumeroDocumentoAberto(int operacaoID, int areaID, int mesaID, int usuarioID);
        //int LerNumeroDocumentoAbertos(int CodOperacao, int CodArea, int CodMesa);
        void InserirTecnico(Guid documentoID, Guid tecnicoID);
        void InserirMotorista(Guid documentoID, Guid motoristaID);
        void LancarArtigoDocumento(Guid documentoID, MovArtigo artigo);
        void ActualizarLinhaDocumento(Guid documentoID, MovArtigo artigo);
        List<Folha.Domain.Models.Documentos.Documentos> ListarDocumentosPendentes();
        void EliminarVendaPendente(Guid documentoID);
        void ReceberPagamentos(DadosPagamentoViewModel Dados);
        void ReceberTroco(DadosPagamentoViewModel Dados);
        List<DocumentoViewModel> Listar(string criterios);

        IEnumerable<MinhasContasBancariasViewModel> ListarMinhasContasBancarias();
        IEnumerable<Mostrar> ListarFPagamentos();

        //void EfectuarPagamentosBn(DadosPagamentoViewModel Dados);

        //void EfectuarPagamentosCx(DadosPagamentoViewModel Dados);
        double buscarSaldoCaixa(int CodCaixa);
        object GetCodLast();

        void EfectuarTransferenciaCx(DadosPagamentoViewModel Dados);
        void EfectuarTransferenciaBn(DadosPagamentoViewModel Dados);
        IEnumerable<MostraDocumentoViewModel> MostraDocumentos(string criterios);
        IEnumerable<RelOpercoesViewModel> LerOperacoes(string dataInicio, string dataFim, object[] CodOperacoes);
        IEnumerable<OpAcessoViewModel> Meus_Documentos(string _TiposDocumentos);
    }
}

