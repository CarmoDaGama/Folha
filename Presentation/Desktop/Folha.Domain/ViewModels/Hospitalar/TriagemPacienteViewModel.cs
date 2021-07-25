using Folha.Domain.Enuns.Hospitalar;

namespace Folha.Domain.ViewModels.Hospitalar
{
    public class TriagemPacienteViewModel
    {
        public string NameKey { get { return "Codigo"; } }
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public RespostaTriagem Valor { get; set; }
        public int CodAtendimento { get; set; }
        public string Observacao { get; set; }
    }
}
