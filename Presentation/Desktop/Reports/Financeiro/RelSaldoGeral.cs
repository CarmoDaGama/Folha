using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Folha.Domain.ViewModels.Report;
using System.Collections.Generic;

namespace Folha.Presentation.Desktop.Reports.Financeiro
{
    public partial class RelSaldoGeral : DevExpress.XtraReports.UI.XtraReport
    {
        public RelSaldoGeral(List<SaldoCaixaViewModel> LtSaldoCaixa, List<SaldoBancoViewModel> LtSaldoBanco, DadosReportViewModel Dados)
        {
            InitializeComponent();

            lbUsuario.Text = Dados.Usuario;
            lbinicio.Text = Dados.DataInicio.ToShortDateString();
            lbfim.Text = Dados.DataFim.ToShortDateString();
            if (Dados.Usuario == null) { lbUsuario.Text = "Não Selecionado"; }

            objectDataSource1.DataSource = LtSaldoCaixa;
            objectDataSource2.DataSource = LtSaldoBanco;
            xrSubreport2.ReportSource = new RelSaldoTotCaixa(LtSaldoCaixa);
            xrSubreport1.ReportSource = new RelCabecalhoInterno();
        }

    }
}
