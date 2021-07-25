using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Folha.Domain.ViewModels.Report;
using System.Collections.Generic;

namespace Folha.Presentation.Desktop.Reports.Financeiro
{
    public partial class RelDividasCliente : DevExpress.XtraReports.UI.XtraReport
    {
        public RelDividasCliente(List<SaldoClienteViewModel> LtSaldoCliente, DadosReportViewModel Dados)
        {
            InitializeComponent();
            lbDataImprecaoRotolo.Text = "Data de Impressão " + DateTime.Now.ToShortDateString();

            lbUsuario.Text =  Dados.Usuario;
            lbinicio.Text = Dados.DataInicio.ToShortDateString();
            lbfim.Text = Dados.DataFim.ToShortDateString();
            Dados.DataInicio = Convert.ToDateTime("0001-01-01"); Dados.DataFim = Convert.ToDateTime("0001-01-01");
            objectDataSource1.DataSource = LtSaldoCliente;
            xrSubreport1.ReportSource = new RelCabecalhoInterno();
        }

    }
}
