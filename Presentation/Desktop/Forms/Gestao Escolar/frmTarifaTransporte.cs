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
using Folha.Presentation.Desktop.Classe;

namespace Folha.Presentation.Desktop.Separadores.Gestao_Escolar
{
    public partial class frmTarifaTransporte : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmTarifaTransporte()
        {
            InitializeComponent();

        }
      

        private void bbiNew_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void bbiEdit_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btnVoltar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void frmTarifaTransporte_Load(object sender, EventArgs e)
        {
            Controle.HabilitarBotao();
        }

        private void btnNovo_ItemClick(object sender, ItemClickEventArgs e)
        {
            Controle.HabilitarBotao(btnSalvar,btnSalvarFechar);
            Controle.HabilitarControle(txtDescricao, txtPrecoC, txtPrecoM);
        }
    }
}