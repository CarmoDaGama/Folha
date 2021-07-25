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
using Folha.Domain.Interfaces.Application.Documentos;
using Folha.Domain.ViewModels.Report;
using Folha.Presentation.Desktop.Forms.Apresenta_Doc;
using Folha.Presentation.Desktop.Classe;
using Folha.Driver.Framework.IOC;
using Folha.Presentation.Desktop.Separadores.Entidades;
using Folha.Domain.ViewModels.Sistema;
using Folha.Domain.Interfaces.Application.Financeiro;
using Folha.Domain.Models.Financeiro;
using Folha.Presentation.Desktop.Forms.Utilitarios_Configuracoes;

namespace Folha.Presentation.Desktop.Forms.Principal
{
    public partial class frmRelDadosDocumentos : DevExpress.XtraEditors.XtraForm
    {
        private readonly IDocumentosApp _DocumentosApp;
        private string NomeRelatorio;
        private List<RelOpercoesViewModel> LtRelOperacoes;
        List<OpAcessoViewModel> LtOperacoes;
        private DateTime inicio;
        private DateTime termino;
        private int indexGrid=0;
        private readonly ICalculosFinanceiroApp _CalculosApp;
        List<Saldos> LtData = new List<Saldos>();
        private bool Editando=false;

        public frmRelDadosDocumentos(IDocumentosApp DocumentosApp, ICalculosFinanceiroApp CalculosApp)
        {
            InitializeComponent();
            _DocumentosApp = DocumentosApp;
            _CalculosApp = CalculosApp;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmRelDadosDocumentos_Load(object sender, EventArgs e)
        {
            if (!cboFiltar.Enabled) { lbFiltragem.Visible = false; cboFiltar.Visible = false; }

            dtInicio.EditValue = DateTime.Today;
            dtFim.EditValue = DateTime.Today;
            dtInicio.Properties.MaxValue = DateTime.Now;
            dtFim.Properties.MaxValue = DateTime.Now;
            dtData.EditValue = DateTime.Today;
            dtData.Properties.MaxValue = DateTime.Now;
            cboTipoOp.SelectedIndex = 0;
            PopulaGradeOp();
        }
        private void PopulaGradeOp()
        {
            LtOperacoes = (List<OpAcessoViewModel>)_DocumentosApp.Meus_Documentos("FINANCEIRO");
            gradeOperacoes.DataSource = LtOperacoes;
        }

        private void btnVoltar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
        private void ResizeFiltro2()
        {
            //Size
            Controle.InvisivelControle(pnlFiltro1, pnlData);
            pnlFiltro1.Height = 1;
            pnlData.Height = 1;
            var SIZEfORM = 0;
            SIZEfORM += pnlFiltro.Height + pnlFiltro2.Height;
            this.Size = new Size(this.Width, SIZEfORM);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            //-----------------------------------------------------
        }
        private void ResizeFiltro1()
        {
            //Size
            Controle.InvisivelControle(pnlFiltro2);
            pnlFiltro2.Height = 1;
            var SIZEfORM = 0;
            SIZEfORM += pnlFiltro.Height + pnlFiltro1.Height;
            this.Size = new Size(this.Width, SIZEfORM);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            //-----------------------------------------------------
        }

        public void ImprimirListaOp()
        {
            cboFiltar.SelectedIndex = 1;
            ResizeFiltro1();
            cboFiltar.Enabled = false;
            NomeRelatorio = "ListagemOperacoes";
            lbRelatorio.Text = "Relatório - Listagem de Operações";
            ShowDialog();
            Close();
        }
        public void ImprimirGrafTotOp()
        {
            cboFiltar.SelectedIndex = 1;
            ResizeFiltro1();
            cboFiltar.Enabled = false;
            NomeRelatorio = "GrafTotOp";
            lbRelatorio.Text = "Relatório - Gráfico de Totalizadores de Documentos";
            ShowDialog();
            Close();
        }
        public void ImprimirGrafPeriodoMov()
        {
            cboFiltar.SelectedIndex = 1;
            ResizeFiltro2();
            cboFiltar.Enabled = false;
            NomeRelatorio = "GrafPeriodicoMov";
            lbRelatorio.Text = "Relatório - Gráfico Periódico de Movimentação";
            ShowDialog();
            Close();
        }
        private void btnImprimir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            for (int i = 0; i < gridOperacoes.RowCount; i++)
            {
                if (!Convert.ToBoolean(gridOperacoes.GetRowCellValue(i, "Checa"))) { gridOperacoes.SetRowCellValue(i, "Checa", false);break; }
            }
            if (NomeRelatorio == "ListagemOperacoes")
                ListagemOp();
            if (NomeRelatorio == "GrafTotOp")
                GrafTotOp();
            if (NomeRelatorio == "GrafPeriodicoMov")
                BuscarGrafPeriodicos();
        }
        private void RecebeData()
        {
            inicio = DateTime.Parse(dtInicio.Text);
            termino = DateTime.Parse(dtFim.Text);
        }
        private void Filtragem()
        {
            RecebeData();
            if (cboFiltar.Text == "Todos")
            {
                LtRelOperacoes = (List<RelOpercoesViewModel>)_DocumentosApp.LerOperacoes(null, null, null);
                inicio = LtRelOperacoes.Min(r => r.Data);
                termino = LtRelOperacoes.Max(r => r.Data);
            }
            else
                LtRelOperacoes = (List<RelOpercoesViewModel>)_DocumentosApp.LerOperacoes(inicio.ToString("yyyy-MM-dd"), termino.ToString("yyyy-MM-dd"), null);

            int countOp = 0;
            List<int> LtCodOp = new List<int>();
            for (int i = 0; i < gridOperacoes.RowCount; i++)
            {
                if (Convert.ToBoolean(gridOperacoes.GetRowCellValue(i, "Checa")))
                {
                    LtCodOp.Add(LtOperacoes[i].codigo);
                    countOp++;
                }
            }

            if (countOp > 0)
            {
                object[] CodOperacoes = new object[countOp];
                for (int i = 0; i < countOp; i++)
                {
                    CodOperacoes[i] = LtCodOp[i];
                }
                if (cboFiltar.Text == "Todos")
                {
                    LtRelOperacoes = (List<RelOpercoesViewModel>)_DocumentosApp.LerOperacoes(null, null, CodOperacoes);
                    if (LtRelOperacoes.Count > 0)
                    {
                        inicio = LtRelOperacoes.Min(r => r.Data);
                        termino = LtRelOperacoes.Max(r => r.Data);
                    }

                }
                else
                    LtRelOperacoes = (List<RelOpercoesViewModel>)_DocumentosApp.LerOperacoes(inicio.ToString("yyyy-MM-dd"), termino.ToString("yyyy-MM-dd"), CodOperacoes);
            }

            if (cboTipoOp.Text == "Crédito")
                LtRelOperacoes = LtRelOperacoes.Where(r => r.Tipo == "CREDITO").ToList();
            else if (cboTipoOp.Text == "Débito")
                LtRelOperacoes = LtRelOperacoes.Where(r => r.Tipo == "DEBITO").ToList();
            else if (cboTipoOp.Text == "Isento")
                LtRelOperacoes = LtRelOperacoes.Where(r => r.Tipo == "ISENTO").ToList();

            if (!string.IsNullOrEmpty(txtCliente.Text))
                LtRelOperacoes = LtRelOperacoes.Where(r => r.Cliente == txtCliente.Text).ToList();

            if (!string.IsNullOrEmpty(txtUsuario.Text))
                LtRelOperacoes = LtRelOperacoes.Where(r => r.Usuario == txtUsuario.Text).ToList();
        }
        private void ListagemOp()
        {
            Filtragem();
            if (LtRelOperacoes.Count == 0) { MessageBox.Show("Sem relatório!", "Relatórios", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            new frmApresentaReport().ApresentarRelOperacoes(LtRelOperacoes, new DadosReportViewModel() { Titulo = "Listagem de Operações", DataInicio = inicio, DataFim = termino, Cliente = txtCliente.Text, Usuario = txtUsuario.Text });
        }
        private void BuscarGrafPeriodicos()
        {
            RecebeData();

            for (int i = 0; i < LtData.Count; i++)
            {
                var saldo = _CalculosApp.MostraSaldo(LtData[i].Data.ToString("yyyy-MM-dd"));
                LtData[i].Credito = saldo.Credito; LtData[i].Debito = saldo.Debito;

            }
            if (LtData.Count == 0) { MessageBox.Show("Sem relatório!", "Relatórios", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            new frmApresentaReport().ApresentarRelGrafPeriodicoMov(LtData);

        }
        private void GrafTotOp()
        {
            Filtragem();
            if (LtRelOperacoes.Count == 0) { MessageBox.Show("Sem relatório!", "Relatórios", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            new frmApresentaReport().ApresentarRelGrafTotOp(LtRelOperacoes, new DadosReportViewModel() { DataInicio = inicio, DataFim = termino, Cliente = txtCliente.Text, Usuario = txtUsuario.Text });
        }

        private void cboFiltar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboFiltar.Text == "Todos")
            {
                Controle.DesabilitarControle(dtInicio, dtFim);
                PopulaGradeOp();
            }
            else
            {
                Controle.HabilitarControle(dtInicio, dtFim);
            }
        }

        private void btnEntidade_Click(object sender, EventArgs e)
        {
            var form = IOC.InjectForm<frmEntidadeBusca>().GetEntidadeSelecionada();
            if (form != null)
            {
                txtCodCliente.Text = form.Codigo.ToString();
                txtCliente.Text = form.Nome;
            }
        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            var form = IOC.InjectForm<frmUsuarios>().GetUsuario();
            if (form != null)
            {
                txtCodUsuario.Text = form.codigo.ToString();
                txtUsuario.Text = form.Nome;
            }

        }

        private void cboTipoOp_SelectedIndexChanged(object sender, EventArgs e)
        {
            //PopulaGradeOp();
        }

        private void gridOperacoes_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            indexGrid = e.RowHandle;
        }

        private void gridOperacoes_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            indexGrid = e.RowHandle;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool Existe = false;
            for (int i = 0; i < LtData.Count; i++)
            {
                if (LtData[i].DataStr == dtData.Text) Existe = true;
            }
            if (Existe) return;
            LtData.Add(new Saldos() { DataStr = dtData.Text, Data = Convert.ToDateTime(dtData.Text) });
            gradeData.DataSource = null;
            gradeData.DataSource = LtData;
        }

        private void chkCheca_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCheca.Checked)
            {
                for (int i = 0; i < LtOperacoes.Count; i++)
                {
                    LtOperacoes[i].Checa = true;
                }
                gradeOperacoes.DataSource = null;
                gradeOperacoes.DataSource = LtOperacoes;
            }
            else
            {
                for (int i = 0; i < LtOperacoes.Count; i++)
                {
                    LtOperacoes[i].Checa = false;
                }
                gradeOperacoes.DataSource = null;
                gradeOperacoes.DataSource = LtOperacoes;
            }

        }

        private void gridOperacoes_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

        }

        private void gridOperacoes_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            Editando = Convert.ToBoolean(gridOperacoes.GetRowCellValue(e.RowHandle, "Checa"));
            if (!Editando)
            {
                Editando = true;
                gridOperacoes.SetRowCellValue(e.RowHandle, "Checa", true);
            }

            else
            {
                Editando = false;
                gridOperacoes.SetRowCellValue(e.RowHandle, "Checa", false);
            }


        }

        private void gridOperacoes_ColumnChanged(object sender, EventArgs e)
        {

        }
    } }
