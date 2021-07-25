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
using Folha.Driver.Framework.IOC;
using Folha.Presentation.Desktop.Forms.Hispitalar;
using Folha.Domain.ViewModels.Hospitalar;
using Folha.Domain.ViewModels.Frame.Hospitalar;
using Folha.Domain.Interfaces.Application.Hospitalar;
using Folha.Domain.Models.Hospitalar;
using Folha.Presentation.Desktop.Forms.Principal;
using Folha.Domain.ViewModels.Genericos;
using Folha.Domain.Interfaces.Application.Genericos;
using Folha.Presentation.Desktop.Forms.Armazens;
using Folha.Domain.Helpers;

namespace Folha.Presentation.Desktop.Forms.Hospitalar
{
    public partial class frmAgendamentoConsulta : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private int codPaciente;
        private int codTipoConsulta;
        private int codDia;
        private int codMedico;
        List<Folha.Domain.ViewModels.Frame.Hospitalar.MedicosViewModel> LtMedicos = new List<Folha.Domain.ViewModels.Frame.Hospitalar.MedicosViewModel>();
        private readonly IConsultaHospitalarApp _ConsultaHospitalarApp;
        private int codPrioridade;
        private int codTipoServico;
        public MarcacaoConsultaViewModel ConsultaMarcada { get; set; } = null;
        //List<MarcacaoConsultaViewModel> LtConsultaMarcada = new List<MarcacaoConsultaViewModel>();
        List<ConsultaHospitalar> LtConsulta = new List<ConsultaHospitalar>();
        List<ConsultaHospitalarViewModel> LtConsultaEdit;
        private int codEntidade;
        private List<EscalaConfig01ViewModel> LtEscalaDisponivel;
        private readonly IEscalaApp _EscalaApp;
        private readonly IMedicosApp _MedicosApp;
        private int codEspecialidade;
        private int indexGridProfissional;
        private bool Editar=false;
        private int codConsulta;
        private int codImposto=0;
        private int codMotivoInsencao=0;
        private readonly IGenericoApp _GenericoApp;

        public frmAgendamentoConsulta(IConsultaHospitalarApp ConsultaHospitalarApp, IEscalaApp EscalaApp, IMedicosApp MedicosApp,IGenericoApp GenericoApp)
        {
            InitializeComponent();
            _ConsultaHospitalarApp = ConsultaHospitalarApp;
            _EscalaApp = EscalaApp;
            _MedicosApp = MedicosApp;
            _GenericoApp = GenericoApp;
            timeData.Properties.MinValue = DateTime.Now;
            timeData.Properties.MaxValue = new DateTime(DateTime.Now.Year + 100, DateTime.Now.Month, DateTime.Now.Day);
            ConsultaMarcada = new MarcacaoConsultaViewModel() { Codigo = 0, TipoConsulta = null };
        }     
        private void btnTipoConsulta_Click_1(object sender, EventArgs e)
        {
            var formTipoConsulta = IOC.InjectForm<frmTipoConsultas>();
            formTipoConsulta.btnSelecionar.Enabled = true;
            formTipoConsulta.ShowDialog();
            if (formTipoConsulta.DadosTipoConsulta.Descricao == "Nenhuma") return;
            codTipoConsulta = formTipoConsulta.DadosTipoConsulta.Codigo;
            codEspecialidade = formTipoConsulta.DadosTipoConsulta.CodEspecialidade;
            txtTipoConsulta.Text = formTipoConsulta.DadosTipoConsulta.Descricao;
            txtValor.Text = formTipoConsulta.DadosTipoConsulta.Valor.ToString("N2");
            GetProfissional();
        }

        public MarcacaoConsultaViewModel AgendamentoConsulta(PacienteViewModel DadosPaciente)
        {
            txtPaciente.Text = DadosPaciente.Nome;
            codPaciente = DadosPaciente.Codigo;
            ShowDialog();
            Close();
            return ConsultaMarcada;
        }

        public MarcacaoConsultaViewModel EditarAgendamentoConsulta(string CodAtendimento, string CodConsulta,string NomePaciente)
        {
            Editar = true;
            codConsulta = int.Parse(CodConsulta);
            txtPaciente.Text = NomePaciente;
            CarregaCampos(CodAtendimento, CodConsulta);
            GetProfissional();
            ShowDialog();
            Close();
            return ConsultaMarcada;
        }

