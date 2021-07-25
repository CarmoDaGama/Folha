using Folha.Domain.Interfaces.Application.Documentos;
using System;
using System.Collections.Generic;
using Folha.Domain.ViewModels.Frame.Documentos;
using Folha.Domain.Interfaces.Repository.Documentos;
using Folha.Domain.ViewModels.Financeiro;


namespace Folha.Driver.Application.Documentos
{
  
    using Folha.Domain.Models.Documentos;
    using Folha.Domain.ViewModels.Documentos;
    using Folha.Domain.Helpers;
    using System.IO;
    using System.Windows.Forms;
    using Folha.Domain.ViewModels.Report;
    using Folha.Domain.ViewModels.Sistema;
    using Folha.Domain.Interfaces.Application.Sistema;
    using Folha.Domain.Interfaces.Application.Entidades;
    using System.Linq;

    public class DocumentosApp : IDocumentosApp
    {
        private readonly IDocumentosRepository _documentosRepository;
        private readonly IOperacoesApp _operacoesApp;
        private readonly IEntidadesApp _entidadesApp;
        public DocumentosApp(IDocumentosRepository documentosRepository,
            IOperacoesApp operacoesApp, IEntidadesApp entidadesApp)
        {
            _documentosRepository = documentosRepository;
            _operacoesApp = operacoesApp;
            _entidadesApp = entidadesApp;
        }
        public DocumentosViewModel SetHashDocumento(DocumentosViewModel documento)
        {
            if (documento.Operacao.APP != "PP" && documento.Operacao.APP != "ADM")
            {
                var codAGT = documento.Operacao.APP + " " + DateTime.Now.Year + "/" + documento.NumeroOrdem;
                documento.Hash = UtilidadesGenericas.GerarHash(
                    UtilidadesGenericas.GetDadosHash(documento.Data, documento.Hora, codAGT, documento.Total));
                var lengthHash = documento.Hash.Length;
            }
            Update(documento);
            return documento;
        }
        public List<DocumentoViewModel> Listar(string criterios)
        {
            return _documentosRepository.Listar(criterios);
        }
        public DocumentosViewModel GetUltimoDocumentoAberto()
        {
            //return GetAll().Where(d => d.Estado.Equals("ABERTO") && d.CodUsuario == UtilidadesGenericas.UsuarioCodigo).LastOrDefault();
            return _documentosRepository.GetUltimoDocumentoPor(1, "ABERTO");
        }
        public DocumentosViewModel GetUltimoDocumentoAberto(int operacaoId)
        {
            return GetAll().Where(
                d => d.Estado.Equals("ABERTO") &&
                d.CodUsuario == UtilidadesGenericas.UsuarioCodigo &&
                d.CodOperacao == operacaoId).LastOrDefault();
        }
        public DocumentosViewModel GetUltimoDocumento(int operacaoId, string estadoDocumento)
        {
            return GetAll().Where(
                d => d.Estado.Equals(estadoDocumento) &&
                d.CodUsuario == UtilidadesGenericas.UsuarioCodigo &&
                d.CodOperacao == operacaoId).LastOrDefault();
        }
        public DocumentosViewModel GetUltimoDocumento(string app, string estadoDocumento)
        {
            return GetAll().Where(
                d => Equals(d.Estado, estadoDocumento) &&
                d.Operacao.APP == app &&
                d.CodUsuario == UtilidadesGenericas.UsuarioCodigo).LastOrDefault();
        }
        public IEnumerable<MinhasContasBancariasViewModel> ListarMinhasContasBancarias()
        {
            return _documentosRepository.ListarMinhasContasBancarias();
        }

        public IEnumerable<Mostrar> MostrarFPagamento()
        {
            return _documentosRepository.ListarFPagamentos();
        }
        public IEnumerable<DocumentoViewModel> ListarDocumentos(string CodTurno, string comissionarioID)
        {
            string criterios = criterios = "Documentos.CodTurno='" + CodTurno + "' AND Operacoes.MovFin like 'CREDITO' and Documentos.Estado='FECHADO' OR Documentos.CodTurno='" + CodTurno + "' AND Operacoes.MovFin like 'DEBITO' and Documentos.Estado='FECHADO'";

            if (!string.IsNullOrEmpty(comissionarioID))
                criterios = "Documentos.CodTurno='" + CodTurno + "' And Comissoes.CodEntidade='" + comissionarioID + "' AND Operacoes.MovFin like 'CREDITO' and Documentos.Estado='FECHADO' OR Documentos.CodTurno='" + CodTurno + "' AND Operacoes.MovFin like 'DEBITO' and Documentos.Estado='FECHADO'";

            return Listar(criterios);
        }

