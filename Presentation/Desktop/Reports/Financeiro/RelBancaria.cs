using Folha.Domain.ViewModels.Financeiro;
using System;
using System.Collections.Generic;

namespace Folha.Presentation.Desktop.Reports.Financeiro
{
    public partial class RelBancaria : DevExpress.XtraReports.UI.XtraReport
    {
        public RelBancaria(List<BancosViewModel> dados)
        {
            InitializeComponent();
            objectDataSource1.DataSource = dados;
            lbDataImprecaoRotolo.Text = "Data de Impressão " + DateTime.Now.ToShortDateString();

            xrSubreport1.ReportSource = new RelCabecalho();
        }

    }
}
