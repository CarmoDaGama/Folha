using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Folha.Domain.ViewModels.Report;
using System.Collections.Generic;

namespace Folha.Presentation.Desktop.Reports.Inventario
{
    public partial class RelRetencaoArtigos : DevExpress.XtraReports.UI.XtraReport
    {
        public RelRetencaoArtigos(List<RelListagemArtigosViewModel> LtArtigos, DadosReportViewModel Dados)
        {
            InitializeComponent();
            lbArmazem.Text = Dados.Armazem;
            lbinicio.Text = Dados.DataInicio.ToShortDateString();
            lbfim.Text = Dados.DataFim.ToShortDateString();
            objectDataSource1.DataSource = LtArtigos;
            xrSubreport1.ReportSource = new RelCabecalhoInterno();
        }

    }
}
