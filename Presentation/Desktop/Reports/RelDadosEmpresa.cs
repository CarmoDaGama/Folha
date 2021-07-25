using DevExpress.XtraReports.UI;
using Folha.Domain.ViewModels.Sistema;

namespace Folha.Presentation.Desktop.Reports
{
    public partial class RelDadosEmpresa : XtraReport
    {
        public RelDadosEmpresa(DadosEmpresaViewModel Dados)
        {
            InitializeComponent();
            cellCambio.Text = Dados.Cambio;
            cellData.Text = Dados.DataHora.ToShortDateString();
            cellHora.Text = Dados.DataHora.ToShortTimeString();
            cellDocumentoId.Text = Dados.DocumentoId.ToString();
            cellFuncionario.Text = Dados.NomeFuncionario;
            cellMoeda.Text = Dados.Moeda;
        }

    }
}
