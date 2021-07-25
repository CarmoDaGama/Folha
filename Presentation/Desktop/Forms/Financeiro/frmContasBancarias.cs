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
using Folha.Domain.Interfaces.Application.Financeiro;
using Folha.Driver.Framework.IOC;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Folha.Domain.Models.Financeiro;
using Folha.Presentation.Desktop.Classe;
using Folha.Presentation.Desktop.Forms.Apresenta_Doc;
using Folha.Domain.Helpers;
using Folha.Domain.Interfaces.Application.Genericos;

namespace Folha.Presentation.Desktop.Separadores.Financeiro
{
    public partial class frmContasBancarias : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public int index=0;
        private readonly IContaBancariaApp _ContaBancariaApp;
        private int cod;
        List<ContasBancarias> LtConta;
        ContasBancarias DadosConta = null;
        public frmContasBancarias(IContaBancariaApp ContaBancariaApp,IGenericoApp GenericoApp)
        {
            InitializeComponent();
            _ContaBancariaApp = ContaBancariaApp;
            _GenericoApp = GenericoApp;
            Permicao();
        
         }
        #region Permicao de Acesso
        int VerficaUsuario = int.Parse(UtilidadesGenericas.UsuarioPerfil.ToString());
        private readonly IGenericoApp _GenericoApp;

        private void Permicao()
        {
            if (VerficaUsuario != 1)
            {
                if (UtilidadesGenericas.TemAcesso("Financeiro#Conta Bancaria#Criar") == false) { btnNovo.Enabled = false; }
                if (UtilidadesGenericas.TemAcesso("Financeiro#Conta Bancaria#Eliminar") == false) { btnEliminar.Enabled = false; }
                if (UtilidadesGenericas.TemAcesso("Financeiro#Conta Bancaria#Imprimir") == false) { bntPrint.Enabled = false; }
            }
        }
        #endregion


        private void btnFechar_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }

        private void btnNovo_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }
        public ContasBancarias GetContaBancaria()
        {
            btnSelecionar.Enabled = true;
            btnSelecionar.Visibility = BarItemVisibility.Always;
            ShowDialog();
            return DadosConta; 
        }
        private void frmContasBancarias_Load(object sender, EventArgs e)
        {
            if (!btnSelecionar.Enabled) btnSelecionar.Visibility = BarItemVisibility.Never;
            else { this.MaximizeBox = false; this.MinimizeBox = false; }
            Mostra();
        }

        private void Mostra()
        {
            LtConta = (List<ContasBancarias>)_ContaBancariaApp.Listar(null, false);
            gradeBancos.DataSource = LtConta;
        }

        private void btnSelecionar_ItemClick(object sender, ItemClickEventArgs e)
        {
            SelecionarContaBancaria();
        }

        private void gvBancos_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            index= e.RowHandle;
            cod = int.Parse(gridBancos.GetRowCellValue(e.RowHandle, "codigo").ToString());
        }

   

        private void gridBancos_DoubleClick(object sender, EventArgs e)
        {
            if (btnSelecionar.Visibility == BarItemVisibility.Always)
            {
                SelecionarContaBancaria();
            }
            else
            {
                var conta = LtConta.Where(c => c.codigo == cod).FirstOrDefault();
                var form = IOC.InjectForm<frmDadosContaBancaria>().EditarConta(conta);
                UtilidadesGenericas.ChamarNoPrincipal(form);
                Mostra();
            }
        }

        private void SelecionarContaBancaria()
        {
            if (gridBancos.RowCount == 0) return;
            DadosConta = LtConta.Where(c => c.codigo == cod).FirstOrDefault();
            this.Close();
        }

        private void btnAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
            UtilidadesGenericas.ChamarNoPrincipal(IOC.InjectForm<frmDadosContaBancaria>());

            //frmDadosContaBancaria chamada = IOC.InjectForm<frmDadosContaBancaria>();
            //UtilidadesGenericas.ChamarNoPrincipal(chamada);
            Mostra();
        }

        private void btnVoltar_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void bntPrint_ItemClick(object sender, ItemClickEventArgs e)
        {
            LtConta = (List<ContasBancarias>)_ContaBancariaApp.Listar(null, false);
            if (LtConta.Count == 0)
            {
                MessageBox.Show("Sem relatório", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            LtConta[0].CabecalhoEmpresa = Controle.CabecalhoEmpresa;

            new frmApresentaReport().ApresentarReportContaBancaria(LtConta);
        }

        private void btnEliminar_ItemClick(object sender, ItemClickEventArgs e)
        {
            bool Verifica = _GenericoApp.VerificarRegisto("fPagamentos", "CodConta", LtConta[index].codigo.ToString());
            if (Verifica)
            {
                MessageBox.Show("Esta conta não pode ser eliminada", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                _ContaBancariaApp.Delete(LtConta[index].codigo);
                Mostra();
            }
               
        }

        private void gvBancos_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            index = e.RowHandle;
            cod = int.Parse(gridBancos.GetRowCellValue(e.RowHandle, "codigo").ToString());
        }
    }
}