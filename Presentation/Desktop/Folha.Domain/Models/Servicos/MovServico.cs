namespace Folha.Domain.Models.Servicos
{
    public class MovServico : Entity
    {
        public string Descricao;
        public decimal Preco;
        public int Qtdade;
        public int Total;
        public Equipamento Equimento;
    }
}
