using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using Folha.Domain.Models.Financeiro;

namespace Folha.Presentation.Desktop.Reports.Documentos
{
    public partial class RelGrafPeriodicoMov : DevExpress.XtraReports.UI.XtraReport
    {
        public RelGrafPeriodicoMov(List<Saldos> LtSaldo)
        {
            InitializeComponent();
            xrSubreport1.ReportSource = new RelCabecalho();
            objectDataSource1.DataSource = LtSaldo;
            lbDataImprecaoRotolo.Text = "Data Impressão " + DateTime.Now.ToShortDateString();

        }

    }
}
