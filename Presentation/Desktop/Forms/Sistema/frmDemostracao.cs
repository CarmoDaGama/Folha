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
using System.Text.RegularExpressions;

namespace Folha.Presentation.Desktop.Separadores.Sistema

{
    public partial class frmDemostracao : DevExpress.XtraEditors.XtraForm
    {
        public frmDemostracao()
        {
            InitializeComponent();
        }

        private void demostracaoBTN_Click(object sender, EventArgs e)
        {
            validateEmail();
        }
        protected bool validateEmail()
        {
            bool checar = true;
            //Regex -> serve para fazer o controlo de caracteres
            Regex r = new Regex(@"^([\w\.\-]+)@((?!\.|\-)[\w\-]+)((\.(\w){1,3})+)$");

            if (!r.IsMatch(emailTB.Text))
            {
                errorProvider1.SetError(emailTB, "Erro ao digitar o email");
                checar = true;
            }
            else errorProvider1.SetError(emailTB, ""); return checar;
        }
        protected bool validateEmpresa()
        {
            bool checar = false;
            Regex r = new Regex(@"");
            if (!r.IsMatch(empresaTB.Text))
            {
                errorProvider1.SetError(empresaTB, "Erro de caracter");
            }
            else errorProvider1.SetError(empresaTB,""); return checar;
        }
    }
}