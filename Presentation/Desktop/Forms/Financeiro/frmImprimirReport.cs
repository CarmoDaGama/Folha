using DevExpress.XtraReports.UI;
using Folha.Domain.Interfaces.Application.Documentos;
using Folha.Domain.Interfaces.Application.Entidades;
using Folha.Domain.Interfaces.Application.Inteligente;
using Folha.Presentation.Desktop.Reports.Financeiro;
using Folha.Presentation.Desktop.Reports.Inventario;
using Folha.Domain.ViewModels.Documentos;
using Folha.Domain.ViewModels.Financeiro;
using Folha.Domain.ViewModels.Hospitalar;
using Folha.Domain.ViewModels.Inventario;
using Folha.Domain.Helpers;
using Folha.Presentation.Desktop.Forms.Apresenta_Doc;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using Folha.Presentation.Desktop.Reports.Vendas;

namespace Folha.Presentation.Desktop.Forms.Financeiro
{
    public partial class frmImprimirReport : DevExpress.XtraEditors.XtraForm
    {
        public enum ResultImpressao
        {
            Visualizar, Imprimir, Cancelar
        }

        private ResultImpressao ResultImpr { get; set; } = ResultImpressao.Cancelar;
        private readonly IDocumentosApp _documentoApp;
        private readonly IEntidadesApp _entidadeApp;
        private readonly IInteligenteApp _inteligenteApp;
        private bool Imprimir { get; set; } = false;
        private bool TrocarMoeda { get; set; }

        public frmImprimirReport(IDocumentosApp _app, IEntidadesApp entidadeApp, IInteligenteApp inteligenteApp)
        {
            InitializeComponent();
            _documentoApp = _app;
            _entidadeApp = entidadeApp;
            _inteligenteApp = inteligenteApp;
        }
        public void ApresentarReportTransferenciaProduto(List<TransferenciaProdutoViewModel> listaProdutos)
        {
            ShowDialog();
            if (Imprimir)
            {
                var doc =_documentoApp.GetById(listaProdutos[0].CodDocumento);
                doc.Emitido = UtilidadesGenericas.MudarEmitidoDocumento(doc.Emitido);
                _documentoApp.Update(doc);
                listaProdutos[0].Documento = null;
                listaProdutos[0].Documento = doc;
                var report = new RelTransferenciaProdutos(listaProdutos);
                if (ResultImpr == ResultImpressao.Imprimir)
                {
                    report.Print(cboImpressora.SelectedItem + "");
                }
                else if (ResultImpr == ResultImpressao.Visualizar)
                {
                    new frmApresentaReport().ApresentarReportTransferenciaProduto(listaProdutos);
                }
                UtilidadesGenericas.Moeda = "AKZ";

            }
        }
        public void ImprimirDocumentoVenda(List<VendaViewModel> data)
        {
            ShowDialog();
            if (Imprimir)
            {
                ApresentarReport(data);
                MudarEmitidoDocumento(data[0].MovArtigo.CodDocumento);
            }
        }
        public void ImprimirRecibo(List<PagamentosViewModel> pagamentos)
        {
            if (UtilidadesGenericas.ListaNula(pagamentos))
            {
                UtilidadesGenericas.MsgShow(
                    "AVISO",
                    "Nao tem dados para este recibo!", 
                    MessageBoxIcon.Warning,
                    MessageBoxButtons.OK
                );
                return;
            }
            ShowDialog();
            if (Imprimir)
            {
                pagamentos[0].Documento.Emitido = UtilidadesGenericas.MudarEmitidoDocumento(pagamentos[0].Documento.Emitido);
                _documentoApp.Update(pagamentos[0].Documento);
                var tel = _entidadeApp.GetTelefoneByEntidade(pagamentos[0].Documento.CodEntidade.ToString());
                var localizacao = _entidadeApp.GetMoradaByEntidade(pagamentos[0].Documento.CodEntidade.ToString());
                var documentos = _inteligenteApp.GetTodosDocsPorRecibo(pagamentos[0].CodDocumento);
                var dadosRecibo = new ReciboViewModel()
                {
                    Pagamentos = pagamentos,
                    Telefone = Equals(tel, null) ? string.Empty : tel.descricao,
                    Localizacao = Equals(localizacao, null) ? string.Empty : localizacao.DescricaoMorada,
                    Documentos = documentos
                };
                var report = new RelRecibo(dadosRecibo);
                if (ResultImpr == ResultImpressao.Imprimir)
                {
                    report.Print(cboImpressora.SelectedItem+"");
                }
                else if (ResultImpr == ResultImpressao.Visualizar)
                {
                    new frmApresentaReport().ApresentarReport(documentos, report);
                }
                UtilidadesGenericas.Moeda = "AKZ";
            }
        }

