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
using DevExpress.XtraGrid.Views.Grid;
using Folha.Driver.Framework.IOC;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Folha.Domain.Models.Hospitalar;
using Folha.Domain.Interfaces.Application.Hospitalar;
using Folha.Domain.ViewModels.Hospitalar;
using Folha.Domain.Helpers;

namespace Folha.Presentation.Desktop.Forms.Hospitalar
{
    public partial class frmQuartosHospilares : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly IQuartosHospitalarApp _quartoApp;
        public int index;
        private int cod;
        List<QuartosHospitalar> lista;
        private List<CamasQuartosHospitalarViewModel> listaCamas;

        public QuartosHospitalar quartos { get; set; }
        public int Index { get; private set; } = -1;

        public frmQuartosHospilares(IQuartosHospitalarApp quartoApp)
        {
            InitializeComponent();
            Permicao();
            _quartoApp = quartoApp;
            Mostrar();

        }
        #region Permicao de Acesso
        int VerficaUsuario = int.Parse(UtilidadesGenericas.UsuarioPerfil.ToString());
        private void Permicao()
        {
            if (VerficaUsuario != 1)
            {
                if (UtilidadesGenericas.TemAcesso("Hospitalar#Quartos#Criar") == false) { btnNovo.Enabled = false; }
                if (UtilidadesGenericas.TemAcesso("Hospitalar#Quartos#Eliminar") == false) { btnEliminar.Enabled = false; }
                if (UtilidadesGenericas.TemAcesso("Hospitalar#Quartos#Imprimir") == false) { btnPrint.Enabled = false; }
            }
        }
        #endregion

        private void btnselect_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Index < 0) return;

            quartos = lista[Index];
            Close();
        }
        public QuartosHospitalar GetQuartos()
        {
            ShowDialog();
            if (quartos != (null) && quartos.Codigo > 0)
            {
                return quartos;
            }
            return null;
        }
        public void Mostrar()
        {
            lista = (List<QuartosHospitalar>)_quartoApp.Listar(null);
            GradeQuartos.DataSource = lista;
          
        }

        private void btnEliminar_ItemClick(object sender, ItemClickEventArgs e)
        {
         
            if (DialogResult.Yes == (MessageBox.Show("Deseja Eliminar Registo?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Information)))
            {
                try
                {
                    listaCamas = _quartoApp.GetCamas(cod);
            
                    if (!UtilidadesGenericas.ListaNula(listaCamas))
                    {
                        MessageBox.Show("Existem Camas Nesse Quarto, Porfavor Retire as Camas para poder eliminar o Quarto", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return ;
                    }
                    else
                    {
                        _quartoApp.Delete(new QuartosHospitalar()
                        {
                            Codigo = cod,
                        });
                        MessageBox.Show("Registro excluído ", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Mostrar();
                    }


                }
                catch (Exception)
                {
                    throw new Exception("Erro ao Eliminar\n");
                }
            }
        }

        private void gridQuartos_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            cod = int.Parse(gridQuartos.GetRowCellValue(e.RowHandle, "Codigo").ToString());
            Index = e.RowHandle;
            quartos = lista[Index];
        }

        private void gridQuartos_DoubleClick(object sender, EventArgs e)
        {
          
                GridView view = (GridView)sender;
                Point pt = view.GridControl.PointToClient(MousePosition);
                GridHitInfo info = view.CalcHitInfo(pt);
                UtilidadesGenericas.Busca.Codigo = gridQuartos.GetRowCellValue(info.RowHandle, "Codigo").ToString();
                UtilidadesGenericas.Busca.Alterou = false;
                var container = new SimpleInjector.Container();
                IOC.RegistrarInjecao(container);
                container.GetInstance<frmQuartosHospilar>().ShowDialog();
                if (UtilidadesGenericas.Busca.Alterou == true) Mostrar();
        }

        private void btnFechar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void btnNovo_ItemClick(object sender, ItemClickEventArgs e)
        {
            UtilidadesGenericas.Busca.Alterou = false;
            UtilidadesGenericas.Busca.Codigo = string.Empty;
            IOC.InjectForm<frmQuartosHospilar>().Show();
            if (UtilidadesGenericas.Busca.Alterou == true) Mostrar();
        }

        private void btnActualizar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Mostrar();
        }
    }
}