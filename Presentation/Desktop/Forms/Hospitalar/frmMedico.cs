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
using Folha.Driver.Framework.IOC;
using Folha.Presentation.Desktop.Separadores.Recursos_Humanos;
using Folha.Presentation.Desktop.Separadores.Empresa;
using Folha.Presentation.Desktop.Separadores.Entidades;
using Folha.Domain.Interfaces.Application.Entidades;
using Folha.Domain.ViewModels.Frame.Entidades;
using Folha.Domain.Helpers;
using Folha.Domain.Interfaces.Application.Hospitalar;
using Folha.Domain.Models.Hospitalar;
using Folha.Domain.Enuns.Genericos;
using Folha.Domain.Models.Financeiro;
using Folha.Domain.ViewModels.Entidades;
using Folha.Domain.ViewModels.Report;
namespace Folha.Presentation.Desktop.Forms.Hospitalar
{
    using Folha.Domain.Interfaces.Application.Genericos;
    using Folha.Domain.Models.Genericos;
    using Folha.Domain.ViewModels.Financeiro;
    using Folha.Domain.ViewModels.Frame.Hospitalar;
    using Folha.Presentation.Desktop.Forms.Principal;
    using Folha.Domain.ViewModels.Frame.Entidades;
    using global::Classe.Validacao;
    using Folha.Domain.Models.Entidades;
    using Folha.Presentation.Desktop.Forms.Apresenta_Doc;

    public partial class frmMedico : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        private readonly IEntidadesApp _EntidadesApp;
        private readonly IEntidadePessoaApp _EntidadePessoaApp;
        private readonly IMedicosApp _MedicosApp;
        #region Declaracoes
        private AllEntidadeViewModel AllEntidade;
        private List<Medicos> ListaMedicos = new List<Medicos>();
        private List<ContactoViewModel> ListaContactos = new List<ContactoViewModel>();
        private List<MoradaViewModel> ListaMoradas = new List<MoradaViewModel>();
        private List<EntidadeContaViewModel> ListaContas = new List<EntidadeContaViewModel>();
        private List<DocumentoEntidadeViewModel> ListaDocumentos = new List<DocumentoEntidadeViewModel>();
        private List<MedicoEspecialidadeViewModel> ListaEspecialidade = new List<MedicoEspecialidadeViewModel>();
        private List<MedicosEspecialidades> ListaMedicosEspecialidade = new List<MedicosEspecialidades>();
        private List<Escala> ListaEscala;

