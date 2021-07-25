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
using Folha.Domain.Models.Inventario;
using Folha.Domain.Interfaces.Application.Inventario;

namespace Folha.Presentation.Desktop.Forms.Armazens
{
    public partial class frmMotivoIsencao : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly IMotivoIsencaoApp _motivoIsencaoApp;
        public int index;
        private int cod;
        List<MotivoIsencao> lista;
        public MotivoIsencao MotivoIsencao { get; set; }
        public int Index { get; private set; } = -1;
        public frmMotivoIsencao(IMotivoIsencaoApp motivoIsencaoApp)
        {
            InitializeComponent();
            _motivoIsencaoApp = motivoIsencaoApp;
            Index = 0;
        }

        public void Mostrar()
        {
            lista = (List<MotivoIsencao>)_motivoIsencaoApp.Listar(null, false);
            GradeMotivoIsencao.DataSource =lista;
        }

        private void btnselect_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Index < 0) return;
            MotivoIsencao = lista[Index];
            Close();
        }
        public MotivoIsencao GetMotivoIsencao()
        {
            ShowDialog();
            if (MotivoIsencao != (null) && MotivoIsencao.Codigo > 0)
            {
                return MotivoIsencao;
            }
            else
            {
                return null;
            }
        }
        private void gridMotivoIsencao_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
              Index = e.RowHandle;
              MotivoIsencao = lista[Index];
        }
        private void frmMotivoIsencao_Load(object sender, EventArgs e)
        {
            Mostrar();
        }

        private void gridMotivoIsencao_DoubleClick(object sender, EventArgs e)
        {
            if (btnselect.Visibility == BarItemVisibility.Always)
            {
                if (Index < 0) return;
                MotivoIsencao = lista[Index];
                Close();
            }
            
        }
    }
}