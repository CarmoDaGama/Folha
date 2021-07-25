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
using Folha.Domain.Helpers;

namespace Folha.Presentation.Desktop.SubFormularios
{
    public partial class frmAlerta : DevExpress.XtraEditors.XtraForm
    {
        public frmAlerta()
        {
            InitializeComponent();
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
                    pictureErro.Image = Properties.Resources.erro;
                    break;
                case MessageBoxIcon.Question:
                    pictureErro.Image = Properties.Resources.Questao;
                    break;
                case MessageBoxIcon.Information:
                    pictureErro.Image = Properties.Resources.atencao;
                    break;
                case MessageBoxIcon.None:
                    pictureErro.Image = Properties.Resources.sucesso;
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
    }
}