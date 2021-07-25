using DevExpress.XtraEditors;
using Folha.Domain.Helpers;
using Folha.Domain.Enuns.Genericos;
using System.Windows.Forms;
using DevExpress.XtraBars;
using System;

namespace Folha.Presentation.Desktop.Forms.Geral
{
    public partial class frmBuscaNomeCliente : XtraForm
    {
        public bool NomeSalvo { get; set; } = false;
        public frmBuscaNomeCliente()
        {
            InitializeComponent();
            ValidacaoControles.InserirEnventosDeValidacao(txtNomeCliente, TipoValidacao.Palavras);
        }

        private void btnSalvar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Salvar();
        }

        private void Salvar()
        {
            if (string.IsNullOrEmpty(txtNomeCliente.Text))
            {
                UtilidadesGenericas.MsgShow("Preencha o campo Nome Cliente para poder salvar", MessageBoxIcon.Error);
                return;
            }
            NomeSalvo = true;
            Close();
        }

        public string GetNomeCliente(string nome)
        {
            txtNomeCliente.Text = nome;
            ShowDialog();

            return NomeSalvo ? txtNomeCliente.Text : string.Empty;
        }
        private void txtNomeCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                Salvar();
            }
        }
    }
}