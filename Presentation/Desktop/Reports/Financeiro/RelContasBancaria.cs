using Folha.Domain.Models.Financeiro;
using System;
using System.Collections.Generic;

namespace Folha.Presentation.Desktop.Reports.Financeiro
{
    public partial class RelContasBancaria : DevExpress.XtraReports.UI.XtraReport
    {
        public RelContasBancaria(List<ContasBancarias> dados)
        {
            InitializeComponent();
            objectDataSource1.DataSource = dados;
            lbDataImprecaoRotolo.Text = "Data de Impressão " + DateTime.Now.ToShortDateString();

            xrSubreport1.ReportSource = new RelCabecalho();
        }
    }
}
