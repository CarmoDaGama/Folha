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
using Folha.Domain.Interfaces.Application.Financeiro;
using Folha.Presentation.Desktop.Classe;
using Folha.Domain.ViewModels.Financeiro;
using Folha.Domain.Models.Financeiro;
using Folha.Presentation.Desktop.Forms.Apresenta_Doc;
using Folha.Domain.ViewModels.Report;
using Folha.Driver.Framework.IOC;
using Folha.Domain.Helpers;
using Folha.Presentation.Desktop.Forms.Hospitalar;
using Folha.Presentation.Desktop.Forms.Financeiro;

namespace Folha.Presentation.Desktop.Separadores.Financeiro
{
    public partial class frmRelatorioFinanceiro : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly ITipoSaidaApp _TipoSaidaApp;
        //private int Posicao;
        //List<FluxoCaixaViewModel> LtFluxoCaixa;
        List<Caixas> LtCaixas;
        List<MostraContasViewModel> LtContas;
        //List<SaldoClienteViewModel> LtSaldoCliente;
        //List<RelNotasPagamentosViewModel> LtNotasPagamentos;
        List<SaldoCaixaViewModel> LtSaldoCaixa = new List<SaldoCaixaViewModel>();
        List<SaldoBancoViewModel> LtSaldoBanco = new List<SaldoBancoViewModel>();
        List<RelNotaFinalidadeViewModel> LtNotaFinalidade = new List<RelNotaFinalidadeViewModel>();
        private readonly ICaixasApp _CaixasApp;
        //double RelTotal;
        string RelConta;
        string RelUsuario;
        string RelCaixa;
        string RelEntidade;
        private readonly ICalculosFinanceiroApp _CalculosFinanceiroApp;
        private readonly IContaBancariaApp _ContaBancariaApp;
        DadosReportViewModel dadosReport;
        private List<TipoSaidaViewModel> LtFinalidade;

        public frmRelatorioFinanceiro(ITipoSaidaApp TipoSaidaApp,ICaixasApp CaixasApp,ICalculosFinanceiroApp CalculosFinanceiroApp,IContaBancariaApp ContaBancariaApp)
        {
            InitializeComponent();
            _TipoSaidaApp = TipoSaidaApp;
            _CaixasApp = CaixasApp;
            _CalculosFinanceiroApp = CalculosFinanceiroApp;
            _ContaBancariaApp = ContaBancariaApp;

            LtContas = (List<MostraContasViewModel>)_ContaBancariaApp.Minhas_ContasBancarias();
            LtCaixas = (List<Caixas>)_CaixasApp.Meus_Caixas();
            GradeTipoSaida.DataSource = LtFinalidade = (List<TipoSaidaViewModel>)_TipoSaidaApp.Listar(null);
        }
        private void frmRelatorioFinanceiro_Load(object sender, EventArgs e)
        {
            LtContas = (List<MostraContasViewModel>)_ContaBancariaApp.Minhas_ContasBancarias();
        }
      
        private void RecebeData()
        {
           //inicio = DateTime.Parse(dtInicio.Text);
           //termino = DateTime.Parse(dtFim.Text);
        }

        private void VerificaCamposHeader()
        {
            //RelCaixa = (!string.IsNullOrEmpty(cboCaixa.Text)) ? (cboCaixa.Text) : (null);
            //RelEntidade = (!string.IsNullOrEmpty(txtCliente.Text)) ? (txtCodCliente.Text + " - " + txtCliente.Text) : (null);
            //RelConta = (!string.IsNullOrEmpty(cboConta.Text)) ? ("CONTA | BANCO: " + cboConta.Text + "-" + txtBanco.Text) : (null);
            RelUsuario = UtilidadesGenericas.UsuarioCodigo + " - " + UtilidadesGenericas.NomeUsuario;
        }
       
