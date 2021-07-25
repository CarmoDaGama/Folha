using System;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraBars.Ribbon;
using Folha.Domain.ViewModels.Principal;
using System.Collections.Generic;
using Folha.Domain.Interfaces.Application.Inteligente;
using System.Windows.Forms;
using DevExpress.XtraBars;
using Folha.Domain.Helpers;
using System.Linq;

namespace Folha.Presentation.Desktop.Forms.Principal
{
    public partial class frmInteligente : RibbonForm
    {
        private readonly IInteligenteApp _inteligenteApp;
        private string nomeCodigo;
        private string nomeDescricao;

        private int Index { get; set; }
        private List<InteligenteViewModel> Inteligentes { get; set; }
        private string NomeTabela { get; set; }
        private bool Inserir { get; set; } = true;
        private string TituloForm { get; set; }
        private bool Selected { get;  set; } = false;
        public int CodigoInteligente { get; private set; }

        public frmInteligente(IInteligenteApp app)
        {
            InitializeComponent();
            _inteligenteApp = app;
            Inteligentes = new List<InteligenteViewModel>();
        }
        public frmInteligente ShowList(string nomeTabela, string titulo)
        {
            NomeTabela = nomeTabela;
            TituloForm = titulo;

            return this;
        }
        public InteligenteViewModel GetSelecionado(string nomeTabela)
        {
            NomeTabela = nomeTabela;
            buttonSelecionar.Visibility = BarItemVisibility.Always;
            labelInfo.Visible = true;
            ShowDialog();
            if (UtilidadesGenericas.ListaNula(Inteligentes) || Index <= -1)
            {
                return null;
            }
            var intligente = Inteligentes.Where(i => i.Codigo == CodigoInteligente).FirstOrDefault();
            return intligente;
        }
        public InteligenteViewModel GetSelecionado(string nomeTabela, string tituloForm)
        {
            NomeTabela = nomeTabela;
            TituloForm = tituloForm;
            buttonSelecionar.Visibility = BarItemVisibility.Always;
            ShowDialog();
            if (UtilidadesGenericas.ListaNula(Inteligentes) || Index <= -1)
            {
                return null;
            }
            var inteligente = Inteligentes.Where(i => i.Codigo == CodigoInteligente).FirstOrDefault();
            return inteligente;
        }

        public Entity GetSelecionado<Entity>(string nomeTabela) where Entity : class, new()
        {
            NomeTabela = nomeTabela;
            var returnEntity = new Entity();
            buttonSelecionar.Visibility = BarItemVisibility.Always;
            ShowDialog();
            if (UtilidadesGenericas.ListaNula(Inteligentes) || Index <= -1)
            {
                return null;
            }
            var inteligente = Inteligentes.Where(i => i.Codigo == CodigoInteligente).FirstOrDefault();
            
            if (!isNull(returnEntity))
            {
                returnEntity.GetType().GetProperty(nomeCodigo).SetValue(returnEntity, inteligente.Codigo);
                returnEntity.GetType().GetProperty(nomeDescricao).SetValue(returnEntity, inteligente.Descricao);
            }
            return returnEntity;
        }
        public Entity GetSelecionado<Entity>(string nomeTabela, string tituloForm) where Entity : class, new()
        {
            TituloForm = tituloForm;
            return GetSelecionado<Entity>(nomeTabela);
        }


        private bool isNull<Entity>(Entity returnEntity) where Entity : class, new()
        {
            nomeCodigo = string.Empty;
            nomeDescricao = string.Empty;
            var tipoEntity = returnEntity.GetType();

            if (!Equals(tipoEntity.GetProperty("Codigo"), null))
            {
                nomeCodigo = "Codigo";
            }
            else if (!Equals(tipoEntity.GetProperty("codigo"), null))
            {
                nomeCodigo = "codigo";
            }

            if (!Equals(tipoEntity.GetProperty("Descricao"), null))
            {
                nomeDescricao = "Descricao";
            }
            else if (!Equals(tipoEntity.GetProperty("descricao"), null))
            {
                nomeDescricao = "descricao";
            }

            return string.IsNullOrEmpty(nomeCodigo) || string.IsNullOrEmpty(nomeDescricao);
        }

