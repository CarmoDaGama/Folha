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
using Folha.Domain.Interfaces.Application.Hospitalar;
using Folha.Driver.Application.Hospitalar;
using Folha.Domain.Models.Hospitalar;
using Folha.Driver.Framework.IOC;
using Folha.Presentation.Desktop.Forms.Hospitalar;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Folha.Domain.Models.Entidades;
using Folha.Domain.Interfaces.Application.Entidades;
using Folha.Domain.Helpers;
using Folha.Domain.ViewModels.Entidades;
using Folha.Domain.ViewModels.Hospitalar;
using Folha.Domain.ViewModels.Frame.Entidades;
using Folha.Presentation.Desktop.Forms.Apresenta_Doc;
using Folha.Domain.ViewModels.Report;

namespace Folha.Presentation.Desktop.Forms.Hispitalar
{
    public partial class frmPacientes : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        private readonly IPacienteApp _PacienteApp;
        private int codEnt;
        //Report
        string RelUsuario;
        DadosReportViewModel dadosReport;
        public int Index { get; private set; } = -1;
        int usuario = int.Parse(UtilidadesGenericas.UsuarioPerfil.ToString());

        private List<PacienteViewModel> LtPacientes;
        public PacienteViewModel DadosPaciente { get; set; } = null;
        public frmPacientes(IPacienteApp PacienteApp)
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;

            _PacienteApp = PacienteApp;
            Index = -1;
            DadosPaciente = new PacienteViewModel{ Codigo = 0, CodEntidade=0,Nome=null };
            Permicao();
        }
        private void Permicao()
        {
            if (usuario != 1)
            {
                if (UtilidadesGenericas.TemAcesso("Hospitalar#Paciente#Criar") == false) { btnNovo.Enabled = false; }
                if (UtilidadesGenericas.TemAcesso("Hospitalar#Paciente#Eliminar") == false) { btnEliminar.Enabled = false; }
                if (UtilidadesGenericas.TemAcesso("Hospitalar#Paciente#Imprimir") == false) { btnImprimir.Enabled = false; }
            }
        }
        private void frmPacientes_Load(object sender, EventArgs e)
        {
            if (!btnSelecionar.Enabled) btnSelecionar.Visibility = BarItemVisibility.Never;
            else { this.MaximizeBox = false; this.MinimizeBox = false; }
            carregarPacientes();
        }

        private void carregarPacientes()
        {
            LtPacientes = _PacienteApp.GetAll(null);
            gradePacientes.DataSource = LtPacientes;
            Index = UtilidadesGenericas.ListaNula(LtPacientes) ? -1 : 0;
        }

        private void btnNovo_ItemClick(object sender, ItemClickEventArgs e)
        {
            IOC.InjectForm<frmPaciente>().ShowDialog();
            if (UtilidadesGenericas.Busca.Alterou)
            {
                carregarPacientes();
                UtilidadesGenericas.Busca.Alterou = false;
            }
        }
       
        private void gridViewPacientes_DoubleClick(object sender, EventArgs e)
        {
            if (btnSelecionar.Visibility == BarItemVisibility.Never)
            {
                var form = IOC.InjectForm<frmPaciente>();

                form.EditarPaciente(new EntidadesViewModel()
                {
                    Codigo = LtPacientes[Index].CodEntidade,
                    Nome = LtPacientes[Index].Nome,

                });
                if (UtilidadesGenericas.Busca.Alterou)
                {
                    carregarPacientes();
                    UtilidadesGenericas.Busca.Alterou = false;
                }
            }
            else
            {
                if (gridViewPacientes.RowCount == 0) return;

                try
                {
                    if (Index == -1) DadosPaciente = new PacienteViewModel { Codigo = 0, CodEntidade = 0, Nome = null };
                    else
                    {
                        DadosPaciente.Codigo = LtPacientes[Index].Codigo;
                        DadosPaciente.CodEntidade = LtPacientes[Index].CodEntidade;
                        DadosPaciente.Nome = LtPacientes[Index].Nome;
                        DadosPaciente.GrupoSanguineo = new GrupoSanguineos { Descricao = gridViewPacientes.GetRowCellValue(Index, "Descricao").ToString() };
                    }
                }
                catch (Exception) { }
                Close();

            }

        }

        private void gridViewPacientes_RowClick(object sender, RowClickEventArgs e)
        {
           Index = e.RowHandle;
        }
        
        private void gridViewPacientes_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            Index = e.RowHandle;
            codEnt = LtPacientes[Index].CodEntidade;
        }

        private void btnApagar_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Index < 0)
            {
                MessageBox.Show("Selecione um registro!");
                return;
            }
            if (temCertesa())
            {
                
                _PacienteApp.Delete(new Paciente()
                { CodPessoa = codEnt, status = 0 });
                frmPacientes_Load(sender, e);
            }
        }
        private bool temCertesa()
        {
            var result = MessageBox.Show(
                "Tem certesa que pretendes" +
                " eleminar Este registro?",
                "QUSETÃO",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            return result == DialogResult.Yes;
        }
        private void btnEditar_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Index > -1)
            {
                var form = IOC.InjectForm<frmPaciente>();

                form.EditarPaciente(new EntidadesViewModel()
                {
                    Codigo = LtPacientes[Index].CodEntidade,
                    Nome = LtPacientes[Index].Nome

                });
            }
        }

        private void btnSelecionar_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gridViewPacientes.RowCount == 0) return;

            try
            {
                if (Index == -1) DadosPaciente = new PacienteViewModel { Codigo = 0, CodEntidade = 0,Nome=null };
                else
                {
                    DadosPaciente.Codigo = LtPacientes[Index].Codigo;
                    DadosPaciente.CodEntidade = LtPacientes[Index].CodEntidade;
                    DadosPaciente.Nome = LtPacientes[Index].Nome;
                    DadosPaciente.GrupoSanguineo = new GrupoSanguineos { Descricao = gridViewPacientes.GetRowCellValue(Index,"Descricao").ToString() };
                }
            }
            catch (Exception) { }
            Close();
          
        }

        private void btnImprimir_ItemClick(object sender, ItemClickEventArgs e)
        {
            RelUsuario = UtilidadesGenericas.UsuarioCodigo + " - " + UtilidadesGenericas.NomeUsuario;
            dadosReport = new DadosReportViewModel(){Usuario = RelUsuario};
            new frmApresentaReport().ApresentarReportPacientes(LtPacientes, dadosReport);
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }
    }
}