using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Folha.Domain.ViewModels.Inventario;

namespace Folha.Presentation.Desktop.Reports.Inventario
{
    public partial class RelProdutosIndividual : DevExpress.XtraReports.UI.XtraReport
    {
        public RelProdutosIndividual(ProdutosViewModel dados)
        {
            InitializeComponent();
            objectDataSource1.DataSource = dados;
            xrSubreport1.ReportSource = new RelCabecalho();
        }

    }
}
