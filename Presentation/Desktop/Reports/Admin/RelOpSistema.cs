using Folha.Domain.Models.Empresa;
using Folha.Domain.ViewModels.Sistema;
using System;
using System.Collections.Generic;
namespace Folha.Presentation.Desktop.Reports.Admin
{
    public partial class RelOpSistema : DevExpress.XtraReports.UI.XtraReport
    {
        public RelOpSistema(List<OperacoesViewModel> dados, Empresa cabecalhoEmpresa)
        {
            InitializeComponent();
            lbDataImprecaoRotolo.Text = "Data de Impressão " + DateTime.Now.ToShortDateString();

            objectDataSource1.DataSource = dados;
          xrSubreport1.ReportSource = new RelCabecalho();
        }
    }
}
