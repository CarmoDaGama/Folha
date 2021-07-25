using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Folha.Domain.ViewModels.Frame.Entidades;

namespace Folha.Presentation.Desktop.Reports.Hospitalar
{
    public partial class RelDadosPaciente : DevExpress.XtraReports.UI.XtraReport
    {
        public RelDadosPaciente(AllEntidadeViewModel paciente)
        {
            InitializeComponent();

            lbPaciente.Text = paciente.Nome;
            lbNascimento.Text = paciente.DataNascimento.ToShortDateString();
            lbSexo.Text = paciente.Sexo;
            lbEstdoCivil.Text = paciente.EstadoCivil;
        }

    }
}
