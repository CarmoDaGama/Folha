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

namespace Folha.Presentation.Desktop.Separadores.Gestao_Escolar
{
    public partial class frmProfessores : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmProfessores()
        {
            InitializeComponent();
           
        }

        private void btnNome_Click(object sender, EventArgs e)
        {
            //new frmEntidadeBusca().ShowDialog();
        }

        private void btnVoltar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }
    }
}