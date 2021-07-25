namespace Folha.Domain.Models.Hospitalar
{
    public class MovHospitalar
    {

        public int Codigo { get; set; }
        public int CodDocumento { get; set; }
        public int CodQuartosHospitalar { get; set; }
        public int CodTarifaHospitalar { get; set; }
        public string Checkin { get; set; }
        public int Horas { get; set; }
        //public int CodEntidade { get; set; }
        public string Quantidade { get; set; }
        public string Preco { get; set; }
        public string Tipo { get; set; }
        public string Quarto { get; set; }
        public string Tarifa { get; set; }


        public Documentos.Documentos Documenoto { get; set; }
        public QuartosHospitalar QuartosHospitalar { get; set; }
        public TarifaHospitalar TarifaHospitalar { get; set; }
    }
}
