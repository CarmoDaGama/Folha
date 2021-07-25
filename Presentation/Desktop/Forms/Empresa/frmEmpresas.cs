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
using Folha.Domain.Interfaces.Application.Empresa;

namespace Folha.Presentation.Desktop.Forms.Empresa
{
    using Folha.Domain.Models.Empresa;
    using Folha.Domain.Helpers;

    public partial class frmEmpresas : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        private readonly IEmpresaApp _EmpresaApp;
        int CodEmpresa;
        private List<Empresa> lista;
        public frmEmpresas(IEmpresaApp EmpresaApp)
        {
            InitializeComponent();
            navigationFrame1.SelectedPage = navigationGrade;
            _EmpresaApp = EmpresaApp;
            Permicao();
        }

        private void btnLista_ItemClick(object sender, ItemClickEventArgs e)
        {
            navigationFrame1.SelectedPage = navigationLista;
        }

        private void btnGrade_ItemClick(object sender, ItemClickEventArgs e)
        {
            navigationFrame1.SelectedPage = navigationGrade;
        }
        #region PERMIÇÃO de Acesso
        int x = int.Parse(UtilidadesGenericas.UsuarioPerfil.ToString());
        private void Permicao()
        {
            if (x != 1)
            {
                if (UtilidadesGenericas.TemAcesso("Administração#Empresas#Criar") == false) { btnNovo.Enabled = false; }
                if (UtilidadesGenericas.TemAcesso("Administração#Empresas#Eliminar") == false) { btnEliminar.Enabled = false; }
            }
        }
        #endregion

        private void frmEmpresas_Load(object sender, EventArgs e)
        {
            Mostra();

        }

        private void Mostra()
        {
            lista = (List<Empresa>)_EmpresaApp.Listar();
            Gradempresa.DataSource = lista;
            gradeCartao.DataSource = lista;
        }

        private void btnActualizar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Mostra();
        }
    }
}