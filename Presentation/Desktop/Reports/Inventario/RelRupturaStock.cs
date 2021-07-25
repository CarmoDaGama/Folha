using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Folha.Domain.ViewModels.Report;
using System.Collections.Generic;

namespace Folha.Presentation.Desktop.Reports.Inventario
{
    public partial class RelRupturaStock : DevExpress.XtraReports.UI.XtraReport
    {
        public RelRupturaStock(List<RelListagemArtigosViewModel> LtRupturaStock,string Armazem)
        {
            InitializeComponent();
            lbArmazem.Text = Armazem;
            objectDataSource1.DataSource = LtRupturaStock;
            xrSubreport1.ReportSource = new RelCabecalhoInterno();
        }

    }
}
