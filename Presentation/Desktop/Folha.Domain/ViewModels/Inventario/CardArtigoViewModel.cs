namespace Folha.Domain.ViewModels.Inventario
{
    public class CardArtigoViewModel
    {
        public int codigo { get; set; }

        public ProdutosViewModel Artigo { get; set; }
        public string descricao { get { return Artigo.descricao; } }
        public byte[] Foto { get { return Artigo.Imagem; } }
        public string preco1 { get { return Artigo.preco1 + " AKZ"; } }

        public ArmazensViewModel Armazem { get; set; }
    }
}
