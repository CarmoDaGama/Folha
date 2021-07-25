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
using Folha.Domain.Interfaces.Application.Inventario;
using Folha.Domain.Models.Inventario;
using Folha.Driver.Framework.IOC;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Folha.Domain.Helpers;
using Folha.Presentation.Desktop.Forms.Apresenta_Doc;
using Folha.Presentation.Desktop.Classe;
using Folha.Domain.ViewModels.Inventario;
using DevExpress.XtraBars;

namespace Folha.Presentation.Desktop.Forms.Armazens
{
    public partial class frmImpostos : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly IImpostoApp _impostoApp;
        public int index;
        private int cod;
        List<ImpostoViewModel> lista;
        public ImpostoViewModel Imposto { get; set; }
        public int Index { get; private set; } = -1;

        public frmImpostos(IImpostoApp impostoApp)
        {
            InitializeComponent();
            btnselect.Visibility = BarItemVisibility.Never;

            _impostoApp = impostoApp;
            Permicao();
            Index = 0;
        }

        public void Mostrar()
        {
            lista =_impostoApp.GetAll();
            GradeImposto.DataSource = lista;
        }
        #region Permicao
        int x = int.Parse(UtilidadesGenericas.UsuarioPerfil.ToString());
        private void Permicao()
        {
            if (x != 1)
            {
                // Sessao

                if (UtilidadesGenericas.TemAcesso("Inventario#Imposto#Novo") == false) { btnNovo.Enabled = false; }
                if (UtilidadesGenericas.TemAcesso("Inventario#Imposto#Eliminar") == false) { btnEliminar.Enabled = false; }
            }
        }
        #endregion

        private void frmImpostos_Load(object sender, EventArgs e)
        {
            Mostrar();
        }

        private void btnNovo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UtilidadesGenericas.Busca.Codigo = string.Empty;
            frmImposto chamada = IOC.InjectForm<frmImposto>();
            UtilidadesGenericas.ChamarNoPrincipal(chamada);
            if (UtilidadesGenericas.Busca.Alterou) Mostrar();
        }

        private void btnEliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Equals(lista, null) || lista.Count == 0)
            {
                MessageBox.Show("Não Tem item na lista!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (cod == 1)
                MessageBox.Show("Este item não pode ser alterado!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (DialogResult.Yes == (MessageBox.Show("Deseja Eliminar Registo?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Information)))
            {
                try
                {
                    _impostoApp.Delete(new ImpostoViewModel()
                    {
                        Codigo = cod,
                    });
                    MessageBox.Show("Registro excluído ", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Mostrar();
                }
                catch (Exception)
                {
                    return;
                    throw new Exception("Erro ao Deletar\n");
                }
            }
        }

        private void gridImposto_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (index <= -1) { return; }

                GridHitInfo info = UtilidadesGenericas.GetGridHitInfo(sender, MousePosition);
                cod = Convert.ToInt16(gridImposto.GetRowCellValue(info.RowHandle, "Codigo"));

                if (btnselect.Visibility == BarItemVisibility.Never)
                {
                    if (int.Parse(gridImposto.GetRowCellValue(info.RowHandle, "Codigo").ToString()) == 1)
                    {
                        UtilidadesGenericas.MsgShow(
                            "AVISO",
                            "Este item não pode ser alterado!", 
                            MessageBoxIcon.Information, 
                            MessageBoxButtons.OK
                        );
                        return;
                    }

                    var imposto = _impostoApp.GetById(cod);

                    IOC.InjectForm<frmImposto>().EditarImposto(imposto);

                    if (UtilidadesGenericas.Busca.Alterou) Mostrar();

                }
                else if (btnselect.Visibility == BarItemVisibility.Always)
                {
                    if (Index < 0) return;
                    Imposto = lista.Where(imp => imp.Codigo == cod).FirstOrDefault();
                    Close();
                }
            }
            catch (Exception)
            {
                UtilidadesGenericas.MsgShow(
                    "Erro",
                    "Seleciona uma linha ",
                    MessageBoxIcon.Error, 
                    MessageBoxButtons.OK);
            }
        }

        private void btnselect_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Index < 0) return;
            Imposto = lista.Where(imp => imp.Codigo == cod).FirstOrDefault();
            Close();
        }

        private void gridImposto_RowClick(object sender, RowClickEventArgs e)
        {
            cod = int.Parse(gridImposto.GetRowCellValue(e.RowHandle, "Codigo").ToString());
            Index = e.RowHandle;
            Imposto = lista.Where(imp => imp.Codigo == cod).FirstOrDefault();
        }
          public ImpostoViewModel GetImposto()
        {
            ShowDialog();
            if (Imposto != (null) && Imposto.Codigo > 0)
            {
                return Imposto;
            }
            else
            {
                return null;
            }
        }

        
    }
}