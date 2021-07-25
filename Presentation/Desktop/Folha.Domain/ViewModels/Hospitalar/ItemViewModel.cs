namespace Folha.Domain.ViewModels.Hospitalar
{
    public class ItemViewModel
    {
        public ItemViewModel(string dadosItem)
        {
            var Sp = dadosItem.Trim().Split('?');
            if (Sp.Length > 2)
            {
                Tipo = Sp[0];
                Id = int.Parse(Sp[1]);
                IdPai =int.Parse(Sp[2]);
            }
        }
        public ItemViewModel()
        {

        }
        public int Id { get; set; }
        public string Tipo { get; set; } = string.Empty;
        public int IdPai { get; set; }
    }
}
 