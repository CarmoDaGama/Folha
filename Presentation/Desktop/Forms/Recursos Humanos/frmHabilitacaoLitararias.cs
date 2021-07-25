using DevExpress.XtraBars;
using Folha.Presentation.Desktop.Classe;
using Folha.Domain.Models.Entidades;
using DevExpress.XtraBars.Ribbon;
using Folha.Domain.Interfaces.Application.Entidades;
using System.Collections.Generic;
using Folha.Domain.Enuns.Genericos;
using System.Windows.Forms;
using System;

namespace Folha.Presentation.Desktop.Separadores.Recursos_Humanos
{
    public partial class frmHabilitacaoLitararias : RibbonForm
    {
        public Habilitacoes Habilitacao { get; set; }
        private readonly IHabilitacaoApp App;
        private List<Habilitacoes> Habilitacoes { get; set; }
        public int Index { get; private set; } = -1;
        public CRUD TipoOperacao { get; private set; }
        int Ativo = 0;
        public frmHabilitacaoLitararias(IHabilitacaoApp app)
        {
            InitializeComponent();
            App = app;
        }

        private void carregarDados()
        {
            Habilitacoes = App.Listar();
            Index = 0;
        }


        private void btnVoltar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }


        public Habilitacoes GetHabilitacao()
        {
            buttonSelecionar.Visibility = BarItemVisibility.Always;
            ShowDialog();
            if (Habilitacao != (null) && Habilitacao.Codigo > 0 )
            {
                return Habilitacao;
            }

            return new Habilitacoes() { Descricao = "Nenhuma" };
        }

        private void frmHabilitacaoLitararias_Load(object sender, System.EventArgs e)
        {
            carregarDados();
            gridControl1.DataSource = Habilitacoes;

        }

        private void buttonSelecionar_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Index < 0) return;

            Habilitacao = Habilitacoes[Index];
            Close();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (btnNovo.Enabled != false)
            {
                Index = e.RowHandle;
                Habilitacao = Habilitacoes[Index];
                txtDescricao.Text = Habilitacao.Descricao; Ativo = 0;
            }
            if (Ativo == 1)
            {
                Index = e.RowHandle;
                Habilitacao = Habilitacoes[Index];
                txtDescricao.Text = Habilitacao.Descricao;
            }
        }

        private void btnNovo_ItemClick(object sender, ItemClickEventArgs e)
        {
            Habilitacao = new Habilitacoes();
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

        private void btnGravar_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (txtDescricao.Text.Equals(string.Empty))
            {
                MessageBox.Show("Preencha o campo Descrição!");
                return;
            }

            Habilitacao = new Habilitacoes() {
                Codigo = Habilitacao.Codigo,
                Descricao = txtDescricao.Text
            };
            if (TipoOperacao == CRUD.Cadastro)
            {
                App.Insert(Habilitacao);
            }
            else
            {
                App.Update(Habilitacao);
            }
            frmHabilitacaoLitararias_Load(sender, e);
            Habilitacao = new Habilitacoes();
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
                App.Delete(Habilitacao);
                frmHabilitacaoLitararias_Load(sender, e);
            }
        }

        private bool temCertesa()
        {
            var result = MessageBox.Show(
                "Tem certesa que pretendes" +
                " eleminar Este registro?", 
                "QUSETÃO",
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question
            );
            return result == DialogResult.Yes;
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
    }
}