using Folha.Presentation.Desktop.Reports.Geral;
using Folha.Domain.ViewModels.Documentos;
using Folha.Domain.ViewModels.Financeiro;
using Folha.Domain.Helpers;
using System;
using System.Collections.Generic;

namespace Folha.Presentation.Desktop.Reports.Financeiro
{
    public partial class RelNotaPagamento : DevExpress.XtraReports.UI.XtraReport
    {
        public RelNotaPagamento(NotaPagamentoViewModel dados,List<NotaPagamentoViewModel> LtNotaPagamento)
        {
            InitializeComponent();
            objectDataSource2.DataSource = dados;
            var codAGT = dados.Documento.Operacao.APP + " " +
                DateTime.Now.Year + "/" +
                dados.Documento.NumeroOrdem;
            lblEmitido.Text = dados.Documento.Emitido;
            subReportDadosgerais.ReportSource = new RelDadosGeraisDocumentos(
                new DadosGeraisDocumentosViewModel() {
                    NomeDocumento = dados.Documento.Operacao.Nome,
                    Cambio = "0,000",
                    CodAGT = codAGT,
                    DataEmissao = dados.Documento.Data,
                    DataVencimento = dados.Documento.DataVencimento,
                    DescGeracao = "Finalidade: " + dados.Finalidade,
                    Hora = dados.Documento.Hora,
                    Moeda = UtilidadesGenericas.Moeda,
                    MoradaCliente = dados.Documento.MoredaCliente,
                    NifCliente = dados.Documento.NifCliente,
                    NomeCliente = dados.Documento.NomeCliente,
                    NumeroDocumento = dados.Documento.NumeroOrdem,
                    TelCliente = dados.Documento.TelCliente,
                    UsuarioCaixa = dados.Documento.Usuario.Nome,
                    TipoCliente = dados.Documento.Operacao.Entidade,
            });
            xrSubreport1.ReportSource = new RelCabecalho();
            subReportPagamentos.ReportSource = new RelPagamento(LtNotaPagamento);
        }

    }
}
