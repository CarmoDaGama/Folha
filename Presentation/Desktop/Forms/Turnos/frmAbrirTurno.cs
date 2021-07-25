using System;
using DevExpress.XtraEditors;
using Folha.Domain.Interfaces.Application.Sistema;
using Folha.Domain.Helpers;

namespace Folha.Presentation.Desktop.Forms.Turnos
{
    public partial class frmAbrirTurno : XtraForm
    {
        bool aberto = false;
        private readonly ITurnosApp App;

        public frmAbrirTurno(ITurnosApp app)
        {
            InitializeComponent();
            App = app;
        }
        public bool AbrirTurno()
        {
            txtSaldoInicial.Text = (0.0m).ToString("N2");
            ShowDialog();

            return aberto;
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btnAbrir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Abrir();
        }

        private void Abrir()
        {
            if (string.IsNullOrEmpty(txtSaldoInicial.Text))
            {
                UtilidadesGenericas.MsgShow("Informe o Saldo Inicial!");
                return;
            }
            decimal saldoInicial = decimal.Parse(txtSaldoInicial.Text);
            App.AbrirTurno(saldoInicial);
            aberto = true;
            Close();
        }

        private void txtSaldoInicial_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                Abrir();
            }
        }
    }
}
