using DevExpress.XtraBars;
using Folha.Domain.Interfaces.Application.Genericos;
using Folha.Domain.Interfaces.Application.Hospitalar;
using Folha.Domain.ViewModels.Genericos;
using Folha.Domain.Helpers;
using Folha.Driver.Framework.IOC;
using Folha.Domain.ViewModels.Frame.Hospitalar;
using Folha.Presentation.Desktop.Forms.Apresenta_Doc;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Folha.Presentation.Desktop.Forms.Hospitalar
{
    using Folha.Domain.Models.Entidades;
    using Folha.Domain.Models.Hospitalar;
    using Folha.Domain.ViewModels.Report;
    using System.Linq;

    public partial class frmMedicos : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        private readonly IMedicosApp _MedicosApp;
        private List<MedicosViewModel> LtMedicos;
        private int indexGrid=-1;
        //Report
        string RelUsuario;
        DadosReportViewModel dadosReport;
        private readonly IEscalaApp _EscalaApp;
        List<EscalaConfig01ViewModel> LtEscalaDisponivel;
        int usuario = int.Parse(UtilidadesGenericas.UsuarioPerfil.ToString());
        private int cod;

        public MedicosViewModel DadosMedicos { get; set; }

        public frmMedicos(IMedicosApp MedicosApp, IEscalaApp EscalaApp)
        {
            InitializeComponent();
            _MedicosApp = MedicosApp;
            _EscalaApp = EscalaApp;
            //Permicao();
            Mostrar();
        }

        private void carregarMedigos()
        {
            gradeMedicos.DataSource = LtMedicos = (List<MedicosViewModel>)_MedicosApp.ListarMedicos(null, null, null);
            indexGrid = UtilidadesGenericas.ListaNula(LtMedicos) ? -1 : 0;
        }
        #region Permicao de Acesso
        //private void Permicao()
        //{
        //    if (usuario != 1)
        //    {
        //        if (UtilidadesGenericas.TemAcesso("Hospitalar#Medico#Criar") == false) { btnNovo.Enabled = false; }
        //        if (UtilidadesGenericas.TemAcesso("Hospitalar#Medico#Eliminar") == false) { btnEliminar.Enabled = false; }
        //        if (UtilidadesGenericas.TemAcesso("Hospitalar#Medico#Imprimir") == false) { btnImprimir.Enabled = false; }
        //    }
        //}
        #endregion
        private void frmVerMedicos_Load(object sender, EventArgs e)
        {
            if (!btnSelecionar.Enabled) btnSelecionar.Visibility = BarItemVisibility.Never;
            else { this.MaximizeBox = false; this.MinimizeBox = false; }

            if (btnSelecionar.Visibility == BarItemVisibility.Never)
            {
                cboInternamento.Visible = true;
            }

           
        }
        

        private void btnNovo_ItemClick(object sender, ItemClickEventArgs e)
        {
            IOC.InjectForm<frmMedico>().ShowDialog();
            if (UtilidadesGenericas.Busca.Alterou) Mostrar();

        }

        private void gridMedico_DoubleClick(object sender, EventArgs e)
        {
            if (btnSelecionar.Visibility == BarItemVisibility.Never)
            {
                var indexCurrent = UtilidadesGenericas.GetGridIndexCurrent(sender, MousePosition);
                var form = IOC.InjectForm<frmMedico>();

                form.EditarMedico(new Entidades()
                {
                    Codigo = LtMedicos[indexCurrent].CodEntidade,
                    Nome = LtMedicos[indexCurrent].Nome
                });
                if (UtilidadesGenericas.Busca.Alterou)
                {
                    carregarMedigos();
                    UtilidadesGenericas.Busca.Alterou = false;
                }
            }
            else
            {
                SelecionarMedico();

            }

        }
        public MedicosViewModel GetProfissional(int CodDayOfWeak, string HoraInicial)
        {
            int codEscala;
            LtMedicos = new List<MedicosViewModel>();
            LtEscalaDisponivel = (List<EscalaConfig01ViewModel>)_EscalaApp.ListEscalaDisponivel(CodDayOfWeak.ToString(), HoraInicial);
            if (LtEscalaDisponivel.Count > 0)
            {
                codEscala = LtEscalaDisponivel[0].CodEscala;
                gradeMedicos.DataSource = null;
                btnSelecionar.Visibility = BarItemVisibility.Always;
                ShowDialog();
            }
            else
            {
                MessageBox.Show("Sem profissionais disponíveis.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                gradeMedicos.DataSource = null;
                return DadosMedicos = new MedicosViewModel() { CodMedico = 0, Nome = "Nenhum" };
            }
                return DadosMedicos;
        }
        public MedicosViewModel GetProfissional()
        {
            ShowDialog();

            return DadosMedicos;
        }

        private void btnSelecionar_ItemClick(object sender, ItemClickEventArgs e)
        {
            SelecionarMedico();
        }

        public void SelecionarMedico()
        {
            if (gridMedico.RowCount == 0) return;

           
                    DadosMedicos = LtMedicos[indexGrid];
                
           
            Close();
        }

        private void gridMedico_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            indexGrid = e.RowHandle;
            cod = int.Parse(gridMedico.GetRowCellValue(e.RowHandle, "CodMedico").ToString());

        }

        private void btnImprimir_ItemClick(object sender, ItemClickEventArgs e)
        {
            RelUsuario = UtilidadesGenericas.UsuarioCodigo + " - " + UtilidadesGenericas.NomeUsuario;
            dadosReport = new DadosReportViewModel() { Usuario = RelUsuario };
            new frmApresentaReport().ApresentarReportMedicos(LtMedicos, dadosReport);
        }

        private void btnVoltar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
            UtilidadesGenericas.Busca.ModoLista = false;
        }

        private void gridMedico_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            indexGrid = e.RowHandle;
        }

        private void btnEliminar_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (MessageBox.Show("Deseja Realmente Eliminar  ", "Eliminar ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) return;

            _MedicosApp.Eliminar(new Medicos()
            {
                Codigo = cod,
            });
            MessageBox.Show(" Eliminado Com Sucesso", "Eliminar ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Mostrar();
        }

        private void Mostrar()
        {
            if (cboInternamento.SelectedItem.ToString() == "TODOS")
            {
                DadosMedicos = new MedicosViewModel() { CodMedico = 0, Nome = "Nenhum" };
                gradeMedicos.DataSource = LtMedicos = (List<MedicosViewModel>)_MedicosApp.ListarMedicos(null, null, null);
                indexGrid = UtilidadesGenericas.ListaNula(LtMedicos) ? -1 : 0;
            }
            else if (cboInternamento.SelectedItem.ToString() == "ACTIVOS")
            {
                DadosMedicos = new MedicosViewModel() { CodMedico = 0, Nome = "Nenhum" };
                LtMedicos = (List<MedicosViewModel>)_MedicosApp.ListarMedicos(null, null, null).Where(a => a.status == 1).ToList();
                gradeMedicos.DataSource = LtMedicos ;
                indexGrid = UtilidadesGenericas.ListaNula(LtMedicos) ? -1 : 0;
            }
            else if (cboInternamento.SelectedItem.ToString() == "ELIMINADOS")
            {
                DadosMedicos = new MedicosViewModel() { CodMedico = 0, Nome = "Nenhum" };
                LtMedicos = (List<MedicosViewModel>)_MedicosApp.ListarMedicos(null, null, null).Where(a => a.status == 0).ToList();
                gradeMedicos.DataSource = LtMedicos;
                indexGrid = UtilidadesGenericas.ListaNula(LtMedicos) ? -1 : 0;
            }
        }

        private void cboInternamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            Mostrar();
        }
    }
}