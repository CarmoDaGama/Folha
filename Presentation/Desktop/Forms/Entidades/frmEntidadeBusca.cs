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
using Folha.Presentation.Desktop.SubFormularios;
using Folha.Domain.Interfaces.Application.Entidades;
using Folha.Domain.Models.Entidades;
using Folha.Driver.Framework.IOC;
using Folha.Domain.ViewModels.Entidades;
using Folha.Domain.Enuns.Entidades;
using Folha.Domain.ViewModels.Hospitalar;
using Folha.Domain.Enuns.Genericos;
using Folha.Domain.Helpers;

namespace Folha.Presentation.Desktop.Separadores.Entidades
{
    public partial class frmEntidadeBusca : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly IEntidadesApp _EntidadesApp;
        private int index;

        private bool Selected { get; set; } = false;
        public new bool Select { get; set; } = false;
        private int Index { get; set; } = -1;
        public List<EntidadesViewModel> Entidades { get; set; }
        public List<PacienteViewModel> Pacientes { get; set; }
        private TypeEntity TipoEntidade { get; set; } = TypeEntity.ISENTO;
        private int TipoPessoaId { get; set; } = 0;
        public CRUD Op { get; private set; }

        public frmEntidadeBusca(IEntidadesApp EntidadesApp)
        {
            InitializeComponent();
            _EntidadesApp = EntidadesApp;
        }
        public void carregarEntidade()
        {
            Entidades = _EntidadesApp.Listar();

            carregarPorTipo();

            gradeEntidadeBusca.DataSource = Entidades;
        }

        private void carregarPorTipo()
        {
            switch (TipoEntidade)
            {
                case TypeEntity.CLIENTE:
                    Entidades = Entidades.Where(e => e.Cliente == 1).ToList();
                    break;
                case TypeEntity.FUNCIONARIO:
                    Entidades = Entidades.Where(e => e.Funcionario == 1).ToList();
                    break;
                case TypeEntity.FORNECEDOR:
                    Entidades = Entidades.Where(e => e.Fornecedor == 1).ToList();
                    break;
                case TypeEntity.FR:
                    break;
                case TypeEntity.ISENTO:
                    break;
                default:
                    break;
            }
            if (TipoPessoaId > 0)
            {
                Entidades = Entidades.Where(e => e.CodTipo == TipoPessoaId).ToList();
            }
        }

        public EntidadesViewModel GetEntidadeSelecionada()
        {
            Select = true;
            ShowDialog();
            if (!UtilidadesGenericas.ListaNula(Entidades) && Selected)
            {
                if (string.IsNullOrEmpty(gridView.GetRowCellValue(index, "Codigo") + ""))
                {
                    return new EntidadesViewModel();
                }
                int codigo = Convert.ToInt32(gridView.GetRowCellValue(index, "Codigo").ToString());
                var entidade = _EntidadesApp.GetById(codigo);

                return entidade;
            }
            else
            {
                return new EntidadesViewModel();
            }
        }

        public EntidadesViewModel GetEntidadeSelecionada(TypeEntity tipoEntidade)
        {
            TipoEntidade = tipoEntidade;
            return GetEntidadeSelecionada();
        }

        public EntidadesViewModel GetEntidadeSelecionada(TypeEntity tipoEntidade, int tipoPessoaId)
        {
            TipoPessoaId = tipoPessoaId;
            return GetEntidadeSelecionada(tipoEntidade);
        }
        public EntidadesViewModel GetEntidadeSelecionada(int tipoPessoaId)
        {
            TipoPessoaId = tipoPessoaId;
            return GetEntidadeSelecionada();
        }

        private void btnVoltar_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnNova_ItemClick(object sender, ItemClickEventArgs e)
        {
            var form = IOC.InjectForm<frmEntidade>();
            form.SetTipoEntidade(TipoEntidade);
            form.ShowDialog();
            if (UtilidadesGenericas.Busca.Alterou)
            {
                carregarEntidade();
                UtilidadesGenericas.Busca.Alterou = false;
            }
        }

        private void frmEntidadeBusca_Load(object sender, EventArgs e)
        {
            carregarEntidade();
            buttonSelect.VisibleInSearchMenu = Select;
        }

        private void buttonSelect_ItemClick(object sender, ItemClickEventArgs e)
        {
            selectRow();
        }

        private void selectRow()
        {
            if (index > -1)
            {
                Selected = true;
                Close();

            }
            else MessageBox.Show("Selecione uma Linha de registro de Entidade");
        }

        private void Lancar()
        {
            if (gridView.RowCount == 0) {
                MessageBox.Show("Nenhuma entidade encontrada!");
                return;
            }
            UtilidadesGenericas.Busca.Codigo = gridView.GetRowCellValue(index, "Codigo").ToString();
            UtilidadesGenericas.Busca.Entidade = gridView.GetRowCellValue(index, "Nome").ToString();
            Close();
        }

        private void gridView_DoubleClick(object sender, EventArgs e)
        {
            if (Op == CRUD.Listar)
            {
                if (index > -1)
                {
                    //int codigo = Convert.ToInt32(gridView.GetRowCellValue(index, "Codigo").ToString());
                    //frmEntidade chamada = IOC.InjectForm<frmEntidade>();
                    //chamada.SetTipoEntidade(TipoEntidade);
                    //if (chamada.EditarEntity(_EntidadesApp.GetByIdWithAllDependent(codigo)))
                    //    carregarEntidade();
                }
                else UtilidadesGenericas.MsgShow("Selecione uma linha");
               
            }
            else
            {
                selectRow();
            }
        }

        private void gridView_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            index = e.RowHandle;
        }

        private void gridView_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            index = e.RowHandle;
        }

        internal frmEntidadeBusca This(TypeEntity entidade, CRUD op )
        {
            Op = op;
            TipoEntidade = entidade;
            return this;
        }
    }
}