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
    public partial class frmContratoTrabalho : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmContratoTrabalho()
        {
            InitializeComponent();
        }
        private void buttonNovoContrato_ItemClick(object sender, ItemClickEventArgs e)
        {
            new frmCadastroContrato().ShowDialog();
        }
    }
}