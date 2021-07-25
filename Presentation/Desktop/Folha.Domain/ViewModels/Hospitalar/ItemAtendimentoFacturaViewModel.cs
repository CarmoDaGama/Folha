namespace Folha.Domain.ViewModels.Hospitalar
{
    public class ItemAtendimentoFacturaViewModel
    {
        public int ItemId { get; set; }
        public int AuxId { get; set; }
        public string Tipo { get; set; }
        public string Nome { get; set; }
        public string Data { get; set; }
        public string Imposto { get; set; }
        public string Preco { get; set; }
        public bool Facturar { get; set; }
        public string Facturado { get { return Facturar ? "SIM" : "NÃO"; } }
        public decimal Desconto { get; set; }
        public string PercentagemImposto { get; set; }
        public string CodImposto { get; set; }
        public string TipoImposto { get; set; }
        public string DescricaoImposto { get; set; }
        public bool Eliminar { get; set; } = false;
    }
}
