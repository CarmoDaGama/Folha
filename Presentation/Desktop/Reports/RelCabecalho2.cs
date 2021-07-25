using Folha.Domain.Models.Empresa;
using Folha.Domain.Models.Inventario;
using System.Collections.Generic;

namespace Folha.Presentation.Desktop.Reports
{
    public partial class RelCabecalho2 : DevExpress.XtraReports.UI.XtraReport
    {
        public RelCabecalho2(Empresa dados)
        {
            InitializeComponent();
            objectDataSource1.DataSource = dados;
        }

    }
}
