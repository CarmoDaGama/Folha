namespace Folha.Domain.Models.Entidades
{
    public class Morada
    {
        public int IDMorada { get; set; }
        public int IDPessoa { get; set; }
        public Entidades Entidade { get; set; }
        public string DescricaoMorada { get; set; }
        public int status { get; set; }
    }
}
