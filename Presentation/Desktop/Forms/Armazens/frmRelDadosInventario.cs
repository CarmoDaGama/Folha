using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using Folha.Domain.Interfaces.Application.Inventario;
using Folha.Domain.ViewModels.Inventario;
using Folha.Domain.Models.Inventario;
using Folha.Presentation.Desktop.Classe;
using Folha.Domain.ViewModels.Report;
using Folha.Presentation.Desktop.Forms.Apresenta_Doc;
using DevExpress.XtraEditors;

namespace Folha.Presentation.Desktop.Forms.Armazens
{
   
    public partial class frmRelDadosInventario : XtraForm
    {
        private readonly IArmazemApp _ArmazemApp;
        private List<Folha.Domain.Models.Inventario.Armazens> LtArmazens;
        private string NomeRelatorio;
        private readonly IArtigosApp _ArtigosApp;
        private List<RelListagemArtigosViewModel> LtArtigos;
        List<RelMovArtigosViewModel> LtMovArtigos;
        private readonly IArtigoStockApp _ArtigoStockApp;
        private DateTime inicio;
        private DateTime termino;
        DadosReportViewModel dados;
        
        public frmRelDadosInventario(IArmazemApp ArmazemApp,IArtigosApp ArtigosApp,IArtigoStockApp ArtigoStockApp)
        {
            InitializeComponent();
            _ArmazemApp = ArmazemApp;
            _ArtigosApp = ArtigosApp;
            _ArtigoStockApp = ArtigoStockApp;
        }

        //Metodos Print
        #region Print
        private void ResizeArmazem()
        {
            //Size
            Controle.DesabilitarControle(cboFiltar);
            Controle.VisivelControle(pnlArmazem);
            pnlData.Height = 1;
            var SIZEfORM = 0;
            SIZEfORM += pnlArmazem.Height;
            this.Size = new Size(this.Width, SIZEfORM);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            //-----------------------------------------------------
        }

        private void ResizeArmazemData()
        {
            //Size
            Controle.VisivelControle(pnlArmazem,pnlData);
            pnlPreco.Height = 1;
            pnlTipoStock.Height = 1;
            var SIZEfORM = 0;
            SIZEfORM += pnlArmazem.Height+pnlData.Height;
            this.Size = new Size(this.Width, SIZEfORM);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            //-----------------------------------------------------
        }
        private void ResizeArmazemPreco()
        {
            //Size
            Controle.VisivelControle(pnlArmazem,pnlPreco);
            pnlData.Height = 1;
            pnlTipoStock.Height = 1;
            var SIZEfORM = 0;
            SIZEfORM += pnlArmazem.Height +pnlPreco.Height;
            this.Size = new Size(this.Width, SIZEfORM);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            //-----------------------------------------------------
        }

