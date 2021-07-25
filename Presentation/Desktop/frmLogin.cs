using Folha.Domain.Interfaces.Application.Sistema;
using Folha.Domain.Helpers;
using Folha.Driver.Framework.IOC;
using Folha.Presentation.Desktop.Separadores.Sistema;
using System;
using System.Threading;

namespace Folha.Presentation.Desktop
{
    using Folha.Domain.Interfaces.Application.Db;
    using Folha.Domain.Interfaces.Application.Empresa;
    using Folha.Domain.Interfaces.Application.UtilitariosConfiguracoes;
    using Folha.Domain.Models.Empresa;
    using Folha.Domain.Models.Genericos;
    using Folha.Domain.Models.Db;
    using Folha.Domain.Enuns.Genericos;
    using Forms.Principal;
    using Folha.Presentation.Desktop.Separadores.Empresa;
    using System.Collections.Generic;
    using System.IO;
    using System.Windows.Forms;
    using Separadores.Principal;
    using Forms.Turnos;

    public partial class frmLogin : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly IUsuariosApp usuarioApp;
        private readonly IDbApp _dbApp;
        private readonly IPerfilNovoApp _perfilApp;
        private readonly IEmpresaApp _Empresa;
        private readonly ITurnosApp _TurnoApp;
        List<Empresa> LtEmpresa;

        Domain.ViewModels.Sistema.UsuariosViewModel usuario;
        private DadosTemporarios dados = new DadosTemporarios();
        public ETipoBancoDados Tipo { get; private set; }

        public Thread processar;

