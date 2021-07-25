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
    public partial class frmCadastroContrato : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmCadastroContrato()
        {
            InitializeComponent();
        }
        private void buttonBuscarFuncionario_Click(object sender, EventArgs e)
        {
            new frmBuscarFuncionarios().ShowDialog();
        }

        private void buttonBuscarCategoria_Click(object sender, EventArgs e)
        {
            new frmBuscarCagos().ShowDialog();
        }
        private void buttonBunscarFuncao_Click(object sender, EventArgs e)
        {
            new frmFuncao().ShowDialog();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            new frmTurnos().ShowDialog();
        }
        private void simpleButton5_Click(object sender, EventArgs e)
        {
            new frmTipoContrato().ShowDialog();
        }
    }
}