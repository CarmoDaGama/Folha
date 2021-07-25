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
    public partial class frmVerMatriculasConfirmacoes : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmVerMatriculasConfirmacoes()
        {
            InitializeComponent();
            
        }

        private void btnNovoAluno_ItemClick(object sender, ItemClickEventArgs e)
        {
            new frmMatriculaDados().ShowDialog();
        }
    }
}