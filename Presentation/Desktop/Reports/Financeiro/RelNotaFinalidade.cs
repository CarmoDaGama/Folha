using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Folha.Domain.ViewModels.Report;
using System.Collections.Generic;

namespace Folha.Presentation.Desktop.Reports.Financeiro
{
    public partial class RelNotaFinalidade : DevExpress.XtraReports.UI.XtraReport
    {
        public RelNotaFinalidade(List<RelNotaFinalidadeViewModel> LtNotaFinalidade, DadosReportViewModel Dados)
        {
            InitializeComponent();
            lbDataImprecaoRotolo.Text = "Data de Impressão " + DateTime.Now.ToShortDateString();

            lbUsuario.Text = Dados.Usuario;
            lbinicio.Text = Dados.DataInicio.ToShortDateString();
            lbfim.Text = Dados.DataFim.ToShortDateString();

            double soma = 0;
            for (int i = 0; i < LtNotaFinalidade.Count; i++)
            {
                soma += LtNotaFinalidade[i].Valor;
            }
            lbResultado.Text ="Total: "+ soma.ToString("N2");
            objectDataSource1.DataSource = LtNotaFinalidade;
            xrSubreport1.ReportSource = new RelCabecalhoInterno();
        }

    }
}
