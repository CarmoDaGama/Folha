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
    public partial class frmCriteriosAvaliacaoTarifariosMulta : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmCriteriosAvaliacaoTarifariosMulta()
        {
            InitializeComponent();

        }
      

        private void btnVoltar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void btnCriterio_Click(object sender, EventArgs e)
        {
            new frmSelecionarCriteriosAvaliacao().ShowDialog();
        }

        private void btnTarifarioMulta_Click(object sender, EventArgs e)
        {
            new frmModalidadesMulta().ShowDialog();
        }
    }
}