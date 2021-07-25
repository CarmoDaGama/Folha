using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraNavBar;
using Folha.Domain.Interfaces.Application.Empresa;
using Folha.Domain.Interfaces.Application.Sistema;
using Folha.Domain.Helpers;
using Folha.Driver.Framework.IOC;
using Folha.Presentation.Desktop.Classe;
using Folha.Presentation.Desktop.Forms.Apresenta_Doc;
using Folha.Presentation.Desktop.Forms.Armazens;
using Folha.Presentation.Desktop.Forms.Geral;
using Folha.Presentation.Desktop.Forms.Hispitalar;
using Folha.Presentation.Desktop.Forms.Hospitalar;
using Folha.Presentation.Desktop.Forms.Principal;
using Folha.Presentation.Desktop.Forms.Utilitarios_Configuracoes;
using Folha.Presentation.Desktop.Separadores.Armazens;
using Folha.Presentation.Desktop.Separadores.Empresa;
using Folha.Presentation.Desktop.Separadores.Entidades;
using Folha.Presentation.Desktop.Separadores.Financeiro;
using Folha.Presentation.Desktop.Separadores.Gestao_Escolar;
using Folha.Presentation.Desktop.Separadores.Notificacoes;
using Folha.Presentation.Desktop.Separadores.Recursos_Humanos;
using Folha.Presentation.Desktop.Separadores.Utilitarios_Configuracoes;
using SimpleInjector;
using System;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Folha.Domain.Enuns.Entidades;
using Folha.Domain.Enuns.Genericos;
using Folha.Domain.Interfaces.Application.Ficalizacao;
using Folha.Presentation.Desktop.Forms.Fiscalisacao;
using Folha.Presentation.Desktop.Forms.Documentos;
using Folha.Domain.Models.UtilitariosConfiguracoes;
using Folha.Domain.Interfaces.Application.UtilitariosConfiguracoes;
using System.Collections.Generic;
using Folha.Presentation.Desktop.Forms.Empresa;

namespace Folha.Presentation.Desktop.Separadores.Principal
{
    public partial class frmPrincipal : RibbonForm
    {
        private readonly ITurnosApp _turnosApp;
        private readonly IEmpresaApp _empresaApp;
        private readonly IPeriodoBackupApp _perido;
        List<PeriodoBackup> listaPeridoBackUp;

