using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Folha.Domain.ViewModels.Report;
using System.Collections.Generic;

namespace Folha.Presentation.Desktop.Reports.Inventario
{
    public partial class RelMovArtigo : DevExpress.XtraReports.UI.XtraReport
    {
        public RelMovArtigo(List<RelMovArtigosViewModel> LtMovArtigo, string dtInicial, string dtFinal,string Armazem)
        {
            InitializeComponent();
            objectDataSource1.DataSource = LtMovArtigo;
            lbinicio.Text = dtInicial;
            lbfim.Text = dtFinal;
            lbArmazem.Text = Armazem;
            xrSubreport1.ReportSource = new RelCabecalhoInterno();
        }

    }
}