        public object ListarPorCriterio(string docNome, int v)
        {
            throw new NotImplementedException();
        }
        private string criarCaminho(string nameFile, int usuarioID)
        {
            var path = string.Format(Application.StartupPath + @"\{0}\", usuarioID);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            path += nameFile;
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            return path;
        }
        public int GetCodLast()
        {
            return (int)_documentosRepository.GetCodLast();
        }

        public void Delete(DocumentosViewModel documento)
        {
            _documentosRepository.Delete(documento);
        }

        public void Update(DocumentosViewModel documento)
        {
            _documentosRepository.Update(documento);
        }

        public void Insert(DocumentosViewModel documento)
        {
            _documentosRepository.Insert(documento);
        }

        public DocumentosViewModel GetById(int id)
        {
            return ActualizarDadosClienteNoDoc((DocumentosViewModel)_documentosRepository.Get(new DocumentosViewModel() { codigo = id }));
        }

        public List<DocumentosViewModel> GetAll()
        {
            return (List<DocumentosViewModel>)_documentosRepository.GetAll(new DocumentosViewModel());
        }
        public string getReport(int codDocumento)
        {


            return "";
        }


        //public double buscarSaldoCaixa(int codCaixa)
        //{
        //   return _documentosRepository.buscarSaldoCaixa(codCaixa);
        //}

        public void ReceberPagamentos(DadosPagamentoViewModel transfDadosPagamentoViewModel)
        {
            _documentosRepository.ReceberPagamentos(transfDadosPagamentoViewModel);
        }

        public void ReceberTroco(DadosPagamentoViewModel transfDadosPagamentoViewModel)
        {
            _documentosRepository.ReceberTroco(transfDadosPagamentoViewModel);
        }

        public int LerNumeroDocumentoAberto(int OperacaoID, int AreaID, int mesaID, int usuarioID)
        {
            return _documentosRepository.LerNumeroDocumentoAberto(OperacaoID, AreaID, mesaID, usuarioID);
        }

        public void FecharDocumento(int documentoID, int entidadeID, double Total, string Descritivo)
        {
            _documentosRepository.FecharDocumento(documentoID, entidadeID, Total, Descritivo);
        }

        public int CriarDocumento(Documentos documento)
        {
            return _documentosRepository.CriaDocumento(documento);
        }


        public void EfectuarTransferenciaCx(DadosPagamentoViewModel Dados)
        {
            _documentosRepository.EfectuarTransferenciaCx(Dados);
        }

        public bool ContemDucumentosAberto(int turnoId)
        {
            return _documentosRepository.ContemDucumentosAberto(turnoId);
        }

        public void AnularDocumento(int documentoID, int usuarioId, string Motivo)
        {
            _documentosRepository.AnularDocumento(documentoID, usuarioId, Motivo);
        }

        public void DeixarPendenteDocumento(int documentoID, string cliente)
        {
            _documentosRepository.DeixarPendenteDocumento(documentoID, cliente);
        }

        public List<PendenteViewModel> CarregarDocumentosPendentes()
        {
            return _documentosRepository.CarregarDocumentosPendentes();
        }

        public bool LerDocumento(int CodOperacao, int CodArea, int CodMesa)
        {
            return _documentosRepository.LerDocumento(CodOperacao, CodArea, CodMesa);
        }

        public AnuladosViewModel GetAnuladosPor(int documentoId)
        {
            return _documentosRepository.GetAnuladosPor(documentoId);
        }

        public DocumentosViewModel GetCodLastPorCodOperacao(int operacaoId)
        {
            return _documentosRepository.GetDocumentoLastPorCodOperacao(operacaoId);
        }

        public void EfectuarTransferenciaBn(DadosPagamentoViewModel Dados)
        {
            _documentosRepository.EfectuarTransferenciaBn(Dados);
        }

        public IEnumerable<MostraDocumentoViewModel> MostraDocumentos(string criterios)
        {
            return _documentosRepository.MostraDocumentos(criterios);
        }

        public IEnumerable<RelOpercoesViewModel> LerOperacoes(string dataInicio, string dataFim, object[] CodOperacoes)
        {
            return _documentosRepository.LerOperacoes(dataInicio, dataFim, CodOperacoes);
        }

        public IEnumerable<OpAcessoViewModel> Meus_Documentos(string TiposDocumentos)
        {
            return _documentosRepository.Meus_Documentos(TiposDocumentos);
        }

        public int GetCodDocumentoLastPorCodOperacao(int operacaoId)
        {
            return _documentosRepository.GetCodDocumentoLastPorCodOperacao(operacaoId);
        }

        public int GetDocumentoLastPorCodOperacao(int operacaoId)
        {
            return _documentosRepository.GetCodDocumentoLastPorCodOperacao(operacaoId);
        }
        public int GetNovoNumeroDocumento(string App)
        {
            var Operacao = _operacoesApp.GetByApp(App);
            var documentLast = GetById(GetCodDocumentoLastPorCodOperacao(Operacao.codigo));
            var novoNumeroOrdem = Equals(documentLast, null) ? 1 : documentLast.NumeroOrdem + 1;
            return novoNumeroOrdem;
        }
        public DocumentosViewModel CriarNovoDocumento(string App, decimal total, int codCliente)
        {
            var Operacao = _operacoesApp.GetByApp(App);
            var novoNumeroOrdem = GetNovoNumeroDocumento(App);
            var consumidorId = codCliente > 0 ? codCliente : 2;
            var Consumidor = _entidadesApp.GetById(consumidorId);
            var tel = _entidadesApp.GetTelefoneByEntidade(codCliente.ToString());
            var morada = _entidadesApp.GetMoradaByEntidade(codCliente.ToString());
            var entidadeId = 2;
            var nomeCliente = "CLIENTE INDIFERENCIADO";
            if (!Equals(Consumidor, null))
            {
                entidadeId = Consumidor.Codigo;
                nomeCliente = Consumidor.Nome;
            }
            //var totalDias = 30;
            //if (!Equals(Consumidor.Codicao, null))
            //{
            //    totalDias = Consumidor.Codicao.Dias;
            //}

            Insert(new DocumentosViewModel()
            {
                CodOperacao = Operacao.codigo,
                Mascara = Operacao.APP + "/" + novoNumeroOrdem,
                Estado = "ABERTO",
                CodEntidade = consumidorId,
                CodUsuario = UtilidadesGenericas.UsuarioCodigo,
                Total = total,
                Descritivo = "Edição do documento " + Operacao.Nome,
                NomeCliente = nomeCliente,
                NumeroOrdem = novoNumeroOrdem,
                Data = DateTime.Now,
                Hora = DateTime.Now.ToShortTimeString(),
                CodArea = 2,
                CodMesa = 0,
                CodTurno = UtilidadesGenericas.CodigoTurno,
                Emitido = "Não Imprimido",
                DataVencimento = UtilidadesGenericas.GetDataVencimento(30),
                NifCliente = Consumidor.Nif,
                MoredaCliente = Equals(morada, null)? string.Empty : morada.DescricaoMorada,
                TelCliente = Equals(tel, null)? string.Empty : tel.descricao

            });

            return GetById(GetCodLast());
        }
        private DocumentosViewModel ActualizarDadosClienteNoDoc(DocumentosViewModel Documento)
        {
            if (Equals(Documento, null) || Documento.codigo <= 0 || Documento.CodOperacao <= 0)
            {
                return null;
            }
            var telCliente = _entidadesApp.GetTelefoneByEntidade(Documento.Entidade.Codigo.ToString());
            var moradaCliente = _entidadesApp.GetMoradaByEntidade(Documento.Entidade.Codigo.ToString());
            if (string.IsNullOrEmpty(Documento.NifCliente) || Documento.NifCliente == "999999999")
            {
                Documento.NifCliente = Documento.Entidade.Nif;
            }
            if (!Equals(telCliente, null) && !string.IsNullOrEmpty(Documento.TelCliente))
            {
                Documento.TelCliente = telCliente.descricao;
            }
            if (!Equals(moradaCliente, null) && !string.IsNullOrEmpty(Documento.MoredaCliente))
            {
                Documento.MoredaCliente = moradaCliente.DescricaoMorada;
            }
            _documentosRepository.Update(Documento);
            return Documento;
        }
    }
}
