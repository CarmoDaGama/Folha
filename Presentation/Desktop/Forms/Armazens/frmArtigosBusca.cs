using Folha.Domain.Interfaces.Application.Inventario;
using Folha.Domain.Models.Inventario;
using System;
using System.Collections.Generic;
using Folha.Domain.ViewModels.Frame.Inventario;
using System.Windows.Forms;
using System.Linq;
using Folha.Domain.ViewModels.Inventario;
using Folha.Domain.Helpers;

namespace Folha.Presentation.Desktop.Separadores.Armazens
{
    public partial class frmBuscaArtigos : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Produtos Artigo { get; set; }
        private List<Produtos> Artigos { get; set; }
        private List<ArtigoViewModel> ArtigosV { get; set; }
        private readonly IArtigosApp _artigoApp;
        private readonly IArtigoStockApp _stockApp;
        private readonly IArmazemApp _armazemApp;
        private string validar = ("qwertyuiop+´´asdfghjklçº~<zxcvbnm,.-/*-+._^`*ª»?=)(//&%$#:;|!#$%&/()=?»><*^ª%_:--»º|!?»`^ª[]}[}*-+^^`*");
        private int index;

        private bool Selected { get; set; } = false;
        public new bool Select { get; set; } = false;
        private int Index { get; set; } = -1;
        private int Valor;

        public frmBuscaArtigos
        (
            IArtigosApp artigoApp, 
            IArmazemApp armazemApp, 
            IArtigoStockApp stockApp
        )
        {
            InitializeComponent();
            _artigoApp = artigoApp;
            _armazemApp = armazemApp;
            _stockApp = stockApp;

        }
        public ProdutoStockViewModel GetArtigo()
        {
            Select = true;
            ShowDialog();
            if (Selected)
            {
                var codArtigo = Convert.ToInt16(gridArtigo.GetRowCellValue(index, "codigo"));
                return _stockApp.GetById(codArtigo);
            }
            else
            {
               return null;
            }
        }

      
        private void selectRow()
        {
            if (index > -1)
            {
                Selected = true;
                Lancar();

            }
        }

        private void Lancar()
        {
            if (gridArtigo.RowCount == 0)
            {
                return;
            }
            UtilidadesGenericas.Busca.Codigo = gridArtigo.GetRowCellValue(index, "codigo").ToString();
            UtilidadesGenericas.Busca.CodProduto = gridArtigo.GetRowCellValue(index, "CodProduto").ToString();
            //var codArmazem = ArtigosV[index].CodArmazem;
            UtilidadesGenericas.Busca.Descricao = gridArtigo.GetRowCellValue(index, "NomeArtigo").ToString();

            UtilidadesGenericas.Busca.CodArmazem = Convert.ToInt16(gridArtigo.GetRowCellValue(index, "CodArmazem"));
            UtilidadesGenericas.Busca.NomeArmazem = gridArtigo.GetRowCellValue(index, "NomeArmazem").ToString();
            UtilidadesGenericas.Busca.Quantidade = gridArtigo.GetRowCellValue(index, "qtde").ToString();
            UtilidadesGenericas.Busca.QuantidadeNova = decimal.Parse(txtQuantdade.Text);

            Close();
        }
        
        private void frmBuscaArtigos_Load_1(object sender, EventArgs e)
        {
            ArtigosV = _stockApp.GetArtigos().Where(a => a.Artigo.status == 1).ToList();
            GradeArtigo.DataSource = ArtigosV;
        }

        private void gridArtigo_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {

        }
        private void gridArtigo_DoubleClick(object sender, EventArgs e)
        {
            selectRow();
        }
        private void btnSelect_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Lancar();
            selectRow();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void txtQuantdade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (validar.Contains(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }

        private void gridArtigo_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            index = e.RowHandle;
        }
    }
}
