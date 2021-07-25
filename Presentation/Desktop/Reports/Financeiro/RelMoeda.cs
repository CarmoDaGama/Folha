using Folha.Domain.ViewModels.Financeiro;
using System.Collections.Generic;

namespace Folha.Presentation.Desktop.Reports.Financeiro
{
    public partial class RelMoeda : DevExpress.XtraReports.UI.XtraReport
    {
        public RelMoeda(List<MostraMoedasViewModel> dados)
        {
            InitializeComponent();
            for (int i = 0; i < dados.Count; i++)
            {
                if (dados[i].Padrao == false)
                    dados[i].PadraoStr = "Não";
                else
                    dados[i].PadraoStr = "Sim";
            }
            objectDataSource1.DataSource = dados;
            xrSubreport1.ReportSource = new RelCabecalho();
        }

    }
}
