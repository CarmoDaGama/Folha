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
using Enterprise.Presentation.Desktop.SubFormularios;
using Enterprise.Presentation.Desktop.Separadores.Stock_Armazens;
using Enterprise.Data.SqlServer.Context;
using Enterprise.Domain.Entities;

namespace Enterprise.Presentation.Desktop.Separadores.Stock_Armazens
{
    public partial class FormCadastroProduto : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FormCadastroProduto()
        {
            InitializeComponent();
        }

        private void pageFornecedores_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            new FormCategoria().ShowDialog();
        }

        private void textEditPreco1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void buttonFamilia_Click(object sender, EventArgs e)
        {
            new FormCategoria().ShowDialog();
        }

        private void buttonInserirSubstituto_ItemClick(object sender, ItemClickEventArgs e)
        {
            new FormBuscaArtigos().ShowDialog();
        }
        private void buttonNovaComposicao_ItemClick(object sender, ItemClickEventArgs e)
        {
            new FormBuscaArtigos().ShowDialog();
        }

        private void buttonSelecionarEntidade_ItemClick(object sender, ItemClickEventArgs e)
        {
            new frmEntidades().ShowDialog();
        }

        private void btnDadosEmpresa_Click(object sender, EventArgs e)
        {
            navigationFrame1.SelectedPage = navigationPage1;
        }

        private void btnDocumentos_Click(object sender, EventArgs e)
        {
            navigationFrame1.SelectedPage = navigationPage2;
        }

        private void btnEmpresa_Click(object sender, EventArgs e)
        {
            navigationFrame1.SelectedPage = navigationPage3;
        }

        private void accordionControlElement1_Click(object sender, EventArgs e)
        {
            navigationFrame1.SelectedPage = navigationPage4;
        }

        private void accordionControlElement2_Click(object sender, EventArgs e)
        {
            navigationFrame1.SelectedPage = navigationPage5;
        }

        private void buttonFamilia_Click_1(object sender, EventArgs e)
        {
            Separadores.Stock_Armazens.FormCategoria chamada = new FormCategoria();
            chamada.ShowDialog();
        }

        private void btnSalvar_ItemClick(object sender, ItemClickEventArgs e)
        {
            EnterPriseContext contexto = new EnterPriseContext();
            Produto produto = new Produto();

            produto.Barra = txtCodigo.Text;
            produto.descricao = txtDescricao.Text;

            produto.Codcategoria = 1;
            produto.Retencao = 60000;
            produto.preco1 = 60000;
            produto.preco2 = 60000;
            produto.preco3 = 60000;
            produto.movimentaStock = 1;
            produto.Vender = 1;
            produto.custo = 60000;
            contexto.Produtos.Add(produto);
            contexto.SaveChanges();
            MessageBox.Show("inserido");
        }
    }
}