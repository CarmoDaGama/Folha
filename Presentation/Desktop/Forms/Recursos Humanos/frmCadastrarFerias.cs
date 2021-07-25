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

namespace Folha.Presentation.Desktop.Separadores.Recursos_Humanos
{
    public partial class frmCadastrarFerias : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmCadastrarFerias()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            new frmBuscarFuncionarios().ShowDialog();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            new frmTiposFerias().ShowDialog();
        }
    }
}