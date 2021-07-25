namespace Folha.Domain.ViewModels.Entidades
{
    public class MoradaViewModel
    {
        public int IDMorada { get; set; }
        public string NameKey { get { return "IDMorada"; } }
        public int IDPessoa { get; set; }
        public string DescricaoMorada { get; set; }
        public int status { get; set; }
    }
}
