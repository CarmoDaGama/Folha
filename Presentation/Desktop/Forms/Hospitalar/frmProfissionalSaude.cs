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
using Folha.Presentation.Desktop.Forms.Principal;
using Folha.Domain.Interfaces.Application.Hospitalar;
using Folha.Presentation.Desktop.Separadores.Entidades;
using Folha.Domain.Models.Hospitalar;
using Folha.Domain.ViewModels.Hospitalar;
using Folha.Domain.Helpers;

namespace Folha.Presentation.Desktop.Forms.Hospitalar
{
    public partial class frmProfissionalSaude : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly IProfissinalSaudeApp _profApp;

        private ProfissinalSaude profissinalsaude;
        private ProfissionalSaudeViewModel Entity { get; set; }
        private List<AreaSaudeProfissinalViewModel> listaArea;
        private int codAreaSaude;
        private int codEntidade;
        private int codDelete;
        private int indexArea;
        private bool Changed { get; set; } = false;
        public int AreaId { get; private set; }
        public frmProfissionalSaude(IProfissinalSaudeApp profApp)
        {
            InitializeComponent();
            _profApp = profApp;
        }
        private void btnInserirArea_Click(object sender, EventArgs e)
        {
            var form = IOC.InjectForm<frmInteligente>();
            var AreaSaude = form.GetSelecionado<AreaSaudeViewModel>("AreaSaude", "Área De Saude");
            if (Equals(AreaSaude, null) ||Equals(AreaSaude.Codigo, 0))
            {
                return;
            }
            codAreaSaude = AreaSaude.Codigo;

            if (Equals(listaArea, null))
            {
                listaArea = new List<AreaSaudeProfissinalViewModel>();
            }
            var newAreaSaude = (new AreaSaudeProfissinalViewModel()
            {
                CodAreaSaude = AreaSaude.Codigo,
                AreaSaude = AreaSaude,
                Descricao = AreaSaude.Descricao,
            });
            if (listaArea.Count > 0 && ContemNaListasSub(newAreaSaude.CodAreaSaude))
            {
                MessageBox.Show("Já está Adicionado", "Erro ao Adicionar ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            listaArea.Add(newAreaSaude);
            gradeArea.DataSource = null;
            gradeArea.DataSource = listaArea;
        }
        private bool ContemNaListasSub(int id)
        {
            return listaArea.Where(a => a.CodAreaSaude == id).FirstOrDefault() != null;
        }
        #region Metodos de Inserir
        private ProfissinalSaude PopulaObjecto()
        {  profissinalsaude = new ProfissinalSaude()
            {
                CodEntidade = codEntidade,
                status = 1,
                AreaSaude = new List<AreaSaudeProfissinalViewModel>()
                
            };

            if (!string.IsNullOrEmpty(txtCodigo.Text)) profissinalsaude.Codigo = int.Parse(txtCodigo.Text);
            profissinalsaude.AreaSaude = null;
            profissinalsaude.AreaSaude = listaArea;
            return profissinalsaude;
        }
        private void PopularDadosEditar(int Codigo)
        {
            if (Codigo == 0) return;
            AreaId = Codigo;
            Entity = _profApp.GetById(Codigo);
            txtEntidade.Text = Entity.Entidades.Nome;
            codEntidade = Entity.CodEntidade;
            gradeArea.DataSource = listaArea = _profApp.GetArea(Codigo);
        }
        #endregion
        #region VALIDAÇÃO
        private void messageShow(string message)
        {
            MessageBox.Show(
                message,
                "INFORMAÇÃO",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }      
        private bool isFieldsValid()
        {
            bool valid = true;

            if (txtEntidade.Text.Equals(string.Empty))
            {
                messageShow("Escolha uma Entidade");
                return false;
            }
            Dictionary<string, object> d = new Dictionary<string, object>();
            d.Add("CodEntidade", codEntidade);

            if (txtCodigo.Text == "" &&   _profApp.VerificarDup("ProfissionalSaude", d))
            {
                messageShow("Já Existe essa entidade Verifica nos Registros ");
                return false;
            }
            if (Equals(listaArea, null) || listaArea.Count == 0)
            {
                MessageBox.Show("Adicino um ou mais Area");
                return false;

            }
            return valid;
        }
        #endregion
        private void btnBuscaCategoria_Click(object sender, EventArgs e)
        {
            var form = IOC.InjectForm<frmEntidadeBusca>();

            var Entidades = form.GetEntidadeSelecionada(1);
            if (Equals(Entidades, null))
            {
                return;
            }
            else
            {
                codEntidade = Entidades.Codigo;
                txtEntidade.Text = Entidades.Nome;
            }
        }
        private void btnSalvar_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!isFieldsValid()) return;
            var prof = PopulaObjecto();
            prof = _profApp.Gravar(prof);
            PopularDadosEditar(prof.Codigo);
            txtCodigo.Text = prof.Codigo.ToString();
            UtilidadesGenericas.Busca.Alterou = true;
        }
        private void frmProfissionalSaude_Load(object sender, EventArgs e)
        {
          if (!string.IsNullOrEmpty(UtilidadesGenericas.Busca.Codigo))
            {
                txtCodigo.Text = UtilidadesGenericas.Busca.Codigo;
                int Codigo = int.Parse(txtCodigo.Text);
                var profissional = _profApp.GetById(Codigo);
                if (Codigo > 0) PopularDadosEditar(Codigo);
            }
        }
        private void gridArea_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            codDelete = listaArea[e.RowHandle].Codigo;
            indexArea = e.RowHandle;
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (codDelete > 0)
            {
                _profApp.DeleteArea(new AreaSaudeProfissinalViewModel()
                {
                    Codigo = codDelete,
                });           
                gradeArea.DataSource = null;
                gradeArea.DataSource = listaArea;
                gradeArea.DataSource = listaArea = _profApp.GetArea(AreaId);

                MessageBox.Show("Registro Excluído ! ", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                listaArea.RemoveAt(indexArea);
                gradeArea.DataSource = null;
                gradeArea.DataSource = listaArea;
            }           
        }
        private void btnSalvarFechar_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!isFieldsValid()) return;
            var prof = PopulaObjecto();
            prof = _profApp.Gravar(prof);
            PopularDadosEditar(prof.Codigo);
            txtCodigo.Text = prof.Codigo.ToString();
            UtilidadesGenericas.Busca.Alterou = true;
            Close();
        }

        private void btnVoltar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }
    }
}