        public frmLogin(IDbApp dbApp, IUsuariosApp app, IPerfilNovoApp perfilApp, IEmpresaApp Empresa, ITurnosApp turnoApp)
        {
            InitializeComponent();
            navigationFrame.SelectedPage = pageLogin;
            usuarioApp = app;
            _dbApp = dbApp;
            _perfilApp = perfilApp;
            _Empresa = Empresa;
            _TurnoApp = turnoApp;
            //RegistarConexao();

        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            navigationFrame.SelectedPage = pageLogin;
         }
        private void btnlicenca_Click(object sender, EventArgs e)
        {
            navigationFrame.SelectedPage = pageServidor;
        }
        private bool RegistarConexao()
        {
            var indice = CboServidor.SelectedIndex;
            var objConexao = new ConexaoDTO();

            switch (indice)
            {
                case 0:

                    objConexao = new ConexaoDTO()
                    {
                        Servidor = txtServidor.Text,
                        DataBase = "FOLHAREST",
                        Porta = int.Parse(txtPortaBd.Text),
                        Usuario = "root",
                        Senha = "",
                        tipoBancoDados = ETipoBancoDados.MySQL
                    };

                    UtilidadesGenericas.ConexaoCorrente.Servidor = txtServidor.Text;
                    UtilidadesGenericas.ConexaoCorrente.DataBase = "FOLHAREST";
                    UtilidadesGenericas.ConexaoCorrente.Porta = int.Parse(txtPortaBd.Text);
                    UtilidadesGenericas.ConexaoCorrente.Usuario = "root";
                    UtilidadesGenericas.ConexaoCorrente.Senha = "";
                    UtilidadesGenericas.ConexaoCorrente.tipoBancoDados = ETipoBancoDados.MySQL;

                    break;
                case 1:
                    objConexao = new ConexaoDTO()
                    {
                        Servidor = txtServidor.Text,
                        DataBase = "FOLHAREST",
                        Porta = int.Parse(txtPortaBd.Text),
                        Usuario = "crisoftecid",
                        Senha = "bemsecreto2015",
                        tipoBancoDados = ETipoBancoDados.SQLServer
                    };

                    UtilidadesGenericas.ConexaoCorrente.Servidor = txtServidor.Text;
                    UtilidadesGenericas.ConexaoCorrente.DataBase = "FOLHAREST";
                    UtilidadesGenericas.ConexaoCorrente.Porta = int.Parse(txtPortaBd.Text);
                    UtilidadesGenericas.ConexaoCorrente.Usuario = "crisoftecid";
                    UtilidadesGenericas.ConexaoCorrente.Senha = "bemsecreto2015";
                    UtilidadesGenericas.ConexaoCorrente.tipoBancoDados = ETipoBancoDados.SQLServer;
                    break;
                case 2:
                    objConexao = new ConexaoDTO()
                    {
                        Servidor = txtServidor.Text,
                        DataBase = "FOLHAREST",
                        Porta = int.Parse(txtPortaBd.Text),
                        Usuario = "root",
                        Senha = "",
                        tipoBancoDados = ETipoBancoDados.Oracle
                    };
                    UtilidadesGenericas.ConexaoCorrente.Servidor = txtServidor.Text;
                    UtilidadesGenericas.ConexaoCorrente.DataBase = "FOLHAREST";
                    UtilidadesGenericas.ConexaoCorrente.Porta = int.Parse(txtPortaBd.Text);
                    UtilidadesGenericas.ConexaoCorrente.Usuario = "root";
                    UtilidadesGenericas.ConexaoCorrente.Senha = "";
                    UtilidadesGenericas.ConexaoCorrente.tipoBancoDados = ETipoBancoDados.Oracle;
                    break;
                default:
                    break;
                    
            }

          
            _dbApp.RegistarConexao(objConexao);
            return Equals(_dbApp.TestarConexao(), "1");
        }
       
      
        void GetUsuario()
        {
            usuario = usuarioApp.GetUsuarioPor(txtLogin.Text, UtilidadesGenericas.Encriptar(txtSenha.Text));
        }
        private void btnEntrar_Click(object sender, EventArgs e)
        {
            //if ((DateTime.Now.Year != 2021)||(DateTime.Now.Month != 2))
            //{
            //    UtilidadesGenericas.MsgShow("Não é possível entrar no sistema pois,passou do limite de uso!");
            //    return;
            //}
            addPermicoesAcesso();
            if (!VirificarValorDosCampos())
                return;
            preencherConexao();
            if (verificarCredencias())
            {
                _perfilApp.CarregarAcessos(txtLogin.Text, UtilidadesGenericas.Encriptar(txtSenha.Text));
                Visible = false;


                new Forms.Sistema.FrmProcessar(GetUsuario).ShowDialog(this);

                    if (usuario == null)
                    {
                        AcessoNegado(); return;
                    }

                UtilidadesGenericas.UsuarioCodigo = usuario.codigo;
                UtilidadesGenericas.NomeUsuario = usuario.Nome;
                UtilidadesGenericas.UsuarioAlterado = usuario.Alterado == 1;
                UtilidadesGenericas.NomeEntidade = usuario.Entidade.Nome;
                UtilidadesGenericas.UsuarioPerfilCodigo = usuario.CodPerfil;
                UtilidadesGenericas.UsuarioPerfilNome = usuario.Perfil.Descricao;
                UtilidadesGenericas.SenhaUser = txtSenha.Text;
                UtilidadesGenericas.LoginUser = txtLogin.Text;


                salvarDadosTemporarios();
                PopulaDadosEmpresa();
                if (SePermicaoForApenasVenda())
                {
                    while (!UtilidadesGenericas.EstadoTurnoSistema)
                    {
                        if (UtilidadesGenericas.TemCesteza("Seu turno não está aberto pretende abrir?"))
                        {
                            _TurnoApp.CarregarTurnoCurrent();
                            if(IOC.InjectForm<frmAbrirTurno>().AbrirTurno())
                            {
                                UtilidadesGenericas.EstadoTurnoSistema = true;
                                UtilidadesGenericas.EstadoTurnoSistema = true;
                                UtilidadesGenericas.CodigoTurno = _TurnoApp.BuscaCodigoTurno(UtilidadesGenericas.UsuarioCodigo);
                            }
                        }
                        else
                        {
                            Application.Exit();
                        }
                    }
                    IOC.InjectForm<frmTelaDocumento>().ShowDialog();
                    txtSenha.Text = string.Empty;
                    Visible = true;
                }
                else
                {

                    IOC.InjectForm<frmInicial>().ShowDialog();
                    txtSenha.Text = string.Empty;
                    Visible = true;
                }
                //Application.Exit();
            }
            else
            {
                AcessoNegado();
                return;
            }
        }
        private bool SePermicaoForApenasVenda()
        {
            int contaOutros = 0;
            int contaVenda = 0;
            if (UtilidadesGenericas.TemAcesso("Empresa"))
            {
                contaOutros++;
            }
            if (UtilidadesGenericas.TemAcesso("Administração"))
            {
                contaOutros++;
            }

            if (UtilidadesGenericas.TemAcesso("Vendas"))
            {
                contaVenda++;
            }

            if (UtilidadesGenericas.TemAcesso("Compra"))
            {
                contaOutros++;
            }
            if (UtilidadesGenericas.TemAcesso("Inventario"))
            {
                contaOutros++;
            }
            if (UtilidadesGenericas.TemAcesso("Finanças"))
            {
                contaOutros++;
            }

            if (UtilidadesGenericas.TemAcesso("Relatorios"))
            {
                contaOutros++;
            }

            if (UtilidadesGenericas.TemAcesso("Fiscalização"))
            {
                contaOutros++;
            }

            if (UtilidadesGenericas.TemAcesso("Hospitalar"))
            {
                contaOutros++;
            }

            if (UtilidadesGenericas.TemAcesso("Recursos Humanos"))
            {
                contaOutros++;
            }

            return contaOutros == 0 && contaVenda == 1;
        }
        private void AcessoNegado()
        {
            labeInfo.Text = "Acesso negado, Verifique os dados";
        }
        private void preencherConexao()
        {
            if (Equals(CboServidor.SelectedItem, "MYSQL SERVER"))
            {

                UtilidadesGenericas.ConexaoCorrente.Servidor = txtServidor.Text;
                UtilidadesGenericas.ConexaoCorrente.DataBase = "FOLHAREST";
                UtilidadesGenericas.ConexaoCorrente.Porta = int.Parse(txtPortaBd.Text);
                UtilidadesGenericas.ConexaoCorrente.Usuario = "root";
                UtilidadesGenericas.ConexaoCorrente.Senha = "";
                UtilidadesGenericas.ConexaoCorrente.tipoBancoDados = ETipoBancoDados.MySQL;

            }else if (Equals(CboServidor.SelectedItem, "ORACLE SERVER"))
            {

                UtilidadesGenericas.ConexaoCorrente.Servidor = txtServidor.Text;
                UtilidadesGenericas.ConexaoCorrente.DataBase = "FOLHAREST";
                UtilidadesGenericas.ConexaoCorrente.Porta = int.Parse(txtPortaBd.Text);
                UtilidadesGenericas.ConexaoCorrente.Usuario = "root";
                UtilidadesGenericas.ConexaoCorrente.Senha = "";
                UtilidadesGenericas.ConexaoCorrente.tipoBancoDados = ETipoBancoDados.MySQL;

            }
            else if (Equals(CboServidor.SelectedItem, "SQL SERVER"))
            {
                UtilidadesGenericas.ConexaoCorrente.Servidor = txtServidor.Text;
                UtilidadesGenericas.ConexaoCorrente.DataBase = "FOLHAREST";
                UtilidadesGenericas.ConexaoCorrente.Porta = int.Parse(txtPortaBd.Text);
                UtilidadesGenericas.ConexaoCorrente.Usuario = "crisoftecid";
                UtilidadesGenericas.ConexaoCorrente.Senha = "bemsecreto2015";
                UtilidadesGenericas.ConexaoCorrente.tipoBancoDados = ETipoBancoDados.SQLServer;

            }

            _dbApp.RegistarConexao(new ConexaoDTO()
            {
                Servidor = UtilidadesGenericas.ConexaoCorrente.Servidor,
                DataBase = UtilidadesGenericas.ConexaoCorrente.DataBase,
                Porta = UtilidadesGenericas.ConexaoCorrente.Porta,
                Usuario = UtilidadesGenericas.ConexaoCorrente.Usuario,
                Senha = UtilidadesGenericas.ConexaoCorrente.Senha,
                tipoBancoDados = UtilidadesGenericas.ConexaoCorrente.tipoBancoDados,
            });
        }
        

