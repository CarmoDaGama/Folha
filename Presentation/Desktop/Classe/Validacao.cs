using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.ComponentModel;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;


namespace Classe.Validacao
{
    public static class Validacao
    {
        private static Regex ExpressaoRegular;

        //----------------------------------------------
        //Métodos de Validação
        //----------------------------------------------


        public static bool ValidacaoEspacoEmBranco(Control textBox, ErrorProvider errorProvider)
        {
            bool checar = false;

            if (String.IsNullOrEmpty(textBox.Text))
            {
                errorProvider.SetError(textBox, "Por favor preencha o UserName");
                checar = true;
            }
            else
                errorProvider.SetError(textBox, null);

            return checar;

        }

        public static bool ValidacaoNome(Control textBox, ErrorProvider errorProvider)
        {
            bool checar = false;
            ExpressaoRegular = new Regex(@"^[a-zA-Z]");
            if (!(ExpressaoRegular.IsMatch(textBox.Text)) || (textBox.Text.Length < 3))
            {
                textBox.Focus();
                errorProvider.SetError(textBox, "Preencha o Name Correctamente!");
                checar = true;
            }
            else
                errorProvider.SetError(textBox, null);

            return checar;

        }

        public static bool ValidacaoEmail(Control textBox, ErrorProvider errorProvider)
        {
            bool checar = false;
            ExpressaoRegular = new Regex(@"^([\w\.\-]+)@((?!\.|\-)[\w\-]+)((\.(\w){2,3})+)$");
            if (!(ExpressaoRegular.IsMatch(textBox.Text)))
            {
                textBox.Focus();
                errorProvider.SetError(textBox, "Preencha o Email Correctamente!");
                checar = true;
            }
            else
                errorProvider.SetError(textBox, null);

            return checar;

        }

        
    }
}
