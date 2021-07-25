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
    public partial class RelAtendimentos : DevExpress.XtraReports.UI.XtraReport
    {
        public RelAtendimentos(List<AtendimentoHospitalarViewModel> AtendimentoHospitalar, DadosReportViewModel Dados)
        {
            InitializeComponent();

            lbUsuario.Text = Dados.Usuario;
            if(Dados.Caixa != "Todos") { 
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
            objectDataSource1.DataSource = AtendimentoHospitalar;
            
        }

    }
}
