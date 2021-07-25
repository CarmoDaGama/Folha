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
using Folha.Presentation.Desktop.Separadores.Entidades;

namespace Folha.Presentation.Desktop.Separadores.Principal
{
    public partial class frmVerRelatorioEntidades : DevExpress.XtraEditors.XtraForm
    {
        public frmVerRelatorioEntidades()
        {
            InitializeComponent();
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnListaEntidades_Click(object sender, EventArgs e)
        {
            navigationFrame1.SelectedPage = Listaentidade;

        }

        private void btnListaContactos_Click(object sender, EventArgs e)
        {
            navigationFrame1.SelectedPage = listaentidae;

        }

        private void btnLitaDocumetos_Click(object sender, EventArgs e)
        {
            navigationFrame1.SelectedPage = listaentidae;

        }

        private void btnContaBancaria_Click(object sender, EventArgs e)
        {
            navigationFrame1.SelectedPage = listaentidae;

        }

        private void btnEntidade_Click(object sender, EventArgs e)
        {
            //new frmEntidadeBusca().ShowDialog();
        }
    }
}