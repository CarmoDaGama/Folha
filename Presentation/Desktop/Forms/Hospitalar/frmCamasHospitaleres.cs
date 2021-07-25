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
using Folha.Driver.Framework.IOC;
using Folha.Domain.Interfaces.Application.Hospitalar;
using Folha.Domain.Models.Hospitalar;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Folha.Domain.Helpers;

namespace Folha.Presentation.Desktop.Forms.Hospitalar
{
    public partial class frmCamasHospitaleres : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly ICamasHospitalarApp _camaApp;
        public int index;
        private int cod;
        List<CamasHospitalar> lista;
        public CamasHospitalar camas { get; set; }
        public int Index { get; private set; } = -1;
        public string Estado { get; private set; }

        public frmCamasHospitaleres(ICamasHospitalarApp camaApp)
        {
            InitializeComponent();
            Permicao();
            _camaApp = camaApp;
            btnselect.Visibility = BarItemVisibility.Never;
            Index = 0;
            Mostrar();
        }
        #region Permicao de Acesso
        int VerficaUsuario = int.Parse(UtilidadesGenericas.UsuarioPerfil.ToString());
        private void Permicao()
        {
            if (VerficaUsuario != 1)
            {
                if (UtilidadesGenericas.TemAcesso("Hospitalar#Camas#Criar") == false) { btnNovo.Enabled = false; }
                if (UtilidadesGenericas.TemAcesso("Hospitalar#Camas#Eliminar") == false) { btnEliminar.Enabled = false; }
                if (UtilidadesGenericas.TemAcesso("Hospitalar#Camas#Imprimir") == false) { btnPrint.Enabled = false; }
            }
        }
        #endregion
        private void btnselect_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Index < 0) return;
            camas = lista[Index];
            Close();
        }
        public CamasHospitalar GetCamas()
        {
            ShowDialog();
            if (camas != (null) && camas.Codigo > 0)
            {
                return camas;
            }
            return null;
        }
        public void Mostrar()
        {
            GradeCamas.DataSource = _camaApp.Listar(null);
            lista = (List<CamasHospitalar>)_camaApp.Listar(null);
        }
        private void btnNovo_ItemClick(object sender, ItemClickEventArgs e)
        {
            UtilidadesGenericas.Busca.Alterou = false;
            UtilidadesGenericas.Busca.Codigo = string.Empty;
            var container = new SimpleInjector.Container();
            IOC.RegistrarInjecao(container);
            container.GetInstance<frmCamasHospitalar>().ShowDialog();
            if (UtilidadesGenericas.Busca.Alterou) Mostrar();
        }
        private void btnEliminar_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Estado == "Sim")
            {
                MessageBox.Show("A Cama não pode ser Eliminada porque encontra-se em uso", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                if (DialogResult.Yes == (MessageBox.Show("Deseja Eliminar Registo?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Information)))
                {
                    try
                    {
                        _camaApp.Delete(new CamasHospitalar()
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

          
        }
        private void gridCamas_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            cod = int.Parse(gridCamas.GetRowCellValue(e.RowHandle, "Codigo").ToString());
            Estado = gridCamas.GetRowCellValue(e.RowHandle, "Ocupado").ToString();

            Index = e.RowHandle;
            camas = lista[Index];
        }
        private void gridCamas_DoubleClick(object sender, EventArgs e)
        {           
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(MousePosition);
            GridHitInfo info = view.CalcHitInfo(pt);
            UtilidadesGenericas.Busca.Codigo = gridCamas.GetRowCellValue(info.RowHandle, "Codigo").ToString();
            UtilidadesGenericas.Busca.Alterou = false;
            string Ocupado = gridCamas.GetRowCellValue(info.RowHandle, "Ocupado").ToString();
            if (Ocupado == "Sim")
            {
                MessageBox.Show("A Cama não pode ser alterada porque encontra-se em uso", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                var container = new SimpleInjector.Container();
                IOC.RegistrarInjecao(container);
                container.GetInstance<frmCamasHospitalar>().ShowDialog();
                if (UtilidadesGenericas.Busca.Alterou) Mostrar();
            }
           
        }
        private void btnFechar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }
        private void btnActualizar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Mostrar();
        }

        private void frmCamasHospitaleres_Load(object sender, EventArgs e)
        {

        }
    }
}