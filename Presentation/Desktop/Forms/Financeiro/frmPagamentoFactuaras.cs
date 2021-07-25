using System;
using System.Collections.Generic;
using Folha.Presentation.Desktop.Separadores.Entidades;
using Folha.Driver.Framework.IOC;
using Folha.Domain.Interfaces.Application.Financeiro;
using DevExpress.XtraGrid.Views.Grid;
using Folha.Presentation.Desktop.Forms.Financeiro;
using Folha.Domain.ViewModels.Frame.Financeiro;
using Folha.Domain.Interfaces.Application.Inventario;
using Folha.Presentation.Desktop.Classe;
using Folha.Domain.ViewModels.Documentos;
using Folha.Domain.Interfaces.Application.Documentos;
using Folha.Domain.Interfaces.Application.Sistema;
using Folha.Domain.ViewModels.Entidades;
using Folha.Domain.Helpers;
using DevExpress.XtraBars.Ribbon;

namespace Folha.Presentation.Desktop.Separadores.Financeiro
{
    public partial class frmFacturaRecibo : RibbonForm
    {
        public int vida;
        private readonly ILiquidacaoDocApp _LiquidacaoDocApp;
        private readonly IMovArtigosApp _MovArtigosApp;
        private readonly IPagamentosApp _pagamentosAapp;
        private List<LiquidacaoDocViewModel> listaLiquidar;
        private readonly IDocumentosApp _documentosApp;
        private readonly IOperacoesApp _operacoesApp;
        private int indexGrid;

        public EntidadesViewModel Consumidor { get; private set; }

        public frmFacturaRecibo(ILiquidacaoDocApp LiquidacaoDocApp,
            IMovArtigosApp MovArtigosApp, 
            IPagamentosApp pagamentosApp,
            IDocumentosApp documentosApp,
            IOperacoesApp operacoesApp)
        {
            InitializeComponent();
            txtDoc.Text = "FACTURA";
            _MovArtigosApp = MovArtigosApp;
            _LiquidacaoDocApp = LiquidacaoDocApp;
            _pagamentosAapp = pagamentosApp;
            _documentosApp = documentosApp;
            _operacoesApp = operacoesApp;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public frmFacturaRecibo GetThis()
        {
            btnClose.Visible = false;
            return this;
        }
        private void btnEntidade_Click(object sender, EventArgs e)
        {
           var form = IOC.InjectForm<frmEntidadeBusca>();

            Consumidor = form.GetEntidadeSelecionada();
            if (Equals(Consumidor, null))
            {
                return;
            }
            else
            {
                if (Consumidor.Codigo!=0)
                txtCodEntidade.Text = Consumidor.Codigo.ToString();
                txtEntidade.Text = Consumidor.Nome;
            }
            BuscarDocumentos();

        }
        private void BuscarDocumentos()
        {

            listaLiquidar = (List<LiquidacaoDocViewModel>)_LiquidacaoDocApp.Listar(txtCodEntidade.Text);
            gridDoc.DataSource = listaLiquidar;

            double Total = 0;
            for (int i = 0; i < gridViewDoc.RowCount; i++)
            {
                Total += double.Parse(gridViewDoc.GetRowCellValue(i, "Total").ToString());
            }
            txtTotal.Text = Total.ToString("N2");
            if (gridViewDoc.RowCount > 0)
            {
                btnPagar.Enabled = true;
            }
            else
            {
                btnPagar.Enabled = false;
            }
        }
        
        public void RecebeDivida(int CodEntidade, string NomeEntidade)
        {

            if (CodEntidade==0 && string.IsNullOrEmpty(NomeEntidade))
            {
                return;
            }
            else
            {
                txtCodEntidade.Text = CodEntidade.ToString();
                txtEntidade.Text = NomeEntidade;
                txtEntidade.Enabled = false;
            }
            BuscarDocumentos();
            ShowDialog();
            Close();
        }

        private void gridDoc_DoubleClick(object sender, EventArgs e)
        {

        }

        private void gridViewDoc_DoubleClick_1(object sender, EventArgs e)
        {
            Liquidar();
        }

        private void frmReceberPagamento_Load(object sender, EventArgs e)
        {
            txtdata.Text = DateTime.Now.ToShortDateString();
        }

        private void gridViewDoc_RowClick(object sender, RowClickEventArgs e)
        {
            indexGrid = e.RowHandle;
        }

        private void gridViewDoc_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            indexGrid = e.RowHandle;
        }

        private void btnVoltar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void gridDoc_Click(object sender, EventArgs e)
        {
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            Liquidar();
        }

        private void Liquidar()
        {
            var docs = gridViewDoc.GetSelectedRows();
            var CodsDocumento = new DadosPagarViewModel[docs.Length];
            for (int i = 0; i < docs.Length ; i++)
            {
                var codDocumento = Convert.ToInt16(gridViewDoc.GetRowCellValue(docs[i], "Codigo"));
                var total = Convert.ToDecimal(gridViewDoc.GetRowCellValue(docs[i], "Total"));
                CodsDocumento[i] = new DadosPagarViewModel();
                CodsDocumento[i].CodCocumento = codDocumento;
                CodsDocumento[i].TotalDocumento = total;
            }
            var codDocumentoRG = IOC.InjectForm<frmReceberPagamentos>().ReceberPagmentoDocumento(CodsDocumento, 0, Consumidor.Codigo);
            if (codDocumentoRG > 0)
            {
                IOC.InjectForm<frmImprimirReport>().ImprimirRecibo(_pagamentosAapp.GetAllCriditoByDoc(codDocumentoRG));

            }

            listaLiquidar = (List<LiquidacaoDocViewModel>)_LiquidacaoDocApp.Listar(txtCodEntidade.Text);
            gridDoc.DataSource = listaLiquidar;
            Controle.LimpaControle(txtCodEntidade, txtEntidade, txtTotal);
        }
    }
}