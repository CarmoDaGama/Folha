using DevExpress.XtraBars;
using Folha.Domain.Interfaces.Application.Entidades;
using Folha.Domain.Interfaces.Application.Hospitalar;
using Folha.Driver.Application.Entidades;
using Folha.Domain.Models.Hospitalar;
using Folha.Domain.ViewModels.Hospitalar;
using Folha.Domain.Helpers;
using Folha.Driver.Framework.IOC;
using Folha.Presentation.Desktop.Forms.Apresenta_Doc;
using System;
using System.Windows.Forms;

namespace Folha.Presentation.Desktop.Forms.Hospitalar
{
    public partial class frmLaboratorio : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        private readonly ILaboratorioApp _labApp;
        private bool Changed { get; set; } = false;
        private string validar = ("QWERTYUIOPASDFGHJKLÇZXCVBNMqwertyuiop+´´asdfghjklçº~<zxcvbnm,.-/*-+._^`*ª»?=)(//&%$#:;|!#$%&/()=?»><*^ª%_:--»º|!?»`^ª[]}[}*-+^^`*");
        private ExamesAtendimentoViewModel Entity { get; set; }
        public int CodPaciente { get; private set; }
        public int CodExame { get; private set; }
        public int CodProfissionalSaude { get; private set; }
        public int Feito { get; private set; }
        public string CodPEssoa { get; private set; }

        public string NomePaciente;
        public string Resultado;
        private Laboratorio laboratorio;
        private readonly IEntidadesApp _entidadeApp;
        private readonly IEntidadePessoaApp _entidadePessoaApp;
        int usuario = int.Parse(UtilidadesGenericas.UsuarioPerfil.ToString());
        private string Sexo;
        public DateTime DataNascimento;
        private string civil;
        private string Contacto;

