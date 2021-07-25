using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Folha.Domain.Interfaces.Application.Documentos;
using Folha.Domain.Models.Documentos;
using Folha.Domain.Helpers;
using Folha.Driver.Framework.IOC;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Folha.Presentation.Desktop.Forms.Documentos
{
    public partial class frmCondicoesPagamento : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly ICondicoesPagamentoApp _condicoes;
        public int index;
        private int cod;
        List<CondicoesPagamento> lista;
        public CondicoesPagamento condicoes { get; set; }
        public int Index { get; private set; } = -1;
        public frmCondicoesPagamento(ICondicoesPagamentoApp condicoes)
        {
            InitializeComponent();
            _condicoes = condicoes;
            Index = 0;
            Permicao();
        }
        #region Permicao
        int x = int.Parse(UtilidadesGenericas.UsuarioPerfil.ToString());

        private void Permicao()
        {
            if (x != 1)
            {
                if (UtilidadesGenericas.TemAcesso("Vender#Condições Pagamento#Novo") == false) { btnNovo.Enabled = false; }
                if (UtilidadesGenericas.TemAcesso("Vender#Condições Pagamento#Eliminar") == false) { btnEliminar.Enabled = false; }
            }
        }
        #endregion
        public CondicoesPagamento GetCondicoesPagamento()
        {
            btnselect.Visibility = BarItemVisibility.Always;
            ShowDialog();
            if (condicoes != (null) && condicoes.Codigo > 0)
            {
                return condicoes;
            }
            else
            {
                return null;
            }

        }

        public void Mostrar()
        {
            lista = (List<CondicoesPagamento>)_condicoes.Listar(null, false);
            GradeCondicoes.DataSource = lista;
        }
        private void frmCondicoesPagamento_Load(object sender, EventArgs e)
        {
            Mostrar();
            condicoes = null;
        }

        private void btnNovo_ItemClick(object sender, ItemClickEventArgs e)
        {
            UtilidadesGenericas.Busca.Codigo = string.Empty;
           

            frmCondicoePagamento chamada = IOC.InjectForm<frmCondicoePagamento>();
            UtilidadesGenericas.ChamarNoPrincipal(chamada);
            if (UtilidadesGenericas.Busca.Alterou) Mostrar();
        }

        private void btnEliminar_ItemClick(object sender, ItemClickEventArgs e)
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
                    _condicoes.Delete(new CondicoesPagamento()
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

        private void btnSelect_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Index < 0) return;
            condicoes = lista[Index];
            Close();
        }

        private void gridCondicoes_DoubleClick(object sender, EventArgs e)
        {
            if (btnselect.Visibility == BarItemVisibility.Never)
            {

                GridView view = (GridView)sender;
                Point pt = view.GridControl.PointToClient(MousePosition);
                GridHitInfo info = view.CalcHitInfo(pt);


                if (int.Parse(gridCondicoes.GetRowCellValue(info.RowHandle, "Codigo").ToString()) == 1 || int.Parse(gridCondicoes.GetRowCellValue(info.RowHandle, "Codigo").ToString()) == 2)
                {
                    MessageBox.Show("Este item não pode ser alterado!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                UtilidadesGenericas.Busca.Editar = true;
                UtilidadesGenericas.Busca.Codigo = gridCondicoes.GetRowCellValue(Index, "Codigo").ToString();
                UtilidadesGenericas.Busca.Descricao = gridCondicoes.GetRowCellValue(info.RowHandle, "Descricao").ToString();
                UtilidadesGenericas.Busca.Dias = gridCondicoes.GetRowCellValue(info.RowHandle, "Dias").ToString();


                frmCondicoePagamento chamada = IOC.InjectForm<frmCondicoePagamento>();
                UtilidadesGenericas.ChamarNoPrincipal(chamada);
                if (UtilidadesGenericas.Busca.Alterou) Mostrar();


            }
            else if (btnselect.Visibility == BarItemVisibility.Always)
            {
                if (Index < 0) return;
                condicoes = new CondicoesPagamento()
                {
                    Codigo = Convert.ToInt16(gridCondicoes.GetRowCellValue(Index, "Codigo")),
                    Descricao = gridCondicoes.GetRowCellValue(Index, "Descricao").ToString(),
                    Dias = Convert.ToInt16(gridCondicoes.GetRowCellValue(Index, "Dias"))
                };
                Close();
            }
        }

        private void gridCondicoes_RowClick(object sender, RowClickEventArgs e)
        {
            cod = int.Parse(gridCondicoes.GetRowCellValue(e.RowHandle, "Codigo").ToString());
            Index = e.RowHandle;
            //condicoes = new CondicoesPagamento()
            //{
            //    Codigo = Convert.ToInt16(gridCondicoes.GetRowCellValue(Index, "Codigo")),
            //    Descricao = gridCondicoes.GetRowCellValue(Index, "Descricao").ToString(),
            //    Dias = Convert.ToInt16(gridCondicoes.GetRowCellValue(Index, "Dias"))
            //};
        }
    }
}