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

namespace Folha.Presentation.Desktop.Separadores.Utilitarios_Configuracoes
{
    public partial class frmCopiaSegurança : DevExpress.XtraEditors.XtraForm
    {
        public frmCopiaSegurança()
        {
            InitializeComponent();
        }
        private void tileBar_SelectedItemChanged(object sender, TileItemEventArgs e)
        {
            //navigationFrame.SelectedPageIndex = tileBarGroupTables.Items.IndexOf(e.Item);
        }

        private void tileBar_Click(object sender, EventArgs e)
        {

        }

        private void employeesTileBarItem_ItemClick(object sender, TileItemEventArgs e)
        {

        }

        private void btnCanselar_ItemClick(object sender, TileItemEventArgs e)
        {
            Close();
        }
    }
}