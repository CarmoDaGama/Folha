using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using Folha.Domain.Interfaces.Application.Genericos;
using Folha.Driver.Framework.IOC;
using Folha.Domain.Models.Genericos;
using Folha.Domain.ViewModels.Genericos;
using Folha.Domain.Helpers;

namespace Folha.Presentation.Desktop.Forms.Geral
{
    public partial class frmSubcategorias : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly ISubCategoriaApp _SubCategoriaApp;
       public  SubCategoriaViewModel DadosSubCategoria { get; set; } = null;
        public short CodSubCategoria { get; private set; }

        List<SubCategoriaViewModel> LtSubCategoria;
        private int indexGrid=-1;

        public frmSubcategorias(ISubCategoriaApp SubCategoriaApp)
        {
            InitializeComponent();
            _SubCategoriaApp = SubCategoriaApp;
            DadosSubCategoria = new SubCategoriaViewModel() { Codigo = 0, SubCategoria = "Nenhuma" };
        }

        private void frmSubcategoria_Load(object sender, EventArgs e)
        {
            if (!btnSelecionar.Enabled) btnSelecionar.Visibility = BarItemVisibility.Never;
            else { this.MaximizeBox = false; this.MinimizeBox = false; }
            CarregarSubCategorias();
        }

        private void CarregarSubCategorias()
        {
            LtSubCategoria = (List<SubCategoriaViewModel>)_SubCategoriaApp.Listar(null);
            gradeSubCategoria.DataSource = LtSubCategoria;
            indexGrid = UtilidadesGenericas.ListaNula(LtSubCategoria) ? -1 : 0;
        }

        private void btnNovo_ItemClick(object sender, ItemClickEventArgs e)
        {
            IOC.InjectForm<frmSubCategoria>().ShowDialog();
            if (UtilidadesGenericas.Busca.Alterou)
            {
                CarregarSubCategorias();
            }
    }

        private void gridSubCategoria_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            indexGrid = e.RowHandle;
            CodSubCategoria = Convert.ToInt16(gridSubCategoria.GetRowCellValue(indexGrid, "Codigo"));
        }

        private void btnSelecionar_ItemClick(object sender, ItemClickEventArgs e)
        {
            SelecionarSubCategoria();
        }

        private void SelecionarSubCategoria()
        {
            if (gridSubCategoria.RowCount == 0 || UtilidadesGenericas.ListaNula(LtSubCategoria)) return;
            var sub = LtSubCategoria.Where(s => s.Codigo == CodSubCategoria).FirstOrDefault();
            try
            {
                if (indexGrid == -1)
                    DadosSubCategoria = new SubCategoriaViewModel()
                    {
                        Codigo = 0,
                        SubCategoria = sub.SubCategoria,
                        Categoria = sub.Categoria
                    };
                else
                {
                    DadosSubCategoria = null;
                    DadosSubCategoria = sub;
                    //DadosSubCategoria.Codigo = LtSubCategoria[indexGrid].Codigo;
                    //DadosSubCategoria.SubCategoria = LtSubCategoria[indexGrid].SubCategoria;
                    //DadosSubCategoria.Categoria = LtSubCategoria[indexGrid].Categoria;
                }
            }
            catch (Exception) { }
            Close();
        }

        private void btnEliminar_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gridSubCategoria.RowCount > 0)
            {
                if (UtilidadesGenericas.TemCestezaEliminarRegistro())
                {
                }
            }
            else
            {
                UtilidadesGenericas.MsgShow("Não tem registro para eliminar!");
            }
        }

        private void btnEditar_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btnFechar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void gridSubCategoria_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            indexGrid = e.RowHandle;
        }

        private void barButtonItem13_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
    }
}