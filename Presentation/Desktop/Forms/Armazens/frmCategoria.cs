using DevExpress.XtraBars;
using Folha.Domain.Interfaces.Application.Inventario;
using Folha.Domain.Models.Inventario;
using Folha.Domain.ViewModels.Inventario;
using Folha.Domain.Helpers;
using Folha.Driver.Framework.IOC;
using Folha.Presentation.Desktop.Forms.Armazens;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
namespace Folha.Presentation.Desktop.Separadores.Armazens
{
    public partial class frmCategoria : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private List<Categoria> Lista = new List<Categoria>();

        private readonly ICategoriaApp _categoriaApp;
        public frmCategoria(ICategoriaApp categoriaApp)
        {
            InitializeComponent();
            _categoriaApp = categoriaApp;
        }
        private void frmCategoria_Load(object sender, EventArgs e)
        {
            txtCodigo.Text = UtilidadesGenericas.Busca.Codigo;
            if (string.IsNullOrEmpty(txtCodigo.Text))
            {
                return;
            }
            CarregaCampos();
        }
        private void CarregaCampos()
        {
            
            Lista = (List<Categoria>)_categoriaApp.ListarPopular(int.Parse(txtCodigo.Text));
            txtDescricao.Text = Lista[0].descricao;
            cmbVender.Text = Lista[0].Vender;

            try
            {
                PicImagem.Image = Imagens.Byte_Imagem(Lista[0].Foto);
            }
            catch (Exception) { }
        }
        private bool isFieldsValid()
        {
            bool valid = true;
            if (txtDescricao.Text == "")
            {
                MessageBox.Show("Insira uma Descricao !", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            Dictionary<string, object> d = new Dictionary<string, object>();
            d.Add("descricao", txtDescricao.Text);
            if (txtCodigo.Text == "" && _categoriaApp.VerificarDup("Categoria", d))
            {
                MessageBox.Show("Já Existe Nome, Verifica nos Registros ");
                return false;
            }
            return valid;
        }

        public void CadatrarEdtar()
        {
            if (!string.IsNullOrEmpty(txtCodigo.Text))
            {

                byte[] logotipo = new byte[1];
                    if (PicImagem.Image != null) logotipo = Imagens.Imagem_Byte(PicImagem.Image);
                    _categoriaApp.Update(new Categoria()
                    {
                        codigo = int.Parse(txtCodigo.Text),
                        descricao = txtDescricao.Text,
                        Vender = cmbVender.Text,
                        Foto = logotipo
                    }
                    );
                    Close();
            }
            else
            {

                byte[] logotipo = new byte[1];
                if (PicImagem.Image != null) logotipo = Imagens.Imagem_Byte(PicImagem.Image);

                    _categoriaApp.Insert(new Categoria()
                    {
                        descricao = txtDescricao.Text,
                        Vender = cmbVender.Text,
                        Foto = logotipo
                    });

                
            }
        }
    
         private void btnsalvarFechar_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!isFieldsValid()) return;
            CadatrarEdtar();
            UtilidadesGenericas.Busca.Alterou = true;
            Close();
        }
        private void btnFechar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmCategorias chamada = IOC.InjectForm<frmCategorias>();
            UtilidadesGenericas.ChamarNoPrincipal(chamada);
        }
    }
}