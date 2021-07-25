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
using Folha.Domain.ViewModels.Frame.Financeiro;
using Folha.Domain.Interfaces.Application.Financeiro;
using Folha.Domain.Helpers;
using Folha.Driver.Framework.IOC;
using Folha.Presentation.Desktop.Separadores.Principal;
using Folha.Presentation.Desktop.Forms.Financeiro;
using Folha.Presentation.Desktop.Separadores.Financeiro;

namespace Folha.Presentation.Desktop.Forms.Notificacoes
{
    public partial class frmContasPagar : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private List<LiquidacaoDocViewModel> LtLiquidar;
        private readonly ILiquidacaoDocApp _LiquidacaoDocApp;
        private int indexGrid;

        public frmContasPagar(ILiquidacaoDocApp LiquidacaoDocApp)
        {
            InitializeComponent();
            _LiquidacaoDocApp = LiquidacaoDocApp;
        }

        private void BuscarDocumentos()
        {

            LtLiquidar = (List<LiquidacaoDocViewModel>)_LiquidacaoDocApp.ListarContaPagar();
            gridDoc.DataSource = LtLiquidar;

            double Total = 0;
            for (int i = 0; i < gridViewDoc.RowCount; i++)
            {
                Total += double.Parse(gridViewDoc.GetRowCellValue(i, "Total").ToString());
            }
            txtTotal.Text = Total.ToString("N2");
        }

        private void frmContasPagar_Load(object sender, EventArgs e)
        {
            BuscarDocumentos();
        }

        private void btnFechar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void gridViewDoc_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            indexGrid = e.RowHandle;
        }

        private void gridViewDoc_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            indexGrid = e.RowHandle;
        }

        private void gridViewDoc_DoubleClick(object sender, EventArgs e)
        {
            if (UtilidadesGenericas.EstadoTurnoSistema)
            {
                if (LtLiquidar[indexGrid].Documento == "COMPRA A FORNECEDOR") {
                    if (LtLiquidar[indexGrid].Estado == "ABERTO" ||LtLiquidar[indexGrid].Estado == "PENDENTE" || LtLiquidar[indexGrid].Estado == "ANULADO")
                    {
                        if (IOC.InjectForm<frmTelaDocumento>().EfectuarOperacaoDocumento(LtLiquidar[indexGrid].Codigo))
                        {
                            BuscarDocumentos();
                        }
                    }
                    else
                    {
                        if (IOC.InjectForm<frmReceberPagamentos>().ReceberPagmentoDocumento(LtLiquidar[indexGrid].Codigo, 0.0m))
                        {
                            BuscarDocumentos();
                        }
                    }
                }

                if (LtLiquidar[indexGrid].Documento == "NOTA DE PAGAMENTO" && LtLiquidar[indexGrid].Estado.ToUpper() == "ABERTO")
                { IOC.InjectForm<frmNotaPagamento>().ShowDialog(); BuscarDocumentos(); }
            }
            else MessageBox.Show("Turno Está fechado!","Mensagem",MessageBoxButtons.OK,MessageBoxIcon.Stop);
        }
    }
}