using System;
using DevExpress.XtraBars;
using SimpleInjector;
using Folha.Presentation.Desktop.Separadores.Entidades;
using Folha.Driver.Framework.IOC;
using Folha.Domain.Interfaces.Application.Documentos;
using DevExpress.DataAccess.Native.Data;
using Folha.Domain.ViewModels.Frame.Documentos;
using System.Collections.Generic;
using System.Windows.Forms;
using Folha.Domain.Interfaces.Application.Financeiro;
using Folha.Domain.ViewModels.Frame.Financeiro;
using Folha.Domain.Helpers;

namespace Folha.Presentation.Desktop.Separadores.Financeiro
{
    public partial class frmVerMovimentosBancarios : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly IBancosApp _BancoApp;

        private readonly IDocumentosApp _DocumentosApp;
        private readonly IPagamentosApp _PagamentosApp;
        List<MinhasContasBancariasViewModel> LtContasBancarias;
        List<ListarMovBancariosViewModel> LtMovBancarios;
        public frmVerMovimentosBancarios(IDocumentosApp DocumentosApp, IPagamentosApp PagamentosApp)
        { 
            InitializeComponent();
            _DocumentosApp = DocumentosApp;
            _PagamentosApp = PagamentosApp;  
            cboTipos.Properties.Items.Add("TODOS");
            cboTipos.Properties.Items.Add("CREDITO");
            cboTipos.Properties.Items.Add("DEBITO");
            cboTipos.SelectedIndex = 0;

        }
      
        private void frmVerMovimentosBancarios_Load(object sender, EventArgs e)
        {
            dtinicio.Text = DateTime.Now.ToShortDateString();
            dtfim.Text = DateTime.Now.ToShortDateString();
            dtinicio.Properties.MaxValue = DateTime.Now;
            dtfim.Properties.MaxValue = DateTime.Now;

            cboContas.Properties.Items.Add("TODAS CONTAS");
            CarregarContasBancarias();
            cboContas.SelectedIndex = 0;


            CarregarDocumentos();
            setSaldos();

        }
        private void setSaldos()
        {
            decimal saldo = 0.0m;
            foreach (var item in LtMovBancarios)
            {
                saldo += item.Valor;
            }
            txtTotal.Text = saldo.ToString("N2");
        }

        public void CarregarContasBancarias()
        {
            LtContasBancarias = new List<MinhasContasBancariasViewModel>();

            LtContasBancarias = (List < MinhasContasBancariasViewModel >) _DocumentosApp.ListarMinhasContasBancarias();
            try
            {
                for (int i = 0; i < LtContasBancarias.Count; i++)
                {
                    cboContas.Properties.Items.Add(LtContasBancarias[i].Banco.ToString());
                }
            }
            catch (Exception ex) { MessageBox.Show("Erro a Carregar as Contas Bancárias\n" + ex, "", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void CarregarDocumentos()
        {
            if (string.IsNullOrEmpty(dtinicio.Text) || string.IsNullOrEmpty(dtfim.Text)) { MessageBox.Show("Deve ser Informado um Intervalo de Tempo", "Movimentos de Banco", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            //GradeProdutos.Rows.Clear();

            string criterios = "";

            DateTime inicio = DateTime.Parse(dtinicio.Text);
            DateTime termino = DateTime.Parse(dtfim.Text);

            if (dtinicio.Text != "" && dtfim.Text != "")
            {
                criterios = criterios + " and " + "Pagamentos.Data between '" + inicio.ToString("yyyy-MM-dd") + "' and '" + termino.ToString("yyyy-MM-dd") + "'";
        }

            if (cboContas.SelectedIndex > 0)
            {
                criterios = criterios + " And Pagamentos.CodConta='" + LtContasBancarias[cboContas.SelectedIndex - 1].Codigo.ToString() + "'";
            }

            if (cboTipos.SelectedItem.ToString() != "TODOS")
            {
                criterios = criterios + " and Pagamentos.Tipo like '" + cboTipos.SelectedItem.ToString() + "'";
            }

            try
            {
                LtMovBancarios = new List<ListarMovBancariosViewModel>();
                LtMovBancarios = (List < ListarMovBancariosViewModel >) _PagamentosApp.ListarMovBancarios(criterios);
                GradeProdutos.DataSource = LtMovBancarios;

                double credito = 0; double Debito = 0; double Total = 0;
                for (int i = 0; i <gvGradeProdutos.RowCount; i++)
                {
                    Total = double.Parse(gvGradeProdutos.GetRowCellValue(i,"Valor").ToString());
                }
                Total = credito - Debito;
                txtTotal.Text = Total.ToString("N2");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro A Carregar Documentos\n" + ex, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cboContas_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarDocumentos();

        }

     

        private void btnActualizar_Click_1(object sender, EventArgs e)
        {
            CarregarDocumentos();

        }
    }
}