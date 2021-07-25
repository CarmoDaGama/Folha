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
using Folha.Domain.Helpers;

namespace Folha.Presentation.Desktop.SubFormularios
{
    public partial class frmDesconto : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmDesconto()
        {
            InitializeComponent();
        }

        private void btnFechar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void btnsalvar_ItemClick(object sender, ItemClickEventArgs e)
        {   UtilidadesGenericas.Busca.Desconto = decimal.Parse(txtDesconto.Text); }
    }
}