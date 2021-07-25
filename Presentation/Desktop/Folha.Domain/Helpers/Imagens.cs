using System;
using System.IO;
using System.Drawing;

namespace Folha.Domain.Helpers
{
  public  class Imagens
    {
        public static byte[] Imagem_Byte(System.Drawing.Image imageIn)
        {
            if (imageIn != null)
            {
                MemoryStream ms = new MemoryStream();
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                return ms.ToArray();
            }
            return new byte[92];
        }

        public static Image Byte_Imagem(byte[] byteArrayIn)
        {
            Image returnImage = UtilidadesGenericas.ImagemVazia;
            try
            {
                MemoryStream ms = new MemoryStream(byteArrayIn);
                returnImage = Image.FromStream(ms);
                return returnImage;

            }
            catch (Exception)
            {
                return returnImage;
            }
        }
    }
}
