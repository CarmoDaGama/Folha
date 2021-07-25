using System;
using Folha.Domain.Interfaces.Application.Entidades;
using Folha.Driver.Framework.IOC;
using SimpleInjector;
using Folha.Presentation.Desktop.Separadores.Entidades;
using System.Collections.Generic;
using Folha.Domain.Helpers;
using System.Windows.Forms;
using Folha.Domain.ViewModels.Entidades;
using Folha.Domain.Enuns.Entidades;
using DevExpress.XtraGrid.Views.Grid;

namespace Folha.Presentation.Desktop.Separadores.Principal
{
    public partial class frmVerEntidade : Form
    {
        private readonly IEntidadesApp _EntidadesApp;
        private int index { get; set; }
        private List<EntidadeViewModel> EntidadesViewModel { get; set; }
        private List<EntidadesViewModel> Entidades { get; set; }
        public TypeEntity TipoEntity { get; set; }

        public frmVerEntidade(IEntidadesApp EntidadesApp)
        {
            InitializeComponent();
            _EntidadesApp = EntidadesApp;
            cboTipoEntidade.SelectedIndex = 0;
            Permicao();
        }

        #region Permicao de Acesso
        int VerficaUsuario = int.Parse(UtilidadesGenericas.UsuarioPerfil.ToString());
        private void Permicao()
        {
            if (VerficaUsuario != 1)
            {
                if (UtilidadesGenericas.TemAcesso("Administração#Entidades#Criar") == false) { btnNova.Enabled = false; }
                if (UtilidadesGenericas.TemAcesso("Administração#Entidades#Eliminar") == false) { btnDelete.Enabled = false; }
                //if (UtilidadesGenericas.TemAcesso("Administração#Entidades#Imprimir") == false) { btnRelatorios.Enabled = false; }
            }
        }
        #endregion

        private void carregarEntidades()
        {
            if (_EntidadesApp != null)
            {
                var tipoSelecionado = cboTipoEntidade.SelectedItem.ToString();
                string titleEntity = cboTipoEntidade.SelectedIndex == 0 ? "CLIENTES" : "JURIDICA";
                if (tipoSelecionado == "Todos")
                {
                    EntidadesViewModel = _EntidadesApp.ListarEntidade(titleEntity, "Todos", TipoEntity, 1);
                }
                else
                {
                    EntidadesViewModel = _EntidadesApp.ListarEntidade(titleEntity, (cboTipoEntidade.SelectedIndex).ToString(), TipoEntity, 1);
                }
                Entidades = _EntidadesApp.Listar(1);
            }
        }

        private void btnRelatorio_Click(object sender, EventArgs e)
        {
            new frmVerRelatorioEntidades().ShowDialog();
        }

        private void frmVerEntidade_Load(object sender, EventArgs e)
        {
            carregarEntidades();
            gradeEntidades.DataSource = EntidadesViewModel;
            index = 0;
        }

        private void gridView1_RowClick(object sender, RowClickEventArgs e)
        {
            index = e.RowHandle;
        }

        private void Editar()
        {
            frmEntidade chamada = IOC.InjectForm<frmEntidade>();
            if (index > -1)
            {
                if (string.IsNullOrEmpty(tileView1.GetRowCellValue(index, "Codigo") + ""))
                {
                    return;
                }
                int codigo = Convert.ToInt32(tileView1.GetRowCellValue(index, "Codigo").ToString());
                chamada.SetTipoEntidade(TipoEntity);
                UtilidadesGenericas.ChamarNoPrincipal(chamada.EditarEntity(_EntidadesApp.GetByIdWithAllDependent(codigo)));

            }
            else MessageBox.Show("Selecione uma linha");
        }

        private void cboTipoEntidade_SelectedIndexChanged(object sender, EventArgs e)
        {
            carregarEntidades();
            gradeEntidades.DataSource = EntidadesViewModel;
        }
        
        private bool IsFisica()
        {
            return cboTipoEntidade.SelectedIndex == 0;
        }

        private void buttonEliminarEntidade_Click(object sender, EventArgs e)
        {
            if (temCertesa())
            {
                _EntidadesApp.RemoverEntidade(new EntidadesViewModel() { Codigo = EntidadesViewModel[index].Codigo, status = 0});
                mensagemResultado("Registro Elimida com sucesso!");
                frmVerEntidade_Load(sender, e);
            }
        }

        private void mensagemResultado(string mensagem)
        {
            MessageBox.Show(
                mensagem,
                "QUSETÃO",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private bool temCertesa()
        {
            var result = MessageBox.Show(
                "Tem Certesa que pretende eliminar este registro?", 
                "Aviso", 
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question
            ) == DialogResult.Yes;


            return result;
        }

        private void btnSelecionarEntity_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnNova_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmEntidade chamada = IOC.InjectForm<frmEntidade>();
            UtilidadesGenericas.ChamarNoPrincipal(chamada);
            chamada.SetTipoEntidade(TipoEntity);

            frmVerEntidade_Load(sender, e);
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            buttonEliminarEntidade_Click(sender, e);
        }

       

        private void gradeEntidades_Click(object sender, EventArgs e)
        {

        }

   

        private void tileView1_DoubleClick(object sender, EventArgs e)
        {
            Editar();
        }

        private void tileView1_ItemClick(object sender, DevExpress.XtraGrid.Views.Tile.TileViewItemClickEventArgs e)
        {
            index = e.Item.RowHandle;
        }
    }
}