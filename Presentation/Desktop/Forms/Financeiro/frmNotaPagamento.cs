using System;
using Folha.Domain.Interfaces.Application.Financeiro;
using Folha.Domain.Models.Financeiro;
using Folha.Driver.Framework.IOC;
using System.Windows.Forms;
using System.Collections.Generic;
using Folha.Presentation.Desktop.Separadores.Entidades;
using Folha.Domain.ViewModels.Frame.Financeiro;
using Folha.Domain.Models.Documentos;
using Folha.Domain.Helpers;
using Folha.Domain.Interfaces.Application.Documentos;
using Folha.Presentation.Desktop.Classe;
using Folha.Domain.ViewModels.Financeiro;
using Folha.Domain.ViewModels.Hospitalar;
using Folha.Presentation.Desktop.Forms.Principal;
using Folha.Domain.ViewModels.Sistema;
using Folha.Domain.Interfaces.Application.Sistema;
using Folha.Domain.Interfaces.Application.Genericos;
using Folha.Presentation.Desktop.Forms.Financeiro;

namespace Folha.Presentation.Desktop.Separadores.Financeiro
{
    public partial class frmNotaPagamento : DevExpress.XtraEditors.XtraForm
    {
        List<BuscaDocNotaPagamentoViewModel> ListDoc = new List<BuscaDocNotaPagamentoViewModel>();
        private readonly INotasPagamentosApp _NotasPagamentosApp;
        private List<NotaPagamento> ListNotaSaida=new List<NotaPagamento>();
        private List<NotaPagamentoViewModel> LtPagamento;

        private readonly IPagamentosApp _PagamentosApp;
        private int codOperacao;
        private readonly IDocumentosApp _DocumentosApp;
        private readonly ICalculosFinanceiroApp _CalculosApp;
        private string criterios;
        private int codEntidade;
        OperacoesViewModel DadosOperacoes;
        private readonly IOperacoesApp _OperacoesApp;
        private readonly IGenericoApp _GenericoApp;
        string CodDocumento=null;

        private bool Pago { get; set; }

        public frmNotaPagamento(INotasPagamentosApp NotasPagamentosApp, IPagamentosApp PagamentosApp, IDocumentosApp DocumentosApp, ICalculosFinanceiroApp CalculosApp, IOperacoesApp OperacoesApp,IGenericoApp GenericoApp)
        {
            InitializeComponent();
            navigationFrame1.SelectedPage = navigationPage1;
            _NotasPagamentosApp = NotasPagamentosApp;
            _PagamentosApp = PagamentosApp;
            _DocumentosApp = DocumentosApp;
            _CalculosApp = CalculosApp;
            _OperacoesApp = OperacoesApp;
            _GenericoApp = GenericoApp;
        }
        private void BuscarDocumento()
        {

            ListDoc = (List < BuscaDocNotaPagamentoViewModel >) _NotasPagamentosApp.BuscaDocumento(txtCodDoc.Text);
            txtCodEntidade.Text = ListDoc[0].Codigo.ToString();
            txtEntidade.Text = ListDoc[0].Entidade.ToString();
            DateTime Data = DateTime.Parse(ListDoc[0].Data.ToString());
            timeData.Text = Data.ToShortDateString();


            if (ListDoc[0].Estado.ToString() == "FECHADO")
            {
                btnSalvar.Enabled = false;
            }
        }
        private void buscarDados()
        {
            ListNotaSaida = (List<NotaPagamento>)_NotasPagamentosApp.BuscarTabela_com_Criterio(txtCodDoc.Text);
            
            if (ListNotaSaida.Count > 0)
            {
                var Finalidade = _GenericoApp.GetDescricaoByCodigo("TipoSaida",int.Parse( ListNotaSaida[0].CodTipoSaida));

                txtObservacao.Text = ListNotaSaida[0].Descricao.ToString();
                txtCodFinalidade.Text = ListNotaSaida[0].CodTipoSaida;
                txtFinalidade.Text = Finalidade.Descricao;

            }
            CarregaPagamentos();

        }
        private void simpleButton8_Click(object sender, EventArgs e)
        {
            if (!Validacoes()) return;

            if (UtilidadesGenericas.EstadoTurnoSistema)
            {
                frmPagamentoViaCaixa Pagamento = IOC.InjectForm<frmPagamentoViaCaixa>();
                Pagamento.ReceberParametros(txtFinalidade.Text, txtCodDoc.Text, txtTotal.Text, txtCodEntidade.Text, txtEntidade.Text, txtDoc.Text, "PAGAMENTO DE " + txtDoc.Text + " Nº: " + txtCodDoc.Text, Convert.ToDateTime(timeData.Text));
                if (Pagamento != null)
                {
                    CarregaPagamentos();
                }
                CalcTotal();
            }
            else UtilidadesGenericas.MsgShow(
                  "Mensagem",
                  "Turno Está fechado!",
                  MessageBoxIcon.Stop,
                  MessageBoxButtons.OK
              );

        }
        private bool Validacoes()
        {
            bool Resposta = true;

            if (string.IsNullOrEmpty(txtCodFinalidade.Text))
            {
                UtilidadesGenericas.MsgShow(
                    "Nota de Pagamento",
                    "Informe a finalidade do Pagamento", 
                    MessageBoxIcon.Error,
                    MessageBoxButtons.OK
                );
                return false;
            }
            if (string.IsNullOrEmpty(txtCodEntidade.Text))
            {
                UtilidadesGenericas.MsgShow(
                    "Nota de Pagamento", 
                    "Informe a Identidade", 
                    MessageBoxIcon.Error,
                    MessageBoxButtons.OK);
                return false;
            }
            CriaDocumento();
            return Resposta;
        }
        private void CriaDocumento()
        {
            if (string.IsNullOrEmpty(txtCodDoc.Text))
            {
                int CodEntidade = int.Parse(txtCodEntidade.Text); ;
                int codDocumento = _DocumentosApp.CriarDocumento(new Documentos()
                {
                    CodOperacao = codOperacao,
                    CodEntidade = CodEntidade,
                    CodArea = 1,
                    Data = DateTime.Parse(timeData.Text)
                });
                txtCodDoc.Text = codDocumento.ToString();
            }
        }
        private void btnDocumentos_Click(object sender, EventArgs e)
        {
            navigationFrame1.SelectedPage = navigationPage1;
        }

