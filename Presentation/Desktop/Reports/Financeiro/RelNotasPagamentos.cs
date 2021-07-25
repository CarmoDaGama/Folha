using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Folha.Domain.ViewModels.Report;
using System.Collections.Generic;

namespace Folha.Presentation.Desktop.Reports.Financeiro
{
    public partial class RelNotasPagamentos : DevExpress.XtraReports.UI.XtraReport
    {
        public RelNotasPagamentos(List<RelNotasPagamentosViewModel> LtNotasPagamentos, DadosReportViewModel Dados)
        {
            InitializeComponent();

            lbUsuario.Text = Dados.Usuario;
            lbfim.Text = Dados.DataFim.ToShortDateString();
            lbinicio.Text = Dados.DataInicio.ToShortDateString();
            if (Dados.DataInicio == Convert.ToDateTime("0001-01-01") && Dados.DataFim == Convert.ToDateTime("0001-01-01"))
            { lbPlaceInicio.Visible = false; lbinicio.Visible = false; lbPlaceFim.Visible = false; lbfim.Visible = false; }
            double Total = 0;
            for (int i = 0; i < LtNotasPagamentos.Count; i++)
            {
                Total += Convert.ToDouble(LtNotasPagamentos[i].Valor);
            }
            lbResultado.Text = Total.ToString("N2");
            objectDataSource1.DataSource = LtNotasPagamentos;
            xrSubreport1.ReportSource = new RelCabecalhoInterno();
        }

    }
}
