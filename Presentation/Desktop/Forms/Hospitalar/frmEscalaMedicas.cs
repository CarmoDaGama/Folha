using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Folha.Domain.Interfaces.Application.Genericos;
using Folha.Domain.ViewModels.Genericos;
using Folha.Domain.Helpers;
using Folha.Driver.Framework.IOC;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Folha.Presentation.Desktop.Forms.Hospitalar
{
    public partial class frmEscalaMedicas : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly IEscalaApp _EscalaApp;
        private int indexGrid = -1;
        private EscalaViewModel Entity { get; set; }


        public frmEscalaMedicas(IEscalaApp EscalaApp)
        {
            InitializeComponent();
            _EscalaApp = EscalaApp;
            Permicao();
        }
        #region Permicao de Acesso
        int VerficaUsuario = int.Parse(UtilidadesGenericas.UsuarioPerfil.ToString());
        private int cod;

        private void Permicao()
        {
            if (VerficaUsuario != 1)
            {
                if (UtilidadesGenericas.TemAcesso("Hospital#Escala Medica#Criar") == false) { btnNovo.Enabled = false; }
                //if (UtilidadesGenericas.TemAcesso("Hospital#Escala Medica#Eliminar") == false) { btnP.Enabled = false; }
                if (UtilidadesGenericas.TemAcesso("Hospital#Escala Medica#Imprimir") == false) { btnPrint.Enabled = false; }
            }
        }
        #endregion

        private void gridEscala_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            indexGrid = e.RowHandle;
            txtDescricao.Text = gridEscala.GetRowCellValue(indexGrid, "Descricao").ToString();
            gradeDias.DataSource = _EscalaApp.ListEscalaConfig(gridEscala.GetRowCellValue(indexGrid, "Codigo").ToString());
            cod = int.Parse(gridEscala.GetRowCellValue(e.RowHandle, "Codigo").ToString());
        }

        private void frmEscalaMedica_Load(object sender, EventArgs e)
        {
            Mostrar();
        }

        private void Mostrar()
        {
            gradeEscala.DataSource = _EscalaApp.Listar(null);
        }

        private void btnVoltar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void btnSalvar_ItemClick(object sender, ItemClickEventArgs e)
        {
            UtilidadesGenericas.Busca.Alterou = false;
            UtilidadesGenericas.Busca.Codigo = string.Empty;
            IOC.InjectForm<frmEscalaMedica>().Show();
            if (UtilidadesGenericas.Busca.Alterou == true) Mostrar();

        }

        private void gridEscala_DoubleClick(object sender, EventArgs e)
        {
            //GridView view = (GridView)sender;
            //Point pt = view.GridControl.PointToClient(MousePosition);
            //GridHitInfo info = view.CalcHitInfo(pt);
            //UtilidadesGenericas.Busca.Codigo = gridEscala.GetRowCellValue(info.RowHandle, "Codigo").ToString();
            //UtilidadesGenericas.Busca.Alterou = false;
            //var container = new SimpleInjector.Container();
            //IOC.RegistrarInjecao(container);
            //container.GetInstance<frmEscalaMedica>().ShowDialog();
            //if (UtilidadesGenericas.Busca.Alterou) Mostrar();

        }

        private void btnEliminar_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (MessageBox.Show("Deseja Realmente Eliminar ", "Eliminar Produto", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            _EscalaApp.Apagar(new EscalaViewModel()
            {
                Codigo = cod,
            });
            MessageBox.Show("Produto Eliminado Com Sucesso", "Eliminar Produtos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Mostrar();
        }
    }
}