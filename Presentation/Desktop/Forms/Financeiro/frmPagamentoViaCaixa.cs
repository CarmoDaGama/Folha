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
using Folha.Domain.Models.Financeiro;
using Folha.Domain.Interfaces.Application.Financeiro;
using Folha.Domain.Interfaces.Application.Documentos;
using Folha.Presentation.Desktop.Separadores.Entidades;
using Folha.Driver.Framework.IOC;
using Folha.Domain.ViewModels.Frame.Documentos;
using Folha.Domain.ViewModels.Frame.Financeiro;
using Folha.Domain.ViewModels.Financeiro;
using Folha.Domain.Helpers;

namespace Folha.Presentation.Desktop.Separadores.Financeiro
{
    public partial class frmPagamentoViaCaixa : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private string _Tipo;
        private string _NDocumento;
        private string _Total;
        private string _codEntidade;
        private string _NomeEntidade;
        private string _Documento;
        private string _Descritivo;
        private DateTime _Data;
        private string ValorTotalPadrao;
        private readonly IMoedaApp _MoedaApp;
        private List<Moedas> ListMoedaCambio=new List<Moedas>();
        private List<Cambio> LtCambios = new List<Cambio>();
        private List<Caixas> LtCaixas = new List<Caixas>();
        List<MostraMoedasViewModel> ListMoeda = new List<MostraMoedasViewModel>();

        //int CodCambio = 0;
        int codCaixa;
        private readonly ICaixasApp _CaixasApp;
        private readonly ICambioApp _CambioApp;
        private readonly IPagamentosApp _PagamentosApp;

        public frmPagamentoViaCaixa(IMoedaApp MoedaApp, IPagamentosApp PagamentosApp, ICaixasApp CaixasApp,ICambioApp CambioApp)
        {
            InitializeComponent();
            _MoedaApp = MoedaApp;
            _PagamentosApp = PagamentosApp;
            _CaixasApp = CaixasApp;
            _CambioApp = CambioApp;
            ListMoeda = (List<MostraMoedasViewModel>)_MoedaApp.Listar();
        }
        public void ReceberParametros(string Tipo, string NDocumento, string Total, string codEntidade, string NomeEntidade, string Documento, string Descritivo, DateTime Data)
        {
            _Tipo = Tipo; _NDocumento = NDocumento; _Total = Total; _codEntidade = codEntidade; _NomeEntidade = NomeEntidade; _Documento = Documento; _Descritivo = Descritivo; _Data = Data;
            ShowDialog();
        }

        private void frmPagamentoViaCaixa_Load(object sender, EventArgs e)
        {
            txtDocumento.Text = _Documento;
            txtCodDoc.Text = _NDocumento;
            txtCodEntidade.Text = _codEntidade;
            txtEntidade.Text = _NomeEntidade;             
            txtDescricao.Text = _Descritivo;
            txtValor.Text = _Total;
            ValorTotalPadrao = _Total;

           
            cboMoeda.Properties.Items.Add(UtilidadesGenericas.Moeda);

            ListMoedaCambio = (List<Moedas>)_MoedaApp.ListarMoedaCambio();
            LtCambios = (List<Cambio>)_CambioApp.Listar();

            //for (int i = 0; i < ListMoedaCambio.Count; i++)
            //{
            //    cboMoeda.Properties.Items.Add(ListMoedaCambio[i].Sigla);
            //}
            if (cboMoeda.Properties.Items.Count > 0) cboMoeda.SelectedItem = UtilidadesGenericas.Moeda;

            //if (string.IsNullOrEmpty(txtCodigo.Text) == false)
            //{
            //    cmdImprimir.Visible = true;
            //}


            LtCaixas =(List<Caixas>) _CaixasApp.Meus_Caixas();

            for (int i = 0; i < LtCaixas.Count; i++)
            {
                cboCaixas.Properties.Items.Add(LtCaixas[i].Descricao.ToString());
            }
            cboCaixas.SelectedIndex = 0;
        }

        private void btnEntidade_Click(object sender, EventArgs e)
        {
            var chamada = IOC.InjectForm<frmEntidadeBusca>().GetEntidadeSelecionada();

            if (chamada.Codigo!=0)
            {
                txtCodEntidade.Text = chamada.Codigo.ToString();
                txtEntidade.Text = chamada.Nome;
                
            }
        }

        private void btnFechar_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Dispose();
        }

        private void btnSalvar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Double _valor = 0;
            double Saldo = 0;
            _valor = double.Parse(txtValor.Text);
            Saldo = double.Parse(txtSaldo.Text);

            if(Saldo<0)
            {
                MessageBox.Show("Saldo negativo.", "Transferência Via Caixa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (double.Parse(txtValor.Text) == 0)
            {
                MessageBox.Show("O pagamento deve ser superior a zero", "Informe outro Pagamento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _PagamentosApp.EfectuarPagamentosCx(new DadosPagamentoViewModel()
            {
                CodDoc = int.Parse(txtCodDoc.Text),
                Descricao = txtDescricao.Text,
                Valor = _valor,
                CodCaixa = LtCaixas[cboCaixas.SelectedIndex].codigo,
                Data = _Data,
                CodMoeda = int.Parse(ListMoeda[cboMoeda.SelectedIndex].Codigo.ToString())
                /*---codcambio*/
            });


            this.Close();
        }

        private void TotalizarCaixa()
        {

            double x = _CaixasApp.buscarSaldoCaixa(codCaixa);
            txtSaldo.Text = x.ToString("N2");

        }

        private void cboCaixas_SelectedIndexChanged(object sender, EventArgs e)
        {
            codCaixa = int.Parse(LtCaixas[cboCaixas.SelectedIndex].codigo.ToString());
            TotalizarCaixa();
        }

        private void cboMoeda_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bbiEdit_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
    }
}