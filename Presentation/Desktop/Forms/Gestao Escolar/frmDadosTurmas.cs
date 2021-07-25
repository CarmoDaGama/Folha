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
    public partial class frmDadosTurmas : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmDadosTurmas()
        {
            InitializeComponent();
            navigationFrame1.SelectedPage = navigationPage_DadosGerais;

        }

        private void btnDadoGerais_Click(object sender, EventArgs e)
        {
            navigationFrame1.SelectedPage = navigationPage_DadosGerais;
        }

        private void btnProfessores_Click(object sender, EventArgs e)
        {
            navigationFrame1.SelectedPage = navigationPage_Professores;
        }

        private void btnHorario_Click(object sender, EventArgs e)
        {
            navigationFrame1.SelectedPage = navigationPage_Horario;
        }

        private void btnAlunos_Click(object sender, EventArgs e)
        {
            navigationFrame1.SelectedPage = navigationPage_Alunos;
        }

        private void btnCurso_Click(object sender, EventArgs e)
        {
            //new frmCursos().ShowDialog();
        }

        private void btnSala_Click(object sender, EventArgs e)
        {
            //new frmSalas().ShowDialog();
        }

        private void btnNovoProfessor_Click(object sender, EventArgs e)
        {
            new frmProfessores().ShowDialog();
        }

        private void navigationPage_Professores_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}