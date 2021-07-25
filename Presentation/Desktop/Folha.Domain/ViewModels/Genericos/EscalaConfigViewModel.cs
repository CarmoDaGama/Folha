namespace Folha.Domain.ViewModels.Genericos
{
    public class EscalaConfigViewModel
    {

        public int Codigo { get; set; }
        public string NameKey { get { return "Codigo"; } }
        public int CodEscala { get; set; }
        public int CodDia { get; set; }
        public string Entrada { get; set; }
        public string Semanas { get; set; }
        public string Saida { get; set; }
        public int Checa { get; set; }

        public Folha.Domain.Models.Hospitalar.DiasSemanas DiasSemana { get; set; }


    }
}
