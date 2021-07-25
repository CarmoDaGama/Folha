using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Folha.Domain.Interfaces.Application.Inventario;
using Folha.Domain.ViewModels.Inventario;
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

namespace Folha.Presentation.Desktop.Separadores.Principal
{
    public partial class frmVerProdutos : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly IArtigosApp _artigoApp;
        private readonly IArtigoStockApp _stockApp;
        private readonly IArmazemApp _armazemApp;
        private readonly ICategoriaApp _catetegoria;
        private int cod;
        private decimal Quantidade;
        public TipoCatgoria Tipo { get; set; } = TipoCatgoria.Categoria;

        int x = int.Parse(UtilidadesGenericas.UsuarioPerfil.ToString());

        public List<ProdutoStockViewModel> ArtigosStock { get; set; }
        public List<ArmazensViewModel> ListaArmazens { get; private set; }
        public List<CategoriaViewModel> ListaCategorias { get; private set; }
        private List<ArtigoViewModel> _Artigos;

        private int indexCategoria { get; set; }
        private int indexArmazem { get; set; }
        public IEnumerable<ArtigoViewModel> ArtigoLista { get; private set; }
        public int IndexPro { get; private set; }
        private Form FormularioPai { get;  set; }

        public frmVerProdutos(IArtigosApp artigoApp, IArmazemApp armazemApp, IArtigoStockApp stockApp, ICategoriaApp categoria)
        {
            InitializeComponent(); _artigoApp = artigoApp; _armazemApp = armazemApp; _catetegoria = categoria; _stockApp = stockApp;
        }
        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmCadastroProdutos chamada = IOC.InjectForm<frmCadastroProdutos>();
            UtilidadesGenericas.ChamarNoPrincipal(chamada);
            //chamada.ShowDialog();
            FormVerProdutos_Load(sender, e);
        }
        
        private void FormVerProdutos_Load(object sender, EventArgs e)
        {
            Permicao();
            carregarArmazem();
        }
     
        //private void CarregaTudo()
        //{
        //    //if (InvokeRequired)
        //    //{
        //    //    this.Invoke(new MethodInvoker(delegate {
        //    //        Permicao();
        //    //        carregarArmazem();
        //    //    }));
        //    //}
        //    //else
        //    //{
        //      Permicao();
        //        carregarArmazem();
        //    //}
        //}

       
        #region Permicao
        private void Permicao()
        {
            if (x != 1)
            {
                if (UtilidadesGenericas.TemAcesso("Inventario#Artigos#Criar") == false) { btnNovoProdut.Enabled = false; }
                if (UtilidadesGenericas.TemAcesso("Inventario#Artigos#Eliminar") == false) { btnEliminar.Enabled = false; }
            }
        }
         #endregion

        private void VerEstadosDoProduto()
        {

            if (cboEstados.SelectedItem.ToString() == "Todos")
            {
                GradeArtigo.DataSource = _stockApp.GetTodosArtigos();
            }
            else if (cboEstados.SelectedItem.ToString() == "Inativos")
            {
                GradeArtigo.DataSource = _stockApp.GetTodosArtigos().Where(a => a.Artigo.status == 0);
            }
            else if (cboEstados.SelectedItem.ToString() == "Activos")
            {
                GradeArtigo.DataSource = _stockApp.GetArtigos().Where(a => a.Artigo.status == 1);
            }           
        }
        private void btnNovoProdut_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UtilidadesGenericas.Busca.Codigo = string.Empty;
            frmCadastroProdutos chamada = IOC.InjectForm< frmCadastroProdutos>();
            UtilidadesGenericas.ChamarNoPrincipal(chamada);
            chamada.Renderizar();
            if (UtilidadesGenericas.Busca.Alterou) GradeArtigo.DataSource = _stockApp.GetArtigos().Where(a => a.Artigo.status == 1);
          
            
        }
        public void ShowAqui(Form formularioPai)
        {
            FormularioPai = formularioPai;
        }
        private void txtPesquisar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GradeArtigo.DataSource = _stockApp.GetArtigos().Where(a => a.Artigo.status == 1);
        }
        private void gridProdutos_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (IndexPro <= -1)
                { return; }
                
                UtilidadesGenericas.Busca.Codigo = gridProdutos.GetRowCellValue(IndexPro, "CodProduto").ToString();
                UtilidadesGenericas.Busca.Alterou = false;
                var chamada = IOC.InjectForm<frmCadastroProdutos>();
                UtilidadesGenericas.ChamarNoPrincipal(chamada);
                chamada.Renderizar();

                if (UtilidadesGenericas.Busca.Alterou)
                    GradeArtigo.DataSource = _stockApp.GetArtigos().Where(a => a.Artigo.status == 1);

            }
            catch (Exception)
            {
                UtilidadesGenericas.MsgShow("Erro", "Selecione uma linha", MessageBoxIcon.Error, MessageBoxButtons.OK);
            }

        }
    
    private void btnEliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Quantidade > 0)
            {
                UtilidadesGenericas.MsgShow(
                    "Erro", 
                    "Este Produto não Pode ser Eliminado \n Porquê Existe no Stock",
                    MessageBoxIcon.Error,
                    MessageBoxButtons.OK
                );
            return;
            }


            if (UtilidadesGenericas.TemCesteza("Deseja Realmente Eliminar Este Produto")) return;
           
                _artigoApp.Eliminar(new Domain.Models.Inventario.Artigo()
                {
                    Codigo = cod,
                });
               UtilidadesGenericas.MsgShow(
                   "SUCESSO",
                   "Produto Eliminado ", 
                   MessageBoxIcon.None, 
                   MessageBoxButtons.OK
                );
                GradeArtigo.DataSource = _stockApp.GetArtigos().Where(a => a.Artigo.status == 1);
            
        }
        private void gridProdutos_RowClick(object sender, RowClickEventArgs e)
        {
            cod = int.Parse(gridProdutos.GetRowCellValue(e.RowHandle, "CodProduto").ToString());
            Quantidade = decimal.Parse(gridProdutos.GetRowCellValue(e.RowHandle, "qtde").ToString());
            IndexPro = e.RowHandle;

        }
        private void carregarArmazem()
        {
            CboArmazens.Properties.Items.Clear();
            ListaArmazens = _armazemApp.GetAll();
            CboArmazens.Properties.Items.Add("Todos Armazens");
            foreach (var item in ListaArmazens) CboArmazens.Properties.Items.Add(item.descricao);
            CboArmazens.SelectedIndex = 0;
            indexArmazem = 0;
        }
        private void loadArtigos()
        {
            ArtigosStock = _stockApp.GetAll();
            _Artigos = _stockApp.GetArtigos();
        }
        private void testeCarregarArtigosEmGrid()
        {
            loadArtigos();
            carregarPorArmazem();
            GradeArtigo.DataSource = _Artigos;
        }
        private void carregarPorArmazem()
        {
            if (indexArmazem > 0)
            {
               
                var armazem = ListaArmazens[indexArmazem - 1];
                _Artigos = _Artigos.Where(a => a.Armazem.codigo == armazem.codigo).ToList();
            }
        }
        private void carregarArtigosEmGrid()
        {
            loadArtigos();
            var armazem = ListaArmazens[indexArmazem ];
            var _Artigos = _stockApp.GetArtigos().Where(a => a.Artigo.Familia.descricao == armazem.descricao && a.Armazem.codigo == armazem.codigo).ToList();
            zerarAsGrids();
            GradeArtigo.DataSource = _Artigos;
            if (armazem.descricao.Equals("Geral"))
                {
                    if (CboArmazens.SelectedIndex.Equals(0))
                    {
                        GradeArtigo.DataSource = _stockApp.GetArtigos();
                    }
                    else
                    {
                        GradeArtigo.DataSource = _stockApp.GetArtigos().Where(a => a.Armazem.codigo == armazem.codigo).ToList();
                    }
                }
            else if (CboArmazens.SelectedIndex.Equals(0) )
                {
                    if (armazem.descricao.Equals("Geral"))
                    {
                        GradeArtigo.DataSource = _stockApp.GetArtigos();
                    }
                    else
                    {
                        GradeArtigo.DataSource = _stockApp.GetArtigos().Where(a => a.Artigo.Familia.codigo == armazem.codigo).ToList();
                    }
                }            
            else
            {
                GradeArtigo.DataSource = _stockApp.GetArtigos();
            }
        }
        private void zerarAsGrids()
        {
            GradeArtigo.DataSource = null;
        }
        private void CboArmazens_SelectedIndexChanged(object sender, EventArgs e)
        {
            indexArmazem = CboArmazens.SelectedIndex;
            testeCarregarArtigosEmGrid();
        }
        private void btnImprmir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _Artigos = _stockApp.GetArtigos();
            if (Equals(_Artigos, null) || _Artigos.Count == 0)
            {
                UtilidadesGenericas.MsgShow("LISTA DE PRODUTOS ESTÁ VAZIA");
                return;
            }
            _Artigos[0].CabecalhoEmpresa = Controle.CabecalhoEmpresa;
            new frmApresentaReport().ApresentarReportProdutos(_Artigos);
        }
        private void cboEstados_SelectedIndexChanged(object sender, EventArgs e)
        {
            VerEstadosDoProduto();
        }
        private void ItemButtonEliminar_Click(object sender, EventArgs e)
        {
            var indice = UtilidadesGenericas.GetGridIndexCurrent(gridProdutos, MousePosition);
            cod = int.Parse(gridProdutos.GetRowCellValue(indice, "CodProduto").ToString());
            Quantidade = decimal.Parse(gridProdutos.GetRowCellValue(indice, "qtde").ToString());
            IndexPro = indice;
            if (Quantidade > 0)
            {
                UtilidadesGenericas.MsgShow("ERRO", "Este Produto não Pode ser Eliminado \n Porquê Existe no Stock ", MessageBoxIcon.Error, MessageBoxButtons.OK);
                return;
            }


            if (MessageBox.Show("Deseja Realmente Eliminar Este Produto", "Eliminar Produto", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) return;

            _artigoApp.Eliminar(new Domain.Models.Inventario.Artigo()
            {
                Codigo = cod,
            });
            UtilidadesGenericas.MsgShow("SUCESSO", "Produto Eliminado ", MessageBoxIcon.None, MessageBoxButtons.OK);
            GradeArtigo.DataSource = _stockApp.GetArtigos().Where(a => a.Artigo.status == 1);


        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
    }
}