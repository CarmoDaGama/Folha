namespace Folha.Domain.ViewModels.Inventario
{
    public class MovArtigoViewModel
    {
        public int CODIGO { get; set; }
        public string NOME { get; set; }
        public decimal PRECO { get; set; }
        public decimal Desconto { get; set; }
        public decimal Retencao { get; set; }
        public decimal Imposto { get; set; }
        public string ARMAZEM { get; set; }
        public decimal QTDADE { get; set; }
        public decimal TOTAL { get; set; }
        public int LINHA { get; set; }
        public int CODARMAZEM { get; set; }
    }
}
