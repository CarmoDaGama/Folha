using System;
using System.IO;
using System.Windows.Forms;

namespace Folha.Domain.Helpers
{
  public  class Arquivos
    {
        public static void txt_GravarArquivo(string nomeArquivo, String conteudo)
        {
            if (File.Exists(nomeArquivo)) File.Delete(nomeArquivo);
            using (StreamWriter writer = new StreamWriter(nomeArquivo, true))
            {
                writer.Write(conteudo);
            }

        }
        public static string CriarCaminho(string nameFile, int usuarioID)
        {
            var path = string.Format(Application.StartupPath + @"\{0}\", usuarioID);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            path += nameFile;
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            return path;
        }
        public static void txt_AdicionaTexto(string Nome, string Conteudo)
        {
            StreamWriter writer = File.AppendText(Nome);

            writer.WriteLine(Conteudo);

            writer.Close();

        }
        public static string txt_LerArquivo(string Nome)
        {
            string res = "";

            if (File.Exists(Nome))
            {
                using (StreamReader Reader = new StreamReader(Nome))
                {
                    res = Reader.ReadToEnd();
                }
            }
            return res;
        }

        public int EliminaArquivo(string Path)
        {
            int res = 0;

            if (File.Exists(Path))
            {
                File.Delete(Path);
                res = 1;
            }
            else res = 0;

            return res;
        }
        private void AbrirExecutavel(string path)
        {

        }
        private int CriarPAsta()
        {
            int res = 0;

            return res;
        }
        public static string ConverterFicheiroParaBase64(string caminho)
        {
            byte[] bits = File.ReadAllBytes(caminho);
            string strbit = Convert.ToBase64String(bits);
            return strbit;
        }
    }
}
