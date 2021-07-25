using System;
using Folha.Domain.Interfaces.Application.Financeiro;
using Folha.Domain.Interfaces.Application.Documentos;
using Folha.Domain.Interfaces.Application.Inventario;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using Folha.Driver.Framework.IOC;
using Folha.Presentation.Desktop.Forms.Turnos;
using Folha.Domain.Helpers;
using System.Collections.Generic;
using Folha.Domain.ViewModels.Frame.Financeiro;
using DevExpress.XtraBars;
using Folha.Domain.Interfaces.Application.Sistema;
using Folha.Domain.Models.Financeiro;
using System.Linq;
using Folha.Domain.ViewModels.Inventario;

namespace Folha.Presentation.Desktop.Separadores.Principal
{
    using Domain.Models.Inventario;
    using Folha.Domain.ViewModels.Sistema;
    public enum OperacaoMeuTurno
    {
        Ver, Confirmar, AbrirOuFechar
    }
    public partial class frmMeuTurno : XtraForm
    {
        private readonly ICaixasApp _CaixaApp;
        private readonly IDocumentosApp _DocumentosApp;
        private readonly IPagamentosApp _PagamentosApp;
        private readonly IMovArtigosApp _MovArtigosApp;
        private readonly ITurnosApp _TurnoApp;
        private readonly IArmazemApp _ArmazensApp;

        private List<CaixaViewModel> dadosCaixas;
        private List<PagamentosViewModel> pagamentos;
        private List<Caixas> caixas;

        private bool Confirmar { get; set; } = false;

        private int TurnoId { get; set; }
        private List<MovArtigoViewModel> ArtigosVendidos { get;  set; }
        private List<Armazens> ListaArmazens { get; set; }
        private Form FormChamou { get; set; }
        private OperacaoMeuTurno Operacao { get; set; }

        public frmMeuTurno(ITurnosApp appTurno, 
            ICaixasApp app, 
            IDocumentosApp appDocumentos, 
            IPagamentosApp appPagamentos, 
            IMovArtigosApp appMovArtigos,
            IArmazemApp armazensApp)
        {
            InitializeComponent();
            _CaixaApp = app;
            _DocumentosApp = appDocumentos;
            _PagamentosApp = appPagamentos;
            _MovArtigosApp = appMovArtigos;
            _TurnoApp = appTurno;
            _ArmazensApp = armazensApp;
            UtilidadesGenericas.CodigoTurno = _TurnoApp.BuscaCodigoTurno(UtilidadesGenericas.UsuarioCodigo);
            TurnoId = UtilidadesGenericas.CodigoTurno;
        }
        private void CarregarArmazens()
        {
            cboArmazem.Properties.Items.Clear();
            ListaArmazens = (List<Armazens>)_ArmazensApp.Listar(null,   false);
            if (!UtilidadesGenericas.ListaNula(ListaArmazens))
            {
                cboArmazem.Properties.Items.Add("Todos");
                foreach (var item in ListaArmazens)
                {
                    cboArmazem.Properties.Items.Add(item.descricao);
                }
           
                cboArmazem.SelectedItem = ListaArmazens[0].descricao;
            }
        }
        public void ConfirmarTurno(int codTurno)
        {
            TurnoId = codTurno;
            Confirmar = true;
            Operacao = OperacaoMeuTurno.Confirmar;
            panelBottom.Visible = Confirmar;
            txtCodigoSupervisor.Text = UtilidadesGenericas.UsuarioCodigo.ToString();
            txtNomeSupervisor.Text = UtilidadesGenericas.NomeUsuario;
            ShowDialog();
        }

        public frmMeuTurno ConfirmarTurno(Form formChamou, short codTurno)
        {
            FormChamou = formChamou;
            Operacao = OperacaoMeuTurno.Confirmar;
            TurnoId = codTurno;
            Confirmar = true;
            panelBottom.Visible = Confirmar;
            txtCodigoSupervisor.Text = UtilidadesGenericas.UsuarioCodigo.ToString();
            txtNomeSupervisor.Text = UtilidadesGenericas.NomeUsuario;
            return this;
        }
        public void VerTurno(int codTurno)
        {
            TurnoId = codTurno;
            Confirmar = false;
            Operacao = OperacaoMeuTurno.Ver;
            panelBottom.Visible = false;
            ShowDialog();
        }
        public frmMeuTurno VerTurno(Form formChamou, int codTurno)
        {
            FormChamou = formChamou;
            TurnoId = codTurno;
            Operacao = OperacaoMeuTurno.Ver;
            Confirmar = false;
            panelBottom.Visible = true;
            return this;
        }
        private void frmMeuTurno_Load(object sender, EventArgs e)
        {
            CarregarTurno();
            if (Confirmar)
             {
                carregarCaixas();
            }
        }
        private void carregarCaixas()
        {
            caixas = (List<Caixas>)_CaixaApp.Listar(string.Empty);
            cboCaixas.Properties.Items.Clear();
            foreach (var item in caixas)
            {
                cboCaixas.Properties.Items.Add(item.Descricao);
            }
        }