        private void CarregaCampos(string CodAtendimento, string CodConsulta)
        {
            LtConsultaEdit = (List<ConsultaHospitalarViewModel>)_ConsultaHospitalarApp.Listar(CodAtendimento, CodConsulta);
            codEntidade = LtConsultaEdit[0].CodEntidade;
            codPrioridade = LtConsultaEdit[0].CodPrioridade;
            codTipoServico = LtConsultaEdit[0].CodTipoServico;
            codTipoConsulta = LtConsultaEdit[0].CodTipoConsulta;
            codMedico = LtConsultaEdit[0].CodMedico;
            codEspecialidade = LtConsultaEdit[0].CodEspecialidade;
            txtTipoConsulta.Text = LtConsultaEdit[0].TipoConsulta;
            timeData.EditValue= Convert.ToDateTime( LtConsultaEdit[0].Data);
            timeHoraInicial.EditValue = LtConsultaEdit[0].HoraInicial;
            timeTempoEstimado.EditValue = LtConsultaEdit[0].TempoEstimado;
            txtValor.Text = LtConsultaEdit[0].ValorConsulta.ToString("N2");
            txtPrioridade.Text = LtConsultaEdit[0].Prioridade;
            txtTipoServico.Text = LtConsultaEdit[0].TipoServico;
            txtProfissional.Text = LtConsultaEdit[0].NomeMedico;
            txtObservacao.Text = LtConsultaEdit[0].Observacao;
            codImposto = LtConsultaEdit[0].CodImposto;
        }

