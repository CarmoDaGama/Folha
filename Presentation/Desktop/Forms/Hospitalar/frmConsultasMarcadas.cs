using DevExpress.XtraBars;
using Folha.Domain.Interfaces.Application.Hospitalar;
using Folha.Domain.ViewModels.Hospitalar;
using Folha.Domain.Helpers;
using System;
using System.Collections.Generic;

namespace Folha.Presentation.Desktop.Forms.Hospitalar
{
    public partial class frmConsultasMarcadas : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly IConsultaHospitalarApp _ConsultaHospitalarApp;
        private bool Selecionado;

        private List<MarcacaoConsultaViewModel> ListaConsultas { get; set; }
        private int CodAtendimento { get; set; }
        private int IndexConsulta { get; set; }
        public frmConsultasMarcadas(IConsultaHospitalarApp ConsultaHospitalarApp)
        {
            InitializeComponent();
            _ConsultaHospitalarApp = ConsultaHospitalarApp;
        }

        public MarcacaoConsultaViewModel BuscarUmaConsultaMarcada(int codAtendimento)
        {
            CodAtendimento = codAtendimento;
            ShowDialog();
            if (UtilidadesGenericas.ListaNula(ListaConsultas) || IndexConsulta < 0 || !Selecionado)
            {
                return null;
            }
            return ListaConsultas[IndexConsulta];
        }
        private void CarregaConsultas()
        {
            gradeConsultas.DataSource = null;
            ListaConsultas = (List<MarcacaoConsultaViewModel>)_ConsultaHospitalarApp.ListConsultaMarcadas(CodAtendimento.ToString());
            gradeConsultas.DataSource = ListaConsultas;
            IndexConsulta = UtilidadesGenericas.ListaNula(ListaConsultas) ? -1 : 0;
        }
        private void frmConsultasMarcadas_Load(object sender, EventArgs e)
        {
            CarregaConsultas();
        }

        private void gridViewPacientes_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            IndexConsulta = e.RowHandle;
        }

        private void gridViewPacientes_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            IndexConsulta = e.RowHandle;
        }

        private void btnSelecionar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Selecionado = true;
            Close();
        }

        private void gridViewPacientes_DoubleClick(object sender, EventArgs e)
        {
            Selecionado = true;
            Close();
        }

        private void btnVoltar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void btnNovo_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
    }
}