        public frmLaboratorio(ILaboratorioApp labApp, IEntidadesApp entidadeApp, IEntidadePessoaApp entidadePApp)
        {
            InitializeComponent();
            _labApp = labApp;
            _entidadeApp = entidadeApp;
            _entidadePessoaApp = entidadePApp;
            Permicao();

        }
        #region Permicao de Acesso
        private void Permicao()
        {
            if (usuario != 1)
            {
                if (UtilidadesGenericas.TemAcesso("Hospitalar#Laboratorio#Dar Resultado") == false) { btnSalvar.Enabled = false; }
                if (UtilidadesGenericas.TemAcesso("Hospitalar#Laboratorio#Dar Resultado") == false) { btnSalvarFechar.Enabled = false; }
            }
        }
        #endregion
        #region Metodos de Inserção
        private Laboratorio PopulaObjecto()
        {
            laboratorio = new Laboratorio()
            {
                CodProfissional = CodProfissionalSaude,
                Estado = Resultado,
                NumeroAmostra = txtAmostra.Text,
                Unidade = txtunidade.Text,
                VReferencia = txtReferencia.Text,
                status = 0
            };
            if (!string.IsNullOrEmpty(txtCodigo.Text)) laboratorio.Codigo = int.Parse(txtCodigo.Text);
            return laboratorio;
        }
        private void PopularDadosEditar(int Codigo)
        {

            if (Codigo == 0) return;
            Entity = _labApp.GetById(Codigo);
            CodPaciente = Entity.CodPaciente;
            txtPaciente.Text = NomePaciente = _entidadeApp.GetById(Entity.Pacientes.CodPessoa).Nome;
            DataNascimento = Convert.ToDateTime( _entidadePessoaApp.GetById(Entity.Pacientes.CodPessoa).DataNascimento);
            Sexo = _entidadePessoaApp.GetById(Entity.Pacientes.CodPessoa).Sexo.descricao;
            civil = _entidadePessoaApp.GetById(Entity.Pacientes.CodPessoa).EstadoCivil.descricao;
            txtExame.Text = Entity.ExamesHospitalar.Descricao;
            CodExame = Entity.CodExame;
            CodPEssoa = Entity.Pacientes.CodPessoa.ToString();
            txtData.Text = Entity.Data.ToString();
            CodProfissionalSaude = Entity.CodProfissionalSaude;
            txtTecnico.Text = Entity.ProfissionalSaude.Entidades.Nome;
            Feito = Entity.status;
            txtTipoResultado.Text = Entity.TipoResultado;

            txtMedico.Text = Entity.Medico;
            txtReferencia.Text = Entity.VReferencia;
            txtAmostra.Text = Entity.NumeroAmostra;
            txtProcesso.Text = Entity.NumeroProcesso;
            txtunidade.Text = Entity.Unidade;
           
            if (txtTipoResultado.Text == "POSITIVO/NEGATIVO")
            {
                cboResultadoD.Text = Entity.Estado;
            }
            else if (txtTipoResultado.Text == "PERCENTAGEM")
            {
                txtResultadoPerc.Text = Entity.Estado;
            }
            else if ((txtTipoResultado.Text == "DESCRIÇÃO"))
            {
                txtResultDescricao.Text = Entity.Estado;
            }

            var Telefone = _labApp.GetTelefoneByEntidade(CodPEssoa);
            if (Equals(Telefone,null))
            {
                return;
            }
            Contacto = _labApp.GetTelefoneByEntidade(CodPEssoa).descricao;

        }
        #endregion
        private void frmLaboratorio_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(UtilidadesGenericas.Busca.Codigo))
            {
                txtCodigo.Text = UtilidadesGenericas.Busca.Codigo;
                int codigoLaboratorio = int.Parse(txtCodigo.Text);
                var lab = _labApp.GetById(codigoLaboratorio);
                if (codigoLaboratorio > 0) PopularDadosEditar(codigoLaboratorio);

                if (Feito == 1)
                {
                    btnSalvarFechar.Visibility = BarItemVisibility.Always;
                    btnPrint.Visibility = BarItemVisibility.Never;

                    if (txtTipoResultado.Text == "POSITIVO/NEGATIVO")
                    {
                        cboResultadoD.Enabled = true;
                        cboResultadoD.Visible = true;
                        txtResultadoPerc.Visible = false;
                        txtResultDescricao.Visible = false;
                    }
                    else if (txtTipoResultado.Text == "PERCENTAGEM")
                    {
                        txtResultadoPerc.Enabled = true;
                        txtResultadoPerc.Visible = true;
                        cboResultadoD.Visible = false;
                        txtResultDescricao.Visible = false;

                    }
                    else if ((txtTipoResultado.Text == "DESCRIÇÃO"))
                    {
                        txtResultDescricao.Enabled = true;
                        txtResultDescricao.Visible = true;
                        txtResultadoPerc.Visible = false;
                        cboResultadoD.Visible = false;
                    }
                }
                 if (Feito == 0)
                {
                    btnSalvarFechar.Visibility = BarItemVisibility.Never;
                    btnPrint.Visibility = BarItemVisibility.Always;
                    btnBusca.Enabled = false;
                    txtReferencia.Enabled = false;
                    txtAmostra.Enabled = false;
                    txtunidade.Enabled = false;

                    if (txtTipoResultado.Text == "POSITIVO/NEGATIVO")
                    {
                        cboResultadoD.Enabled = false;
                        cboResultadoD.Visible = true;
                        txtResultadoPerc.Visible = false;
                        txtResultDescricao.Visible = false;

                    }
                    else if (txtTipoResultado.Text == "PERCENTAGEM")
                    {
                        txtResultadoPerc.Enabled = false;
                        txtResultadoPerc.Visible = true;
                        cboResultadoD.Visible = false;
                        txtResultDescricao.Visible = false;

                    }
                    else if ((txtTipoResultado.Text == "DESCRIÇÃO"))
                    {
                        txtResultDescricao.Enabled = false;
                        txtResultDescricao.Visible = true;
                        txtResultadoPerc.Visible = false;
                        cboResultadoD.Visible = false;
                    }
                }
            }
        }
    
        private void btnSalvar_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (txtTipoResultado.Text == "POSITIVO/NEGATIVO")
            {
                Resultado = cboResultadoD.Text;

            }
            else if (txtTipoResultado.Text == "PERCENTAGEM")
            {
                Resultado = txtResultadoPerc.Text;
            }
            else if (txtTipoResultado.Text == "DESCRIÇÃO")
            {
                Resultado = txtResultDescricao.Text;
            }
            else
            {
                MessageBox.Show("Teste Invalido", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTecnico.Text == "")
            {
                MessageBox.Show("Adiciona um Tecnico de  laboratorio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (txtTipoResultado.Text == "POSITIVO/NEGATIVO" && cboResultadoD.SelectedIndex > 0)
            {
                MessageBox.Show("Adiciona um resultado do tipo Positivo ou negativo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }
            else if (txtTipoResultado.Text == "PERCENTAGEM" && txtResultadoPerc.Text == "")
            {
                MessageBox.Show("Adiciona um resultado do tipo Percentagem", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }
            else if (txtTipoResultado.Text == "DESCRIÇÃO" && txtResultDescricao.Text == "")
            {
                MessageBox.Show("Adiciona um resultado do tipo Descricão", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                var lab = PopulaObjecto();
                lab = _labApp.Gravar(lab);
            }
            catch (Exception)
            {
                MessageBox.Show("Erro, verifica os dados !", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            PopularDadosEditar(laboratorio.Codigo);
            txtCodigo.Text = laboratorio.Codigo.ToString();
            UtilidadesGenericas.Busca.Alterou = true;
            if (MessageBox.Show("Deseja Imprimir", "Imprimir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) return;
            new frmApresentaReport().ApresentarReportFichaLaboratorio(Entity, NomePaciente, DataNascimento, civil, Sexo, Contacto);

        }
       
        private void btnBusca_Click(object sender, EventArgs e)
        {
            var form = IOC.InjectForm<frmProfissionalSaudes>();
            form.btnSelecionar.Visibility = BarItemVisibility.Always;

            var BuscaProf = form.GetProfissional();
            if (Equals(BuscaProf, null))
            {
                return;
            }
            else
            {
                CodProfissionalSaude = BuscaProf.Codigo;
                txtTecnico.Text = BuscaProf.Nome;
            }
        }

        private void btnVoltar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }
        private void txtResultadoPerc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (validar.Contains(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }
        private void btnSalvarFechar_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (txtTipoResultado.Text == "POSITIVO/NEGATIVO")
            {
                Resultado = cboResultadoD.Text;
            }
            else if (txtTipoResultado.Text == "PERCENTAGEM")
            {
                Resultado = txtResultadoPerc.Text;
            }
            else if (txtTipoResultado.Text == "DESCRIÇÃO")
            {
                Resultado = txtResultDescricao.Text;
            }
            else
            {
                MessageBox.Show("Teste Invalido", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTecnico.Text == "")
            {
                MessageBox.Show("Adiciona um Tecnico de  laboratorio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (txtTipoResultado.Text == "POSITIVO/NEGATIVO" && cboResultadoD.SelectedIndex < 0)
            {
                MessageBox.Show("Adiciona um resultado do tipo Positivo ou negativo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }
            else if (txtTipoResultado.Text == "PERCENTAGEM" && txtResultadoPerc.Text == "")
            {
                MessageBox.Show("Adiciona um resultado do tipo Percentagem", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }
            else if (txtTipoResultado.Text == "DESCRIÇÃO" && txtResultDescricao.Text == "")
            {
                MessageBox.Show("Adiciona um resultado do tipo Descricão", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
                var lab = PopulaObjecto();
                lab = _labApp.Gravar(lab);
          
            PopularDadosEditar(laboratorio.Codigo);
            txtCodigo.Text = laboratorio.Codigo.ToString();
            UtilidadesGenericas.Busca.Alterou = true;
            if (MessageBox.Show("Deseja Imprimir", "Imprimir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            new frmApresentaReport().ApresentarReportFichaLaboratorio(Entity, NomePaciente, DataNascimento, civil, Sexo, Contacto);

            Close();
        }

        
        private void btnVoltar_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            Close();
        }
        private void btnPrint_ItemClick(object sender, ItemClickEventArgs e)
        {
            new frmApresentaReport().ApresentarReportFichaLaboratorio(Entity, NomePaciente, DataNascimento, civil, Sexo, Contacto);
        }
    }
}