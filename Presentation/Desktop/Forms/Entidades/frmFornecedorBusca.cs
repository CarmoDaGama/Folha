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
using Folha.Domain.Models.Compras;
using Folha.Domain.Models.Entidades;
using Folha.Domain.Interfaces.Application.Entidades;

namespace Folha.Presentation.Desktop.Forms.Entidades
{
    public partial class frmFornecedorBusca : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        private readonly IFornecedoresApp _forneApp;
        public int index;
        private int cod;
        List<FornecedorBusca> lista;
        public FornecedorBusca fornecedor { get; set; }
        public int Index { get; private set; } = -1;
        public frmFornecedorBusca(IFornecedoresApp forneApp)
        {
            InitializeComponent();

            _forneApp = forneApp;
            Index = 0;
        }

        public void Mostrar()
        {
            lista = (List<FornecedorBusca>)_forneApp.ListarFornecedor(null);
            gradeFornecedor.DataSource = lista;
        }

        private void frmFornecedorBusca_Load(object sender, EventArgs e)
        {
            Mostrar();
        }

        public FornecedorBusca GetForneccedorSelecionado()
        {
            ShowDialog();
            if (fornecedor != (null) && fornecedor.Codigo > 0)
            {
                return fornecedor;
            }
            return null;

        }

        private void btnSelect_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Index < 0) return;
            fornecedor = lista.Where(f => f.Codigo == cod).FirstOrDefault();
            Close();
        }

        private void gridfornecedor_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            cod = int.Parse(gridfornecedor.GetRowCellValue(e.RowHandle, "Codigo").ToString());
            Index = e.RowHandle;
            fornecedor = lista.Where(f => f.Codigo == cod).FirstOrDefault();
        }

        private void gridfornecedor_DoubleClick(object sender, EventArgs e)
        {
            if (Index < 0) return;
            fornecedor = lista.Where(f => f.Codigo == cod).FirstOrDefault();
            Close();
        }

        private void btnVoltar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }
    }
}