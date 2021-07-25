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
using DevExpress.XtraBars;
using System.ComponentModel.DataAnnotations;
using Folha.Presentation.Desktop.Separadores.Entidades;
using Folha.Driver.Framework.IOC;
using Folha.Domain.ViewModels.Frame.Entidades;
using Folha.Domain.Interfaces.Application.Entidades;
using Folha.Domain.Helpers;
using Folha.Presentation.Desktop.Forms.Principal;
using Folha.Domain.Models.Entidades;
using Folha.Domain.Models.Genericos;
using Folha.Domain.ViewModels.Entidades;
using Folha.Domain.Interfaces.Application.Genericos;
using Folha.Domain.Interfaces.Application.Escolar;
using Folha.Domain.Models.Escolar;
using Folha.Domain.ViewModels.Escolar;

namespace Folha.Presentation.Desktop.Separadores.Gestao_Escolar
{
    public partial class frmAluno : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private int _codEntidade;
        private readonly IEntidadesApp _EntidadesApp;
        private AllEntidadeViewModel AllEntidade;
        private int codHabilitacoes;
        private int codPais;
        private int codProfissao;
        private List<ContactoViewModel> ListaContactos=new List<ContactoViewModel>();
        private List<MoradaViewModel> ListaMoradas= new List<MoradaViewModel>();
        private List<DocumentoEntidadeViewModel> ListaDocumentos= new List<DocumentoEntidadeViewModel>();
        private readonly IGenericoApp _GenericoApp;
        private int Activo;
        private readonly IAlunosApp _AlunosApp;
        private readonly IEntidadePessoaApp _EntidadePessoaApp;
        private int LastCodEntidade;
        bool AlunoExistente=false;
        private int codAluno;
        private List<PagamentoPropinaViewModel> LtPagamentos;
        private List<AlunoCursoViewModel> LtCusrsos;

        public frmAluno(IEntidadesApp EntidadesApp,IGenericoApp GenericoApp,IAlunosApp AlunosApp, IEntidadePessoaApp EntidadePessoaApp)
        {
            InitializeComponent();
            _EntidadesApp = EntidadesApp;
            _GenericoApp = GenericoApp;
            _AlunosApp = AlunosApp;
            _EntidadePessoaApp = EntidadePessoaApp;
            navigationFrame1.SelectedPage = navigationPage_DadosPessoais;
        }
      

