using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using Folha.Domain.Models.Entidades;
using Folha.Domain.ViewModels.Entidades;

namespace Folha.Presentation.Desktop.Separadores.Entidades
{
    public partial class frmMorada : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public MoradaViewModel Morada { get; set; }
        public frmMorada()
        {
            InitializeComponent();
            Morada = new MoradaViewModel() { DescricaoMorada = "Nenhuma", IDPessoa = 1 };
        }

        private void btnFechar_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }
        public MoradaViewModel GetMorada()
        {
            ShowDialog();
            return Morada;
        }
        private void btnSaveClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (txtDescricaoMorada.Text.Equals(string.Empty))
            {
                MessageBox.Show("Preencha o campo Descriçaõ!");
                return;
            }
            Morada.DescricaoMorada = txtDescricaoMorada.Text;
            Close();
        }

        public MoradaViewModel EditarMorada(MoradaViewModel morada)
        {
            Morada = null;
            Morada = morada;
            txtDescricaoMorada.Text = morada.DescricaoMorada;
            ShowDialog();
            return Morada;
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            txtDescricaoMorada.Text = "";
        }
    }
}