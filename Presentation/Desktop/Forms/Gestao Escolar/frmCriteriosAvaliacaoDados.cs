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
    public partial class frmCriteriosAvaliacaoDados : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmCriteriosAvaliacaoDados()
        {
            InitializeComponent();
            navigationFrame1.SelectedPage = navigationPage_DadosGerais;
        }

        private void btnDados_Click(object sender, EventArgs e)
        {
            navigationFrame1.SelectedPage = navigationPage_DadosGerais;
        }

        private void btnDisciplinas_Click(object sender, EventArgs e)
        {
            navigationFrame1.SelectedPage = navigationPage_DisciplinasChaves;
        }

        private void btnProvas_Click(object sender, EventArgs e)
        {
            navigationFrame1.SelectedPage = navigationPage_Provas;
        }

        private void btnNovos_Click(object sender, EventArgs e)
        {
            //new frmDisciplina().ShowDialog();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            new frmAddProvas().ShowDialog();
        }

        private void navigationPage_DisciplinasChaves_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}