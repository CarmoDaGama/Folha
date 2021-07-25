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
using Folha.Domain.Interfaces.Application.Sistema;
using Folha.Driver.Framework.IOC;
using Folha.Presentation.Desktop.Forms.Turnos;
using Folha.Presentation.Desktop.Separadores.Principal;
using Folha.Domain.ViewModels.Frame.Sistema;
using Folha.Domain.Helpers;

namespace Folha.Presentation.Desktop.Separadores.Financeiro
{
    public partial class frmVerTodosTurnos : XtraForm
    {
        private readonly ITurnosApp _TurnosApp;

        private List<TurnosVendedoresViewModel> Turnos { get;  set; }
        public int IndexTurno { get; set; } = -1;

        public frmVerTodosTurnos(ITurnosApp TurnosApp)
        {
            InitializeComponent();
            _TurnosApp = TurnosApp;
        }

        private void frmVerTodosTurnos_Load(object sender, EventArgs e)
        {
            carregarTurnos();
        }

        private void carregarTurnos()
        {
            Turnos = (List<TurnosVendedoresViewModel>)_TurnosApp.ListarTurnoVendedores(null);
            gradeTurnos.DataSource = Turnos;
            if (gridTurnos.RowCount > 0)
            {
                IndexTurno = 0;
            }
        }

        private void gradeTurnos_Click(object sender, EventArgs e)
        {

        }

        private void gradeTurnos_DoubleClick(object sender, EventArgs e)
        {
            irirConfirmar();
        }
        private void irirConfirmar()
        {
            if (gridTurnos.RowCount > 0)
            {
                var estadoTurno = gridTurnos.GetRowCellValue(IndexTurno, "Estado").ToString();
                var confirmadoTurno = gridTurnos.GetRowCellValue(IndexTurno, "Confirmado").ToString();
                if (estadoTurno.ToUpper() == "ABERTO")
                {
                    UtilidadesGenericas.MsgShow("Não é possível confirmar este turno pois Ele ainda está aberto!", MessageBoxIcon.Warning);
                    return;
                }
                if (confirmadoTurno.ToUpper() == "SIM")
                {
                    UtilidadesGenericas.MsgShow("Este turno já foi confirmado!", MessageBoxIcon.Warning);
                    return;
                }
                var codTurno = Convert.ToInt16(gridTurnos.GetRowCellValue(IndexTurno, "Codigo"));
                Close();
                var formMeuTurno = IOC.InjectForm<frmMeuTurno>().ConfirmarTurno(IOC.InjectForm<frmVerTodosTurnos>(),codTurno);
                UtilidadesGenericas.ChamarNoPrincipal(formMeuTurno);
                carregarTurnos();
            }
        }
        private void btnAbrir_ItemClick(object sender, ItemClickEventArgs e)
        {
            var codTurno = Convert.ToInt16(gridTurnos.GetRowCellValue(IndexTurno, "Codigo"));
            Close();
            var formMeuTurno = IOC.InjectForm<frmMeuTurno>().VerTurno(IOC.InjectForm<frmVerTodosTurnos>(), codTurno);
            UtilidadesGenericas.ChamarNoPrincipal(formMeuTurno);
            carregarTurnos();
        }

        private void btnConfirmar_ItemClick(object sender, ItemClickEventArgs e)
        {
            irirConfirmar();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            IndexTurno = e.RowHandle;
        }
    }
}