        private void btnEmpresa_Click(object sender, EventArgs e)
        {
            navigationFrame1.SelectedPage = navigationPage2;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (gvPagamentos.RowCount == 0) {
            UtilidadesGenericas.MsgShow(
                "Nota de Pagamento",
                "Não Existe Pagamentos Informados", 
                MessageBoxIcon.Error, 
                MessageBoxButtons.OK
            ); return; }

            try
            {
                _NotasPagamentosApp.addNotaPagamento(new NotaPagamento()
                {
                  Documento = new Documentos { codigo = int.Parse(txtCodDoc.Text) },
                  Descricao = txtObservacao.Text,
                  TipoSaida = new TipoSaida { Codigo = int.Parse(txtCodFinalidade.Text) }
                });

              
                int CodEntidade = int.Parse(txtCodEntidade.Text);
                _DocumentosApp.FecharDocumento(int.Parse(txtCodDoc.Text), CodEntidade, double.Parse(txtTotal.Text), null);
                BuscarDocumento();
                Pago = true;
                Imprimir();
            }
            catch (Exception)
            {
                UtilidadesGenericas.MsgShow("Houve um erro na na gravação ");
            }


            this.Close();
           
        }
        private void CalcTotal()
        {
            double somaT = 0;
            for (int i = 0; i < LtPagamento.Count; i++)
            {
                somaT += LtPagamento[i].Valor;
                if (LtPagamento[i].Moeda != UtilidadesGenericas.Moeda)
                {
                    //CASO A MOEDA PADRAO NAO FOR KWANZA
                    int Cambio = int.Parse(gvPagamentos.GetRowCellValue(i, "CodCambio").ToString());
                    somaT = double.Parse(UtilidadesGenericas.CalculosFinanceiros.ConverterMoeda(somaT, _CalculosApp.TaxadeCambio(Cambio), true));
                }
            }

            txtPago.Text = somaT.ToString("N2");
            txtTotal.Text = somaT.ToString("N2");
        }
        private void btnBancario_Click(object sender, EventArgs e)
        {
            if(!Validacoes()) return;

            if (UtilidadesGenericas.EstadoTurnoSistema)
            {
                frmPagamentoViaBanco Pagamento = IOC.InjectForm<frmPagamentoViaBanco>();
                Pagamento.ReceberParametros(txtFinalidade.Text, txtCodDoc.Text, txtTotal.Text, txtCodEntidade.Text, txtEntidade.Text, txtDoc.Text, "PAGAMENTO DE " + txtDoc.Text + " Nº: " + txtCodDoc.Text, Convert.ToDateTime(timeData.Text));
                if (Pagamento != null)
                {
                    CarregaPagamentos();
                }
                CalcTotal();
            }
            else UtilidadesGenericas.MsgShow(
                  "Mensagem",
                  "Turno Está fechado!",
                  MessageBoxIcon.Stop,
                  MessageBoxButtons.OK
              );

        }

