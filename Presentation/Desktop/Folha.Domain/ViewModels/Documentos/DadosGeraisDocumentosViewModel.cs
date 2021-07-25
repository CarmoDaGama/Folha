using System;

namespace Folha.Domain.ViewModels.Documentos
{
    public class DadosGeraisDocumentosViewModel
    {
        public string NomeDocumento { get; set; }
        public string CodAGT { get; set; }
        public string DescGeracao { get; set; }
        public string NomeCliente { get; set; }
        public string NifCliente { get; set; }
        public string TelCliente { get; set; }
        public string TipoCliente { get; set; }
        public string MoradaCliente { get; set; }
        public int NumeroDocumento { get; set; }
        public DateTime DataEmissao { get; set; }
        public string Hora { get; set; }
        public DateTime DataVencimento { get; set; }
        public string Moeda { get; set; }
        public string Cambio { get; set; }
        public string UsuarioCaixa { get; set; }
    }
}
