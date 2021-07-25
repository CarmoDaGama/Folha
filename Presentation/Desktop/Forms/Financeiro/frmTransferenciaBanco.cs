using System;
using DevExpress.XtraBars;
using Folha.Domain.Helpers;
using Folha.Driver.Framework.IOC;
using Folha.Domain.Interfaces.Application.Documentos;
using Folha.Domain.Interfaces.Application.Financeiro;
using Folha.Domain.Models.Financeiro;
using System.Collections.Generic;
using System.Windows.Forms;
using Folha.Domain.Models.Documentos;
using Folha.Domain.ViewModels.Frame.Documentos;
using Folha.Domain.Interfaces.Application.Sistema;
using Folha.Domain.ViewModels.Sistema;

namespace Folha.Presentation.Desktop.Separadores.Financeiro
{
    public partial class frmTransferenciaBanco : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly IDocumentosApp _DocumentosApp;
        private readonly ICaixasApp _CaixasApp;
        private List<Caixas> LtCaixa;
        OperacoesViewModel DadosOperacoes;
        private int codCaixa;
        private string Descricao;
        private int _codOperacao;
        private string validaPreco = ("qwertyuiop+´´asdfghjklçº~<zxcvbnm-/*-+_^`*ª»?=)(//&%$#:;|!#$%&/()=?»><*^ª%_:--»º|!?»`^ª[]}[}*-+^^`*");
        private readonly IOperacoesApp _OperacoesApp;
        private string conta;
        private int codConta;
        private readonly IFPagamentosApp _FPagamentosApp;
        private int codForma;

        public frmTransferenciaBanco(IDocumentosApp DocumentosApp, ICaixasApp CaixasApp, IOperacoesApp OperacoesApp,IFPagamentosApp FPagamentosApp)
        {
            InitializeComponent();
            _DocumentosApp = DocumentosApp;
            _CaixasApp = CaixasApp;
            _OperacoesApp = OperacoesApp;
            _FPagamentosApp = FPagamentosApp;
            LtCaixa = (List<Caixas>)_CaixasApp.Listar(null);
        }

        private void btnFechar_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnContaBancaria_Click(object sender, EventArgs e)
        {
           
           
        }

        private void frmTransferenciaBanco_Load(object sender, EventArgs e)
        {
            timeData.Text = DateTime.Now.ToShortDateString();
            timeData.Properties.MaxValue = DateTime.Now;

            cboCaixa.Properties.Items.Clear();
            for (int i = 0; i < LtCaixa.Count; i++)
            {
                cboCaixa.Properties.Items.Add(LtCaixa[i].Descricao.ToString());
            }

            DadosOperacoes = _OperacoesApp.GetOperacaPorNome("TRANSFERÊNCIA DE VALOR");
            _codOperacao = DadosOperacoes.codigo;
        }

        private void btnSalvar_ItemClick(object sender, ItemClickEventArgs e)
        {
            fPagamentos dados = _FPagamentosApp.GetByCodConta(codConta);
            if (dados != null)
            {
                if (string.IsNullOrEmpty(cboCaixa.Text)|| string.IsNullOrEmpty(txtContaBancaria.Text)) { MessageBox.Show("Deve ser Criado um Caixa ou Banco para a Movimentação", "Transferência para Caixa", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                if (string.IsNullOrEmpty(txtValor.Text)) { MessageBox.Show("Informe o valor a ser transferido", "Transferência para Caixa", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            
                if (UtilidadesGenericas.CalculosFinanceiros.IsNumeric(txtValor.Text) == false) { MessageBox.Show("Informe o valor com formato errado", "Transferência para Caixa", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                double saldo = double.Parse(txtSaldo.Text);
                double _valor = double.Parse(txtValor.Text);

                if (_valor < 1) { MessageBox.Show("O Valor informado tem que ser maior que zero", "Transferência para Caixa", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                if (saldo < _valor) { MessageBox.Show("Saldo insuficiente para transferência", "Transferência para Caixa", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                int CodDocumento = _DocumentosApp.CriarDocumento(new Documentos()
                {
                CodOperacao = _codOperacao,
                CodEntidade = 1,
                CodArea = 1,
                Descritivo = "De " + cboCaixa.Text + " Para " + txtBanco.Text,
                Data = DateTime.Now,
        
                });

          
            _DocumentosApp.EfectuarTransferenciaBn(new DadosPagamentoViewModel()
            {
                CodDoc = CodDocumento,
                Descricao = "Transferencia de Valor do Caixa " + cboCaixa.Text + " Para a Conta " + txtContaBancaria.Text,
                Valor = _valor,
                CodCaixa=codCaixa,
                CodConta=codConta,
                CodForma=dados.codigo,
                Data = Convert.ToDateTime(timeData.Text),
                Banco=txtBanco.Text
            }
             );

            _DocumentosApp.FecharDocumento(CodDocumento, 1, _valor, "De " + cboCaixa.Text + " Para a Conta " + txtContaBancaria.Text);
            MessageBox.Show("Transferência Efectuada com Sucesso","Tranferência Bancária",MessageBoxButtons.OK,MessageBoxIcon.Information);
                this.Close();
            }
            else MessageBox.Show("Não existe forma de pagamento veínculado com a conta.", "Tranferência Bancária", MessageBoxButtons.OK, MessageBoxIcon.Error);

            
        }

        private void cboCaixaOrigem_SelectedIndexChanged(object sender, EventArgs e)
        {         
            if (cboCaixa.Properties.Items.Count > 0)
            {
                codCaixa = LtCaixa[cboCaixa.SelectedIndex].codigo;
                Descricao = LtCaixa[cboCaixa.SelectedIndex].Descricao;
            }

            double x = _CaixasApp.buscarSaldoCaixa(codCaixa);
            txtSaldo.Text = x.ToString("N2");
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (validaPreco.Contains(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }

        private void txtBanco_Click(object sender, EventArgs e)
        {
            var chamada = IOC.InjectForm<frmContasBancarias>().GetContaBancaria();

            if (chamada == null) return;
            codConta = chamada.codigo;
            conta = chamada.Descricao;
            txtCodConta.Text = codConta.ToString();
            txtBanco.Text = conta;
            txtContaBancaria.Text = chamada.Numero;
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            txtBanco.Text = "";
            txtCodConta.Text = "";
            txtContaBancaria.Text = "";
            txtValor.Text = "";
        }
    }
}