        private void gridView1_RowClick(object sender, RowClickEventArgs e)
        {
            Index = e.RowHandle;
            CodigoInteligente = Convert.ToInt16(gridView1.GetRowCellValue(Index, "Codigo"));
        }
        private void gridView1_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            Index = e.RowHandle;
            CodigoInteligente = Convert.ToInt16(gridView1.GetRowCellValue(Index, "Codigo"));
        }
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (buttonSelecionar.Visibility == BarItemVisibility.Always)
            {
                Close();
            }
            else
            {
                activarEditar();
            }
        }
        private void frmInteligente_Load(object sender, EventArgs e)
        {
           setTituloForm();
            panelSave.Visible = false;
            carregarListaInteligente();
            if (panelSave.Visible == true)
            {
                btnFechar.Caption = "Voltar";
            }
            else if (panelSave.Visible == false)
            {
                btnFechar.Caption = "Fechar";
            }
        }
        private void setTituloForm()
        {
            if (string.IsNullOrEmpty(TituloForm))
            {
                Text = NomeTabela.ToUpper();
            }
            else
            {
                Text = TituloForm/*.ToUpper()*/;
            }
        }

        private void btnNovo_ItemClick(object sender, ItemClickEventArgs e)
        {
            txtDescricao.Text = string.Empty;
            txtDescricao.Enabled = true;
            btnGravar.Enabled = true;
            btnNovo.Enabled = false;
            Inserir = true;
            panelSave.Visible = true;
            btnFechar.Caption = "Voltar";

            buttonSelecionar.Enabled = false;
            btnEliminar.Enabled = false;


        }
        private void btnEliminar_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gridView1.RowCount <= 0)
            {
               UtilidadesGenericas.MsgShow("AVISO", "Lista encontra-se sem registros", MessageBoxIcon.Information, MessageBoxButtons.OK);
                return;
            }
            else
            {
                if (linhaSelecionada() && temCerteza())
                {
                    var intligente = Inteligentes.Where(i => i.Codigo == CodigoInteligente).FirstOrDefault();
                    intligente.NomeTabela = NomeTabela;
                    _inteligenteApp.Delete(intligente);
                    carregarListaInteligente();
                }
            }
           
        }

        private bool linhaSelecionada()
        {
            if (Index <= -1)
            {
                UtilidadesGenericas.MsgShow(
                    "AVISO", 
                    "Selecione um registros", 
                    MessageBoxIcon.Information,  
                    MessageBoxButtons.OK
                );

                return false;
            }
            return true;
        }
        private void carregarListaInteligente()
        {
            Inteligentes = _inteligenteApp.GetAll(NomeTabela);
            gridControl1.DataSource = Inteligentes;
            if (gridView1.RowCount > 0)
            {
                CodigoInteligente = Convert.ToInt16(gridView1.GetRowCellValue(Index, "Codigo"));
            }
        }
        private void apresentaMsg(string messagem)
        {
            UtilidadesGenericas.MsgShow(
                "IMFORMAÇÃO",
                messagem,
                MessageBoxIcon.Information,
                MessageBoxButtons.OK
            );
        }
        private bool temCerteza()
        {
            var result = MessageBox.Show(
                "Tem certesa que pretende eliminar essa linha de registro!",
                "QUESTÃO",
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question
            );
            return result == DialogResult.Yes;
        }
        private bool NotRequesitos()
        {
            if (string.IsNullOrEmpty(txtDescricao.Text))
            {
                UtilidadesGenericas.MsgShow(
                    "AVISO",
                    "Preencha o campo descrição!", 
                    MessageBoxIcon.Information,  
                    MessageBoxButtons.OK
                );

                return true;
            }
            return false;
        }
        private void activarEditar()
        {
            if (linhaSelecionada())
            {
                var inteligente = Inteligentes.Where(i=> i.Codigo == CodigoInteligente).FirstOrDefault();
                txtDescricao.Text = inteligente.Descricao;
                txtDescricao.Enabled = true;
                btnGravar.Enabled = true;
                btnNovo.Enabled = false;
                Inserir = false;
                panelSave.Visible = true;
            }
        }

     
        private void btnGravar_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (NotRequesitos())
            {
                return;
            }
            Dictionary<string, object> dadoCampos = new Dictionary<string, object>();
            dadoCampos.Add("Descricao", txtDescricao.Text);
            if (Inserir)
            {
                var newInteligente = new InteligenteViewModel() {
                    NomeTabela = NomeTabela,
                    Descricao = txtDescricao.Text
                };
                if (_inteligenteApp.VerificarDuplicacaoDoRegistro(NomeTabela, dadoCampos))
                {
                    UtilidadesGenericas.MsgShow("Erro", "A " + txtDescricao.Text + " digitada já existe", MessageBoxIcon.Error, MessageBoxButtons.OK);

                    return;
                }
                _inteligenteApp.Insert(newInteligente);
            }
            else
            {
                var oldInteligente = new InteligenteViewModel() {
                    Codigo = CodigoInteligente,
                    NomeTabela = NomeTabela,
                    Descricao = txtDescricao.Text
                };
                if (_inteligenteApp.VerificarDuplicacaoDoRegistro(NomeTabela, dadoCampos))
                {
                    UtilidadesGenericas.MsgShow("Erro", "A " + txtDescricao.Text + " digitada já existe", MessageBoxIcon.Error, MessageBoxButtons.OK);

                    return;
                }
                _inteligenteApp.Update(oldInteligente);
            }
            txtDescricao.Text = string.Empty;
            txtDescricao.Enabled = false;
            btnGravar.Enabled = false;
            btnNovo.Enabled = true;
            panelSave.Visible = false;
            buttonSelecionar.Enabled = true;
            btnEliminar.Enabled = true;
            carregarListaInteligente();
        }
        private void buttonSelecionar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Selected = true;
            Close();
        }

        private void btnCloser_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (panelSave.Visible == true)
            {
                btnFechar.Caption = "Voltar";
                panelSave.Visible = false;
                btnNovo.Enabled = true;
                btnGravar.Enabled = false;

                buttonSelecionar.Enabled = true;
                btnEliminar.Enabled = true;
            }
            else if (panelSave.Visible == false)
            {
                btnFechar.Caption = "Fechar";
                btnNovo.Enabled = true;
                Index = -1;
                Close();
            }

        }

        private void frmInteligente_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Selected)
            {
                Index = -1;
            }
        }

        private void barButtonItem13_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
    }
}