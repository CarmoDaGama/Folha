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
using DevExpress.XtraBars;
using System.ComponentModel.DataAnnotations;
using Folha.Presentation.Desktop.Classe;
using Folha.Domain.Helpers;
using Folha.Driver.Framework.IOC;
using Folha.Presentation.Desktop.Forms.Armazens;

namespace Folha.Presentation.Desktop.Separadores.Armazens
{
    public partial class frmRelatorioProdutos : DevExpress.XtraBars.Ribbon.RibbonForm
    {
       
        public frmRelatorioProdutos()
        {
            InitializeComponent();
        }
       
        private void tileLtProdutos_ItemClick(object sender, TileItemEventArgs e)
        {
            var formDados = IOC.InjectForm<frmRelDadosInventario>();
            formDados.ImprimirListagemArtigos();
        }

        private void tileInventario_ItemClick(object sender, TileItemEventArgs e)
        {
            var formDados = IOC.InjectForm<frmRelDadosInventario>();
            formDados.ImprimirControloStockArmazem();
        }

        private void tileRupturaStock_ItemClick(object sender, TileItemEventArgs e)
        {
            var formDados = IOC.InjectForm<frmRelDadosInventario>();
            formDados.ImprimirRupturaStock();
        }

        private void tileMovArtigos_ItemClick(object sender, TileItemEventArgs e)
        {
            var formDados = IOC.InjectForm<frmRelDadosInventario>();
            formDados.ImprimirMovArtigos();
        }

        private void tileGrafMovArtigos_ItemClick(object sender, TileItemEventArgs e)
        {
            var formDados = IOC.InjectForm<frmRelDadosInventario>();
            formDados.ImprimirGrafMovArtigo();
        }

        private void tileGrafVendidos_ItemClick(object sender, TileItemEventArgs e)
        {
            var formDados = IOC.InjectForm<frmRelDadosInventario>();
            formDados.ImprimirGrafArtigosVendidos();
        }

        private void tilePrazoValidade_ItemClick(object sender, TileItemEventArgs e)
        {
           
        }

        private void tileApoioContagem_ItemClick(object sender, TileItemEventArgs e)
        {
            var formDados = IOC.InjectForm<frmRelDadosInventario>();
            formDados.ImprimirApoioContagem();
        }

        private void tileArtgSemControlStock_ItemClick(object sender, TileItemEventArgs e)
        {
            var formDados = IOC.InjectForm<frmRelDadosInventario>();
            formDados.ImprimirArtgSemControloStock();
        }

        private void tileTbPrecos_ItemClick(object sender, TileItemEventArgs e)
        {
            var formDados = IOC.InjectForm<frmRelDadosInventario>();
            formDados.ImprimirTabelaPreco();
        }

        private void tileItem12_ItemClick(object sender, TileItemEventArgs e)
        {
            var formDados = IOC.InjectForm<frmRelDadosInventario>();
            formDados.ImprimirListaPreco();
        }

        private void tileRetencaoArtigos_ItemClick(object sender, TileItemEventArgs e)
        {
            var formDados = IOC.InjectForm<frmRelDadosInventario>();
            formDados.ImprimirListaRetencao();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
    }
