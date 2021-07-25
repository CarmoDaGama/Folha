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
using Folha.Presentation.Desktop.Forms.Apresenta_Doc;
using Folha.Domain.ViewModels.Frame.Hospitalar;
using Folha.Domain.ViewModels.Hospitalar;
using Folha.Domain.Interfaces.Application.Hospitalar;
using Folha.Domain.Interfaces.Application.Financeiro;
using Folha.Domain.ViewModels.Financeiro;
using Folha.Domain.Models.Financeiro;
using Folha.Presentation.Desktop.Classe;
using Folha.Domain.Helpers;
using Folha.Domain.ViewModels.Report;
using Folha.Presentation.Desktop.Separadores.Entidades;
using Folha.Driver.Framework.IOC;
using Folha.Domain.Models.Hospitalar;
using Folha.Presentation.Desktop.Forms.Hispitalar;

namespace Folha.Presentation.Desktop.Forms.Financeiro
{
    public partial class frmRelDadosFinanceiro : DevExpress.XtraEditors.XtraForm
    {

        private readonly IPacienteApp _PacienteApp;

        private readonly ICaixasApp _CaixasApp;
        private List<MostraContasViewModel> LtContas;
        private readonly IContaBancariaApp _ContaBancariaApp;
        private List<Caixas> LtCaixas;
        List<FluxoCaixaViewModel> LtFluxoCaixa;
        string RelConta;
        string RelUsuario;
        string RelCaixa;
        string RelEntidade;
        private DateTime inicio;
        private DateTime termino;
        string NomeRelatorio;
        private DadosReportViewModel dadosReport;
        private double RelTotal;
        private readonly ICalculosFinanceiroApp _CalculosFinanceiroApp;
        private List<SaldoClienteViewModel> LtSaldoCliente;
        private List<RelNotasPagamentosViewModel> LtNotasPagamentos;
        private List<RelNotaFinalidadeViewModel> LtNotaFinalidade;
        private List<TipoSaidaViewModel> LtFinalidade;
        private readonly ITriagemApp _TriagemApp;

        public frmRelDadosFinanceiro(IPacienteApp PacienteApp, ICaixasApp CaixasApp,IContaBancariaApp ContaBancariaApp, ICalculosFinanceiroApp CalculosFinanceiroApp,ITriagemApp TriagemApp)
        {
            InitializeComponent();

            _PacienteApp = PacienteApp;
            _TriagemApp = TriagemApp;

            _CaixasApp = CaixasApp;
            _ContaBancariaApp = ContaBancariaApp;
            LtContas = (List<MostraContasViewModel>)_ContaBancariaApp.Minhas_ContasBancarias();
            _CalculosFinanceiroApp = CalculosFinanceiroApp;
            LtCaixas = (List<Caixas>)_CaixasApp.Meus_Caixas();

            cboFiltar.SelectedIndex = 0;
        }
       

