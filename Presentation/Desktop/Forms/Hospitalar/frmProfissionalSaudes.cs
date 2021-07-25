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
using Folha.Domain.Models.Hospitalar;
using Folha.Domain.Interfaces.Application.Hospitalar;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Folha.Domain.Helpers;

namespace Folha.Presentation.Desktop.Forms.Hospitalar
{
    public partial class frmProfissionalSaudes : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly IProfissinalSaudeApp _ProfApp;
        public int index;
        private int cod;
        public ProfissinalSaude prof { get; set; }
        public int Index { get; private set; } = -1;
        List<ProfissinalSaude> lista;
        int usuario = int.Parse(UtilidadesGenericas.UsuarioPerfil.ToString());

        public frmProfissionalSaudes(IProfissinalSaudeApp profApp)
        {
            InitializeComponent();
            _ProfApp = profApp;
            Mostrar();
            Index = 0;
            Permicao();
        }
        #region Permicao de Acesso
        private void Permicao()
        {
            if (usuario != 1)
            {
                if (UtilidadesGenericas.TemAcesso("Hospitalar#Profissional de Saude#Criar") == false) { btnNovo.Enabled = false; }
                if (UtilidadesGenericas.TemAcesso("Hospitalar#Profissional de Saude#Eliminar") == false) { btnEliminar.Enabled = false; }
                if (UtilidadesGenericas.TemAcesso("Hospitalar#Profissional de Saude#Imprimir") == false) { btnPrint.Enabled = false; }
            }
        }
        #endregion
        public void Mostrar()
        {
            lista = (List<ProfissinalSaude>)_ProfApp.Listar(null, false).Where(a => a.status == 1).ToList();
            GradeProfissional.DataSource = lista;

        }
        private void btnNovo_ItemClick(object sender, ItemClickEventArgs e)
        {
            UtilidadesGenericas.Busca.Codigo = string.Empty;
            IOC.InjectForm<frmProfissionalSaude>().Show();
            if (UtilidadesGenericas.Busca.Alterou == true) Mostrar();
        }
        private void gridProfissional_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
                Point pt = view.GridControl.PointToClient(MousePosition);
                GridHitInfo info = view.CalcHitInfo(pt);
                UtilidadesGenericas.Busca.Codigo = gridProfissional.GetRowCellValue(info.RowHandle, "Codigo").ToString();
                UtilidadesGenericas.Busca.Alterou = false;
                var container = new SimpleInjector.Container();
                IOC.RegistrarInjecao(container);
                container.GetInstance<frmProfissionalSaude>().ShowDialog();
                if (UtilidadesGenericas.Busca.Alterou == true) Mostrar();
           
        }

        private void btnSelecionar_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Index < 0) return;
            prof = lista[Index];
            Close();
        }
        public ProfissinalSaude GetProfissional()
        {
            ShowDialog();
            if (prof != (null) && prof.Codigo > 0)
            {
                return prof;
            }
            else
            {
                return null;
            }

        }
        private void gridProfissional_RowClick(object sender, RowClickEventArgs e)
        {
            cod = int.Parse(gridProfissional.GetRowCellValue(e.RowHandle, "Codigo").ToString());
            Index = e.RowHandle;
            prof = lista[Index];
        }

        private void btnEliminar_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (MessageBox.Show("Deseja Realmente Eliminar ", "Eliminar ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
             _ProfApp.Eliminar(new ProfissinalSaude()
                {
                    Codigo = cod,
                });
                MessageBox.Show(" Eliminado Com Sucesso", "Eliminar ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GradeProfissional.DataSource = _ProfApp.Listar(null, false).Where(a => a.status == 1);
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }
    }
}