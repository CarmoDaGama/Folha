using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Folha.Presentation.Desktop.Reports.Financeiro
{
    public partial class RelSaldoTotalizadores : DevExpress.XtraReports.UI.XtraReport
    {
        public RelSaldoTotalizadores()
        {
            InitializeComponent();
            xrSubreport1.ReportSource = new RelCabecalho();

            lbDataImprecaoRotolo.Text = "Data de Impressão " + DateTime.Now.ToShortDateString();

        }

    }
}
