
namespace Folha.Domain.ViewModels.Hospitalar
{
    public class ExameViewModel
    {
        /*ExamesHospitalar.Codigo,"+
        "ExamesAtendimento.Data As DataExame," +
        "ExamesHospitalar.Descricao," +
        "ExamesHospitalar.Lucro," +
        "ExamesHospitalar.Preco," +
        "ExamesHospitalar.PrecoVenda," +
        "ExamesAtendimento.CodAtendimento," +
        "ExamesAtendimento.Estado As EstadoAtendimento," +
        "ExamesAtendimento.TipoResultado," +
        "Motivoisencao.Descricao As Motivoisencao," +
        "Imposto.Descricao As DescricaoImposto," +
        "Imposto.Percentagem As ImpostoPercentagem " +*/
        public int Codigo { get; set; }
        public int CodExame { get; set; }
        public string Descricao { get; set; }
        public string DataExame { get; set; }
        public decimal Lucro { get; set; }
        public decimal Preco { get; set; }
        public decimal PrecoVenda { get; set; }
        public int CodAtendimento { get; set; }
        public string EstadoAtendimento { get; set; }
        public string TipoResultado { get; set; }
        public string Motivoisencao { get; set; }
        public string DescricaoImposto { get; set; }
        public decimal ImpostoPercentagem { get; set; }
        public string Facturado { get; set; }
        public string CodImposto { get; set; }
        public string DetalheImposto { get; set; }
        public string TipoImposto { get; set; }
    }
}
