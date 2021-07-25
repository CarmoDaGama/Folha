using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Folha.Domain.ViewModels.Report;
using System.Collections.Generic;

namespace Folha.Presentation.Desktop.Reports.Inventario
{
    public partial class RelTblPrecoArmazem : DevExpress.XtraReports.UI.XtraReport
    {
        public RelTblPrecoArmazem(List<RelListagemArtigosViewModel> LtArtigos,string Armazem)
        {
            InitializeComponent();
            lbArmazem.Text = Armazem;
            objectDataSource1.DataSource = LtArtigos;
            xrSubreport1.ReportSource = new RelCabecalhoInterno();
        }

    }
}
