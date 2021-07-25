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
using Enterprise.Presentation.Desktop.Separadores.Armazens;
//using Enterprise.Domain.Entities.Models;
using Enterprise.Presentation.Desktop.Separadores.Entidades;

namespace Enterprise.Presentation.Desktop.Separadores.Armazens
{
    public partial class frmCadastroProduto : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmCadastroProduto()
        {
            InitializeComponent();
        }

        private void pageFornecedores_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            new frmCategoria().ShowDialog();
        }

        private void textEditPreco1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void buttonFamilia_Click(object sender, EventArgs e)
        {
            new frmCategoria().ShowDialog();
        }

        private void buttonInserirSubstituto_ItemClick(object sender, ItemClickEventArgs e)
        {
            new frmBuscaArtigos().ShowDialog();
        }
        private void buttonNovaComposicao_ItemClick(object sender, ItemClickEventArgs e)
        {
            new frmBuscaArtigos().ShowDialog();
        }

        private void buttonSelecionarEntidade_ItemClick(object sender, ItemClickEventArgs e)
        {
            new frmEntidadeBusca().ShowDialog();
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
            //Separadores.Stock_Armazens.FormCategoria chamada = new frmCategoria();
            //chamada.ShowDialog();
        }

        private void btnSalvar_ItemClick(object sender, ItemClickEventArgs e)
        {

            //DBModelsContext contexto = new DBModelsContext();
            //Produtos produto = new Produtos();

            //produto.descricao = txtDescricao.Text;


            //produto.Retencao = Convert.ToDecimal(txtRetencao.Text);
            //produto.preco1 = Convert.ToDecimal(txtPreco1.Text);
            //produto.preco2 = Convert.ToDecimal(txtPreco2.Text);
            //produto.preco3 = Convert.ToDecimal(txtPreco3.Text);

            //produto.movimentaStock = (cboMovimenta.Text == "Movimenta") ? 1 : 0;
            //produto.Vender = (cboVenda.Text == "Sim") ? 1 : 0;
            //produto.custo = Convert.ToDecimal(textEditCusto.Text);
            //produto.Imposto = Convert.ToDecimal(txtImposto.Text);
            //contexto.Produtos.Add(produto);
            //contexto.SaveChanges();
            //MessageBox.Show("inserido");
        }
    }
}