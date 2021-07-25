using System;
using System.Drawing;
using System.Windows.Forms;

namespace Folha.Domain.Helpers
{
    public partial class frmAlerta : DevExpress.XtraEditors.XtraForm
    {
        public frmAlerta()
        {
            InitializeComponent();

        }

        private void frmAlerta_Shown(object sender, EventArgs e)
        {
            //Location = new Point(920, 550);
        }
        public bool Confimado = false;
        public bool chamarNotificacao( string titulo, string mensagem , MessageBoxIcon icon , MessageBoxButtons botoes  )
        {
            lbTitulo.Text = titulo;
            lbMensagem.Text = mensagem;
            RenderizarBotoes(botoes);
            RenderizarImagens(icon);

            ShowDialog();
            return Confimado;
           
               
        }

        private void RenderizarImagens(MessageBoxIcon icon)
        {
            switch (icon)
            {
                case MessageBoxIcon.Error:
                    pictureErro.Visible = true;
                    pictureInfo.Visible = false;
                    pictureQuestao.Visible = false;
                    pictureSucesso.Visible = false;
                    break;
                case MessageBoxIcon.Question:
                    pictureErro.Visible = false;
                    pictureInfo.Visible = false;
                    pictureQuestao.Visible = true;
                    pictureSucesso.Visible = false;
                    break;
                case MessageBoxIcon.Information:
                    pictureErro.Visible = false;
                    pictureInfo.Visible = true;
                    pictureQuestao.Visible = false;
                    pictureSucesso.Visible = false;
                    break;
                case MessageBoxIcon.None:
                    pictureErro.Visible = false;
                    pictureInfo.Visible = false;
                    pictureQuestao.Visible = false;
                    pictureSucesso.Visible = true;
                    break;

                default:
                    break;
            }
        }

        private void RenderizarBotoes(MessageBoxButtons botoes)
        {
            switch (botoes)
            {
                case MessageBoxButtons.OK:
                    panelCancelar.Visible = false;
                    panelConfirma.Visible = true;
                    break;
                case MessageBoxButtons.OKCancel:
                    panelCancelar.Visible = true;
                    panelConfirma.Visible = true;
                    break;
                case MessageBoxButtons.AbortRetryIgnore:
                    break;
                case MessageBoxButtons.YesNoCancel:
                    panelCancelar.Visible = true;
                    panelConfirma.Visible = true;
                    break;
                case MessageBoxButtons.YesNo:
                    panelCancelar.Visible = true;
                    panelConfirma.Visible = true;
                    break;
                case MessageBoxButtons.RetryCancel:
                    panelCancelar.Visible = true;
                    panelConfirma.Visible = false;
                    break;
                default:
                    break;
            }
        }

        private void btnConfimar_Click(object sender, EventArgs e)
        {
            Confimado = true;
            Close();
        }

        private void btnCanscelar_Click(object sender, EventArgs e)
        {

            Confimado = false;
            Close();
        }

        private void frmAlerta_Load(object sender, EventArgs e)
        {
            Location = new Point(UtilidadesGenericas.LarguraPai-418, UtilidadesGenericas.AlturaPai-200);
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            //var pointY = 2;
            frmAlerta vb = new frmAlerta();
            if (vb.Location.X <= 3)
            {
                timer1.Stop();
            }
            else
            {
               
                   vb.Location = new Point(Location.Y, Location.X + 10);

            }
        }
    }
}