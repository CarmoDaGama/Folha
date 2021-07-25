using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using Folha.Domain.ViewModels.Financeiro;
using Folha.Domain.Helpers;
using System;
using Folha.Domain.ViewModels.Documentos;
using Folha.Presentation.Desktop.Reports.Geral;

namespace Folha.Presentation.Desktop.Reports.Vendas
{
    public partial class RelRecibo : XtraReport
    {
        private ReciboViewModel DadosRecibo { get; set; }

        public RelRecibo(ReciboViewModel dados)
        {
            InitializeComponent();
            DadosRecibo = dados;
            objectDataSource1.DataSource = null;
            objectDataSource1.DataSource = dados.Documentos;
            carregarTotais(dados.Pagamentos);
            carregarDados(dados.Pagamentos[0]);
            //lblTel.Text = "Tel: " + dados.Telefone;
            //lblLocalizacao.Text = "Localização: " + dados.Localizacao;
            xrSubreport1.ReportSource = new RelCabecalho();
           
            //xrSubreport2.ReportSource = new RelFacutaras(dados.Documentos);
        }

        private void carregarTotais(List<PagamentosViewModel> pagamentos)
        {
            var valorTatais = 0.0m;
            foreach (var item in pagamentos)
            {
                valorTatais += item.Valor;
            }
            lblTotal.Text =  valorTatais.ToString("N3") + " " + UtilidadesGenericas.Moeda;
            lblValorExtenso.Text = UtilidadesGenericas.Decimal_Extenso(valorTatais);
        }

        private void carregarDados(PagamentosViewModel pagamento)
        {
            //lblCambio.Text = "300,00";
            //lblMoeda.Text = UtilidadesGenericas.Moeda;
            //lblDataEmissao.Text = pagamento.Data.ToString("yyyy-MM-dd");
            //lblDataVencimento.Text = pagamento.Documento.DataVencimento.ToString("yyyy-MM-dd");
            //lblMoeda.Text = UtilidadesGenericas.Moeda;
            //lblFuncionario.Text = UtilidadesGenericas.NomeUsuario;
            lblEmitido.Text = pagamento.Documento.Emitido;
            var codAGT = pagamento.Documento.Operacao.APP + " " + DateTime.Now.Year + "/" + pagamento.Documento.NumeroOrdem;
            //lbCliente.Text =  pagamento.Documento.NomeCliente;
            //labelNif.Text =  pagamento.Documento.Entidade.Nif;
            //xrTableCell4.Text = pagamento.Documento.Operacao.Nome;
            //labelDoc.Text = pagamento.Documento.NumeroOrdem.ToString();
            //lblHora.Text = pagamento.Documento.Hora;
            var dadosGerais = new DadosGeraisDocumentosViewModel() {
                NumeroDocumento = pagamento.Documento.NumeroOrdem,
                Cambio = pagamento.Cambio.cambio.ToString("N3"),
                DataEmissao = pagamento.Documento.Data,
                DataVencimento = pagamento.Documento.DataVencimento,
                Hora = pagamento.Documento.Hora,
                Moeda = UtilidadesGenericas.Moeda,
                UsuarioCaixa = pagamento.Documento.Usuario.Nome,
                CodAGT = codAGT,
                DescGeracao =string.Empty,
                NomeCliente = pagamento.Documento.NomeCliente,
                NifCliente = pagamento.Documento.Entidade.Nif,
                NomeDocumento = pagamento.Documento.Operacao.Nome,
                TelCliente = DadosRecibo.Telefone,
                MoradaCliente = DadosRecibo.Localizacao,
                TipoCliente = pagamento.Documento.Operacao.Entidade
            };
            lblDescricao.Text = UtilidadesGenericas.GetDescricaoFooter(
                 pagamento.Documento.Data,
                 pagamento.Documento.Hora,
                 codAGT, 
                 pagamento.Documento.Total,
                 pagamento.Documento.Hash
             );
            subreportDadosGerais.ReportSource = new RelDadosGeraisDocumentos(dadosGerais);
        }
    }
}
