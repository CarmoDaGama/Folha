using Folha.Domain.Interfaces.Application.Financeiro;
using System;
using System.Collections.Generic;
using Folha.Domain.Models.Financeiro;
using Folha.Domain.ViewModels.Frame.Financeiro;
using Folha.Domain.Interfaces.Repository.Financeiro;
using Folha.Domain.ViewModels.Frame;
using Folha.Domain.ViewModels.Frame.Documentos;
using Folha.Domain.Interfaces.Application.Inteligente;
using Folha.Domain.ViewModels.Financeiro;

namespace Folha.Driver.Application.Financeiro
{
    public class PagamentoApp : IPagamentosApp
    {
        private readonly IPagamentosRepository _PagamentosRepository;
        private readonly ILiquidacaoDocApp _LiquidaRepository;
        private readonly IPagamentosRepository _pagamentoRepository;
        private readonly IInteligenteApp _inteligenteApp;
        public PagamentoApp(
            IPagamentosRepository PagamentosRepository,
            ILiquidacaoDocApp liquidaRepository,
            IPagamentosRepository pagamentoRepository,
            IInteligenteApp inteligenteApp)
        {
            _PagamentosRepository = PagamentosRepository;
            _LiquidaRepository = liquidaRepository;
            _pagamentoRepository = pagamentoRepository;
            _inteligenteApp = inteligenteApp;
        }

        public IEnumerable<Pagamentos> MostraPagamentosCx(string criterios)
        {
            return _PagamentosRepository.MostraPagamentosCx(criterios);
        }

        public IEnumerable<Caixas> Meus_Caixas()
        {
            return _PagamentosRepository.Meus_Caixas();
        }

        public IEnumerable<MovimentosCaixaViewModel> ListarMovCaixa(string criterios)
        {
            return _PagamentosRepository.ListarMovCaixa(criterios);
        }

        public IEnumerable<ListarMovBancariosViewModel> ListarMovBancarios(string criterios)
        {
            return _PagamentosRepository.ListarMovBancarios(criterios);
        }

        public List<Folha.Domain.ViewModels.Frame.Financeiro.PagamentosViewModel> ListarPagamentos(string CodTurno, string ComissionarioID)
        {

            string criterios = "Pagamentos.CodTurno='" + CodTurno + "'";

            if (!string.IsNullOrEmpty(ComissionarioID)) criterios = "Pagamentos.CodTurno='" + CodTurno + "' And Comissoes.CodEntidade='" + ComissionarioID + "'";

            return _PagamentosRepository.ListarPagamentos(criterios);
        }

        public List<Folha.Domain.ViewModels.Frame.Financeiro.PagamentosViewModel> ListarPagamentos(string CodTurno, string ComissionarioID, int codDocumento)
        {

            string criterios = "Pagamentos.CodTurno='" + CodTurno + "'";

            if (!string.IsNullOrEmpty(ComissionarioID)) criterios = "Pagamentos.CodTurno='" + CodTurno + "' And Comissoes.CodEntidade='" + ComissionarioID + "'";

            if (codDocumento > 0) criterios += " And Pagamentos.CodDocumento='" + codDocumento + "'";

            return _PagamentosRepository.ListarPagamentos(criterios);
        }


        public int GetCodLast()
        {
            return (int)_PagamentosRepository.GetCodLast();
        }

