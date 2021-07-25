namespace Folha.Domain.ViewModels.Financeiro
{
    public class Mostrar
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public string Movimentar { get; set; }
        public string ContaBancaria { get; set; }
        public string Banco { get; set; }
        public string CodBanco { get; set; }
        public int CodConta { get; set; }

        public Folha.Domain.Models.Empresa.Empresa CabecalhoEmpresa { get; set; }

    }
}
