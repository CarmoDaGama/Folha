using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Folha.Domain.Interfaces.Application.Inventario;
using Folha.Domain.Models.Inventario;
using Folha.Domain.Helpers;
using Folha.Driver.Framework.IOC;
using System.Drawing;

using System.Collections.Generic;
using System.Windows.Forms;

namespace Folha.Presentation.Desktop.Forms.Armazens
{
    public partial class frmLotesArtigo : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly ILoteArtigoApp _lote;
        public int index;
        private int cod;
        public Lote lote { get; set; }
        public int Index { get; private set; } = -1;
        List<Lote> lista;
        int usuario = int.Parse(UtilidadesGenericas.UsuarioPerfil.ToString());

        public frmLotesArtigo(ILoteArtigoApp lote)
        {
            InitializeComponent();
            _lote = lote;
            Mostrar();
            Index = 0;
            Permicao();
        }
        #region Permicao de Acesso
        private void Permicao()
        {
            if (usuario != 1)
            {
                if (UtilidadesGenericas.TemAcesso("Inventario#Lote de Artigo#Criar") == false) { btnNovo.Enabled = false; }
                if (UtilidadesGenericas.TemAcesso("Inventario#Lote de Artigo#Eliminar") == false) { btnEliminar.Enabled = false; }
            }
        }
        #endregion
        public void Mostrar()
        {
            lista = (List<Lote>)_lote.Listar(null, false);
            GradeLote.DataSource = lista;

        }
        private void btnNovo_ItemClick(object sender, ItemClickEventArgs e)
        {
            UtilidadesGenericas.Busca.Codigo = string.Empty;
            IOC.InjectForm<frmLote>().Show();
            if (UtilidadesGenericas.Busca.Alterou == true) Mostrar();
        }

        private void gridLote_DoubleClick(object sender, System.EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(MousePosition);
            GridHitInfo info = view.CalcHitInfo(pt);
            UtilidadesGenericas.Busca.Codigo = gridLote.GetRowCellValue(info.RowHandle, "Codigo").ToString();
            UtilidadesGenericas.Busca.Alterou = false;
            var container = new SimpleInjector.Container();
            IOC.RegistrarInjecao(container);
            container.GetInstance<frmLote>().ShowDialog();
            if (UtilidadesGenericas.Busca.Alterou ) Mostrar();
        }

        private void btnselect_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Index < 0) return;
            lote = lista[Index];
            Close();
        }

        public Lote GetLote()
        {
            ShowDialog();
            if (lote != (null) && lote.Codigo > 0)
            {
                return lote;
            }
            
            return null;

        }

        private void gridLote_RowClick(object sender, RowClickEventArgs e)
        {
            cod = int.Parse(gridLote.GetRowCellValue(e.RowHandle, "Codigo").ToString());
            Index = e.RowHandle;
            lote = lista[Index];
        }

        private void btnFechar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();

        }
    }
}