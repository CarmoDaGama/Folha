using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Folha.Domain.ViewModels.Report;
using System.Collections.Generic;
using Folha.Domain.Helpers;

namespace Folha.Presentation.Desktop.Reports.Inventario
{
    public partial class RelGrafMovArtigos : DevExpress.XtraReports.UI.XtraReport
    {
        public RelGrafMovArtigos(List<RelMovArtigosViewModel>LtMovArtigo, string dtInicial, string dtFinal,string Armazem)
        {
            InitializeComponent();
            lbArmazem.Text = Armazem;
            lbinicio.Text = dtInicial;
            lbfim.Text = dtFinal;
            lbUsuario.Text = UtilidadesGenericas.UsuarioCodigo + " - " + UtilidadesGenericas.NomeUsuario;
            objectDataSource1.DataSource = LtMovArtigo;
            xrSubreport1.ReportSource = new RelCabecalhoInterno();
        }

    }
}
