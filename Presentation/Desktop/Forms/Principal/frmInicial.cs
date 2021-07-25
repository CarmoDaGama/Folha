using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Folha.Domain.Helpers;
using DevExpress.XtraEditors;
using Folha.Driver.Framework.IOC;
using Folha.Presentation.Desktop.Separadores.Notificacoes;

using Folha.Domain.Interfaces.Application.Empresa;
using Folha.Domain.Interfaces.Application.Sistema;
using Folha.Presentation.Desktop.Classe;
using Folha.Presentation.Desktop.Forms.Armazens;
using Folha.Presentation.Desktop.Forms.Utilitarios_Configuracoes;
using Folha.Presentation.Desktop.Separadores.Armazens;
using Folha.Presentation.Desktop.Separadores.Empresa;
using Folha.Presentation.Desktop.Separadores.Entidades;
using Folha.Presentation.Desktop.Separadores.Financeiro;
using Folha.Presentation.Desktop.Separadores.Utilitarios_Configuracoes;
using Folha.Domain.Enuns.Entidades;
using Folha.Domain.Enuns.Genericos;
using Folha.Presentation.Desktop.Forms.Fiscalisacao;
using Folha.Presentation.Desktop.Forms.Documentos;
using Folha.Domain.Interfaces.Application.UtilitariosConfiguracoes;
using Folha.Presentation.Desktop.Forms.Empresa;
using DevExpress.XtraBars;
using Folha.Presentation.Desktop.Separadores.Principal;
using Folha.Domain.Interfaces.Application.Admin;
using Folha.Presentation.Desktop.Forms.Sistema;
using DevExpress.XtraBars.Navigation;

namespace Folha.Presentation.Desktop.Forms.Principal
{
    public partial class frmInicial : XtraForm
    {
        private readonly ITurnosApp _turnosApp;
        private readonly IEmpresaApp _empresaApp;
        private readonly IPeriodoBackupApp _perido;
        private readonly IDefinicoesGeraisApp _definicoesGeraisApp;
        private readonly IPerfilNovoApp _perfilApp;

