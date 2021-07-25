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
using Folha.Presentation.Desktop.Classe;
using Folha.Domain.Models.Entidades;
using Folha.Domain.Interfaces.Application.Entidades;
using Folha.Domain.Enuns.Genericos;

namespace Folha.Presentation.Desktop.Separadores.Recursos_Humanos
{
    public partial class frmProfissaoFuncionario : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Profissao Profissao { get; set; }
        private readonly IProfissaoApp App;
        private List<Profissao> Profissoes { get; set; }
        public int Index { get; private set; } = -1;
        int Ativo = 0;
        public CRUD TipoOperacao { get; private set; }

        private void carregarDados()
        {
            Profissoes = App.Listar();
            Index = 0;
        }

        public frmProfissaoFuncionario(IProfissaoApp app)
        {
            InitializeComponent();
            App = app;
        }

        private void btnVoltar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        public Profissao GetProfissao()
        {
            buttonSelecionar.Visibility = BarItemVisibility.Always;
            ShowDialog();
            if (Profissao != (null) && Profissao.Codigo > 0)
            {
                return Profissao;
            }

            return new Profissao() { Descricao = "Nenhuma" };
        }

        private void buttonSelecionar_ItemClick(object sender, ItemClickEventArgs e)
        {

            if (Index < 0) { MessageBox.Show("Nenhum registro selecionado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            else
            {
                Profissao = Profissoes[Index];
                Close();
            }
        }

        private void frmProfissaoFuncionario_Load(object sender, EventArgs e)
        {
            carregarDados();
            gridControl1.DataSource = Profissoes;
        }
        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (btnNovo.Enabled!=false)
            {
                Index = e.RowHandle;
                Profissao = Profissoes[Index];
                txtDescricao.Text = Profissao.Descricao; Ativo = 0;
            }
            if (Ativo == 1)
            {
                Index = e.RowHandle;
                Profissao = Profissoes[Index];
                txtDescricao.Text = Profissao.Descricao;
            }
           
        }

        private void btnNovo_ItemClick(object sender, ItemClickEventArgs e)
        {
            Profissao = new Profissao();
            txtDescricao.Enabled = true;
            txtDescricao.Text = string.Empty;
            btnGravar.Enabled = true;
            btnNovo.Enabled = false;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            buttonSelecionar.Enabled = false;
            TipoOperacao = CRUD.Cadastro;

        }
        private void btnEditar_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Index > -1)
            {
                //Habilitacao = new Habilitacao();
                txtDescricao.Enabled = true;
                //txtDescricao.Text = string.Empty;
                btnGravar.Enabled = true;
                btnEditar.Enabled = false;
                btnNovo.Enabled = false;
                btnEliminar.Enabled = false;
                buttonSelecionar.Enabled = false;
                Ativo = 1;
                TipoOperacao = CRUD.Edição;
            }
            else
            {
                MessageBox.Show("Nenhum registro selecionado","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            
        }

        private void btnGravar_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (txtDescricao.Text.Equals(string.Empty))
            {
                MessageBox.Show("Preencha o campo Descrição!");
                return;
            }

            Profissao = new Profissao()
            {
                Codigo = Profissao.Codigo,
                Descricao = txtDescricao.Text
            };
            if (TipoOperacao == CRUD.Cadastro)
            {
                App.Insert(Profissao);
            }
            else
            {
                App.Update(Profissao);
            }
            frmProfissaoFuncionario_Load(sender, e);
            Profissao = new Profissao();
            txtDescricao.Enabled = false;
            txtDescricao.Text = string.Empty;
            btnGravar.Enabled = false;
            btnNovo.Enabled = true;
            btnEditar.Enabled = true;
            buttonSelecionar.Enabled = true;
            btnEliminar.Enabled = true;
        }

        private void btnEliminar_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Index < 0)
            {
                MessageBox.Show("Selecione um registro!");
                return;
            }
            if (temCertesa())
            {
                App.Delete(Profissao);
                MessageBox.Show("Registro Eliminado com sucesso!");
                frmProfissaoFuncionario_Load(sender, e);
            }
        }

        private bool temCertesa()
        {
            var result = MessageBox.Show(
                "Tem certesa que pretende" +
                " eleminar Este registro?",
                "QUSETÃO",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            return result == DialogResult.Yes;
        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }
    }
}