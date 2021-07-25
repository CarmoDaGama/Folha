namespace Folha.Domain.Models.Hospitalar
{
    public class DiasSemanas
    {
        public int IDDias { get; set; }
        public string NameKey { get { return "Codigo"; } }
        public string DescricaoDias { get; set; }
        public string DayOfWeak { get; set; }
    }
}
