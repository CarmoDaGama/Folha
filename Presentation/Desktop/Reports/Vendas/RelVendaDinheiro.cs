using System;
using DevExpress.XtraReports.UI;
using Folha.Domain.ViewModels.Documentos;
using System.Collections.Generic;
using Folha.Domain.Helpers;
using Folha.Domain.Enuns.Documentos;
using System.Linq;

namespace Folha.Presentation.Desktop.Reports.Vendas
{
    public partial class RelVendaDinheiro : XtraReport
    {
        public List<VendaViewModel> ArtigosVendidos { get; set; }
        private string TipoDeEntidade { get;  set; }
        private DocumentosViewModel Documento { get; set; }

        public RelVendaDinheiro(List<VendaViewModel> artigosVendidos)
        {
            InitializeComponent();
            ArtigosVendidos = artigosVendidos;
            loadData();
        }

        private void loadData()
        {
            if (UtilidadesGenericas.ListaNula(ArtigosVendidos))
            {
                return;
            }

            var documentoOperacao = ArtigosVendidos.FirstOrDefault();
            Documento = documentoOperacao.MovArtigo.Documento;
            lblEmitido.Text = documentoOperacao.MovArtigo.Documento.Emitido;
            LabelAGT.Text = documentoOperacao.MovArtigo.Documento.Operacao.APP + " " +
                            DateTime.Now.Year + "/" + 
                            documentoOperacao.MovArtigo.Documento.NumeroOrdem;
            lblDescricao.Text = UtilidadesGenericas.GetDescricaoFooter(
                documentoOperacao.MovArtigo.Documento.Data,
                documentoOperacao.MovArtigo.Documento.Hora,
                LabelAGT.Text, documentoOperacao.MovArtigo.Documento.Total, 
                documentoOperacao.MovArtigo.Documento.Hash
            );

            var Nif = documentoOperacao.MovArtigo.Documento.Entidade.Nif;

            if (string.IsNullOrEmpty(Nif))
            {
                labelNif.Text = "Nif: 999999999";
            }
            else
            {
                labelNif.Text = "Nif: " + documentoOperacao.MovArtigo.Documento.NifCliente;
            }

            if (documentoOperacao.MovArtigo.Documento.Operacao.APP == "CF")
            {
                 TipoDeEntidade = "Forncedor: ";
            }
            else
            {
                 TipoDeEntidade = "Cliente: ";
            }
            if (UtilidadesGenericas.InEnumStdDoc(
                documentoOperacao.MovArtigo.Documento.Estado) == TipoEstadoDocumento.ANULADO)
            {
                Watermark.Text = documentoOperacao.MovArtigo.Documento.Estado;
            }
            lblHora.Text = documentoOperacao.MovArtigo.Documento.Hora;
            lblMoeda.Text = UtilidadesGenericas.Moeda;
            labelDoc.Text = documentoOperacao.MovArtigo.Documento.NumeroOrdem.ToString();

            carregarCambio(UtilidadesGenericas.UmDolarEmKWZ.ToString("N3"));
            lblDataEmissao.Text = documentoOperacao.MovArtigo.Documento.Data.ToString("yyyy-MM-dd");
            lblFuncionario.Text = documentoOperacao.NomeFumcionario;
            NomearDocumento(documentoOperacao.MovArtigo.Documento);

            lbDataImprecaoRotolo.Text = "|    Data Impressão " + DateTime.Now.ToShortDateString()  ;
            lbdataemissaoRodape.Text = "Data Emissão " + documentoOperacao.MovArtigo.Documento.Data.ToShortDateString();


            labelDoc.Text = documentoOperacao.MovArtigo.CodDocumento.ToString();
            SetTotais();
            lbCliente.Text = TipoDeEntidade + documentoOperacao.MovArtigo.Documento.NomeCliente;
            lblTel.Text = "Tel: " + documentoOperacao.MovArtigo.Documento.TelCliente;
            lblMorada.Text = "Morada: " + documentoOperacao.MovArtigo.Documento.MoredaCliente;
            if (string.IsNullOrEmpty(documentoOperacao.ContaPagamento.Banco.descricao))

            {
                labelCoordenadasBancarias.Text = "Caixa: Numerário";
            }
            else
            {
                labelCoordenadasBancarias.Text = documentoOperacao.ContaPagamento.Banco.descricao + ": "
                   + documentoOperacao.ContaPagamento.Numero + "\n "
                   + documentoOperacao.ContaPagamento.Iban;
            }

            // trazer a data de vencimento nãode emissão
            lbVencimento.Text = documentoOperacao.Data.ToShortDateString();

            xrSubreport1.ReportSource = new RelCabecalho();

            var geracao = documentoOperacao.MovArtigo.Documento.Geracao;
            if(!string.IsNullOrEmpty(geracao) && geracao != "ISENTO")
            {
                lblDescGeracao.Visible = true;
                lblDescGeracao.Text = geracao;
            }
            renderizarTotaisFT(documentoOperacao.MovArtigo.Documento);
        }

        private void NomearDocumento(DocumentosViewModel documento)
        {
            if (documento.Operacao.APP == "NC")
            {
                cellNomeDocumento.Text = documento.Operacao.Nome.ToUpper() + " - " + documento.Descritivo.ToUpper();
            }
            else
            {
                cellNomeDocumento.Text = documento.Operacao.Nome.ToUpper();
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
            if (documento.Operacao.APP == "FR")
            {
                labelCoordenadasBancarias.Visible = true;
                labelCoordenadasBancariasTitulo.Visible = true;
            }
                    
        }

        private void carregarCambio(string cambio)
        {
            cellCambio.Text = cambio;
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
            lblPagamento.Text = Documento.Total.ToString("N3");
            lblTotalImposto.Text = Documento.Imposto.ToString("N3");
            lblTotalDesconta.Text = Documento.Desconto.ToString("N3");
            lblTotalLiquido.Text = Documento.TotalIliquido.ToString("N3");

            porExtenso.Text = "TOTAL EM EXTENSO: " + UtilidadesGenericas.Decimal_Extenso(Documento.Total);
            xrSubreport2.ReportSource = new RelMotivos(motivos);
        }
    }
}
