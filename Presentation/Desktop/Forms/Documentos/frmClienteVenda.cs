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

namespace Folha.Presentation.Desktop.Forms.Documentos
{
    public partial class frmClienteVenda : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public string TipoRetorno { get; set; } = "Cancelado";
        public frmClienteVenda()
        {
            InitializeComponent();
        }
        public string DescricaoDeixarPendente()
        {
            ShowDialog();
            return TipoRetorno;
        }
        private void btnCancelar_ItemClick(object sender, ItemClickEventArgs e)
        {
            TipoRetorno = string.Empty;
            Close();
        }

        private void btnGravar_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Equals(txtDescricao.Text, string.Empty))
            {
                MessageBox.Show("Preencha o  campo descrição!", "MENSAGEM", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            TipoRetorno = txtDescricao.Text;
            Close();
        }
    }
}