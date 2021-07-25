using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Folha.Domain.Helpers;
using Folha.Domain.Interfaces.Application.Documentos;
using Folha.Domain.ViewModels.Documentos;
using Folha.Driver.Framework.IOC;

namespace Folha.Presentation.Desktop.Separadores.Principal
{
    public partial class frmVerOperacoesPendentes : XtraForm
    {
        private readonly IDocumentosApp _documentosApp;

        private int IndexOperacao { get; set; } = -1;
        private List<PendenteViewModel> ListaPendentes { get; set; } = new List<PendenteViewModel>();

        public frmVerOperacoesPendentes(IDocumentosApp app)
        {
            InitializeComponent();
            _documentosApp = app;
        }


        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            IndexOperacao = UtilidadesGenericas.GetGridIndexCurrent(sender, MousePosition);
            var codOperacaoPendente = Convert.ToInt32(gridView1.GetRowCellValue(IndexOperacao, "codigo"));
            var pendente = ListaPendentes.Where(p => p.codigo == codOperacaoPendente).FirstOrDefault();
            IOC.InjectForm<frmTelaDocumento>().EfectuarOperacaoDocumento(pendente.APP, pendente.Estado);
        }
        private void carregarListaPendestes()
        {
            ListaPendentes = _documentosApp.CarregarDocumentosPendentes();
            gradeOperacoes.DataSource = ListaPendentes;
            if (ListaPendentes.Count > 0)
            {
                IndexOperacao = 0;
            }
        }
        private void frmVerOperacoesPendentes_Load(object sender, EventArgs e)
        {
            carregarListaPendestes();
        }

        private void btnAbrirOperacao_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
          
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            IndexOperacao = e.RowHandle;
        }

        private void btnActualizarLista_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        }

        private void btnActualizarLista_Click(object sender, EventArgs e)
        {
            carregarListaPendestes();

        }

        private void btnAbrirOperacao_Click(object sender, EventArgs e)
        {
            if (IndexOperacao < 0)
            {
                return;
            }
            IndexOperacao = UtilidadesGenericas.GetGridIndexCurrent(sender, MousePosition);
            var codOperacaoPendente = Convert.ToInt32(gridView1.GetRowCellValue(IndexOperacao, "codigo"));
            var pendente = ListaPendentes.Where(p => p.codigo == codOperacaoPendente).FirstOrDefault();
            var form = IOC.InjectForm<frmTelaDocumento>();
            form.EfectuarOperacaoDocumento(pendente.APP, pendente.Estado);
        }
    }
}