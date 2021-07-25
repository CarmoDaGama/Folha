using System;

namespace Folha.Domain.ViewModels.Frame.Documentos
{
    public  class DocumentoViewModel
    {
        public int Codigo { get; set; }
        public DateTime Data { get; set; }
         
        public string Hora { get; set; }
        public string Documento { get; set; }

        public string Area { get; set; }

        public string Entidade { get; set; }

        public float Total { get; set; }

        public string Estado { get; set; }

        public string Usuario { get; set; }

        public string MovInventario { get; set; }

        public string MovFinanceiro { get; set; }

        public string Descritivo { get; set; }
        public string NomeItem { get; set; }
        public string Numero { get; set; }
        public string APP { get; set; }
    }
}
