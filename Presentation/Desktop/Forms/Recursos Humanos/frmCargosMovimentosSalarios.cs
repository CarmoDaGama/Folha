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
    public partial class frmCargosMovimentosSalarios : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmCargosMovimentosSalarios()
        {
            InitializeComponent();
        }

        private void buttonNovaCategoria_ItemClick(object sender, ItemClickEventArgs e)
        {
            new frmCastroCategoriaFuncionario().ShowDialog();
        }
    }
}