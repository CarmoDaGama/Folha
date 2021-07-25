namespace Folha.Domain.Models.Documentos
{
    public class CondicoesPagamento
    {
        public int Codigo { get; set; }
        public string NameKey { get { return "Codigo"; } }
        public string Descricao { get; set; }
        public int Dias { get; set; }
    }
}