        private void btnDadosGerais_Click(object sender, EventArgs e)
        {
            navigationFrame1.SelectedPage = UtilidadesGenericas.NavegarNoFrame(sender, navigationFrame1.Controls);
            var name = UtilidadesGenericas.GetNameNavegarNoFrame(sender);
            switch (name)
            {
                case "Documento":
                    if (gridDocumentos.RowCount == 0)
                    {
                        gridControlDocumentos.DataSource = _DocumentosApp.ListarDocumentos(TurnoId.ToString(), "");
                    }
                    break;

                case "Financeiro":
                    if (gridPagamentos.RowCount == 0)
                    {
                        pagamentos = _PagamentosApp.ListarPagamentos(TurnoId.ToString(), "");
                        gridControlPagamentos.DataSource = pagamentos;
                    }
                    break;

                case "ProdutosVendidos":
                    if (gridMovArtigos.RowCount == 0)
                    {
                        CarregarArmazens();
                        CarregarMovArtigos();
                    }
                    break;

                default:
                    break;
            }
        }

        private void textEdit3_EditValueChanged(object sender, EventArgs e)
        {

        }
        private void alterarTurno<T>(string nomeMetodo) where T : class
        {
            var form = IOC.InjectForm<T>();
            form.GetType().GetMethod(nomeMetodo).Invoke(form, new object[] {});
            if (UtilidadesGenericas.Alterou)
            {
                frmMeuTurno_Load(this, EventArgs.Empty);
            }
        }

        private void btnAbrirTurno_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (IOC.InjectForm<frmAbrirTurno>().AbrirTurno())
            {
                UtilidadesGenericas.EstadoTurnoSistema = true;
                UtilidadesGenericas.CodigoTurno = _TurnoApp.BuscaCodigoTurno(UtilidadesGenericas.UsuarioCodigo);
                TurnoId = UtilidadesGenericas.CodigoTurno;
                CarregarTurno();
                panelBottom.Visible = false;
                btnComfirmar.Enabled = false;
                btnAbrirTurno.Enabled = false;
                btnFecharTurno.Enabled = true;
            }
        }
        private void btnFecharTurno_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (_DocumentosApp.ContemDucumentosAberto(TurnoId))
            {
                MessageBox.Show("Não é possível fechar o turno pois existe documentos abertos!",
                    "Mensagem",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }
            var saldoTotal = 0.0m;
            var dado = dadosCaixas.Where(d => Equals(d.ItemCaixa.ToUpper(), "SALDO TOTAL")).FirstOrDefault();
            if (!Equals(dado, null))
            {
                saldoTotal = decimal.Parse(dado.Descricao.Replace("AKZ", string.Empty).Trim());
            }
            if (IOC.InjectForm<frmFecharTurno>().FecharTurno(saldoTotal, saldoTotal, 0.0m, TurnoId))
            {
                UtilidadesGenericas.EstadoTurnoSistema = false;
                UtilidadesGenericas.CodigoTurno = 0;
                TurnoId = 0;
                clearGrids();
                gridControlDadosGerais.DataSource = null;
                gridControlDocumentos.DataSource = null;
                gridControlMovArtigos.DataSource = null;
                gridControlPagamentos.DataSource = null;
                panelBottom.Visible = false;
                btnComfirmar.Enabled = false;
                btnAbrirTurno.Enabled = true;
                btnFecharTurno.Enabled = false;
            }
        }

        private void clearGrids()
        {
            gridControlDadosGerais.DataSource = null;
            gridControlDocumentos.DataSource = null;
            gridControlPagamentos.DataSource = null;
            gridControlMovArtigos.DataSource = null;
        }
        private void CarregarTurno()
        {
            var turno = _TurnoApp.GetById(TurnoId);
            if (!Equals (turno, null))
            {
                  
                verificarEstadoTurno(turno);
                dadosCaixas = _CaixaApp.BuscarTotal(UtilidadesGenericas.UsuarioCodigo, TurnoId.ToString(), "AKZ", "");
                gridControlDadosGerais.DataSource = dadosCaixas;


            }
            else if (!Confirmar)
            {
                btnAbrirTurno.Enabled = true;
                btnFecharTurno.Enabled = false;
            }
            else
            {
                panelBottom.Enabled = false;
            }
            dateConfirmacao.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
        }

