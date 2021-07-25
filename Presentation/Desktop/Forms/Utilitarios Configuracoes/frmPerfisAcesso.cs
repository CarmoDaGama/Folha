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
using Folha.Domain.Interfaces.Application.UtilitariosConfiguracoes;
using Folha.Domain.Models.UtilitariosConfiguracoes;
using Folha.Driver.Framework.IOC;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Folha.Domain.Helpers;

namespace Folha.Presentation.Desktop.Forms.Utilitarios_Configuracoes
{
    public partial class frmPerfisAcesso : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        private readonly IPerfilNovoApp _PerfilApp;
        public int index;
        private int cod;
        public Perfil Perfil { get; set; }
        public int Index { get; private set; } = -1;
        List<Perfil> lista;
        public frmPerfisAcesso(IPerfilNovoApp perfilApp)
        {
            InitializeComponent();
            _PerfilApp = perfilApp;
            btnselecionar.Visibility = BarItemVisibility.Never;
            Index = 0;
            Permicao();
        }
        public Perfil GetPerfil()
        {
            ShowDialog();
            if (Perfil != (null) && Perfil.codigo > 0)
            {
                return Perfil;
            }
            return null;
        }
        public void Mostrar()
        {
            lista = (List<Perfil>)_PerfilApp.Listar(null, false);
            gradePerfil.DataSource = lista;
        }
        private void btnselecionar_ItemClick(object sender, ItemClickEventArgs e)
        {
            SelecionarPerfil();
        }
        private void frmPerfisAcesso_Load(object sender, EventArgs e)
        {
            Mostrar();
        }
        private void gridPerfil_RowClick(object sender, RowClickEventArgs e)
        {
            cod = int.Parse(gridPerfil.GetRowCellValue(e.RowHandle, "codigo").ToString());
            Index = e.RowHandle;
            Perfil = lista[Index];
        }

        private void btnEliminar_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (cod == 1)
            { MessageBox.Show("Este item não pode ser alterado!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

            if (DialogResult.Yes == (MessageBox.Show("Deseja Eliminar Registo?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question)))
            {
                try
                {
                    _PerfilApp.Delete(new Perfil()
                    {
                        codigo = cod,
                    });
                    MessageBox.Show("Registro excluído ", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lista = (List<Perfil>)_PerfilApp.Listar(null, false);
                    gradePerfil.DataSource = lista;
                }
                catch (Exception)
                {
                    throw new Exception("Erro ao Deletar\n");
                }

            }
        }

        private void btnNovo_ItemClick(object sender, ItemClickEventArgs e)
        {
            UtilidadesGenericas.Busca.Codigo =    string.Empty;
            UtilidadesGenericas.Busca.Descricao = string.Empty;
            UtilidadesGenericas.Busca.Acessos =   string.Empty;
            frmAddPerfil chamada = IOC.InjectForm<frmAddPerfil>();
            UtilidadesGenericas.ChamarNoPrincipal(chamada);
            if (UtilidadesGenericas.Busca.Alterou) Mostrar();


        }


        #region PERMIÇÃO de Acesso
        int x = int.Parse(UtilidadesGenericas.UsuarioPerfil.ToString());
        private void Permicao()
        {
            if (x != 1)
            {
                if (UtilidadesGenericas.TemAcesso("Administração#Perfil#Criar") == false) { btnNovo.Enabled = false; }
                if (UtilidadesGenericas.TemAcesso("Administração#Perfil#Eliminar") == false) { btnEliminar.Enabled = false; }
            }
        }
        #endregion
        public void SelecionarPerfil()
        {
            if (Index < 0) return;
            Perfil = lista.Where(p => p.codigo == cod).FirstOrDefault();
            Close();
        }
        private void gridPerfil_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (btnselecionar.Visibility == BarItemVisibility.Always)
                {
                    SelecionarPerfil();
                }
                else
                {
                    GridHitInfo info = UtilidadesGenericas.GetGridHitInfo(sender, MousePosition);
                    if (int.Parse(gridPerfil.GetRowCellValue(info.RowHandle, "codigo").ToString()) == 1)
                    {
                        MessageBox.Show("Este item não pode ser alterado!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    UtilidadesGenericas.Busca.Editar = true;
                    UtilidadesGenericas.Busca.Codigo = cod.ToString();
                    UtilidadesGenericas.Busca.Descricao = gridPerfil.GetRowCellValue(info.RowHandle, "Descricao").ToString();
                    UtilidadesGenericas.Busca.Acessos = gridPerfil.GetRowCellValue(info.RowHandle, "Acessos").ToString();
                    frmAddPerfil chamada = IOC.InjectForm<frmAddPerfil>();
                    UtilidadesGenericas.ChamarNoPrincipal(chamada);

                    if (UtilidadesGenericas.Busca.Alterou) Mostrar();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Selecina uma linha", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            Mostrar();
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }
    }

}