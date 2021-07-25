using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Folha.Domain.ViewModels.Inventario;
using System.Collections.Generic;
using Folha.Domain.Models.Inventario;

namespace Folha.Presentation.Desktop.Reports.Inventario
{
    public partial class RelArmazens : DevExpress.XtraReports.UI.XtraReport
    {
        public RelArmazens(List<Armazens> dados)
        {
            InitializeComponent();
            objectDataSource1.DataSource = dados;
            xrSubreport1.ReportSource = new RelCabecalho();

        }

    }
}
