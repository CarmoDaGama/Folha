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
using Folha.Domain.ViewModels.Frame.Hospitalar;
using Folha.Domain.ViewModels.Hospitalar;
using Folha.Domain.Models.Hospitalar;
using Folha.Domain.Interfaces.Application.Hospitalar;
using Folha.Presentation.Desktop.Classe;
using Folha.Domain.Helpers;
using Folha.Domain.ViewModels.Report;
using Folha.Presentation.Desktop.Forms.Apresenta_Doc;
using Folha.Presentation.Desktop.Forms.Hispitalar;
using Folha.Domain.ViewModels.Frame.Entidades;
using Folha.Domain.Interfaces.Application.Entidades;
using Folha.Driver.Framework.IOC;
using Folha.Presentation.Desktop.Forms.Principal;

namespace Folha.Presentation.Desktop.Forms.Hospitalar
{
    public partial class frmRelDadosHospitalar : DevExpress.XtraEditors.XtraForm
    {
        
        string Titulo;
        string RelUsuario;
        private string codGruposanguineo;
        private List<Folha.Domain.ViewModels.Frame.Hospitalar.MedicosViewModel> LtMedicos;
        private List<PacienteViewModel> LtPacientes;
        private List<GrupoSanguineos> gruposSanguineos;
        private List<AtendimentoHospitalarViewModel> LtAtendimentoHospitalar; 
        private List<AtendimentoHospitalarGraficViewModel> LtAtendimentoHospitalarGrafic;
        private List<PacienteInternado> LtPacienteInternado;
        private List<Laboratorio> LtLaboratorios;
        private List<ConsultaHospitalarViewModel> LtConsultorios;
        private List<TriagemViewModel> LtTiagem;
      
        private DadosReportViewModel dadosReport;

        private readonly ITriagemApp _TriagemApp;
        private readonly IPacienteApp _PacienteApp;
        private readonly IMedicosApp _MedicosApp;
        private readonly IAtendimentoHospitalarApp _AtendimentoHospitalarApp;
        private readonly IInternamentoApp _InternametoApp;
        private readonly IExamesHospitalarApp _ExamesHospitalarApp;
        private readonly ILaboratorioApp _labApp;
        private readonly IEntidadesApp _EntidadesApp;
        private readonly IConsultaHospitalarApp _IConsultaHospitalarApp;
        private DateTime inicio;
        private DateTime termino;
        string NomeRelatorio;
        int codEntidade;

        private AllEntidadeViewModel AllEntidade;

        public frmRelDadosHospitalar(IPacienteApp PacienteApp, IMedicosApp MedicosApp, IAtendimentoHospitalarApp AtendimentoHospitalarApp, IInternamentoApp InternametoApp, IConsultaHospitalarApp IConsultaHospitalarApp, IExamesHospitalarApp ExamesHospitalarApp, ILaboratorioApp labApp, ITriagemApp TriagemApp , IEntidadesApp EntidadesApp)
        {
            InitializeComponent();

            _PacienteApp = PacienteApp;
            _MedicosApp = MedicosApp;
            _AtendimentoHospitalarApp = AtendimentoHospitalarApp;
            _InternametoApp = InternametoApp;
            _IConsultaHospitalarApp = IConsultaHospitalarApp;
            _ExamesHospitalarApp = ExamesHospitalarApp;
            _labApp = labApp;
            _TriagemApp = TriagemApp;
            _EntidadesApp = EntidadesApp;
        }

