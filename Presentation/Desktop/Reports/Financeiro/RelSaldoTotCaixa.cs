using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Folha.Domain.ViewModels.Report;
using System.Collections.Generic;

namespace Folha.Presentation.Desktop.Reports.Financeiro
{
    public partial class RelSaldoTotCaixa : DevExpress.XtraReports.UI.XtraReport
    {
        public RelSaldoTotCaixa(List<SaldoCaixaViewModel> LtSaldoCaixa)
        {
            InitializeComponent();
            objectDataSource1.DataSource = LtSaldoCaixa;
        }
    }
}
