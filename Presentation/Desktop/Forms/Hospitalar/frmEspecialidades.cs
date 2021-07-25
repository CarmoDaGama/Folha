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
using Folha.Domain.Interfaces.Application.Hospitalar;
using Folha.Domain.Models.Hospitalar;

namespace Folha.Presentation.Desktop.Forms.Hospitalar
{
    public partial class frmEspecialidades : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly IEspecialidadesApp _EspecialidadesApp;
        private int index=-1;
        public Especialidades Especialidades { get; set; } = null;
        public frmEspecialidades(IEspecialidadesApp EspecialidadesApp)
        {
            InitializeComponent();
            _EspecialidadesApp = EspecialidadesApp;
            Especialidades = new Especialidades { Codigo = 0, Descricao = "Nenhuma" };


        }

        private void frmEspecialidades_Load(object sender, EventArgs e)
        {
            if (!btnSelecionar.Enabled) btnSelecionar.Visibility = BarItemVisibility.Never;
            else { this.MaximizeBox = false; this.MinimizeBox = false; }

            gradeEspecialidades.DataSource = _EspecialidadesApp.Listar(null);
        }

       

        private void gridEspecialidades_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            index = e.RowHandle;
        }

        private void btnSelecionar_ItemClick(object sender, ItemClickEventArgs e)
        {
            
            if (gridEspecialidades.RowCount == 0) return;
            
            try
            {
                if (index == -1) Especialidades = new Especialidades { Codigo = 0, Descricao = "Nenhuma" };
                else
                {
                Especialidades.Codigo=int.Parse( gridEspecialidades.GetRowCellValue(index, "Codigo").ToString());
                Especialidades.Descricao= gridEspecialidades.GetRowCellValue(index, "Descricao").ToString();
                }
            }
            catch (Exception) { }
            Close();
        }

        private void btnNovo_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btnVoltar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void btnEliminar_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btnEditar_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void gridEspecialidades_DoubleClick(object sender, EventArgs e)
        {
            if (gridEspecialidades.RowCount == 0) return;

            try
            {
                if (index == -1) Especialidades = new Especialidades { Codigo = 0, Descricao = "Nenhuma" };
                else
                {
                    Especialidades.Codigo = int.Parse(gridEspecialidades.GetRowCellValue(index, "Codigo").ToString());
                    Especialidades.Descricao = gridEspecialidades.GetRowCellValue(index, "Descricao").ToString();
                }
            }
            catch (Exception) { }
            Close();
        }
    }
}