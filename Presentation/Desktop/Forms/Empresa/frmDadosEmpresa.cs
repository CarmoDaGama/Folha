using DevExpress.XtraBars;
using Folha.Domain.Interfaces.Application.Empresa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Folha.Presentation.Desktop.Separadores.Empresa
{
    using Folha.Domain.Models.Empresa;
    using Folha.Domain.Helpers;

    public partial class frmDadosEmpresa : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly IEmpresaApp _EmpresaApp;
        int CodEmpresa;
        int codVerificar;
        int fechar;
        private List<Empresa> LtEmpresa;

        public frmDadosEmpresa(IEmpresaApp EmpresaApp)
        {
            InitializeComponent();
            _EmpresaApp = EmpresaApp;
        }
        void bbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            
        }

        private void bbiNew_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void accordionControlElement4_Click(object sender, EventArgs e)
        {

        }

        private void barButtonItem12_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btnDadosEmpresa_Click(object sender, EventArgs e)
        {
            navigationFrame1.SelectedPage = pageDadosEmpresa;
        }
        
        #region VALIDAÇÃO
        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }
        #endregion

        public void ChamarFora()
        {
            btnSalverFechar.Visibility = BarItemVisibility.Always;
            btnSalverFechar.Enabled = true;
            btnSalvar.Visibility = BarItemVisibility.Never;
            btnSalvar.Enabled = false;
        }
        private void btnVoltar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void btnSalvar_ItemClick(object sender, ItemClickEventArgs e)
        {
            fechar = 0;
            if (Validacao())
            {
                Gravar();
            }
            else { }
        }
        private bool Validacao()
        {
            if (txtNome.Text == ""){
                UtilidadesGenericas.MsgShow(
                    "Aviso", 
                    "Digite o nome.",
                    MessageBoxIcon.Warning,
                    MessageBoxButtons.OK
                    );
                return false;
            }
            else if (txtNIF.Text == "") {
                UtilidadesGenericas.MsgShow(
                    "Aviso",
                    "Digite o NIF.", 
                    MessageBoxIcon.Warning,
                    MessageBoxButtons.OK);
                return false;
            }
            else if (txtTelefone.Text == "")
            {
                UtilidadesGenericas.MsgShow(
                    "Aviso",
                    "Digite o Telefone.",
                    MessageBoxIcon.Warning,
                    MessageBoxButtons.OK);
                return false;
            }

            else {
                return true;
            }
        }
        private void Gravar()
        {
            var Empresa = _EmpresaApp.Listar();
            foreach (var item in Empresa)
            {
                codVerificar = 1;
                CodEmpresa = item.codigo;
            }

            if (codVerificar == 1)
            {
                //Editar
                byte[] logotipo = new byte[1];
                if (pcImagem.Image != null) logotipo = Imagens.Imagem_Byte(pcImagem.Image);

                _EmpresaApp.Editar(new Empresa()
                {
                    codigo = CodEmpresa,
                    Nome = txtNome.Text,
                    NIF = txtNIF.Text,
                    Morada = txtMorada.Text,
                    Telefones = txtTelefone.Text,
                    WebSite = txtSite.Text,
                    Email = txtEmail.Text,
                    Logotipo = logotipo,
                    Validou = 1,
                    Slogan = txtslogan.Text,
                    Responsavel = txtAdmin.Text,
                    TipoEmpresa = cboTipoEmpresa.Text
                });
                UtilidadesGenericas.MsgShow(
                    "Aviso",
                    "Dados salvo com sucesso.",
                    MessageBoxIcon.Information,
                    MessageBoxButtons.OK
                );
                PopulaDadosEmpresa();
            }
            else
            {
                byte[] logotipo = new byte[1];
                if (pcImagem.Image != null) logotipo = Imagens.Imagem_Byte(pcImagem.Image);

                _EmpresaApp.Gravar(new Empresa()
                {
                    Nome = txtNome.Text,
                    NIF = txtNIF.Text,
                    Morada = txtMorada.Text,
                    Telefones = txtTelefone.Text,
                    WebSite = txtSite.Text,
                    Email = txtEmail.Text,
                    Logotipo = logotipo,
                    Validou = 1,
                    Slogan = txtslogan.Text,
                    Responsavel = txtAdmin.Text,
                    TipoEmpresa = cboTipoEmpresa.Text
                });
                UtilidadesGenericas.MsgShow( 
                    "Aviso",
                    "Empresa cadastrada com sucesso.",
                    MessageBoxIcon.Information, 
                    MessageBoxButtons.OK
                );
               
            }
            UtilidadesGenericas.Busca.Alterou = true;

        }
        private void PopulaDadosEmpresa()
        {
            LtEmpresa = _EmpresaApp.Listar();
            UtilidadesGenericas.DadosEmpresa.codigo = LtEmpresa[0].codigo;
            UtilidadesGenericas.DadosEmpresa.Nome = LtEmpresa[0].Nome;
            UtilidadesGenericas.DadosEmpresa.NIF = LtEmpresa[0].NIF;
            UtilidadesGenericas.DadosEmpresa.Morada = LtEmpresa[0].Morada;
            UtilidadesGenericas.DadosEmpresa.Telefones = LtEmpresa[0].Telefones;
            UtilidadesGenericas.DadosEmpresa.WebSite = LtEmpresa[0].WebSite;
            UtilidadesGenericas.DadosEmpresa.Email = LtEmpresa[0].Email;
            UtilidadesGenericas.DadosEmpresa.Logotipo = LtEmpresa[0].Logotipo;
            UtilidadesGenericas.DadosEmpresa.Validou = LtEmpresa[0].Validou;
            UtilidadesGenericas.DadosEmpresa.Slogan = LtEmpresa[0].Slogan;
            UtilidadesGenericas.DadosEmpresa.TipoEmpresa = LtEmpresa[0].TipoEmpresa;
            UtilidadesGenericas.DadosEmpresa.Responsavel = LtEmpresa[0].Responsavel;


        }
        private void btnSalverFechar_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Validacao())
            {
                Gravar();
                fechar = 1;
            }
            if (fechar==1)
            {
                Close();
            }
            UtilidadesGenericas.Busca.Alterou = true;


        }

        private void frmDadosEmpresa_Load(object sender, EventArgs e)
        {
            carregarEmpresa();
        }
        private void carregarEmpresa()
        {
            byte[] logotipo = new byte[1];
            if (pcImagem.Image != null) logotipo = Imagens.Imagem_Byte(pcImagem.Image);
            List<Empresa> Empresa = (List<Empresa>)_EmpresaApp.Listar();
            foreach (var item in Empresa)
            {
                txtNome.Text = item.Nome;
                txtNIF.Text = item.NIF;
                txtMorada.Text = item.Morada;
                txtTelefone.Text = item.Telefones;
                txtSite.Text = item.WebSite;
                txtEmail.Text = item.Email;
                logotipo = item.Logotipo;
                pcImagem.Image = Imagens.Byte_Imagem(item.Logotipo);

                txtAdmin.Text = item.Responsavel;
                txtslogan.Text = item.Slogan;
                cboTipoEmpresa.Text = item.TipoEmpresa;

            }
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void pageDadosEmpresa_Paint(object sender, PaintEventArgs e)
        {

        }

        private void barButtonItem1_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            txtNome.Text = "";
            txtNIF.Text = "";
            txtslogan.Text = "";
            txtTelefone.Text = "Telefone";
            txtEmail.Text = "Email";
            txtSite.Text = "";
            txtAdmin.Text = "";
            txtMorada.Text = "";
        }

    }
}