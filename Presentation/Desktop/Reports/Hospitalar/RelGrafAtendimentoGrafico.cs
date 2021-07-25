using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using Folha.Domain.ViewModels.Hospitalar;
using Folha.Domain.ViewModels.Report;

namespace Folha.Presentation.Desktop.Reports.Hospitalar
{
    public partial class RelGrafAtendimentoGrafico : DevExpress.XtraReports.UI.XtraReport
    {
        public RelGrafAtendimentoGrafico(List<AtendimentoHospitalarGraficViewModel> LtAtendimentoGrafico, DadosReportViewModel Dados)
        {
            InitializeComponent();

            objectDataSource2.DataSource = LtAtendimentoGrafico;
            lbUsuario.Text = Dados.Usuario;
            lbinicio.Text = Dados.DataInicio.ToShortDateString();
            lbfim.Text = Dados.DataFim.ToShortDateString();
            xrSubreport1.ReportSource = new RelCabecalho();
        }

    }
}
