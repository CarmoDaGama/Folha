using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using Folha.Domain.ViewModels.Report;

namespace Folha.Presentation.Desktop.Reports.Documentos
{
    public partial class RelGrafTotOperacoes : DevExpress.XtraReports.UI.XtraReport
    {
        public RelGrafTotOperacoes(List<RelOpercoesViewModel> LtOperacoes, DadosReportViewModel Dados)
        {
            InitializeComponent();
            xrSubreport1.ReportSource = new RelCabecalhoInterno();
            objectDataSource1.DataSource = LtOperacoes;
            lbUsuario.Text = Dados.Usuario;
            lbinicio.Text = Dados.DataInicio.ToShortDateString();
            lbfim.Text = Dados.DataFim.ToShortDateString();
            lbCliente.Text = Dados.Cliente;

            lbDataImprecaoRotolo.Text = "Data Impressão " + DateTime.Now.ToShortDateString();

        }

    }
}
