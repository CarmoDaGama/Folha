using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Folha.Domain.Interfaces.Application.Inventario;
using Folha.Domain.Helpers;
using Folha.Driver.Framework.IOC;
using Folha.Presentation.Desktop.Classe;
using Folha.Presentation.Desktop.Forms.Apresenta_Doc;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Folha.Presentation.Desktop.Separadores.Armazens
{
    public partial class frmVerArmazens : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        public int index;
        private readonly IArmazemApp _armazemApp;
        private int cod;
        List<Domain.Models.Inventario.Armazens> lista;
        public frmVerArmazens(IArmazemApp armazemApp)
        {
            InitializeComponent();
            _armazemApp = armazemApp;
            Permicao();
        }

        #region Permicao
        int x = int.Parse(UtilidadesGenericas.UsuarioPerfil.ToString());

        private void Permicao()
        {
            if (x != 1)
            {
                if (UtilidadesGenericas.TemAcesso("Inventario#Armazens#Criar") == false) { btnNovo.Enabled = false; }
                if (UtilidadesGenericas.TemAcesso("Inventario#Armazens#Eliminar") == false) { btnEliminar.Enabled = false; }
                if (UtilidadesGenericas.TemAcesso("Inventario#Armazens#Imprimir") == false) { btnImprimir.Enabled = false; }
            }
        }
        #endregion

        
        private void frmVerArmazens_Load(object sender, EventArgs e)
        {
            Mostra();
           
        }

        private void Mostra()
        {
            lista = (List<Domain.Models.Inventario.Armazens>)_armazemApp.Listar(null, false);
            GradeArmazem.DataSource = lista;
        }

        private void gridarmazem_RowClick(object sender, RowClickEventArgs e)
        {
            cod = int.Parse(gridarmazem.GetRowCellValue(e.RowHandle, "codigo").ToString());
        }
        private void gridarmazem_DoubleClick(object sender, EventArgs e)
        {
            GridHitInfo info = UtilidadesGenericas.GetGridHitInfo(sender, MousePosition);

            if (int.Parse(gridarmazem.GetRowCellValue(info.RowHandle, "codigo").ToString()) == 1)
            {
                UtilidadesGenericas.MsgShow(
                    "AVISO", 
                    "Este item não pode ser alterado!", 
                    MessageBoxIcon.Information, 
                    MessageBoxButtons.OK);
                return;
            }
            UtilidadesGenericas.Busca.Editar = true;
                UtilidadesGenericas.Busca.Codigo = cod.ToString();
                UtilidadesGenericas.Busca.Descricao = gridarmazem.GetRowCellValue(info.RowHandle, "descricao").ToString();
            
                IOC.InjectForm<frmArmazens>().ShowDialog();

            lista = (List<Domain.Models.Inventario.Armazens>)_armazemApp.Listar(null, false);
            GradeArmazem.DataSource = lista;
        }
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UtilidadesGenericas.Busca.Codigo = string.Empty;
            IOC.InjectForm<frmArmazens>().ShowDialog();
            Mostra();            
        }

        private void btnEliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (cod == 1)
                UtilidadesGenericas.MsgShow(
                    "AVISO",
                    "Este item não pode ser alterado!", 
                    MessageBoxIcon.Information, 
                    MessageBoxButtons.OK);

            if (DialogResult.Yes == (MessageBox.Show("Deseja Eliminar Registo?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Information)))
            {
                try
                {
                    _armazemApp.Delete(new Domain.Models.Inventario.Armazens()
                    {
                        codigo = cod,
                    });
                    UtilidadesGenericas.MsgShow(
                         "AVISO",
                         "Registro excluído ",
                         MessageBoxIcon.Information,
                         MessageBoxButtons.OK
                    );

                    lista = (List<Domain.Models.Inventario.Armazens>)_armazemApp.Listar(null, false);
                    GradeArmazem.DataSource = lista;
                }
                catch (Exception)
                {
                    throw new Exception("Erro ao Deletar\n");
                }
            }
        }

        private void btnImprimir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            lista = (List<Domain.Models.Inventario.Armazens>)_armazemApp.Listar(null, false);

            if (Equals(lista, null) || lista.Count == 0)
            {
                UtilidadesGenericas.MsgShow("Lista Está vazia");
                return;
            }
            lista[0].CabecalhoEmpresa = Controle.CabecalhoEmpresa;

            new frmApresentaReport().ApresentarReportArmazens(lista);
        }

        private void btnFechar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btnActualizar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Mostra();
        }
    }
}