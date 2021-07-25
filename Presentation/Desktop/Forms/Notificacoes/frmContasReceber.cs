using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using System.ComponentModel.DataAnnotations;
using Folha.Presentation.Desktop.Separadores.Entidades;
using Folha.Driver.Framework.IOC;
using SimpleInjector;
using Folha.Domain.Interfaces.Application.Financeiro;
using Folha.Domain.ViewModels.Frame.Financeiro;
using Folha.Presentation.Desktop.Separadores.Financeiro;
using Folha.Domain.Helpers;
using Folha.Presentation.Desktop.Separadores.Principal;
using Folha.Presentation.Desktop.Forms.Principal;

namespace Folha.Presentation.Desktop.Separadores.Notificacoes
{
    public partial class frmContasReceber : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly ILiquidacaoDocApp _LiquidacaoDocApp;
        private List<LiquidacaoDocViewModel> LtLiquidar;
        private int indexGrid;

        public frmContasReceber(ILiquidacaoDocApp LiquidacaoDocApp)
        {
            InitializeComponent();
            _LiquidacaoDocApp = LiquidacaoDocApp;
        }
       
        private void BuscarDocumentos()
        {

            LtLiquidar = (List<LiquidacaoDocViewModel>)_LiquidacaoDocApp.Listar(null);
            gridDoc.DataSource = LtLiquidar;

            double Total = 0;
            for (int i = 0; i < gridViewDoc.RowCount; i++)
            {
                Total += double.Parse(gridViewDoc.GetRowCellValue(i, "Total").ToString());
            }
            txtTotal.Text = Total.ToString("N2");
        }
        private void frmContasReceber_Load(object sender, EventArgs e)
        {
            BuscarDocumentos();
        }

        private void btnFechar_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            Close();
        }
        private void gridViewDoc_DoubleClick(object sender, EventArgs e)
        {
            if (UtilidadesGenericas.EstadoTurnoSistema)
            {
                if (LtLiquidar[indexGrid].Documento=="FACTURA")
                IOC.InjectForm<frmFacturaRecibo>().RecebeDivida(int.Parse(LtLiquidar[indexGrid].CodEntidade),LtLiquidar[indexGrid].Entidade);

            LtLiquidar = (List<LiquidacaoDocViewModel>)_LiquidacaoDocApp.Listar(null);
            gridDoc.DataSource = LtLiquidar;
            txtTotal.Text = null;
            }
            else MessageBox.Show(
                  "Turno Está fechado!",
                  "Mensagem",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Stop
              );
        }

        private void gridViewDoc_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            indexGrid = e.RowHandle;
        }

        private void gridViewDoc_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            indexGrid = e.RowHandle;
        }
    }
}