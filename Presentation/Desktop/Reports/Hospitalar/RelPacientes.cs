using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Folha.Domain.ViewModels.Hospitalar;
using System.Collections.Generic;
using Folha.Domain.ViewModels.Report;

namespace Folha.Presentation.Desktop.Reports.Hospitalar
{
    public partial class RelPacientes : DevExpress.XtraReports.UI.XtraReport
    {
        public RelPacientes(List<PacienteViewModel> pacientes, DadosReportViewModel Dados)
        {
            InitializeComponent();
            lbUsuario.Text = Dados.Usuario;
            xrSubreport1.ReportSource = new RelCabecalhoInterno();
            objectDataSource1.DataSource = pacientes;
        }

    }
}
