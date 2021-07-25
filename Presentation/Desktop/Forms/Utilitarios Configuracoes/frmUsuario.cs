using DevExpress.XtraBars;
using Folha.Domain.Interfaces.Application.UtilitariosConfiguracoes;
using Folha.Domain.Models.UtilitariosConfiguracoes;
using Folha.Domain.ViewModels.UtilitariosConfiguracoes;
using Folha.Domain.Enuns.Genericos;
using Folha.Domain.Helpers;
using Folha.Driver.Framework.IOC;
using Folha.Presentation.Desktop.Forms.Utilitarios_Configuracoes;
using Folha.Presentation.Desktop.Separadores.Entidades;
using System.Windows.Forms;
using System;
using System.Collections.Generic;

namespace Folha.Presentation.Desktop.Separadores.Utilitarios_Configuracoes
{
    public partial class frmUsuario : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly IUsuarioNovoApp _UsuarioApp;
        private CRUD TipoOperacao { get; set; }
        private bool Changed { get; set; } = false;

        private int codEntidade;
        private int codPerfil;
        private string NomeEntidae;
        private string validar =("1234567890|!#$%&/()=?»><*^ª_:--»º|!?»`^ª[]}[}*-+^^`*");
        int VerficaUsuario = int.Parse(UtilidadesGenericas.UsuarioPerfil.ToString());

        private UsuariosViewModel Entity { get; set; }
        private Usuarios usuario;

