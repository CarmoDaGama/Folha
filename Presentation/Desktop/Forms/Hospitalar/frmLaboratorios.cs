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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Folha.Driver.Framework.IOC;
using Folha.Domain.Helpers;

namespace Folha.Presentation.Desktop.Forms.Hospitalar
{
    public partial class frmLaboratorios : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly ILaboratorioApp _labApp;
        public int index;
        private int cod;
        public Laboratorio laboratorio { get; set; }
        public int Index { get; private set; } = -1;
        List<Laboratorio> lista;
        public frmLaboratorios(ILaboratorioApp labApp)
        {
            InitializeComponent();
            _labApp = labApp;
            Index = 0;
            VerEstados();
        }
        #region METODOS
        
        private void VerEstados()
        {
            if (cboEstados.SelectedItem.ToString() == "EM PROCESSO")
            {
                lista = (List<Laboratorio>)_labApp.Listar(null, false).Where(a => a.status == 1).ToList();
                GradeLaboratorio.DataSource = lista;

            }
            else if (cboEstados.SelectedItem.ToString() == "PROCESSADO")
            {
                lista = (List<Laboratorio>)_labApp.Listar(null, false).Where(a => a.status == 0).ToList();
                GradeLaboratorio.DataSource = lista;
            }
            else if (cboEstados.SelectedItem.ToString() == "TODOS")
            {
                lista = (List<Laboratorio>)_labApp.Listar(null, false);
                GradeLaboratorio.DataSource =lista ;
            }
        }
        #endregion
        private void gridLaboratorio_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                GridView view = (GridView)sender;
                Point pt = view.GridControl.PointToClient(MousePosition);
                GridHitInfo info = view.CalcHitInfo(pt);
                UtilidadesGenericas.Busca.Codigo = gridLaboratorio.GetRowCellValue(info.RowHandle, "Codigo").ToString();
                UtilidadesGenericas.Busca.Alterou = false;
                var container = new SimpleInjector.Container();
                IOC.RegistrarInjecao(container);
                container.GetInstance<frmLaboratorio>().ShowDialog();
                if (UtilidadesGenericas.Busca.Alterou) VerEstados();
            }
            catch (Exception)
            {
                MessageBox.Show("Seleciona uma linha ", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }       

        private void cboEstados_SelectedIndexChanged(object sender, EventArgs e)
        {
            VerEstados();
        }

        private void frmLaboratorios_Load(object sender, EventArgs e)
        {

        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }
    }
}