using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Folha.Domain.Interfaces.Application.Documentos;
using Folha.Domain.Interfaces.Application.Financeiro;
using Folha.Domain.Interfaces.Application.Genericos;
using Folha.Domain.Models.Financeiro;
using Folha.Domain.ViewModels.Financeiro;
using Folha.Domain.Helpers;
using Folha.Driver.Framework.IOC;
using Folha.Presentation.Desktop.Classe;
using Folha.Presentation.Desktop.Forms.Apresenta_Doc;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Folha.Presentation.Desktop.Separadores.Financeiro
{
    public partial class frmFPagamento : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        int cod;
        List<Mostrar> Lista;
        private readonly IDocumentosApp _DocumentosApp;
        public frmFPagamento(IDocumentosApp DocumentosApp, IGenericoApp GenericoApp,IFPagamentosApp FPagamentosApp)
        {
            InitializeComponent();
            Permicao();
            _DocumentosApp = DocumentosApp; 
            _GenericoApp = GenericoApp;
            _FPagamentosApp = FPagamentosApp;
        }

        #region Permicao de Acesso
        int VerficaUsuario = int.Parse(UtilidadesGenericas.UsuarioPerfil.ToString());
        private int indexGrid=0;
        private readonly IGenericoApp _GenericoApp;
        private readonly IFPagamentosApp _FPagamentosApp;

        private void Permicao()
        {
            if (VerficaUsuario != 1)
            {
                if (UtilidadesGenericas.TemAcesso("Financeiro#Formas de Pagamentos#Criar") == false) { btnNovo.Enabled = false; }
                if (UtilidadesGenericas.TemAcesso("Financeiro#Formas de Pagamentos#Eliminar") == false) { btnEliminar.Enabled = false; }
                if (UtilidadesGenericas.TemAcesso("Financeiro#Formas de Pagamentos#Imprimir") == false) { btnImprimir.Enabled = false; }
            }
        }
        #endregion

        private void frmCadastroFormaPagamento_Load(object sender, EventArgs e)
        {
            Mostrar();
        }

        private void gridFPagamentos_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            indexGrid = e.RowHandle;
            cod = int.Parse(gridFPagamentos.GetRowCellValue(e.RowHandle, "Codigo").ToString());
        }

        private void Mostrar ()
        {
            Lista = (List<Mostrar>)_DocumentosApp.MostrarFPagamento();
            gradeFPagamentos.DataSource = Lista;
        }

        private void gridFPagamentos_DoubleClick(object sender, EventArgs e)
        {
            
            if (int.Parse(gridFPagamentos.GetRowCellValue(indexGrid, "Codigo").ToString()) == 1)
            {
                MessageBox.Show("Este item não pode ser alterado!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            UtilidadesGenericas.ChamarNoPrincipal(IOC.InjectForm<frmFPagamentosCad>().EditarFPagamento(Lista[indexGrid]));
            Mostrar();
        }

        private void gradeFPagamentos_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void btnVoltar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btnImprimir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Lista = (List<Mostrar>)_DocumentosApp.MostrarFPagamento();

            if (Equals(Lista, null) || Lista.Count == 0)
            {
                MessageBox.Show("Sem relatório!", "Forma de Pagamento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            new frmApresentaReport().ApresentarReporFPagamento(Lista);
        }

        private void btnEliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (cod == 1)
            {
                MessageBox.Show("Este item não pode ser alterado!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            bool VerifPagamento = _GenericoApp.VerificarRegisto("Pagamentos", "CodForma", cod.ToString());
            if (VerifPagamento)
            {
                MessageBox.Show("Este registo não pode ser eliminado!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            _FPagamentosApp.Delete(new fPagamentosViewModel { codigo = Lista[indexGrid].Codigo });
            Mostrar();
        }

        private void btnNovo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UtilidadesGenericas.ChamarNoPrincipal(IOC.InjectForm<frmFPagamentosCad>());
            Mostrar();
        }

        private void gridFPagamentos_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            indexGrid = e.RowHandle;
            cod = int.Parse(gridFPagamentos.GetRowCellValue(e.RowHandle, "Codigo").ToString());
        }
    }
}