        public void Insert(Folha.Domain.ViewModels.Financeiro.PagamentosViewModel pagamento)
        {
            _PagamentosRepository.Insert(pagamento);
        }
        public void CriarCreditoSemDividas(Folha.Domain.ViewModels.Financeiro.PagamentosViewModel pagamento)
        {
            Insert(pagamento);
            pagamento = null;
            pagamento = GetById(GetCodLast());
            var dividas = _LiquidaRepository.Listar(pagamento.Documento.CodEntidade.ToString());
            foreach (var item in dividas)
            {
                if (pagamento.Estado == "ABERTO" && pagamento.Valor >= Convert.ToDecimal(item.Total))
                {
                    _inteligenteApp.InsertDoc(new Folha.Domain.ViewModels.Documentos.DocumentoPagamentoViewModel()
                    {
                        DescricaoDocumento = "FT " + DateTime.Now.Year + "/" + pagamento.Documento.NumeroOrdem,
                        CodRecibo = pagamento.CodDocumento
                    });
                    Insert(new Folha.Domain.ViewModels.Financeiro.PagamentosViewModel()
                    {
                        Valor = Convert.ToDecimal(item.Total),
                        CodCaixa = pagamento.CodCaixa,
                        CodCambio = pagamento.CodCambio,
                        CodConta = pagamento.CodConta,
                        CodDocumento = item.Codigo,
                        CodForma = pagamento.CodForma,
                        CodMoeda = pagamento.CodMoeda,
                        Hora = pagamento.Hora,
                        Estado = "FECHADO",
                        Descricao = "",
                        Tipo = "CREDITO",
                        CodTurno = pagamento.CodTurno,
                        Data = pagamento.Data
                    });
                    pagamento.Valor -= Convert.ToDecimal(item.Total);
                    if (pagamento.Valor == 0)
                    {
                        pagamento.Estado = "FECHADO";
                        pagamento.Valor = pagamento.Documento.Total;

                    }
                    Update(pagamento);
                }
            }
        }

        public void Update(Folha.Domain.ViewModels.Financeiro.PagamentosViewModel pagamento)
        {
            _PagamentosRepository.Update(pagamento);
        }

        public void Delete(Folha.Domain.ViewModels.Financeiro.PagamentosViewModel pagamento)
        {
            _PagamentosRepository.Delete(pagamento);
        }

        public Folha.Domain.ViewModels.Financeiro.PagamentosViewModel GetById(int id)
        {
            return (Folha.Domain.ViewModels.Financeiro.PagamentosViewModel)_PagamentosRepository.Get(new Folha.Domain.ViewModels.Financeiro.PagamentosViewModel() { codigo = id });
        }

        public List<Folha.Domain.ViewModels.Financeiro.PagamentosViewModel> GetAll()
        {
            return (List<Folha.Domain.ViewModels.Financeiro.PagamentosViewModel>)_PagamentosRepository.Get(new Folha.Domain.ViewModels.Financeiro.PagamentosViewModel() { });
        }

        public void EfectuarPagamentosCx(DadosPagamentoViewModel dados)
        {
            _PagamentosRepository.EfectuarPagamentosCx(dados);
        }

        public void EfectuarPagamentosBn(DadosPagamentoViewModel dados)
        {
            _PagamentosRepository.EfectuarPagamentosBn(dados);
        }

        public List<Folha.Domain.ViewModels.Financeiro.PagamentosViewModel> GetAllByDoc(int codigo)
        {
            return _PagamentosRepository.GetAllPorIdDocumento(codigo);
        }

        public List<Folha.Domain.ViewModels.Financeiro.PagamentosViewModel> GetAllCriditoByDoc(int codigo)
        {
            return _PagamentosRepository.GetAllCriditoByDoc(codigo);
        }

        public int GetUltimoNumeroPagamentoRecibo()
        {
            return _PagamentosRepository.GetUltimoNumeroPagamentoRecibo();
        }

        public List<Folha.Domain.ViewModels.Financeiro.PagamentosViewModel> GetAllCreditosAbertos(int CodCliente)
        {
            return _pagamentoRepository.GetAllCreditosAbertos(CodCliente);
        }

        public int GetUltimoNumeroPagamentoNotaCredito()
        {
            return _pagamentoRepository.GetUltimoNumeroPagamentoNotaCredito();
        }

        public List<Folha.Domain.ViewModels.Financeiro.PagamentosViewModel> GetAllByDoc(int codDocumento, string movFin)
        {
            return _pagamentoRepository.GetAllByDoc(codDocumento, movFin);
        }
    }
}
