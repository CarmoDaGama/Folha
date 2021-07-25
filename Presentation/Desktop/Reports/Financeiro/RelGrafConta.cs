using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Folha.Domain.ViewModels.Report;
using System.Collections.Generic;

namespace Folha.Presentation.Desktop.Reports.Financeiro
{
    public partial class RelGrafConta : DevExpress.XtraReports.UI.XtraReport
    {
        public RelGrafConta(List<SaldoBancoViewModel> LtSaldoConta, DadosReportViewModel Dados)
        {
            InitializeComponent();
            objectDataSource1.DataSource = LtSaldoConta;
            lbUsuario.Text = Dados.Usuario;
            lbinicio.Text = Dados.DataInicio.ToShortDateString();
            lbfim.Text = Dados.DataFim.ToShortDateString();
            xrSubreport1.ReportSource = new RelCabecalho();
            lbDataImprecaoRotolo.Text = "Data de Impressão " + DateTime.Now.ToShortDateString();

        }

    }
}
