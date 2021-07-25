using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Folha.Domain.ViewModels.Report;
using System.Collections.Generic;
using Folha.Domain.Models.Hospitalar;

namespace Folha.Presentation.Desktop.Reports.Hospitalar
{
    public partial class RelInternamentos : DevExpress.XtraReports.UI.XtraReport
    {
        public RelInternamentos(List<PacienteInternado> InternamentoHospitalar, DadosReportViewModel Dados)
        {
            InitializeComponent();

            lbUsuario.Text = Dados.Usuario;
            if (Dados.Caixa != "Todos")
            {
                lbfim.Text = Dados.DataFim.ToShortDateString();
                lbinicio.Text = Dados.DataInicio.ToShortDateString();
                xrLabel2.Visible = true;
                xrLabel3.Visible = true;
                lbfim.Visible = true;
                lbinicio.Visible = true;
            }
            else
            {
                xrLabel2.Visible = false;
                xrLabel3.Visible = false;
                lbfim.Visible = false;
                lbinicio.Visible = false;
            }
            xrSubreport1.ReportSource = new RelCabecalhoInterno();
            objectDataSource1.DataSource = InternamentoHospitalar;
        }

    }
}
