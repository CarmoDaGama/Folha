using Folha.Domain.Interfaces.Application.Inventario;
using Folha.Domain.Models.Inventario;
using Folha.Domain.Helpers;
using System;
using System.Windows.Forms;

namespace Folha.Presentation.Desktop.Forms.Armazens
{
    public partial class FrmEditArmazens : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly IArtigosApp _ArtigosApp;

        public FrmEditArmazens(IArtigosApp ArtigosApp)
        {
            InitializeComponent();
            _ArtigosApp = ArtigosApp;
            txtstockmax.Text = UtilidadesGenericas.Busca.QuantidadeMAx;
            txtstockmin.Text = UtilidadesGenericas.Busca.QuantidadeMin;
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (decimal.Parse(txtstockmin.Text) >= decimal.Parse(txtstockmax.Text))
            {
                MessageBox.Show("A Quantidade Minima não pode ser superio ou igual a Maxima", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtstockmin.Text =="")
            {
                MessageBox.Show("A Quantidade Minima não pode ser Vazia", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtstockmax.Text == "")
            {
                MessageBox.Show("A Quantidade Maxima não pode ser Vazia", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (UtilidadesGenericas.CalculosFinanceiros.IsNumeric(txtstockmax.Text) == false)
            {
                MessageBox.Show("Quantidade Invalida", "Informe a Quantidade Numerica", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return ;
            }
            if (UtilidadesGenericas.CalculosFinanceiros.IsNumeric(txtstockmin.Text) == false)
            {
                MessageBox.Show("Quantidade Invalida", "Informe a Quantidade Numerica", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _ArtigosApp.UpdateStok(new ProdutoStock()
            {
                Codigo = int.Parse(UtilidadesGenericas.Busca.CodNovoArmazem),
                StockMax = decimal.Parse(txtstockmax.Text),
                StockMin = decimal.Parse(txtstockmin.Text)
            });
            UtilidadesGenericas.Busca.Alterou = true;
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSalvar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (decimal.Parse(txtstockmin.Text) >= decimal.Parse(txtstockmax.Text))
            {
                MessageBox.Show("A Quantidade Minima não pode ser superio ou igual a Maxima", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtstockmin.Text == "")
            {
                MessageBox.Show("A Quantidade Minima não pode ser Vazia", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtstockmax.Text == "")
            {
                MessageBox.Show("A Quantidade Maxima não pode ser Vazia", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (UtilidadesGenericas.CalculosFinanceiros.IsNumeric(txtstockmax.Text) == false)
            {
                MessageBox.Show("Quantidade Invalida", "Informe a Quantidade Numerica", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (UtilidadesGenericas.CalculosFinanceiros.IsNumeric(txtstockmin.Text) == false)
            {
                MessageBox.Show("Quantidade Invalida", "Informe a Quantidade Numerica", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _ArtigosApp.UpdateStok(new ProdutoStock()
            {
                Codigo = int.Parse(UtilidadesGenericas.Busca.CodNovoArmazem),
                StockMax = decimal.Parse(txtstockmax.Text),
                StockMin = decimal.Parse(txtstockmin.Text)
            });
            UtilidadesGenericas.Busca.Alterou = true;
            Close();
        }

        private void btnFechar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
    }
}