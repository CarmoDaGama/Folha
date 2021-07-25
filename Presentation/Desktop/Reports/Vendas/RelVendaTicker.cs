using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Folha.Domain.ViewModels.Documentos;
using System.Collections.Generic;
using Folha.Domain.Helpers;
using Folha.Domain.Enuns.Documentos;
using System.Linq;

namespace Folha.Presentation.Desktop.Reports.Vendas
{
    public partial class RelVendaTicker : DevExpress.XtraReports.UI.XtraReport
    {
        public List<VendaViewModel> ArtigosVendidos { get; set; }
        private DocumentosViewModel Documento { get; set; }
        public RelVendaTicker(List<VendaViewModel> artigosVendidos)
        {
            InitializeComponent();
            ArtigosVendidos = artigosVendidos;
            loadData();
        }

        private void loadData()
        {
            var documentoOperacao = ArtigosVendidos[0];
            Documento = documentoOperacao.MovArtigo.Documento;
            if (UtilidadesGenericas.InEnumStdDoc(documentoOperacao.MovArtigo.Documento.Estado) == TipoEstadoDocumento.ANULADO)
            {
                Watermark.Text = documentoOperacao.MovArtigo.Documento.Estado;
            }
            LabelAGT.Text = documentoOperacao.MovArtigo.Documento.Operacao.APP + DateTime.Now.Year + "/" + documentoOperacao.MovArtigo.Documento.NumeroOrdem;
            lblDescricao.Text = UtilidadesGenericas.GetDescricaoFooter(
                documentoOperacao.MovArtigo.Documento.Data,
                documentoOperacao.MovArtigo.Documento.Hora,
                LabelAGT.Text, documentoOperacao.MovArtigo.Documento.Total,
                documentoOperacao.MovArtigo.Documento.Hash
            );

            //lblMoeda.Text = UtilidadesGenericas.Moeda;
            //lblDoc.Text = documentoOperacao.MovArtigo.Documento.NumeroOrdem.ToString();

            //lblData.Text = DateTime.Now.ToString("yyyy-MM-dd");
            //parameterFumcionario.Value = documentoOperacao.NomeFumcionario;
            lblNomeDoc.Text = documentoOperacao.MovArtigo.Documento.Operacao.Nome.ToUpper() +": "+ documentoOperacao.MovArtigo.Documento.Operacao.APP + DateTime.Now.Year + "/" + documentoOperacao.MovArtigo.Documento.NumeroOrdem;
            SetTotais();
            lbCliente.Text = documentoOperacao.MovArtigo.Documento.NomeCliente;
            lbUsuario.Text = documentoOperacao.MovArtigo.Documento.CodUsuario + " - " + documentoOperacao.MovArtigo.Documento.Usuario.Nome;
            lbNif.Text =  documentoOperacao.MovArtigo.Documento.Entidade.Nif;
            lbDataImprecaoRotolo.Text = "|    Data Impressão " + DateTime.Now.ToShortDateString();
            lbdataemissaoRodape.Text = "Data Emissão " + documentoOperacao.MovArtigo.Documento.Data.ToShortDateString();


            xrSubreport1.ReportSource = new RelCabecalhoTicker();
        }

        private void NomearDocumento(DocumentosViewModel documento)
        {
            if (documento.Operacao.APP == "NC")
            {
                //cellNomeDocumento.Text = documento.Operacao.Nome.ToUpper() + " - " + documento.Descritivo.ToUpper();
            }
            else
            {
                //cellNomeDocumento.Text = documento.Operacao.Nome.ToUpper();
            }
        }

        private void renderizarTotaisFT(DocumentosViewModel documento)
        {
            if (documento.Operacao.APP == "PP" ||
                documento.Operacao.APP == "ADM" ||
                documento.Operacao.APP == "ASE" ||
                documento.Operacao.APP == "ASE" ||
                documento.Operacao.APP == "RA")
            {
                //lblTextPagamento.Visible = false;
                //lblPagamento.Visible = false;
                //labelDescricaoBensServico.Visible = false;
                //GroupFooterDescricaoDosBens.Visible = false;
                labelDescricaoBensServico.Text = "Este documento não serve de factura".ToUpper();

            }
        }

        private void SetTotais()
        {
            var motivos = new List<MotivoViewModel>();
            var totalImposto = 0.0m;
            var totalDesconto = 0.0m;
            foreach (var item in ArtigosVendidos)
            {

                var oldMotivo = motivos.Where(m => m.MotivoIsencao == item.MovArtigo.DescricaoImposto).FirstOrDefault();
                totalImposto += (item.DecimalImposto * item.Preco) * item.qtde;
                totalDesconto += (item.DecimalDesconto * item.Preco) * item.qtde;
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
            var descontoGlobal = ArtigosVendidos.FirstOrDefault().MovArtigo.DescontoGeral;
            lblTotalPagar.Text = Documento.Total.ToString("N3");
            lblTotalImposto.Text = Documento.Imposto.ToString("N3");
            lblTotalDescontos.Text = Documento.Desconto.ToString("N3");
            lblTotalIliquido.Text = Documento.TotalIliquido.ToString("N3");

            lblExtenso.Text  = "TOTAL EM EXTENSO: " + UtilidadesGenericas.Decimal_Extenso(Documento.Total);
            xrSubreport2.ReportSource = new RelMotivos(motivos);
        }

        private decimal getUSD(decimal valor)
        {
            if (UtilidadesGenericas.Moeda == "USD")
            {
                lblValorCambio.Text = lblValorCambio.Text.Replace("USD", "AKZ");
                return valor * UtilidadesGenericas.UmDolarEmKWZ;
            }
            return (valor / UtilidadesGenericas.UmDolarEmKWZ);
        }
    }
}