        public void ImprimirListagemArtigos()
        {
            cboFiltar.SelectedIndex = 1;
            
            //Size
            Controle.DesabilitarControle(cboFiltar);
            Controle.VisivelControle(pnlPreco, pnlTipoStock, pnlArmazem);
            pnlData.Height = 1;
            var SIZEfORM = 0;
                SIZEfORM += pnlArmazem.Height+ pnlPreco.Height+pnlTipoStock.Height;
            this.Size = new Size(this.Width, SIZEfORM);
            //-----------------------------------------------------

            NomeRelatorio = "ListagemArtigos";
            lbRelatorio.Text = "Relatório - Listagem de Artigos";
            ShowDialog();
            Close();
        }
        public void ImprimirControloStockArmazem()
        {
            cboFiltar.SelectedIndex = 1;
            ResizeArmazem();
            NomeRelatorio = "ControloStockArmazem";
            lbRelatorio.Text = "Relatório - Controlo de Stock Por Armazem";
            ShowDialog();
            Close();
        }
        public void ImprimirRupturaStock()
        {
            cboFiltar.SelectedIndex = 1;
            ResizeArmazem();
            NomeRelatorio = "RupturaStock";
            lbRelatorio.Text = "Relatório - Ruptura de Stock";
            ShowDialog();
            Close();
        }
        public void ImprimirGrafMovArtigo()
        {
            cboFiltar.SelectedIndex = 1;
            ResizeArmazemData();
            NomeRelatorio = "GrafMovArtigos";
            lbRelatorio.Text = "Relatório - Gráfico de Movimentação de Artigos";
            ShowDialog();
            Close();
        }
        public void ImprimirGrafArtigosVendidos()
        {
            cboFiltar.SelectedIndex = 1;
           ResizeArmazem();
            NomeRelatorio = "GrafArtigosVendidos";
            lbRelatorio.Text = "Relatório - Gráfico de Artigos Mais Vendidos";
            ShowDialog();
            Close();
        }
        public void ImprimirMovArtigos()
        {
            cboFiltar.SelectedIndex = 1;
            ResizeArmazemData();
            NomeRelatorio = "MovArtigos";
            lbRelatorio.Text = "Relatório - Movimentação de Artigos";
            ShowDialog();
            Close();
        }
        public void ImprimirApoioContagem()
        {
            cboFiltar.SelectedIndex = 1;
            ResizeArmazem();
            NomeRelatorio = "ApoioContagem";
            lbRelatorio.Text = "Relatório - Apoio à Contagem";
            ShowDialog();
            Close();
        }
        public void ImprimirArtgSemControloStock()
        {
            cboFiltar.SelectedIndex = 1;
            ResizeArmazem();
            NomeRelatorio = "ArtgSemControloStock";
            lbRelatorio.Text = "Relatório - Artigos Sem Controlo de Stock";
            ShowDialog();
            Close();
        }
        public void ImprimirTabelaPreco()
        {
            cboFiltar.SelectedIndex = 1;
            ResizeArmazemPreco();
            NomeRelatorio = "TabelaPreco";
            lbRelatorio.Text = "Relatório - Tabela de Preços Por Armazém";
            ShowDialog();
            Close();
        }
        public void ImprimirListaPreco()
        {
            cboFiltar.SelectedIndex = 1;
            ResizeArmazem();
            NomeRelatorio = "ListaPrecoArmazem";
            lbRelatorio.Text = "Relatório - Lista de Preço Por Armazém";
            ShowDialog();
            Close();
        }
        public void ImprimirListaRetencao()
        {
            cboFiltar.SelectedIndex = 1;
            ResizeArmazemData();
            NomeRelatorio = "RetencaoArtigo";
            lbRelatorio.Text = "Relatório - Retenção de Artigos";
            ShowDialog();
            Close();
        }
        #endregion
        //-----------------------------------------------------------------------