        public frmPrincipal(ITurnosApp turnosApp, IEmpresaApp empApp, IPeriodoBackupApp perido)
        {
            InitializeComponent();
            _turnosApp = turnosApp;
            _empresaApp = empApp;
            _perido = perido;
        }
        #region Permissão
        private void Permicao()
        {
            int x = int.Parse(UtilidadesGenericas.UsuarioPerfil.ToString()); 
            if (UtilidadesGenericas.TemPOS || UtilidadesGenericas.TemRestaurante || UtilidadesGenericas.TemHotel)
            {
                ///////////////////////////////////////PERMIÇÃO DO SEPARADOR///////////////////////////////////////////

                SeparadorSessao.Visible = true;
                if (UtilidadesGenericas.TemAcesso("Administração") == false) { SeparadorAdmin.Visible = false; }
                else{ SeparadorAdmin.Visible = true; }
                if (UtilidadesGenericas.TemAcesso("Vendas") == false) { btnSeparadorVenda.Visible = false; }
                else { btnSeparadorVenda.Visible = true; }
                if (UtilidadesGenericas.TemAcesso("Compra") == false) { SeparadorCompras.Visible = false; }
                else { SeparadorCompras.Visible = true; }
                if (UtilidadesGenericas.TemAcesso("Hospitalar") == false) { btnSeparadorHospitalar.Visible = false; }
                else { btnSeparadorHospitalar.Visible = true; }
                if (UtilidadesGenericas.TemAcesso("Inventario") == false) { SeparadorInventario.Visible = false; }
                else { SeparadorInventario.Visible = true; }
                if (UtilidadesGenericas.TemAcesso("Financeiro") == false) { SeparadorFinanceiro.Visible = false; }
                else { SeparadorFinanceiro.Visible = true; }

               

                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            }

            if (x != 1)
            {
                 //Administrção
                if (UtilidadesGenericas.TemAcesso("Administração#Utilizador") == false) btnUsuarios.Enabled = false;
                if (UtilidadesGenericas.TemAcesso("Administração#Perfil") == false) btnPerfisUtilizadores.Enabled = false;
                if (UtilidadesGenericas.TemAcesso("Administração#Entidades") == false) btnEntidades.Enabled = false;
                if (UtilidadesGenericas.TemAcesso("Administração#GerarBD") == false) btnGerarNovaCopia.Enabled = false;
                if (UtilidadesGenericas.TemAcesso("Administração#Operações") == false) btnOperacoes.Enabled = false;
                if (UtilidadesGenericas.TemAcesso("Administração#Configuração") == false) btnConfig.Enabled = false;
                if (UtilidadesGenericas.TemAcesso("Administração#Correio") == false )btnCorreioEletronico.Enabled = false;
                if (UtilidadesGenericas.TemAcesso("Administração#Servidor") == false) btnServidorRemoto.Enabled = false;
                if (UtilidadesGenericas.TemAcesso("Administração#Empresa") == false) btnEmpresa.Enabled = false;
                if (UtilidadesGenericas.TemAcesso("Administração#Empresas") == false) btnEmpresas.Enabled = false;
                if (UtilidadesGenericas.TemAcesso("Administração#Tabela") == false) btnTabela.Enabled = false;
                if (UtilidadesGenericas.TemAcesso("Administração#Gerar SAFT") == false) btnGerarSaft.Enabled = false;
                if (UtilidadesGenericas.TemAcesso("Administração#Configrução BackUp") == false) btnConfigBackup.Enabled = false;


                // Vendas
                if (UtilidadesGenericas.TemAcesso("Vendas#Dash Board") == false) btndashBoardVendas.Enabled = false;
                if (UtilidadesGenericas.TemAcesso("Vendas#Relatorios") == false) btnRelatorioVenda.Enabled = false;
                if (UtilidadesGenericas.TemAcesso("Vendas#Clientes") == false) btnClientes.Enabled = false;
                if (UtilidadesGenericas.TemAcesso("Vendas#Contactos") == false) btnContactosVendas.Enabled = false;
                if (UtilidadesGenericas.TemAcesso("Vendas#Factura Recibo") == false) btnFacturaRecibo.Enabled = false;
                if (UtilidadesGenericas.TemAcesso("Vendas#Factura") == false) btnFactura.Enabled = false;
                if (UtilidadesGenericas.TemAcesso("Vendas#Proforma") == false) btnProform.Enabled = false;
                if (UtilidadesGenericas.TemAcesso("Vendas#Orçamento") == false) { btnOrcamento.Enabled = false; }
                if (UtilidadesGenericas.TemAcesso("Vendas#Outros Documetos") == false) btnTodosDoc_Vendas.Enabled = false;
                if (UtilidadesGenericas.TemAcesso("Vendas#Operacões Pendente") == false) btnOperacoesPendetes.Enabled = false;
                if (UtilidadesGenericas.TemAcesso("Vendas#Grelha de comissões") == false) btnGrelhaComissoes.Enabled = false;
                if (UtilidadesGenericas.TemAcesso("Vendas#Condições Pagamento") == false) btnCondicoesPagamento.Enabled = false;

                // Documentos
                if (UtilidadesGenericas.TemAcesso("Vendas#Documentos") == false) btnTodosDocumentosFinanceiro.Enabled = false;
                if (UtilidadesGenericas.TemAcesso("Vendas#Documentos") == false) btnTodosDoc_Compras.Enabled = false;

                // Compra
                if (UtilidadesGenericas.TemAcesso("Compra#Dash Board") == false) btnDashCompra.Enabled = false;
                if (UtilidadesGenericas.TemAcesso("Compra#Relatorios") == false) btnRelatorioCompra.Enabled = false;
                if (UtilidadesGenericas.TemAcesso("Compra#Fornecedor") == false) btnFornecedorCompra.Enabled = false;
                if (UtilidadesGenericas.TemAcesso("Compra#Compra Fornecedor") == false) btnCompraFornecedor.Enabled = false;
                if (UtilidadesGenericas.TemAcesso("Compra#Estornos") == false) btnEstomos.Enabled = false;
                if (UtilidadesGenericas.TemAcesso("Compra#Processo de Importação") == true) btnProcesso.Enabled = false;
                if (UtilidadesGenericas.TemAcesso("Compra#Gestores") == false) btnGestores.Enabled = false;
                if (UtilidadesGenericas.TemAcesso("Compra#Encomendas") == false) btnEcomendas.Enabled = false;
                if (UtilidadesGenericas.TemAcesso("Compra#Dash Board") == false) btnEcomendas.Enabled = false;
                if (UtilidadesGenericas.TemAcesso("Compra#Documentos") == false) btnTodosDoc_Compras.Enabled = false;

                // Hospitalar
                //if (UtilidadesGenericas.TemAcesso("Hospitalar#Dash Board") == false) btnDash.Enabled = false;
                if (UtilidadesGenericas.TemAcesso("Hospitalar#Relatorios") == false) btnRelatorioHosp.Enabled = false;
                if (UtilidadesGenericas.TemAcesso("Hospitalar#Medico") == false) btnMedicos.Enabled = false;
                if (UtilidadesGenericas.TemAcesso("Hospitalar#Paciente") == false) btnPacientes.Enabled = false;
                if (UtilidadesGenericas.TemAcesso("Hospitalar#Profissional de Saude") == false) btnProfissinalSaude.Enabled = false;
                if (UtilidadesGenericas.TemAcesso("Hospitalar#Atendimento") == false) btnAtendimentoRecepcao.Enabled = false;
                if (UtilidadesGenericas.TemAcesso("Hospitalar#Consultor") == false) btnconsultorio.Enabled = false;
                if (UtilidadesGenericas.TemAcesso("Hospitalar#Internamento") == false) btnInternamento.Enabled = false;
                if (UtilidadesGenericas.TemAcesso("Hospitalar#Laboratorio") == false) btnLaboratorio.Enabled = false;
                if (UtilidadesGenericas.TemAcesso("Hospitalar#Exames") == false) btnExames.Enabled = false;
                if (UtilidadesGenericas.TemAcesso("Hospitalar#Escala Medica") == false) btnEscalaMedica.Enabled = false;
                //if (UtilidadesGenericas.TemAcesso("Hospitalar#Horario de Atendimento") == false) btnHorarioAtendimento.Enabled = false;
                if (UtilidadesGenericas.TemAcesso("Hospitalar#Tipo de Consulta") == false) btnTipoConsulta.Enabled = false;
                if (UtilidadesGenericas.TemAcesso("Hospitalar#Area Hospitalar") == false) btnAreaHospitalar.Enabled = false;
                if (UtilidadesGenericas.TemAcesso("Hospitalar#Especilidade") == false) btnEspecialidade.Enabled = false;
                if (UtilidadesGenericas.TemAcesso("Hospitalar#Quarto") == false) btnSalasHospitalar.Enabled = false;
                if (UtilidadesGenericas.TemAcesso("Hospitalar#Camas") == false) btnCamas.Enabled = false;
                if (UtilidadesGenericas.TemAcesso("Hospitalar#Tarifas") == false) btnTarifas.Enabled = false;
                if (UtilidadesGenericas.TemAcesso("Hospitalar#Tipo Quartos") == false) btnTipoQuarto.Enabled = false;
                if (UtilidadesGenericas.TemAcesso("Hospitalar#Tipo Camas") == false) btnTipoCama.Enabled = false;
                if (UtilidadesGenericas.TemAcesso("Hospitalar#A Seguradoras") == false) btnSeguradora.Enabled = false;
                if (UtilidadesGenericas.TemAcesso("Hospitalar#Farmacos") == false) btnFarmacos.Enabled = false;
                if (UtilidadesGenericas.TemAcesso("Hospitalar#Configurações") == false) btnConfiguracao.Enabled = false;

                // Inventario
                if (UtilidadesGenericas.TemAcesso("Inventario#Dash Board") == false) btnDashiBordInventario.Enabled = false;
                if (UtilidadesGenericas.TemAcesso("Inventario#Relatorios") == false) btnRelatorioInventario.Enabled = false;
                if (UtilidadesGenericas.TemAcesso("Inventario#Artigos") == false) { btnArtigos.Enabled = false; }
                if (UtilidadesGenericas.TemAcesso("Inventario#Familia de Produtos") == false) btnFamiliaProduto.Enabled = false;
                if (UtilidadesGenericas.TemAcesso("Inventario#Armazens") == false) btnArmazens.Enabled = false;
                if (UtilidadesGenericas.TemAcesso("Inventario#Imposto") == false) btnImposto.Enabled = false;
                if (UtilidadesGenericas.TemAcesso("Inventario#Movimentos de Artigos") == false) btnmovArtigo.Enabled = false;
                if (UtilidadesGenericas.TemAcesso("Inventario#Movimentos de Artigos#Saidas") == false) btnSaidas.Enabled = false;
                if (UtilidadesGenericas.TemAcesso("Inventario#Movimentos de Artigos#Transferencias") == false) btnTransferencias.Enabled = false;
                if (UtilidadesGenericas.TemAcesso("Inventario#Movimentos de Artigos#Entradas") == false) btnEntradas.Enabled = false;
                if (UtilidadesGenericas.TemAcesso("Inventario#Lote de Artigo") == false) btnLotes.Enabled = false;

                //// Financeiro
                if (UtilidadesGenericas.TemAcesso("Financeiro#Dash Board") == false) btnDashBoardFinanceiro.Enabled = false;
                if (UtilidadesGenericas.TemAcesso("Financeiro#Relatorios") == false) btnRelatorioFinanceiro.Enabled = false;
                if (UtilidadesGenericas.TemAcesso("Financeiro#Caixas") == false) btnCaixa.Enabled = false;
                if (UtilidadesGenericas.TemAcesso("Financeiro#Bancario") == false) btnBancario.Enabled = false;
                if (UtilidadesGenericas.TemAcesso("Financeiro#Turno de Vendedores") == false) btnTodosTurnos.Enabled = false;
                if (UtilidadesGenericas.TemAcesso("Financeiro#Registros Periodicos") == false) btnRegistosPeriodicos.Enabled = false;
                if (UtilidadesGenericas.TemAcesso("Financeiro#Receber Pagamentos") == false) btnReceberPagamentos.Enabled = false;
                if (UtilidadesGenericas.TemAcesso("Financeiro#Efectuar Pagamentos") == false) btnEfectuarPagamentos.Enabled = false;
                if (UtilidadesGenericas.TemAcesso("Financeiro#Moedas") == false) btnMoedas.Enabled = false;
                if (UtilidadesGenericas.TemAcesso("Financeiro#Unidades Bancaria") == false) btnUnidadBancaria.Enabled = false;
                if (UtilidadesGenericas.TemAcesso("Financeiro#Caixa") == false) btnVerCaixa.Enabled = false;
                if (UtilidadesGenericas.TemAcesso("Financeiro#Conta Bancaria") == false) btnContaBancaria.Enabled = false;
                if (UtilidadesGenericas.TemAcesso("Financeiro#Formas de Pagamento") == false) btnFPagamentos.Enabled = false;
                if (UtilidadesGenericas.TemAcesso("Financeiro#Finlidade de Pagamentos") == false) btnFinalidadePagamento.Enabled = false;
            }


        }
        #endregion