        private void PopulaDadosEmpresa()
        {
            LtEmpresa = (List<Empresa>)_Empresa.Listar();
            UtilidadesGenericas.DadosEmpresa.codigo = LtEmpresa[0].codigo;
            UtilidadesGenericas.DadosEmpresa.Nome = LtEmpresa[0].Nome;
            UtilidadesGenericas.DadosEmpresa.NIF = LtEmpresa[0].NIF;
            UtilidadesGenericas.DadosEmpresa.Morada = LtEmpresa[0].Morada;
            UtilidadesGenericas.DadosEmpresa.Telefones = LtEmpresa[0].Telefones;
            UtilidadesGenericas.DadosEmpresa.WebSite = LtEmpresa[0].WebSite;
            UtilidadesGenericas.DadosEmpresa.Email = LtEmpresa[0].Email;
            UtilidadesGenericas.DadosEmpresa.Logotipo = LtEmpresa[0].Logotipo;
            UtilidadesGenericas.DadosEmpresa.Validou = LtEmpresa[0].Validou;

        }
        private void addPermicoesAcesso()
        {
            UtilidadesGenericas.TemPOS = true;
            UtilidadesGenericas.TemEscolar = true;
            UtilidadesGenericas.TemCyber = true;
            UtilidadesGenericas.TemPOS = true;
            UtilidadesGenericas.TemRH = true;
            UtilidadesGenericas.TemRestaurante = true;
            UtilidadesGenericas.TemHotel = true;
            UtilidadesGenericas.TemPT = true;
            UtilidadesGenericas.TemFrotas = true;
            UtilidadesGenericas.TemLavandaria = true;
            UtilidadesGenericas.TemViagem = true;
            UtilidadesGenericas.TemHospitalar = true;
            UtilidadesGenericas.TemSeguranca = true;
            UtilidadesGenericas.TemServico = true;
        }
        private bool verificarCredencias()
        {
            if (usuarioApp.CredenciasDoUsuarioValidas(txtLogin.Text, UtilidadesGenericas.Encriptar(txtSenha.Text)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool VirificarValorDosCampos()
        {
            if (string.IsNullOrEmpty(txtLogin.Text))
            {
                labeInfo.Text = "Erro, Preencha o campo Usuário";
                return false;
            }
            if (string.IsNullOrEmpty(txtSenha.Text))
            {
                labeInfo.Text = "Erro, Preencha o campo Senha";
                return false;
            }
            return true;
        }
        private void frmLogin_Load(object sender, EventArgs e)
        {
            buscarDadosLog();
            txtLogin.Select(0, txtLogin.Text.Length);
            txtLogin.SelectAll();
            UtilidadesGenericas.LarguraPai = Width-3;
            UtilidadesGenericas.AlturaPai = Height-3;
        }
        private void salvarDadosTemporarios()
        {
            Arquivos.txt_AdicionaTexto(
                Arquivos.CriarCaminho("DadosLog.txt", 1),
                txtLogin.Text + "&" + CboServidor.SelectedItem + "&" + txtServidor.Text
            );
        }
        private void buscarDadosLog()
        {
            var path = string.Format(Application.StartupPath + @"\{0}\", 1);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if (File.Exists(path + "DadosLog.txt"))
            {
                string dados = Arquivos.txt_LerArquivo(path + "DadosLog.txt");
                string[] splitDados = dados.Split('&');
                if (!Equals(splitDados, null) && splitDados.Length > 1)
                {
                    txtLogin.Text = splitDados[0].Trim();
                    CboServidor.SelectedItem = splitDados[1].Trim();
                    txtServidor.Text = splitDados[2].Trim();
                    preencherConexao();
                }
            }

        }

        private void txtSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                btnEntrar_Click(sender, e);
            }
            else
            {
                labeInfo.Text = string.Empty;
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnDemostrcao_Click(object sender, EventArgs e)
        {
            frmDemostracao fmd = new frmDemostracao();
            fmd.ShowDialog();
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            frmInserirLicenca chamada = new frmInserirLicenca();
            chamada.ShowDialog();
        }
      
        private void btnFechar3_Click(object sender, EventArgs e)
        {
            btnClose_Click(sender, e);
        }
        #region Servidor

        private void CarregarActualizacao()
        {
            try
            {
                _dbApp.ActualizarTabelas();
                _dbApp.actualizarMovProdutos();
                UtilidadesGenericas.MsgShow("SUCESSO", "Actualização Concluida!", MessageBoxIcon.None, MessageBoxButtons.OK);
            }
            catch (Exception x)
            {
                UtilidadesGenericas.MsgShow("ERRO", "Não foi possivél actulizar o Banco de dados!", MessageBoxIcon.Error, MessageBoxButtons.OK);

                //MessageBox.Show(x.ToString(), "Não foi possivél actulizar o Banco de dados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            PopulaDadosEmpresa();

            if ((LtEmpresa[0].Validou == 0))
            {
                if (UtilidadesGenericas.MsgShow("AVISO", "Porfavor insira os dados da sua empresa Sr(a)!", MessageBoxIcon.Information, MessageBoxButtons.OK))
                {
                    UtilidadesGenericas.DadosEmpresa.codigo = LtEmpresa[0].codigo;
                    UtilidadesGenericas.Busca.Alterou = false;
                    IOC.InjectForm<frmDadosEmpresa>().ChamarFora();
                }
                else
                {
                    Application.Exit();
                    return;
                }


            }
        }
        private void btnbd_Click(object sender, EventArgs e)
        {
            new Forms.Sistema.FrmProcessar(CarregarActualizacao).ShowDialog(this);
        }


        private bool messagemShow(string messagem)
        {
            var result = MessageBox.Show(messagem, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return result == DialogResult.OK;
        }

        private void btnTestarConexao_Click(object sender, EventArgs e)
        {
            if (RegistarConexao())
            {
                UtilidadesGenericas.MsgShow(
                    "SUCESSO", 
                    "Conexão Efectuada com Sucesso!",
                    MessageBoxIcon.None,
                    MessageBoxButtons.OK
                );
            }
            else
            {
                UtilidadesGenericas.MsgShow(
                    "Erro",
                    "Conexão Não Efectuada !", 
                    MessageBoxIcon.Error, 
                    MessageBoxButtons.OK
                );

            }

        }
        private void CboServidor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CboServidor.SelectedIndex == 0)
            {
                txtPortaBd.Text = "3306";
                UtilidadesGenericas.ConexaoCorrente.Usuario = "root";
                UtilidadesGenericas.ConexaoCorrente.Senha = "";
                UtilidadesGenericas.ConexaoCorrente.tipoBancoDados = ETipoBancoDados.MySQL;
            }
            if (CboServidor.SelectedIndex == 1)
            {
                txtPortaBd.Text = "1433";
                UtilidadesGenericas.ConexaoCorrente.Usuario = "Crisoftecid";
                UtilidadesGenericas.ConexaoCorrente.Senha = "bemsecreto2015";
                UtilidadesGenericas.ConexaoCorrente.tipoBancoDados = ETipoBancoDados.SQLServer;
            }
            dados.Servidor = CboServidor.SelectedItem.ToString();

            UtilidadesGenericas.ConexaoCorrente.Servidor = txtServidor.Text;
            UtilidadesGenericas.ConexaoCorrente.Porta = int.Parse(txtPortaBd.Text);
        }
        #endregion

        private void txtLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            labeInfo.Text = "";
            if (Equals(txtLogin.Text , "Usuario"))
            {
                txtLogin.Text = "";
            }
        }

        private void txtSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Equals(txtSenha.Text, "Password"))
            {
                txtSenha.Text = "";
            }
            labeInfo.Text = "";

        }
        private void btnDefinicoes_Click(object sender, EventArgs e)
        {
            navigationFrame.SelectedPage = pageServidor;

        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            navigationFrame.SelectedPage = pageLogin;

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtSenha.Properties.UseSystemPasswordChar = !checkBoxVerSenha.Checked;
        }
    }
}