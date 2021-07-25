using Folha.Domain.Enuns.Genericos;
using System.Windows.Forms;
namespace Folha.Domain.Helpers
{
    public static class ValidacaoControles
    {
        public static string CaracteresEspeciais {
            get
            {
                return "|\\!\"#£$§%€&/{([)]=}'?«»+*¨´`~^-_.:;,<>";
            }
        }
        public static string LetraMax
        {
            get
            {
                return "ZAQXSWCDEVFRBGTNHYMJUKILOÇP";
            }
        }
        public static string LetraMin
        {
            get
            {
                return "ZAQXSWCDEVFRBGTNHYMJUKILOÇP".ToLower();
            }
        }
        public static string Numeros
        {
            get
            { return "123456789"; }
        }
        private static void EventoTeclaPrecionarNumerosAndLentras(object enviador, KeyPressEventArgs evento)
        {
            if (CaracteresEspeciais.Contains(evento.KeyChar.ToString()))
            {
                evento.Handled = true;
            }
        }
        private static void EventoTeclaPrecionarNumeros(object enviador, KeyPressEventArgs evento)
        {
            if (evento.KeyChar == ',')
            {
                string texto = enviador.GetType().GetProperty("Text").GetValue(enviador).ToString();
                if (texto.Contains(","))
                {
                    evento.Handled = true;
                }
            }
            else if ((CaracteresEspeciais + " ").Contains(evento.KeyChar.ToString())||
               (LetraMax + LetraMin).Contains(evento.KeyChar.ToString()))
            {
                evento.Handled = true;
            }
        }
        private static void EventoTeclaPrecionarLetras(object enviador, KeyPressEventArgs evento)
        {
            if ((CaracteresEspeciais).Contains(evento.KeyChar.ToString()) ||
                 Numeros.Contains(evento.KeyChar.ToString()))
            {
                evento.Handled = true;
            }
        }
        public static void InserirEnventosDeValidacao(Control controle, TipoValidacao tipo)
        {
            switch (tipo)
            {
                case TipoValidacao.Nome:
                    controle.KeyPress += new KeyPressEventHandler(EventoTeclaPrecionarLetras);
                    break;
                case TipoValidacao.Palavras:
                    controle.KeyPress += new KeyPressEventHandler(EventoTeclaPrecionarNumerosAndLentras);
                    break;
                case TipoValidacao.Numero:
                    controle.KeyPress += new KeyPressEventHandler(EventoTeclaPrecionarNumeros);
                    break;
                default:
                    break;
            }
        }

    }
}
