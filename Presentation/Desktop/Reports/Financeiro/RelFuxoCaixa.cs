using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Folha.Domain.ViewModels.Financeiro;
using System.Collections.Generic;
using Folha.Domain.ViewModels.Report;

namespace Folha.Presentation.Desktop.Reports.Financeiro
{
    public partial class RelFuxoCaixa : DevExpress.XtraReports.UI.XtraReport
    {
        public RelFuxoCaixa(List<FluxoCaixaViewModel> LtFluxo, DadosReportViewModel Dados)
        {
            InitializeComponent();
            lbDataImprecaoRotolo.Text = "Data de Impressão " + DateTime.Now.ToShortDateString();

            lbcaixa.Text = Dados.Caixa;
            lbUsuario.Text = Dados.Usuario;
            lbfim.Text = Dados.DataFim.ToShortDateString();
            lbinicio.Text = Dados.DataInicio.ToShortDateString();

            for (int i = 0; i < LtFluxo.Count; i++)
            {
                LtFluxo[i].Data = Convert.ToDateTime(LtFluxo[i].Data).ToShortDateString();
                LtFluxo[i].Valor = Convert.ToDouble(LtFluxo[i].Valor).ToString("N2");
            }

            lbResultado.Text = Dados.Total.ToString("N2");
            objectDataSource1.DataSource = LtFluxo;
            xrSubreport1.ReportSource = new RelCabecalhoInterno();

        }

        private void xrTable2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }
    }
}
