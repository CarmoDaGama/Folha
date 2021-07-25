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
using DevExpress.XtraGrid.Views.Grid;
using Folha.Domain.Interfaces.Application.Sistema;
using Folha.Domain.Enuns.Genericos;
using Folha.Domain.Helpers;
using Folha.Domain.Models.Sistema;
using Folha.Domain.ViewModels.Sistema;
using Folha.Presentation.Desktop.Forms.Apresenta_Doc;

namespace Folha.Presentation.Desktop.Separadores.Utilitarios_Configuracoes
{
    public partial class frmOpSistema : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly IOperacoesApp _operacoesApp;
        private List<OperacoesViewModel> listOperacoes;

        private List<Operacoes> lista;



        public CRUD Operacao { get; set; }
        public int IndexOperacao { get; private set; }

        public frmOpSistema(IOperacoesApp operacoesApp)
        {
            InitializeComponent();
            _operacoesApp = operacoesApp;
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void carregarOperacoes()
        {
            listOperacoes = _operacoesApp.GetAll();
        }
        private void btnFechar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void frmOpSistema_Load(object sender, EventArgs e)
        {
            carregarOperacoes();
            gradeOperacoes.DataSource = listOperacoes;
        }

        private void btnNovo_ItemClick(object sender, ItemClickEventArgs e)
        {
            Operacao = CRUD.Cadastro;
            operar(true);
        }
        private void operar(bool versor)
        {
            groupControlDadosOperacao.Visible = versor;
            btnNovo.Enabled = !versor;
            btnEditar.Enabled = !versor;
            btnSalvar.Enabled = versor;
            btnSalvarFechar.Enabled = versor;
            btnEliminar.Enabled = !versor;
            UtilidadesGenericas.ClearComponents(groupControlDadosOperacao.Controls);
        }

        private void gridOperacoes_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            IndexOperacao = e.RowHandle;
        }

        private void gridOperacoes_RowClick(object sender, RowClickEventArgs e)
        {
            IndexOperacao = e.RowHandle;
        }

        private void gridOperacoes_DoubleClick(object sender, EventArgs e)
        {
            Operacao = CRUD.Edição;
            operar(true);
            popularCampos();
        }

        private void popularCampos()
        {
            var codOperacao = Convert.ToInt16(gridOperacoes.GetRowCellValue(IndexOperacao, "codigo"));
            var operacao = listOperacoes.Where(op => op.codigo == codOperacao).FirstOrDefault();
            txtCod.Text = operacao.codigo.ToString();
            txtNome.Text = operacao.Nome;
            cboEntidade.SelectedItem = operacao.Entidade;
            cboMFinanceiro.SelectedItem = operacao.MovFin;
            cboMStock.SelectedItem = operacao.MovStk;
            rtxtObs.Text = operacao.APP;
        }

        private void btnSalvar_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (validarCampos())
            {
                if (ifNotDuplicate())
                {
                    if (Operacao == CRUD.Cadastro)
                    {
                        _operacoesApp.Insert(getNewOperacao());
                    }
                    else if (Operacao == CRUD.Edição)
                    {
                        _operacoesApp.Update(getOldOperacao());
                    }
                    operar(false);
                    frmOpSistema_Load(sender, e);
                }
                else
                {
                    showMsg("O nome inserido já exite");
                }
            }
        }

        private bool ifNotDuplicate()
        {
            if (Operacao == CRUD.Edição)
                return true;
            OperacoesViewModel op = new OperacoesViewModel();
            Dictionary<string, object> dicionario = new Dictionary<string, object>();
            dicionario.Add("Nome", txtNome.Text);
            dicionario.Add("APP", rtxtObs.Text);
            //var operation = listOperacoes.Where(o => o.Nome == txtNome.Text).FirstOrDefault();

            return !_operacoesApp.ContemDuplicacao("Operacoes", dicionario); 
        }

        private OperacoesViewModel getOldOperacao()
        {
            return new OperacoesViewModel()
            {
                codigo = Convert.ToInt32(txtCod.Text),
                APP = rtxtObs.Text,
                Entidade = cboEntidade.SelectedItem.ToString(),
                MovFin = cboMFinanceiro.SelectedItem.ToString(),
                MovStk = cboMStock.SelectedItem.ToString(),
                Nome = txtNome.Text
            };
        }

        private OperacoesViewModel getNewOperacao()
        {
            return new OperacoesViewModel()
            {
                codigo = 0,
                APP = rtxtObs.Text,
                Entidade = cboEntidade.SelectedItem.ToString(),
                MovFin = cboMFinanceiro.SelectedItem.ToString(),
                MovStk = cboMStock.SelectedItem.ToString(),
                Nome = txtNome.Text
            };
        }

        private bool validarCampos()
        {
            if (string.IsNullOrEmpty(txtNome.Text))
            {
                showMsg("Preencha o campo Nome!");
                return false;
            }
            if (cboEntidade.SelectedIndex <= -1)
            {
                showMsg("Selecione Uma entidade!");
                return false;
            }
            if (cboMFinanceiro.SelectedIndex <= -1)
            {
                showMsg("Selecione Um movimento Financeiro!");
                return false;
            }
            if (cboMFinanceiro.SelectedIndex <= -1)
            {
                showMsg("Selecione Um movimento Stock!");
                return false;
            }
            if (string.IsNullOrEmpty(rtxtObs.Text))
            {
                showMsg("Preencha o campo Observação!");
                return false;
            }
            return true;
        }
        private void showMsg(string message)
        {
            MessageBox.Show(
                message, 
                "MENSAGEM", 
                MessageBoxButtons.OK, 
                MessageBoxIcon.Information
            );
        }
        private void btnSalvarFechar_ItemClick(object sender, ItemClickEventArgs e)
        {
            btnSalvar_ItemClick(sender, e);
        }

        private void btnEditar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Operacao = CRUD.Edição;
            operar(true);
            popularCampos();
        }

        private void ribbon_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (IndexOperacao >= 0 && temCerteza())
            {
                _operacoesApp.Delete(listOperacoes[IndexOperacao]);
                frmOpSistema_Load(sender, e);
            }
            else
            {
                showMsg("Selecione uma linha de registro!");
            }
        }

        private bool temCerteza()
        {
            var result =
            MessageBox.Show(
                "Tem certeza que pretende eliminar este registro!",
                "MENSAGEM",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information
            );
            return result == DialogResult.Yes;
        }

        private void btnImprimir_ItemClick(object sender, ItemClickEventArgs e)
        {
            listOperacoes = _operacoesApp.GetAll();
            if (Equals(listOperacoes, null) || listOperacoes.Count == 0)
            {
                MessageBox.Show("Lista  Está vazia");
                return;
            }

            new frmApresentaReport().ApresentarReporOpSistema(listOperacoes, Controle.CabecalhoEmpresa);
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
    }
}