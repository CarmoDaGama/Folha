using System;
using DevExpress.XtraEditors;
using Folha.Domain.Interfaces.Application.Documentos;
using Folha.Domain.Interfaces.Application.Sistema;
using DevExpress.XtraBars;
using Folha.Domain.Helpers;
using System.Windows.Forms;

namespace Folha.Presentation.Desktop.Forms.Turnos
{
    public partial class frmFecharTurno : XtraForm
    {
        private readonly IDocumentosApp _documentoApp;
        private ITurnosApp _turnoApp;
        public bool Fechedo { get; set; }
        public decimal SaldoTotal { get; private set; }
        public decimal SaldoVendas { get; private set; }
        public decimal Quebra { get; private set; }
        public int CodTurno { get; private set; }
        public decimal SaldoHospedagem { get; private set; }

        public frmFecharTurno(IDocumentosApp documentoApp, ITurnosApp turnoApp)
        {
            InitializeComponent();
            _documentoApp = documentoApp;
            _turnoApp = turnoApp;
        }

        public bool FecharTurno(decimal saldoTotal, decimal saldoVendas, decimal saldoHospedagem, int codTurno)
        {
            SaldoTotal = saldoTotal;
            SaldoVendas = saldoVendas;
            SaldoHospedagem = saldoHospedagem;
            CodTurno = codTurno;
            txtSaldoCurrent.Text = (0.0m).ToString("N2");
            ShowDialog();

            return Fechedo;
        }

        private void btnFechar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Fechar();
        }

        private void Fechar()
        {
            if (string.IsNullOrEmpty(txtSaldoCurrent.Text))
            {

                MessageBox.Show("Informe o Saldo Total que Possui!",
                  "Mensagem",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Error
              );
                return;
            }
            decimal saldoInformado = decimal.Parse(txtSaldoCurrent.Text);

            _turnoApp.FecharTurno(SaldoTotal, saldoInformado, SaldoVendas, SaldoHospedagem, CodTurno);
            Fechedo = true;
            Close();
        }

        private void btnVoltar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void frmFecharTurno_Load(object sender, EventArgs e)
        {
            txtSaldoTotal.Text = SaldoTotal.ToString() ;
        }

        private void txtSaldoCurrent_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtSaldoCurrent_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtSaldoQuebra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                Fechar();
            }
        }
    }
}
