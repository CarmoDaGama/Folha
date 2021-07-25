using Folha.Domain.Models.Inventario;
using Folha.Domain.ViewModels.Inventario;
using System.Collections.Generic;

namespace Folha.Presentation.Desktop.Reports.Inventario
{
    public partial class RelImpostos : DevExpress.XtraReports.UI.XtraReport
    {
        public RelImpostos(List<ImpostoViewModel> dados)
        {
            InitializeComponent();
            objectDataSource2.DataSource = dados;
            xrSubreport1.ReportSource = new RelCabecalho();

        }

    }
}
