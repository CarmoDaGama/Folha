using Folha.Domain.Models.Financeiro;
using System;
using System.Collections.Generic;

namespace Folha.Presentation.Desktop.Reports.Financeiro
{
    public partial class RelCaixas : DevExpress.XtraReports.UI.XtraReport
    {
        public RelCaixas(List<Caixas> dados)
        {
            InitializeComponent();
            lbDataImprecaoRotolo.Text = "Data de Impressão " + DateTime.Now.ToShortDateString();

            objectDataSource1.DataSource = dados;
            xrSubreport1.ReportSource = new RelCabecalho();
        }

    }
}
