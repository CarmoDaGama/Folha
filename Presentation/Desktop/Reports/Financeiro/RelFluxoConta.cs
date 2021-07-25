using System;
using DevExpress.XtraReports.UI;
using Folha.Domain.ViewModels.Financeiro;
using System.Collections.Generic;
using Folha.Domain.ViewModels.Report;

namespace Folha.Presentation.Desktop.Reports.Financeiro
{
    public partial class RelFluxoConta : XtraReport
    {
        public RelFluxoConta(List<FluxoCaixaViewModel> LtFluxo, DadosReportViewModel Dados)
        {
            InitializeComponent();
            
            lbConta.Text = Dados.Conta;
            lbUsuario.Text = Dados.Usuario;

            for (int i = 0; i < LtFluxo.Count; i++)
            {
                LtFluxo[i].Data = Convert.ToDateTime(LtFluxo[i].Data).ToShortDateString();
                LtFluxo[i].Valor = Convert.ToDouble(LtFluxo[i].Valor).ToString("N2");
            }

            //lbfim.Text = Convert.ToDateTime(Dados.DataFim).ToShortDateString();
            lbinicio.Text = Convert.ToDateTime(Dados.DataInicio).ToShortDateString();
            lbResultado.Text = Dados.Total.ToString("N2");
            objectDataSource1.DataSource = LtFluxo;
            xrSubreport1.ReportSource = new RelCabecalho();

            lbDataImprecaoRotolo.Text = "Data de Impressão " + DateTime.Now.ToShortDateString();

        }

        private void xrTable2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

        private void xrPanel1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

        private void xrLine1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }
    }
}
