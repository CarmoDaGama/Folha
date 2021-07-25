using Folha.Domain.ViewModels.Inventario;
using System.Collections.Generic;

namespace Folha.Presentation.Desktop.Reports.Inventario
{
    public partial class RelProdutos : DevExpress.XtraReports.UI.XtraReport
    {
        public RelProdutos(List<ArtigoViewModel> dados)
        {
            InitializeComponent();
            objectDataSource1.DataSource = dados;
            xrSubreport1.ReportSource = new RelCabecalho();
        }

    }
}