        private void SaldoTotCaixa()
        {
            LtCaixas = (List<Caixas>)_CaixasApp.Meus_Caixas();
            LtSaldoCaixa = new List<SaldoCaixaViewModel>();
            for (int i = 0; i < LtCaixas.Count; i++)
            {
                int CodCaixa = LtCaixas[i].codigo;
                string Caixa = LtCaixas[i].Descricao;
                double Ex = _CaixasApp.buscarSaldoCaixa(CodCaixa);
                LtSaldoCaixa.Add(new SaldoCaixaViewModel() { Caixa = Caixa, Saldo = Ex });
            }
        }
        private void SaldoTotConta()
        {
            LtSaldoBanco = new List<SaldoBancoViewModel>();
            for (int i = 0; i < LtContas.Count; i++)
            {
                int CodConta = LtContas[i].codigo;
                string Numero = LtContas[i].Numero;
                string Banco = LtContas[i].BancoDescricao;
                double Ex = _ContaBancariaApp.buscarSaldoBanco(CodConta);

                LtSaldoBanco.Add(new SaldoBancoViewModel() { Conta = Numero, Banco = Banco, Saldo = Ex });
            }
        }
        private void BuscarSaldo()
        {
            VerificaCamposHeader();
            SaldoTotCaixa();
            SaldoTotConta();

            if  (LtSaldoCaixa.Count == 0 && LtSaldoBanco.Count==0)
            {
                MessageBox.Show("Sem relatório!", "Relatório Financeiro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataViewModel Data=new DataViewModel();
            Data = _CalculosFinanceiroApp.RetortaDataSaldoCaixaConta();
            if (Data == null)
            {
                MessageBox.Show("Sem relatório!", "Relatório Financeiro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            dadosReport = new DadosReportViewModel()
            {
                DataInicio = Data.DataInicial,
                DataFim = Data.DataFinal,
                Usuario = RelUsuario
            };
            new frmApresentaReport().ApresentarReportSaldoGeral(LtSaldoCaixa, LtSaldoBanco, dadosReport);
        }
       private void BuscarGraficoCaixa()
       {
            VerificaCamposHeader();
            SaldoTotCaixa();

            DataViewModel Data = new DataViewModel();
            Data = _CaixasApp.RetortaDataSaldoCaixa();
            if (Data == null)
            {
                MessageBox.Show("Sem relatório!", "Relatório Financeiro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            dadosReport = new DadosReportViewModel()
            {
                DataInicio = Data.DataInicial,
                DataFim = Data.DataFinal,
                Usuario = RelUsuario
            };
            new frmApresentaReport().ApresentarReportGrafCaixa(LtSaldoCaixa, dadosReport);
        } 
        private void BuscarGraficoBanco()
        {
            VerificaCamposHeader();
            SaldoTotConta();

            DataViewModel Data;
            Data = _ContaBancariaApp.RetortaDataSaldoConta();
            if (Data == null)
            {
                MessageBox.Show("Sem relatório!", "Relatório Financeiro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dadosReport = new DadosReportViewModel()
            {
                DataInicio = Data.DataInicial,
                DataFim = Data.DataFinal,
                Usuario = RelUsuario
            };
            new frmApresentaReport().ApresentarReportGrafConta(LtSaldoBanco, dadosReport);
        }
       
        private void tileSaldoGeral_ItemClick(object sender, TileItemEventArgs e)
        {
            GradeTipoSaida.Visible = false;
            BuscarSaldo();
        }

        private void tileFluxoCaixa_ItemClick(object sender, TileItemEventArgs e)
        {
            GradeTipoSaida.Visible = false;
            var formDados = IOC.InjectForm<frmRelDadosFinanceiro>();
            formDados.ImprimirFluxoCaixa();
        }

        private void tileFluxoConta_ItemClick(object sender, TileItemEventArgs e)
        {
            GradeTipoSaida.Visible = false;
            var formDados = IOC.InjectForm<frmRelDadosFinanceiro>();
            formDados.ImprimirFluxoConta();
        }

        private void tileContaCorrente_ItemClick(object sender, TileItemEventArgs e)
        {
            GradeTipoSaida.Visible = false;
            var formDados = IOC.InjectForm<frmRelDadosFinanceiro>();
            formDados.ImprimirContaCorrente();
        }

        private void tileNotasPagamentos_ItemClick(object sender, TileItemEventArgs e)
        {
            GradeTipoSaida.Visible = false;
            var formDados = IOC.InjectForm<frmRelDadosFinanceiro>();
            formDados.ImprimirNotasPagamentos();
        }

        private void tileSaldoClientes_ItemClick(object sender, TileItemEventArgs e)
        {
            GradeTipoSaida.Visible = false;
            var formDados = IOC.InjectForm<frmRelDadosFinanceiro>();
            formDados.ImprimirSaldoCliente();
        }

        private void tileDividasClientes_ItemClick(object sender, TileItemEventArgs e)
        {
            GradeTipoSaida.Visible = false;
            var formDados = IOC.InjectForm<frmRelDadosFinanceiro>();
            formDados.ImprimirDividaClientes();
        }

        private void tileGrafContas_ItemClick(object sender, TileItemEventArgs e)
        {
            GradeTipoSaida.Visible = false;
            BuscarGraficoBanco();
        }

        private void tileGrafCaixas_ItemClick(object sender, TileItemEventArgs e)
        {
            GradeTipoSaida.Visible = false;
            BuscarGraficoCaixa();
        }

        private void tileNotasFinalidade_ItemClick(object sender, TileItemEventArgs e)
        {
            GradeTipoSaida.Visible = true;

            int v = 0;
            LtFinalidade = (List<TipoSaidaViewModel>) gridView1.DataSource;
            for (int i = 0; i < LtFinalidade.Count; i++)
            {
                if (LtFinalidade[i].Checa == true)
                {
                    v++;
                }
            }

            if (v > 0)
            {
                var formDados = IOC.InjectForm<frmRelDadosFinanceiro>();
                formDados.ImprimirNotasFinalidade(LtFinalidade);
            }
            else MessageBox.Show("Selecione a Finalidade de Pagamento.", "Relatório Financeiro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }
    }
}