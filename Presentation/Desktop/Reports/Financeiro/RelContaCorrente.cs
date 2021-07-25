using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Folha.Domain.ViewModels.Financeiro;
using Folha.Domain.ViewModels.Report;
using System.Collections.Generic;

namespace Folha.Presentation.Desktop.Reports.Financeiro
{
    public partial class RelContaCorrente : DevExpress.XtraReports.UI.XtraReport
    {
        double credito;
        double debito;
        double soma;
        public RelContaCorrente(List<FluxoCaixaViewModel> LtFluxo, DadosReportViewModel Dados)
        {
            InitializeComponent();

            lbEntidadeNome.Text = Dados.NomeEntidade;
            lbUsuarioNome.Text =Dados.Usuario;
            lbDataImprecaoRotolo.Text = "Data de Impressão " + DateTime.Now.ToShortDateString();


            lbfim.Text = Convert.ToDateTime(Dados.DataFim).ToShortDateString();
            lbinicio.Text = Convert.ToDateTime(Dados.DataInicio).ToShortDateString();

            credito = 0;
            debito = 0;
            for (int i = 0; i < LtFluxo.Count; i++)
            {
                LtFluxo[i].Data = Convert.ToDateTime(LtFluxo[i].Data).ToShortDateString();
               
                if (LtFluxo[i].Tipo == "CREDITO")
                    credito += Convert.ToDouble(LtFluxo[i].Valor);
                else if(LtFluxo[i].Tipo == "DEBITO")
                    debito+= Convert.ToDouble(LtFluxo[i].Valor);

                LtFluxo[i].Valor = Convert.ToDouble(LtFluxo[i].Valor).ToString("N2");
            }

            lbCredito.Text = credito.ToString("N2");
            lbDebito.Text = debito.ToString("N2");
            soma = credito - debito;
            lbSaldo.Text = soma.ToString("N2");
            objectDataSource1.DataSource = LtFluxo;
            xrSubreport1.ReportSource = new RelCabecalho();
        }

    }
}
