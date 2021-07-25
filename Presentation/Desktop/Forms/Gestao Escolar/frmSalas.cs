using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using System.ComponentModel.DataAnnotations;
using Folha.Presentation.Desktop.Classe;
using Folha.Domain.Interfaces.Application.Escolar;
using Folha.Domain.Models.Escolar;

namespace Folha.Presentation.Desktop.Separadores.Gestao_Escolar
{
    public partial class frmSalas : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly ISalasApp _SalasApp;
        public frmSalas(ISalasApp SalasApp)
        {
            InitializeComponent();
            _SalasApp = SalasApp;

        }
      
        private void btnVoltar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void btnNovo_ItemClick(object sender, ItemClickEventArgs e)
        {
            Controle.DesabilitarBotao(btnEditar, btnEliminar);
            Controle.HabilitarBotao(btnSalvar, btnSalvarFechar);
            Controle.HabilitarControle(txtDescricao);
        }

        private void txtProcurar_TextChanged(object sender, EventArgs e)
        {
            gradeSalas.DataSource = _SalasApp.Listar(txtProcurar.Text);
        }

        private void btnSalvar_ItemClick(object sender, ItemClickEventArgs e)
        {
            _SalasApp.addSala(new Salas()
            {
                Descricao = txtDescricao.Text,
                
            });
            gradeSalas.DataSource = _SalasApp.Listar(null);
        }
    }
}