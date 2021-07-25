using System;

namespace Folha.Domain.ViewModels.Admin
{
    public class NotificaoDocumentoViewModel
    {
        public int codigo { get; set; }
        public DateTime Data { get; set; }
        public string Hora { get; set; }
        public int CodUsuario { get; set; }
        public int CodArea { get; set; }
        public int CodMesa { get; set; }
        public int CodEntidade { get; set; }
        public int CodTurno { get; set; }
        public decimal Total { get; set; }
        public int CodOperacao { get; set; }
        public string Estado { get; set; }
        public string Descritivo { get; set; }
        public int NumeroOrdem { get; set; }
        public string Mascara { get; set; }

    }
}
