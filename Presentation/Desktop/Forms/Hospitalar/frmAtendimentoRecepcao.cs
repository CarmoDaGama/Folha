using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraGrid.Views.Grid;
using Folha.Domain.Interfaces.Application.Entidades;
using Folha.Domain.Interfaces.Application.Genericos;
using Folha.Domain.Interfaces.Application.Hospitalar;
using Folha.Domain.Models.Hospitalar;
using Folha.Domain.ViewModels.Hospitalar;
using Folha.Domain.ViewModels.Report;
using Folha.Domain.Helpers;
using Folha.Driver.Framework.IOC;
using Folha.Domain.ViewModels.Frame.Entidades;
using Folha.Domain.ViewModels.Frame.Hospitalar;
using Folha.Presentation.Desktop.Forms.Apresenta_Doc;
using Folha.Presentation.Desktop.Forms.Hispitalar;
using Folha.Presentation.Desktop.Forms.Principal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Folha.Presentation.Desktop.Forms.Hospitalar
{
    public partial class frmAtendimentoRecepcao : RibbonForm
    {
        private readonly IEntidadesApp _EntidadesApp;
        private AllEntidadeViewModel AllEntidade;
        private readonly ITriagemApp _TriagemApp;
        List<TipoConsultas> LtTipoConsultas = new List<TipoConsultas>();
        List<FarmacoReceitaViewModel> LtFarmacoReceita = new List<FarmacoReceitaViewModel>();
        List<ExamesViewModel> LtExamesAtendimento = new List<ExamesViewModel> ();
        List<ReceitasViewModel> LtReceitas = new List<ReceitasViewModel>();
        List<MarcacaoConsultaViewModel> LtConsultas = new List<MarcacaoConsultaViewModel>();
        List<MarcacaoConsultaViewModel> ListaConsultasNova = new List<MarcacaoConsultaViewModel>();
        PacienteViewModel DadosPaciente { get; set; }
        List<TriagemViewModel> LtTiagem;
        private readonly IReceitasApp _ReceitasApp;
        private int codPaciente;
        private int codMedico;
        private int codConsulta;
        private readonly IAtendimentoHospitalarApp _AtendimentoHospitalarApp;
        private int LastCodTriagem;
        private int LastCodConsultorio;
        private int LastCodReceita;
        private int LastCodAtendimento;
        public int codAtendimento { get; set; }
        private readonly IExamesHospitalarApp _ExamesApp;
        List<AtendimentoHospitalarViewModel> LtAtendimento = new List<AtendimentoHospitalarViewModel>();
        private int codEntidade;
        private readonly IConsultaHospitalarApp _ConsultaHospitalarApp;
        private int codTipoConsulta;
        private int LastCodConsulta;
        private int indexGridExames=-1;
        private int indexGridReceitas=-1;
        private bool Editar = false;
        private int codReceita;
        private int indexGridConsulta=-1;
        private string GrupoDescricao;
        private IPacienteApp _PacienteApp;
        private bool EstadoRecepcao { get; set; }
        int usuario = int.Parse(UtilidadesGenericas.UsuarioPerfil.ToString());
        private int codAtendimentoNovo;
        private IGenericoApp _GenericoApp;

        private PacienteViewModel PacienteConsulta { get; set; } = null;
        private List<AtendimentoDocViewModel> ListaDocumentos { get; set; }
        private int IndexDocumento { get; set; }
        private List<ItemAtendimentoFacturaViewModel> ItensFactura { get; set; }
        private List<ItemAtendimentoFacturaViewModel> BackItensFactura { get; set; }
        private MarcacaoConsultaViewModel ConsultaMedicoReceitou { get; set; }
        public int CodConsultaNovo { get; private set; }
        public int CodMedicoNovo { get; private set; }
        public int CodPacienteNovo { get; private set; }

        public frmAtendimentoRecepcao(
            IEntidadesApp EntidadesApp, 
            ITriagemApp TriagemApp,
            IReceitasApp ReceitasApp, 
            IAtendimentoHospitalarApp AtendimentoApp, 
            IExamesHospitalarApp ExamesApp,
            IConsultaHospitalarApp ConsultaHospitalarApp,
            IPacienteApp PacienteApp,
            IGenericoApp GenericoApp)
        {
            InitializeComponent();
            _EntidadesApp = EntidadesApp;
            _TriagemApp = TriagemApp;
            _ReceitasApp = ReceitasApp;
            _AtendimentoHospitalarApp = AtendimentoApp;
            _ExamesApp = ExamesApp;
            _ConsultaHospitalarApp = ConsultaHospitalarApp;
            _PacienteApp = PacienteApp;
            _GenericoApp = GenericoApp;
            navigationItenamento.SelectedPage = navigationPage_Paciente;
            Permicao();
        }
        #region Permicao de Acesso
        private void Permicao()
        {
            if (usuario != 1)
            {
                if (UtilidadesGenericas.TemAcesso("Hospitalar#Atendimento#Triagem") == false) { btnTriagem.Visible = false; }
                if (UtilidadesGenericas.TemAcesso("Hospitalar#Atendimento#Consulta") == false) { btnConsultas.Visible = false; }
                if (UtilidadesGenericas.TemAcesso("Hospitalar#Atendimento#Exames") == false) { btnExames.Visible = false; }
                if (UtilidadesGenericas.TemAcesso("Hospitalar#Atendimento#Internamento") == false) { btnIntenamento.Visible = false; }
                if (UtilidadesGenericas.TemAcesso("Hospitalar#Atendimento#Receitas") == false) { btnReceitas.Visible = false; }
                if (UtilidadesGenericas.TemAcesso("Hospitalar#Atendimento#Facturação") == false) { btnDocumento.Visible = false; }
                if (UtilidadesGenericas.TemAcesso("Hospitalar#Atendimento#Consultar") == false) { btnConsultar.Visible = false; }
                if (UtilidadesGenericas.TemAcesso("Hospitalar#Atendimento#Fechar Recepção") == false) { btnFecharRecepcao.Visibility = BarItemVisibility.Never; }

                //Consultar 
                if (UtilidadesGenericas.TemAcesso("Hospitalar#Atendimento#Consulta#Criar") == false) { btnNovaConsulta.Enabled = false; }
                if (UtilidadesGenericas.TemAcesso("Hospitalar#Atendimento#Consulta#Eliminar") == false) { btnDeleteConsulta.Enabled = false; }

                //Exames 
                if (UtilidadesGenericas.TemAcesso("Hospitalar#Atendimento#Exames#Criar") == false) { btnNovoExame.Enabled = false; }
                if (UtilidadesGenericas.TemAcesso("Hospitalar#Atendimento#Exames#Eliminar") == false) { btnDeleteExame.Enabled = false; }


                //Receita 
                if (UtilidadesGenericas.TemAcesso("Hospitalar#Atendimento#Receitas#Criar") == false) { btnNovaReceita.Enabled = false; }
                if (UtilidadesGenericas.TemAcesso("Hospitalar#Atendimento#Receitas#Eliminar") == false) { btnDeleteFarmaco.Enabled = false; }

                ////Consultar 
                //if (UtilidadesGenericas.TemAcesso("Hospitalar#Atendimento#Consultar#Criar") == false) { btnConsultar.Enabled = false; }


            }

        }
        #endregion
 
        //Carregamentos--------------------------------------------------------------------------------
        private void CarregaCampos(string CodEntidade)
        {
            if(Editar)
            btnNome.Enabled = false;
            GrupoDescricao = _PacienteApp.RetornaGrupoSanguines(codPaciente.ToString());
            txtGrupoSanguineo.Text = GrupoDescricao;
            AllEntidade = _EntidadesApp.ListEntidadeGetAll(CodEntidade);        
            txtCodPaciente1.Text = codPaciente.ToString();
            txtNomePaciente1.Text = AllEntidade.Nome;
            txtNomePaciente2.Text = AllEntidade.Nome;
            txtPai.Text = AllEntidade.NomePai;
            txtNif.Text = AllEntidade.Nif;
            dateNascimento.EditValue = AllEntidade.DataNascimento;
            txtIdade.Text = (DateTime.Now.Year - Convert.ToDateTime(AllEntidade.DataNascimento.ToString()).Year).ToString();
            txtNacionalidade.Text = AllEntidade.Nacionalidade;
            cboSexo.SelectedItem = AllEntidade.Sexo;
            cboEstadoCivil.SelectedItem = AllEntidade.EstadoCivil;
            txtHabilitacao.Text = AllEntidade.Habilitacao;
            txtPai.Text = AllEntidade.NomePai;
            txtMae.Text = AllEntidade.NomeMae;
            txtProfissao.Text = AllEntidade.Profissao;

            try
            {
                PicFoto1.Image = Imagens.Byte_Imagem(AllEntidade.Foto);
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void CarregaTriagem()
        {
            LtTiagem = (List<TriagemViewModel>)_TriagemApp.Listar(codAtendimento.ToString());
            if (!UtilidadesGenericas.ListaNula(LtTiagem))
            {
                txtTemperatura.Text = LtTiagem[0].Temperatura.ToString("N2");
                txtTensaoArterial.Text = LtTiagem[0].TemperaturaArterial.ToString();
                txtPeso.Text = LtTiagem[0].Peso.ToString("N2");
                txtFrRespiratoria.Text = LtTiagem[0].FrequenciaRespiratoria.ToString("N2");
                txtFrCardiaca.Text = LtTiagem[0].FrequenciaCardiaca.ToString("N2");
                txtIdade.Text = (DateTime.Now.Year - Convert.ToDateTime(AllEntidade.DataNascimento.ToString()).Year).ToString();
                LastCodTriagem = LtTiagem[0].Codigo;
            }
            else
            {
                return;
            }
        }
        private void CarregaExames()
        {
            LtExamesAtendimento = new List<ExamesViewModel>();
            LtExamesAtendimento = (List <ExamesViewModel> )_ExamesApp.ListarAtendimento(LtAtendimento[0].Codigo.ToString());
            gradeExames.DataSource = null;
            gradeExames.DataSource = LtExamesAtendimento;
        }
        private void CarregaReceitas()
        {
            if (string.IsNullOrEmpty(UtilidadesGenericas.Busca.CodigoConsultaNova))
            {
                return;
            }
            CodConsultaNovo = int.Parse(UtilidadesGenericas.Busca.CodigoConsultaNova);
            gradeReceitas.DataSource = null;
           gradeReceitas.DataSource=LtFarmacoReceita=(List<FarmacoReceitaViewModel>) _ReceitasApp.CarregaFarmacos(CodConsultaNovo.ToString());
            

            LtReceitas = _ReceitasApp.ListaReceita(CodConsultaNovo.ToString());
            if (!UtilidadesGenericas.ListaNula(LtReceitas))
            {
                txtObservacao.Text = LtReceitas[0].Observacao;
                codReceita = LtReceitas[0].Codigo;
                LastCodReceita = codReceita;
                ConsultaMedicoReceitou = new MarcacaoConsultaViewModel()
                {
                    CodMedico = LtReceitas[0].CodMedico,
                    Medico = LtReceitas[0].NomeMedico,
                    TipoConsulta = LtReceitas[0].TipoConsulta,
                    Codigo = LtReceitas[0].CodConsulta,
                    Atendido = LtReceitas[0].Atendido
                };

                codConsulta = LtReceitas[0].CodConsulta;
                codMedico = LtReceitas[0].CodMedico;
                txtTipoConsulta.Text = ConsultaMedicoReceitou.TipoConsulta;
                if (ConsultaMedicoReceitou.Atendido != "Não")
                {
                    btnDeleteFarmaco.Enabled = false;
                    btnNovaReceita.Enabled = false;
                    gradeReceitas.Enabled = false;
                }
            }
        }
        private void CarregaConsultas()
        {
            gradeConsultas.DataSource = null;
            gradeConsultas.DataSource = _ConsultaHospitalarApp.ListConsultaMarcadas(LtAtendimento[0].Codigo.ToString());
            LtConsultas = (List<MarcacaoConsultaViewModel>) _ConsultaHospitalarApp.ListConsultaMarcadas(LtAtendimento[0].Codigo.ToString());
        }

        private void CarregaConultorio()
        {
            if (string.IsNullOrEmpty(UtilidadesGenericas.Busca.CodigoConsultaNova))
            {
                return;
            }
            CodConsultaNovo = int.Parse(UtilidadesGenericas.Busca.CodigoConsultaNova);

            ListaConsultasNova = (List<MarcacaoConsultaViewModel>)_ConsultaHospitalarApp.ListConsultaIndividual(CodConsultaNovo.ToString());
            if (!UtilidadesGenericas.ListaNula(ListaConsultasNova))
            {
                txtAnaminizes.Text = ListaConsultasNova[0].Anaminizes;
                txtQueixasPrincipal.Text = ListaConsultasNova[0].QueixaPrincipal;
                txtEvolucao.Text = ListaConsultasNova[0].EvolucaoTratamento;
                LastCodAtendimento = ListaConsultasNova[0].Codigo;
            }
            else
            {
                return;
            }
        }
        //Gravar------------------------------------------------------------
        private void GravarAtentimento()
        {
            _AtendimentoHospitalarApp.Insert(new AtendimentoHospitalar()
            {
                CodPaciente = codPaciente,
                Data = DateTime.Now.Date,
                Facturado = "Não",
                status = 1,
                CodTipoConsulta = codTipoConsulta,
                CodUsuario = UtilidadesGenericas.UsuarioCodigo

            });

            LastCodAtendimento = _GenericoApp.LastCodGeral("AtendimentoHospitalar");
            codAtendimento = LastCodAtendimento;
            LastCodConsulta= _GenericoApp.LastCodGeral("ConsultaHospitalar");

        }
        private void GravarTriagem()
        {
            //var triagem = new Triagem()
            //{
            //    Codigo = LastCodTriagem,
            //    CodPaciente = int.Parse(txtCodPaciente1.Text.Replace(".", ",")),
            //    Temperatura = Decimal.Parse(txtTemperatura.Text.Replace(".", ",")),
            //    TemperaturaArterial = Decimal.Parse(txtTensaoArterial.Text.Replace(".", ",")),
            //    Peso = Decimal.Parse(txtPeso.Text.Replace(".", ",")),
            //    FrequenciaRespiratoria = Decimal.Parse(txtFrRespiratoria.Text.Replace(".", ",")),
            //    FrequenciaCardiaca = Decimal.Parse(txtFrCardiaca.Text.Replace(".", ",")),
            //    CodAtendimento = codAtendimento
            //};
            //if (LastCodTriagem == 0)
            //{
                
            //    _TriagemApp.Insert(triagem);
            //    LastCodTriagem = _GenericoApp.LastCodGeral("Triagem");
            //}
            //else
            //{
            //    _TriagemApp.Update(triagem);

            //}
        }
        private void GravarReceita()
        {
            if (codReceita == 0)
            {
                _ReceitasApp.Insert(new Receitas()
                {
                    CodPaciente = CodPacienteNovo,
                    CodMedico = CodMedicoNovo,
                    CodConsulta = CodConsultaNovo,
                    Observacao = txtObservacao.Text,
                    Data = DateTime.Now.Date.ToString("yyyy-MM-dd"),
                    CodAtendimento = codAtendimento
                });
                LastCodReceita = _GenericoApp.LastCodGeral("Receitas");
                codReceita = LastCodReceita;
            }
            else
            {
                _ReceitasApp.Update(new Receitas()
                {
                    CodPaciente = CodPacienteNovo,
                    CodAtendimento = codAtendimento,
                    CodMedico = ConsultaMedicoReceitou.CodMedico,
                    CodConsulta = codConsulta,
                    Codigo = codReceita,
                    Observacao = txtObservacao.Text
                });
                LastCodReceita = codReceita;
            }
        }
        private void GravarExames()
        {
            for (int i = 0; i < LtExamesAtendimento.Count; i++)
            {
                if (LtExamesAtendimento[i].CodExameAtendimento == 0)
                    LtExamesAtendimento[i].CodPaciente = codPaciente;  LtExamesAtendimento[i].CodAtendimento = codAtendimento;
            }
            _ExamesApp.InsertUpdateExamesAtendimento(LtExamesAtendimento);
        }       
        private void GravarFarmacoReceita()
        {
            if (gridConsulta.RowCount == 0) {
                MessageBox.Show(
                    "Não pode passar receita sem marcar consulta.", 
                    "Receita",
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
                return;
            }
            if (LastCodReceita == 0)
            {
                codReceita = (LtReceitas[0].Codigo);
            }
            else
            {
                codReceita = LastCodReceita;
            }
            
            for (int i = 0; i < LtFarmacoReceita.Count; i++)
            {
                if (LtFarmacoReceita[i].CodAtendimento == 0)
                {
                    LtFarmacoReceita[i].CodFarmacoReceita = 0;
                    LtFarmacoReceita[i].CodPaciente = codPaciente;
                    LtFarmacoReceita[i].CodReceita = codReceita;
                    LtFarmacoReceita[i].CodAtendimento = codAtendimento;
                }  
            }
            _ReceitasApp.InsertFarmaco(LtFarmacoReceita);
        }
        private void Actualizacoes()
        {
            if (gridConsulta.RowCount > 0)
            {
                for (int i = 0; i < LtConsultas.Count; i++)
                {
                    if (LtConsultas[i].Codigo > 0)
                        _ConsultaHospitalarApp.UpdateAtendimento(new List<ConsultaHospitalar>() {
                            new ConsultaHospitalar() {
                                Codigo = LtConsultas[i].Codigo,
                                CodAtendimento = LastCodAtendimento
                            }
                        });
                }
            }           
        }

        private void InsertAll()
        {
            GravarTriagem();

            //if (gridReceitas.RowCount > 0)
            //    GravarReceita();

            //if (gridReceitas.RowCount > 0)
            //    GravarFarmacoReceita();
        }

        private void UpdateAll()
        {
            ActualizaTriagem();
            //ActualizaReceita();

            //if (gridReceitas.RowCount > 0)
            //{
            //    GravarReceita();
            //    GravarFarmacoReceita();
            //}

        }
        //--------------------------------------------------------------------------------------------------------------------
        //Actualizacoes
        private void ActualizaTriagem()
        {
            if ((!UtilidadesGenericas.ListaNula(LtTiagem) && LtTiagem[0].Codigo > 0))
            {
                var triagem = new Triagem()
                {
                    Codigo = LtTiagem[0].Codigo,
                    Temperatura = Convert.ToDecimal(txtTemperatura.Text),
                    TemperaturaArterial =txtTensaoArterial.Text,
                    Peso = Convert.ToDecimal(txtPeso.Text),
                    FrequenciaRespiratoria = Convert.ToDecimal(txtFrRespiratoria.Text),
                    FrequenciaCardiaca = Convert.ToDecimal(txtFrCardiaca.Text)
                };
                _TriagemApp.Update(triagem);
            }
            else
            {
                GravarTriagem();
            }
        }
        private void ActualizaReceita()
        {
            if (!UtilidadesGenericas.ListaNula(LtReceitas) && LtReceitas[0].Codigo > 0)
                _ReceitasApp.Update(new Receitas()
                {
                    CodPaciente = codPaciente,
                    CodAtendimento = codAtendimento,
                    CodMedico = CodMedicoNovo,
                    CodConsulta = CodConsultaNovo,
                    Codigo = codReceita,
                    Observacao = txtObservacao.Text
                });
        }
        private void btnNome_Click(object sender, EventArgs e)
        {
            var formPacientes = IOC.InjectForm<frmPacientes>();
            formPacientes.btnSelecionar.Enabled = true;
            formPacientes.ShowDialog();
            if (formPacientes.DadosPaciente.Codigo == 0) return;
            PacienteConsulta = formPacientes.DadosPaciente;
            DadosPaciente = formPacientes.DadosPaciente;
            codPaciente = DadosPaciente.Codigo;
            codEntidade = DadosPaciente.CodEntidade;
            GrupoDescricao = formPacientes.DadosPaciente.GrupoSanguineo.Descricao;
            CarregaCampos(formPacientes.DadosPaciente.CodEntidade.ToString());

        }
        #region Navigation
                private void btnPaciente_Click(object sender, EventArgs e)
                {
                    navigationItenamento.SelectedPage = navigationPage_Paciente;
                } 
                private void btnTriagem_Click(object sender, EventArgs e)
                {
                    navigationItenamento.SelectedPage = navigationPage_Triagem;
                }

                private void btnConsultas_Click(object sender, EventArgs e)
                {
                    navigationItenamento.SelectedPage = navigationPage_Consultas;
                }
                private void btnExames_Click(object sender, EventArgs e)
                {
                    navigationItenamento.SelectedPage = navigationPage_Exames;
                }
                private void btnReceitas_Click(object sender, EventArgs e)
                {
                    navigationItenamento.SelectedPage = navigationPage_Receitas;
                }
        #endregion
        private void btnSalvar_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (CamposValidos())
            {
                if (Editar)
                {
                    UpdateAll();
                    UtilidadesGenericas.Busca.Alterou = true;
                }
                else
                {
                    InsertAll();
                    UtilidadesGenericas.Busca.Alterou = true;
                }
                Close();
            }
        }
        private bool CamposValidos()
        {
            //if ((!UtilidadesGenericas.ListaNula(LtReceitas) || !UtilidadesGenericas.ListaNula(LtFarmacoReceita)))
            //{
            //    UtilidadesGenericas.MsgShow("Selecione o Medico que receitou os Farmacos", MessageBoxIcon.Error);
            //    return false;
            //}
            if ((UtilidadesGenericas.ListaNula(LtConsultas) && UtilidadesGenericas.ListaNula(LtExamesAtendimento)))
            {
                UtilidadesGenericas.MsgShow("Adicione pelomenos uma Consulta ou um Exame para poder salvar este Atendimeno!", MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void btnNovaConsulta_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCodPaciente1.Text))
            {
                MessageBox.Show("Selecione o paciente!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var form = IOC.InjectForm<frmAgendamentoConsulta>();
            
            var Consulta = form.AgendamentoConsulta(PacienteConsulta);
            if (Consulta.TipoConsulta != null)
            {
                gradeConsultas.DataSource = null;
                if(Consulta.CodTipoConsulta != 0)
                codTipoConsulta = Consulta.CodTipoConsulta;
                LtConsultas.Add(Consulta);
                codMedico = Consulta.CodMedico;
                codConsulta = Consulta.Codigo;
                gradeConsultas.DataSource = LtConsultas;

                if (codAtendimento <= 0)
                {
                    GravarAtentimento();
                }
            }
            LastCodAtendimento = codAtendimento;
            Actualizacoes();
        }
        private bool ContemNaListas(int id)
        {
            return LtExamesAtendimento.Where(a => a.CodExame == id).FirstOrDefault() != null;
        }
        private void btnNovoExame_Click(object sender, EventArgs e)
        { 
            var formExames= IOC.InjectForm<frmExames>();
            formExames.btnSelecionar.Enabled = true;
            formExames.ShowDialog();

            if (formExames.DadosExame.Descricao == "Nenhuma") return;
            formExames.DadosExame.CodPaciente = codPaciente;
            if (LtExamesAtendimento.Count > 0 && ContemNaListas(formExames.DadosExame.CodExame))
            {
                MessageBox.Show(" Exame " + formExames.DadosExame.Descricao + " Já está Adicionado", "Erro ao Adicionar ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (codPaciente <= 0)
            {
                MessageBox.Show("Selecione Um Paciente no tab Paciente", "Erro ao Adicionar ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            LtExamesAtendimento.Add(formExames.DadosExame);
            gradeExames.DataSource = null;
            gradeExames.DataSource = LtExamesAtendimento;



            if (gridExames.RowCount > 0)
            {
                if (codAtendimento <= 0 && LastCodAtendimento <= 0)
                {
                    GravarAtentimento();
                }
                GravarExames();
            }
        }
        private void btnNovaReceita_Click(object sender, EventArgs e)
        {
            if (gridConsulta.RowCount == 0) { MessageBox.Show("Não existe consulta Marcadada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            var Farmaco = IOC.InjectForm<frmInteligente>().GetSelecionado<Farmacos>("Farmacos", "Fármacos");
            if (!Equals(Farmaco, null))
            {
                LtFarmacoReceita.Add(new FarmacoReceitaViewModel() { CodFarmaco = Farmaco.Codigo, Descricao = Farmaco.Descricao });
                gradeReceitas.DataSource = null;
                gradeReceitas.DataSource = LtFarmacoReceita;
                txtObservacao.Enabled = true;
            }
        }     
        public void EditarAtendimento(List<AtendimentoHospitalarViewModel> Lista)
        {
            Editar = true;
            LtAtendimento = Lista;
            codAtendimento = Lista[0].Codigo;
            codEntidade = Lista[0].CodEntidade;
            codPaciente = LtAtendimento[0].CodPaciente;
            PacienteConsulta = _PacienteApp.GetByIdPaciente(codPaciente);
            CarregaCampos(Lista[0].CodEntidade.ToString());
            CarregaExames();
            CarregaReceitas();
            CarregaTriagem();
            CarregaConsultas();
            CarregaConultorio();
            ShowDialog();
            Close();
        }
        private void frmAtendimentoRecepcao_Load(object sender, EventArgs e)
        {
            verificarAtendimento();
            if (UtilidadesGenericas.Busca.VerificaConsultorio == true)
            {
                btnConsultar.Visible = true;
                btnReceitas.Visible = true;
                btnConsultas.Visible = false;
                btnDocumento.Visible = false;
                btnTriagem.Visible = true;
                btnSalvar.Visibility = BarItemVisibility.Never;
                btnSalvarFechar.Visibility = BarItemVisibility.Never;
                btnFecharRecepcao.Visibility = BarItemVisibility.Never;
                btnFinalizar.Visibility = BarItemVisibility.Always;

                if (!string.IsNullOrEmpty(UtilidadesGenericas.Busca.CodigoConsultaNova) && !string.IsNullOrEmpty(UtilidadesGenericas.Busca.CodCosulta))
                {
                    int Codigo = int.Parse(UtilidadesGenericas.Busca.CodCosulta);
                    CodConsultaNovo = int.Parse(UtilidadesGenericas.Busca.CodigoConsultaNova);
                    CodMedicoNovo = int.Parse(UtilidadesGenericas.Busca.CodMedicoNovo);
                    CodPacienteNovo = int.Parse(UtilidadesGenericas.Busca.CodPaceinteNovo);
                    codAtendimento = codAtendimento;
                }

            }

        }

        private void verificarAtendimento()
        {

            if (codAtendimento > 0)
            {
                EstadoRecepcao = _AtendimentoHospitalarApp.GetEstadoAtendimento(codAtendimento);
                if (EstadoRecepcao)
                {
                    btnFecharRecepcao.Enabled = true;
                }
                else
                {
                    txtTemperatura.Enabled = false;
                    txtTensaoArterial.Enabled = false;
                    txtTipoConsulta.Enabled = false;
                    txtQueixasPrincipal.Enabled = false;
                    txtFrCardiaca.Enabled = false;
                    txtFrRespiratoria.Enabled = false;
                    txtAnaminizes.Enabled = false;
                    txtObservacao.Enabled = false;
                    txtPeso.Enabled = false;
                    btnDeleteExame.Enabled = false;
                    btnNovoExame.Enabled = false;
                    btnDeleteFarmaco.Enabled = false;
                    btnEditar.Enabled = false;
                    btnNovaConsulta.Enabled = false;
                    btnNome.Enabled = false;
                    btnNovaReceita.Enabled = false;
                    btnDeleteFarmaco.Enabled = false;
                    btnDeleteConsulta.Enabled = false;
                }
            }
        }

        #region Codigo do consultorio


        private void PopularDadosEditar(int Codigo)
        {
            //if (Codigo == 0) return;
            //AreaId = Codigo;
            //Entity = _AtendimentoHospitalarApp.GetById(Codigo);
            //txtEntidade.Text = Entity.Entidades.Nome;
            //codEntidade = Entity.CodEntidade;
            //gradeArea.DataSource = listaArea = _profApp.GetArea(Codigo);
        }
        #endregion
        
        private void gridExames_RowClick(object sender, RowClickEventArgs e)
        {
            indexGridExames = e.RowHandle;
        }
        private void gridReceitas_RowClick(object sender, RowClickEventArgs e)
        {
            indexGridReceitas = e.RowHandle;
        }
        private void btnDeleteFarmaco_Click(object sender, EventArgs e)
        {
            if (indexGridReceitas == -1) { MessageBox.Show("Selecione uma linha!", "Exames", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            if (LtFarmacoReceita[indexGridReceitas].CodFarmacoReceita!= 0)
            {
                try
                {
                    _ReceitasApp.DeleteFarmacos(new FarmacoReceita() { Codigo = LtFarmacoReceita[indexGridReceitas].CodFarmacoReceita });
                }
                catch (Exception)
                {
                    MessageBox.Show("Erro a Deletar Exames\n");
                }
            }
            LtFarmacoReceita.RemoveAt(indexGridReceitas);
            gradeReceitas.DataSource = null;
            gradeReceitas.DataSource = LtFarmacoReceita;
            indexGridReceitas = -1;
        }
        private void btnDeleteExame_Click(object sender, EventArgs e)
        {
            if (indexGridExames == -1) { MessageBox.Show("Selecione uma linha!", "Exames", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            if (LtExamesAtendimento[indexGridExames].CodExameAtendimento != 0)
            {
                try
                {
                    _ExamesApp.DeleteExamesAtendimento(new ExamesAtendimento() { Codigo = LtExamesAtendimento[indexGridExames].CodExameAtendimento });
                }
                catch (Exception)
                {
                    MessageBox.Show("Erro a Deletar Exames\n");
                }
            }
            LtExamesAtendimento.RemoveAt(indexGridExames);
            gradeExames.DataSource = null;
            gradeExames.DataSource = LtExamesAtendimento;
            indexGridExames = -1;
        }
        private void gridConsulta_DoubleClick(object sender, EventArgs e)
        {
            if (indexGridConsulta <= -1 || !EstadoRecepcao)
                return;
            var form = IOC.InjectForm<frmAgendamentoConsulta>();
            if (!UtilidadesGenericas.ListaNula(LtConsultas))
            {
                var result = form.EditarAgendamentoConsulta(codAtendimento.ToString(), LtConsultas[indexGridConsulta].Codigo.ToString(), txtNomePaciente1.Text);
                if (Equals(result, null) || Equals(result.TipoConsulta, null))
                {
                    return;
                }
                int index=-1;
                for (int i = 0; i < LtConsultas.Count; i++)
                {
                    if (LtConsultas[i].Codigo == result.Codigo) index = i;
                }
                if(index!=-1)
                LtConsultas[index].CodMedico = result.CodMedico;
                LtConsultas[index].TipoConsulta = result.TipoConsulta;
                LtConsultas[index].Medico = result.Medico;
                LtConsultas[index].HoraMarcada = result.HoraMarcada;
                gradeConsultas.DataSource = null;
                gradeConsultas.DataSource = LtConsultas;
            }
        }
        private void gridConsulta_RowClick(object sender, RowClickEventArgs e)
        {
            indexGridConsulta = e.RowHandle;
        }

        private void gridConsulta_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            indexGridConsulta = e.RowHandle;
        }

        private void btnDocumento_Click(object sender, EventArgs e)
        {
            if (UtilidadesGenericas.EstadoTurnoSistema && UtilidadesGenericas.CodigoTurno > 0)
            {
                navigationItenamento.SelectedPage = pageFacturacao;
                UtilidadesGenericas.showFormInPanel(panelFacturacao, IOC.InjectForm<frmFacturacaoHospitalar>().FacturarDocumento(codAtendimento));
            }
            else
            {
                UtilidadesGenericas.MsgShow("Abra o turno para poder acessar a facturação!", MessageBoxIcon.Warning);
            }
        }

        private void CarregarDocumentosAtendimento()
        {
           
        }

        private void gridDocumentos_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            IndexDocumento = e.RowHandle;
        }

        private void btnVerDocumentos_Click(object sender, EventArgs e)
        {
            CarregarDocumentosAtendimento();
        }

        private void btnSalvarFechar_ItemClick(object sender, ItemClickEventArgs e)
        {
            btnSalvar_ItemClick(sender, e);
            UtilidadesGenericas.Busca.VerificaConsultorio = false;
            //Close();
        }

        private void btnVoltar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
            UtilidadesGenericas.Busca.VerificaConsultorio = false;

        }



        private void CarregarDocumentosAtendimento(ItemAtendimentoFacturaViewModel itemAtendimentoFacturaViewModel)
        {

        }

        private void txtTemperatura_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btnPrintTriagem_Click(object sender, EventArgs e)
        {
            string RelUsuario = UtilidadesGenericas.UsuarioCodigo + " - " + UtilidadesGenericas.NomeUsuario;
            DadosReportViewModel dados = new DadosReportViewModel() { Usuario = RelUsuario,DataInicio=LtTiagem[0].Data,DataFim= LtTiagem[0].Data };
            AllEntidadeViewModel paciente = new AllEntidadeViewModel() { Nome = txtNomePaciente1.Text, Sexo = cboSexo.Text, EstadoCivil = cboEstadoCivil.Text, DataNascimento = Convert.ToDateTime(dateNascimento.Text) };
            new frmApresentaReport().ApresentarReportTriagem(LtTiagem, dados, paciente);
        }

        private void btnImprimirReceita_Click(object sender, EventArgs e)
        {
            //new frmApresentaReport().ApresentarReportReceita(LtFarmacoReceita, paciente);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ItemCheckFacturar_CheckedChanged(object sender, EventArgs e)
        {}

        private void btnIntenamento_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCodPaciente1.Text))
            {
                MessageBox.Show("Selecione o paciente!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (gridConsulta.RowCount <= 0)
            {
                MessageBox.Show("Sr(a): "+ txtNomePaciente2.Text + "Não tem uma consulta o!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            navigationItenamento.SelectedPage = navegationIntenamento;
            UtilidadesGenericas.showFormInPanel(panelIntenamento, IOC.InjectForm<frmIntenamentoFaturacao>().FacturarDocumento(codAtendimento, codPaciente, codTipoConsulta));
        }

        private void navigationPage_Triagem_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnFecharRecepcao_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (TemItensPorFacturar())
            {
                UtilidadesGenericas.MsgShow("Não é Possivel Fechar este Atendimento pois" +
                    "\n existem itens a serem liberados ou facturados", MessageBoxIcon.Warning);
            }
            else
            {
                FecharRecepcao();
            }
        }

        private bool TemItensPorFacturar()
        {
            return _AtendimentoHospitalarApp.TemItensPorFacturar(codAtendimento);
        }

        private void FecharRecepcao()
        {
            _AtendimentoHospitalarApp.FecharAtendimento(
                new AtendimentoHospitalar()
                {
                    Codigo = codAtendimento,
                    CodPaciente = codPaciente,
                    CodUsuario = UtilidadesGenericas.UsuarioCodigo,
                    Facturado = "Sim"
                });
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            navigationItenamento.SelectedPage = navigationConsultorio;
        }

        private void Terminarconsulta()
        {
            _ConsultaHospitalarApp.UpdateConsultorio(
             new ConsultaHospitalar()
                {
                   Codigo = CodConsultaNovo,
                   Anaminizes = txtAnaminizes.Text,
                   QueixaPrincipal = txtQueixasPrincipal.Text,
                   EvolucaoTratamento = txtEvolucao.Text,
                   Atendido ="Sim"             
            });
        }

        private void btnFinalizar_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (txtAnaminizes.Text == "")
            {
                MessageBox.Show("O Campo Anaminizes está vazio!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtQueixasPrincipal.Text == "")
            {
                MessageBox.Show("O Campo Queixas Principal está vazio!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Terminarconsulta();
              // ActualizaTriagem();
            if (gridReceitas.RowCount > 0)
                    GravarReceita();

                if (gridReceitas.RowCount > 0)
                    GravarFarmacoReceita();
                UtilidadesGenericas.Busca.Alterou = true;
            //}


            var triagem = new Triagem()
            {
                Codigo = LastCodTriagem,
                CodPaciente = CodPacienteNovo,
                Temperatura = Decimal.Parse(txtTemperatura.Text.Replace(".", ",")),
                TemperaturaArterial = txtTensaoArterial.Text,
                Peso = Decimal.Parse(txtPeso.Text.Replace(".", ",")),
                FrequenciaRespiratoria = Decimal.Parse(txtFrRespiratoria.Text.Replace(".", ",")),
                FrequenciaCardiaca = Decimal.Parse(txtFrCardiaca.Text.Replace(".", ",")),
                CodAtendimento = codAtendimento
            };
            if (LastCodTriagem == 0)
            {

                _TriagemApp.Insert(triagem);
                LastCodTriagem = _GenericoApp. LastCodGeral("Triagem");
            }
            else
            {
                _TriagemApp.Update(triagem);

            }

            Close();
        }

        private void ribbon_Click(object sender, EventArgs e)
        {

        }

        private void frmAtendimentoRecepcao_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (codAtendimento > 0)
            {
                GravarTriagem();
            }
        }
    }
    
}