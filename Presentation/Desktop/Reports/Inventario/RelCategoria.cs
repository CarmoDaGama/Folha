using Folha.Domain.Models.Inventario;
using System.Collections.Generic;

namespace Folha.Presentation.Desktop.Reports.Inventario
{
    public partial class RelCategoria : DevExpress.XtraReports.UI.XtraReport
    {
        public RelCategoria(List<Categoria> dados)
        {
            InitializeComponent();
            objectDataSource1.DataSource = dados;
            xrSubreport1.ReportSource = new RelCabecalho();

        }

    }
}
