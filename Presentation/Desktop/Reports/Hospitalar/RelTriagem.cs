using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Folha.Domain.ViewModels.Hospitalar;
using System.Collections.Generic;
using Folha.Domain.ViewModels.Report;
using Folha.Domain.ViewModels.Frame.Entidades;

namespace Folha.Presentation.Desktop.Reports.Hospitalar
{
    public partial class RelTriagem : DevExpress.XtraReports.UI.XtraReport
    {
        public RelTriagem(List<TriagemViewModel> LtTriagem, DadosReportViewModel Dados, AllEntidadeViewModel paciente)
        {
            InitializeComponent();

            lbUsuario.Text = Dados.Usuario.ToUpper();
            lbinicio.Text = Dados.DataInicio.ToShortDateString();
            lbfim.Text = Dados.DataFim.ToShortDateString();
            xrSubreport1.ReportSource = new RelCabecalhoInterno();
            xrSubreport2.ReportSource = new RelDadosPaciente(paciente);
            objectDataSource2.DataSource = LtTriagem;
        }

    }
}