        public frmUsuario(IUsuarioNovoApp UsuarioApp)
        {
            InitializeComponent();
            _UsuarioApp = UsuarioApp;
            //Permicao();
        }
        #region Permicao de Acesso
        private void Permicao()
        {
            if (VerficaUsuario != 1)
            {
                if (UtilidadesGenericas.TemAcesso("Administração#Utilizador#Alterar") == false) { btnSalvar.Enabled = false; }
                if (UtilidadesGenericas.TemAcesso("Administração#Utilizador#Alterar") == false) { btnSalvarFechar.Enabled = false; }
            }
        }
        #endregion

        
        #region Metodos de Inserção
        private Usuarios PopulaObjecto()
        {
            usuario = new Usuarios()
            {
                CodEntidade = codEntidade,
                CodPerfil = codPerfil,
                Login = txtLogin.Text,
                Senha = UtilidadesGenericas.Encriptar(txtSenha.Text),
                Nome = NomeEntidae,
                Alterado = 0
            };
            if (!string.IsNullOrEmpty(txtCodigo.Text))
            {
                usuario.codigo = int.Parse(txtCodigo.Text);
                usuario.Alterado = 1;
            }
            
            return usuario;
        }
        private void PopularDadosEditar(int Codigo)
        {
            if (Codigo == 0) return;
            Entity = _UsuarioApp.GetById(Codigo);
            codEntidade = Entity.CodEntidade;
            codPerfil = Entity.CodPerfil;
            txtLogin.Text = Entity.Login;
            NomeEntidae = Entity.Nome;
            txtSenha.Text =UtilidadesGenericas.Desencriptar(Entity.Senha);
            txtEntidade.Text = Entity.Entidades.Nome;
            txtPerfil.Text = Entity.Perfil.Descricao;
        }
        #endregion
        #region Validação
        private bool isFieldsValid()
        {
            bool valid = true;

            Dictionary<string, object> d = new Dictionary<string, object>();
            d.Add("Login", txtLogin.Text);

            if (txtCodigo.Text == "" && _UsuarioApp.VerificarDup("Usuarios", d))
            {
                messageShow("O Login " + txtLogin.Text + " já existe, Verifica nos Registros ");
                return false;
            }

            if (txtEntidade.Text.Equals(string.Empty))
            {
                messageShow("Escolha uma Entidade");
                return false;
            }
            if (txtLogin.Text.Equals(string.Empty))
            {
                messageShow("Digita o Usuario");
                return false;
            }
            if (txtLogin.Text.Length <  3)
            {
                messageShow("Digita mais de 2 caracter no Login");
                return false;
            }
            if (txtPerfil.Text.Equals(string.Empty))
            {
                messageShow("Escolhe um perfil");
                return false;
            }
            if (txtSenha.Text.Equals(string.Empty))
            {
                messageShow("Escolha um Senha");
                return false;
            }
            if (txtSenha.Text.Length < 4)
            {
                messageShow("Digita mais de 4 caracter na Senha");
                return false;
            }
           
            if (!UtilidadesGenericas.UsuarioAlterado && txtCodigo.Text == "1" && txtSenha.Text.ToUpper() == "ADMIN")
            {
                UtilidadesGenericas.MsgShow("Insira uma Senha diferente de admin para o ADMINISTRADOR ", MessageBoxIcon.Stop);
                return false;
            }
            return valid;
        }
        private void messageShow(string message)
        {
            MessageBox.Show(
                message,
                "INFORMAÇÃO",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }
        #endregion
        private void btnFechar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void frmUsuario_Load(object sender, System.EventArgs e)
        {
            if (!string.IsNullOrEmpty(UtilidadesGenericas.Busca.Codigo))
            {
                txtCodigo.Text = UtilidadesGenericas.Busca.Codigo;
                int CodigoUsuario = int.Parse(txtCodigo.Text);
                var usuario = _UsuarioApp.GetById(CodigoUsuario);
                if (CodigoUsuario > 0) PopularDadosEditar(CodigoUsuario);
            }
        }
        private void btnSalvar_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!isFieldsValid()) return;
            try
            {
                var usuario = PopulaObjecto();
                usuario = _UsuarioApp.Gravar(usuario);
                if (!string.IsNullOrEmpty(txtCodigo.Text))
                { 
                    UtilidadesGenericas.UsuarioAlterado = _UsuarioApp.UsuarioAlterado(int.Parse(txtCodigo.Text));
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Erro ao Cadastrar "+ txtLogin.Text+ " usuario já existe ");
                return;
            }
            PopularDadosEditar(usuario.codigo);
            txtCodigo.Text = usuario.codigo.ToString();
            UtilidadesGenericas.Busca.Alterou = true;
            //Close();

        }
        private void btnBuscaPerfil_Click(object sender, System.EventArgs e)
        {
            
        }
        private void btnNome_Click(object sender, System.EventArgs e)
        {
              
        }
        private void txtLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (validar.Contains (e.KeyChar.ToString()))
            {
                e.Handled = true;
            }   
        }
        private void btnSalvarFechar_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!isFieldsValid()) return;
            try
            {
                var usuario = PopulaObjecto();
                usuario = _UsuarioApp.Gravar(usuario);
                
            }
            catch (Exception)
            {

                MessageBox.Show("Erro ao Cadastrar " + txtLogin.Text + " usuario já existe ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            PopularDadosEditar(usuario.codigo);
            UtilidadesGenericas.Busca.Alterou = true;
            if (usuario.Alterado == 1)
            {
                UtilidadesGenericas.UsuarioAlterado = true;
            }
            Close();
            //UtilidadesGenericas.ChamarNoPrincipal(IOC.InjectForm<frmUsuarios>());

        }

        private void txtEntidade_Click(object sender, EventArgs e)
        {
            var form = IOC.InjectForm<frmEntidadeBusca>();
            var entidade = form.GetEntidadeSelecionada(1);
            if (!Equals(entidade, null) && entidade.Codigo != 0)
            {
                if (entidade.CodTipo == 2)
                {
                    MessageBox.Show("Selecione Apenas Entidade Física", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEntidade.Text = "";
                    return;
                }
                else
                {
                    codEntidade = entidade.Codigo;
                    txtEntidade.Text = entidade.Nome;
                    NomeEntidae = entidade.Nome;
                }
            }
        }

        private void txtPerfil_Click(object sender, EventArgs e)
        {
            var form = IOC.InjectForm<frmPerfisAcesso>();
            form.btnselecionar.Visibility = BarItemVisibility.Always;

            var perfil = form.GetPerfil();
            if (Equals(perfil, null))
            {
                return;
            }
            else
            {
                codPerfil = perfil.codigo;
                txtPerfil.Text = perfil.Descricao;
            }
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            txtCodigo.Text = "";
            txtEntidade.Text = "";
            txtLogin.Text = "";
            txtPerfil.Text = "";
            txtSenha.Text = "";
        }

        private void btnVerLista_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmUsuarios chamada = IOC.InjectForm<frmUsuarios>();
            UtilidadesGenericas.ChamarNoPrincipal(chamada);
        }
    }
}