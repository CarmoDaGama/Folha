using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Folha.Domain.Interfaces.Application.UtilitariosConfiguracoes;
using Folha.Domain.Models.UtilitariosConfiguracoes;
using Folha.Domain.Helpers;
using Folha.Driver.Framework.IOC;
using Folha.Presentation.Desktop.Separadores.Utilitarios_Configuracoes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Folha.Presentation.Desktop.Forms.Utilitarios_Configuracoes
{
    public partial class frmUsuarios : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly IUsuarioNovoApp _UsuarioApp;
        private int index = 0;
        private int cod;
        public Usuarios usuario { get; set; }

        List<Usuarios> lista;

        public frmUsuarios(IUsuarioNovoApp UsuarioApp)
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
                if (UtilidadesGenericas.TemAcesso("Administração#Usuarios#Criar") == false) { btnNovo.Enabled = false; }
                if (UtilidadesGenericas.TemAcesso("Administração#Usuarios#Eliminar") == false) { btnEliminar.Enabled = false; }
                //if (UtilidadesGenericas.TemAcesso("Administração#Utilizador#Imprimir") == false) { btnPrint.Enabled = false; }
            }
        }
        #endregion

        public void Mostrar()
        {
            lista = (List<Usuarios>)_UsuarioApp.Listar(null, false);
            gradeUsuario.DataSource = lista;
            index = UtilidadesGenericas.ListaNula(lista) ? -1 : 0;
        }
        private void gridUsuario_DoubleClick(object sender, EventArgs e)
        {
            if (gridUsuario.RowCount > 0)
            {
                try
                {
                    UtilidadesGenericas.Busca.Codigo = gridUsuario.GetRowCellValue(index, "codigo").ToString();
                    UtilidadesGenericas.Busca.Alterou = false;
                    frmUsuario chamada = IOC.InjectForm<frmUsuario>();
                    UtilidadesGenericas.ChamarNoPrincipal(chamada);
                    if (UtilidadesGenericas.Busca.Alterou) Mostrar();
                }
                catch (Exception)
                {
                    UtilidadesGenericas.MsgShow( 
                        "Erro",
                        "Seleciona uma linha ", 
                        MessageBoxIcon.Error,
                        MessageBoxButtons.OK);
                }

            }
        }

        private void gridUsuario_RowClick(object sender, RowCellClickEventArgs e)
        {
            cod = int.Parse(gridUsuario.GetRowCellValue(e.RowHandle, "codigo").ToString());
            index = e.RowHandle;
            usuario = lista.Where(u => u.codigo == cod).FirstOrDefault();
        }

        private void btnNovo_ItemClick(object sender, ItemClickEventArgs e)
        {
            UtilidadesGenericas.Busca.Codigo = string.Empty;
            frmUsuario chamada = IOC.InjectForm<frmUsuario>();
            UtilidadesGenericas.ChamarNoPrincipal(chamada);

            if (UtilidadesGenericas.Busca.Alterou) Mostrar();
        }

        private void frmusuarios_Load(object sender, EventArgs e)
        {
            Mostrar();

        }

        private void btnEliminar_ItemClick(object sender, ItemClickEventArgs e)
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
        public Usuarios GetUsuario()
        {
            btnSelecionar.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            ShowDialog();
            return usuario;
        }

        private void btnSelecionar_ItemClick(object sender, ItemClickEventArgs e)
        {
            usuario = new Usuarios() { codigo = lista[index].codigo, Nome = lista[index].Nome };
            Close();
        }

        private void btnFechar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }
    }
}