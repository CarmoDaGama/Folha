using DevExpress.XtraBars;
using Folha.Domain.Interfaces.Application.Documentos;
using Folha.Domain.Interfaces.Application.Financeiro;
using Folha.Domain.Models.Financeiro;
using Folha.Domain.Models.Documentos;
using Folha.Driver.Framework.IOC;
using Folha.Domain.ViewModels.Financeiro;
using Folha.Domain.ViewModels.Frame.Documentos;
using Folha.Domain.ViewModels.Frame.Financeiro;
using Folha.Presentation.Desktop.Separadores.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Folha.Domain.Helpers;

namespace Folha.Presentation.Desktop.Separadores.Financeiro
{
    public partial class frmPagamentoViaBanco : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly IPagamentosApp _PagamentosApp;
        private string _Tipo;
        private string _Documento;
        private string _Descritivo;
        private DateTime _Data;
        private string _NomeEntidade;
        private string _codEntidade;
        private string _Total;
        private string _NDocumento;
        private List<MostraMoedasViewModel> ListMoeda;
        private string ValorTotalPadrao;
        private List<Moedas> ListMoedaCambio;
        private IMoedaApp _MoedaApp;
        private List<Cambio> LtCambios = new List<Cambio>();
        private readonly IFPagamentosApp _FPagamentosApp;
        private List<Mostrar> LtConta;
        private int codconta;
        private readonly IDocumentosApp _DocumentosApp;
        private readonly IContaBancariaApp _ContaBancariaApp;

        public frmPagamentoViaBanco(IPagamentosApp PagamentosApp, IMoedaApp MoedaApp, IFPagamentosApp FPagamentosApp,IDocumentosApp DocumentosApp,IContaBancariaApp ContaBancariaApp)
        {
            InitializeComponent();
            _PagamentosApp = PagamentosApp;
            _MoedaApp = MoedaApp;
            _FPagamentosApp = FPagamentosApp;
            _DocumentosApp = DocumentosApp;
            _ContaBancariaApp = ContaBancariaApp;
            ListMoeda = (List<MostraMoedasViewModel>)_MoedaApp.Listar();
        }
        public void ReceberParametros(string Tipo, string NDocumento, string Total, string codEntidade, string NomeEntidade, string Documento, string Descritivo, DateTime Data)
        {
            _Tipo = Tipo; _NDocumento = NDocumento; _Total = Total; _codEntidade = codEntidade; _NomeEntidade = NomeEntidade; _Documento = Documento; _Descritivo = Descritivo; _Data = Data;
            ShowDialog();

        }
        private void btnSalvar_ItemClick(object sender, ItemClickEventArgs e)
        {
             Double _valor = 0;
            _valor = double.Parse(txtValor.Text);
            double saldo = double.Parse(txtSaldo.Text);
            if (saldo< 0)
            {
                MessageBox.Show("Saldo negativo", "Transferência Via Banco", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty( cboContaBancaria.Text))
            {
                MessageBox.Show("Não Existe Conta bancária cadastrada", "Cadastre Contas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            fPagamentos dados = _FPagamentosApp.GetByCodConta(LtConta[cboContaBancaria.SelectedIndex].Codigo);
            if (dados == null) { MessageBox.Show("Não existe forma de pagamento veínculado com a conta", "Tranferência Via Banco", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            _PagamentosApp.EfectuarPagamentosBn(new DadosPagamentoViewModel()
            {
                CodDoc = int.Parse(txtCodDoc.Text),
                Descricao = txtDescricao.Text,
                Valor = _valor,
                CodConta = LtConta[cboContaBancaria.SelectedIndex].Codigo,
                Data = _Data,
                CodMoeda = int.Parse(ListMoeda[cboMoeda.SelectedIndex].Codigo.ToString())
                /*---codcambio*/
            });
            this.Close();
        }

        private void frmPagamentoViaBanco_Load(object sender, EventArgs e)
        {
            txtDoc.Text = _Documento;
            txtCodDoc.Text = _NDocumento;
            txtCodEntidade.Text = _codEntidade;
            txtEntidade.Text = _NomeEntidade;
            txtDescricao.Text = _Descritivo;
            txtValor.Text = _Total;
            ValorTotalPadrao = _Total;


            cboMoeda.Properties.Items.Add(UtilidadesGenericas.Moeda);

            ListMoedaCambio = (List<Moedas>)_MoedaApp.ListarMoedaCambio();
            //DtCambios = Conexao.BuscarTabela_com_Criterio("Cambios", "estado=1");

            //for (int i = 0; i < ListMoedaCambio.Count; i++)
            //{
            //    cboMoeda.Properties.Items.Add(ListMoedaCambio[i].Sigla);
            //}

            if (cboMoeda.Properties.Items.Count > 0) cboMoeda.SelectedItem = UtilidadesGenericas.Moeda;

            timeData.Text = DateTime.Now.ToShortDateString();
            timeData.Properties.MaxValue = DateTime.Now;

            LtConta = (List<Mostrar>)_DocumentosApp.MostrarFPagamento();
            LtConta.RemoveAt(0);
            for (int i = 0; i < LtConta.Count; i++)
            {
                cboContaBancaria.Properties.Items.Add(LtConta[i].Descricao.ToString());
            }
        }

        private void btnFechar_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Dispose();
        }

        private void btnEntidade_Click(object sender, EventArgs e)
        {
            var chamada = IOC.InjectForm<frmEntidadeBusca>().GetEntidadeSelecionada();

            if (chamada.Codigo != 0)
            {
                txtCodEntidade.Text = chamada.Codigo.ToString();
                txtEntidade.Text = chamada.Nome;

            }
        }

        private void cboContaBancaria_SelectedIndexChanged(object sender, EventArgs e)
        {
            codconta = int.Parse(LtConta[cboContaBancaria.SelectedIndex].Codigo.ToString());
            int codBanco = int.Parse(LtConta[cboContaBancaria.SelectedIndex].CodBanco.ToString());
            txtSaldo.Text = _ContaBancariaApp.buscarSaldoBanco(codBanco).ToString("N2");
        }

    }
}