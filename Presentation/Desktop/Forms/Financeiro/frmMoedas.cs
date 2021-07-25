using DevExpress.XtraGrid.Views.Grid;
using Folha.Domain.Interfaces.Application.Financeiro;
using Folha.Domain.Models.Financeiro;
using Folha.Domain.ViewModels.Financeiro;
using Folha.Domain.Helpers;
using Folha.Driver.Framework.IOC;
using Folha.Presentation.Desktop.Forms.Apresenta_Doc;
using Folha.Presentation.Desktop.Forms.Financeiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Folha.Presentation.Desktop.Separadores.Financeiro
{
    public partial class frmMoedas : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly IMoedaApp _Moeda;
        int codigoB=1;
        int Index = 0;
        private List<MostraMoedasViewModel> ListMoeda;
        public frmMoedas(IMoedaApp Moeda)
        {
            InitializeComponent();
            Permicao();
            _Moeda = Moeda;  
        }
        #region Permicao de Acesso
        int VerficaUsuario = int.Parse(UtilidadesGenericas.UsuarioPerfil.ToString());
        private void Permicao()
        {
            if (VerficaUsuario != 1)
            {
                if (UtilidadesGenericas.TemAcesso("Financeiro#Moedas#Criar") == false) { btnNovo.Enabled = false; }
                if (UtilidadesGenericas.TemAcesso("Financeiro#Moedas#Eliminar") == false) { btnEliminar.Enabled = false; }
                if (UtilidadesGenericas.TemAcesso("Financeiro#Moedas#Imprimir") == false) { btnPrint.Enabled = false; }
            }
        }
        #endregion
        private void frmMoedas_Load(object sender, EventArgs e)
        {
            Mostrar();
            
        }

        private void Mostrar()
        {
            ListMoeda = (List<MostraMoedasViewModel>)_Moeda.Listar();
            gradeMoeda.DataSource = ListMoeda;
        }

        private void gridMoedas_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            codigoB = int.Parse(gridMoedas.GetRowCellValue(e.RowHandle, "Codigo").ToString());
            Index = e.RowHandle;
       
        }

        private void gridMoedas_DoubleClick(object sender, EventArgs e)
        {
            var moeda = ListMoeda.Where(m => m.Codigo == codigoB).FirstOrDefault();
            IOC.InjectForm<frmCadMoeda>().ReceberParametros(moeda);
             Mostrar();

        }

        private void btnNovo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmCadMoeda chamada = IOC.InjectForm<frmCadMoeda>();
            UtilidadesGenericas.ChamarNoPrincipal(chamada);
            Mostrar();
        }

        private void btnEliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Equals(ListMoeda, null) || ListMoeda.Count == 0)
            {
                UtilidadesGenericas.MsgShow(
                    "AVISO",
                    "Não Tem item na lista!", 
                    MessageBoxIcon.Information,
                    MessageBoxButtons.OK
                );
                return;
            }
            
                if (codigoB != 1)
                {
                    if (DialogResult.Yes == (MessageBox.Show("Deseja Eliminar Registo?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Information)))
                    {
                        try
                        {
                            _Moeda.deleteMoeda(new Moedas()
                            {
                                codigo = codigoB
                            }); 
                            gradeMoeda.DataSource = _Moeda.Listar();
                        }
                        catch (Exception)
                        {
                            throw new Exception("Erro ao eliminar ");
                        }
                    }
                }
                else UtilidadesGenericas.MsgShow(
                    "AVISO", 
                    "Este registro não pode ser excluído.", 
                    MessageBoxIcon.Information, 
                    MessageBoxButtons.OK);
            
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ListMoeda = (List<MostraMoedasViewModel>)_Moeda.Listar();
            if (ListMoeda.Count == 0)
            {
                UtilidadesGenericas.MsgShow(
                    "AVISO", 
                    "Sem relatório.", 
                    MessageBoxIcon.Information,
                    MessageBoxButtons.OK);
                return;
            }

            new frmApresentaReport().ApresentarReportMoeda(ListMoeda);
        }

        private void btnVoltar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void gridMoedas_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            Index = e.RowHandle;
        }
    }
}