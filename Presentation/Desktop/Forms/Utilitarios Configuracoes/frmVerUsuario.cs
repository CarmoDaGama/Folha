using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Folha.Domain.Interfaces.Application.UtilitariosConfiguracoes;
using Folha.Domain.Models.UtilitariosConfiguracoes;
using Folha.Domain.Helpers;
using Folha.Driver.Framework.IOC;
using Folha.Presentation.Desktop.Classe;
using Folha.Presentation.Desktop.Forms.Apresenta_Doc;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Folha.Presentation.Desktop.Separadores.Utilitarios_Configuracoes
{
    public partial class frmVerUsuario : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        private readonly IUsuarioNovoApp _UsuarioApp;
        private int index=0;
        private int cod;
        public Usuarios usuario { get; set; }

        List<Usuarios> lista;


        public frmVerUsuario(IUsuarioNovoApp UsuarioApp)
        {
            InitializeComponent();
            _UsuarioApp = UsuarioApp;
            Permicao();
        }

        #region Permicao de Acesso
        int VerficaUsuario = int.Parse(UtilidadesGenericas.UsuarioPerfil.ToString());
        private void Permicao()
        {
            if (VerficaUsuario != 1)
            {
                if (UtilidadesGenericas.TemAcesso("Administração#Utilizador#Criar") == false) { btnAbrir.Enabled = false; }
                if (UtilidadesGenericas.TemAcesso("Administração#Utilizador#Eliminar") == false) { btnEliminar.Enabled = false; }
                if (UtilidadesGenericas.TemAcesso("Administração#Utilizador#Imprimir") == false) { btnPrint.Enabled = false; }
            }
        }
        #endregion

        #region Metodos
        public void Mostrar()
        {
            lista = (List<Usuarios>)_UsuarioApp.Listar(null, false);
            gradeUsuario.DataSource =lista;
        }
        #endregion
        private void btnNovo_Click(object sender, EventArgs e)
        {
            IOC.InjectForm<frmUsuario>().ShowDialog();
        }
        private void frmVerUsuario_Load(object sender, EventArgs e)
        {
            Mostrar();
        }


        private void gridUsuario_RowClick(object sender, RowClickEventArgs e)
        {
            cod = int.Parse(gridUsuario.GetRowCellValue(e.RowHandle, "codigo").ToString());
            index = e.RowHandle;
            usuario = lista.Where(u => u.codigo == cod).FirstOrDefault();
        }

        private void gridUsuario_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                GridView view = (GridView)sender;
                Point pt = view.GridControl.PointToClient(MousePosition);
                GridHitInfo info = view.CalcHitInfo(pt);
                UtilidadesGenericas.Busca.Codigo = gridUsuario.GetRowCellValue(info.RowHandle, "codigo").ToString();
                UtilidadesGenericas.Busca.Alterou = false;
                IOC.InjectForm<frmUsuario>().ShowDialog();
                if (UtilidadesGenericas.Busca.Alterou) Mostrar();
            }
            catch (Exception)
            {
                MessageBox.Show("Seleciona uma linha ", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
  

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btnAbrir_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UtilidadesGenericas.Busca.Codigo = string.Empty;
            var container = new SimpleInjector.Container();
            IOC.RegistrarInjecao(container);
            container.GetInstance<frmUsuario>().ShowDialog();
            if (UtilidadesGenericas.Busca.Alterou) Mostrar();
        }

        private void btnEliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (cod == 1)
                MessageBox.Show("Este item não pode ser alterado!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (DialogResult.Yes == (MessageBox.Show("Deseja Eliminar Registo?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Information)))
            {
                try
                {
                    _UsuarioApp.Delete(new Usuarios()
                    {
                        codigo = cod,
                    });
                    Mostrar();
                }
                catch (Exception)
                {
                    throw new Exception("Erro ao Deletar\n");
                }

            }
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            lista = (List<Usuarios>)_UsuarioApp.Listar(null, false);

            if (Equals(lista, null) || lista.Count == 0)
            {
                MessageBox.Show("Lista de Esta vazia");
                return;
            }
            lista[0].CabecalhoEmpresa = Controle.CabecalhoEmpresa;

            new frmApresentaReport().ApresentarReportUsuario(lista);
        }

        private void voltar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();

        }

        private void btnActualizar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Mostrar();
        }
        public Usuarios GetUsuario()
        {
            btnSelecionar.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            ShowDialog();
            return usuario;
        }

        private void btnSelecionar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            usuario = lista.Where(u => u.codigo == cod).FirstOrDefault();
            Close();
        }
    }
}