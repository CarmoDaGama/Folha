using System;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraBars;
using Folha.Presentation.Desktop.Separadores.Recursos_Humanos;
using Folha.Presentation.Desktop.Separadores.Empresa;
using Classe.Validacao;
using Folha.Domain.Interfaces.Application.Entidades;
using Folha.Domain.Models.Entidades;
using Folha.Domain.Helpers;
using Folha.Domain.Enuns.Entidades;
using Folha.Domain.Enuns.Genericos;
using Folha.Driver.Framework.IOC;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using System.Collections.Generic;
using Folha.Domain.ViewModels.Entidades;
using Folha.Presentation.Desktop.Forms.Principal;
using Folha.Domain.Models.Genericos;
using DevExpress.XtraGrid.Views.Grid;
using Folha.Domain.ViewModels.Frame.Entidades;
using Folha.Domain.Interfaces.Application.Documentos;
using System.Linq;
using Folha.Presentation.Desktop.Forms.Documentos;
using Folha.Domain.Models.Documentos;
using Folha.Presentation.Desktop.Separadores.Principal;

namespace Folha.Presentation.Desktop.Separadores.Entidades
{
    public partial class frmEntidade : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly IEntidadesApp _EntidadesApp;
        private readonly IFornecedoresApp FornecedorApp;
        private readonly IFuncionariosApp FuncionariosApp;
        private readonly ICondicoesPagamentoApp _condicoes;
        private int codHabilitacao;
        private int codProfissao;
        private int valueFuncionario = 0;
        private int valueFornecedor = 0;
        private int codPais;
        private TypeEntity TipoEntidade;
        private bool validForSave;
        private int indexContacto = -1;
        private int indexConta = -1;
        private int indexDocument = -1;
        private int indexMorada = -1;

        private CRUD TipoOperacao { get; set; }
        private EntidadesViewModel Entity { get; set; }
        public bool Changed { get; private set; }

        public frmEntidade(
            IEntidadesApp EntidadesApp,
            IFornecedoresApp fornecedoresApp,
            IFuncionariosApp funcionariosApp,
            ICondicoesPagamentoApp condicoes)
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;

