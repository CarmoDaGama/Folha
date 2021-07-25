using Folha.Domain.ViewModels.Documentos;
using Folha.Domain.Enuns.Documentos;
using Folha.Domain.Helpers;

namespace Folha.Presentation.Desktop.Reports.Geral
{
    public partial class RelCabecalho2 : DevExpress.XtraReports.UI.XtraReport
    {
        private CabecalhoReportViewModel DadosDoCabeçalho { get; set; }
        public RelCabecalho2(CabecalhoReportViewModel dadosDoCabeçalho)
        {
            InitializeComponent();
            DadosDoCabeçalho = dadosDoCabeçalho;
            if (UtilidadesGenericas.InEnumStdDoc(dadosDoCabeçalho.EstadoDocumento) == TipoEstadoDocumento.ANULADO)
            {
                lblEstadoDocumento.Text = dadosDoCabeçalho.EstadoDocumento.ToUpper();
                lblEstadoDocumento.Visible = true;
            }
            lblCliente.Text =string.IsNullOrEmpty(dadosDoCabeçalho.Cliente) ? "Exemplo" : dadosDoCabeçalho.Cliente;
            lblDescricao.Text = string.IsNullOrEmpty(dadosDoCabeçalho.Descricao) ? "Exemplo" : dadosDoCabeçalho.Descricao;
            lblNomeEmpresa.Text = string.IsNullOrEmpty(dadosDoCabeçalho.NomeEmpresa) ? "Nome Da Empresa" : dadosDoCabeçalho.NomeEmpresa;
            lblNIF.Text = string.IsNullOrEmpty(dadosDoCabeçalho.NIF) ? "Exemplo" : dadosDoCabeçalho.NIF;
            lblNIF2.Text = string.IsNullOrEmpty(dadosDoCabeçalho.NIF) ? "Exemplo" : dadosDoCabeçalho.NIF;
            lblTel.Text = string.IsNullOrEmpty(dadosDoCabeçalho.Tel) ? "Exemplo" : dadosDoCabeçalho.Tel;

        }

    }
}