        private void btnNome_Click(object sender, EventArgs e)
        {
            var formEntidadeBusca = IOC.InjectForm<frmEntidadeBusca>();
            var entitdade = formEntidadeBusca.GetEntidadeSelecionada(1);
            _codEntidade = entitdade.Codigo;
            if (entitdade.CodTipo == 2) { MessageBox.Show("Selecione Apenas Entidade Física", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            //verifica se aluno já existe
            AlunoExistente = _GenericoApp.VerificarRegisto("Alunos", "CodEntidade", _codEntidade.ToString());
            if (AlunoExistente) { MessageBox.Show("Aluno já registrado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if(_codEntidade!=0)
            Carregamentos(_codEntidade.ToString());

        }
        private void Carregamentos(string CodEntidade)
        {
            CarregaCampos(CodEntidade);
            CarregaContactos(CodEntidade);
            CarregaMorada(CodEntidade);
            CarregaDocumento(CodEntidade);
            if (codAluno > 0)
            {
                CarregaPagamentos();
                CarregaConfirmacao(CodEntidade);

            }
                

        }

        private void CarregaCampos(string CodEntidade)
        {
            //if (Editar)
            //    btnNome.Enabled = false;
            AllEntidade = _EntidadesApp.ListEntidadeGetAll(CodEntidade);
            txtCodEntidade.Text = _codEntidade.ToString();
            txtNome.Text = AllEntidade.Nome;
            txtPai.Text = AllEntidade.NomePai;
            txtContribuinte.Text = AllEntidade.Nif;
            dtNascimento.EditValue = AllEntidade.DataNascimento;
            txtNacionalidade.Text = AllEntidade.Nacionalidade;
            cboSexo.SelectedItem = AllEntidade.Sexo;
            cboEstadoCivil.SelectedItem = AllEntidade.EstadoCivil;
            txtHabilitacao.Text = AllEntidade.Habilitacao;
            txtPai.Text = AllEntidade.NomePai;
            txtMae.Text = AllEntidade.NomeMae;
            txtProfissao.Text = AllEntidade.Profissao;
            txtLimiteDebito.Text = AllEntidade.Limite.ToString("N2");

            codPais = int.Parse(AllEntidade.CodPais);
            codHabilitacoes = int.Parse(AllEntidade.CodHabilitacao);
            codProfissao = int.Parse(AllEntidade.CodProfissao);


            try
            {
                PicFoto.Image = Imagens.Byte_Imagem(AllEntidade.Foto);
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }
        private void CarregaContactos(string CodEntidade)
        {
            //gradeContactos.DataSource = ListaContactos = (List<ContactoViewModel>)_EntidadesApp.Ca(CodEntidade);
        }
        private void CarregaMorada(string CodEntidade)
        {
            gradeMorada.DataSource = ListaMoradas = (List<MoradaViewModel>)_EntidadesApp.CarregaMorada(CodEntidade);
        }
        private void CarregaDocumento(string CodEntidade)
        {
            gradeDocumentos.DataSource = ListaDocumentos = (List<DocumentoEntidadeViewModel>)_EntidadesApp.CarregaDocumentos(CodEntidade);
        }
        private void CarregaPagamentos()
        {
                LtPagamentos = (List<PagamentoPropinaViewModel>)_AlunosApp.ListarPagamento(codAluno);
                gradePagamentos.DataSource = LtPagamentos;

        }
         public void CarregaConfirmacao(string CodEntidade)
        {
            LtCusrsos = (List<AlunoCursoViewModel>)_AlunosApp.ListarConfirmacao(CodEntidade);
            gradeCursos.DataSource = LtCusrsos;
        }
        private void btnFechar_ItemClick(object sender, ItemClickEventArgs e)
        {
           Close();
        }

        private void btnDadosPessoais_Click(object sender, EventArgs e)
        {
            navigationFrame1.SelectedPage = navigationPage_DadosPessoais;
        }

        private void btnCursos_Click(object sender, EventArgs e)
        {
            navigationFrame1.SelectedPage = navigationPage_Cursos;
        }

        private void btnPagamentos_Click(object sender, EventArgs e)
        {
            navigationFrame1.SelectedPage = navigationPage_Pagamentos;
        }

        private void btnMaisHabilitacoes_Click(object sender, EventArgs e)
        {
            var habilitacao = IOC.InjectForm<frmInteligente>().GetSelecionado<Habilitacoes>("Habilitacoes", "Habilitações");
            if (Equals(habilitacao, null))
            {
                return;
            }
            codHabilitacoes = habilitacao.Codigo;
            txtHabilitacao.Text = habilitacao.Descricao;
        }

        private void btnMaisNacionalidade_Click(object sender, EventArgs e)
        {
            var pais = IOC.InjectForm<frmInteligente>().GetSelecionado<Pais>("Pais", "Paises");
            if (Equals(pais, null))
            {
                return;
            }
            codPais = pais.codigo;
            txtNacionalidade.Text = pais.Descricao;
        }

        private void btnProfissao_Click(object sender, EventArgs e)
        {
            var profissao = IOC.InjectForm<frmInteligente>().GetSelecionado<Profissao>("Profissao", "Profissões");
            if (Equals(profissao, null))
            {
                return;
            }
            codProfissao = profissao.Codigo;
            txtProfissao.Text = profissao.Descricao;
        }

        private void btnDocumentos_Click(object sender, EventArgs e)
        {
            navigationFrame1.SelectedPage = navigationPage_Documentos;
        }

        private void btnContactos_Click(object sender, EventArgs e)
        {
            navigationFrame1.SelectedPage = navigationPage_Contactos;
        }

        private void btnMorada_Click(object sender, EventArgs e)
        {
            navigationFrame1.SelectedPage = navigationPage_Moradas;
        }

        private void btnAddDocumentos_Click(object sender, EventArgs e)
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
            if (RecebeDados.TipoDocumento == "Nenhum") return;
            ListaDocumentos.Add(RecebeDados);
            gradeDocumentos.DataSource = null;
            gradeDocumentos.DataSource = ListaDocumentos;
        }

        private void btnAddMorada_Click(object sender, EventArgs e)
        {
            var formMorada = IOC.InjectForm<frmMorada>();
            var Morada = formMorada.GetMorada();
            if (Morada.DescricaoMorada == "Nenhuma") return;
            ListaMoradas.Add(Morada);
            gradeMorada.DataSource = null;
            gradeMorada.DataSource = ListaMoradas;
        }

        private void btnAddContactos_Click(object sender, EventArgs e)
        {
            frmEntidadesContactos frmContact = new frmEntidadesContactos();
            frmContact.ShowDialog();


            ContactoViewModel RecebeDados = new ContactoViewModel()
            {
                Codigo = frmContact.Contacto.codigo.ToString(),
                CodEntidade = _codEntidade.ToString(),
                Descricao = frmContact.Contacto.descricao,
                CodTipoContacto = frmContact.Contacto.CodTipoContacto.ToString(),
                TipoContacto = frmContact.Contacto.Tipo.descricao
            };
            if (RecebeDados.Descricao == "Nenhum") return;
            ListaContactos.Add(RecebeDados);
            gradeContactos.DataSource = null;
            gradeContactos.DataSource = ListaContactos;
        }
        private void GravarAluno()
        {
            byte[] logotipo = new byte[1];
            if (PicFoto.Image != null) logotipo = Imagens.Imagem_Byte(PicFoto.Image);

            AllEntidadeViewModel DadosEntidades = new AllEntidadeViewModel()
            {
                Codigo = (!string.IsNullOrEmpty(txtCodEntidade.Text)) ? (int.Parse(txtCodEntidade.Text)) : (0),
                Nome = txtNome.Text,
                Nif = txtContribuinte.Text,
                CodPais = codPais.ToString(),
                Foto = logotipo,
                Limite=Convert.ToDouble(txtLimiteDebito.Text)
            };

            EntidadesPessoaViewModel DadosEntidadePessoa = new EntidadesPessoaViewModel()
            {
                //CodEntidade = (!string.IsNullOrEmpty(txtCodEntidade.Text)) ? (int.Parse(txtCodEntidade.Text)) : (LastCodEntidade),
                CodSexo = cboSexo.SelectedIndex + 1,
                CodEstadoCivil = cboEstadoCivil.SelectedIndex + 1,
                DataNascimento = dtNascimento.Text,
                CodHabilitacao = codHabilitacoes,
                CodProfissao = codProfissao,
                NomePai = txtPai.Text,
                NomeMae = txtMae.Text
            };

            if (!string.IsNullOrEmpty(txtCodEntidade.Text) && AlunoExistente)
            {
                DadosEntidadePessoa.CodEntidade = _codEntidade;
                _EntidadesApp.UpdateEntidade(DadosEntidades);
                _EntidadePessoaApp.Update(DadosEntidadePessoa);
            }
            else if (string.IsNullOrEmpty(txtCodEntidade.Text))
            {
                _EntidadesApp.InserirEntidade(DadosEntidades);

                LastCodEntidade = _EntidadesApp.GetCodLastEntity();
                _codEntidade = LastCodEntidade;
                DadosEntidadePessoa.CodEntidade = _codEntidade;

                _EntidadePessoaApp.Insert(DadosEntidadePessoa);
            }

            int Activo = 1;
            bool VerificaAluno = _GenericoApp.VerificarRegisto("Alunos", "CodEntidade", _codEntidade.ToString());
            if (chkAluno.Checked == false) { Activo = 0; }

            if (!VerificaAluno)
            {
                //string x = Geral.ClienteSql.INSERT("Alunos", Campos, Valores);
                _AlunosApp.Insert(new Alunos() { CodEntidade = _codEntidade, status = Activo, DataRegisto = DateTime.Now.ToString("yyyy-MM-dd") });
            }
            else
                _AlunosApp.Update(new Alunos() { Codigo = codAluno, status = Activo });


            GravaContactos();
            GravaMoradas();
            GravaDocumentos();
            UtilidadesGenericas.Busca.Alterou = true;
            Close();
        }
       
        private void GravaContactos()
        {
            try
            {
                if (ListaContactos.Count > 0)
                {
                    _EntidadesApp.ActualizaContactos(_codEntidade.ToString(), ListaContactos);
                }

                if (ListaContactos.Count == 0) return;

                if (ListaContactos.Count > 0)
                    _EntidadesApp.InserirContactos(_codEntidade.ToString(), ListaContactos);
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
                    _EntidadesApp.ActualizaMoradas(_codEntidade.ToString(), ListaMoradas);
                }

                if (ListaMoradas.Count == 0) return;

                if (ListaMoradas.Count > 0)
                    _EntidadesApp.InserirMoradas(_codEntidade.ToString(), ListaMoradas);
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
                    _EntidadesApp.ActualizaDocumentos(_codEntidade.ToString(), ListaDocumentos);
                }

                if (ListaDocumentos.Count == 0) return;

                if (ListaDocumentos.Count > 0)
                    _EntidadesApp.InserirDocumentos(_codEntidade.ToString(), ListaDocumentos);

            }
            catch (Exception)
            {
                MessageBox.Show("Erro a Gravar Documentos \n");
            }
        }

        public void EditarAluno(AlunosViewModel Dados)
        {
            AlunoExistente = _GenericoApp.VerificarRegisto("Alunos", "CodEntidade", Dados.CodEntidade.ToString());
            codAluno = Dados.Codigo;
            txtCodEntidade.Text = Dados.CodEntidade.ToString();
            txtNome.Text = Dados.Nome;
            _codEntidade = Dados.CodEntidade;
            if (Dados.status == 1)
                chkAluno.Checked = true;
            else
                chkAluno.Enabled = false;

            Carregamentos(_codEntidade.ToString());
            //btnPrint.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnNome.Enabled = false;
            ShowDialog();
            Close();
        }
        private bool CamposValidos()
        {
            if (string.IsNullOrEmpty(txtNome.Text))
            {
                UtilidadesGenericas.MsgShow("Didigite o nome do Aluno!");
                return false;
            }

            if (string.IsNullOrEmpty(txtHabilitacao.Text))
            {
                UtilidadesGenericas.MsgShow("Didigite o habilitação do Aluno!");
                return false;
            }

            if (string.IsNullOrEmpty(txtNacionalidade.Text))
            {
                UtilidadesGenericas.MsgShow("Didigite a nacionalidade do Aluno!");
                return false;
            }
            if (cboSexo.SelectedIndex <= -1)
            {
                UtilidadesGenericas.MsgShow("Didigite o genero do Aluno!");
                return false;
            }
            //if (cboEstadoCivil.SelectedIndex <= -1)
            //{
            //    UtilidadesGenericas.MsgShow("Didigite o estodo do Medico!");
            //    return false;
            //}


            //if (UtilidadesGenericas.ListaNula(LtDocumentos))
            //{
            //    UtilidadesGenericas.MsgShow("Adicione pelo menos um documento do Medico!");
            //    return false;
            //}
            return true;
        }
        private void btnSalvarFechar_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (CamposValidos())
                GravarAluno();
        }

        private void frmDadosAluno_Load(object sender, EventArgs e)
        {
            txtLimiteDebito.Text = "0,00";
        }

        private void gridContactos_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                var indexCurrent = UtilidadesGenericas.GetGridIndexCurrent(sender, MousePosition);
                frmEntidadesContactos formContact = new frmEntidadesContactos();
                var contactoCurrent = ListaContactos[indexCurrent];

                var ContactoEditado = formContact.EditarContacto(new ContactosViewModel()
                {
                    CodTipoContacto = int.Parse(contactoCurrent.CodTipoContacto),
                    Tipo = new TipoContactoViewModel()
                    {
                        descricao = contactoCurrent.TipoContacto,
                        codigo = int.Parse(contactoCurrent.CodTipoContacto)
                    },
                    descricao = contactoCurrent.Descricao,
                    CodEntidade = int.Parse(txtCodEntidade.Text)
                });

                ListaContactos[indexCurrent].TipoContacto = ContactoEditado.Tipo.descricao;
                ListaContactos[indexCurrent].Descricao = ContactoEditado.descricao;
                gradeContactos.DataSource = null;
                gradeContactos.DataSource = ListaContactos;
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

        private void gridDocumentos_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                var indexCurrent = UtilidadesGenericas.GetGridIndexCurrent(sender, MousePosition);
                var formDocument = IOC.InjectForm<frmDocumentos>();
                var Document = formDocument.EditarDocumneto(new DocumentosEntidadeViewModel()
                {
                    Numero= ListaDocumentos[indexCurrent].Numero,
                    Emissao= ListaDocumentos[indexCurrent].Emissao.ToShortDateString(),
                    Validade= ListaDocumentos[indexCurrent].Validade.ToShortDateString(),
                    Tipo=new TiposDocumentosViewModel() { descricao= ListaDocumentos[indexCurrent].TipoDocumento},
                    CodTipoDocumento = int.Parse(ListaDocumentos[indexCurrent].CodTipoDocumento)

                });
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
                if (RecebeDados.TipoDocumento == "Nenhum") return;

                ListaDocumentos[indexCurrent].CodTipoDocumento = RecebeDados.CodTipoDocumento;
                ListaDocumentos[indexCurrent].TipoDocumento = RecebeDados.TipoDocumento;
                ListaDocumentos[indexCurrent].Numero = RecebeDados.Numero;
                ListaDocumentos[indexCurrent].Emissao = RecebeDados.Emissao;
                ListaDocumentos[indexCurrent].Validade = RecebeDados.Validade;
                gradeDocumentos.DataSource = null;
                gradeDocumentos.DataSource = ListaDocumentos;
            }
            catch (Exception) { }
        }
    }
}