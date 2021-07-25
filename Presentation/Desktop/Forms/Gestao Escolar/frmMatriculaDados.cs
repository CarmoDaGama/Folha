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
using Folha.Driver.Framework.IOC;
using Folha.Presentation.Desktop.Forms.Principal;
using Folha.Domain.Models.Escolar;

namespace Folha.Presentation.Desktop.Separadores.Gestao_Escolar
{
    public partial class frmMatriculaDados : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private int _codAluno;
        private int codCurso;

        public frmMatriculaDados()
        {
            InitializeComponent();
            navigationFrame1.SelectedPage = navigationPage_Dados;
        }

        private void btnDadosMatricula_Click(object sender, EventArgs e)
        {
            navigationFrame1.SelectedPage = navigationPage_Dados;
        }

        private void btnHistorico_Click(object sender, EventArgs e)
        {
            navigationFrame1.SelectedPage = navigationPage_Historico;
        }

        private void btnNome_Click(object sender, EventArgs e)
        {
            var Aluno = IOC.InjectForm<frmAlunos>().GetAluno();
            if(Aluno!=null)
            {
                txtAluno.Text = Aluno.Nome;
                _codAluno = Aluno.Codigo;
                txtCodAluno.Text = Aluno.Codigo.ToString();
            }
        }

        private void btnCurso_Click(object sender, EventArgs e)
        {
            var cursos= IOC.InjectForm<frmInteligente>().GetSelecionado<Cursos>("Cursos", "Cursos");
            if (Equals(cursos, null))
            {
                return;
            }
            codCurso = cursos.Codigo;
            txtCurso.Text = cursos.Descricao;
        }

        private void frmMatriculaDados_Load(object sender, EventArgs e)
        {
           timeData.Text = DateTime.Now.ToShortDateString();
           timeData.Properties.MaxValue = DateTime.Now;
        }

        private void btnVoltar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }
    }
}