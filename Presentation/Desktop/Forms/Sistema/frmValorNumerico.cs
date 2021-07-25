using System;
using System.Windows.Forms;
using Folha.Domain.Helpers;
namespace Folha.Presentation.Desktop.Forms.Sistema
{
    public partial class frmValorNumerico : DevExpress.XtraEditors.XtraForm
    {
        public bool Password;
        public int CodDocumento;
        public string CodArmazem;
        public string codProduto;
        decimal Qt;

        public object Valor { get; private set; }
        public bool ValorValido { get; private set; }

        public frmValorNumerico()
        {
            InitializeComponent();
        }
        public object GetValorPercentual(object ValorAntigo, string Descritivo)
        {
            this.txtDesc.Properties.Mask.EditMask = "P3";
            this.txtDesc.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txtDesc.Properties.MaxLength = 7;
            return GetValor(ValorAntigo, Descritivo);
        }
        public object GetValor(object ValorAntigo, string Descritivo)
        {
            if (string.IsNullOrEmpty(Convert.ToDecimal(ValorAntigo).ToString("N3"))) return null;

            if (UtilidadesGenericas.CalculosFinanceiros.IsNumeric(ValorAntigo.ToString()) == true)
            {
                try
                {
                    Qt = decimal.Parse(ValorAntigo.ToString());
                    txtDesc.Text = Qt.ToString("N3");
                }
                catch { }
            }
            else
            {
                txtDesc.Text = ValorAntigo.ToString();
            }

            lblDescritivo.Text = Descritivo;

            txtDesc.Focus();
            txtDesc.SelectAll();
            ShowDialog();
            if (ValorValido)
            {
                return Valor;
            }
            else
            {
                return null;
            }
        }
        private void frmQtdade_Load(object sender, EventArgs e)
        {
            if (Password == true)
            {
                txtDesc.Properties.UseSystemPasswordChar = true;
            }
            txtDesc.Focus();
            txtDesc.Select(0, txtDesc.Text.Length);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var botaoClicado = (sender as Button);
            txtDesc.Text = txtDesc.Text + botaoClicado.Text.Trim();
            txtDesc.Focus();
        }
        private void brnEnter_Click(object sender, EventArgs e)
        {
            if (ValorValidado())
            {
                ValorValido = true;
                //var strDesc = txtDesc.Text.Replace("%", string.Empty).Replace(".", ",");
                Valor = Convert.ToDecimal(GetDescricao());

                this.Dispose();
            }

        }

        private bool ValorValidado()
        {
            if (string.IsNullOrEmpty(txtDesc.Text))
            {
                UtilidadesGenericas.MsgShow(
                    "Informe um Valor Numerico",
                    "Deve Informar Algum Valor",
                    MessageBoxIcon.Error,
                    MessageBoxButtons.OK
                );
                return false;
            }

            if (UtilidadesGenericas.CalculosFinanceiros.IsNumeric(GetDescricao()) == false)
            {
                UtilidadesGenericas.MsgShow(
                    "Informe um Valor Numerico",
                    "O Valor Incorrecto",
                    MessageBoxIcon.Error,
                    MessageBoxButtons.OK
                );
                return false;
            }
            Valor = decimal.Parse(GetDescricao());
            if ((decimal)Valor < 0)
            {
                UtilidadesGenericas.MsgShow(
                    "Informe um Valor Numerico",
                    "Valor Informado Invalido",
                    MessageBoxIcon.Error,
                    MessageBoxButtons.OK
                );
                return false;
            }
            return true;
        }

        private string GetDescricao()
        {
            if (txtDesc.Text.Contains(","))
            {
                return txtDesc.Text.Replace("%", string.Empty);
            }
            else
            {
                var desc = txtDesc.Text.Replace("%", string.Empty).Replace(".", ",");
                return desc;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                txtDesc.Text = txtDesc.Text + ",";
            }
            catch { }
        }
        private void txtDesc_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }

            if (e.KeyChar != 13) return;
            brnEnter_Click(sender, e);
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
            ValorValido = false;
        }
    }
    }