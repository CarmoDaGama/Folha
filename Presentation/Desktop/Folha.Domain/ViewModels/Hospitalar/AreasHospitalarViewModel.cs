namespace Folha.Domain.ViewModels.Hospitalar
{
    public class AreasHospitalarViewModel
    {
        public int Codigo { get; set; }
        public string NameKey { get { return "Codigo"; } }
        public string Descricao { get; set; }
    }
}