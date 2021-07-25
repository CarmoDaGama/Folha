using DevExpress.XtraReports.UI;
using Folha.Domain.ViewModels.Documentos;

namespace Folha.Presentation.Desktop.Reports.Geral
{
    public partial class RelDadosGeraisDocumentos : XtraReport
    {
        public RelDadosGeraisDocumentos(DadosGeraisDocumentosViewModel dados)
        {
            InitializeComponent();
            cellNomeDocumento.Text = dados.NomeDocumento;
            LabelAGT.Text = dados.CodAGT;
            lblDescGeracao.Text = dados.DescGeracao;
            lbCliente.Text = "Cliente: " + dados.NomeCliente;
            lblMorada.Text = "Localizção: " + dados.MoradaCliente;
            labelNif.Text = "Nif: " + dados.NifCliente;
            lblTel.Text = "Tel: " + dados.TelCliente;
            labelDoc.Text = dados.NumeroDocumento.ToString();
            lblDataEmissao.Text = dados.DataEmissao.ToShortDateString();
            lblHora.Text = dados.Hora;
            lbVencimento.Text = dados.DataVencimento.ToShortDateString();
            lblMoeda.Text = dados.Moeda;
            cellCambio.Text = dados.Cambio;
            lblFuncionario.Text = dados.UsuarioCaixa;
            if (dados.TipoCliente == "ISENTO")
            {
                panelCliente.Visible = false;
            }
        }

    }
}
