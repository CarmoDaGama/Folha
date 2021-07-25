using DevExpress.XtraBars;
using Folha.Domain.Interfaces.Application.Documentos;
using Folha.Domain.Interfaces.Application.Financeiro;
using Folha.Domain.Interfaces.Application.Sistema;
using Folha.Domain.Models.Documentos;
using Folha.Domain.Models.Financeiro;
using Folha.Domain.Models.Sistema;
using Folha.Domain.ViewModels.Sistema;
using Folha.Domain.Helpers;
using Folha.Domain.ViewModels.Frame.Documentos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Folha.Presentation.Desktop.Separadores.Financeiro
{
    public partial class frmTransferenciaCaixa : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly ICaixasApp _CaixasApp;
        private List<Caixas> LtCaixa;
        OperacoesViewModel DadosOperacoes;
        private string Descricao;
        private int CodCaixaOrigem;
        private readonly IDocumentosApp _DocumentosApp;
        private int _codOperacao;
        private int CodCaixaDestino;
        private readonly IOperacoesApp _OperacoesApp;

        public frmTransferenciaCaixa(ICaixasApp CaixasApp, IDocumentosApp DocumentosApp,IOperacoesApp OperacoesApp)
        {
            InitializeComponent();
            _CaixasApp = CaixasApp;
            _DocumentosApp = DocumentosApp;
            _OperacoesApp = OperacoesApp;

            LtCaixa =(List<Caixas>) _CaixasApp.Listar(null);
        }
        #region Codigos
        private void CarregaLoad()
        {
            cboCaixaOrigem.Properties.Items.Clear();
            for (int i = 0; i < LtCaixa.Count; i++)
            {
                cboCaixaOrigem.Properties.Items.Add(LtCaixa[i].Descricao.ToString());
            }

            cboCaixaDestino.Properties.Items.Clear();

            for (int i = 0; i < LtCaixa.Count; i++)
            {
                if (LtCaixa[i].Descricao.ToString() != cboCaixaOrigem.Text)
                {
                    cboCaixaDestino.Properties.Items.Add(LtCaixa[i].Descricao.ToString());
                }
            }

            DadosOperacoes = _OperacoesApp.GetOperacaPorNome("TRANSFERÊNCIA DE VALOR");
            _codOperacao = DadosOperacoes.codigo;

            txtValor.Focus();
            timeData.Text = DateTime.Now.ToShortDateString();
            timeData.Properties.MaxValue = DateTime.Now;
        }
        #endregion
        private void btnVoltar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void frmTransferenciaCaixa_Load(object sender, EventArgs e)
        {
            CarregaLoad();
        }

        private void cboCaixa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCaixaDestino.Properties.Items.Count > 0)
            {
                CodCaixaDestino= int.Parse(LtCaixa[cboCaixaDestino.SelectedIndex].codigo.ToString());
            }
        }

        private void btnSalvar_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (string.IsNullOrEmpty(cboCaixaDestino.Text)) { MessageBox.Show("Deve ser criado um caixa ou banco para a movimentação", "Transferência para Caixa", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (string.IsNullOrEmpty(txtValor.Text)) { MessageBox.Show("Informe o valor a ser transferido", "Transferência para Caixa", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (cboCaixaDestino.Text==cboCaixaOrigem.Text) { MessageBox.Show("Selecione caixas diferentes", "Transferência para Caixa", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (UtilidadesGenericas.CalculosFinanceiros.IsNumeric(txtValor.Text) == false) { MessageBox.Show("Informe o Valor Com Formato Errado", "Transferência para Caixa", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            double saldo = double.Parse(txtSaldo.Text);
            double _valor = double.Parse(txtValor.Text);

            if (_valor < 1) { MessageBox.Show("O Valor informado tem que ser maior que zero", "Transferência para Caixa", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (saldo < _valor) { MessageBox.Show("Saldo insuficiente para transferência", "Transferência para Caixa", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            int CodDocumento = _DocumentosApp.CriarDocumento(new Documentos()
            {
                CodOperacao=_codOperacao,
                CodEntidade=1,
                CodArea=1,
                Descritivo= "De " + cboCaixaOrigem.Text + " Para " + cboCaixaDestino.SelectedItem.ToString(),
                Data = DateTime.Now,
            });


            _DocumentosApp.EfectuarTransferenciaCx(new DadosPagamentoViewModel()
            {
                CodDoc = CodDocumento,
                Descricao = "Transferencia de Valor do Caixa " + cboCaixaOrigem.Text + " para o Caixa " + cboCaixaDestino.SelectedItem.ToString(),
                Valor=_valor,
                CodCaixaOrigem=CodCaixaOrigem,
                CodCaixaDestino=CodCaixaDestino,
                Data=Convert.ToDateTime( timeData.Text),
            }
             );

            _DocumentosApp.FecharDocumento(CodDocumento, 1, _valor, "De " + cboCaixaOrigem.Text + " Para o Caixa " + cboCaixaDestino.SelectedItem.ToString());
            MessageBox.Show("Transferência Efectuada com Sucesso", "Tranferência Bancária", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void cboCaixaOrigem_SelectedIndexChanged(object sender, EventArgs e)
        {       
            if (cboCaixaOrigem.Properties.Items.Count > 0)
            {
                CodCaixaOrigem = LtCaixa[cboCaixaOrigem.SelectedIndex].codigo;
                Descricao = LtCaixa[cboCaixaOrigem.SelectedIndex].Descricao;
            }

            double x =_CaixasApp.buscarSaldoCaixa(CodCaixaOrigem);
            txtSaldo.Text = x.ToString("N2");
        }

        private void btnFechar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void bbiPrint_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItem1_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            txtValor.Text = "";
        }
    }
}