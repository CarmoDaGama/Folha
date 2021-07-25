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
    public partial class frmProfessoresDados : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmProfessoresDados()
        {
            InitializeComponent();
            navigationFrame1.SelectedPage = navigationPage_DadosGerais;
        }

        private void btnVoltar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void btnDadosGerais_Click(object sender, EventArgs e)
        {
            navigationFrame1.SelectedPage = navigationPage_DadosGerais;
        }

        private void btnDisciplinas_Click(object sender, EventArgs e)
        {
            navigationFrame1.SelectedPage = navigationPage_Disciplinas;
        }

        private void btnTurmas_Click(object sender, EventArgs e)
        {
            navigationFrame1.SelectedPage = navigationPage_Turmas;
        }

        private void btnHorario_Click(object sender, EventArgs e)
        {
            navigationFrame1.SelectedPage = navigationPage_Horarios;
        }

        private void btnNovaDisciplina_Click(object sender, EventArgs e)
        {
            new frmDisciplinasDados().ShowDialog();
        }
    }
}