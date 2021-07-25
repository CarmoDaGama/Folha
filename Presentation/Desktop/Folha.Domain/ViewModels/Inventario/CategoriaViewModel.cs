namespace Folha.Domain.ViewModels.Inventario
{
    public class CategoriaViewModel
    {
        public int codigo { get; set; }
        public string NameKey { get { return "codigo"; } }

        public string descricao { get; set; }
        public string Vender { get; set; }
        public byte[] Foto { get; set; }
    }
}