        //Metodos e Carregamentos
        #region Metodos&Carregamentos
        private void loadData()
        {
            dtInicio.EditValue = DateTime.Today;
            dtFim.EditValue = DateTime.Today;
            dtInicio.Properties.MaxValue = DateTime.Now;
            dtFim.Properties.MaxValue = DateTime.Now;

            LtArmazens = (List<Folha.Domain.Models.Inventario.Armazens>)_ArmazemApp.Meus_Armazens();

            for (int i = 0; i < LtArmazens.Count; i++)
            {
                cboArmazem.Properties.Items.Add(LtArmazens[i].descricao);
            }
            if (cboArmazem.Properties.Items.Count > 0) cboArmazem.SelectedIndex = 0;
            cboPreco.SelectedIndex = 0;
            cboTipoStock.SelectedIndex = 0;
        }
        private void RecebeData()
        {
            inicio = DateTime.Parse(dtInicio.Text);
            termino = DateTime.Parse(dtFim.Text);
        }
        private void frmRelDadosInventario_Load(object sender, EventArgs e)
        {
            loadData();
        }
        private void BuscarListagemArtigos()
        {
            LtArtigos = (List<RelListagemArtigosViewModel>)_ArtigosApp.ListagemArtigos(cboPreco.Text, cboTipoStock.SelectedIndex, LtArmazens[cboArmazem.SelectedIndex].codigo);
            if (Equals(LtArtigos, null) || LtArtigos.Count == 0)
            {
                MessageBox.Show("Sem Relatório!", "Relatório Inventário", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            new frmApresentaReport().ApresentarRelListaArtigos(LtArtigos,cboArmazem.Text);
        }
        private void BuscarStockArmazem()
        {
            LtArtigos = (List<RelListagemArtigosViewModel>)_ArtigoStockApp.StoquePorProdutos(LtArmazens[cboArmazem.SelectedIndex].codigo);
            if (Equals(LtArtigos, null) || LtArtigos.Count == 0)
            {
                MessageBox.Show("Sem Relatório!", "Relatório Inventário", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            new frmApresentaReport().ApresentarRelControleStock(LtArtigos,NomeRelatorio,cboArmazem.Text);
        }
        private void BuscarApoioContagem()
        {
            LtArtigos = (List<RelListagemArtigosViewModel>)_ArtigoStockApp.ApoioContagem(LtArmazens[cboArmazem.SelectedIndex].codigo);
            if (Equals(LtArtigos, null) || LtArtigos.Count == 0)
            {
                MessageBox.Show("Sem Relatório!", "Relatório Inventário", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            new frmApresentaReport().ApresentarRelControleStock(LtArtigos,NomeRelatorio, cboArmazem.Text);
        }
        private void BuscarArtgSemControloStock()
        {
            LtArtigos = (List<RelListagemArtigosViewModel>)_ArtigosApp.SemControloStock(LtArmazens[cboArmazem.SelectedIndex].codigo);
            if (Equals(LtArtigos, null) || LtArtigos.Count == 0)
            {
                MessageBox.Show("Sem Relatório!", "Relatório Inventário", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            new frmApresentaReport().ApresentarRelArtgSemControleStock(LtArtigos,cboArmazem.Text);
        }
        private void BuscarTabelaPreco()
        {
            LtArtigos = (List<RelListagemArtigosViewModel>)_ArtigosApp.TabelaPreco(LtArmazens[cboArmazem.SelectedIndex].codigo,cboPreco.Text);
            if (Equals(LtArtigos, null) || LtArtigos.Count == 0)
            {
                MessageBox.Show("Sem Relatório!", "Relatório Inventário", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            new frmApresentaReport().ApresentarRelTabelaPreco(LtArtigos,cboArmazem.Text);
        }
        private void BuscarListaPrecoArmazem()
        {
            LtArtigos = (List<RelListagemArtigosViewModel>)_ArtigosApp.ListaPreco(LtArmazens[cboArmazem.SelectedIndex].codigo);
            if (Equals(LtArtigos, null) || LtArtigos.Count == 0)
            {
                MessageBox.Show("Sem Relatório!", "Relatório Inventário", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            new frmApresentaReport().ApresentarRelListaPrecoArmazem(LtArtigos, cboArmazem.Text);
        }
        private void RupturaStock()
        {
            LtArtigos = (List<RelListagemArtigosViewModel>)_ArtigoStockApp.RupturaStock(LtArmazens[cboArmazem.SelectedIndex].codigo.ToString());
            if (Equals(LtArtigos, null) || LtArtigos.Count == 0)
            {
                MessageBox.Show("Sem Relatório!", "Relatório Inventário", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            new frmApresentaReport().ApresentarRelRupturaStock(LtArtigos,cboArmazem.Text);
        }
        private void BuscaMovArtigos()
        {
            RecebeData();
            var Data = new DataViewModel();
            if(cboFiltar.Text=="Filtrar")
            LtMovArtigos = (List<RelMovArtigosViewModel>)_ArtigosApp.RelMovArtigos(inicio.ToString("yyyy-MM-dd"), termino.ToString("yyyy-MM-dd"),LtArmazens[cboArmazem.SelectedIndex].codigo);
            else
            {
                LtMovArtigos = (List<RelMovArtigosViewModel>)_ArtigosApp.RelMovArtigos(null, null, LtArmazens[cboArmazem.SelectedIndex].codigo);
                Data = _ArtigosApp.RetornaDataMovArtigo(LtArmazens[cboArmazem.SelectedIndex].codigo);

                if (Data == null) { MessageBox.Show("Sem Relatório!", "Relatório Inventário", MessageBoxButtons.OK, MessageBoxIcon.Information); return; };
                inicio = Data.DataInicial; termino = Data.DataFinal;
            }
              
            if (Equals(LtMovArtigos, null) || LtMovArtigos.Count == 0)
            {
                MessageBox.Show("Sem Relatório!", "Relatório Inventário", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            new frmApresentaReport().ApresentarRelMovArtigo(LtMovArtigos, inicio.ToShortDateString(), termino.ToShortDateString(),cboArmazem.Text);
        }
        private void BuscaGrafMovArtigos()
        {
            RecebeData();
            var Data = new DataViewModel();
            if (cboFiltar.Text == "Filtrar")
                LtMovArtigos = (List<RelMovArtigosViewModel>)_ArtigosApp.RelMovArtigos(inicio.ToString("yyyy-MM-dd"), termino.ToString("yyyy-MM-dd"), LtArmazens[cboArmazem.SelectedIndex].codigo);
            else
            {
                LtMovArtigos = (List<RelMovArtigosViewModel>)_ArtigosApp.RelMovArtigos(null, null, LtArmazens[cboArmazem.SelectedIndex].codigo);
                Data = _ArtigosApp.RetornaDataMovArtigo(LtArmazens[cboArmazem.SelectedIndex].codigo);

                if (Data == null) { MessageBox.Show("Sem Relatório!", "Relatório Inventário", MessageBoxButtons.OK, MessageBoxIcon.Information); return; };
                inicio = Data.DataInicial; termino = Data.DataFinal;
            }

            if (Equals(LtMovArtigos, null) || LtMovArtigos.Count == 0)
            {
                MessageBox.Show("Sem Relatório!", "Relatório Inventário", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            new frmApresentaReport().ApresentarRelGrafMovArtigo(LtMovArtigos, inicio.ToShortDateString(), termino.ToShortDateString(),cboArmazem.Text);
        }
        private void BuscaGrafArtigosVendidos()
        {
            RecebeData();
            var Data = new DataViewModel();
                LtMovArtigos = (List<RelMovArtigosViewModel>)_ArtigosApp.ArtigosVendidos(LtArmazens[cboArmazem.SelectedIndex].codigo);

            Data = _ArtigosApp.RetornaDataMovArtigo(LtArmazens[cboArmazem.SelectedIndex].codigo);
                if (Data == null) { MessageBox.Show("Sem Relatório!", "Relatório Inventário", MessageBoxButtons.OK, MessageBoxIcon.Information); return; };
                inicio = Data.DataInicial; termino = Data.DataFinal;

            if (Equals(LtMovArtigos, null) || LtMovArtigos.Count == 0)
            {
                MessageBox.Show("Sem Relatório!", "Relatório Inventário", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            new frmApresentaReport().ApresentarRelGrafArtigosVendidos(LtMovArtigos, inicio.ToShortDateString(), termino.ToShortDateString(),cboArmazem.Text);
        }
        private void BuscaRetencaoArtigos()
        {
            RecebeData();
            var Data = new DataViewModel();
            if (cboFiltar.Text == "Filtrar")
                LtArtigos = (List<RelListagemArtigosViewModel>)_ArtigosApp.ListagemRetenção(inicio.ToString("yyyy-MM-dd"), termino.ToString("yyyy-MM-dd"), LtArmazens[cboArmazem.SelectedIndex].codigo);
            else
            {
                LtArtigos = (List<RelListagemArtigosViewModel>)_ArtigosApp.ListagemRetenção(null, null, LtArmazens[cboArmazem.SelectedIndex].codigo);
                Data = _ArtigosApp.RetornaDataRetencao(LtArmazens[cboArmazem.SelectedIndex].codigo);
                if (Data == null) { MessageBox.Show("Sem Relatório!", "Relatório Inventário", MessageBoxButtons.OK, MessageBoxIcon.Information); return; };
                inicio = Data.DataInicial; termino = Data.DataFinal;
            }
            

            if (Equals(LtArtigos, null) || LtArtigos.Count == 0)
            {
                MessageBox.Show("Sem Relatório!", "Relatório Inventário", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            dados = new DadosReportViewModel()
            {
                DataInicio = inicio,
                DataFim=termino,
                Armazem= cboArmazem.Text
            };
            new frmApresentaReport().ApresentarRelRetencaoArtigos(LtArtigos,dados);
        }
        #endregion
        //-----------------------------------------------------------------------

        private void btnImprimir_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (NomeRelatorio == "ListagemArtigos")
                BuscarListagemArtigos();
            if(NomeRelatorio== "ControloStockArmazem")
                BuscarStockArmazem();
            if (NomeRelatorio == "RupturaStock")
                RupturaStock();
            if (NomeRelatorio == "MovArtigos")
                BuscaMovArtigos();
            if (NomeRelatorio == "GrafMovArtigos")
                BuscaGrafMovArtigos();
            if (NomeRelatorio == "GrafArtigosVendidos")
                BuscaGrafArtigosVendidos();
            if (NomeRelatorio == "ApoioContagem")
                BuscarApoioContagem();
            if (NomeRelatorio == "ArtgSemControloStock")
                BuscarArtgSemControloStock();
            if (NomeRelatorio == "TabelaPreco")
                BuscarTabelaPreco();
            if (NomeRelatorio == "ListaPrecoArmazem")
                BuscarListaPrecoArmazem();
            if (NomeRelatorio == "RetencaoArtigo")
                BuscaRetencaoArtigos();
        }
        private void btnVoltar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void cboFiltar_SelectedIndexChanged_1(object sender, EventArgs e)
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
    }
}