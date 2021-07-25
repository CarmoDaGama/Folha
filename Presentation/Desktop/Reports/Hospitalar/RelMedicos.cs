using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Folha.Domain.ViewModels.Frame.Hospitalar;
using System.Collections.Generic;
using Folha.Domain.ViewModels.Report;

namespace Folha.Presentation.Desktop.Reports.Hospitalar
{
    public partial class RelMedicos : DevExpress.XtraReports.UI.XtraReport
    {
        public RelMedicos(List<MedicosViewModel> Medicos, DadosReportViewModel Dados)
        {
            InitializeComponent();
            lbUsuario.Text = Dados.Usuario;
            xrSubreport1.ReportSource = new RelCabecalhoInterno();
            objectDataSource1.DataSource = Medicos;
        }

    }
}
