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
using Folha.Driver.Framework.IOC;
using Folha.Domain.Models.Hospitalar;
using Folha.Domain.ViewModels.Hospitalar;
using Folha.Domain.Helpers;

namespace Folha.Presentation.Desktop.Forms.Hospitalar
{
    public partial class frmExames : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly IExamesHospitalarApp _ExamesHospitalarApp;
        private int indexGrid=-1;
        public ExamesViewModel DadosExame { get; set; } = null;
        List<ExamesViewModel> LtExames;
        public frmExames(IExamesHospitalarApp ExamesHospitalarApp)
        {
            InitializeComponent();
            _ExamesHospitalarApp = ExamesHospitalarApp;
            DadosExame = new ExamesViewModel() { CodExame = 0, CodExameAtendimento=0, Descricao = "Nenhuma" };
            Permicao();
        }

        #region Permicao de Acesso
        int VerficaUsuario = int.Parse(UtilidadesGenericas.UsuarioPerfil.ToString());
        private int codMedico;

        private void Permicao()
        {
            if (VerficaUsuario != 1)
            {
                if (UtilidadesGenericas.TemAcesso("Hospitalar#Hospitalar#Criar") == false) { btnNovo.Enabled = false; }
                if (UtilidadesGenericas.TemAcesso("Administração#Hospitalar#Eliminar") == false) { btnEliminar.Enabled = false; }
                if (UtilidadesGenericas.TemAcesso("Administração#Hospitalar#Imprimir") == false) { bntPrint.Enabled = false; }
            }
        }
        #endregion

        private void frmExames_Load(object sender, EventArgs e)
        {
            if (!btnSelecionar.Enabled) btnSelecionar.Visibility = BarItemVisibility.Never;
            else { this.MaximizeBox = false; this.MinimizeBox = false; cboTipoResultado.Enabled = true; btnBusca.Enabled = true; }

            gradeExames.DataSource = LtExames = (List <ExamesViewModel>) _ExamesHospitalarApp.ListarExamesHospitalar(null);
            if (!UtilidadesGenericas.ListaNula(LtExames))
            {
                indexGrid = 0;
            }
        }

        private void btnNovo_ItemClick(object sender, ItemClickEventArgs e)
        {
            IOC.InjectForm<frmExame>().ShowDialog();
            gradeExames.DataSource = LtExames = (List<ExamesViewModel>)_ExamesHospitalarApp.ListarExamesHospitalar(null);
        }

        private void btnSelecionar_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gridExames.RowCount == 0) return;
            if (string.IsNullOrEmpty(cboTipoResultado.Text)) { MessageBox.Show("Selecione o Tipo de Resultado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (string.IsNullOrEmpty(txtMedico.Text)) { MessageBox.Show("Selecione o Medico que requistou o exame", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            try
            {
                if (indexGrid == -1) DadosExame = new ExamesViewModel() { CodExame = 0, CodExameAtendimento=0, Descricao = "Nenhuma" };
                else
                {
                    DadosExame.CodExame = LtExames[indexGrid].CodExame;
                    DadosExame.Descricao = LtExames[indexGrid].Descricao;
                    DadosExame.Preco = LtExames[indexGrid].Preco;
                    DadosExame.CodExameAtendimento = 0;
                    DadosExame.TipoResultado = cboTipoResultado.Text;
                    DadosExame.Medico = txtMedico.Text;
                    DadosExame.NumeroProcesso = "";
                    DadosExame.NumeroAmostra = "";
                    DadosExame.ViaDocumento = "Não Impresso";
                }
            }
            catch (Exception) { }
            Close();
        }

        private void gridExames_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            indexGrid = e.RowHandle;
        }

        private void gridExames_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            indexGrid = e.RowHandle;
        }

        private void gridExames_DoubleClick(object sender, EventArgs e)
        {
            if (btnSelecionar.Visibility == BarItemVisibility.Never)
            {
                var form = IOC.InjectForm<frmExame>();
                form.EditarExameHospitalar(LtExames[indexGrid]);
                gradeExames.DataSource = LtExames = (List<ExamesViewModel>)_ExamesHospitalarApp.ListarExamesHospitalar(null);
            }
            else
            {
                if (gridExames.RowCount == 0) return;
                if (string.IsNullOrEmpty(cboTipoResultado.Text)) { MessageBox.Show("Selecione o Tipo de Resultado", "Tipo de Resultado", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                  if (indexGrid == -1) DadosExame = new ExamesViewModel() { CodExame = 0, CodExameAtendimento = 0, Descricao = "Nenhuma" };
                    else
                    {
                        DadosExame.CodExame = LtExames[indexGrid].CodExame;
                        DadosExame.Descricao = LtExames[indexGrid].Descricao;
                        DadosExame.Preco = LtExames[indexGrid].Preco;
                        DadosExame.CodExameAtendimento = 0;
                        DadosExame.TipoResultado = cboTipoResultado.Text;
                        DadosExame.Medico = txtMedico.Text;
                        DadosExame.NumeroProcesso = "";
                        DadosExame.NumeroAmostra = "";
                        DadosExame.ViaDocumento = "";
                    }
               
                Close();
            }
        }

        private void btnEditar_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btnVoltar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void bntPrint_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btnBusca_Click(object sender, EventArgs e)
        {
            var form = IOC.InjectForm<frmMedicos>();
            form.btnSelecionar.Visibility = BarItemVisibility.Always;
            var buscaMedico = form.GetProfissional();
            if (Equals(buscaMedico, null))
            {
                return;
            }
            else
            {
                codMedico = buscaMedico.CodMedico;
                txtMedico.Text = buscaMedico.Nome;
            }
        }
    }
}