        void navBarControl_ActiveGroupChanged(object sender, NavBarGroupEventArgs e)
        {
            //navigationFrame.SelectedPageIndex = navBarControl.Groups.IndexOf(e.Group);
        }
        void barButtonNavigation_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmVerEntidade chamada = IOC.InjectForm<frmVerEntidade>();
            UtilidadesGenericas.showFormInPanel(panelBody, chamada);
        }

        private void btnProforma_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void barButtonItem20_ItemClick(object sender, ItemClickEventArgs e)
        {
            
        }

        private void btnTodosDocumentos_ItemClick(object sender, ItemClickEventArgs e)
        {          
            UtilidadesGenericas.showFormInPanel(panelBody, IOC.InjectForm<frmVerTodosDocumentos>());
        }
        private void btnPostoVendas_ItemClick(object sender, ItemClickEventArgs e)
        {
            new frmApresentaReport().ApresentarReportTestMarcaDaAgua();
        }

        private void btnOrdemServico_ItemClick(object sender, ItemClickEventArgs e)
        {
        } 

        private void btnConfiguracoes_ItemClick(object sender, ItemClickEventArgs e)
        {
          
        }

        private void btnFamiliaProduto_ItemClick(object sender, ItemClickEventArgs e)
        {
      
            var container = new Container();
            IOC.RegistrarInjecao(container);
            frmCategorias chamada = container.GetInstance<frmCategorias>();

            UtilidadesGenericas.showFormInPanel(panelBody, chamada);
        }

        private void btnArmazens_ItemClick(object sender, ItemClickEventArgs e)
        {
            
            UtilidadesGenericas.showFormInPanel(panelBody, IOC.InjectForm<frmInteligente>().ShowList("Armazens", "Armazens"));

        }