        public frmInicial(ITurnosApp turnosApp, 
                          IEmpresaApp empApp, 
                          IPeriodoBackupApp perido,
                          IDefinicoesGeraisApp definicoesGeraisApp, 
                          IPerfilNovoApp perfilApp)
        {
            InitializeComponent();
            _turnosApp = turnosApp;
            _empresaApp = empApp;
            _perido = perido;
            _definicoesGeraisApp = definicoesGeraisApp;
            _perfilApp = perfilApp;
        }
        #region Permissão
        private void Permicao()
        {
            if (InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate {
                    invokePermissao();
                }));
            }
            else
            {
                invokePermissao();
            }
        }

        private void invokePermissao()
        {
            int x = int.Parse(UtilidadesGenericas.UsuarioPerfil.ToString());
            if (UtilidadesGenericas.TemPOS || UtilidadesGenericas.TemRestaurante || UtilidadesGenericas.TemHotel)
            {
                ///////////////////////////////////////PERMIÇÃO DO SEPARADOR///////////////////////////////////////////

                if (UtilidadesGenericas.TemAcesso("Empresa") == false) { btnSeparadorEmpresa.Visible = false; }
                else { btnSeparadorEmpresa.Visible = true; }
                if (UtilidadesGenericas.TemAcesso("Administração") == false) { SeparadorAdmin.Visible = false; }
                else { SeparadorAdmin.Visible = true; }
                if (UtilidadesGenericas.TemAcesso("Vendas") == false) { btnSeparadorVenda.Visible = false; }
                else { btnSeparadorVenda.Visible = true; }
                if (UtilidadesGenericas.TemAcesso("Compra") == false) { SeparadorCompras.Visible = false; }
                else { SeparadorCompras.Visible = true; }
                if (UtilidadesGenericas.TemAcesso("Inventario") == false) { SeparadorInventario.Visible = false; }
                else { SeparadorInventario.Visible = true; }
                if (UtilidadesGenericas.TemAcesso("Finanças") == false) { SeparadorFinanceiro.Visible = false; }
                else { SeparadorFinanceiro.Visible = true; }
                if (UtilidadesGenericas.TemAcesso("Relatorios") == false) { btnSeparadorRelatorios.Visible = false; }
                else { btnSeparadorRelatorios.Visible = true; }
                if (UtilidadesGenericas.TemAcesso("Fiscalização") == false) { btnSerparadorFicaliza.Visible = false; }
                else { btnSerparadorFicaliza.Visible = true; }
                if (UtilidadesGenericas.TemAcesso("Hospitalar") == false) { //btnSeparadorRecursosHumanos.Visible = false;
                }
                else { //btnSeparadorRecursosHumanos.Visible = true;
                    }
                if (UtilidadesGenericas.TemAcesso("Recursos Humanos") == false) { SeparadorFinanceiro.Visible = false; }
                else { SeparadorFinanceiro.Visible = true; }


                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            }

            if (x != 1)
            {

                //Empresa
                if (UtilidadesGenericas.TemAcesso("Empresa#Empresa") == false) btnMinhaEmpresa.Visible = false;
                if (UtilidadesGenericas.TemAcesso("Empresa#Operações") == false) btnOperacoes.Visible = false;
                if (UtilidadesGenericas.TemAcesso("Empresa#Trevo Soft") == false) btnTrevosolution.Visible = false;
                if (UtilidadesGenericas.TemAcesso("Empresa#Afilhares") == false) btnAfilhares.Visible = false;
                if (UtilidadesGenericas.TemAcesso("Empresa#Trevo Mobile") == false) btnTrevoMobile.Visible = false;


                //Administrção
                if (UtilidadesGenericas.TemAcesso("Administração#Entidades") == false) btnEntidades.Visible = false;
                if (UtilidadesGenericas.TemAcesso("Administração#Perfil") == false) btnPerfisUtilizadores.Visible = false;
                if (UtilidadesGenericas.TemAcesso("Administração#Usuarios") == false) btnUsuarios.Visible = false;
                if (UtilidadesGenericas.TemAcesso("Administração#Configuração") == false) btnConfig.Visible = false;
                if (UtilidadesGenericas.TemAcesso("Administração#Documentos") == false) btnTodosDoc_Admin.Visible = false;


                // Vendas
                if (UtilidadesGenericas.TemAcesso("Vendas#Clientes") == false) btnClientes.Visible = false;
                if (UtilidadesGenericas.TemAcesso("Vendas#Consições de Pagamento") == false) btnCondicoesPagamento.Visible = false;
                if (UtilidadesGenericas.TemAcesso("Vendas#Factura") == false) btnFactura.Visible = false;
                if (UtilidadesGenericas.TemAcesso("Vendas#Factura Recibo") == false) btnFacturaRecibo.Visible = false;
                if (UtilidadesGenericas.TemAcesso("Vendas#Factura Proforma") == false) btnProform.Visible = false;
                if (UtilidadesGenericas.TemAcesso("Vendas#Orçamento") == false) { btnOrcamento.Visible = false; }
                if (UtilidadesGenericas.TemAcesso("Vendas#Operacões Pendente") == false) btnOperacoesPendetes.Visible = false;

                // Compra
                if (UtilidadesGenericas.TemAcesso("Compra#Fornecedor") == false) btnFornecedorCompra.Visible = false;
                if (UtilidadesGenericas.TemAcesso("Compra#Compra Fornecedor") == false) btnCompraFornecedor.Visible = false;
                if (UtilidadesGenericas.TemAcesso("Compra#Encomendas") == false) btnEcomendas.Visible = false;

                // Inventario
                if (UtilidadesGenericas.TemAcesso("Inventario#Artigos") == false) { btnArtigos.Visible = false; }
                if (UtilidadesGenericas.TemAcesso("Inventario#Armazens") == false) btnArmazens.Visible = false;
                if (UtilidadesGenericas.TemAcesso("Inventario#Categorias") == false) btnFamiliaProduto.Visible = false;
                if (UtilidadesGenericas.TemAcesso("Inventario#Lotes") == false) btnLotes.Visible = false;
                if (UtilidadesGenericas.TemAcesso("Inventario#Entrada") == false) btnEntradas.Visible = false;
                if (UtilidadesGenericas.TemAcesso("Inventario#Saída") == false) btnSaidas.Visible = false;
                if (UtilidadesGenericas.TemAcesso("Inventario#Transferência") == false) btnTransferencias.Visible = false;

                //// Financeiro
                if (UtilidadesGenericas.TemAcesso("Finanças#Caixas") == false) btnVerCaixa.Visible = false;
                if (UtilidadesGenericas.TemAcesso("Finanças#Conta Bancaria") == false) btnContaBancaria.Visible = false;
                if (UtilidadesGenericas.TemAcesso("Finanças#Moedas") == false) btnMoedas.Visible = false;
                if (UtilidadesGenericas.TemAcesso("Finanças#Unidade Bancaria") == false) btnUnidadBancaria.Visible = false;
                if (UtilidadesGenericas.TemAcesso("Finanças#Formas de Liquidação") == false) btnFPagamentos.Visible = false;
                if (UtilidadesGenericas.TemAcesso("Finanças#Finalidade de Liquidação") == false) btnFinalidadePagamento.Visible = false;
                if (UtilidadesGenericas.TemAcesso("Finanças#Efectuar Liquidação") == false) btnEfectuarPagamentos.Visible = false;
                if (UtilidadesGenericas.TemAcesso("Finanças#Receber Pagamentos") == false) btnReceberPagamentos.Visible = false;
                if (UtilidadesGenericas.TemAcesso("Finanças#Turno do Vendedor") == false) btnTodosTurnos.Visible = false;
                if (UtilidadesGenericas.TemAcesso("Finanças#Registro Periodico") == false) btnRegistosPeriodicos.Visible = false;
                if (UtilidadesGenericas.TemAcesso("Finanças#Movimentos Bancarios") == false) btnBancario.Visible = false;
                if (UtilidadesGenericas.TemAcesso("Finanças#Movimentos de Caixas") == false) btnCaixa.Visible = false;
                if (UtilidadesGenericas.TemAcesso("Finanças#Imposto") == false) btnImposto.Visible = false;
                if (UtilidadesGenericas.TemAcesso("Finanças#Motivo de isenção") == false) btnMotivosIsencao.Visible = false;

                //// Relatorios
                if (UtilidadesGenericas.TemAcesso("Relatorios#Administração") == false) btnRelAdministracao.Visible = false;
                if (UtilidadesGenericas.TemAcesso("Relatorios#Vendas") == false) btnRelatorioVenda.Visible = false;
                if (UtilidadesGenericas.TemAcesso("Relatorios#Compras") == false) btnRelatorioCompra.Visible = false;
                if (UtilidadesGenericas.TemAcesso("Relatorios#Finanças") == false) btnRelatorioInventario.Visible = false;
                if (UtilidadesGenericas.TemAcesso("Relatorios#Hospital") == false) btnRelatorioHospitalar.Visible = false;
                if (UtilidadesGenericas.TemAcesso("Relatorios#Recursos Humanos") == false) btnRElatorioREcursos.Visible = false;
                if (UtilidadesGenericas.TemAcesso("Relatorios#REscola") == false) btnRelEscola.Visible = false;

                //// Fiscalização
                if (UtilidadesGenericas.TemAcesso("Ficalização#SAFT") == false) btnGerarSaft.Visible = false;
                if (UtilidadesGenericas.TemAcesso("Ficalização#Configuração Backup") == false) btnConfigBackup.Visible = false;
                if (UtilidadesGenericas.TemAcesso("Ficalização#Backup") == false) btnGerarNovaCopia.Visible = false;
                if (UtilidadesGenericas.TemAcesso("Ficalização#Auditoria") == false) btnAuditoria.Visible = false;



                // Hospitalar
                //if (UtilidadesGenericas.TemAcesso("Hospitalar#Relatorios") == false) btnRelatorioHosp.Enabled = false;
                //if (UtilidadesGenericas.TemAcesso("Hospitalar#Medico") == false) btnMedicos.Enabled = false;
                //if (UtilidadesGenericas.TemAcesso("Hospitalar#Paciente") == false) btnPacientes.Enabled = false;
                //if (UtilidadesGenericas.TemAcesso("Hospitalar#Profissional de Saude") == false) btnProfissinalSaude.Enabled = false;
                //if (UtilidadesGenericas.TemAcesso("Hospitalar#Atendimento") == false) btnAtendimentoRecepcao.Enabled = false;
                //if (UtilidadesGenericas.TemAcesso("Hospitalar#Consultor") == false) btnconsultorio.Enabled = false;
                //if (UtilidadesGenericas.TemAcesso("Hospitalar#Internamento") == false) btnInternamento.Enabled = false;
                //if (UtilidadesGenericas.TemAcesso("Hospitalar#Laboratorio") == false) btnLaboratorio.Enabled = false;
                //if (UtilidadesGenericas.TemAcesso("Hospitalar#Exames") == false) btnExames.Enabled = false;
                //if (UtilidadesGenericas.TemAcesso("Hospitalar#Escala Medica") == false) btnEscalaMedica.Enabled = false;
                ////if (UtilidadesGenericas.TemAcesso("Hospitalar#Horario de Atendimento") == false) btnHorarioAtendimento.Enabled = false;
                //if (UtilidadesGenericas.TemAcesso("Hospitalar#Tipo de Consulta") == false) btnTipoConsulta.Enabled = false;
                //if (UtilidadesGenericas.TemAcesso("Hospitalar#Area Hospitalar") == false) btnAreaHospitalar.Enabled = false;
                //if (UtilidadesGenericas.TemAcesso("Hospitalar#Especilidade") == false) btnEspecialidade.Enabled = false;
                //if (UtilidadesGenericas.TemAcesso("Hospitalar#Quarto") == false) btnSalasHospitalar.Enabled = false;
                //if (UtilidadesGenericas.TemAcesso("Hospitalar#Camas") == false) btnCamas.Enabled = false;
                //if (UtilidadesGenericas.TemAcesso("Hospitalar#Tarifas") == false) btnTarifas.Enabled = false;
                //if (UtilidadesGenericas.TemAcesso("Hospitalar#Tipo Quartos") == false) btnTipoQuarto.Enabled = false;
                //if (UtilidadesGenericas.TemAcesso("Hospitalar#Tipo Camas") == false) btnTipoCama.Enabled = false;
                //if (UtilidadesGenericas.TemAcesso("Hospitalar#A Seguradoras") == false) btnSeguradora.Enabled = false;
                //if (UtilidadesGenericas.TemAcesso("Hospitalar#Farmacos") == false) btnFarmacos.Enabled = false;
                //if (UtilidadesGenericas.TemAcesso("Hospitalar#Configurações") == false) btnConfiguracao.Enabled = false;



            }
        }
        #endregion
        private void VerificarPermissaoDeFacturacao()
        {
            var dadosGerais = _definicoesGeraisApp.ListarGerais(null);
             UtilidadesGenericas.PermitirVenderSemStock = dadosGerais.FirstOrDefault().StateVenderSemStock;
        }

    private void AlterarSenhaPadrao()
        {
            while (UtilidadesGenericas.UsuarioAlterado == false)
            {
                if (UtilidadesGenericas.MsgShow("AVISO", "É necessario alterar a senha do usuário " + UtilidadesGenericas.NomeUsuario + "\n por questão de segurança!", MessageBoxIcon.Information, MessageBoxButtons.OK))
                {
                    UtilidadesGenericas.Busca.Codigo = UtilidadesGenericas.UsuarioCodigo.ToString();
                    UtilidadesGenericas.Busca.Alterou = false;
                    frmUsuario chamada = IOC.InjectForm<frmUsuario>();
                    chamada.Size = new Size(517, 300);
                    chamada.btnVoltar.Visibility = BarItemVisibility.Never;
                    chamada.btnSalvar.Visibility = BarItemVisibility.Never;
                    chamada.btnVerLista.Visibility = BarItemVisibility.Never;
                    chamada.txtEntidade.Enabled = false;
                    chamada.txtPerfil.Enabled = false;

                    chamada.ShowDialog();
                }
                else
                {
                    System.Windows.Forms.Application.Exit();
                    return;
                }
            }
        }

    private void CarregaTudo()
    {
            Permicao();
          
            carregarTurnoCurrent();
            VerificarPermissaoDeFacturacao();
            panelBody.Controls.Clear();
            Controle.CabecalhoEmpresa = _empresaApp.Listar().FirstOrDefault();
            AlterarSenhaPadrao();

            if (InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate {
                    ChamarFormNotificacoes();
                    lbNome.Text = UtilidadesGenericas.NomeUsuario.ToUpper();
                    lbEmpresa.Text = "Folha ERP  | " + UtilidadesGenericas.DadosEmpresa.Nome;
                    lbPerfil.Text = UtilidadesGenericas.UsuarioPerfilNome;
                }));
            }
            else
            {
                ChamarFormNotificacoes();
                lbNome.Text = UtilidadesGenericas.NomeUsuario.ToUpper();
                lbEmpresa.Text = "Folha ERP  | " + UtilidadesGenericas.DadosEmpresa.Nome;
                lbPerfil.Text = UtilidadesGenericas.UsuarioPerfilNome;
            }
        }

        private void ChamarFormNotificacoes()
        {
            frmNotificacoes chamadaNotificacao = IOC.InjectForm<frmNotificacoes>();
            UtilidadesGenericas.showFormInPanel(panelBody, chamadaNotificacao);
            chamadaNotificacao.Renderizar();
        }

        private bool messagemShow(string messagem)
        {
            var result = MessageBox.Show(messagem, "AVISO", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            return result == DialogResult.OK;
        }

        private void carregarTurnoCurrent()
        {
            if (_turnosApp.VerificaEstadoDoTurno(UtilidadesGenericas.UsuarioCodigo) == "ABERTO")
            {
                UtilidadesGenericas.EstadoTurnoSistema = true;
                UtilidadesGenericas.CodigoTurno = _turnosApp.BuscaCodigoTurno(UtilidadesGenericas.UsuarioCodigo);
            }
        }


        public void ChamarFormAqui(Form form)
        {
            UtilidadesGenericas.showFormInPanel(panelBody, form);
        }
        private void frmInicial_Load(object sender, EventArgs e)
        {
            UtilidadesGenericas.frmInicial = this;
            new Forms.Sistema.FrmProcessar(CarregaTudo).ShowDialog(this);
            UtilidadesGenericas.LarguraPai = Width;
            UtilidadesGenericas.AlturaPai = Height;

        }

        private void btnMeuTurno_Click(object sender, EventArgs e)
        {

            UtilidadesGenericas.showFormInPanel(panelBody, IOC.InjectForm<frmMeuTurno>());

        }

        private void btnEmpresa_Click(object sender, EventArgs e)
        {
            UtilidadesGenericas.showFormInPanel(panelBody, IOC.InjectForm<frmDadosEmpresa>());

        }

        private void btnArtigos_Click(object sender, EventArgs e)
        {
            UtilidadesGenericas.showFormInPanel(panelBody, IOC.InjectForm<frmVerProdutos>());
            

        }

        private void btnConfigBackup_Click(object sender, EventArgs e)
        {
            IOC.InjectForm<frmConfiguracoesBackup>().ShowDialog();

        }

        private void btnRelatorioInventario_Click(object sender, EventArgs e)
        {
            UtilidadesGenericas.showFormInPanel(panelBody, IOC.InjectForm<frmRelatorioProdutos>());

        }

        private void btnFamiliaProduto_Click(object sender, EventArgs e)
        {
            frmCategorias chamada = IOC.InjectForm<frmCategorias>();
            chamada.FormBorderStyle = FormBorderStyle.None;
            UtilidadesGenericas.showFormInPanel(panelBody, chamada);
        }

        private void btnArmazens_Click(object sender, EventArgs e)
        {
            UtilidadesGenericas.showFormInPanel(panelBody, IOC.InjectForm<frmInteligente>().ShowList("Armazens", "Armazens"));

        }

        private void btnImposto_Click(object sender, EventArgs e)
        {
            UtilidadesGenericas.showFormInPanel(panelBody, IOC.InjectForm<frmImpostos>());

        }

        private void btnLotes_Click(object sender, EventArgs e)
        {
            UtilidadesGenericas.showFormInPanel(panelBody, IOC.InjectForm<frmLotesArtigo>());

        }

        private void btnEntradas_Click(object sender, EventArgs e)
        {
            IOC.InjectForm<frmTelaDocumento>().EfectuarOperacaoDocumento("ASE", "ABERTO");

        }

        private void btnSaidas_Click(object sender, EventArgs e)
        {
            IOC.InjectForm<frmTelaDocumento>().EfectuarOperacaoDocumento("ASS", "ABERTO");

        }

        private void btnTransferencias_Click(object sender, EventArgs e)
        {
            frmStockTransferencia chamada = IOC.InjectForm<frmStockTransferencia>();
            chamada.FormBorderStyle = FormBorderStyle.None;
            UtilidadesGenericas.showFormInPanel(panelBody, chamada);
        }

        private void btnTodosDoc_Admin_Click(object sender, EventArgs e)
        {
            UtilidadesGenericas.showFormInPanel(panelBody, IOC.InjectForm<frmVerTodosDocumentos>());

        }

        private void btnMotivosIsencao_Click(object sender, EventArgs e)
        {
            UtilidadesGenericas.showFormInPanel(panelBody, IOC.InjectForm<frmMotivoIsencao>());

         
        }

        private void btnGerarSaft_Click(object sender, EventArgs e)
        {
            UtilidadesGenericas.showFormInPanel(panelBody, IOC.InjectForm<frmGerarSaft>());

        }

        private void btnGerarNovaCopia_Click(object sender, EventArgs e)
        {
            new frmCopiaSegurança().ShowDialog();

        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            UtilidadesGenericas.showFormInPanel(panelBody, IOC.InjectForm<frmConfiguracoesGeral>());
        }

        private void btnOperacoes_Click(object sender, EventArgs e)
        {
            UtilidadesGenericas.showFormInPanel(panelBody, IOC.InjectForm<frmOpSistema>());
      
        }

        private void btnEntidades_Click(object sender, EventArgs e)
        {
            UtilidadesGenericas.showFormInPanel(panelBody, IOC.InjectForm<frmVerEntidade>());
            
        }

        private void btnPerfisUtilizadores_Click(object sender, EventArgs e)
        {
            UtilidadesGenericas.showFormInPanel(panelBody, IOC.InjectForm<frmPerfisAcesso>());

        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            UtilidadesGenericas.showFormInPanel(panelBody, IOC.InjectForm<frmUsuarios>());

        }

        private void btnNotificacao_Click(object sender, EventArgs e)
        {
            UtilidadesGenericas.showFormInPanel(panelBody, IOC.InjectForm<frmNotificacoes>());

        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            UtilidadesGenericas.showFormInPanel(panelBody, IOC.InjectForm<frmVerEntidade>());

        }

        private void btnCondicoesPagamento_Click(object sender, EventArgs e)
        {
            UtilidadesGenericas.showFormInPanel(panelBody, IOC.InjectForm<frmCondicoesPagamento>());

        }

        private void btnOperacoesPendetes_Click(object sender, EventArgs e)
        {
            UtilidadesGenericas.showFormInPanel(panelBody, IOC.InjectForm<frmVerOperacoesPendentes>());

        }

        private void btnFacturaRecibo_Click(object sender, EventArgs e)
        {
            if (UtilidadesGenericas.EstadoTurnoSistema)
                IOC.InjectForm<frmTelaDocumento>().ShowDialog();
            else
                UtilidadesGenericas.MsgShow("AVISO", "Turno encontra-se Fechado", MessageBoxIcon.Information, MessageBoxButtons.OK);


        }

        private void btnFactura_Click(object sender, EventArgs e)
        {
            if (UtilidadesGenericas.EstadoTurnoSistema)
                IOC.InjectForm<frmTelaDocumento>().EfectuarOperacaoDocumento("FT", "ABERTO");
            else
                UtilidadesGenericas.MsgShow("AVISO", "Turno encontra-se Fechado", MessageBoxIcon.Information, MessageBoxButtons.OK);

        }

        private void btnOrcamento_Click(object sender, EventArgs e)
        {
            if (UtilidadesGenericas.EstadoTurnoSistema)
                IOC.InjectForm<frmTelaDocumento>().EfectuarOperacaoDocumento("ADM", "ABERTO");
            else
                UtilidadesGenericas.MsgShow("AVISO", "Turno encontra-se Fechado", MessageBoxIcon.Information, MessageBoxButtons.OK);

        }

        private void btnProform_Click(object sender, EventArgs e)
        {
            if (UtilidadesGenericas.EstadoTurnoSistema)
                IOC.InjectForm<frmTelaDocumento>().EfectuarOperacaoDocumento("PP", "ABERTO");
            else
                UtilidadesGenericas.MsgShow("AVISO", "Turno encontra-se Fechado", MessageBoxIcon.Information, MessageBoxButtons.OK);

        }

        private void btnFornecedorCompra_Click(object sender, EventArgs e)
        {
            UtilidadesGenericas.showFormInPanel(panelBody, IOC.InjectForm<frmEntidadeBusca>().This(TypeEntity.FORNECEDOR, CRUD.Listar));

        }

        private void btnCompraFornecedor_Click(object sender, EventArgs e)
        {
            if (UtilidadesGenericas.EstadoTurnoSistema)
                IOC.InjectForm<frmTelaDocumento>().EfectuarOperacaoDocumento("CF", "ABERTO");
            else
                UtilidadesGenericas.MsgShow("AVISO", "Turno encontra-se Fechado", MessageBoxIcon.Information, MessageBoxButtons.OK);

        }

        private void btnRelAdministracao_Click(object sender, EventArgs e)
        {
            UtilidadesGenericas.showFormInPanel(panelBody, IOC.InjectForm<frmVerRelatorioOperacoes>());

        }

        private void btnRelatorioFinanceiro_Click(object sender, EventArgs e)
        {
            UtilidadesGenericas.showFormInPanel(panelBody, IOC.InjectForm<frmRelatorioFinanceiro>());

        }

        private void btnVerCaixa_Click(object sender, EventArgs e)
        {

            var chamada = IOC.InjectForm<frmInteligente>();
            chamada.FormBorderStyle = FormBorderStyle.None;
            UtilidadesGenericas.showFormInPanel(panelBody, chamada.ShowList("Caixas", "Caixas"));

        }

        private void btnBancario_Click(object sender, EventArgs e)
        {
            UtilidadesGenericas.showFormInPanel(panelBody, IOC.InjectForm<frmVerMovimentosBancarios>());

        }

        private void btnCaixa_Click(object sender, EventArgs e)
        {
            UtilidadesGenericas.showFormInPanel(panelBody, IOC.InjectForm<frmVerMovimentosCaixa>());

        }

        private void btnTodosTurnos_Click(object sender, EventArgs e)
        {
          
            UtilidadesGenericas.showFormInPanel(panelBody, IOC.InjectForm<frmVerTodosTurnos>());

        }

        private void btnRegistosPeriodicos_Click(object sender, EventArgs e)
        {
            UtilidadesGenericas.showFormInPanel(panelBody, IOC.InjectForm<frmVerRegistosPeriodicos>());

            
        }

        private void btnReceberPagamentos_Click(object sender, EventArgs e)
        {
            if (UtilidadesGenericas.EstadoTurnoSistema)
            {
                UtilidadesGenericas.showFormInPanel(panelBody, IOC.InjectForm<frmFacturaRecibo>().GetThis());
            }
            else
                UtilidadesGenericas.MsgShow(
                    "AVISO", 
                    "Turno encontra-se Fechado",
                    MessageBoxIcon.Information, 
                    MessageBoxButtons.OK
                );
        }

        private void btnEfectuarPagamentos_Click(object sender, EventArgs e)
        {
            if (UtilidadesGenericas.EstadoTurnoSistema)
            {
                frmNotaPagamento chamada = IOC.InjectForm<frmNotaPagamento>();
                chamada.ShowDialog();
                UtilidadesGenericas.showFormInPanel(panelBody, chamada);
            }
            else
                UtilidadesGenericas.MsgShow(
                    "AVISO", 
                    "Turno encontra-se Fechado",
                    MessageBoxIcon.Information, 
                    MessageBoxButtons.OK
                );
        }

        private void btnMoedas_Click(object sender, EventArgs e)
        {
            var chamada = IOC.InjectForm<frmMoedas>();
            chamada.btnVoltar.Visibility = BarItemVisibility.Never;
            UtilidadesGenericas.showFormInPanel(panelBody, chamada);
        }

        private void btnUnidadBancaria_Click(object sender, EventArgs e)
        {
            var chamada = IOC.InjectForm<frmInteligente>();
            chamada.FormBorderStyle = FormBorderStyle.None;
            UtilidadesGenericas.showFormInPanel(panelBody, chamada.ShowList("Bancos", "Unidade Bancaria"));
        }

        private void btnContaBancaria_Click(object sender, EventArgs e)
        {
            frmContasBancarias chamada = IOC.InjectForm<frmContasBancarias>();
            chamada.btnVoltar.Visibility = BarItemVisibility.Never;
            chamada.FormBorderStyle = FormBorderStyle.None;
            UtilidadesGenericas.showFormInPanel(panelBody, chamada);
        }

        private void btnFPagamentos_Click(object sender, EventArgs e)
        {
            frmFPagamento chamada = IOC.InjectForm<frmFPagamento>();
            chamada.FormBorderStyle = FormBorderStyle.None;
            UtilidadesGenericas.showFormInPanel(panelBody, chamada);
        }

        private void btnFinalidadePagamento_Click(object sender, EventArgs e)
        {
            var chamada = IOC.InjectForm<frmInteligente>();
            chamada.FormBorderStyle = FormBorderStyle.None;
            UtilidadesGenericas.showFormInPanel(panelBody, chamada.ShowList("TipoSaida", "Finalidade de Pagamento"));
        }

        private void btnRelatorioVenda_Click(object sender, EventArgs e)
        {

        }

        private void btnRelatorioCompra_Click(object sender, EventArgs e)
        {

        }

        private void accordionControlElement2_Click(object sender, EventArgs e)
        {

        }

        private void btnTrevosolution_Click(object sender, EventArgs e)
        {
            frmTrevo chamada = new frmTrevo();
            chamada.FormBorderStyle = FormBorderStyle.None;
            UtilidadesGenericas.showFormInPanel(panelBody, chamada);
        }

        private void btnRelatorioHospitalar_Click(object sender, EventArgs e)
        {

        }

        private void btnFechar_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void btnFechar_MouseHover(object sender, EventArgs e)
        {
            btnFechar.BackColor = Color.Red;
        }

        private void btnFechar_MouseLeave(object sender, EventArgs e)
        {
            btnFechar.BackColor = Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(45)))), ((int)(((byte)(61)))));
        }

        private void accordionControlElement1_Click(object sender, EventArgs e)
        {
            if (UtilidadesGenericas.EstadoTurnoSistema)
            {
                frmTransferenciaCaixa chamada = IOC.InjectForm<frmTransferenciaCaixa>();
                UtilidadesGenericas.showFormInPanel(panelBody, chamada);

                //CarregarDocumentos();
            }
            else
                UtilidadesGenericas.MsgShow("AVISO", "Turno encontra-se Fechado", MessageBoxIcon.Information, MessageBoxButtons.OK);





        }

        private void btnTransfernciaBanco_Click(object sender, EventArgs e)
        {
            if (UtilidadesGenericas.EstadoTurnoSistema)
            {
                frmTransferenciaBanco chamada = IOC.InjectForm<frmTransferenciaBanco>();
                UtilidadesGenericas.showFormInPanel(panelBody, chamada);
                //CarregarDocumentos();
            }
            else
                UtilidadesGenericas.MsgShow("AVISO", "Turno encontra-se Fechado", MessageBoxIcon.Information, MessageBoxButtons.OK);

        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            UtilidadesGenericas.showFormInPanel(panelBody, IOC.InjectForm<frmConfiguracoesGeral>());

        }

        private void SeparadorAdmin_Click(object sender, EventArgs e)
        {

        }

        private void accordionControl1_ClientSizeChanged(object sender, EventArgs e)
        {
            if (panelBody.Controls.Count > 0)
            {
                var formControl = panelBody.Controls[0];
                panelBody.Controls.Clear();
                panelBody.Controls.Add(formControl);
            }
        }

        private void lbEmpresa_Click(object sender, EventArgs e)
        {

        }

        private void btnTrevoMobile_Click(object sender, EventArgs e)
        {

        }

        private void btnAfilhares_Click(object sender, EventArgs e)
        {

        }

        private void SeparadorSessao_Click(object sender, EventArgs e)
        {

        }
        private void ActualizarPermissaoAcesso()
        {
            refreshMenuPrincipal(acMenuPrincipal.Elements);
            _perfilApp.CarregarAcessos(UtilidadesGenericas.LoginUser, UtilidadesGenericas.GetSenhaEncriptada());
            Permicao();
            if (InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate {
                    ChamarFormNotificacoes();
                }));
            }
            else
            {
                ChamarFormNotificacoes();
            }
        }

        private void refreshMenuPrincipal(AccordionControlElementCollection elements)
        {
            foreach (var item in elements)
            {
                if (InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate {
                        if (item.Enabled)
                        {
                            item.Visible = true;
                            if (item.Elements.Count > 0)
                            {
                                refreshMenuPrincipal(item.Elements);
                            }
                        }
                    }));
                }
                else
                {
                    if (item.Enabled)
                    {
                        item.Visible = true;
                        if (item.Elements.Count > 0)
                        {
                            refreshMenuPrincipal(item.Elements);
                        }
                    }
                }
                
            }
        }

        private void btnActualizarPermissaoAcesso_Click(object sender, EventArgs e)
        {
            new FrmProcessar(ActualizarPermissaoAcesso).ShowDialog(this);

        }
    }
}