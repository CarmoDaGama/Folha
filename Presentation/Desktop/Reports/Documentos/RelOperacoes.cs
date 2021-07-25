using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Folha.Domain.ViewModels.Report;
using System.Collections.Generic;

namespace Folha.Presentation.Desktop.Reports.Documentos
{
    public partial class RelOperacoes : DevExpress.XtraReports.UI.XtraReport
    {
        public RelOperacoes(List<RelOpercoesViewModel> LtOperacoes, DadosReportViewModel Dados)
        {
            InitializeComponent();
            xrCellTitulo.Text = Dados.Titulo;
            objectDataSource1.DataSource = LtOperacoes;
            double TotCredito = 0;
            double TotDebito = 0;
            double Tot = 0;
            for (int i = 0; i < LtOperacoes.Count; i++)
            {
                if (LtOperacoes[i].Tipo == "CREDITO")
                    TotCredito += LtOperacoes[i].Total;
                else if (LtOperacoes[i].Tipo == "DEBITO")
                    TotDebito += LtOperacoes[i].Total;
            }
            Tot = TotCredito-TotDebito;
            lbTotCredito.Text= TotCredito.ToString("N2");
            lbTotDebito.Text=TotDebito.ToString("N2");
            lbSaldo.Text = Tot.ToString("N2");

            lbUsuario.Text =  Dados.Usuario;
            lbinicio.Text =  Dados.DataInicio.ToShortDateString();
            lbfim.Text= Dados.DataFim.ToShortDateString();
            lbCliente.Text =  Dados.Cliente;
            lbDataImprecaoRotolo.Text = "Data Impressão " + DateTime.Now.ToShortDateString();

            xrSubreport1.ReportSource = new RelCabecalho();
        }

    }
}