        private int CodHabilitacoes;
        private int CodProfissao;
        private int CodPais;
        private string CodEntidade;
        private int CodSexo;
        private int CodEstadoCivil;
        private string SaberCodigoEnt;
        private string CodMedicoEntidade;
        private string CodMedico=null;
        private int indexGridDocumento=-1;
        private int indexGridContactos=-1;
        private int indexGridMoradas=-1;
        private int indexGridEspecialidade=-1;
        private int indexGridContaBancaria=-1;
        private int LastCodMedico;
        private int LastCodEntidade;
        private readonly IEscalaApp _EscalaApp;
        private int codEscala;
        private RelMedicoViewModel _Medico;
        #endregion
        #region Validacao
        public void ValidaBotaoSalvar()
        {
            Validacao.ValidacaoEspacoEmBranco(txtEntidade, errorProvider);
            Validacao.ValidacaoEspacoEmBranco(txtPai, errorProvider);
            Validacao.ValidacaoEspacoEmBranco(txtMae, errorProvider);
            Validacao.ValidacaoEspacoEmBranco(txtNacionalidade, errorProvider);
            Validacao.ValidacaoEspacoEmBranco(txtHabilitacao, errorProvider);
            Validacao.ValidacaoEspacoEmBranco(txtNumeroCarteira, errorProvider);

            Validacao.ValidacaoNome(txtEntidade, errorProvider);
            Validacao.ValidacaoNome(txtPai, errorProvider);
            Validacao.ValidacaoNome(txtMae, errorProvider);
        }
        #endregion
        public frmMedico(IEntidadesApp EntidadesApp, IEntidadePessoaApp EntidadePessoaApp, IMedicosApp MedicosApp, IEscalaApp EscalaApp) 
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            _EntidadesApp = EntidadesApp;
            _EntidadePessoaApp = EntidadePessoaApp;
            _MedicosApp = MedicosApp;
            _EscalaApp = EscalaApp;
            ValidacaoControles.InserirEnventosDeValidacao(txtMae, TipoValidacao.Nome);
            ValidacaoControles.InserirEnventosDeValidacao(txtPai, TipoValidacao.Nome);
            ValidacaoControles.InserirEnventosDeValidacao(txtContribuinte, TipoValidacao.Palavras);
            ValidacaoControles.InserirEnventosDeValidacao(txtNumeroCarteira, TipoValidacao.Numero);
        }
        
        private void btnHabilitacoes_Click(object sender, EventArgs e)
        {
            var habilitacao = IOC.InjectForm<frmInteligente>().GetSelecionado<Habilitacoes>("Habilitacoes", "Habilitações");
            if (Equals(habilitacao, null))
            {
                return;
            }
            CodHabilitacoes = habilitacao.Codigo;
            txtHabilitacao.Text = habilitacao.Descricao;
        }

        public void EditarMedico(Entidades entidade)
        {
            txtCodEntidade.Text = entidade.Codigo.ToString();
            txtEntidade.Text = entidade.Nome;
            CodEntidade = txtCodEntidade.Text;
            SaberCodigoEnt = (string.IsNullOrEmpty(txtCodEntidade.Text)) ? (LastCodEntidade.ToString()) : (txtCodEntidade.Text);

            ListaMedicos = new List<Medicos>();
            ListaMedicos = (List<Medicos>)_MedicosApp.GetMedico(txtCodEntidade.Text);
            if (ListaMedicos.Count > 0)
                CodMedico = ListaMedicos[0].Codigo.ToString();

            CarregaEntidade();
            btnPrint.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            ShowDialog();
            Close();
        }

        private void btnNacionalidade_Click(object sender, EventArgs e)
        {
            var pais = IOC.InjectForm<frmInteligente>().GetSelecionado<Pais>("Pais", "Paises");
            if (Equals(pais, null))
            {
                return;
            }
            CodPais =  pais.codigo;
            txtNacionalidade.Text = pais.Descricao;
        }

        private void btnNomeEntidade_Click(object sender, EventArgs e)
        {
            var formEntidadeBusca = IOC.InjectForm<frmEntidadeBusca>();
            var entitdade = formEntidadeBusca.GetEntidadeSelecionada(1);
            var listMEdico = (List<Medicos>)_MedicosApp.GetMedico(entitdade.Codigo.ToString());
            Medicos medico = null;
            if (!UtilidadesGenericas.ListaNula(listMEdico))
            {
                medico = listMEdico[0];
            }

            if (!Equals(medico, null) && medico.Codigo > 0 && medico.CodPessoa > 0)
            {
                UtilidadesGenericas.MsgShow("A Entidade " + entitdade.Nome + " Já existe como medico no sistema");
                return;

            }
            if (!Equals(entitdade, null) && entitdade.Codigo != 0)
            {
                if (entitdade.CodTipo == 2) { MessageBox.Show("Selecione Apenas Entidade Física", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                txtCodEntidade.Text = entitdade.Codigo.ToString();
                txtEntidade.Text = entitdade.Nome;
                CodEntidade = txtCodEntidade.Text;
                SaberCodigoEnt = (string.IsNullOrEmpty(txtCodEntidade.Text)) ? (LastCodEntidade.ToString()) : (txtCodEntidade.Text);

                ListaMedicos = new List<Medicos>();
                ListaMedicos =(List<Medicos>) _MedicosApp.GetMedico(txtCodEntidade.Text);
                if(ListaMedicos.Count>0)
                CodMedico = ListaMedicos[0].Codigo.ToString();
                CarregaEntidade(); 
            }

        }
        //----------------------
        //Regioes
        //----------------------
        #region Carregamentos
        private void CarregaCampos()
        {
            AllEntidade =_EntidadesApp.ListEntidadeGetAll(txtCodEntidade.Text);
            txtPai.Text = AllEntidade.NomePai;
            txtContribuinte.Text = AllEntidade.Nif;
            dateNascimento.EditValue = AllEntidade.DataNascimento;
            CodPais = int.Parse(AllEntidade.CodPais);
            CodSexo = int.Parse(AllEntidade.CodSexo);
            CodEstadoCivil = int.Parse(AllEntidade.CodEstadoCivil);
            CodHabilitacoes = int.Parse(AllEntidade.CodHabilitacao);

            txtNacionalidade.Text =AllEntidade.Nacionalidade;
            cboSexo.SelectedItem = AllEntidade.Sexo;
            cboEstadoCivil.SelectedItem =AllEntidade.EstadoCivil;
            txtHabilitacao.Text = AllEntidade.Habilitacao;
            txtPai.Text = AllEntidade.NomePai;
            txtMae.Text = AllEntidade.NomeMae;
            if (ListaMedicos.Count > 0)
                txtNumeroCarteira.Text = ListaMedicos[0].NumeroCarteira;
            CodProfissao = int.Parse(AllEntidade.CodProfissao);

            try
            {
                PicFoto.Image = Imagens.Byte_Imagem(AllEntidade.Foto);
            }
            catch (Exception ) { }
        }
        private void CarregaEntidade()
        {
            if(!string.IsNullOrEmpty(CodMedico))
            CarregaEspecialidade();
            CarregaContas();
            CarregaContactos();
            CarregaMorada();
            CarregaDocumento();
            CarregaCampos();
        }
        private void CarregaContas()
        {
            gradeConta.DataSource = ListaContas = (List<EntidadeContaViewModel>)_EntidadesApp.CarregaContas(txtCodEntidade.Text);
        }
        private void CarregaEspecialidade()
        {
            gradeEspecialidade.DataSource =ListaEspecialidade= _MedicosApp.ListarMedicoEspecialidade(CodMedico);
        }
        private void CarregaContactos()
        {
            gradeContactos.DataSource = ListaContactos = (List<ContactoViewModel>)_EntidadesApp.CarregaContactos(txtCodEntidade.Text);
        }
        private void CarregaMorada()
        {   
            gradeMorada.DataSource = ListaMoradas = (List<MoradaViewModel>)_EntidadesApp.CarregaMorada(txtCodEntidade.Text);
        }
        private void CarregaDocumento()
        {
            gradeDocumentos.DataSource = ListaDocumentos= (List<DocumentoEntidadeViewModel>)_EntidadesApp.CarregaDocumentos(txtCodEntidade.Text);
        }
#endregion
        #region Gravar
        private void GravarMedico()
        {
            byte[] logotipo = new byte[1];
            if (PicFoto.Image != null) logotipo = Imagens.Imagem_Byte(PicFoto.Image);
           
            AllEntidadeViewModel DadosEntidades = new AllEntidadeViewModel()
            {
                Codigo = string.IsNullOrEmpty(txtCodEntidade.Text)? 0 : int.Parse(txtCodEntidade.Text),
                Nome = txtEntidade.Text,
                Nif = txtContribuinte.Text,
                CodPais = CodPais.ToString(),
                Foto = logotipo
            };

            EntidadesPessoaViewModel DadosEntidadePessoa = new EntidadesPessoaViewModel()
            {
                CodEntidade = (!string.IsNullOrEmpty(txtCodEntidade.Text)) ?(int.Parse(txtCodEntidade.Text)) :(LastCodEntidade) ,
                CodSexo = cboSexo.SelectedIndex + 1,
                CodEstadoCivil = cboEstadoCivil.SelectedIndex + 1,
                DataNascimento = dateNascimento.Text,
                CodHabilitacao = CodHabilitacoes,
                CodProfissao = 1,
                NomePai = txtPai.Text,
                NomeMae = txtMae.Text
            };

            if(!string.IsNullOrEmpty(txtCodEntidade.Text) && !string.IsNullOrEmpty(CodMedico))
            {
                _EntidadesApp.UpdateEntidade(DadosEntidades);
                _EntidadePessoaApp.Update(DadosEntidadePessoa);
            }
            else if(string.IsNullOrEmpty(txtCodEntidade.Text))
            {
                _EntidadesApp.InserirEntidade(DadosEntidades);

                LastCodEntidade = _EntidadesApp.GetCodLastEntity();
                SaberCodigoEnt = LastCodEntidade.ToString();

                _EntidadePessoaApp.Insert(new EntidadesPessoaViewModel()
                {
                    CodEntidade = LastCodEntidade,
                    CodSexo = cboSexo.SelectedIndex + 1,
                    CodEstadoCivil = cboEstadoCivil.SelectedIndex + 1,
                    DataNascimento = dateNascimento.Text,
                    CodHabilitacao = CodHabilitacoes,
                    CodProfissao = 1,
                    NomePai = txtPai.Text,
                    NomeMae = txtMae.Text
                });
            }

            ListaMedicos = new List<Medicos>();
            ListaMedicos = (List<Medicos>)_MedicosApp.GetMedico(txtCodEntidade.Text);

            if (ListaMedicos.Count > 0)
            {
                _MedicosApp.UpdateMedicos(new Medicos()
                {
                    Codigo = ListaMedicos[0].Codigo,
                    NumeroCarteira = txtNumeroCarteira.Text,
                    CodEscala = codEscala,
                    status = 1
                });
            }
            else
            {
                _MedicosApp.AddMedicos(new Medicos()
                {
                    CodPessoa = int.Parse(SaberCodigoEnt),
                    NumeroCarteira = txtNumeroCarteira.Text,
                    CodEscala = codEscala,
                     status = 1
                });
            }           

            if(string.IsNullOrEmpty(txtCodEntidade.Text))
            LastCodMedico = _MedicosApp.GetLastIdMedico();
            else 
            {
                ListaMedicos = (List<Medicos>)_MedicosApp.GetMedico(txtCodEntidade.Text);
                CodMedicoEntidade = ListaMedicos[0].Codigo.ToString();
            }
            string saberCodMedico = (CodMedicoEntidade == null) ? (LastCodMedico.ToString()) : (CodMedicoEntidade);

            if (ListaEspecialidade.Count > 0)
            {
                ListaMedicosEspecialidade = new List<MedicosEspecialidades>();
                for (int i = 0; i < ListaEspecialidade.Count; i++)
                {
                    if(ListaEspecialidade[i].Codigo==0)
                    ListaMedicosEspecialidade.Add(new MedicosEspecialidades() {
                        CodEspecialidade = ListaEspecialidade[i].CodEspecialidade,
                        CodMedico = int.Parse(saberCodMedico)
                    });
                }
                
                _MedicosApp.AddMedicoEspecialidade(ListaMedicosEspecialidade);
            }

            GravaContactos();
            GravaMoradas();
            GravaContas();
            GravaDocumentos();
            
        }

        private void GravaContas()
        {
            try
            {
                if (ListaContas.Count > 0)
                {
                    _EntidadesApp.ActualizaContasBancarias(SaberCodigoEnt, ListaContas);
                }

                if (ListaContas.Count == 0) return;
                        
                if(ListaContas.Count>0)
                        _EntidadesApp.InserirContasBancarias(SaberCodigoEnt,ListaContas);                  
            }
            catch (Exception)
            {
                MessageBox.Show("Erro a Gravar Contas Bancárias \n");
            }
        }
        private void GravaContactos()
        {
            try
            {
                if (ListaContactos.Count > 0)
                {
                    _EntidadesApp.ActualizaContactos(SaberCodigoEnt, ListaContactos);
                }

                if (ListaContactos.Count == 0) return;
                
                        if(ListaContactos.Count>0)
                        _EntidadesApp.InserirContactos(SaberCodigoEnt, ListaContactos);                       
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro a Gravar Contactos \n" + ex.Message);
            }
        }
        private void GravaMoradas()
        {
            try
            {
                if (ListaMoradas.Count > 0)
                {
                    _EntidadesApp.ActualizaMoradas(SaberCodigoEnt, ListaMoradas);
                }

                if (ListaMoradas.Count == 0) return;

                        if(ListaMoradas.Count>0)
                        _EntidadesApp.InserirMoradas(SaberCodigoEnt, ListaMoradas);                 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro a Gravar Moradas\n" + ex.Message);
            }
        }
        private void GravaDocumentos()
        {
            try
            {
                if (ListaDocumentos.Count > 0)
                {
                    _EntidadesApp.ActualizaDocumentos(SaberCodigoEnt, ListaDocumentos);
                }

                if (ListaDocumentos.Count == 0) return;
               
                if(ListaDocumentos.Count>0)
                _EntidadesApp.InserirDocumentos(SaberCodigoEnt, ListaDocumentos);
                
            }
            catch (Exception)
            {
                MessageBox.Show("Erro a Gravar Documentos \n");
            }
        }
        #endregion
        //protected bool Valida()
        //{
        //    bool checar = false;

        //    if (String.IsNullOrEmpty(txtEntidade.Text))
        //    {
        //        errorProvider.SetError(txtEntidade, "Por favor preencha o UserName");
        //        checar = true;
        //    }
        //    else
        //        errorProvider.SetError(txtEntidade, null);
        //    return checar;

        //}
        private void btnSalvar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (CamposValidos())
            {
                ValidaBotaoSalvar();
                GravarMedico();
                UtilidadesGenericas.Busca.Alterou = true;
            }
        }
        private bool CamposValidos()
        {
            if (string.IsNullOrEmpty(txtEntidade.Text))
            {
                UtilidadesGenericas.MsgShow("Didigite o nome do Medico!");
                return false;
            }
            
            if (string.IsNullOrEmpty(txtHabilitacao.Text))
            {
                UtilidadesGenericas.MsgShow("Didigite o habilitação do Medico!");
                return false;
            }
           
            if (string.IsNullOrEmpty(txtNacionalidade.Text))
            {
                UtilidadesGenericas.MsgShow("Didigite a nacionalidade do Medico!");
                return false;
            }
            if (cboSexo.SelectedIndex <= -1)
            {
                UtilidadesGenericas.MsgShow("Didigite o genero do Medico!");
                return false;
            }
            //if (cboEstadoCivil.SelectedIndex <= -1)
            //{
            //    UtilidadesGenericas.MsgShow("Didigite o estodo do Medico!");
            //    return false;
            //}

            if (UtilidadesGenericas.ListaNula(ListaEspecialidade))
            {
                UtilidadesGenericas.MsgShow("Adicione pelo menos uma Especialidade do Medico!");
                return false;
            }
            if (codEscala <= 0)
            {
                UtilidadesGenericas.MsgShow("Adicione uma Escala do Medico!");
                return false;
            }

            //if (UtilidadesGenericas.ListaNula(LtDocumentos))
            //{
            //    UtilidadesGenericas.MsgShow("Adicione pelo menos um documento do Medico!");
            //    return false;
            //}
            return true;
        }

        private void PicFoto_Click(object sender, EventArgs e)
        {
            
        }

        private void frmMedico_Load(object sender, EventArgs e)
        {
            ListaEscala =(List<Escala>) _EscalaApp.Listar(null);
            for (int i = 0; i < ListaEscala.Count; i++)
            {
                cboEscala.Properties.Items.Add(ListaEscala[i].Descricao);
            }
            cboEscala.SelectedIndex = 0;
            LastCodEntidade =_EntidadesApp.GetCodLastEntity();

            CodEntidade = txtCodEntidade.Text;
            SaberCodigoEnt = (string.IsNullOrEmpty(txtCodEntidade.Text)) ? (LastCodEntidade.ToString()) : (txtCodEntidade.Text);
        }

        private void btnPessoa_Click(object sender, EventArgs e)
        {
            navigationFrame1.SelectedPage = navigationPage_Pessoas;
        }

        private void btnContacto_Click(object sender, EventArgs e)
        {
            navigationFrame1.SelectedPage = navigationPage_Contactos;
        }

        private void btnContasBancarias_Click(object sender, EventArgs e)
        {
            navigationFrame1.SelectedPage = navigationPage_ContaBancaria;
        }

        private void btnMoradas_Click(object sender, EventArgs e)
        {
            navigationFrame1.SelectedPage = navigationPage_Morada;
        }

        private void btnContactos_Click(object sender, EventArgs e)
        {
            frmEntidadesContactos frmContact = new frmEntidadesContactos();
            frmContact.ShowDialog();


            ContactoViewModel RecebeDados = new ContactoViewModel()
            {
                Codigo = frmContact.Contacto.codigo.ToString(),
                CodEntidade = SaberCodigoEnt,
                Descricao = frmContact.Contacto.descricao,
                CodTipoContacto = frmContact.Contacto.CodTipoContacto.ToString(),
                TipoContacto = frmContact.Contacto.Tipo.descricao
            };
            if (RecebeDados.Descricao == "Nenhum") return;
            ListaContactos.Add(RecebeDados);
            gradeContactos.DataSource = null;
            gradeContactos.DataSource = ListaContactos;
        }

        private void btnContaBancaria_Click(object sender, EventArgs e)
        {
            var form = new frmEntidadeContaBancaria();
            var conta = form.GetConta();
            for (int i = 0; i < ListaContas.Count; i++)
            {
                if ((ListaContas[i].Banco == conta.Banco.descricao) && (ListaContas[i].Numero==conta.Numero)) { MessageBox.Show("Registo já existente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            }
            EntidadeContaViewModel RecebeDados = new EntidadeContaViewModel()
            {
                Codigo = conta.codigo.ToString(),
                CodBanco = conta.CodBanco.ToString(),
                Banco = conta.Banco.descricao,
                Numero = conta.Numero,
                Natureza = conta.Natureza,
                Sequencia = conta.Sequencia,
                Iban = conta.iban,
                Swift = conta.swift
            };
            if (RecebeDados.Natureza == "Nenhum") return;
            ListaContas.Add(RecebeDados);
            gradeConta.DataSource = null;
            gradeConta.DataSource = ListaContas;
        }

        private void btnMorada_Click(object sender, EventArgs e)
        {
            var formMorada = IOC.InjectForm<frmMorada>();
            var Morada = formMorada.GetMorada();
            if (Morada.DescricaoMorada == "Nenhuma") return;
            ListaMoradas.Add(Morada);
            gradeMorada.DataSource = null;
            gradeMorada.DataSource = ListaMoradas;
        }

        private void cboSexo_SelectedIndexChanged(object sender, EventArgs e)
        {
                CodSexo = (cboSexo.Text == "MASCULINO") ? 1 : 2;
        }

        private void cboEstadoCivil_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void navigationPage_Pessoas_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnDocumentos_Click(object sender, EventArgs e)
        {
            var formDocument = IOC.InjectForm<frmDocumentos>();
            var Document = formDocument.GetDocumento();
            if ((Equals(Document, null)))
            {
                return;
            }
            DocumentoEntidadeViewModel RecebeDados = new DocumentoEntidadeViewModel()
            {
                Codigo = Document.codigo.ToString(),
                CodTipoDocumento = Document.CodTipoDocumento.ToString(),
                TipoDocumento = Document.Tipo.descricao,
                Numero = Document.Numero,
                Emissao = Convert.ToDateTime(Document.Emissao),
                Validade = Convert.ToDateTime(Document.Validade)
            };
            if (RecebeDados.TipoDocumento== "Nenhum") return;
            ListaDocumentos.Add(RecebeDados);
            gradeDocumentos.DataSource = null;
            gradeDocumentos.DataSource = ListaDocumentos;
        }

        private void btnDocumento_Click(object sender, EventArgs e)
        {
            navigationFrame1.SelectedPage = navigationPage_Documentos;
        }

        private void panelFields_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnNovaEspecialidade_Click(object sender, EventArgs e)
        {
            try
            {
                var formEspecialidade = IOC.InjectForm<frmInteligente>().GetSelecionado<Especialidades>("Especialidades", "Especialidades");
                if (!Equals(formEspecialidade, null))
                {
                    for (int i = 0; i < ListaEspecialidade.Count; i++)
                    {
                        if (ListaEspecialidade[i].Descricao.ToUpper() == formEspecialidade.Descricao.ToUpper()) { MessageBox.Show("Registo já existente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                    }
                    ListaEspecialidade.Add(new MedicoEspecialidadeViewModel() { Codigo = 0, CodEspecialidade = formEspecialidade.Codigo, Descricao = formEspecialidade.Descricao });

                    gradeEspecialidade.DataSource = null;
                    gradeEspecialidade.DataSource = ListaEspecialidade;
                }
            }
            catch (Exception) { }
        }

        private void btnEspecialidades_Click(object sender, EventArgs e)
        {
            navigationFrame1.SelectedPage = navigationPage_Especialidades;
        }

        private void gridEspecialidade_DoubleClick(object sender, EventArgs e)
        {
           
        }

        private void gridContactos_DoubleClick(object sender, EventArgs e)
        {
            try
            {
            var indexCurrent = UtilidadesGenericas.GetGridIndexCurrent(sender, MousePosition);
            frmEntidadesContactos formContact = new frmEntidadesContactos();
            var contactoCurrent = ListaContactos[indexCurrent];

            var ContactoEditado = formContact.EditarContacto(new ContactosViewModel() {
                CodTipoContacto = int.Parse(contactoCurrent.CodTipoContacto),
                Tipo = new TipoContactoViewModel() { descricao = contactoCurrent.TipoContacto,
                    codigo = int.Parse(contactoCurrent.CodTipoContacto) },
                descricao = contactoCurrent.Descricao, CodEntidade = int.Parse(txtCodEntidade.Text)
            });

            ListaContactos[indexCurrent].TipoContacto = ContactoEditado.Tipo.descricao;
            ListaContactos[indexCurrent].Descricao = ContactoEditado.descricao;
            gradeContactos.DataSource = null;
            gradeContactos.DataSource = ListaContactos;
            }
            catch (Exception) { }

        }

        private void gridContaBancaria_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                var indexCurrent = UtilidadesGenericas.GetGridIndexCurrent(sender, MousePosition);
            var form = new frmEntidadeContaBancaria();
            var contactoCurrent = ListaContas[indexCurrent];
            var ContaEditada = form.EditarContacta(new Domain.ViewModels.Entidades.EntidadesContasViewModel()
            {
               Banco = new BancosViewModel()
               {
                   descricao = ListaContas[indexCurrent].Banco,
                   codigo = int.Parse(ListaContas[indexCurrent].CodBanco)
               },
               Numero= ListaContas[indexCurrent].Numero,
               Natureza= ListaContas[indexCurrent].Natureza,
               Sequencia = ListaContas[indexCurrent].Sequencia,
               iban= ListaContas[indexCurrent].Iban,
               swift= ListaContas[indexCurrent].Swift
            });
          
            ListaContas[indexCurrent].Banco = ContaEditada.Banco.descricao;
            ListaContas[indexCurrent].Numero = ContaEditada.Numero;
            ListaContas[indexCurrent].Natureza = ContaEditada.Natureza;
            ListaContas[indexCurrent].Sequencia = ContaEditada.Sequencia;
            ListaContas[indexCurrent].Iban = ContaEditada.iban;
            ListaContas[indexCurrent].Swift = ContaEditada.swift;

            gradeConta.DataSource = null;
            gradeConta.DataSource = ListaContas;
            }
            catch (Exception) { }
        }

        private void gridMoradas_DoubleClick(object sender, EventArgs e)
        {
            try
            { 
            var indexCurrent = UtilidadesGenericas.GetGridIndexCurrent(sender, MousePosition);
            var formMorada = IOC.InjectForm<frmMorada>();
            var MoradaEditada = formMorada.EditarMorada(new MoradaViewModel()
            {
                DescricaoMorada = ListaMoradas[indexCurrent].DescricaoMorada
            });

            ListaMoradas[indexCurrent].DescricaoMorada = MoradaEditada.DescricaoMorada;
            gradeMorada.DataSource = null;
            gradeMorada.DataSource = ListaMoradas;
        }
            catch (Exception) { }
}

        private void gridDocumentos_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            indexGridDocumento = e.RowHandle;
        }

        private void btndelDocumentos_Click(object sender, EventArgs e)
        {
            if (indexGridDocumento == -1) {MessageBox.Show("Selecione uma linha!", "Documentos", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if(ListaDocumentos[indexGridDocumento].Codigo!="0")
            { 
                try
                {
                    _EntidadesApp.DeleteDocumentos(new List<DocumentoEntidadeViewModel>() { ListaDocumentos[indexGridDocumento] });
                }
                catch (Exception)
                {
                    //MessageBox.Show("Erro a Deletar Morada\n");
                }
            }
            ListaDocumentos.RemoveAt(indexGridDocumento);
            gradeDocumentos.DataSource = null;
            gradeDocumentos.DataSource = ListaDocumentos;
            indexGridDocumento = -1;
        }

        private void gridContactos_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {           
            indexGridContactos = e.RowHandle;
        }

        private void btnDelContactos_Click(object sender, EventArgs e)
        {
            if (indexGridContactos == -1) { MessageBox.Show("Selecione uma linha!", "Contactos", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (ListaContactos[indexGridContactos].Codigo != "0")
            { 
                try
                {
                    _EntidadesApp.DeleteContactos(new List<ContactoViewModel>() { ListaContactos[indexGridContactos] });
                }
                catch (Exception)
                {
                     //MessageBox.Show("Erro a Deletar Contacto \n");
                }
            }
            ListaContactos.RemoveAt(indexGridContactos);
            gradeContactos.DataSource = null;
            gradeContactos.DataSource = ListaContactos;
            indexGridContactos = -1;
        }

        private void gridMoradas_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            indexGridMoradas= e.RowHandle;
        }

        private void btnDeleteMorada_Click(object sender, EventArgs e)
        {
            if (indexGridMoradas == -1) { MessageBox.Show("Selecione uma linha!", "Moradas", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
           if (ListaMoradas[indexGridMoradas].IDMorada != 0)
            { 
                try
                {
                    _EntidadesApp.DeleteMoradas(new List<MoradaViewModel>() { ListaMoradas[indexGridMoradas] });
                }
                catch (Exception)
                {
                    MessageBox.Show("Erro a Deletar Morada\n");
                }
            }

            ListaMoradas.RemoveAt(indexGridMoradas);
            gradeMorada.DataSource = null;
            gradeMorada.DataSource = ListaMoradas;
            indexGridMoradas = -1;
        }

        private void btnDeleteEspecialidade_Click(object sender, EventArgs e)
        {
            if (indexGridEspecialidade== -1) { MessageBox.Show("Selecione uma linha!", "Moradas", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if(ListaEspecialidade[indexGridEspecialidade].Codigo!=0)
            { 
                try
                {
                    _MedicosApp.DeleteListEspecialidade(new List<MedicoEspecialidadeViewModel>() { ListaEspecialidade[indexGridEspecialidade] });
                }
                catch (Exception)
                {
                    MessageBox.Show("Erro a Deletar Especialidade\n");
                }
            }
            ListaEspecialidade.RemoveAt(indexGridEspecialidade);
            gradeEspecialidade.DataSource = null;
            gradeEspecialidade.DataSource = ListaEspecialidade;
            indexGridEspecialidade = -1;
        }

        private void gridEspecialidade_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            indexGridEspecialidade = e.RowHandle;
        }

        private void gridContaBancaria_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            indexGridContaBancaria = e.RowHandle;
        }

        private void btnDeleteConta_Click(object sender, EventArgs e)
        {
            if (indexGridContaBancaria == -1) { MessageBox.Show("Selecione uma linha!", "Moradas", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (ListaContas[indexGridContaBancaria].Codigo != "0")
            { 
                try
                {
                    _EntidadesApp.DeleteContasBancarias(new List<EntidadeContaViewModel>() { ListaContas[indexGridContaBancaria] });
                }
                catch (Exception)
                {
                    MessageBox.Show("Erro a Deletar Conta Bancária\n");
                }
            }
            ListaContas.RemoveAt(indexGridContaBancaria);
            gradeConta.DataSource = null;
            gradeConta.DataSource = ListaContas;
            indexGridContaBancaria = -1;
        }

        private void btnSvFechar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (CamposValidos())
            {
                ValidaBotaoSalvar();
                GravarMedico();
                UtilidadesGenericas.Busca.Alterou = true;
                Close();
            }
        }

        private void btnVoltar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void txtEntidade_Validating(object sender, CancelEventArgs e)
        {
        }

        private void chkEscalaIndefinida_CheckedChanged(object sender, EventArgs e)
        {
            if(chkEscalaIndefinida.Checked==true)
            {
                cboEscala.SelectedItem =  "INDEFINIDA";
                cboEscala.Text= "INDEFINIDA";
                cboEscala.SelectedIndex = 2;
                gradeDias.DataSource = null;
                cboEscala.Enabled = false;
                gradeDias.Enabled = false;
                codEscala = 3;
            }
            else
            {
                cboEscala.SelectedItem= "NORMAL";
                cboEscala.Enabled = true;
                gradeDias.Enabled = true; 
                codEscala = 1;

                gradeDias.DataSource = null;
                gradeDias.DataSource = _EscalaApp.ListEscalaConfig("1");
            }
        }

        private void cboEscala_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboEscala.SelectedIndex!=-1)
            codEscala = ListaEscala[cboEscala.SelectedIndex].Codigo;
            gradeDias.DataSource = null;
            gradeDias.DataSource = _EscalaApp.ListEscalaConfig(codEscala.ToString());
        }

        private void btnEscala_Click(object sender, EventArgs e)
        {
            navigationFrame1.SelectedPage = navigationPage_Escala;
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Imprimir();
        }
        private void Imprimir()
        {
            _Medico = new RelMedicoViewModel()
            {
                Nome = AllEntidade.Nome,
                DataNascimento = AllEntidade.DataNascimento,
                Sexo = cboSexo.Text,
                NomePai = AllEntidade.NomePai,
                NomeMae = AllEntidade.NomeMae,
                Nacionalidade =  txtNacionalidade.Text ,
                Foto = AllEntidade.Foto,
                EstadoCivil = cboEstadoCivil.Text,
                Contribuinte = txtContribuinte.Text,
                Morada = (gridMoradas.RowCount > 0) ? (gridMoradas.GetRowCellValue(0, "DescricaoMorada").ToString()) : (""),
                Contacto1 = (gridContactos.RowCount > 0) ? (gridContactos.GetRowCellValue(0, "descricao").ToString()) : (""),
                Contacto2 = (gridContactos.RowCount > 1) ? (gridContactos.GetRowCellValue(1, "descricao").ToString()) : (""),
                NumeroCarteira=txtNumeroCarteira.Text
            };
            new frmApresentaReport().ApresentarRelFichaMedico(_Medico, ListaEspecialidade);
        }
    }
}