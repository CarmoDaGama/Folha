namespace Folha.Domain.ViewModels.Documentos
{
    public class PendenteViewModel
    {
        //Documentos.codigo, Documentos.Data, Documentos.Hora, Operacoes.Nome, Operacoes.APP, Areas.descricao, VendaPendente.Cliente, Documentos.Total, 
        //Documentos.Estado, Documentos.CodOperacao, Documentos.CodArea, Documentos.CodEntidade AS CodCliente, Usuarios.Nome AS Usuario
        public int codigo { get; set; }
        public string Hora { get; set; }
        public string Data { get; set; }
        public string Nome { get; set; }
        public string APP { get; set; }
        public string descricao { get; set; }
        public string Cliente { get; set; }
        public decimal Total { get; set; }
        public string Estado { get; set; }
        public int CodOperacao { get; set; }
        public int CodArea { get; set; }
        public int CodEntidade { get; set; }
        public string Usuario { get; set; }
    }
}
