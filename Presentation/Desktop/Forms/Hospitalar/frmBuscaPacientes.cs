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
using Folha.Domain.Interfaces.Application.Hospitalar;
using Folha.Driver.Framework.IOC;
using Folha.Domain.ViewModels.Hospitalar;
using Folha.Domain.Helpers;

namespace Folha.Presentation.Desktop.Forms.Hospitalar
{
    public partial class frmBuscaPacientes : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly IPacienteApp _PacienteApp;
        private List<PacienteViewModel> LtPacientes;
        private int Index { get; set; } = -1;
        private bool Selected { get; set; } = false;
        public new bool Select { get; set; } = false;

        public frmBuscaPacientes(IPacienteApp PacienteApp)
        {
            InitializeComponent();
            _PacienteApp = PacienteApp;
            FormBorderStyle = FormBorderStyle.None;

        }
        private void btnVoltar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void frmBuscaPacientes_Load(object sender, EventArgs e)
        {
            carregarPacientes();
        }

        private void carregarPacientes()
        {
            gridControlBuscaPacientes.DataSource = _PacienteApp.GetAll(null);
            LtPacientes = _PacienteApp.GetAll(null);
        }

        private void btnNovo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            IOC.InjectForm<frmPaciente>().ShowDialog();
            if (UtilidadesGenericas.Busca.Alterou)
            {
                carregarPacientes();
                UtilidadesGenericas.Busca.Alterou = false;
            }
        }

        #region Passando valores para o outro formulário
        public PacienteViewModel SelecionaPaciente()
        {
            Select = true;
            ShowDialog();
            if (Selected)
            {
                if (UtilidadesGenericas.ListaNula(LtPacientes))
                {
                    return new PacienteViewModel();
                }
                return LtPacientes[Index];
            }
            else
            {
                MessageBox.Show("Selecione o Um Paciente");
                return new PacienteViewModel();
            }
        }
        private void selectRow()
        {
            if (Index > -1)
            {
                Selected = true;
                Close();

            }
            else MessageBox.Show("Selecione uma Linha de registro do Paciente");
        }

        #endregion

        private void gridViewBuscaPacientes_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            Index = e.RowHandle;
        }

        private void gridViewBuscaPacientes_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            Index = e.RowHandle;
        }

        private void gridViewBuscaPacientes_DoubleClick(object sender, EventArgs e)
        {
            selectRow();
        }

        private void btnSelecionar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            selectRow();
        }
    }
}