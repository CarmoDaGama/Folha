using System;

namespace Folha.Domain.Models.Entidades
{
    public class DocumentoEntidade
    {
        public int codigo { get; set; }
        public int CodEntidade { get; set; }
        public Entidades Entidade { get; set; }
        public int CodTipoDocumento { get; set; }
        public TipoDocumentoEntidade Tipo { get; set; }
        public string Numero { get; set; }
        public DateTime Emissao { get; set; }
        public DateTime Validade { get; set; }
    }
}
