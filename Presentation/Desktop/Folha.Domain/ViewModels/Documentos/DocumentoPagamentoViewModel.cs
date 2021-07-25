using System;

namespace Folha.Domain.ViewModels.Documentos
{
    public  class DocumentoPagamentoViewModel
    {
        public int Codigo { get; set; }
        public DateTime DataOperacao { get; set; }
        public string NameKey { get { return "Codigo"; } }
        public string DescricaoDocumento { get; set; }
        public int CodRecibo { get; set; }
        public decimal Taxa { get; set; } = 0.14m;
        public decimal Valor { get; set; }

    }
}
