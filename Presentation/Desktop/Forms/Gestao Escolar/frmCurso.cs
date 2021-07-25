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
    public partial class frmCurso : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmCurso()
        {
            InitializeComponent();
            navigationFrame1.SelectedPage = navigationPage_Classe;
        }

        private void btnDadosEmpresa_Click(object sender, EventArgs e)
        {
            navigationFrame1.SelectedPage = navigationPage_Classe;
        }

        private void btnEmolumentos_Click(object sender, EventArgs e)
        {
            navigationFrame1.SelectedPage = navigationPage_Emulumentos;
        }

        private void btnDisciplinas_Click(object sender, EventArgs e)
        {
            navigationFrame1.SelectedPage = navigationPage_Disciplina;
        }

        private void btnAlunos_Click(object sender, EventArgs e)
        {
            navigationFrame1.SelectedPage = navigationPage_Alunos;
        }

        private void btnNovoClasse_Click(object sender, EventArgs e)
        {
            new frmCriteriosAvaliacaoTarifariosMulta().ShowDialog();
        }
    }
}