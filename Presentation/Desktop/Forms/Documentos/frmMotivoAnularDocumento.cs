using Folha.Domain.Helpers;
using System;
using System.Windows.Forms;

namespace Folha.Presentation.Desktop.Forms.Documentos
{
    public partial class frmMotivoAnularDocumento : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMotivoAnularDocumento()
        {
            InitializeComponent();
        }

        private string Motivo { get; set; }

        public string GetDescricaoDoMotivo()
        {
            txtMotivo.Text = "";
            ShowDialog();
            return Motivo;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMotivo.Text))
            {
                UtilidadesGenericas.MsgShow("Insira uma Motivo!");
                return;
            }
            Motivo = txtMotivo.Text;
            Close();
        }

        private void utilidadesGenericas(string v)
        {
            throw new NotImplementedException();
        }
    }
}