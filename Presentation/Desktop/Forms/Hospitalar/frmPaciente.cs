using DevExpress.XtraBars;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Folha.Domain.Interfaces.Application.Entidades;
using Folha.Domain.Interfaces.Application.Hospitalar;
using Folha.Domain.Models.Entidades;
using Folha.Domain.Models.Genericos;
using Folha.Domain.Models.Hospitalar;
using Folha.Domain.ViewModels.Entidades;
using Folha.Domain.ViewModels.Hospitalar;
using Folha.Domain.Enuns.Genericos;
using Folha.Domain.Helpers;
using Folha.Driver.Framework.IOC;
using Folha.Domain.ViewModels.Frame.Entidades;
using Folha.Presentation.Desktop.Forms.Apresenta_Doc;
using Folha.Presentation.Desktop.Forms.Principal;
using Folha.Presentation.Desktop.Separadores.Empresa;
using Folha.Presentation.Desktop.Separadores.Entidades;
using Folha.Presentation.Desktop.Separadores.Recursos_Humanos;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Folha.Presentation.Desktop.Forms.Hospitalar
{
    public partial class frmPaciente : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        private int codEntidade = 0;

        private readonly IPacienteApp _PacienteApp;
        private readonly IEntidadesApp _EntidadesApp;
        private readonly IEntidadePessoaApp _EntidadePessoaApp;
        public CRUD Operacao { get; set; } = CRUD.Cadastro;
        public EntidadesViewModel Entidade { get; set; }
        private AllEntidadeViewModel AllEntidade;

        private int indexContacto = -1;
        private int indexDocument = -1;
        private int indexMorada = -1;
        private int CodPais;
        private int CodSexo;
        private int CodHabilitacoes;
        private int CodProfissao;
        //private string CodEntidade;

        private int LastCodEntidade;
        private int fechar = 0;
        private int aviso = 0;
        private int codGruposanguineo = 0;
        private List<GrupoSanguineos> gruposSanguineos;
        private PacienteViewModel _Paciente;

        private EntidadesViewModel Entity { get; set; }
        public List<PacienteViewModel> LtPacientes { get; private set; }

        public frmPaciente(IEntidadesApp EntidadesApp, IEntidadePessoaApp EntidadePessoaApp, IPacienteApp PacienteApp)
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            _EntidadesApp = EntidadesApp;
            _EntidadePessoaApp = EntidadePessoaApp;
            _PacienteApp = PacienteApp;
             Entity = new EntidadesViewModel();
        }

        private void btnNome_Click(object sender, EventArgs e)
        {
            carregarEntidade();
        }
        private void carregarEntidade()
        {
            var form = IOC.InjectForm<frmEntidadeBusca>();
            var entidade = form.GetEntidadeSelecionada(Folha.Domain.Enuns.Entidades.TypeEntity.CLIENTE, 1);
            List<PacienteViewModel> GSanguineo = _PacienteApp.GetAll(null);
            var paciente = _PacienteApp.GetByIdEntidade(entidade.Codigo);
            if (!Equals(paciente, null) && paciente.Codigo > 0)
            {
                if (paciente.status == "1")
                {
                    UtilidadesGenericas.MsgShow("A entidades selecionada já é um paciente!", MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    if (recuperarPaciente())
                    {
                        _PacienteApp.Update(new Paciente()
                        {
                            CodEntidade = paciente.CodEntidade,
                            CodPessoa = paciente.CodEntidade,
                            CodGrupoSanguineos = int.Parse(paciente.CodGrupoSanguineos),
                            status = 1
                        });
                        UtilidadesGenericas.Busca.Alterou = true;
                    }
                    else
                    {
                        return;
                    }
                }
            }
            if (entidade == null || entidade.Codigo == 0)
            { return; }

            codEntidade = entidade.Codigo;
            txtNome.Text = entidade.Nome;
            txtCodNome.Text = entidade.Codigo.ToString();
            txtPai.Text = entidade.Pessoa.NomePai;
            txtMae.Text = entidade.Pessoa.NomeMae;
            txtNacionalidade.Text = entidade.Nacionalidade.Descricao;
            cboSexo.Text = entidade.Pessoa.Sexo.descricao;
            txtHabilitacoes.Text = entidade.Pessoa.Habilitacao.Descricao;
            timeNascimento.DateTime = Convert.ToDateTime(entidade.Pessoa.DataNascimento);
            txtProfissao.Text = entidade.Pessoa.Profissao.Descricao;
            cboEstadoCivil.Text = entidade.Pessoa.EstadoCivil.descricao;
            txtContribuente.Text = entidade.Nif;
            PicImagem.Image = Imagens.Byte_Imagem(entidade.Foto);

            foreach (var item in GSanguineo)
            {
                if (item.CodEntidade == codEntidade)
                {cboGrupoSanguineo.Text = item.Descricao;}
            }
            //
            CodPais = entidade.Nacionalidade.codigo;
            CodProfissao = entidade.Pessoa.Profissao.Codigo;
            CodHabilitacoes = entidade.Pessoa.Habilitacao.Codigo;
            //
            loadEntityWithAllDependents();
            btnImprimi.Enabled = true;
        }

        private bool recuperarPaciente()
        {
            var resultReturn = MessageBox.Show(
                "Esta Entidade já tem um Paciente no sistema mas eliminado, pretende recuperar?", 
                "QUESTÃO",
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question
            );
            if (resultReturn == DialogResult.Yes)
            {
                Operacao = CRUD.Edição;
                return true;
            }
            else
            {
                return false;
            }
        }

        private void loadEntityWithAllDependents()
        {
            gridControlMorada.DataSource = null;
            gridControlDocumentos.DataSource = null;
            gridControlContactos.DataSource = null;
            int entidadeId = Convert.ToInt32(txtCodNome.Text);
            Entity = _EntidadesApp.GetByIdWithAllDependent(entidadeId);
            gridControlMorada.DataSource = Entity.Moradas;
            gridControlDocumentos.DataSource = Mapper<DocumentosEntidadeViewModel, PacienteDocumentoVeiwModel>.Map(Entity.Documentos);
            gridControlContactos.DataSource = Mapper<ContactosViewModel, PacienteContactoViewModel>.Map(Entity.Contactos);
        }

        private void btnContactos_Click(object sender, EventArgs e)
        {
            frmEntidadesContactos frmContact = new frmEntidadesContactos();
            frmContact.ShowDialog();
            if (frmContact.Contacto.descricao != "Nenhum" && frmContact.Contacto.Tipo.descricao != "Nenhum")
            {
                Entity.Contactos.Add(frmContact.Contacto);
                gridControlContactos.DataSource = null;
                gridControlContactos.DataSource = Mapper<ContactosViewModel, PacienteContactoViewModel>.Map(Entity.Contactos);
            } 
        }
        private void btnDocumentos_Click(object sender, EventArgs e)
        {
            var formDocumento = IOC.InjectForm<frmDocumentos>();
            var newDocumento = formDocumento.GetDocumento();
            if (newDocumento.Tipo.descricao != "Nenhum" && newDocumento.Numero != "00000")
            {
                Entity.Documentos.Add(newDocumento);

                gridControlDocumentos.DataSource = null;
                gridControlDocumentos.DataSource = Mapper<DocumentosEntidadeViewModel, PacienteDocumentoVeiwModel>.Map(Entity.Documentos);
            }
        }
        private void btnMorada_Click(object sender, EventArgs e)
        {
            var formMorada = IOC.InjectForm<frmMorada>();
            var newMorada = formMorada.GetMorada();
            if (newMorada.DescricaoMorada != "Nenhuma")
            {
                Entity.Moradas.Add(newMorada);
                gridControlMorada.DataSource = null;
                gridControlMorada.DataSource = Entity.Moradas;
            }
        }
        private void btnMaisHabilitacoes_Click(object sender, EventArgs e)
        {
            Habilitacoes habilitacao = IOC.InjectForm<frmInteligente>().GetSelecionado<Habilitacoes>("Habilitacoes", "Habilitações");
            if (Equals(habilitacao, null))
            {
                return;
            }
            CodHabilitacoes = habilitacao.Codigo;
            txtHabilitacoes.Text = habilitacao.Descricao;
        }
        private void btnProfissao_Click(object sender, EventArgs e)
        {
            var profissao = IOC.InjectForm<frmInteligente>().GetSelecionado<Profissao>("Profissao", "Profissões");
            if (Equals(profissao, null))
            {
                return;
            }
            CodProfissao = profissao.Codigo;
            txtProfissao.Text = profissao.Descricao;
        }
        private void btnMaisNacionalidade_Click(object sender, EventArgs e)
        {
            Pais pais = IOC.InjectForm<frmInteligente>().GetSelecionado<Pais>("Pais", "Paises");
            if (Equals(pais, null))
            {
                return;
            }
            CodPais = pais.codigo;
            txtNacionalidade.Text = pais.Descricao;
        }
        private void carregarLastCodEntidade()
        {
            if (string.IsNullOrEmpty(txtCodNome.Text) || txtCodNome.Text == "0")
            {
                LastCodEntidade = _EntidadesApp.GetCodLastEntity();
            }
            else
            {
                LastCodEntidade = int.Parse(txtCodNome.Text);
            }
        }
        private void GravarPaciente()
        {
            byte[] logotipo = new byte[1];
            if (PicImagem.Image != null) logotipo = Imagens.Imagem_Byte(PicImagem.Image);
            EntidadesViewModel DadosEntidades = new EntidadesViewModel()
            {
                Codigo = codEntidade,
                Nome = txtNome.Text,
                Nif = txtContribuente.Text,
                CodPais = CodPais,
                Foto = logotipo,
                Cliente = 1,
                Limite = "000",
                CodTipo = 1,
                Contactos = Entity.Contactos,
                Documentos = Entity.Documentos,
                Moradas = Entity.Moradas,
                CodCondicaoPagamento = 1
            };
            
            if (!string.IsNullOrEmpty(txtCodNome.Text))
            {
                _EntidadesApp.EditEntidade(DadosEntidades);
            }
            else
            {
                _EntidadesApp.addEntidade(DadosEntidades);
            }

            carregarLastCodEntidade();
            EntidadesPessoaViewModel DadosEntidadePessoa = new EntidadesPessoaViewModel()
            {
                CodEntidade = (!string.IsNullOrEmpty(txtCodNome.Text)) ? (int.Parse(txtCodNome.Text)) : (LastCodEntidade),
                CodSexo = cboSexo.SelectedIndex + 1,
                CodEstadoCivil = cboEstadoCivil.SelectedIndex + 1,
                DataNascimento = timeNascimento.EditValue.ToString(),
                CodHabilitacao = CodHabilitacoes,
                CodProfissao = CodProfissao,
                NomePai = txtPai.Text,
                NomeMae = txtMae.Text,
            };
            if (!string.IsNullOrEmpty(txtCodNome.Text))
            { _EntidadePessoaApp.Update(DadosEntidadePessoa);}
            else
            { _EntidadePessoaApp.Insert(DadosEntidadePessoa);}
            //
            if (Operacao == CRUD.Edição)
            {

                _PacienteApp.Update(new Paciente()
                { CodPessoa = codEntidade, CodGrupoSanguineos = codGruposanguineo, status = 1 });
                fechar = 1; aviso = 1;
            }
            else if (Operacao == CRUD.Cadastro)
            {
                _PacienteApp.Insert(new Paciente()
                {CodPessoa = LastCodEntidade, CodGrupoSanguineos = codGruposanguineo, status = 1 });
                txtCodNome.Text = LastCodEntidade.ToString();
                fechar = 1; aviso = 2;
            }
        }

        private void btnSalvar_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (validacao())
            {
                GravarPaciente();
            }
            fechar = 0;
            UtilidadesGenericas.Busca.Alterou = true;
            if (fechar == 0 && aviso == 1)
            {
                btnImprimi.Visibility = BarItemVisibility.Always;
                btnImprimi.Enabled = true;
            }
            if (fechar == 0 && aviso == 2)
            {
                btnImprimi.Visibility = BarItemVisibility.Always;
               btnImprimi.Enabled = true;
            }
        }
        private bool validacao()
        {
            if (txtNome.Text == "")
            {
                MessageBox.Show("O campo Nome deve ser preenchido.", "Paciente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            //else if (txtHabilitacoes.Text == "" || txtHabilitacoes.Text == "Nenhuma")
            //{
            //    MessageBox.Show("O campo Habilitações deve ser preenchido.", "Paciente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return false;
            //}
            //else if (txtProfissao.Text == "" || txtProfissao.Text == "Nenhuma")
            //{
            //    MessageBox.Show("O campo Profissão deve ser preenchido.", "Paciente", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false;
            //}
            //else if (txtNacionalidade.Text == "" || txtNacionalidade.Text == "Nenhuma")
            //{
            //    MessageBox.Show("O campo Nacionalidade deve ser preenchido.", "Paciente", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false;
            //}
            else
            {
                return true;
            }
        }
     
        private void btnVoltar_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }
        private void gridViewContactos_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            indexContacto = e.RowHandle;
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
        private bool isSelected(int index)
        {
            if (index < 0)
            {messageShow("Selecione Uma Linha de Registro");return false;}
            if (MessageBox.Show("Desejas eliminar este registro!", "AVISO", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK) {return true; }
            else {return false; }
        }
        private void removeInList<T>(GridControl grid, List<T> list, int index) where T : class, new()
        {
            grid.DataSource = null;
            list.RemoveAt(index);
            grid.DataSource = list;
        }
        private void btnContacto_Click(object sender, EventArgs e)
        {
            navigationFrame1.SelectedPage = pgContactos;
        }

        private void btnMoradas_Click(object sender, EventArgs e)
        {
            navigationFrame1.SelectedPage = pgMoradas;
        }
        private void btnDadosGerais_Click(object sender, EventArgs e)
        {
            navigationFrame1.SelectedPage = pgDadosGerais;
        }

        private void btnDocumento_Click(object sender, EventArgs e)
        {
            navigationFrame1.SelectedPage = pgDocumentos;
        }
        private void btnEliminarContactos_Click(object sender, EventArgs e)
        {
            if (isSelected(indexContacto))
            {
                removeInList(gridControlContactos, Entity.Contactos, indexContacto);
                gridControlContactos.DataSource = null;
                gridControlContactos.DataSource = Mapper<ContactosViewModel, PacienteContactoViewModel>.Map(Entity.Contactos);
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (isSelected(indexDocument))
            {
                removeInList(gridControlDocumentos, Entity.Documentos, indexDocument);
                gridControlDocumentos.DataSource = null;
                gridControlDocumentos.DataSource = Mapper<DocumentosEntidadeViewModel, PacienteDocumentoVeiwModel>.Map(Entity.Documentos);
            }
        }

        private void btnEliminarMorada_Click(object sender, EventArgs e)
        {
            if (isSelected(indexMorada))
            {
                removeInList(gridControlMorada, Entity.Moradas, indexMorada);
            }
        }
        private void gridDocumentos_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            indexDocument = e.RowHandle;
        }

        private void gridViewMoradas_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            indexMorada = e.RowHandle;
        }
        private void gridViewContactos_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(MousePosition);
            GridHitInfo info = view.CalcHitInfo(pt);

            frmEntidadesContactos frmContact = new frmEntidadesContactos();
            frmContact.EditarContacto(Entity.Contactos[indexContacto]);
           
            if (frmContact.Contacto.descricao != "Nenhum")
            {
                gridControlContactos.DataSource = null;
                gridControlContactos.DataSource = Mapper<ContactosViewModel, PacienteContactoViewModel>.Map(Entity.Contactos);
            }
        }

        private void frmPaciente_Load(object sender, EventArgs e)
        {
            LtPacientes = _PacienteApp.GetAll(null);
            CarregarGrupoSanguineos();
            if (txtCodNome.Text != "") btnImprimi.Enabled = true;
        }
        private void CarregarGrupoSanguineos()
        {
            gruposSanguineos = _PacienteApp.ListarGrupoSanguineo(new GrupoSanguineos());
            cboGrupoSanguineo.Properties.Items.Clear();
            foreach (var item in gruposSanguineos)
            {
                cboGrupoSanguineo.Properties.Items.Add(item.Descricao);
            }
            if (txtCodNome.Text == ""){cboGrupoSanguineo.SelectedIndex = 0;}
        }
        private void cboSexo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CodSexo = (cboSexo.Text == "MASCULINO") ? (1) : (2);
        }
        private void gridDocumentos_DoubleClick(object sender, EventArgs e)
        {
            frmDocumentos newDocumento = IOC.InjectForm<frmDocumentos>();

            
            Entity.Documentos[indexDocument] = newDocumento.EditarDocumneto(Entity.Documentos[indexDocument]);
            gridControlDocumentos.DataSource = null;
            gridControlDocumentos.DataSource = Mapper<DocumentosEntidadeViewModel, PacienteDocumentoVeiwModel>.Map(Entity.Documentos);
           
        }

        private void gridViewMoradas_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(MousePosition);
            GridHitInfo info = view.CalcHitInfo(pt);
            
            frmMorada formMorada = IOC.InjectForm<frmMorada>();
            formMorada.EditarMorada(Entity.Moradas[indexMorada]);

            gridControlMorada.DataSource = null;
            gridControlMorada.DataSource = Entity.Moradas;
           
        }
        private void CarregaCampos()
        {
            AllEntidade = _EntidadesApp.ListEntidadeGetAll(txtCodNome.Text);
            List<PacienteViewModel>  GSanguineo = (List<PacienteViewModel>)_PacienteApp.GetAll(null);
            txtPai.Text = AllEntidade.NomePai;
            txtContribuente.Text = AllEntidade.Nif;
            timeNascimento.EditValue = AllEntidade.DataNascimento;
            if (!string.IsNullOrEmpty(AllEntidade.CodPais))
            {

                CodPais = int.Parse(AllEntidade.CodPais);
            }
            if (!string.IsNullOrEmpty(AllEntidade.CodSexo))
            {
                CodSexo = int.Parse(AllEntidade.CodSexo);
            }
            if (!string.IsNullOrEmpty(AllEntidade.CodHabilitacao))
            {
                CodHabilitacoes = int.Parse(AllEntidade.CodHabilitacao);
            }

            foreach (var item in GSanguineo)
            {
                if (item.CodEntidade == codEntidade)
                {
                    cboGrupoSanguineo.Text = item.Descricao;
                }
            }
            txtNacionalidade.Text = AllEntidade.Nacionalidade;
            cboSexo.SelectedItem = AllEntidade.Sexo;
            cboEstadoCivil.SelectedItem = AllEntidade.EstadoCivil;
            txtHabilitacoes.Text = AllEntidade.Habilitacao;
            txtPai.Text = AllEntidade.NomePai;
            txtMae.Text = AllEntidade.NomeMae;
            if (!string.IsNullOrEmpty(AllEntidade.CodProfissao))
            {
                CodProfissao = int.Parse(AllEntidade.CodProfissao);
            }
          
            txtProfissao.Text = AllEntidade.Profissao;
            
            try
            {
                PicImagem.Image = Imagens.Byte_Imagem(AllEntidade.Foto);
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }

           
        }
        public void EditarPaciente(EntidadesViewModel entidade)
        {
            codEntidade = entidade.Codigo;
            txtNome.Text = entidade.Nome;
            Operacao = CRUD.Edição;
            txtCodNome.Text = entidade.Codigo.ToString();

            CarregaCampos();
            loadEntityWithAllDependents();
            btnImprimi.Visibility = BarItemVisibility.Always;
            btnImprimi.Enabled = true;
            ShowDialog();
            Close();
        }

        private void btnSalvarFechar_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (validacao())
            {
                GravarPaciente();
            }
            UtilidadesGenericas.Busca.Alterou = true;
            if (fechar == 1) {
                Close();
            }
        }
        private void cboGrupoSanguineo_SelectedIndexChanged(object sender, EventArgs e)
        {
            codGruposanguineo = gruposSanguineos[cboGrupoSanguineo.SelectedIndex].Codigo;
        }

        private void btnImprimi_ItemClick(object sender, ItemClickEventArgs e)
        {
            Imprimir();
        }
        private void Imprimir()
        {
            _Paciente = new PacienteViewModel()
            {
                Nome = AllEntidade.Nome,
                DataNascimento = AllEntidade.DataNascimento,
                Sexo = cboSexo.Text,
                Pai = AllEntidade.NomePai,
                Mae = AllEntidade.NomeMae,
                Nacionalidade = new Pais() { Descricao = txtNacionalidade.Text },
                GrupoSanguineo = new GrupoSanguineos() { Descricao = cboGrupoSanguineo.Text },
                Foto = AllEntidade.Foto,
                EstadoCivil = cboEstadoCivil.Text,
                Nif=txtContribuente.Text,
                Morada=(gridViewMoradas.RowCount>0)?(gridViewMoradas.GetRowCellValue(0,"DescricaoMorada").ToString()):(""),
                Contacto1= (gridViewContactos.RowCount > 0) ? (gridViewContactos.GetRowCellValue(0, "descricao").ToString()) : (""),
                Contacto2 = (gridViewContactos.RowCount > 1) ? (gridViewContactos.GetRowCellValue(1, "descricao").ToString()) : (""),
            };
            new frmApresentaReport().ApresentarReportFichaPaciente(_Paciente);
        }

        private void ribbon_Click(object sender, EventArgs e)
        {

        }

        private void txtCodNome_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}