        /**public void ImprimirTurno(List<Folha.Domain.ViewModels.Frame.Financeiro.CaixaViewModel> LtCaixa, List<Folha.Domain.ViewModels.Frame.Documentos.DocumentoViewModel> LtDocs, List<Folha.Domain.ViewModels.Inventario.MovArtigoViewModel> LtArtigosVendidos, string acesso)
        {
            ShowDialog();
            if (Imprimir)
            {

                var report = new RelFechoTurno(LtCaixa, LtDocs, LtArtigosVendidos, acesso);
                if (ResultImpr == ResultImpressao.Imprimir)
                {
                    reportcboImpressora.SelectedItem+"");
                }
                else if (ResultImpr == ResultImpressao.Visualizar)
                {
                    new frmApresentaReport().ApresentarRelFechoTurno(LtCaixa, LtDocs, LtArtigosVendidos, acesso);
                }
            }
        }*/
        /**public void ImprimirAtendimento(List<TriagemViewModel> LtTriagem, 
                                        List<TriagemPacienteViewModel> LtPerguntas, 
                                        List<MarcacaoConsultaViewModel> LtConsultas,
                                        List<ExamesViewModel> LtExames, 
                                        List<PacienteInternado> LtInternamento)
        {
            ShowDialog();
            if (Imprimir)
            {

                var report = new RelAtendimento(LtTriagem, LtPerguntas, LtConsultas, LtExames, LtInternamento);
                if (ResultImpr == ResultImpressao.Imprimir)
                {
                    reportcboImpressora.SelectedItem+"");
                }
                else if (ResultImpr == ResultImpressao.Visualizar)
                {
                    new frmApresentaReport().ApresentaRelAtendimento(LtTriagem, LtPerguntas, LtConsultas, LtExames, LtInternamento);
                }
            }
        }*/
        public void ImprimirDocumentoVenda(List<VendaViewModel> data, bool trocarMoeda)
        {
            TrocarMoeda = trocarMoeda;
            ShowDialog();
            if (Imprimir)
            {
                ApresentarReport(data);
                MudarEmitidoDocumento(data[0].MovArtigo.CodDocumento);
            }
        }
        public void ApresentarReport(object Datas)
        {
            XtraReport report;
            if (cboForamato.SelectedItem.ToString() == "Ticket")
            {
                report = new RelVendaTicker((List<VendaViewModel>)Datas);
            }
            else
            {
                report = new RelVendaDinheiro((List<VendaViewModel>)Datas);
            }

            if (ResultImpr == ResultImpressao.Imprimir)
            {
                report.Print(cboImpressora.SelectedItem+"");
            }
            else if (ResultImpr == ResultImpressao.Visualizar)
            {
                new frmApresentaReport().ApresentarReport(Datas, report);
            }
            UtilidadesGenericas.Moeda = "AKZ";
        }


        private void MudarEmitidoDocumento(int codDocumento)
        {
            var documento = _documentoApp.GetById(codDocumento);
            documento.Emitido = UtilidadesGenericas.MudarEmitidoDocumento(documento.Emitido);
            _documentoApp.Update(documento);
        }
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            Imprimir = true;
            ResultImpr = ResultImpressao.Imprimir;
            Close();

        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            Imprimir = false;
            Close();
        }

        private void cboMoeda_SelectedIndexChanged(object sender, EventArgs e)
        {
            UtilidadesGenericas.Moeda = cboMoeda.SelectedItem.ToString();
        }

        private void frmImprimirReport_Load(object sender, EventArgs e)
        {
            cboMoeda.Visible = TrocarMoeda;
            lblMoeda.Visible = TrocarMoeda;
            cboMoeda.SelectedItem = UtilidadesGenericas.Moeda;
            if (!TrocarMoeda)
            {
                Size = new Size(Width, 205);
            }
            CarregarImpressorasInstaladas();
        }

        private void CarregarImpressorasInstaladas()
        {
            cboImpressora.Properties.Items.Clear();
            foreach (string strImpressora in PrinterSettings.InstalledPrinters)
            {
                
                cboImpressora.Properties.Items.Add(strImpressora);
            }
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            Imprimir = true;
            ResultImpr = ResultImpressao.Visualizar;
            Close();
        }

        public void ImprimirNotaCredito(List<VendaViewModel> list, List<PagamentosViewModel> pagamentos)
        {
            ShowDialog();
            if (Imprimir && !UtilidadesGenericas.ListaNula(list) && !UtilidadesGenericas.ListaNula(pagamentos))
            {
                pagamentos[0].Emitido = UtilidadesGenericas.MudarEmitidoDocumento(pagamentos[0].Emitido);
                var tel = _entidadeApp.GetTelefoneByEntidade(pagamentos[0].Documento.CodEntidade.ToString());
                var localizacao = _entidadeApp.GetMoradaByEntidade(pagamentos[0].Documento.CodEntidade.ToString());

                var dadosRecibo = new ReciboViewModel()
                {
                    Pagamentos = pagamentos,
                    Telefone = Equals(tel, null) ? string.Empty : tel.descricao,
                    Localizacao = Equals(localizacao, null) ? string.Empty : localizacao.DescricaoMorada,
                    Documentos = _inteligenteApp.GetTodosDocsPorRecibo(pagamentos[0].CodDocumento)
                };
                var report = new RelNotaCredito(dadosRecibo, list);
                if (ResultImpr == ResultImpressao.Imprimir)
                {
                    report.Print(cboImpressora.SelectedItem+"");
                }
                else if (ResultImpr == ResultImpressao.Visualizar)
                {
                    new frmApresentaReport().ApresentarReport(pagamentos, report);
                }
                UtilidadesGenericas.Moeda = "AKZ";
            }
        }

        public void ApresentarReportNotaPagamento(NotaPagamentoViewModel dados, List<NotaPagamentoViewModel> ltPagamento)
        {
            ShowDialog();
            if (Imprimir)
            {
                var report = new RelNotaPagamento(dados, ltPagamento);
                dados.Documento.Emitido = UtilidadesGenericas.MudarEmitidoDocumento(dados.Documento.Emitido);
                _documentoApp.Update(dados.Documento);
                if (ResultImpr == ResultImpressao.Imprimir)
                {
                    report.Print(cboImpressora.SelectedItem + "");
                }
                else if (ResultImpr == ResultImpressao.Visualizar)
                {
                    new frmApresentaReport().ApresentarReportNotaPagamento(dados, ltPagamento);
                }
                UtilidadesGenericas.Moeda = "AKZ";
            }
        }
    }
}