        private void btnReceberPagamentos_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (UtilidadesGenericas.EstadoTurnoSistema)
            {
                frmFacturaRecibo chamada = IOC.InjectForm<frmFacturaRecibo>();
                chamada.ShowDialog();
            }
            else MessageBox.Show(
                  "Turno Está fechado!",
                  "Mensagem",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Stop
              );
        }

        private void btnEfectuarPagamentos_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (UtilidadesGenericas.EstadoTurnoSistema)
            {
                frmNotaPagamento chamada = IOC.InjectForm<frmNotaPagamento>();
                chamada.ShowDialog();
            }
            else MessageBox.Show(
                  "Turno Está fechado!",
                  "Mensagem",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Stop
              );
           
        }

        private void btnMoedas_ItemClick(object sender, ItemClickEventArgs e)
        {
            var chamada = IOC.InjectForm<frmMoedas>();
            chamada.btnVoltar.Visibility = BarItemVisibility.Never;
            UtilidadesGenericas.showFormInPanel(panelBody, chamada);

            //panelBody.Controls.Clear();
            //frmMoedas chamada = IOC.InjectForm<frmMoedas>();
            //chamada.TopLevel = false;
            //chamada.AutoScroll = true;
            //panelBody.Controls.Add(chamada);
            //chamada.btnVoltar.Visibility = BarItemVisibility.Never;
            //chamada.Show();
        }

       

        private void btnLancarNotas_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmLancarNotas chamada = new frmLancarNotas();
            chamada.ShowDialog();

        }

        private void btnIndividual_ItemClick(object sender, ItemClickEventArgs e)
        {
            panelBody.Controls.Clear();
            frmVerNotasIndividuais chamada = new frmVerNotasIndividuais();
            chamada.TopLevel = false;
            chamada.AutoScroll = true;
            panelBody.Controls.Add(chamada);
            chamada.Show();
        }

        private void btnNiveisAcademicos_ItemClick(object sender, ItemClickEventArgs e)
        {
          frmNiveisAcademico chamada = new frmNiveisAcademico();
            chamada.ShowDialog();
        }

        private void btnDisciplinas_ItemClick(object sender, ItemClickEventArgs e)
        {
           
      
        }

        private void btnTurnos_ItemClick(object sender, ItemClickEventArgs e)
        {
          
        }

        private void btnSalas_ItemClick(object sender, ItemClickEventArgs e)
        {
           
           
        }

        private void btnClasses_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }

        private void btnTransporte_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }

        private void btnModalidadeMulta_ItemClick(object sender, ItemClickEventArgs e)
        {
          frmModalidadesMulta chamada = new Separadores.Gestao_Escolar.frmModalidadesMulta();
            chamada.ShowDialog();
        }

        private void btnEmolumentos_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmEmolumentosEscolares chamada = new Separadores.Gestao_Escolar.frmEmolumentosEscolares();
            chamada.ShowDialog();
        }

        private void btnReceberPagamentos_GestaoEscolar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Separadores.Gestao_Escolar.frmReceberPagamentos chamada = new Separadores.Gestao_Escolar.frmReceberPagamentos();
            chamada.ShowDialog();
        }

        private void brnTarifaTransporte_ItemClick(object sender, ItemClickEventArgs e)
        {
            Separadores.Gestao_Escolar.frmTarifaTransporte chamada = new Separadores.Gestao_Escolar.frmTarifaTransporte();
            chamada.ShowDialog();
        }

        private void btnMovimentos_ItemClick(object sender, ItemClickEventArgs e)
        {
            Separadores.Recursos_Humanos.frmMovimentos chamada = new Separadores.Recursos_Humanos.frmMovimentos();
            chamada.ShowDialog();
        }

        private void btnTurnos_RecursosHumanos_ItemClick(object sender, ItemClickEventArgs e)
        {
            Separadores.Recursos_Humanos.frmTurnos chamada = new Separadores.Recursos_Humanos.frmTurnos();
            chamada.ShowDialog();
        }

        private void btnCategoria_ItemClick(object sender, ItemClickEventArgs e)
        {
            Separadores.Recursos_Humanos.frmCategoriaFuncionario chamada = new Separadores.Recursos_Humanos.frmCategoriaFuncionario();
            chamada.ShowDialog();
        }

        private void btnFuncoes_ItemClick(object sender, ItemClickEventArgs e)
        {
            Separadores.Recursos_Humanos.frmFuncao chamada = new Separadores.Recursos_Humanos.frmFuncao();
            chamada.ShowDialog();
        }

        private void btnTipoContrato_ItemClick(object sender, ItemClickEventArgs e)
        {
            Separadores.Recursos_Humanos.frmTipoContrato chamada = new Separadores.Recursos_Humanos.frmTipoContrato();
            chamada.ShowDialog();
        }

        private void btnProfissoes_ItemClick(object sender, ItemClickEventArgs e)
        {
            Separadores.Recursos_Humanos.frmProfissaoFuncionario chamada =IOC.InjectForm<frmProfissaoFuncionario>();
            chamada.ShowDialog();

        }

        private void brnCategoriaCargo_ItemClick(object sender, ItemClickEventArgs e)
        {
            Separadores.Recursos_Humanos.frmCategoriaFuncionario chamada = new Separadores.Recursos_Humanos.frmCategoriaFuncionario();
            chamada.ShowDialog();
        }

        private void btnHabilitacoes_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmHabilitacaoLitararias chamada = IOC.InjectForm<frmHabilitacaoLitararias>();
            chamada.ShowDialog();
        }

        private void btnFolhaSalario_ItemClick(object sender, ItemClickEventArgs e)
        {
            Separadores.Recursos_Humanos.frmFolhaSalarios chamada = new Separadores.Recursos_Humanos.frmFolhaSalarios();
            chamada.ShowDialog();
        }

        private void btnDepartamento_ItemClick(object sender, ItemClickEventArgs e)
        {
            Separadores.Recursos_Humanos.frmDepartamento chamada = new Separadores.Recursos_Humanos.frmDepartamento();
            chamada.ShowDialog();
        }

        private void btnReceberPagamentos_PT_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }

        private void btnPtsCentrais_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void btnBairro_ItemClick(object sender, ItemClickEventArgs e)
        {
         
        }

        private void btnTarifasPagamento_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }

        private void btnDefinicao_PT_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }

        private void btnClausulaContratuais_PT_ItemClick(object sender, ItemClickEventArgs e)
        {
           

        }

      


        private void btnPerfil_ItemClick(object sender, ItemClickEventArgs e)
        {
          
        }

        private void barButtonItem93_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmVerUsuario chamada = IOC.InjectForm<frmVerUsuario>();
            Controle.Painel(panelBody, chamada);
        }

        private void FormPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
          //Application.Exit();
        }

        private void buttonServico_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void barButtonItem81_ItemClick(object sender, ItemClickEventArgs e)
        {
            panelBody.Controls.Clear();
            var container = new Container();
            IOC.RegistrarInjecao(container);
            frmVerEntidade chamada = container.GetInstance<frmVerEntidade>();
            chamada.TopLevel = false;
            chamada.Dock = DockStyle.Fill;
            panelBody.Controls.Add(chamada);
            panelBody.Tag = chamada;
            chamada.Show();
        }

        private void buttonLavandeiras_ItemClick(object sender, ItemClickEventArgs e)
        {
            new frmTecnicos().ShowDialog();
        }

        private void buttonCadastros_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void buttonPecas_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void buttonEfectuarRegistro_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void buttonTipoPecas_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void buttonCores_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void buttonTecidos_ItemClick(object sender, ItemClickEventArgs e)
        {
        }
        private void btnCorreio_ItemClick(object sender, ItemClickEventArgs e)
        {
        }
       
        private void btnRelatorio_ItemClick(object sender, ItemClickEventArgs e)
        {
            //panelBody.Controls.Clear();
            //Separadores.Principal.frmVerRelatorioOperacoes chamada = new Separadores.Principal.frmVerRelatorioOperacoes();
            //chamada.TopLevel = false;
            //chamada.Dock = DockStyle.Fill;
            //panelBody.Controls.Add(chamada);
            //panelBody.Tag = chamada;
            //chamada.Show();
        }

        private void btnOperacoesPendentes_ItemClick(object sender, ItemClickEventArgs e)
        {
            UtilidadesGenericas.showFormInPanel(panelBody, IOC.InjectForm<frmVerOperacoesPendentes>());
        }

        private void btnRestaurante_ItemClick(object sender, ItemClickEventArgs e)
        {
            
        }

        void CarregaTudo()
        {
            Permicao();
            btnEntidadeLogada.Caption = UtilidadesGenericas.NomeUsuario;
            btnNomeEmpresa.Caption = UtilidadesGenericas.DadosEmpresa.Nome ;
            carregarTurnoCurrent();
            panelBody.Controls.Clear();       
            Controle.CabecalhoEmpresa = _empresaApp.Listar().FirstOrDefault();
            AlterarSenhaPadrao();

            if (InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate {
                    frmNotificacoes chamadaNotificacao = IOC.InjectForm<frmNotificacoes>();
                    UtilidadesGenericas.showFormInPanel(panelBody, chamadaNotificacao);
                }));
            }
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {          
            new Forms.Sistema.FrmProcessar(CarregaTudo).ShowDialog(this);
            //UtilidadesGenericas.FormPrincipal = this;
        }

        private void AlterarSenhaPadrao()
        {
            while (UtilidadesGenericas.UsuarioAlterado == false)
            {
                if (messagemShow("É necessario alterar a senha do usuário " + UtilidadesGenericas.NomeUsuario + "\n por questão de segurança!"))
                {
                    UtilidadesGenericas.Busca.Codigo = UtilidadesGenericas.UsuarioCodigo.ToString();
                    UtilidadesGenericas.Busca.Alterou = false;
                    //IOC.InjectForm<frmUsuario>().btnBuscaPerfil.Enabled =false.ShowDialog();
                    frmUsuario chamada = IOC.InjectForm<frmUsuario>();
                   
                    chamada.Size = new System.Drawing.Size(517, 300);
                    chamada.btnVoltar.Visibility = BarItemVisibility.Never;
                    chamada.btnSalvar.Visibility = BarItemVisibility.Never;
                    chamada.ShowDialog();
                }
                else
                {
                    System.Windows.Forms.Application.Exit();
                    return;
                }
            }           
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

        private void btnEntidade_ItemClick(object sender, ItemClickEventArgs e)
        {
            var container = new Container();
            IOC.RegistrarInjecao(container);
            UtilidadesGenericas.showFormInPanel(panelBody, container.GetInstance<frmVerEntidade>());
        }

        private void btnMeuTurno_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmMeuTurno chamada = IOC.InjectForm<frmMeuTurno>();
            chamada.FormBorderStyle = FormBorderStyle.None;
            UtilidadesGenericas.showFormInPanel(panelBody, chamada);
        }

        private void btnProdutos_ItemClick(object sender, ItemClickEventArgs e)
        {
            var container = new Container();
            IOC.RegistrarInjecao(container);
            frmVerProdutos chamada = container.GetInstance<frmVerProdutos>();
            UtilidadesGenericas.showFormInPanel(panelBody, chamada);
        }

        private void navBarItem_Notificacoes_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            panelBody.Controls.Clear();
            frmNotificacoes chamada = IOC.InjectForm<frmNotificacoes>();
            UtilidadesGenericas.showFormInPanel(panelBody, chamada);
        }

       

        private void btnFornecedores_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmVerEntidade chamada = IOC.InjectForm<frmVerEntidade>();
            chamada.TipoEntity = Folha.Domain.Enuns.Entidades.TypeEntity.FORNECEDOR;
            UtilidadesGenericas.showFormInPanel(panelBody, chamada);

        }

        private void barButtonItem12_ItemClick(object sender, ItemClickEventArgs e)
        {
            panelBody.Controls.Clear();
            frmVerEntidade chamada = IOC.InjectForm<frmVerEntidade>();
            chamada.TipoEntity = Folha.Domain.Enuns.Entidades.TypeEntity.FUNCIONARIO;
            UtilidadesGenericas.showFormInPanel(panelBody, chamada);
        }

        private void btnCaixa_ItemClick(object sender, ItemClickEventArgs e)
        {
            var container = new Container();
            IOC.RegistrarInjecao(container);
            frmVerMovimentosCaixa chamada = container.GetInstance<frmVerMovimentosCaixa>();
            
            UtilidadesGenericas.showFormInPanel(panelBody, chamada);
        }

        private void btnBancario_ItemClick(object sender, ItemClickEventArgs e)
        {

            panelBody.Controls.Clear();
            frmVerMovimentosBancarios chamada = IOC.InjectForm<frmVerMovimentosBancarios>();
            chamada.TopLevel = false;
            chamada.AutoScroll = true;
            panelBody.Controls.Add(chamada);
            chamada.Show();
        }

        private void btnTodosTurnos_ItemClick(object sender, ItemClickEventArgs e)
        {
            panelBody.Controls.Clear();
            frmVerTodosTurnos chamada = IOC.InjectForm<frmVerTodosTurnos>();
            chamada.TopLevel = false;
            chamada.AutoScroll = true;
            panelBody.Controls.Add(chamada);
            chamada.Show();
        }

        private void btnRegistosPeriodicos_ItemClick(object sender, ItemClickEventArgs e)
        {
            panelBody.Controls.Clear();
            frmVerRegistosPeriodicos chamada = IOC.InjectForm<frmVerRegistosPeriodicos>();
            chamada.TopLevel = false;
            chamada.AutoScroll = true;
            panelBody.Controls.Add(chamada);
            chamada.Show();
        }

        private void btnGestaoAlunos_ItemClick(object sender, ItemClickEventArgs e)
        {
            //frmVerAlunos chamada = new frmVerAlunos();
            UtilidadesGenericas.showFormInPanel(panelBody, IOC.InjectForm<frmAlunos>());
        }

        private void btnMatriculaConfirmacao_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmVerMatriculasConfirmacoes chamada = new frmVerMatriculasConfirmacoes();
            UtilidadesGenericas.showFormInPanel(panelBody, chamada);
        }
        private void btnDadosEmpresa_ItemClick(object sender, ItemClickEventArgs e)
        {
            IOC.InjectForm<frmDadosEmpresa>().ShowDialog();
        }

        private void btnBackup_ItemClick(object sender, ItemClickEventArgs e)
        {
            new frmCopiaSegurança().ShowDialog();
        }

        private void btnPaises_ItemClick(object sender, ItemClickEventArgs e)
        {
            UtilidadesGenericas.showFormInPanel(panelBody, IOC.InjectForm<frmInteligente>().ShowList("Pais", "País (Nacionalidade)"));
        }

        private void btnFabricante_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void btnModelo_ItemClick(object sender, ItemClickEventArgs e)
        {
          
        }

        private void btnTecnico_ItemClick(object sender, ItemClickEventArgs e)
        {
            new frmTecnicos().ShowDialog();
        }

        private void btnServicos_ItemClick(object sender, ItemClickEventArgs e)
        {
            UtilidadesGenericas.showFormInPanel(panelBody, IOC.InjectForm<frmInteligente>().ShowList("AreasHospitalar", "Áreas Hospitalar"));

        }

        private void btnEquipamentos_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void btnGarantia_ItemClick(object sender, ItemClickEventArgs e)
        {
            UtilidadesGenericas.showFormInPanel(panelBody, IOC.InjectForm<frmInteligente>().ShowList("Farmacos", "Farmacos"));
        }

        private void btnMotorista_ItemClick(object sender, ItemClickEventArgs e)
        {
            //panelBody.Controls.Clear();
            //frmMotorista chamada = new frmMotorista();
            //chamada.TopLevel = false;
            //chamada.Dock = DockStyle.Fill;
            //panelBody.Controls.Add(chamada);
            //panelBody.Tag = chamada;
            //chamada.Show();
        }

        private void btnModalidades_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void btnTipoAtendimento_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void btnSala_ItemClick(object sender, ItemClickEventArgs e)
        {
            var container = new Container();
            IOC.RegistrarInjecao(container);
            container.GetInstance<frmSalas>().ShowDialog();
        }

        private void btnTransferencia_ItemClick(object sender, ItemClickEventArgs e)
        {
            var container = new Container();
            IOC.RegistrarInjecao(container);
            frmStockTransferencia chamada = container.GetInstance<frmStockTransferencia>();
            UtilidadesGenericas.showFormInPanel(panelBody, chamada);
        }

        private void btnRelatorioEstatistica_SA_ItemClick(object sender, ItemClickEventArgs e)
        {
            panelBody.Controls.Clear();
            frmRelatorioProdutos chamada = new frmRelatorioProdutos();
            chamada.TopLevel = false;
            chamada.Dock = DockStyle.Fill;
            panelBody.Controls.Add(chamada);
            panelBody.Tag = chamada;
            chamada.Show();
        }

        private void btnRelatorioEstatisticas_F_ItemClick(object sender, ItemClickEventArgs e)
        {
           
            
        }

        private void btnColetivo_ItemClick(object sender, ItemClickEventArgs e)
        {
            panelBody.Controls.Clear();
            frmVerNotasColetivas chamada = new frmVerNotasColetivas();
            chamada.TopLevel = false;
            chamada.Dock = DockStyle.Fill;
            panelBody.Controls.Add(chamada);
            panelBody.Tag = chamada;
            chamada.Show();
        }

        private void btnCriterios_ItemClick(object sender, ItemClickEventArgs e)
        {
            panelBody.Controls.Clear();
            frmCriteriosAvaliacao chamada = new frmCriteriosAvaliacao();
            chamada.TopLevel = false;
            chamada.Dock = DockStyle.Fill;
            panelBody.Controls.Add(chamada);
            panelBody.Tag = chamada;
            chamada.Show();
        }

        private void btnCursosFormacao_ItemClick(object sender, ItemClickEventArgs e)
        {
            panelBody.Controls.Clear();
            frmVerCursos chamada = new frmVerCursos();
            chamada.TopLevel = false;
            chamada.Dock = DockStyle.Fill;
            panelBody.Controls.Add(chamada);
            panelBody.Tag = chamada;
            chamada.Show();
        }

        private void btnTurmas_ItemClick(object sender, ItemClickEventArgs e)
        {
            panelBody.Controls.Clear();
            frmVerTurmas chamada = new frmVerTurmas();
            chamada.TopLevel = false;
            chamada.Dock = DockStyle.Fill;
            panelBody.Controls.Add(chamada);
            panelBody.Tag = chamada;
            chamada.Show();
        }

        private void btnProfessores_ItemClick(object sender, ItemClickEventArgs e)
        {
            panelBody.Controls.Clear();
           frmVerProfessores chamada = new frmVerProfessores();
            chamada.TopLevel = false;
            chamada.Dock = DockStyle.Fill;
            panelBody.Controls.Add(chamada);
            panelBody.Tag = chamada;
            chamada.Show();
        }

        private void btnPortugues_ItemClick(object sender, ItemClickEventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-PT");
            Controle.Idioma();ControlIdiomaFPrincipal();
        }

        private void btnIngles_ItemClick(object sender, ItemClickEventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-EN");
            Controle.Idioma(); ControlIdiomaFPrincipal();
        }
        #region LISTA IDIOMA
        protected void ControlIdiomaFPrincipal()
        {
            //ribbonPage_UtilitariosConfiguracoes.Text = Rotulos.UtilitariosConfiguracoes;
            //btnCopiaSeguranca.Caption = Rotulos.CopiaSeguranca;
            //btnOpSistema.Caption = Rotulos.OpSistema;
            //btnContasEmail.Caption = Rotulos.ContasEmail;
            //btnConfMaquina.Caption = Rotulos.ConfigMaquina;
            //btnAltSenha.Caption = Rotulos.AlterarMSenha;
            //btnUsuario.Caption = Rotulos.Usuarios;
            //btnPerfil.Caption = Rotulos.PerfisAcesso;
            //btnCorreio.Caption = Rotulos.CorreioElectronico;

        }
        #endregion

        private void btnCopiaSeguranca_ItemClick(object sender, ItemClickEventArgs e)
        {
            new frmCopiaSegurança().ShowDialog();
        }

        private void btnOpSistema_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            IOC.InjectForm<frmOpSistema>().ShowDialog();
        }

        private void btnContasEmail_ItemClick_1(object sender, ItemClickEventArgs e)
        {
        }

        private void btnConfMaquina_ItemClick(object sender, ItemClickEventArgs e)
        {        }

        private void btnFuncionario_P_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmVerEntidade chamada = IOC.InjectForm<frmVerEntidade>();
            chamada.TipoEntity = Folha.Domain.Enuns.Entidades.TypeEntity.FUNCIONARIO;
            UtilidadesGenericas.showFormInPanel(panelBody, chamada);
        }

        private void btnFuncionario_RH_ItemClick(object sender, ItemClickEventArgs e)
        {
            panelBody.Controls.Clear();
           frmVerFuncionarioAtivo chamada = new frmVerFuncionarioAtivo();
            chamada.TopLevel = false;
            chamada.Dock = DockStyle.Fill;
            panelBody.Controls.Add(chamada);
            panelBody.Tag = chamada;
            chamada.Show();
        }

        private void btnDiario_ItemClick(object sender, ItemClickEventArgs e)
        {
            panelBody.Controls.Clear();
            frmVerControloPonto chamada = new frmVerControloPonto();
            chamada.TopLevel = false;
            chamada.Dock = DockStyle.Fill;
            panelBody.Controls.Add(chamada);
            panelBody.Tag = chamada;
            chamada.Show();
        }

        private void btnMensal_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btnControloFerias_ItemClick(object sender, ItemClickEventArgs e)
        {
            panelBody.Controls.Clear();
             frmVerFerias chamada = new frmVerFerias();
            chamada.TopLevel = false;
            chamada.Dock = DockStyle.Fill;
            panelBody.Controls.Add(chamada);
            panelBody.Tag = chamada;
            chamada.Show();
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            //MessageBox.Show(_dbApp.TestarUtilidadesGenericas());
        }

        private void CmdFornecedores_ItemClick(object sender, ItemClickEventArgs e)
        {
            panelBody.Controls.Clear();
            var container = new Container();
            IOC.RegistrarInjecao(container);
            frmVerEntidade chamada = container.GetInstance<frmVerEntidade>();
            chamada.TopLevel = false;
            chamada.AutoScroll = true;
            panelBody.Controls.Add(chamada);
            chamada.Show();
        }

        private void barButtonItem8_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItem18_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void btnUnidadBancaria_ItemClick(object sender, ItemClickEventArgs e)
        {
            var chamada = IOC.InjectForm<frmInteligente>();
            chamada.FormBorderStyle = FormBorderStyle.None;
            UtilidadesGenericas.showFormInPanel(panelBody, chamada.ShowList("Bancos", "Unidade Bancaria"));
        }

        private void btnVerCaixa_ItemClick(object sender, ItemClickEventArgs e)
        {
            var chamada = IOC.InjectForm<frmInteligente>();
            chamada.FormBorderStyle = FormBorderStyle.None;
            UtilidadesGenericas.showFormInPanel(panelBody, chamada.ShowList("Caixas", "Caixas"));
        }

        private void btnContaBancaria_ItemClick(object sender, ItemClickEventArgs e)
        {

            frmContasBancarias chamada = IOC.InjectForm<frmContasBancarias>();
            chamada.btnVoltar.Visibility = BarItemVisibility.Never;
            chamada.FormBorderStyle = FormBorderStyle.None;
            UtilidadesGenericas.showFormInPanel(panelBody, chamada);
        }

        private void btnFPagamentos_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmFPagamento chamada = IOC.InjectForm<frmFPagamento>();
            chamada.FormBorderStyle = FormBorderStyle.None;
            UtilidadesGenericas.showFormInPanel(panelBody, chamada);
        }

    

        private void btnFinalidadePagamento_ItemClick(object sender, ItemClickEventArgs e)
        {
            var chamada = IOC.InjectForm<frmInteligente>();
            chamada.FormBorderStyle = FormBorderStyle.None;
            UtilidadesGenericas.showFormInPanel(panelBody, chamada.ShowList("TipoSaida", "Finalidade de Pagamento"));
        }
        private void btnTelaDeVenda_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }

        private void btnMedicos_ItemClick(object sender, ItemClickEventArgs e)
        {

            IOC.InjectForm<frmMedico>().ShowDialog();
        }

        private void btnPerfisUtilizadores_ItemClick(object sender, ItemClickEventArgs e)
        {
            UtilidadesGenericas.showFormInPanel(panelBody, IOC.InjectForm<frmPerfisAcesso>());
        }

        private void barButtonItem24_ItemClick(object sender, ItemClickEventArgs e)
        {
            var chamada = IOC.InjectForm<frmVerUsuario>();
            chamada.voltar.Visibility = BarItemVisibility.Never;
            UtilidadesGenericas.showFormInPanel(panelBody, chamada);
        }

        private void btnGerarNovaCopia_ItemClick(object sender, ItemClickEventArgs e)
        {
            new frmCopiaSegurança().ShowDialog();
        }

        private void btnRestaurarCopia_ItemClick(object sender, ItemClickEventArgs e)
        {
            new frmCopiaSegurança().ShowDialog();
        }

        private void btnOperacoes_ItemClick(object sender, ItemClickEventArgs e)
        {

            IOC.InjectForm<frmOpSistema>().ShowDialog();
        }

        private void btnProform_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (UtilidadesGenericas.EstadoTurnoSistema)
                IOC.InjectForm<frmTelaDocumento>().EfectuarOperacaoDocumento("PP", "ABERTO");
            else MessageBox.Show(
                    "Turno Está fechado!",
                    "Mensagem",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Stop
                );
        }

        private void btnFactura_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (UtilidadesGenericas.EstadoTurnoSistema)
                IOC.InjectForm<frmTelaDocumento>().EfectuarOperacaoDocumento("FT", "ABERTO");
            else MessageBox.Show(
                    "Turno Está fechado!",
                    "Mensagem",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Stop
                );
        }

        private void btnFacturaRecibo_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (UtilidadesGenericas.EstadoTurnoSistema)
                IOC.InjectForm<frmTelaDocumento>().ShowDialog();
            else MessageBox.Show(
                    "Turno Está fechado!",
                    "Mensagem",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Stop
                );
           
        }

        private void btnOrcamento_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (UtilidadesGenericas.EstadoTurnoSistema)
                IOC.InjectForm<frmTelaDocumento>().EfectuarOperacaoDocumento("ADM", "ABERTO");
            else MessageBox.Show(
                    "Turno Está fechado!",
                    "Mensagem",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Stop
                );
        }

        private void btnSistema_ItemClick(object sender, ItemClickEventArgs e)
        {
         }

        private void btnImpressoras_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void frmFornecedores_ItemClick(object sender, ItemClickEventArgs e)
        {
            UtilidadesGenericas.showFormInPanel(panelBody, IOC.InjectForm<frmEntidadeBusca>().This(TypeEntity.FORNECEDOR, CRUD.Listar));
        }

        private void btnDoc_ItemClick(object sender, ItemClickEventArgs e)
        {
            UtilidadesGenericas.showFormInPanel(panelBody, IOC.InjectForm<frmVerTodosDocumentos>());
        }

        private void btnRelatorios_Fin_ItemClick(object sender, ItemClickEventArgs e)
        {
            UtilidadesGenericas.showFormInPanel(panelBody, IOC.InjectForm<frmRelatorioFinanceiro>());
        }
        public void ChamarFormAqui(Form form)
        {
            UtilidadesGenericas.showFormInPanel(panelBody, form);
        }
        private void btnClientes_ItemClick(object sender, ItemClickEventArgs e)
        {
            UtilidadesGenericas.showFormInPanel(panelBody, IOC.InjectForm<frmVerEntidade>());
        }

 
        private void btnImposto_ItemClick(object sender, ItemClickEventArgs e)
        {
            
            UtilidadesGenericas.showFormInPanel(panelBody, IOC.InjectForm<frmImpostos>());
        }

        private void barButtonItem25_ItemClick(object sender, ItemClickEventArgs e)
        {
            UtilidadesGenericas.showFormInPanel(panelBody, IOC.InjectForm<frmNotificacoes>());
        }

        private void btnMedicos_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            UtilidadesGenericas.showFormInPanel(panelBody, IOC.InjectForm<frmMedicos>());
            UtilidadesGenericas.Busca.ModoLista= true;
        }

        private void btnPacientes_ItemClick(object sender, ItemClickEventArgs e)
        {
            UtilidadesGenericas.showFormInPanel(panelBody, IOC.InjectForm<frmPacientes>());
        }

        private void btnConfig_ItemClick(object sender, ItemClickEventArgs e)
        {
            IOC.InjectForm<frmConfiguracoesGeral>().ShowDialog();
        }

        private void btnTipoConsulta_ItemClick(object sender, ItemClickEventArgs e)
        {
            UtilidadesGenericas.showFormInPanel(panelBody, IOC.InjectForm<frmTipoConsultas>());
        }

        private void btnAtendimentoRecepcao_ItemClick(object sender, ItemClickEventArgs e)
        {
            UtilidadesGenericas.showFormInPanel(panelBody, IOC.InjectForm<frmAtendimentos>());
        }

        private void panelBody_Paint(object sender, PaintEventArgs e)
        {

        }

        private void barButtonItem39_ItemClick(object sender, ItemClickEventArgs e)
        {
            IOC.InjectForm<frmDadosEmpresa>().ShowDialog();

        }

        private void barButtonItem9_ItemClick(object sender, ItemClickEventArgs e)
        {
            IOC.InjectForm<frmLogin>().Show();
        }

        private void btnInternamento_ItemClick(object sender, ItemClickEventArgs e)
        {
            UtilidadesGenericas.showFormInPanel(panelBody, IOC.InjectForm<frmInternamentos>());
        }

        private void btnEscalaMedica_ItemClick(object sender, ItemClickEventArgs e)
        {
            UtilidadesGenericas.showFormInPanel(panelBody, IOC.InjectForm<frmEscalaMedicas>());
        }

        private void btnOperacoesPendetes_ItemClick(object sender, ItemClickEventArgs e)
        {
          
            UtilidadesGenericas.showFormInPanel(panelBody, IOC.InjectForm<frmVerOperacoesPendentes>());
        }

        private void btnTabela_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItem86_ItemClick(object sender, ItemClickEventArgs e)
        {
          
            UtilidadesGenericas.showFormInPanel(panelBody, IOC.InjectForm<frmLaboratorios>());
        }
        private void btnProfissinalSaude_ItemClick(object sender, ItemClickEventArgs e)
        {
            UtilidadesGenericas.showFormInPanel(panelBody, IOC.InjectForm<frmProfissionalSaudes>());
        }

        private void btnExames_ItemClick(object sender, ItemClickEventArgs e)
        {
            UtilidadesGenericas.showFormInPanel(panelBody, IOC.InjectForm<frmExames>());
        }

        private void btnAreaHospitalar_ItemClick(object sender, ItemClickEventArgs e)
        {
            UtilidadesGenericas.showFormInPanel(panelBody, IOC.InjectForm<frmInteligente>().ShowList("AreasHospitalar", "Áreas Hospitalar"));
        }

        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
        {
            UtilidadesGenericas.showFormInPanel(panelBody, IOC.InjectForm<frmInteligente>().ShowList("TiposQuartosHospitalar", "Tipo de Quarto Hospitalar"));
        }

        private void btnEspecialidade_ItemClick(object sender, ItemClickEventArgs e)
        {
            UtilidadesGenericas.showFormInPanel(panelBody, IOC.InjectForm<frmInteligente>().ShowList("Especialidades", "Especialidades do Medico"));

        }

        private void btnTipoCama_ItemClick(object sender, ItemClickEventArgs e)
        {
            UtilidadesGenericas.showFormInPanel(panelBody, IOC.InjectForm<frmInteligente>().ShowList("TiposCamasHospitalar", "Tipo de Camas Hospitalar"));
        }

        private void btnSalasHospitalar_ItemClick(object sender, ItemClickEventArgs e)
        {
            UtilidadesGenericas.showFormInPanel(panelBody, IOC.InjectForm<frmQuartosHospilares>());
        }

        private void btnCamas_ItemClick(object sender, ItemClickEventArgs e)
        {
            UtilidadesGenericas.showFormInPanel(panelBody, IOC.InjectForm<frmCamasHospitaleres>());
        }
        private void btnFarmacos_ItemClick(object sender, ItemClickEventArgs e)
        {
            UtilidadesGenericas.showFormInPanel(panelBody, IOC.InjectForm<frmInteligente>().ShowList("Farmacos", "Farmacos"));
        }

        private void btnSeguradora_ItemClick(object sender, ItemClickEventArgs e)
        {
            UtilidadesGenericas.showFormInPanel(panelBody, IOC.InjectForm<frmInteligente>().ShowList("SeguradoraHospitalar", "Seguradora Hospitalar"));
        }

        private void btnTarifas_ItemClick(object sender, ItemClickEventArgs e)
        {
            UtilidadesGenericas.showFormInPanel(panelBody, IOC.InjectForm<frmTarifasHospitalers>());
        }

        private void btnHorarioAtendimento_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btnconsultorio_ItemClick(object sender, ItemClickEventArgs e)
        {
            UtilidadesGenericas.showFormInPanel(panelBody, IOC.InjectForm<frmConsultorio>());
        }

        private void btnImpostoTaxa_ItemClick(object sender, ItemClickEventArgs e)
        {
            UtilidadesGenericas.showFormInPanel(panelBody, IOC.InjectForm<frmImpostos>());
        }

        private void btnSubCategoria_ItemClick(object sender, ItemClickEventArgs e)
        {
            UtilidadesGenericas.showFormInPanel(panelBody, IOC.InjectForm<frmSubcategorias>());
        }

        private void btnCompraFornecedor_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (UtilidadesGenericas.EstadoTurnoSistema)
                IOC.InjectForm<frmTelaDocumento>().EfectuarOperacaoDocumento("CF", "ABERTO");
            else MessageBox.Show(
                    "Turno Está fechado!",
                    "Mensagem",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Stop
                );
        }

        private void btnRelatorioProduto_ItemClick(object sender, ItemClickEventArgs e)
        {
            //panelBody.Controls.Clear();
            //frmRelatorioProdutos chamada = IOC.InjectForm<frmRelatorioProdutos>();
            //chamada.TopLevel = false;
            //chamada.AutoScroll = true;
            //panelBody.Controls.Add(chamada);
            //chamada.Show();
        }

        private void btnRelatorioHosp_ItemClick(object sender, ItemClickEventArgs e)
        {
            UtilidadesGenericas.showFormInPanel(panelBody, IOC.InjectForm<frmRelatorioHospitalar>()); 
        }

        private void btnEntradas_ItemClick(object sender, ItemClickEventArgs e)
        {
            IOC.InjectForm<frmTelaDocumento>().EfectuarOperacaoDocumento("ASE", "ABERTO");
        }

        private void btnSaidas_ItemClick(object sender, ItemClickEventArgs e)
        {
            IOC.InjectForm<frmTelaDocumento>().EfectuarOperacaoDocumento("ASS", "ABERTO");
        }

        private void btnRelatorioInventario_ItemClick(object sender, ItemClickEventArgs e)
        {
            UtilidadesGenericas.showFormInPanel(panelBody, IOC.InjectForm<frmRelatorioProdutos>());
        }

        private void barButtonItem9_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            IOC.InjectForm<frmDiasSemanas>().ShowDialog();

        }

        private void barButtonItem14_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmMotivoIsencao chamada = IOC.InjectForm<frmMotivoIsencao>();
            chamada.btnselect.Visibility = BarItemVisibility.Never;
            chamada.Show();

        }

        private void btnRelAdministracao_ItemClick(object sender, ItemClickEventArgs e)
        {
            UtilidadesGenericas.showFormInPanel(panelBody, IOC.InjectForm<frmVerRelatorioOperacoes>());
        }

        private void btnOutrosDocumentos_ItemClick(object sender, ItemClickEventArgs e)
        {
            UtilidadesGenericas.showFormInPanel(panelBody, IOC.InjectForm<frmVerTodosDocumentos>());
        }

        private void btnGerarSaft_ItemClick(object sender, ItemClickEventArgs e)
        {
            IOC.InjectForm<frmGerarSaft>().ShowDialog();
        }

        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (MessageBox.Show("Deseja realmente sair do sistema ?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) return;
            //this.Close();
        }

        private void btnTodosDoc_Inventario_ItemClick(object sender, ItemClickEventArgs e)
        {
            UtilidadesGenericas.showFormInPanel(panelBody, IOC.InjectForm<frmVerTodosDocumentos>());
        }

        private void btnTodosDoc_Hospitalar_ItemClick(object sender, ItemClickEventArgs e)
        {
            UtilidadesGenericas.showFormInPanel(panelBody, IOC.InjectForm<frmVerTodosDocumentos>());
        }

        private void btnTodosDoc_Admin_ItemClick(object sender, ItemClickEventArgs e)
        {
            UtilidadesGenericas.showFormInPanel(panelBody, IOC.InjectForm<frmVerTodosDocumentos>());
        }

        private void btnEstomos_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btnNomeEmpresa_ItemClick(object sender, ItemClickEventArgs e)
        {
            IOC.InjectForm<frmDadosEmpresa>().ShowDialog();

        }

        private void btnCondicoesPagamento_ItemClick(object sender, ItemClickEventArgs e)
        {
            UtilidadesGenericas.showFormInPanel(panelBody, IOC.InjectForm<frmCondicoesPagamento>());

        }

        private void btnDisciplina_ItemClick(object sender, ItemClickEventArgs e)
        {
            var container = new Container();
            IOC.RegistrarInjecao(container);
            container.GetInstance<frmDisciplina>().ShowDialog();
        }

        private void btnTurnoEscolar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Separadores.Gestao_Escolar.frmTurnoEscola chamada = new Separadores.Gestao_Escolar.frmTurnoEscola();
            chamada.ShowDialog();
        }

        private void Salas_ItemClick(object sender, ItemClickEventArgs e)
        {
            var container = new Container();
            IOC.RegistrarInjecao(container);
            container.GetInstance<frmSalas>().ShowDialog();
        }

        private void btnClasse_ItemClick(object sender, ItemClickEventArgs e)
        {
            Separadores.Gestao_Escolar.frmClasses chamada = new Separadores.Gestao_Escolar.frmClasses();
            chamada.ShowDialog();
        }

        private void btnTransportes_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmListaTransporte chamada = new Separadores.Gestao_Escolar.frmListaTransporte();
            chamada.ShowDialog();
        }

        private void btnConfigBackup_ItemClick(object sender, ItemClickEventArgs e)
        {
            
        }

        private void btnLote_ItemClick(object sender, ItemClickEventArgs e)
        {
         //   IOC.InjectForm<frmLotes>().ShowDialog();

        }

        private void btnConfigBackup_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            //configuração BackUp
            IOC.InjectForm<frmConfiguracoesBackup>().ShowDialog();

        }

        private void barButtonItem16_ItemClick(object sender, ItemClickEventArgs e)
        {
            UtilidadesGenericas.showFormInPanel(panelBody, IOC.InjectForm<frmLotesArtigo>());

        }

        private void btnEmpresas_ItemClick(object sender, ItemClickEventArgs e)
        {
            UtilidadesGenericas.showFormInPanel(panelBody, IOC.InjectForm<frmEmpresas>());

        }

        private void btnRelatorioCompra_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btnRelatorioVenda_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
    }
}