        private void GravarConsulta()
        {
            _ConsultaHospitalarApp.Insert(new  ConsultaHospitalar()
            {
                Codigo = 0,
                CodPaciente = codPaciente,
                CodTipoConsulta = codTipoConsulta,
                Data = Convert.ToDateTime(timeData.Text),
                HoraInicial = timeHoraInicial.Text,
                TempoEstimado = timeTempoEstimado.Text,
                ValorConsulta = Convert.ToDouble(txtValor.Text),
                CodPrioridade = codPrioridade,
                CodTipoServico = codTipoServico,
                CodMedico = codMedico,
                Observacao = txtObservacao.Text,
                status = 1,
                Atendido = "Não",
                CodImposto=codImposto,
                CodMotivoIsencao=codMotivoInsencao

            });

            ConsultaMarcada = new MarcacaoConsultaViewModel() {
                Codigo = _ConsultaHospitalarApp.LastCodConsulta(),
                CodMedico =codMedico,
                TipoConsulta = txtTipoConsulta.Text,
                CodTipoConsulta =codTipoConsulta,
                Medico = txtProfissional.Text,
                HoraMarcada = timeHoraInicial.Text,
                Atendido = "Não",
                Editar =false
            };
        }
        private void EditarConsulta()
        {
            _ConsultaHospitalarApp.Update(new ConsultaHospitalar()
            {
                Codigo = codConsulta,
                CodTipoConsulta = codTipoConsulta,
                Data = Convert.ToDateTime(timeData.Text),
                HoraInicial = timeHoraInicial.Text,
                TempoEstimado = timeTempoEstimado.Text,
                ValorConsulta = Convert.ToDouble(txtValor.Text),
                CodPrioridade = codPrioridade,
                CodTipoServico = codTipoServico,
                CodMedico = codMedico,
                Observacao = txtObservacao.Text,
                CodImposto = codImposto,
                CodMotivoIsencao = codMotivoInsencao
            });

            ConsultaMarcada = new MarcacaoConsultaViewModel() { Codigo=codConsulta, CodMedico = codMedico, TipoConsulta = txtTipoConsulta.Text, CodTipoConsulta = codTipoConsulta, Medico = txtProfissional.Text, HoraMarcada = timeHoraInicial.Text,Editar=true};
        }
        private void btnSalvar_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (CamposValidos())
            {
                if (Editar)
                    EditarConsulta();
                else
                GravarConsulta();

                Close();
            }
        }

        private bool CamposValidos()
        {
            if (string.IsNullOrEmpty(txtProfissional.Text))
            {
                UtilidadesGenericas.MsgShow("Selecione o Proficional de Saúde!");
                return false;
            }
            if (string.IsNullOrEmpty(txtTipoConsulta.Text))
            {
                UtilidadesGenericas.MsgShow("Selecione o Tipo de Consulta!");
                return false;
            }
            if (string.IsNullOrEmpty(txtPrioridade.Text))
            {
                UtilidadesGenericas.MsgShow("Selecione a prioridade!");
                return false;
            }
            if (string.IsNullOrEmpty(txtTipoServico.Text))
            {
                UtilidadesGenericas.MsgShow("Selecione o Tipo de Serviço!");
                return false;
            }
            if (Equals(timeData.EditValue, null))
            {
                UtilidadesGenericas.MsgShow("Selecione a data da consulta!");
                return false;
            }
            if (string.IsNullOrEmpty(timeTempoEstimado.Text))
            {
                UtilidadesGenericas.MsgShow("Insira o tempo estimado!");
                return false;
            }
            if (string.IsNullOrEmpty(timeHoraInicial.Text))
            {
                UtilidadesGenericas.MsgShow("Insira a hora maracada!");
                return false;
            }
            return true;
        }

        private void btnPrioridade_Click(object sender, EventArgs e)
        {
            var Prioridade = IOC.InjectForm<frmInteligente>().GetSelecionado<Prioridade>("Prioridade", "Prioridade");
            if (!Equals(Prioridade, null))
            {
                codPrioridade = Prioridade.Codigo;
                txtPrioridade.Text = Prioridade.Descricao;
                GetProfissional();
            }
        }

        private void frmAgendamentoConsulta_Load(object sender, EventArgs e)
        {
            codPrioridade = 2;
            txtPrioridade.Text = "NÃO URGENTE";
        }

        private void btnTipoServico_Click(object sender, EventArgs e)
        {
            var TipoServico = IOC.InjectForm<frmInteligente>().GetSelecionado<TipoServico>("TipoServico", "Tipo de Servico");

            if (!Equals(TipoServico, null))
            {
                codTipoServico = TipoServico.Codigo;
                txtTipoServico.Text = TipoServico.Descricao;
                GetProfissional();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            GetProfissional();
            if(LtMedicos.Count==0) MessageBox.Show("Sem profissionais disponíveis.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void GetProfissional()
        {
            int codEscala;
            codDia = _GenericoApp.BuscarCodigo("DiasSemana", "DayOfWeak", timeData.DateTime.DayOfWeek.ToString());
            if (string.IsNullOrEmpty(timeHoraInicial.Text) || codEspecialidade <= 0)
            {
                return;
            }
            LtEscalaDisponivel = (List<EscalaConfig01ViewModel>)_EscalaApp.ListEscalaDisponivel(codDia.ToString(), timeHoraInicial.Text);
            if (LtEscalaDisponivel.Count > 0)
            {
                codEscala = LtEscalaDisponivel[0].CodEscala;
                gradeProfissional.DataSource = null;
                gradeProfissional.DataSource = LtMedicos = /*(List<MedicosViewModel>)*/_MedicosApp.ListarMedicosDisponiveis(null, codEscala.ToString(),codEspecialidade.ToString(), timeHoraInicial.Text, timeData.Text);
                
            }
            else
            {
                //MessageBox.Show("Sem profissionais disponíveis.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                gradeProfissional.DataSource = null;
            }
        }

        private void gridProfissional_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            indexGridProfissional = e.RowHandle;
            txtProfissional.Text = LtMedicos[indexGridProfissional].Nome;
            codMedico = LtMedicos[indexGridProfissional].CodMedico;
            codEntidade = LtMedicos[indexGridProfissional].CodEntidade;
        }

        private void btnImposto_Click(object sender, EventArgs e)
        {
            var form = IOC.InjectForm<frmImpostos>();
            form.btnselect.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            var imposto = form.GetImposto();
            if (Equals(imposto, null))
            {
                return;
            }
            codImposto = imposto.Codigo;
            //txtImposto.Text = imposto.Descricao;
            //txtValorIva.Text = imposto.Percentagem.ToString();
            //if (codImposto == 1)
            //{
            //    btnMotivoIsencao.Enabled = true;
            //}
            //else
            //{
            //    btnMotivoIsencao.Enabled = false;
            //    txtMotivoIsencao.Text = "";
            //}
        }

        private void btnMotivoIsencao_Click(object sender, EventArgs e)
        {
            var form = IOC.InjectForm<frmMotivoIsencao>();
            form.btnSelecionar.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            var motivoIsencao = form.GetMotivoIsencao();
            if (Equals(motivoIsencao, null)) { return; }
            codMotivoInsencao = motivoIsencao.Codigo;
        }

        private void btnVoltar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void timeData_EditValueChanged(object sender, EventArgs e)
        {
            GetProfissional();
        }

        private void timeHoraInicial_EditValueChanged(object sender, EventArgs e)
        {
            GetProfissional();
        }
    }
}