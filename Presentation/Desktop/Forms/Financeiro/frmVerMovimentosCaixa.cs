using System;
using System.Windows.Forms;
using SimpleInjector;
using Folha.Presentation.Desktop.Separadores.Entidades;
using Folha.Driver.Framework.IOC;
using Folha.Domain.Interfaces.Application.Financeiro;
using System.Data;
using Folha.Domain.ViewModels.Frame;
using System.Collections.Generic;
using Folha.Domain.Models.Financeiro;
using Folha.Domain.Interfaces.Application.Documentos;
using Folha.Domain.Helpers;

namespace Folha.Presentation.Desktop.Separadores.Financeiro
{
    public partial class frmVerMovimentosCaixa : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly ICaixasApp _CaixasApp;
        private readonly IPagamentosApp _PagamentosApp;
        int codCaixa=0;
        List<Caixas> LtCaixas;
        private readonly IDocumentosApp _DocumentosApp;

        public frmVerMovimentosCaixa(ICaixasApp CaixasApp, IPagamentosApp PagamentosApp, IDocumentosApp DocumentosApp)
        {
            InitializeComponent();
            _CaixasApp = CaixasApp;
            _PagamentosApp = PagamentosApp;
            _DocumentosApp = DocumentosApp;
        }
        private void btnTranferenciaCaixa_Click(object sender, EventArgs e)
        {
            if (UtilidadesGenericas.EstadoTurnoSistema)
            {
                frmTransferenciaCaixa chamada = IOC.InjectForm<frmTransferenciaCaixa>();
                chamada.ShowDialog();
                CarregarDocumentos();
            }
            else MessageBox.Show(
                    "Turno Está fechado!",
                    "Mensagem",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Stop
                );
        }

        private void btnTransferirBanco_Click(object sender, EventArgs e)
        {
            if (UtilidadesGenericas.EstadoTurnoSistema)
            {
                frmTransferenciaBanco chamada = IOC.InjectForm<frmTransferenciaBanco>();
                chamada.ShowDialog();
                CarregarDocumentos();
            }
            else MessageBox.Show(
                   "Turno Está fechado!",
                   "Mensagem",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Stop
               );
        }

        private void frmVerMovimentosCaixa_Load(object sender, EventArgs e)
        {
            dtinicio.Text = DateTime.Now.ToShortDateString();
            dtfim.Text = DateTime.Now.ToShortDateString();
            dtinicio.Properties.MaxValue = DateTime.Now;
            dtfim.Properties.MaxValue = DateTime.Now;

            cboTipo.Properties.Items.Add("TODOS");
            cboTipo.Properties.Items.Add("CREDITO");
            cboTipo.Properties.Items.Add("DEBITO");
            cboTipo.SelectedIndex = 0;

            cboCaixas.Properties.Items.Add("Todos Caixas");

            CarregaCaixas();
            cboCaixas.SelectedIndex = 0;

        }
        private void CarregaCaixas()
        {
            LtCaixas = new List<Caixas>();
            try
            {
                 LtCaixas = (List < Caixas >) _PagamentosApp.Meus_Caixas();
                for (int i = 0; i < LtCaixas.Count; i++)
                {
                    cboCaixas.Properties.Items.Add(LtCaixas[i].Descricao.ToString());
                }
            }
            catch (Exception) { MessageBox.Show("Erro a Carregar Caixas\n", "", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void cboCaixas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboCaixas.SelectedIndex!=0)
                codCaixa = int.Parse(LtCaixas[cboCaixas.SelectedIndex-1].codigo.ToString());
                
                if (cboCaixas.SelectedIndex != 0)
                {
                    double x = _CaixasApp.buscarSaldoCaixa(codCaixa);
                    txtSaldoTotalcx.Text = x.ToString("N2");
                }
                else if(cboCaixas.SelectedIndex==0) txtSaldoTotalcx.Text = "0,00";
            }

            catch { }

            CarregarDocumentos();
        }
        private void CarregarDocumentos()
        {
            if (string.IsNullOrEmpty(dtinicio.Text) || string.IsNullOrEmpty(dtfim.Text)) { MessageBox.Show("Deve ser Informado um Intervalo de Tempo", "Movimentos de Caixas", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            DateTime inicio = DateTime.Parse(dtinicio.Text);
            DateTime termino = DateTime.Parse(dtfim.Text);
            string criterios = "Pagamentos.CodForma=1";

            if (cboCaixas.SelectedItem.ToString() != "Todos Caixas")
            {
                criterios = criterios + " and " + "Pagamentos.CodCaixa='" + codCaixa.ToString() + "'";
            }
            if (dtinicio.Text != "" && dtfim.Text != "")
            {

                criterios = criterios + " and " + "Pagamentos.Data between '" + inicio.ToString("yyyy-MM-dd") + "' and '" + termino.ToString("yyyy-MM-dd") + "'";
            }
            if (cboTipo.SelectedItem.ToString() != "TODOS")
            {
                criterios = criterios + " and Pagamentos.Tipo like '" + cboTipo.SelectedItem.ToString() + "'";
            }

            try
            {
               
                gradeMovimentoCaixa.DataSource = _PagamentosApp.ListarMovCaixa(criterios); 

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro A Carregar Documentos\n" + ex);
            }
            try
            {
                double soma = 0;
                double debito = 0;
                double credito = 0;

                for (int i = 0; i < gvCaixa.RowCount; i++)
                {
                    soma = double.Parse(gvCaixa.GetRowCellValue(i, "Valor").ToString());

                    //if (!gvCaixa.GetRowCellValue(i, "Sigla").ToString().Equals(Conexao.MoedaPadrao.Sigla))
                    //{
                    //    int Cambio = int.Parse(gvCaixa.GetRowCellValue(i, "Cambio").ToString());

                    //    soma = double.Parse(Geral.ConverterMoeda(soma, Geral.TaxadeCambio(Cambio), true));
                    //}

                    if (gvCaixa.GetRowCellValue(i, "Tipo").ToString() == "DEBITO") debito += soma;
                    if (gvCaixa.GetRowCellValue(i, "Tipo").ToString() == "CREDITO") credito += soma;

                }

                soma = credito - debito;
                txtSaldo.Text = soma.ToString("N2");
            }
            catch (Exception ex) { MessageBox.Show("Erro \n" + ex); }

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CarregarDocumentos();
        }

        private void dtinicio_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dtfim.Properties.MinValue = DateTime.Parse(dtinicio.Text);
            }
            catch { }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnActualizar_Click_1(object sender, EventArgs e)
        {
            CarregarDocumentos();

        }
    }
}