using DevExpress.XtraReports.UI;
using Folha.Domain.ViewModels.Documentos;
using System.Collections.Generic;

namespace Folha.Presentation.Desktop.Reports.Vendas
{
    public partial class RelArtigos : XtraReport
    {
        public RelArtigos(List<VendaViewModel> artigosVendidos)
        {
            InitializeComponent();
            objectDataSource1.DataSource = artigosVendidos;
        }

    }
}
