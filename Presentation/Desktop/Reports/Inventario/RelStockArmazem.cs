using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Folha.Domain.ViewModels.Report;
using System.Collections.Generic;

namespace Folha.Presentation.Desktop.Reports.Inventario
{
    public partial class RelStockArmazem : DevExpress.XtraReports.UI.XtraReport
    {
        public RelStockArmazem(List<RelListagemArtigosViewModel> LtArtigosStock,string NomeRelatorio,string Armazem)
        {
            InitializeComponent();
            objectDataSource1.DataSource = LtArtigosStock;
            lbArmazem.Text = Armazem;
            xrSubreport1.ReportSource = new RelCabecalhoInterno();
            if (NomeRelatorio == "ApoioContagem") xrTblTitulo.Text = "Apoio à Contagem de Artigos";
            else xrTblTitulo.Text = "Controlo De Stock Por Armazém";
        }

    }
}
