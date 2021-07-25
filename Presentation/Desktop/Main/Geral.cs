using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise.Presentation.Desktop.Main
{
   public class Geral
    {
        /// <summary>
        /// ///
        /// </summary>
        public static bool AProcessar = true;
        public static object UsuarioCodigo = "";
        public static object UsuarioPerfil = "";

        public static bool TemPOS = false;
        public static bool TemRH = false;
        public static bool TemHotel = false;
        public static bool TemRestaurante = false;
        public static bool TemEscolar = false;
        public static bool TemServico = false;
        public static bool TemCyber = false;
        public static bool TemAcademia = false;
        public static bool TemHospitalar = false;
        public static bool TemFrotas = false;
        public static bool TemSeguranca = false;
        public static bool Pausa;
        public static bool TemPT = false;
        public static bool TemLavandaria = false;
        public static bool TemViagem = false;


        public static class Busca
        {
            public static string Banco { get; set; }
            public static string Conta { get; set; }
            public static string CodConta { get; set; }
            public static string Natureza { get; set; }
            public static string Sequencia { get; set; }

        }
    }
}
