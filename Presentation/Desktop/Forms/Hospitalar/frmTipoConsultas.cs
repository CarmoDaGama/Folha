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
using Folha.Domain.Models.Hospitalar;
using Folha.Driver.Framework.IOC;
using Folha.Domain.Helpers;
using Folha.Domain.ViewModels.Hospitalar;

namespace Folha.Presentation.Desktop.Forms.Hospitalar
{
    public partial class frmTipoConsultas : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly ITipoConsultasApp _TipoConsultasApp;
        List<TipoConsultaViewModel> LtTipoConsultas;
        private int IndexGridTipoConsulta=-1;

        public TipoConsultaViewModel DadosTipoConsulta { get; set; } = null;
        public frmTipoConsultas(ITipoConsultasApp TipoConsultasApp)
        {
            InitializeComponent();
            Permicao();

            _TipoConsultasApp = TipoConsultasApp;
            DadosTipoConsulta = new TipoConsultaViewModel() { Codigo = 0, Descricao = "Nenhuma" };
        }
        #region Permicao de Acesso
        int VerficaUsuario = int.Parse(UtilidadesGenericas.UsuarioPerfil.ToString());
        private void Permicao()
        {
            if (VerficaUsuario != 1)
            {
                if (UtilidadesGenericas.TemAcesso("Hospitalar#Tipo de consulta#Criar") == false) { btnNovo.Enabled = false; }
                if (UtilidadesGenericas.TemAcesso("Hospitalar#Tipo de consulta#Eliminar") == false) { btnEliminar.Enabled = false; }
                if (UtilidadesGenericas.TemAcesso("Hospitalar#Tipo de consulta#Imprimir") == false) { btnPrint.Enabled = false; }
            }
        }
        #endregion
        private void frmTipoConsultas_Load(object sender, EventArgs e)
        {
            if (!btnSelecionar.Enabled) btnSelecionar.Visibility = BarItemVisibility.Never;
            else { this.MaximizeBox = false; this.MinimizeBox = false; }
            carragarTiposConsulta();
        }

        private void carragarTiposConsulta()
        {
            gradeTipoConsultas.DataSource = LtTipoConsultas = (List<TipoConsultaViewModel>)_TipoConsultasApp.Listar(null);
            IndexGridTipoConsulta = UtilidadesGenericas.ListaNula(LtTipoConsultas) ? -1 : 0;
        }

        private void btnNovo_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmDadosTipoConsultas chamada = IOC.InjectForm<frmDadosTipoConsultas>();
            chamada.ShowDialog();
            carragarTiposConsulta();
        }

        private void gridTipoConsultas_DoubleClick(object sender, EventArgs e)
        {
            try
            { 
            var indexCurrent = UtilidadesGenericas.GetGridIndexCurrent(sender, MousePosition);
            var form = IOC.InjectForm<frmDadosTipoConsultas>();

            form.EditarTipoConsultas(new List<TipoConsultaViewModel>() { LtTipoConsultas[indexCurrent] });
                carragarTiposConsulta();
            }
            catch (Exception) { }
        }

        private void btnSelecionar_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gridTipoConsultas.RowCount == 0) return;

            try
            {
                if (IndexGridTipoConsulta == -1) DadosTipoConsulta = new TipoConsultaViewModel() { Codigo=0,Descricao="Nenhuma"};
                else
                {
                    DadosTipoConsulta.Codigo = LtTipoConsultas[IndexGridTipoConsulta].Codigo;
                    DadosTipoConsulta.Descricao = LtTipoConsultas[IndexGridTipoConsulta].Descricao;
                    DadosTipoConsulta.Valor = LtTipoConsultas[IndexGridTipoConsulta].Valor;
                    DadosTipoConsulta.Tempo = LtTipoConsultas[IndexGridTipoConsulta].Tempo;
                    DadosTipoConsulta.CodEspecialidade = LtTipoConsultas[IndexGridTipoConsulta].CodEspecialidade;
                }
            }
            catch (Exception) { }
            Close();
        }

        private void gridTipoConsultas_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            IndexGridTipoConsulta = e.RowHandle;
        }

        private void btnVoltar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void gridTipoConsultas_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            IndexGridTipoConsulta = e.RowHandle;
        }
    }
}