        private void CarregaPagamentos()
        {
            try
            {
                gradeNotaPagamento.DataSource = LtPagamento = _NotasPagamentosApp.ListarNotasPagamentos(int.Parse(txtCodDoc.Text));
            }
            catch (Exception ex) { UtilidadesGenericas.MsgShow("Erro ao Carregar os Pagamentos: \n" + ex.Message); }

            CalcTotal();
           
        }
        public bool ReceberCodDocumento(string codDocumento)
        {
            btnPrint.Enabled = true;
            this.CodDocumento = codDocumento;
            Controle.DesabilitarControle(btnBancario, btnSalvar, txtObservacao, btnNumerario);
            ShowDialog();
            Close();
            return Pago;
        }
        private void frmNotaPagamento_Load(object sender, EventArgs e)
        {
            
            timeData.Text = DateTime.Now.ToShortDateString();
            timeData.Properties.MaxValue = DateTime.Now;
            txtDoc.Text = "NOTA DE PAGAMENTO";

            DadosOperacoes = _OperacoesApp.GetOperacaPorNome("NOTA DE PAGAMENTO");
            codOperacao = DadosOperacoes.codigo;


            int x = _DocumentosApp.LerNumeroDocumentoAberto(codOperacao, 1, 0,UtilidadesGenericas.UsuarioCodigo);
            if (x > 0)
            {
                txtCodDoc.Text = x.ToString();
                BuscarDocumento();
                buscarDados();
                return;
            }
            else
            {
                if (!string.IsNullOrEmpty(CodDocumento))
                {
                    txtCodDoc.Text = CodDocumento;
                    if (!string.IsNullOrEmpty(txtCodDoc.Text))
                    {
                        BuscarDocumento();
                        buscarDados();

                    }
                }
            }

        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            var form = IOC.InjectForm<frmInteligente>();
            var tipoSaida = form.GetSelecionado<TiposQuartosHospitalarViewModel>("TipoSaida", "Finalidade de Pagamento");

            if (Equals(tipoSaida, null))
            {
                return;
            }
            else
            {
                txtCodFinalidade.Text = tipoSaida.Codigo.ToString();
                txtFinalidade.Text = tipoSaida.Descricao;
            }

        }

        private void btnEntidade_Click(object sender, EventArgs e)
        {
            var form = IOC.InjectForm<frmEntidadeBusca>();
            var recebe=form.GetEntidadeSelecionada();
            codEntidade = recebe.Codigo;
            txtCodEntidade.Text = codEntidade.ToString();
            txtEntidade.Text = recebe.Nome;
        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Imprimir();
        }
        private void Imprimir()
        {
            NotaPagamentoViewModel dados = new NotaPagamentoViewModel()
            {
                Finalidade = txtFinalidade.Text,
                CodCliente = int.Parse(txtCodEntidade.Text),
                Cliente = txtEntidade.Text,
                CodDocumento = int.Parse(txtCodDoc.Text),
                Documento = _DocumentosApp.GetById(int.Parse(txtCodDoc.Text)),
                Data = ListDoc[0].Data,
                Funcionario = ListDoc[0].Usuario,
                Hora = ListDoc[0].Hora,
                Obs = txtObservacao.Text

            };
            IOC.InjectForm<frmImprimirReport>().ApresentarReportNotaPagamento(dados, LtPagamento);
        }
        private void simpleButton10_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnFechar2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
    }
