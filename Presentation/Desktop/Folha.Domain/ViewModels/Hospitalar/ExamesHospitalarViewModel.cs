namespace Folha.Domain.ViewModels.Hospitalar
{
    public class ExamesHospitalarViewModel
    {
        public int Codigo { get; set; }
        public string NameKey { get { return "Codigo"; } }
        public string Descricao { get; set; }
        public int CodImposto { get; set; }
        public int CodMotivoIsencao { get; set; }
        public int CodSubCategoria { get; set; }
        public decimal Custo { get; set; }
        public decimal Preco { get; set; }
        public decimal Lucro { get; set; }
        public decimal PrecoVenda { get; set; }
        public int status { get; set; }

        //public Folha.Domain.Models.Empresa.Empresa CabecalhoEmpresa { get; set; }
    }
}