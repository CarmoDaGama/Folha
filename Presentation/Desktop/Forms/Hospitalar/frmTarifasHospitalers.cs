using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Folha.Domain.Interfaces.Application.Hospitalar;
using Folha.Domain.Models.Hospitalar;
using Folha.Domain.Helpers;
using Folha.Driver.Framework.IOC;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Folha.Presentation.Desktop.Forms.Hospitalar
{
    public partial class frmTarifasHospitalers : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly ITarifaHospitalarApp _tarifaApp;
        public int index;
        private int cod;
        List<TarifaHospitalar> lista;
        public TarifaHospitalar tarifa { get; set; }
        public int Index { get; private set; } = -1;
        public frmTarifasHospitalers(ITarifaHospitalarApp tarifaApp)
        {
            InitializeComponent();
            Permicao();
            _tarifaApp = tarifaApp;
            Index = 0;
            Mostrar();
        }

        #region Permicao de Acesso
        int VerficaUsuario = int.Parse(UtilidadesGenericas.UsuarioPerfil.ToString());
        private void Permicao()
        {
            if (VerficaUsuario != 1)
            {
                if (UtilidadesGenericas.TemAcesso("Hospitalar#Tarifas#Criar") == false) { btnNovo.Enabled = false; }
                if (UtilidadesGenericas.TemAcesso("Hospitalar#Tarifas#Eliminar") == false) { btnEliminar.Enabled = false; }
                if (UtilidadesGenericas.TemAcesso("Hospitalar#Tarifas#Imprimir") == false) { btnImprimir.Enabled = false; }
            }
        }
        #endregion

        private void btnselect_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Index < 0) return;
            tarifa = lista[Index];
            Close();
        }

        public TarifaHospitalar GetTarifa()
        {
            ShowDialog();
            if (tarifa != (null) && tarifa.Codigo > 0)
            {
                return tarifa;
            }
            return null;
        }

        public void Mostrar()
        {
            GradeTarifa.DataSource = _tarifaApp.Listar(null);
            lista = (List<TarifaHospitalar>)_tarifaApp.Listar(null);
        }

        private void btnActualizar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Mostrar();
        }

        private void frmTarifasHospitalers_Load(object sender, System.EventArgs e)
        {
            Mostrar();
        }
        private void btnNovo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UtilidadesGenericas.Busca.Codigo = string.Empty;
            var container = new SimpleInjector.Container();
            IOC.RegistrarInjecao(container);
            container.GetInstance<frmTarifasHospitalar>().ShowDialog();
            if (UtilidadesGenericas.Busca.Alterou) Mostrar();
        }

        private void gridTarifa_DoubleClick(object sender, System.EventArgs e)
        {
            //if (usuario != 1)
            //{
            //    if (UtilidadesGenericas.TemAcesso("Hospitalar#Profissional de Saude#Alterar") == false)
            //        return;
            //}
            //else
            //{
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(MousePosition);
            GridHitInfo info = view.CalcHitInfo(pt);
            UtilidadesGenericas.Busca.Codigo = gridTarifa.GetRowCellValue(info.RowHandle, "Codigo").ToString();
            UtilidadesGenericas.Busca.Alterou = false;
            var container = new SimpleInjector.Container();
            IOC.RegistrarInjecao(container);
            container.GetInstance<frmTarifasHospitalar>().ShowDialog();
            if (UtilidadesGenericas.Busca.Alterou) Mostrar();

            // }
        }

        private void gridTarifa_RowClick(object sender, RowClickEventArgs e)
        {
            cod = int.Parse(gridTarifa.GetRowCellValue(e.RowHandle, "Codigo").ToString());
            Index = e.RowHandle;
            tarifa = lista[Index];
        }

        private void btnEliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (DialogResult.Yes == (MessageBox.Show("Deseja Eliminar Registo?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Information)))
            {
                try
                {
                    _tarifaApp.Delete(new TarifaHospitalar()
                    {
                        Codigo = cod,
                    });
                    MessageBox.Show("Registro excluído ", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Mostrar();
            }
                catch (Exception)
            {
                throw new Exception("Erro ao Eliminar\n");
            }
        }
        }

        private void btnFechar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
    }
}