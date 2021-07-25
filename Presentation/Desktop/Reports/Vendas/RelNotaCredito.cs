using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Folha.Domain.ViewModels.Documentos;
using Folha.Domain.ViewModels.Financeiro;
using Folha.Domain.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace Folha.Presentation.Desktop.Reports.Vendas
{
    public partial class RelNotaCredito : XtraReport
    {
        public RelNotaCredito(ReciboViewModel dados)
        {
            InitializeComponent();
            objectDataSource1.DataSource = dados;
            carregarTotais(dados.Pagamentos);
            carregarDados(dados.Pagamentos[0]);
            lblTel.Text = "Tel: " + dados.Telefone;
            lblLocalizacao.Text = "Localização: " + dados.Localizacao;
            xrSubreport1.ReportSource = new RelCabecalho();

            xrSubreport2.ReportSource = new RelFacutaras(dados.Documentos);
        }
        public RelNotaCredito(ReciboViewModel dados, List<VendaViewModel> artigosVendidos)
        {
            InitializeComponent();
            //objectDataSource1.DataSource = artigosVendidos;
            subReportArtigos.ReportSource = new RelArtigos(artigosVendidos);
            carregarTotais(dados.Pagamentos);
            carregarDados(dados.Pagamentos[0]);
            carregarTaxas(artigosVendidos);
            lblTel.Text = "Tel: " + dados.Telefone;
            lblLocalizacao.Text = "Localização: " + dados.Localizacao;
            xrSubreport1.ReportSource = new RelCabecalho();

            xrSubreport2.ReportSource = new RelFacutaras(dados.Documentos);
        }

        private void carregarDados(PagamentosViewModel pagamento)
        {
            lblCambio.Text = "300,00";
            lblMoeda.Text = UtilidadesGenericas.Moeda;
            lblDataEmissao.Text = pagamento.Data.ToString("yyyy-MM-dd");
            lblDataVencimento.Text = pagamento.Documento.DataVencimento.ToString("yyyy-MM-dd");
            lblMoeda.Text = UtilidadesGenericas.Moeda;
            lblFuncionario.Text = UtilidadesGenericas.NomeUsuario;
            lblEmitido.Text = pagamento.Emitido;
            LabelAGT.Text = pagamento.Documento.Operacao.APP + " " + DateTime.Now.Year + "/" + pagamento.Documento.NumeroOrdem;
            lbCliente.Text = "Cliente: " + pagamento.Documento.NomeCliente;
            labelNif.Text = "Nif: " + pagamento.Documento.Entidade.Nif;
            xrTableCell4.Text = pagamento.Documento.Operacao.Nome;
            labelDoc.Text = pagamento.NumeroOrdem.ToString();
            lblHora.Text = pagamento.Hora;
        }
        private void carregarTotais(List<PagamentosViewModel> pagamentos)
        {
            var valorTatais = 0.0m;
            foreach (var item in pagamentos)
            {
                valorTatais += item.Valor;
            }
            lblTotal.Text = "TOTAL: " + valorTatais.ToString("N2") + " " + UtilidadesGenericas.Moeda;
            lblValorExtenso.Text = UtilidadesGenericas.Decimal_Extenso(valorTatais);
        }
        private void carregarTaxas(List<VendaViewModel> artigos)
        {
            var motivos = new List<MotivoViewModel>();
            foreach (var item in artigos)
            {

                var oldMotivo = motivos.Where(m => m.MotivoIsencao == item.MovArtigo.DescricaoImposto).FirstOrDefault();

                if (Equals(oldMotivo, null))
                {
                    motivos.Add(new MotivoViewModel()
                    {
                        Taxa = item.MovArtigo.Imposto / 100,
                        Incidencia = item.Preco,
                        MotivoIsencao = item.MovArtigo.DescricaoImposto,
                        TotalIVA = item.MovArtigo.Preco * (item.MovArtigo.Imposto / 100)
                    });
                }
                else
                {

                    oldMotivo.TotalIVA += item.MovArtigo.Preco * (item.MovArtigo.Imposto / 100);
                    oldMotivo.Incidencia += item.Preco;
                }

            }
            xrSubreport3.ReportSource = new RelMotivos(motivos);
        }
    }
}
