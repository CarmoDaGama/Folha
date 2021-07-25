namespace Folha.Domain.ViewModels.Inventario
{
    public class ImpostoViewModel
    {
        public int Codigo { get; set; }
        public int CodTipo { get; set; }
        public string Sigla { get; set; }
        public TipoImpostoViewModel Tipo { get; set; } = new TipoImpostoViewModel();
        public ForeignKey FKeyTipo
        {
            get
            {
                return new ForeignKey()
                {
                    NameTable = "TipoImposto",
                    NameEntity = "Tipo",
                    NameFieldThis = "CodTipo",
                    NameFieldOrigin = "Codigo"
                };
            }
        }
        public string NameKey { get { return "Codigo"; } }
        public string Descricao { get; set; }
        public decimal Percentagem { get; set; }
    }
}
