using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;

namespace Folha.Presentation.Desktop.Reports.Admin
{
    public partial class RelUsuario : DevExpress.XtraReports.UI.XtraReport
    {
        public RelUsuario(List<Domain.Models.UtilitariosConfiguracoes.Usuarios> dados)
        {
            InitializeComponent();
            objectDataSource1.DataSource = dados;
            xrSubreport1.ReportSource = new RelCabecalho();
            lbDataImprecaoRotolo.Text = "Data de Impressão " + DateTime.Now.ToShortDateString();

        }

    }
}
