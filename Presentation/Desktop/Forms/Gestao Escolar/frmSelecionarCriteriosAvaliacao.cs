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

namespace Folha.Presentation.Desktop.Separadores.Gestao_Escolar
{
    public partial class frmSelecionarCriteriosAvaliacao : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmSelecionarCriteriosAvaliacao()
        {
            InitializeComponent();
            
        }

        private void btnVoltar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }
    }
}