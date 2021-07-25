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
using Folha.Presentation.Desktop.Separadores.Entidades;

namespace Folha.Presentation.Desktop.Separadores.Principal
{
    public partial class frmVerFornecedores : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmVerFornecedores()
        {
            InitializeComponent();
            
        }
        void bbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }

        private void btnEntidade_Click(object sender, EventArgs e)
        {
            //new frmEntidade().ShowDialog();
        }
    }
}