using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Folha.Domain.Interfaces.Application.Inventario;
using Folha.Domain.Models.Inventario;
using Folha.Domain.Helpers;
using Folha.Driver.Framework.IOC;
using Folha.Presentation.Desktop.Classe;
using Folha.Presentation.Desktop.Forms.Apresenta_Doc;
using Folha.Presentation.Desktop.Separadores.Armazens;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Folha.Presentation.Desktop.Forms.Armazens
{

    public partial class frmCategorias : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly ICategoriaApp _categoriaApp;
        public int index;
        private int cod;
        List<Categoria> lista;
        public Categoria Categoria { get; set; }
        public int Index { get; private set; } = -1;
        public frmCategorias(ICategoriaApp categoriaApp)
        {
            InitializeComponent();
            _categoriaApp = categoriaApp;
            btnselect.Visibility = BarItemVisibility.Never;
            Index = 0;
            Permicao();
        }

        #region Permicao
        int x = int.Parse(UtilidadesGenericas.UsuarioPerfil.ToString());

        private void Permicao()
        {
            if (x != 1)
            {
                if (UtilidadesGenericas.TemAcesso("Inventario#Familia de Produtos#Novo") == false) { btnNovo.Enabled = false; }
                if (UtilidadesGenericas.TemAcesso("Inventario#Familia de Produtos#Eliminar") == false) { btnEliminar.Enabled = false; }
            }
        }
        #endregion

        public Categoria GetCategoria()
        {
            ShowDialog();
            if (Categoria != (null) && Categoria.codigo > 0)
            {
                return Categoria;
            }
            else
            {
                return null;
            }

        }
        public void CarregarAndMostrarCategorias()
        {
            lista = (List<Categoria>)_categoriaApp.Listar(null, false);

            GradeCategoria.DataSource =lista;
        }
        private void frmCategorias_Load(object sender, System.EventArgs e)
        {
            CarregarAndMostrarCategorias();
        }    
        private void btnNovo_ItemClick(object sender,ItemClickEventArgs e)
        {
            UtilidadesGenericas.Busca.Codigo = string.Empty;
            if (btnselect.Visibility == BarItemVisibility.Never)
            {
                frmCategoria chamada = IOC.InjectForm<frmCategoria>();
                UtilidadesGenericas.ChamarNoPrincipal(chamada);
                if (UtilidadesGenericas.Busca.Alterou) CarregarAndMostrarCategorias();
            }else
            {
                IOC.InjectForm<frmCategoria>().ShowDialog();
            }
        }

        private void btnEliminar_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Equals(lista, null) || lista.Count == 0)
            {
                UtilidadesGenericas.MsgShow(
                    "AVISO", 
                    "Não Tem item na lista!",
                    MessageBoxIcon.Information, 
                    MessageBoxButtons.OK
                );

                return;
            }
            if (cod == 1)
                UtilidadesGenericas.MsgShow(
                    "AVISO", 
                    "Este item não pode ser alterado!", 
                    MessageBoxIcon.Information,
                    MessageBoxButtons.OK
                );


            if (DialogResult.Yes == (MessageBox.Show("Deseja Eliminar Registo?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Information)))
            {
                try
                {
                    _categoriaApp.Delete(new Categoria()
                    {
                        codigo = cod,
                    });
                    UtilidadesGenericas.MsgShow("SUCESSO", "Registro excluído", MessageBoxIcon.None, MessageBoxButtons.OK);


                    CarregarAndMostrarCategorias();
                }
                catch (Exception)
                {
                    throw new Exception("Erro ao Eliminar\n");
                }

            }
        }

        private void btnSelecionar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Index < 0) return;
            Categoria = lista[Index];
            Close();
        }

    
        private void gridCategoria_DoubleClick_1(object sender, EventArgs e)
        {
            if (btnselect.Visibility == BarItemVisibility.Never)
            {
                GridHitInfo info = UtilidadesGenericas.GetGridHitInfo(sender, MousePosition);


                if (int.Parse(gridCategoria.GetRowCellValue(info.RowHandle, "codigo").ToString()) == 1)
                {
                    UtilidadesGenericas.MsgShow(
                        "AVISO",
                        "Este item não pode ser alterado!", 
                        MessageBoxIcon.Information,
                        MessageBoxButtons.OK
                    );
                    return;
                }
                UtilidadesGenericas.Busca.Editar = true;
                UtilidadesGenericas.Busca.Codigo = cod.ToString();
                UtilidadesGenericas.Busca.Descricao = gridCategoria.GetRowCellValue(info.RowHandle, "descricao").ToString();
                UtilidadesGenericas.Busca.Vender = gridCategoria.GetRowCellValue(info.RowHandle, "Vender").ToString();

                
                UtilidadesGenericas.ChamarNoPrincipal(IOC.InjectForm<frmCategoria>());
                if (UtilidadesGenericas.Busca.Alterou) CarregarAndMostrarCategorias();

                
            }
            else if (btnselect.Visibility == BarItemVisibility.Always)
            {
                if (Index < 0) return;
                Categoria = lista.Where(c => c.codigo == cod).FirstOrDefault();
                Close();
            }
        }

        private void gridCategoria_RowClick_1(object sender, RowClickEventArgs e)
        {
            cod = int.Parse(gridCategoria.GetRowCellValue(e.RowHandle, "codigo").ToString());
            Index = e.RowHandle;
            Categoria = lista.Where(c => c.codigo == cod).FirstOrDefault();

        }

        private void btnselect_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Index < 0) return;
            Categoria = lista.Where(c => c.codigo == cod).FirstOrDefault();
            Close();
        }

       
    }
}