            _EntidadesApp = EntidadesApp;
            FornecedorApp = fornecedoresApp;
            FuncionariosApp = funcionariosApp;
            _condicoes = condicoes;
            var codicao = ((List<CondicoesPagamento>)_condicoes.Listar(null, false)).FirstOrDefault();
            Entity = new EntidadesViewModel()
            {
                CodCondicaoPagamento = codicao.Codigo,
                Condicao = new CondicoesPagamentosViewModel()
                {
                    Codigo = codicao.Codigo,
                    Descricao = codicao.Descricao,
                    Dias = codicao.Dias
                }
            };
            gradeContactos.DataSource = Entity.Contactos;
            validacao();
            Permicao();
        }
        #region Permicao de Acesso
        int VerficaUsuario = int.Parse(UtilidadesGenericas.UsuarioPerfil.ToString());
        private void Permicao()
        {
            if (VerficaUsuario != 1)
            {
                if (UtilidadesGenericas.TemAcesso("Administração#Entidades#Alterar") == false) { btnSalvar.Enabled = false; }
                if (UtilidadesGenericas.TemAcesso("Administração#Entidades#Alterar") == false) { btnSalvarFechar.Enabled = false; }
            }
        }
        #endregion

        private void validacao()
        {
            ValidacaoControles.InserirEnventosDeValidacao(txtNome, TipoValidacao.Nome);
            ValidacaoControles.InserirEnventosDeValidacao(txtMaePessoa, TipoValidacao.Nome);
            ValidacaoControles.InserirEnventosDeValidacao(txtPaiPessoa, TipoValidacao.Nome);
        }


        public void SetTipoEntidade(TypeEntity type)
        {
            TipoEntidade = type;
            switch (type)
            {
                case TypeEntity.FUNCIONARIO:
                    //btnFuncionarios.Visible = true;
                    valueFuncionario = 1;
                    break;
                case TypeEntity.FORNECEDOR:
                    //btnFornecedores.Visible = true;
                    valueFornecedor = 1;
                    break;
                case TypeEntity.CLIENTE:
                    break;
                default:
                    break;
            }
        }
        private void CadastrarOuEditar()
        {
            switch (TipoOperacao)
            {
                case CRUD.Cadastro:
                    Text = "Cadastro De Entidade";
                    txtCodCondicao.Text = Entity.CodCondicaoPagamento.ToString();
                    txtDescricaoCondicao.Text = Entity.Condicao.Descricao;
                    break;
                case CRUD.Edição:
                    Text = "Edição De Entidade";
                    loadData();
                    break;
                default:
                    break;
            }
        }

        private void loadData()
        {
            cboTipo.SelectedIndex = Entity.CodTipo - 1;
            if (Entity.Tipo.codigo == 2)
            {
                loadDataJuridica();
            }
            else
            {
                loadDataFisiaca();
            }
            loadDataDependents();
        }

        private void loadDataDependents()
        {
            clearDataSources();
            carregarContactos();
            carregarContas();
            carregarDocumentos();
            gradeMorada.DataSource = Entity.Moradas;
        }

        private void clearDataSources()
        {
            gradeContactos.DataSource = null;
            gradeConta.DataSource = null;
            griadeDocumentos.DataSource = null;
            gradeMorada.DataSource = null;
        }

        private void loadDataFisiaca()
        {
            txtCodNome.Text = Entity.Codigo.ToString();
            txtNome.Text = Entity.Nome;
            txtContribuente.Text = Entity.Nif;
            txtLimiteDebito.Text = Entity.Limite;
            txtCodCondicao.Text = Entity.CodCondicaoPagamento.ToString();
            txtDescricaoCondicao.Text = Entity.Condicao.Descricao;

            textNacionalidade.Text = Entity.Nacionalidade.Descricao;
            codPais = Entity.CodPais;

            PicImagem.Image = Imagens.Byte_Imagem(Entity.Foto);
            if (Entity.Pessoa.CodEntidade <= 0)
            {
                Entity.Tipo.codigo = 2;
                _EntidadesApp.EditEntidade(Entity);
                cboTipo.SelectedIndex = Entity.Tipo.codigo - 1;
                return;
            }
            cboTipo.SelectedIndex = Entity.Tipo.codigo - 1;
            textHabilitacao.Text = Equals(Entity.Pessoa, null) ? "" : Entity.Pessoa.Habilitacao.Descricao;
            codHabilitacao = Equals(Entity.Pessoa, null) ? 0 : Entity.Pessoa.Habilitacao.Codigo;

            textProficao.Text = Equals(Entity.Pessoa, null) ? "" : Entity.Pessoa.Profissao.Descricao;
            codProfissao = Equals(Entity.Pessoa, null) ? 0 : Entity.Pessoa.Profissao.Codigo;

            dateNascimento.EditValue = Equals(Entity.Pessoa, null) ? "" : Entity.Pessoa.DataNascimento;
            txtPaiPessoa.Text = Equals(Entity.Pessoa, null) ? "" : Entity.Pessoa.NomePai;
            txtMaePessoa.Text = Equals(Entity.Pessoa, null) ? "" : Entity.Pessoa.NomeMae;
        }

        private void loadDataJuridica()
        {
            txtCodNome.Text = Entity.Codigo.ToString();
            txtNome.Text = Entity.Nome;
            txtContribuente.Text = Entity.Nif;
            txtLimiteDebito.Text = Entity.Limite;
            txtCodCondicao.Text = Entity.CodCondicaoPagamento.ToString();
            txtDescricaoCondicao.Text = Entity.Condicao.Descricao;
            textNacionalidade.Text = Entity.Nacionalidade.Descricao;
            PicImagem.Image = Imagens.Byte_Imagem(Entity.Foto);
            cboTipo.SelectedItem = Entity.Tipo.ToString();
        }

   

        public frmEntidade EditarEntity(EntidadesViewModel entidade)
        {
            Changed = false;
            TipoOperacao = CRUD.Edição;
            Entity = entidade;
           
            return this;
        }

      



        private void btnMaisHabilitacoes_Click(object sender, EventArgs e)
        {
            var form = IOC.InjectForm<frmInteligente>();
            var habilitacao = form.GetSelecionado<Habilitacoes>("Habilitacoes", "Habilitações");
            if (!Equals(habilitacao, null))
            {
                codHabilitacao = habilitacao.Codigo;
                CodHabilitacoes.Text = codHabilitacao.ToString();
                textHabilitacao.Text = habilitacao.Descricao;
            }
        }

        private void btnProfissao_Click(object sender, EventArgs e)
        {
            var form = IOC.InjectForm<frmInteligente>();
            var profissao = form.GetSelecionado<Profissao>("Profissao", "Profissões");
            if (!Equals(profissao, null))
            {
                codProfissao = profissao.Codigo;
                ProfissaoCod.Text = codProfissao.ToString();
                textProficao.Text = profissao.Descricao;
            }
        }

        private void btnMaisNacionalidade_Click(object sender, EventArgs e)
        {
            var form = IOC.InjectForm<frmInteligente>();
            var pais = form.GetSelecionado<Pais>("Pais", "Paises");
            if (!Equals(pais, null))
            {
                codPais = pais.codigo;
                CodNacionalidade.Text = codPais.ToString();
                textNacionalidade.Text = pais.Descricao;
            }
        }

        private void frmEntidade_Load(object sender, EventArgs e)
        {
            cboTipo.SelectedItem = "PESSOA FÍSICA";
            cboSexoPessoa.SelectedItem = "MASCULINO";
            cboEstadoCivilPessoa.SelectedItem = "SOLTEIRO (A)";
            dateNascimento.Text = DateTime.Now.ToShortDateString();
            dateNascimento.Properties.MaxValue = DateTime.Now;
            CadastrarOuEditar();
            MostrarIdade();

        }

        private void txtNome_EditValueChanged(object sender, EventArgs e)
        {



        }


        private void btnContactos_Click(object sender, EventArgs e)
        {
            frmEntidadesContactos frmContact = new frmEntidadesContactos();
            frmContact.ShowDialog();
            if (UtilidadesGenericas.EntidadeValida(frmContact.Contacto))
            {
                Entity.Contactos.Add(frmContact.Contacto);
                gradeContactos.DataSource = null;
                carregarContactos();
            }
        }

        private void carregarContactos()
        {
            gradeContactos.DataSource = Mapper<ContactosViewModel, ContactViewModel>.Map(Entity.Contactos);
            indexContacto = 0;
        }

        private bool validContact(ContactosViewModel contacto)
        {
            if (Equals(contacto, null))
                return false;

            if (string.IsNullOrEmpty(contacto.descricao))
                return false;

            if (contacto.codigo <= 0)
                return false;

            return true;
        }

        private void btnContaBancaria_Click(object sender, EventArgs e)
        {
            var form = new frmEntidadeContaBancaria();
            var newConta = form.GetConta();
            if (UtilidadesGenericas.EntidadeValida(newConta))
            {
                Entity.Contas.Add(newConta);
                gradeConta.DataSource = null;
                carregarContas();
            }

        }

        private void carregarContas()
        {
            gradeConta.DataSource = Mapper<EntidadesContasViewModel, ContaEntityViewModel>.Map(Entity.Contas);
            indexConta = 0;
        }

        private void btnMorada_Click(object sender, EventArgs e)
        {
            
        }

        private void btnFuncionarios_Click(object sender, EventArgs e)
        {
        }

        private void btnSalvar_ItemClick(object sender, ItemClickEventArgs e)
        {
            validForSave = isFieldsValid();
            if (!validForSave) return;
            Entity = new EntidadesViewModel()
            {
                Codigo = Entity.Codigo,
                Nome = txtNome.Text,
                Foto = Imagens.Imagem_Byte(PicImagem.Image),
                Limite = string.IsNullOrEmpty(txtLimiteDebito.Text) ? string.Empty : txtLimiteDebito.Text,
                Nif = string.IsNullOrEmpty(txtContribuente.Text) ? string.Empty : txtContribuente.Text,
                CodTipo = cboTipo.SelectedIndex + 1,
                CodPais = codPais,
                Fornecedor = valueFornecedor,
                Funcionario = valueFuncionario,
                Cliente = valueFornecedor == 0 && valueFuncionario == 0 ? 1 : 0,
                Contactos = Entity.Contactos,
                Contas = Entity.Contas,
                Moradas = Entity.Moradas,
                Documentos = Entity.Documentos,
                CodCondicaoPagamento = Entity.CodCondicaoPagamento
            };

            if (cboTipo.SelectedIndex == 0)
            {
                Entity.Pessoas.Add(getEntityPessoa());
            }


            if (TipoOperacao == CRUD.Cadastro)
            {
                _EntidadesApp.addEntidade(Entity);
                var codeEntidade = _EntidadesApp.GetCodLastEntity();
                if (!Equals(Entity.Pessoas, null) && Entity.Pessoas.Count > 0)
                {
                    Entity.Pessoas[0].CodEntidade = codeEntidade;
                    _EntidadesApp.SalvarDadosPessoa(Entity.Pessoas[0]);
                }
                saveFornecedorOrFuncionario(codeEntidade);
            }
            else if (TipoOperacao == CRUD.Edição)
            {
                _EntidadesApp.EditEntidade(Entity);
                if (!Equals(Entity.Pessoas, null) && Entity.Pessoas.Count > 0)
                {
                    Entity.Pessoas[0].CodEntidade = Entity.Codigo;
                    _EntidadesApp.EditarDadosPessoa(Entity.Pessoas[0]);
                }

            }
            Changed = true;
            UtilidadesGenericas.Busca.Alterou = true;
            ClearComponents();
        }

        private void saveFornecedorOrFuncionario(int codEntidade)
        {
            switch (TipoEntidade)
            {
                case TypeEntity.CLIENTE:
                    break;
                case TypeEntity.FUNCIONARIO:
                    Funcionarios func = new Funcionarios()
                    {
                        CodEntidade = codEntidade,
                        DataRegisto = DateTime.Now.ToShortDateString(),
                        CodDepartamento = 1,
                    };
                    FuncionariosApp.Add(func);
                    break;
                case TypeEntity.FORNECEDOR:
                    Fornecedores forn = new Fornecedores()
                    {
                        CodEntidade = codEntidade
                    };
                    FornecedorApp.Add(forn);
                    break;
                default:
                    break;
            }
        }

        private bool isFieldsValid()
        {
            bool valid = true;
            if (string.IsNullOrEmpty(txtNome.Text))
            {
                messageShow("Preencha o campo Nome");
                return false;
            }
            if (cboTipo.SelectedIndex == 0)
            {
                //if (string.IsNullOrEmpty(textHabilitacao.Text))
                //{
                //    messageShow("Escolha uma habilitação");
                //    return false;
                //}
                //if (string.IsNullOrEmpty(textProficao.Text))
                //{
                //    messageShow("Escolha uma Profissaõ");
                //    return false;
                //}
                if (cboEstadoCivilPessoa.SelectedIndex <= -1)
                {
                    messageShow("Escolha um Estado civíl");
                    return false;
                }
                if (cboSexoPessoa.SelectedIndex <= -1)
                {
                    messageShow("Escolha um Sexo");
                    return false;
                }
                if (Equals(dateNascimento.EditValue, null))
                {
                    messageShow("Escolha uma Data Nascimeno");
                    return false;
                }
            }
            //if (string.IsNullOrEmpty(textNacionalidade.Text))
            //{
            //    messageShow("Escolha uma Nacionalidade");
            //    return false;
            //}
            //if (Equals(Entity.Documentos, null) || Entity.Documentos.Count == 0)
            //{
            //    messageShow("É obrigatorio Ser adicionado\n pelo menos um documento de identificação");
            //    return false;
            //}

            return valid;
        }

        private bool isCbo(Control item)
        {
            return item.GetType().Name.Contains("ComboBoxEdit");
        }

        private bool isTxt(Control item)
        {
            return item.GetType().Name.Contains("TextEdit");
        }

        private void messageShow(string message)
        {
            MessageBox.Show(
                message,
                "INFORMAÇÃO",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private EntidadesPessoaViewModel getEntityPessoa()
        {
            EntidadesPessoaViewModel pessoa = new EntidadesPessoaViewModel()
            {
                CodSexo = cboSexoPessoa.SelectedIndex + 1,
                CodEstadoCivil = cboEstadoCivilPessoa.SelectedIndex + 1,
                DataNascimento = Convert.ToDateTime(dateNascimento.EditValue).ToShortDateString(),
                CodHabilitacao = codHabilitacao,
                CodProfissao = codProfissao,
                NomePai = txtPaiPessoa.Text,
                NomeMae = txtMaePessoa.Text
            };
            Entity.Tipo = new TipoEntidadeViewModel() { codigo = 1 };
            return pessoa;
        }

        private void ClearComponents()
        {
            cboTipo.SelectedIndex = -1;

            foreach (Control control in panelFields.Controls)
                if (control.Name.Contains("txt"))
                    control.Text = "";

            TipoOperacao = Folha.Domain.Enuns.Genericos.CRUD.Cadastro;

        }

        private void txtPai_Validating_1(object sender, CancelEventArgs e)
        {

        }

        private void txtMae_Validating(object sender, CancelEventArgs e)
        {

        }

        private void txtNome_Validating(object sender, CancelEventArgs e)
        {

        }

        private void btnNovoDocumento_Click(object sender, EventArgs e)
        {
            var formDocument = IOC.InjectForm<frmDocumentos>();
            var newDocument = formDocument.GetDocumento();
            if (UtilidadesGenericas.EntidadeValida(newDocument))
            {
                Entity.Documentos.Add(newDocument);
                griadeDocumentos.DataSource = null;
                carregarDocumentos();
            }
        }

        private void carregarDocumentos()
        {
            griadeDocumentos.DataSource = Mapper<DocumentosEntidadeViewModel, DocEntidadeViewModel>.Map(Entity.Documentos);
            indexDocument = 0;
        }

        private void btnFiliais_Click(object sender, EventArgs e)
        {
            new frmFiliais().ShowDialog();
        }

        private void btnNovoFuncionario_Click(object sender, EventArgs e)
        {
            new frmCadastroContrato().ShowDialog();
        }

        private void btnNovoAgregado_Click(object sender, EventArgs e)
        {
            new frmAgregadosDados().ShowDialog();
        }

        private void btnEditar_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void btnVoltar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void btnSalvarFechar_ItemClick(object sender, ItemClickEventArgs e)
        {
            btnSalvar_ItemClick(sender, e);
            if (validForSave)
                Close();
            frmVerEntidade chamada = IOC.InjectForm<frmVerEntidade>();
            UtilidadesGenericas.ChamarNoPrincipal(chamada);

        }

        private void cboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsPessoaFisica())
            {
                Entity.Tipo = new TipoEntidadeViewModel() { codigo = 1 };
                enableFieldsPessoa(true);
            }
            else
            {
                Entity.Tipo = new TipoEntidadeViewModel() { codigo = 2 };
                enableFieldsPessoa(false);
            }
        }

        private void enableFieldsPessoa(bool enable)
        {
            foreach (Control item in panelFields.Controls)
            {
                if (isFieldPessoa(item))
                    item.Enabled = enable;
            }
            textHabilitacao.Enabled = enable;
        }

        private bool isFieldPessoa(Control item)
        {
            return item.Name.Contains("Pessoa");
        }

        private bool IsPessoaFisica()
        {
            return cboTipo.SelectedIndex == 0;
        }

        private void gridViewDocument_RowClick(object sender, RowClickEventArgs e)
        {
            indexDocument = e.RowHandle;
        }
        private bool isSelected(int index)
        {
            if (index < 0)
            {
                messageShow("Selecione Um Linha dos Registros");
                return false;
            }
            return true;
        }

        private void removeInList<T>(GridControl grid, List<T> list, int index) where T : class, new()
        {
            grid.DataSource = null;
            list.RemoveAt(index);
            grid.DataSource = list;
        }

        private void btnEliminarDocumento_Click(object sender, EventArgs e)
        {
            if (isSelected(indexDocument))
            {
                _EntidadesApp.DeleteDocumentos(new List<DocumentoEntidadeViewModel>() { new DocumentoEntidadeViewModel() { Codigo = Entity.Documentos[indexDocument].codigo.ToString() } });
                removeInList(griadeDocumentos, Entity.Documentos, indexDocument);
                indexDocument = 0;
            }
        }

        private void gridViewMoradas_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            indexMorada = e.RowHandle;
        }

        private void btnEliminarMorada_Click(object sender, EventArgs e)
        {
            
        }

        private void gridViewContaBancaria_RowClick(object sender, RowClickEventArgs e)
        {
            indexConta = e.RowHandle;
        }

        private void btnEliminarContaBancario_Click(object sender, EventArgs e)
        {
            if (isSelected(indexConta))
            {
                _EntidadesApp.DeleteContasBancarias(

                    new List<EntidadeContaViewModel>()
                    {
                        new EntidadeContaViewModel(){Codigo = Entity.Contas[indexConta].codigo.ToString()}
                    }
                );
                removeInList(gradeConta, Entity.Contas, indexConta);
                indexConta = 0;
            }
        }

        private void gridViewContactos_RowClick(object sender, RowClickEventArgs e)
        {
            indexContacto = e.RowHandle;
        }

        private void btnEliminarContactos_Click(object sender, EventArgs e)
        {
            if (isSelected(indexContacto))
            {
                _EntidadesApp.DeleteContactos(

                    new List<ContactoViewModel>()
                    {
                        new ContactoViewModel(){Codigo = Entity.Contactos[indexContacto].codigo.ToString()}
                    }
                );
                removeInList(gradeContactos, Entity.Contactos, indexContacto);
                indexConta = 0;
            }
        }

        private void btnNome_Click(object sender, EventArgs e)
        {


        }

        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void gridViewContactos_DoubleClick(object sender, EventArgs e)
        {
            if (gridContactos.RowCount > 0)
            {
                var newContacto = new frmEntidadesContactos().EditarContacto(Entity.Contactos[indexContacto]);
                Entity.Contactos[indexContacto] = null;
                Entity.Contactos[indexContacto] = newContacto;
                carregarContactos();
            }
        }

        private void gridViewContaBancaria_DoubleClick(object sender, EventArgs e)
        {
            if (gridContaBancaria.RowCount > 0)
            {
                var form = new frmEntidadeContaBancaria();
                var newConta = form.EditarContacta(Entity.Contas[indexConta]);
                Entity.Contas[indexConta] = null;
                Entity.Contas[indexConta] = newConta;
                carregarContas();
            }
        }

        private void gridViewDocumentos_DoubleClick(object sender, EventArgs e)
        {
            if (gridDocumentos.RowCount > 0)
            {
                var formDocument = IOC.InjectForm<frmDocumentos>();
                var newDocument = formDocument.EditarDocumneto(Entity.Documentos[indexDocument]);
                Entity.Documentos[indexDocument] = null;
                Entity.Documentos[indexDocument] = newDocument;
                carregarDocumentos();
            }
        }

        private void gridControlMorada_DoubleClick(object sender, EventArgs e)
        {
            if (gridMoradas.RowCount > 0)
            {
                var formMorada = IOC.InjectForm<frmMorada>();
                var newMorada = formMorada.EditarMorada(Entity.Moradas[indexMorada]);
                Entity.Moradas[indexMorada] = null;
                Entity.Moradas[indexMorada] = newMorada;
                gradeMorada.DataSource = UtilidadesGenericas.newInstanceThisList(Entity.Moradas);
                indexMorada = 0;
            }
        }

        private void gridViewDocumentos_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            indexDocument = e.RowHandle;
        }

        private void gridViewDocumentos_RowClick(object sender, RowClickEventArgs e)
        {
            indexDocument = e.RowHandle;
        }

        private void btnPrint_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btnCondicaoPagamento_Click(object sender, EventArgs e)
        {
            var condicao = IOC.InjectForm<frmCondicoesPagamento>().GetCondicoesPagamento();
            if (Equals(condicao, null) || condicao.Codigo <= 0)
            {
                return;
            }
            Entity.CodCondicaoPagamento = condicao.Codigo;
            Entity.Condicao = new CondicoesPagamentosViewModel()
            {
                Codigo = condicao.Codigo,
                Descricao = condicao.Descricao,
                Dias = condicao.Dias
            };

            txtCodCondicao.Text = condicao.Codigo.ToString();
            txtDescricaoCondicao.Text = condicao.Descricao;

        }



        private void textHabilitacao_Click(object sender, EventArgs e)
        {
            var form = IOC.InjectForm<frmInteligente>();
            var habilitacao = form.GetSelecionado<Habilitacoes>("Habilitacoes", "Habilitações");
            if (!Equals(habilitacao, null))
            {
                codHabilitacao = habilitacao.Codigo;
                CodHabilitacoes.Text = codHabilitacao.ToString();
                textHabilitacao.Text = habilitacao.Descricao;
            }
        }

        private void txtDescricaoCondicao_Click(object sender, EventArgs e)
        {
            var condicao = IOC.InjectForm<frmCondicoesPagamento>().GetCondicoesPagamento();
            if (Equals(condicao, null) || condicao.Codigo <= 0)
            {
                return;
            }
            Entity.CodCondicaoPagamento = condicao.Codigo;
            Entity.Condicao = new CondicoesPagamentosViewModel()
            {
                Codigo = condicao.Codigo,
                Descricao = condicao.Descricao,
                Dias = condicao.Dias
            };

            txtCodCondicao.Text = condicao.Codigo.ToString();
            txtDescricaoCondicao.Text = condicao.Descricao;

        }

        private void textNacionalidade_Click(object sender, EventArgs e)
        {
            var form = IOC.InjectForm<frmInteligente>();
            var pais = form.GetSelecionado<Pais>("Pais", "Paises");
            if (!Equals(pais, null))
            {
                codPais = pais.codigo;
                CodNacionalidade.Text = codPais.ToString();
                textNacionalidade.Text = pais.Descricao;
            }
        }

        private void btnContactos_Click_1(object sender, EventArgs e)
        {


            frmEntidadesContactos frmContact = new frmEntidadesContactos();
            frmContact.ShowDialog();
            if (UtilidadesGenericas.EntidadeValida(frmContact.Contacto))
            {
                Entity.Contactos.Add(frmContact.Contacto);
                gradeContactos.DataSource = null;
                carregarContactos();
            }
        }

        private void btnEliminarContactos_Click_1(object sender, EventArgs e)
        {
            if (isSelected(indexContacto))
            {
                _EntidadesApp.DeleteContactos(

                    new List<ContactoViewModel>()
                    {
                        new ContactoViewModel(){Codigo = Entity.Contactos[indexContacto].codigo.ToString()}
                    }
                );
                removeInList(gradeContactos, Entity.Contactos, indexContacto);
                indexConta = 0;
            }
        }

        private void MostrarIdade()
        {
            var idade = UtilidadesGenericas.GetIntervaloDeAno(dateNascimento.DateTime, DateTime.Now);
            var uniExpresao = "";
            if (idade == 1)
            {
                uniExpresao = " Ano";
            }
            else if (idade > 1)
            {
                uniExpresao = " Anos";
            }
            txtIdade.Text = idade.ToString() + uniExpresao;
        }

        private void btnImprimirDocumentos_Click(object sender, EventArgs e)
        {

        }

        private void btnAddDocumentos_Click(object sender, EventArgs e)
        {
            var formDocument = IOC.InjectForm<frmDocumentos>();
            var newDocument = formDocument.GetDocumento();
            if (UtilidadesGenericas.EntidadeValida(newDocument))
            {
                Entity.Documentos.Add(newDocument);
                griadeDocumentos.DataSource = null;
                carregarDocumentos();
            }

        }

        private void btnRemoveDocumentos_Click(object sender, EventArgs e)
        {
            if (isSelected(indexDocument))
            {
                _EntidadesApp.DeleteDocumentos(new List<DocumentoEntidadeViewModel>() { new DocumentoEntidadeViewModel() { Codigo = Entity.Documentos[indexDocument].codigo.ToString() } });
                removeInList(griadeDocumentos, Entity.Documentos, indexDocument);
                indexDocument = 0;
            }
        }

        private void btnContaBancaria_Click_1(object sender, EventArgs e)
        {
            var form = new frmEntidadeContaBancaria();
            var newConta = form.GetConta();
            if (UtilidadesGenericas.EntidadeValida(newConta))
            {
                Entity.Contas.Add(newConta);
                gradeConta.DataSource = null;
                carregarContas();
            }

        }

        private void btnEliminarContaBancario_Click_1(object sender, EventArgs e)
        {
            if (isSelected(indexConta))
            {
                _EntidadesApp.DeleteContasBancarias(

                    new List<EntidadeContaViewModel>()
                    {
                        new EntidadeContaViewModel(){Codigo = Entity.Contas[indexConta].codigo.ToString()}
                    }
                );
                removeInList(gradeConta, Entity.Contas, indexConta);
                indexConta = 0;
            }
        }

        private void btnNovaMorada_Click(object sender, EventArgs e)
        {
            var formMorada = IOC.InjectForm<frmMorada>();
            var newMorada = formMorada.GetMorada();
            if (UtilidadesGenericas.EntidadeValida(newMorada))
            {
                Entity.Moradas.Add(newMorada);
                gradeMorada.DataSource = null;
                gradeMorada.DataSource = Entity.Moradas;
                indexMorada = 0;
            }

        }

        private void btnEliminarMorada_Click_1(object sender, EventArgs e)
        {
            if (isSelected(indexMorada))
            {
                _EntidadesApp.DeleteMoradas(
                    new List<MoradaViewModel>()
                    {
                        new MoradaViewModel()
                        {
                            IDMorada = Entity.Moradas[indexMorada].IDMorada
                        }
                    }
                );
                removeInList(gradeMorada, Entity.Moradas, indexMorada);
                indexMorada = 0;
            }

        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmVerEntidade chamada = IOC.InjectForm<frmVerEntidade>();
            UtilidadesGenericas.ChamarNoPrincipal(chamada);
        }
    }
}