        private void btnImprimir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (NomeRelatorio=="FluxoCaixa")
            {
                if (string.IsNullOrEmpty(cboCaixa.Text)) { MessageBox.Show("Selecione o Caixa!", "Caixa", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                BuscarFluxoCaixa();
            }
            if (NomeRelatorio == "FluxoConta")
            {
                if (string.IsNullOrEmpty(cboConta.Text)) { MessageBox.Show("Selecione a Conta!", "Conta Bancária", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                BuscarFluxoBanco();
            }
            if (NomeRelatorio == "ContaCorrente")
            {
                if (string.IsNullOrEmpty(txtCliente.Text)) { MessageBox.Show("Selecione o Cliente!", "Conta Corrente", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                buscarContaCorrente();
            }
            if (NomeRelatorio == "SaldoClientes")
            {
                BuscarSaldoClientes();
            }
            if (NomeRelatorio == "DividasClientes")
            {
                BuscarDividasClientes();
            }
            if (NomeRelatorio == "NotasPagamentos")
            {
                BuscarNotasPagamentos();
            }
            if (NomeRelatorio == "NotasFinalidade")
            {
                BuscarTotalizadoresPagamentos();
            }


        }
       
        private void btnVoltar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
        //Filtrar os dados na ComboBox
        private void cboFiltar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboFiltar.Text == "Todos")
            {
                Controle.DesabilitarControle(dtInicio, dtFim);
            }
            else
            {
                Controle.HabilitarControle(dtInicio, dtFim);
            }
            
        }
        //----------------------------------------------------------------------------
        //Financeiro
        //----------------------------------------------------------------------------
        #region RelFinanceiro
        private void SizeFluxoCaixa()
        {
            Controle.DesabilitarControle(cboFiltar);
            Controle.VisivelControle(pnlCaixa,pnlTipoOp);
            pnlCliente.Height=1;
            pnlConta.Height = 1;
            pnlEntidade.Height = 1;

            var SIZEfORM = 0;
            SIZEfORM += pnlCaixa.Height+pnlTipoOp.Height+pnlFiltro.Height+pnlData.Height;
            this.Size = new Size(522, SIZEfORM);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void SizeFluxoConta()
        {
            Controle.DesabilitarControle(cboFiltar);
            Controle.VisivelControle(pnlConta, pnlTipoOp);
            pnlCliente.Height = 1;
            pnlCaixa.Height = 1;
            pnlEntidade.Height = 1;

            var SIZEfORM = 0;
            SIZEfORM += pnlConta.Height + pnlTipoOp.Height + pnlFiltro.Height + pnlData.Height;
            this.Size = new Size(522, SIZEfORM);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        private void SizeContaCorrente()
        {
            Controle.DesabilitarControle(cboFiltar);
            Controle.VisivelControle(pnlCliente, pnlTipoOp);
            Controle.HabilitarControle(btnCliente);
            pnlCaixa.Height = 1;
            pnlEntidade.Height = 1;

            var SIZEfORM = 0;
            SIZEfORM += pnlCliente.Height + pnlTipoOp.Height + pnlFiltro.Height + pnlData.Height;
            this.Size = new Size(522, SIZEfORM);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        private void SizeData()
        {
            pnlCaixa.Height = 1;
            pnlEntidade.Height = 1;
            pnlCliente.Height = 1;
            pnlConta.Height = 1;
            pnlTipoOp.Height = 1;
            var SIZEfORM = 0;
            SIZEfORM += pnlFiltro.Height + pnlData.Height;
            this.Size = new Size(522, SIZEfORM);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        #region MetodosPrint
        public void ImprimirFluxoCaixa()
        {
            cboFiltar.SelectedIndex = 1;
            SizeFluxoCaixa();
            NomeRelatorio = "FluxoCaixa";
            lbRelatorio.Text = "Relatório - Fluxo de Caixa";
            ShowDialog();
            Close();
        }
        public void ImprimirFluxoConta()
        {
            cboFiltar.SelectedIndex = 1;
            SizeFluxoConta();
            txtBanco.ReadOnly=true ;
            NomeRelatorio = "FluxoConta";
            lbRelatorio.Text = "Relatório - Fluxo de Conta";
            ShowDialog();
            Close();
        }
        public void ImprimirContaCorrente()
        {
            cboFiltar.SelectedIndex = 1;
            SizeContaCorrente();
            txtCliente.ReadOnly = true;
            NomeRelatorio = "ContaCorrente";
            lbRelatorio.Text = "Relatório - Conta Corrente (Cliente)";
            ShowDialog();
            Close();
        }
        public void ImprimirSaldoCliente()
        {
            cboFiltar.SelectedIndex = 1;
            NomeRelatorio = "SaldoClientes";
            SizeData();
            lbRelatorio.Text = "Relatório - Saldo de Clientes";
            ShowDialog();
            Close();
        }
        public void ImprimirDividaClientes()
        {
            cboFiltar.SelectedIndex = 1;
            SizeData();
            NomeRelatorio = "DividasClientes";
            lbRelatorio.Text = "Relatório - Dividas de Clientes";
            ShowDialog();
            Close();
        }
        public void ImprimirNotasPagamentos()
        {
            cboFiltar.SelectedIndex = 1;
            SizeData();
            NomeRelatorio = "NotasPagamentos";
            lbRelatorio.Text = "Relatório - Notas de Pagamentos";
            ShowDialog();
            Close();
        }
        public void ImprimirNotasFinalidade(List<TipoSaidaViewModel>LtFinalidade)
        {
            this.LtFinalidade = LtFinalidade;
            cboFiltar.SelectedIndex = 1;
            cboFiltar.Enabled = false;
            SizeData();
            NomeRelatorio = "NotasFinalidade";
            lbRelatorio.Text = "Relatório - Notas de Pagamento Por Finalidade";
            ShowDialog();
            Close();
        }
        #endregion
        private void BuscarFluxoBanco()
        {
            VerificaCamposHeader();
            RecebeData();
            LtFluxoCaixa = (List<FluxoCaixaViewModel>)_CalculosFinanceiroApp.ListarFluxo(inicio.ToString("yyyy-MM-dd"), termino.ToString("yyyy-MM-dd"), null, LtContas[cboConta.SelectedIndex].codigo.ToString(), cboTipoOp.Text);

            if (Equals(LtFluxoCaixa, null) || LtFluxoCaixa.Count == 0)
            {
                MessageBox.Show("Sem Relatório!", "Relatório Financeiro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                double soma = 0;
                double debito = 0;
                double credito = 0;

                for (int i = 0; i < LtFluxoCaixa.Count; i++)
                {
                    soma = Convert.ToDouble(LtFluxoCaixa[i].Valor);

                    if (LtFluxoCaixa[i].Tipo == "DEBITO") debito += soma;
                    if (LtFluxoCaixa[i].Tipo == "CREDITO") credito += soma;
                }

                soma = credito - debito;
                RelTotal = soma;
            }
            catch (Exception) { }
            dadosReport = new DadosReportViewModel()
            {
                DataInicio = DateTime.Parse(dtInicio.Text),
                DataFim = DateTime.Parse(dtFim.Text),
                Total = RelTotal,
                Caixa = RelCaixa,
                Conta = RelConta,
                NomeEntidade = RelEntidade,
                Usuario = RelUsuario
            };
            new frmApresentaReport().ApresentarReportFluxoConta(LtFluxoCaixa, dadosReport);

        }
        private void BuscarSaldoClientes()
        {
            VerificaCamposHeader();
            RecebeData();

            if(cboFiltar.Text=="Filtrar")
            LtSaldoCliente = (List<SaldoClienteViewModel>)_CalculosFinanceiroApp.BuscarSaldoClientes(inicio.ToString("yyyy-MM-dd"), termino.ToString("yyyy-MM-dd"));
            else if(cboFiltar.Text == "Todos")
            { 
                LtSaldoCliente = (List<SaldoClienteViewModel>)_CalculosFinanceiroApp.BuscarSaldoClientes(null, null);
                DataViewModel data = _CalculosFinanceiroApp.RetornaDataDocumento();
                inicio =data.DataInicial;
                termino = data.DataFinal;
            }
                

            if (Equals(LtSaldoCliente, null) || LtSaldoCliente.Count == 0)
            {
                MessageBox.Show("Sem Relatório!", "Relatório Financeiro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dadosReport = new DadosReportViewModel()
            {
                DataInicio =inicio,
                DataFim=termino,
                Usuario = RelUsuario
            };
            new frmApresentaReport().ApresentarReportSaldoCliente(LtSaldoCliente, dadosReport);
        }
        private void BuscarFluxoCaixa()
        {
            VerificaCamposHeader();
            RecebeData();
            LtFluxoCaixa = (List<FluxoCaixaViewModel>)_CalculosFinanceiroApp.ListarFluxo(inicio.ToString("yyyy-MM-dd"), termino.ToString("yyyy-MM-dd"), LtCaixas[cboCaixa.SelectedIndex].codigo.ToString(), null,cboTipoOp.Text);

            if (Equals(LtFluxoCaixa, null) || LtFluxoCaixa.Count == 0)
            {
                MessageBox.Show("Sem Relatório!", "Relatório Financeiro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                double soma = 0;
                double debito = 0;
                double credito = 0;

                for (int i = 0; i < LtFluxoCaixa.Count; i++)
                {
                    soma = Convert.ToDouble(LtFluxoCaixa[i].Valor);
                    if (LtFluxoCaixa[i].Tipo == "DEBITO") debito += soma;
                    if (LtFluxoCaixa[i].Tipo == "CREDITO") credito += soma;
                }

                soma = credito - debito;
                RelTotal = soma;
            }
            catch (Exception) { }


            dadosReport = new DadosReportViewModel()
            {
                DataInicio = DateTime.Parse(dtInicio.Text),
                DataFim = DateTime.Parse(dtFim.Text),
                Total = RelTotal,
                Caixa = cboCaixa.Text,
                Conta = RelConta,
                NomeEntidade = RelEntidade,
                Usuario = RelUsuario
            };

            new frmApresentaReport().ApresentarReportFluxoCaixa(LtFluxoCaixa, dadosReport);

        }
        private void buscarContaCorrente()
        {
           
            VerificaCamposHeader();
            RecebeData();
            LtFluxoCaixa = (List<FluxoCaixaViewModel>)_CalculosFinanceiroApp.buscarContaCorrente(inicio.ToString("yyyy-MM-dd"), termino.ToString("yyyy-MM-dd"), int.Parse(txtCodCliente.Text));

            if (cboTipoOp.Text == "Crédito")
                LtFluxoCaixa = LtFluxoCaixa.Where(r => r.Tipo == "CREDITO").ToList();
            else if (cboTipoOp.Text == "Débito")
                LtFluxoCaixa = LtFluxoCaixa.Where(r => r.Tipo == "DEBITO").ToList();

            if (Equals(LtFluxoCaixa, null) || LtFluxoCaixa.
                Count == 0)
            {
                MessageBox.Show("Sem Relatório!", "Relatório Financeiro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dadosReport = new DadosReportViewModel()
            {
                DataInicio = DateTime.Parse(dtInicio.Text),
                DataFim = DateTime.Parse(dtFim.Text),
                Total = RelTotal,
                Caixa = RelCaixa,
                Conta = RelConta,
                NomeEntidade = RelEntidade,
                Usuario = RelUsuario
            };
            new frmApresentaReport().ApresentarReportContaCorrente(LtFluxoCaixa, dadosReport);
        }
        private void BuscarDividasClientes()
        {
            VerificaCamposHeader();
            RecebeData();
            if (cboFiltar.Text == "Filtrar")
                LtSaldoCliente = (List<SaldoClienteViewModel>)_CalculosFinanceiroApp.BuscarDividasClientes(inicio.ToString("yyyy-MM-dd"), termino.ToString("yyyy-MM-dd"));
            else if(cboFiltar.Text=="Todos")
            {
                LtSaldoCliente = (List<SaldoClienteViewModel>)_CalculosFinanceiroApp.BuscarDividasClientes(null, null);
                DataViewModel data = _CalculosFinanceiroApp.RetornaDataDocumento();
                inicio = data.DataInicial;
                termino = data.DataFinal;
            }
               

            if (Equals(LtSaldoCliente, null) || LtSaldoCliente.Count == 0)
            {
                MessageBox.Show("Sem Relatório!", "Relatório Financeiro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dadosReport = new DadosReportViewModel()
            {
                DataInicio = inicio,
                DataFim = termino,
                Usuario = RelUsuario
            };
            new frmApresentaReport().ApresentarReportDividaCliente(LtSaldoCliente, dadosReport);
        }

        private void BuscarNotasPagamentos()
        {
            VerificaCamposHeader();
            RecebeData();
            if (cboFiltar.Text == "Filtrar")
                LtNotasPagamentos = (List<RelNotasPagamentosViewModel>)_CalculosFinanceiroApp.BuscarNotasPagamentos(inicio.ToString("yyyy-MM-dd"), termino.ToString("yyyy-MM-dd"));
            else if (cboFiltar.Text == "Todos")
            {
                LtNotasPagamentos = (List<RelNotasPagamentosViewModel>)_CalculosFinanceiroApp.BuscarNotasPagamentos(null, null);
                DataViewModel data = _CalculosFinanceiroApp.RetortaDataNotasPagamentos();
                inicio = data.DataInicial;
                termino = data.DataFinal;
            }
               
            if (Equals(LtNotasPagamentos, null) || LtNotasPagamentos.Count == 0)
            {
                MessageBox.Show("Sem Relatório!", "Relatório Financeiro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dadosReport = new DadosReportViewModel()
            {
                DataInicio = inicio,
                DataFim = inicio,
                Caixa = RelCaixa,
                Conta = RelConta,
                NomeEntidade = RelEntidade,
                Usuario = RelUsuario
            };
            new frmApresentaReport().ApresentarReportNotasPagamentos(LtNotasPagamentos, dadosReport);
        }

        private void BuscarTotalizadoresPagamentos()
        {
            VerificaCamposHeader();
            RecebeData();

            string Operacoes = null;
            LtNotaFinalidade = new List<RelNotaFinalidadeViewModel>();
            for (int i = 0; i < LtFinalidade.Count; i++)
            {
                if (LtFinalidade[i].Descricao != null && LtFinalidade[i].Checa == true)
                {
                    Operacoes = Operacoes + " NotaSaida.CodTipoSaida='" + LtFinalidade[i].Codigo.ToString() + "' OR";
                    string Documento = LtFinalidade[i].Descricao;
                    string Total = _CalculosFinanceiroApp.MostraTotal(inicio.ToString("yyyy-MM-dd"), termino.ToString("yyyy-MM-dd"), LtFinalidade[i].Codigo);
                    LtNotaFinalidade.Add(new RelNotaFinalidadeViewModel() { Descricao = Documento, Valor = Convert.ToDouble(Total) });
                }
            }

            if (LtNotaFinalidade.Count == 0)
            {
                MessageBox.Show("Sem Relatório Disponível!", "Relatório Financeiro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dadosReport = new DadosReportViewModel()
            {
                DataInicio = DateTime.Parse(dtInicio.Text),
                DataFim = DateTime.Parse(dtFim.Text),
                Caixa = RelCaixa,
                Conta = RelConta,
                NomeEntidade = RelEntidade,
                Usuario = RelUsuario
            };
            new frmApresentaReport().ApresentarReportNotaFinalidade(LtNotaFinalidade, dadosReport);

        }
        #endregion

        private void frmRelDadosHospitalar_Load(object sender, EventArgs e)
        {
            if (!cboFiltar.Enabled) { lbFiltragem.Visible = false; cboFiltar.Visible = false; }

            LtContas = (List<MostraContasViewModel>)_ContaBancariaApp.Minhas_ContasBancarias();
            for (int i = 0; i < LtContas.Count; i++)
            {
                cboConta.Properties.Items.Add(LtContas[i].Numero);
            }

            for (int i = 0; i < LtCaixas.Count; i++)
            {
                cboCaixa.Properties.Items.Add(LtCaixas[i].Descricao);
            }

            dtInicio.EditValue = DateTime.Today;
            dtFim.EditValue = DateTime.Today;
            dtInicio.Properties.MaxValue = DateTime.Now;
            dtFim.Properties.MaxValue = DateTime.Now;
            cboTipoOp.SelectedIndex = 0;
            //this.AutoSize = false;
        }

        private void VerificaCamposHeader()
        {
            RelCaixa = (!string.IsNullOrEmpty(cboCaixa.Text)) ? (cboCaixa.Text) : (null);
            RelEntidade = (!string.IsNullOrEmpty(txtCliente.Text)) ? (txtCodCliente.Text + " - " + txtCliente.Text) : (null);
            RelConta = (!string.IsNullOrEmpty(cboConta.Text)) ? ("CONTA | BANCO: " + cboConta.Text + "-" + txtBanco.Text) : (null);
            RelUsuario = UtilidadesGenericas.UsuarioCodigo + " - " + UtilidadesGenericas.NomeUsuario;
        }
        private void RecebeData()
        {
            inicio = DateTime.Parse(dtInicio.Text);
            termino = DateTime.Parse(dtFim.Text);
        }

        private void cboConta_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBanco.Text = LtContas[cboConta.SelectedIndex].BancoDescricao;
        }

        private void btnCliente_Click_1(object sender, EventArgs e)
        {
            var form = IOC.InjectForm<frmEntidadeBusca>().GetEntidadeSelecionada(1);
            txtCodCliente.Text = form.Codigo.ToString();
            txtCliente.Text = form.Nome;
        }

        private void btnEntidade_Click_1(object sender, EventArgs e)
        {
            var form = IOC.InjectForm<frmEntidadeBusca>().GetEntidadeSelecionada();
            txtCodEntidade.Text = form.Codigo.ToString();
            txtNomeEntidade.Text = form.Nome;
        }

        
    }
}