        private void verificarEstadoTurno(TurnosViewModel turno)
        {
            var v = DateTime.Now - new DateTime();
            if (turno.Confirmado == "SIM")
            {
                btnAbrirTurno.Enabled = false;
                btnFecharTurno.Enabled = false;
                btnComfirmar.Enabled = false;
                panelBottom.Visible = true;
                panelBottom.Enabled = false;
                carregarCaixas();
                var resultTurno = caixas.Where(c => c.codigo == turno.CodCaixa).FirstOrDefault();
                if (!Equals(resultTurno, null))
                {
                    cboCaixas.SelectedItem = resultTurno.Descricao;
                }
                txtNomeSupervisor.Text = turno.Usuario.Nome;
                txtCodigoSupervisor.Text = turno.CodSuperVisor.ToString();
            }
            else if (turno.Estado == "ABERTO")
            {
                btnAbrirTurno.Enabled = false;
                btnFecharTurno.Enabled = true;
                btnComfirmar.Enabled = false;
                panelBottom.Visible = false;
            }
            else if (turno.Estado == "FECHADO")
            {
                btnAbrirTurno.Enabled = true;
                btnFecharTurno.Enabled = false;
                btnComfirmar.Enabled = false;
                panelBottom.Visible = true;
            }
            if (Confirmar)
            {
                btnAbrirTurno.Enabled = false;
                btnFecharTurno.Enabled = false;
                btnComfirmar.Enabled = true;
                panelBottom.Visible = true;
            }
            else
            {
                btnComfirmar.Enabled = false;
                //panelBottom.Visible = false;
            }
        }

        private void CarregarMovArtigos()
        {
            ArtigosVendidos = _MovArtigosApp.ListarMovArtigo("", GetIdArmazem(), TurnoId.ToString()); ;
            gridControlMovArtigos.DataSource = ArtigosVendidos;
            carregarTotais();
        }

        private string GetIdArmazem()
        {
            string id = "";
            var armazem = cboArmazem.SelectedItem.ToString();
            if (armazem != "Todos" && !string.IsNullOrEmpty(armazem))
            {
                id = ListaArmazens[cboArmazem.SelectedIndex - 1].codigo.ToString();
            }
            return id;
        }

        private void carregarTotais()
        {
            if (UtilidadesGenericas.ListaNula(ArtigosVendidos))
            {
                return;
            }
            var totalRetencao = 0.0m;
            var totalPrecoArtigos = 0.0m;
            var somaTotalArtigos = 0.0m;
            foreach (var item in ArtigosVendidos)
            {
                totalRetencao += item.Retencao;
                totalPrecoArtigos += item.TOTAL;
                somaTotalArtigos += item.QTDADE;
            }
            txtTotalRetencao.Text = totalRetencao.ToString("N2");
            txtTotalQtdArtigos.Text = somaTotalArtigos.ToString("N2");
            txtTotalProdutoVendido.Text = totalPrecoArtigos.ToString("N2");
            txtTotal40Percentual.Text = (totalPrecoArtigos * 0.4m).ToString("N2");
        }

        private void btnComfirmar_ItemClick(object sender, ItemClickEventArgs e)
        {

            if (cboCaixas.SelectedIndex <= -1)
            {
                UtilidadesGenericas.MsgShow("Selecione uma Caixa!", MessageBoxIcon.Stop);
                return;
            }
            if (!_TurnoApp.ContemTurnosComCaixasNulos(TurnoId))
            {
                UtilidadesGenericas.MsgShow("Não comtem Caixas  com turnos a Confirmar", MessageBoxIcon.Stop);
                return;
            }
            var codCaixa = caixas[cboCaixas.SelectedIndex].codigo;
            actualizarPagamentosComFormaNumeraria(codCaixa);
            _TurnoApp.ConfirmarTurno(codCaixa, int.Parse("1"), TurnoId);
            CarregarTurno();
            panelBottom.Enabled = false;
            btnComfirmar.Enabled = false;
            UtilidadesGenericas.MsgShow("Turnos confirmado com sucesso!", MessageBoxIcon.Information);
        }

        private void actualizarPagamentosComFormaNumeraria(int codCaixa)
        {
            if (UtilidadesGenericas.ListaNula(pagamentos))
            {
                btnDadosGerais_Click(btnFinanceiro, EventArgs.Empty);
                if (UtilidadesGenericas.ListaNula(pagamentos))
                    return;
            }
            foreach (var item in pagamentos)
            {
                int CodigoDoc = item.Numero;
                string forma = item.Forma;
                if (forma == "NUMERARIO")
                {
                    var pagamento = _PagamentosApp.GetById(CodigoDoc);
                    pagamento.CodCaixa = codCaixa;
                    _PagamentosApp.Update(pagamento);
                }
            }
        }

        private void btnActualizar_ItemClick(object sender, ItemClickEventArgs e)
        {
            CarregarTurno();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cboArmazem_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarMovArtigos();
        }

        private void gridControlPagamentos_Click(object sender, EventArgs e)
        {

        }

        private void frmMeuTurno_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!Equals(FormChamou, null))
            {
                UtilidadesGenericas.ChamarNoPrincipal(FormChamou);
            }
        }
    }
}