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

namespace Folha.Presentation.Desktop.Separadores.Recursos_Humanos
{
    public partial class frmDiario : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmDiario()
        {
            InitializeComponent();
        }

        private void buttonRegistroColectivo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new frmRegistroColectivo().ShowDialog();
        }
    }
}