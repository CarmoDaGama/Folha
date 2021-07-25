using Enterprise.Domain.Inventario;

namespace Enterprise.Domain.ViewModels.Inventarios
{
    public class CardArtigoViewModel
    {
        public int codigo { get; set; }

        public Produtos Artigo { get; set; }
        public string descricao { get { return Artigo.descricao; } }
        public byte[] Imagem { get { return Artigo.Imagem; } }

        public Armazens Armazem { get; set; }
    }
}
