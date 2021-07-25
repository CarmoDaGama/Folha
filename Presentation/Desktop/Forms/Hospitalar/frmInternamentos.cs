using Folha.Domain.Interfaces.Application.Hospitalar;
using Folha.Domain.Models.Hospitalar;
using Folha.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Folha.Presentation.Desktop.Forms.Hospitalar
{
    public partial class frmInternamentos : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        IAtendimentoHospitalarApp _interApp;
        public List<PacienteInternado> ListaInternado { get; private set; }

        public frmInternamentos
        (IAtendimentoHospitalarApp interApp)
        {
            InitializeComponent();
           _interApp = interApp;
            Permicao();
        }

    #region Permicao de Acesso
    int VerficaUsuario = int.Parse(UtilidadesGenericas.UsuarioPerfil.ToString());
        private void Permicao()
        {
            if (VerficaUsuario != 1)
            {
                if (UtilidadesGenericas.TemAcesso("Administração#Utilizador#Imprimir") == false) { btnPrint.Enabled = false; }
            }
        }
        #endregion
       
        private void frmInternamentos_Load(object sender, EventArgs e)
        {
            VerEstados();
        }

  

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }


        private void cboInternamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            VerEstados();
        }

        private void VerEstados()
        {
            if (cboInternamento.SelectedItem.ToString() == "TODOS")
            {
                ListaInternado = (List<PacienteInternado>)_interApp.ListarTudo(null);
                GradeIntermento.DataSource = ListaInternado;
            }
            else if (cboInternamento.SelectedItem.ToString() == "INTERNADOS")
            {
                GradeIntermento.DataSource = _interApp.ListarTudo(null).Where(a => a.Estado == "INTERNADO");
              
            }
            else if (cboInternamento.SelectedItem.ToString() == "LIBERADOS")
            {
                GradeIntermento.DataSource = _interApp.ListarTudo(null).Where(a => a.Estado == "LIBERADO");
            }
        }
    }
}