        private void ValidacaoDosCamposHospitalar()
        {
            RelUsuario = UtilidadesGenericas.UsuarioCodigo + " - " + UtilidadesGenericas.NomeUsuario;
        }
        private void RecebeData()
        {
            inicio = DateTime.Parse(dtInicio.Text);
            termino = DateTime.Parse(dtFim.Text);
        }
        #region Regiao
        private void BuscarTriagem()
        {

            RecebeData();
            if (cboFiltar.Text == "Todos")
                LtTiagem = (List<TriagemViewModel>)_TriagemApp.ListarComFiltro(inicio.ToString("yyyy-MM-dd"), termino.ToString("yyyy-MM-dd"), int.Parse(txtCodPaciente.Text));
            else if (cboFiltar.Text == "Filtrar")
            {
                LtTiagem = (List<TriagemViewModel>)_TriagemApp.ListarComFiltro(null, null, int.Parse(txtCodPaciente.Text));
                DataViewModel data = _TriagemApp.RetornaDataTriagem(int.Parse(txtCodPaciente.Text));
                inicio = data.DataInicial;
                termino = data.DataFinal;
            }
            if (UtilidadesGenericas.ListaNula(LtTiagem))
            {
                UtilidadesGenericas.MsgShow("Sem Relatório!");
                return;
            }
            string RelUsuario = UtilidadesGenericas.UsuarioCodigo + " - " + UtilidadesGenericas.NomeUsuario;
            DadosReportViewModel dados = new DadosReportViewModel() { Usuario = RelUsuario, DataInicio = inicio, DataFim = termino };
            AllEntidade = _EntidadesApp.ListEntidadeGetAll(codEntidade.ToString());

            if (AllEntidade.Codigo != 0)
                new frmApresentaReport().ApresentarReportTriagem(LtTiagem, dados, new AllEntidadeViewModel() { Nome = txtPaciente.Text, Sexo = AllEntidade.Sexo, EstadoCivil = AllEntidade.EstadoCivil, DataNascimento = AllEntidade.DataNascimento });

        }
        #endregion
        private void btnImprimir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            #region Condições dos botões Hospitalar (TODOS)
            if (cboFiltar.SelectedIndex==1)
            {
                ImprimirDadosFiltrados();
            }
            else {
                RecebeData();
                if (Titulo == "Médicos")
                {
                    ValidacaoDosCamposHospitalar();
                    dadosReport = new DadosReportViewModel() { Usuario = RelUsuario };
                    LtMedicos = (List<Folha.Domain.ViewModels.Frame.Hospitalar.MedicosViewModel>)_MedicosApp.ListarMedicoFiltrado(null);
                    if (LtMedicos.Count != 0)
                        new frmApresentaReport().ApresentarReportMedicos(LtMedicos, dadosReport);
                    else
                        MessageBox.Show("Não tem nunhum dados.", "Aviso",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                if (Titulo == "Pacientes")
                {
                    ValidacaoDosCamposHospitalar();
                    dadosReport = new DadosReportViewModel() { Usuario = RelUsuario };
                    LtPacientes = _PacienteApp.GetAll(null);

                    if (LtPacientes.Count != 0)
                        new frmApresentaReport().ApresentarReportPacientes(LtPacientes, dadosReport);
                    else
                        MessageBox.Show("Não tem nunhum dados.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (Titulo == "Atendimentos")
                {
                    ValidacaoDosCamposHospitalar();
                    dadosReport = new DadosReportViewModel() { Usuario = RelUsuario, DataInicio = inicio, DataFim = termino, Caixa = cboFiltar.Text };
                    LtAtendimentoHospitalar = (List<AtendimentoHospitalarViewModel>)_AtendimentoHospitalarApp.ListarAtendimentosSemFiltro();

                    if (LtAtendimentoHospitalar.Count != 0)
                        new frmApresentaReport().ApresentarReportAtendimentos(LtAtendimentoHospitalar, dadosReport);
                    else
                        MessageBox.Show("Não tem nunhum dados.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (Titulo == "Internamentos")
                {
                    ValidacaoDosCamposHospitalar();
                    dadosReport = new DadosReportViewModel() { Usuario = RelUsuario, DataInicio = inicio, DataFim = termino, Caixa = cboFiltar.Text };
                    LtPacienteInternado = (List<PacienteInternado>)_AtendimentoHospitalarApp.ListarInternadoSemFiltro();

                    if (LtPacienteInternado.Count != 0)
                        new frmApresentaReport().ApresentarReportPacienteInternado(LtPacienteInternado, dadosReport);
                    else
                        MessageBox.Show("Não tem nunhum dados.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (Titulo == "Laboratórios")
                {
                    ValidacaoDosCamposHospitalar();
                    dadosReport = new DadosReportViewModel() { Usuario = RelUsuario, DataInicio = inicio, DataFim = termino, Caixa = cboFiltar.Text };
                    LtLaboratorios = (List<Laboratorio>)_labApp.Listar(null, false);

                    if (LtLaboratorios.Count != 0)
                        new frmApresentaReport().ApresentarReportLaboratorios(LtLaboratorios, dadosReport);
                    else
                        MessageBox.Show("Não tem nunhum dados.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (Titulo == "Consultorios")
                {
                    ValidacaoDosCamposHospitalar();
                    dadosReport = new DadosReportViewModel() { Usuario = RelUsuario, DataInicio = inicio, DataFim = termino, Caixa = cboFiltar.Text };

                    LtConsultorios = (List<ConsultaHospitalarViewModel>)(List<ConsultaHospitalarViewModel>)_IConsultaHospitalarApp.ListarSemFiltro();
                    if (LtConsultorios.Count == 0)
                        MessageBox.Show("Não tem nunhum dados.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else new frmApresentaReport().ApresentarReportConsultaHospitalar(LtConsultorios, dadosReport);

                }
                if (Titulo == "Triagem")
                {
                    if (string.IsNullOrEmpty(txtCodPaciente.Text) && string.IsNullOrEmpty(txtPaciente.Text)) { MessageBox.Show("Selecione o Paciente", "Relatório Hospitalar", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                    BuscarTriagem();
                }
            }
            //Imprimir Graficos
            if (Titulo == "Gráfico Atendimentos")
            {
                //ValidacaoDosCamposHospitalar();
                //RecebeData();
                //dadosReport = new DadosReportViewModel() { Usuario = RelUsuario, DataInicio= inicio, DataFim= termino };
                //LtAtendimentoHospitalarGrafic = (List<AtendimentoHospitalarGraficViewModel>)_AtendimentoHospitalarApp.TotalAtendimento(inicio.ToString("yyyy-MM-dd"), termino.ToString("yyyy-MM-dd"), ckFacturado.Checked);
                //new frmApresentaReport().ApresentarReportGrafAtendimento(LtAtendimentoHospitalarGrafic, dadosReport);
            }
            
            #endregion
        }
        private void ImprimirDadosFiltrados()
        {
            RecebeData();
            if (Titulo == "Médicos")
            {
                ValidacaoDosCamposHospitalar();
                dadosReport = new DadosReportViewModel() { Usuario = RelUsuario };
                LtMedicos = (List<Folha.Domain.ViewModels.Frame.Hospitalar.MedicosViewModel>)_MedicosApp.ListarMedicoFiltrado(txtEspecialidade.Text);
                
                if (txtEspecialidade.Text != "")
                {
                    if (LtMedicos.Count != 0)
                        new frmApresentaReport().ApresentarReportMedicos(LtMedicos, dadosReport);
                    else MessageBox.Show("Não tem nunhum dados.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
               else { MessageBox.Show("Selecione uma especialidade.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                
            }
            if (Titulo == "Pacientes")
            {
                ValidacaoDosCamposHospitalar();
                dadosReport = new DadosReportViewModel() { Usuario = RelUsuario };
                LtPacientes = _PacienteApp.RetornaGrupoSPaciente(cboAterarDados.Text);
                
                if (cboAterarDados.Text != "")
                {
                    if (LtPacientes.Count != 0)
                        new frmApresentaReport().ApresentarReportPacientes(LtPacientes, dadosReport);
                    else MessageBox.Show("Não tem nunhum dados.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
              else { MessageBox.Show("Selecione um grupo sanguineo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                
            }
            if (Titulo == "Atendimentos")
            {
                ValidacaoDosCamposHospitalar();
                dadosReport = new DadosReportViewModel() { Usuario = RelUsuario, DataInicio = inicio, DataFim = termino , Caixa = cboFiltar.Text};
                LtAtendimentoHospitalar = (List<AtendimentoHospitalarViewModel>)_AtendimentoHospitalarApp.ListarAtendimentosComFiltro(cboFacturado.Text,inicio.ToString("yyyy-MM-dd"), termino.ToString("yyyy-MM-dd"));

                if (LtAtendimentoHospitalar.Count != 0)
                    new frmApresentaReport().ApresentarReportAtendimentos(LtAtendimentoHospitalar, dadosReport);
                else MessageBox.Show("Não tem nunhum dados.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (Titulo == "Internamentos")
            {
                ValidacaoDosCamposHospitalar();
                dadosReport = new DadosReportViewModel() { Usuario = RelUsuario, DataInicio = inicio, DataFim = termino, Caixa = cboFiltar.Text };
                
                if (cboAterarDados.Text == "Nenhum")
                {
                    //Data
                    LtPacienteInternado = (List<PacienteInternado>)(List<PacienteInternado>)_AtendimentoHospitalarApp.FiltrarPacienteInternado(cboAterarDados.Text, inicio.ToString("yyyy-MM-dd"), termino.ToString("yyyy-MM-dd"));
                    if (LtPacienteInternado.Count == 0)
                        MessageBox.Show("Não tem nunhum dados.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else new frmApresentaReport().ApresentarReportPacienteInternado(LtPacienteInternado, dadosReport);
                }
                else
                {
                    //Estado
                    LtPacienteInternado = (List<PacienteInternado>)_AtendimentoHospitalarApp.FiltrarPacienteInternado(cboAterarDados.Text, cboAterarDados.Text, null);
                    if (LtPacienteInternado.Count == 0)
                        MessageBox.Show("Não tem nunhum dados.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else new frmApresentaReport().ApresentarReportPacienteInternado(LtPacienteInternado, dadosReport);
                }
                
            }
            if (Titulo == "Laboratórios")
            {
                ValidacaoDosCamposHospitalar();
                dadosReport = new DadosReportViewModel() { Usuario = RelUsuario, DataInicio = inicio, DataFim = termino, Caixa = cboFiltar.Text };
                
                if (cboAterarDados.Text == "Nenhum")
                {
                    //Data
                    LtLaboratorios = (List<Laboratorio>)_labApp.FiltrarLaboratorioEstadoData(cboAterarDados.Text, inicio.ToString("yyyy-MM-dd"), termino.ToString("yyyy-MM-dd"));
                    if (LtLaboratorios.Count==0)
                        MessageBox.Show("Não tem nunhum dados.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else new frmApresentaReport().ApresentarReportLaboratorios(LtLaboratorios, dadosReport);
                }
                else
                {
                    //Estado
                    LtLaboratorios = (List<Laboratorio>)_labApp.FiltrarLaboratorioEstadoData(cboAterarDados.Text, cboAterarDados.Text, null);
                    if (LtLaboratorios.Count==0)
                        MessageBox.Show("Não tem nunhum dados.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else new frmApresentaReport().ApresentarReportLaboratorios(LtLaboratorios, dadosReport);
                }
            }
            if (Titulo == "Consultorios")
            {
                ValidacaoDosCamposHospitalar();
                dadosReport = new DadosReportViewModel() { Usuario = RelUsuario, DataInicio = inicio, DataFim = termino, Caixa = cboFiltar.Text };

                LtConsultorios = (List<ConsultaHospitalarViewModel>)(List<ConsultaHospitalarViewModel>)_IConsultaHospitalarApp.ListarComFiltro(cboFacturado.Text, inicio.ToString("yyyy-MM-dd"), termino.ToString("yyyy-MM-dd"));
                if (LtConsultorios.Count == 0)
                    MessageBox.Show("Não tem nunhum dados.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else new frmApresentaReport().ApresentarReportConsultaHospitalar(LtConsultorios, dadosReport);
              
            }
            if (Titulo == "Triagem")
            {
                if (string.IsNullOrEmpty(txtCodPaciente.Text) && string.IsNullOrEmpty(txtPaciente.Text)) { MessageBox.Show("Selecione o Paciente", "Relatório Hospitalar", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                BuscarTriagem();
            }
        }
        public string LevarValor(string titulo)
        {
            Titulo = titulo;
            return titulo;
        }

        private void btnVoltar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OcultarCampos();
            Close();
        }

        private void cboFiltar_SelectedIndexChanged(object sender, EventArgs e)
        {
            Responsividade();
            TriagemLocacion();
            if (cboFiltar.Text == "Todos")
            {
                OcultarCampos();
            }
            else
            {
                FiltrarOsCamposVisivel();
            }
        }
        #region Filtrar os campos ====================================================================================
        private void Invisiblidade()
        {
            lbDtInicial.Visible = false;
            dtInicio.Visible = false;
            lbDtFinal.Visible = false;
            dtFim.Visible = false;

            lblPaciente.Visible = false;
            txtCodPaciente.Visible = false;
            txtPaciente.Visible = false;
            btnPaciente.Visible = false;
        }
        private void FiltrarOsCamposVisivel()
        {
            if (Titulo == "Médicos")
            {
                sbtnEspecialidade.Visible = true;
                txtCodEspecialidade.Visible = true;
                txtEspecialidade.Visible = true;
                lblEspecialidade.Visible = true;
            }
            if (Titulo == "Pacientes")
            {
                lbAterarDados.Visible = true;
                lbAterarDados.Text = "Grupo Sanguíneo:";
                cboAterarDados.Visible = true;
            }
            if (Titulo == "Atendimentos")
            {
                lbDtInicial.Visible = true;
                dtInicio.Visible = true;
                lbDtFinal.Visible = true;
                dtFim.Visible = true;

                lblFacturado.Visible = true;
                lblFacturado.Text = "Facturado:";
                cboFacturado.Visible = true;
            }
           if (Titulo == "Laboratórios" || Titulo == "Internamentos")
            {
                lbDtInicial.Visible = true;
                dtInicio.Visible = true;
                lbDtFinal.Visible = true;
                dtFim.Visible = true;
                //Paciente
                lbAterarDados.Visible = true;
                lbAterarDados.Text = "Estado:";
                if(!cboAterarDados.Properties.Items.Contains("Nenhum"))
                cboAterarDados.Properties.Items.Add("Nenhum");
                cboAterarDados.SelectedItem = "Nenhum";
                cboAterarDados.Visible = true;
            }
            if (Titulo == "Consultorios")
            {
                lbDtInicial.Visible = true;
                dtInicio.Visible = true;
                lbDtFinal.Visible = true;
                dtFim.Visible = true;

                lblFacturado.Visible = true;
                lblFacturado.Text = "Atendido:";
                cboFacturado.Visible = true;
            }
            if (Titulo == "Triagem")
            {
                lbDtInicial.Visible = false;
                dtInicio.Visible = false;
                lbDtFinal.Visible = false;
                dtFim.Visible = false;

                lblPaciente.Visible = true;
                txtCodPaciente.Visible = true;
                txtPaciente.Visible = true;
                btnPaciente.Visible = true;
            }
        }
        private void OcultarCampos()
        {
            if (Titulo == "Médicos")
            {
                Invisiblidade();
                sbtnEspecialidade.Visible = false;
                txtCodEspecialidade.Visible = false;
                txtEspecialidade.Visible = false;
                lblEspecialidade.Visible = false;
            }
            if (Titulo == "Pacientes")
            {
                Invisiblidade();
                lbAterarDados.Visible = false;
                lbAterarDados.Text = "Grupo Sanguíneo:";
                cboAterarDados.Visible = false;
            }
            if (Titulo == "Atendimentos")
            {
                Invisiblidade();
                lbDtInicial.Visible = false;
                dtInicio.Visible = false;
                lbDtFinal.Visible = false;
                dtFim.Visible = false;

                lblFacturado.Visible = false;
                lblFacturado.Text = "Facturado:";
                cboFacturado.Visible = false;
            }
            if (Titulo == "Laboratórios" || Titulo == "Internamentos")
            {
                Invisiblidade();
                lbDtInicial.Visible = false;
                dtInicio.Visible = false;
                lbDtFinal.Visible = false;
                dtFim.Visible = false;
                //Paciente
                lbAterarDados.Visible = false;
                lbAterarDados.Text = "Estado:";
                cboAterarDados.SelectedIndex = 0;
                cboAterarDados.Visible = false;
            }
            if (Titulo == "Consultorios")
            {
                Invisiblidade();
                lbDtInicial.Visible = false;
                dtInicio.Visible = false;
                lbDtFinal.Visible = false;
                dtFim.Visible = false;

                lblFacturado.Visible = false;
                lblFacturado.Text = "Atendido:";
                cboFacturado.Visible = false;
            }
            if (Titulo == "Triagem")
            {
                lbDtInicial.Visible = true;
                dtInicio.Visible = true;
                lbDtFinal.Visible = true;
                dtFim.Visible = true;

                lblPaciente.Visible = true;
                txtCodPaciente.Visible = true;
                txtPaciente.Visible = true;
                btnPaciente.Visible = true;
            }
        }

        #endregion ====================================================================================

        private void frmRelDadosHospitalar_Load(object sender, EventArgs e)
        {
            cboFiltar.SelectedIndex = 0;
            OcultarCampos();

            dtInicio.EditValue = DateTime.Today;
            dtFim.EditValue = DateTime.Today;
            dtInicio.Properties.MaxValue = DateTime.Now;
            dtFim.Properties.MaxValue = DateTime.Now;
           
            Responsividade();
            TriagemLocacion();
            if (Titulo== "Pacientes" || Titulo == "Laboratórios")
            {
                carregarDados();
            }
            else
            {
                cboAterarDados.Properties.Items.Clear();
            }
            if (Titulo == "Triagem")
            {
                btnPaciente.Visible = true;
            }
            if (Titulo == "") { lblAlteracaoTitulo.Text = "Filtragem De Dados (Relatório)"; } else { lblAlteracaoTitulo.Text = Titulo; }
        }
        private void TriagemLocacion()
        {
            if (Titulo == "Triagem")
            {
                lblPaciente.Location = new System.Drawing.Point(4, 106);
                txtCodPaciente.Location = new System.Drawing.Point(121, 103);
                txtPaciente.Location = new System.Drawing.Point(174, 103);
                btnPaciente.Location = new System.Drawing.Point(477, 103);
                Size = new System.Drawing.Size(512, 169);
            }
        }
        private void Responsividade()
        {
            if (cboFiltar.SelectedIndex != 0)
            {
                if (Titulo == "Médicos")
                {
                    lblEspecialidade.Location = new System.Drawing.Point(6, 81);
                    txtCodEspecialidade.Location = new System.Drawing.Point(123, 80);
                    txtEspecialidade.Location = new System.Drawing.Point(176, 80);
                    sbtnEspecialidade.Location = new System.Drawing.Point(481, 80);
                    Size = new System.Drawing.Size(512, 145);
                }
                if (Titulo == "Pacientes")
                {
                    lbAterarDados.Location = new System.Drawing.Point(4, 78);
                    cboAterarDados.Location = new System.Drawing.Point(121, 73);
                    Size = new System.Drawing.Size(512, 139);
                }
                if (Titulo == "Atendimentos" || Titulo == "Consultorios")
                {
                    lblFacturado.Location = new System.Drawing.Point(335, 105);
                    cboFacturado.Location = new System.Drawing.Point(411, 101);
                    Size = new System.Drawing.Size(512, 167);
                }
                if (Titulo == "Laboratórios" || Titulo == "Internamentos")
                {
                    lbAterarDados.Location = new System.Drawing.Point(4, 106);
                    cboAterarDados.Location = new System.Drawing.Point(121, 101);
                    Size = new System.Drawing.Size(512, 167);
                }
            }
            else
            {
                Size = new System.Drawing.Size(518, 99);
            }
            
        }
        
        private void cboAterarDados_SelectedIndexChanged(object sender, EventArgs e)
        {
            //codGruposanguineo = gruposSanguineos[cboAterarDados.SelectedIndex].Descricao;
            //valor = cboAterarDados.Text;
        }

        private void carregarDados()
        {
            cboAterarDados.Properties.Items.Clear();
            if (Titulo == "Pacientes")
            {
                List<GrupoSanguineos> GSanguineo = _PacienteApp.ListarGrupoSanguineo(null);

                foreach (var item in GSanguineo)
                {
                    cboAterarDados.Properties.Items.Add( item.Descricao);
                }
            }
            if (Titulo == "Laboratórios")
            {
                List<Laboratorio> LtLaboratorioCb = (List<Laboratorio>)_labApp.Listar(null, false);

                foreach (var item in LtLaboratorioCb)
                {
                    cboAterarDados.Properties.Items.Add(item.Estado);
                }
            }
            if (Titulo == "Internamentos")
            {
                LtPacienteInternado = (List<PacienteInternado>)_InternametoApp.ListarTudo(null);

                foreach (var item in LtPacienteInternado)
                {
                    cboAterarDados.Properties.Items.Add(item.Estado);
                }
            }

        }

        private void ckFacturado_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnPaciente_Click(object sender, EventArgs e)
        {
            var formPacientes = IOC.InjectForm<frmPacientes>();
            formPacientes.btnSelecionar.Enabled = true;
            formPacientes.ShowDialog();
            if (formPacientes.DadosPaciente.Codigo == 0) return;
            txtCodPaciente.Text = formPacientes.DadosPaciente.Codigo.ToString();
            txtPaciente.Text = formPacientes.DadosPaciente.Nome;
            codEntidade = formPacientes.DadosPaciente.CodEntidade;
        }

        private void sbtnEspecialidade_Click(object sender, EventArgs e)
        {
            var especialidade = IOC.InjectForm<frmInteligente>().GetSelecionado<Especialidades>("Especialidades", "Especialidades");
            if (Equals(especialidade, null))
            {
                return;
            }
            txtCodEspecialidade.Text = especialidade.Codigo.ToString();
            txtEspecialidade.Text = especialidade.Descricao;
        }

        private void dtInicio_EditValueChanged(object sender, EventArgs e)
        {
            if (Titulo == "Laboratórios")
            {
                cboAterarDados.Text = "Nenhum";
            }
        }

        private void dtFim_EditValueChanged(object sender, EventArgs e)
        {
            if (Titulo == "Laboratórios")
            {
                cboAterarDados.Text = "Nenhum";
            }
        }
    }
}