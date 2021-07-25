using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Folha.Domain.ViewModels.Report;
using System.Collections.Generic;

namespace Folha.Presentation.Desktop.Reports.Financeiro
{
    public partial class RelSaldoCliente : DevExpress.XtraReports.UI.XtraReport
    {
        public RelSaldoCliente(List<SaldoClienteViewModel> LtSaldoCliente, DadosReportViewModel Dados)
        {
            InitializeComponent();

            lbUsuario.Text = Dados.Usuario;
            lbinicio.Text = Dados.DataInicio.ToShortDateString();
            lbfim.Text = Dados.DataFim.ToShortDateString();
            if (Dados.DataInicio == Convert.ToDateTime("0001-01-01") && Dados.DataFim == Convert.ToDateTime("0001-01-01"))
            { lbPlaceInicio.Visible = false; lbinicio.Visible = false; lbPlaceFim.Visible = false; lbfim.Visible = false; }
            objectDataSource1.DataSource = LtSaldoCliente;
            xrSubreport1.ReportSource = new RelCabecalhoInterno();
        }

    }
}
