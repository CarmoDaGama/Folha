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
using DevExpress.XtraBars;
using System.ComponentModel.DataAnnotations;

namespace Folha.Presentation.Desktop.Separadores.Notificacoes
{
    public partial class frmApoioContagem : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmApoioContagem()
        {
            InitializeComponent();
           
        }
        private void btnFechar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void gridControl2_Click(object sender, EventArgs e)
        {

        }
    }
}