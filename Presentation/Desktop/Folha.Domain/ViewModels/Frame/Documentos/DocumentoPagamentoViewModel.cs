using System;

namespace Folha.Domain.ViewModels.Frame.Documentos
{
    public class DocumentoPagamentoViewModel
    {
        public int Codigo { get; set; }
        public DateTime Data { get; set; }
        public DateTime Hora { get; set; }
        public string Documento { get; set; }
        public string Tipo { get; set; }
        public string STR { get; set; }
    }
}
