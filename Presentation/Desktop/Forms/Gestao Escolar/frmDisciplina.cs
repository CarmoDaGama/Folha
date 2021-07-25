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
using Folha.Domain.Interfaces.Application.Escolar;
using Folha.Domain.Models.Escolar;

namespace Folha.Presentation.Desktop.Separadores.Gestao_Escolar
{
    public partial class frmDisciplina : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly IDisciplinaApp _DisciplinaApp;
        public frmDisciplina(IDisciplinaApp DisciplinaApp)
        {
            InitializeComponent();
            _DisciplinaApp = DisciplinaApp;


        }
        
        private void FormDisciplina_Load(object sender, EventArgs e)
        {
            gradeDisciplina.DataSource = _DisciplinaApp.Listar(null);
        }

        private void textEditF_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void gridControl2_Click(object sender, EventArgs e)
        {

        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSalvar_ItemClick(object sender, ItemClickEventArgs e)
        {
            _DisciplinaApp.addDisciplina(new Disciplina()
            {
                Descricao = txtDescricao.Text,
                Abreviatura=txtAbreviatura.Text
            });
           gradeDisciplina.DataSource = _DisciplinaApp.Listar(null);
        }

        private void txtProcurar_TextChanged(object sender, EventArgs e)
        {
            gradeDisciplina.DataSource = _DisciplinaApp.Listar(txtProcurar.Text);
        }
    }
}