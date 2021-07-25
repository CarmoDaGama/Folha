using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using Folha.Domain.ViewModels.Report;

namespace Folha.Presentation.Desktop.Reports.Inventario
{
    public partial class RelListagemArtigos : DevExpress.XtraReports.UI.XtraReport
    {
        public RelListagemArtigos(List<RelListagemArtigosViewModel>LtArtigos,string Armazem)
        {
            InitializeComponent();
            lbArmazem.Text = Armazem;
            objectDataSource1.DataSource = LtArtigos;
            xrSubreport1.ReportSource = new RelCabecalhoInterno();
        }

    }
}
