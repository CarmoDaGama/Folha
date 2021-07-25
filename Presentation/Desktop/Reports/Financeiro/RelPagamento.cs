using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Folha.Domain.ViewModels.Financeiro;
using System.Collections.Generic;
using Folha.Domain.Helpers;

namespace Folha.Presentation.Desktop.Reports.Financeiro
{
    public partial class RelPagamento : XtraReport
    {
        decimal Total = 0;
        public RelPagamento(List<NotaPagamentoViewModel> LtNotaPagamento)
        {
            InitializeComponent();
            objectDataSource1.DataSource = LtNotaPagamento;
            for (int i = 0; i < LtNotaPagamento.Count; i++)
            {
                Total += Convert.ToDecimal(LtNotaPagamento[i].Valor);
            }
            lblTotal.Text = Total.ToString("N3");
            lblValorExtenso.Text = UtilidadesGenericas.Decimal_Extenso(Total);
        }

    }
}
