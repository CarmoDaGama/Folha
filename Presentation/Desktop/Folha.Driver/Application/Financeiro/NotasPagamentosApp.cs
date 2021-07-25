using Folha.Domain.Interfaces.Application.Financeiro;
using System;
using System.Collections.Generic;
using Folha.Domain.Models.Financeiro;
using Folha.Domain.Interfaces.Repository.Financeiro;
using Folha.Domain.ViewModels.Frame.Financeiro;
using System.Data;
using Folha.Domain.ViewModels.Financeiro;
using Folha.Domain.Interfaces.Application.Genericos;
using Folha.Domain.Interfaces.Application.Documentos;

namespace Folha.Driver.Application.Financeiro
{
    public class NotasPagamentosApp : INotasPagamentosApp
    {
        private readonly INotasPagamentosRepository _NotaPagamentoRepository;
        private readonly IGenericoApp _GenericoApp;
        private readonly IDocumentosApp _documentoApp;

        public NotasPagamentosApp(INotasPagamentosRepository NotaPagamentoRepository, IGenericoApp genericoApp, IDocumentosApp documentoApp)
        {
            _NotaPagamentoRepository = NotaPagamentoRepository;
            _GenericoApp = genericoApp;
            _documentoApp = documentoApp; 
        }
        public void addNotaPagamento(NotaPagamento NotaPagamento)
        {
            _NotaPagamentoRepository.Insert(NotaPagamento);
        }

        public List<NotaPagamento> Listar(string criterios)
        {
            throw new NotImplementedException();
        }

        public List<NotaPagamentoViewModel> ListarNotasPagamentos(int codDocumento)
        {
            return _NotaPagamentoRepository.ListarNotasPagamentos(codDocumento);
        }
        public List<NotaPagamento> BuscarTabela_com_Criterio(string criterios)
        {
           return _NotaPagamentoRepository.BuscarTabela_com_Criterio(criterios);
        }
        
        public List<BuscaDocNotaPagamentoViewModel> BuscaDocumento(string criterios)
        {
            return _NotaPagamentoRepository.BuscarDocumento(criterios);
        }
        public NotaPagamentoViewModel GetNotaPagamento(int cod)
        {
            var ListNotaSaida = BuscarTabela_com_Criterio(cod.ToString());
            NotaPagamentoViewModel dados = null;
            if (ListNotaSaida.Count > 0)
            {
                var Finalidade = _GenericoApp.GetDescricaoByCodigo("TipoSaida", int.Parse(ListNotaSaida[0].CodTipoSaida));

                //txtObservacao.Text = ListNotaSaida[0].Descricao;
                //txtCodFinalidade.Text = ListNotaSaida[0].CodTipoSaida;
                //txtFinalidade.Text = Finalidade.Descricao;
                var ListDoc = BuscaDocumento(cod.ToString());
                //txtCodEntidade.Text = ListDoc[0].Codigo.ToString();
                //txtEntidade.Text = ListDoc[0].Entidade.ToString();
                //DateTime Data = DateTime.Parse(ListDoc[0].Data.ToString());
                //timeData.Text = Data.ToShortDateString();

                dados = new NotaPagamentoViewModel()
                {
                    Finalidade = Finalidade.Descricao,
                    CodCliente = ListDoc[0].Codigo,
                    Cliente = ListDoc[0].Entidade,
                    CodDocumento = cod,
                    Documento = _documentoApp.GetById(cod),
                    Data = ListDoc[0].Data,
                    Funcionario = ListDoc[0].Usuario,
                    Hora = ListDoc[0].Hora,
                    Obs = ListNotaSaida[0].Descricao

                };

            }
            return dados;
        }
    }
}
