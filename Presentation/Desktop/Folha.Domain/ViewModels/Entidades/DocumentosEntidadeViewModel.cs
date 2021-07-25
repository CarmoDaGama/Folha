using System;

namespace Folha.Domain.ViewModels.Entidades
{
    public class DocumentosEntidadeViewModel
    {
        public int codigo { get; set; }
        public string NameKey { get { return "codigo"; } }
        public int CodEntidade { get; set; }
        public int CodTipoDocumento { get; set; }
        public TiposDocumentosViewModel Tipo { get; set; } = new TiposDocumentosViewModel();
        public ForeignKey FKEntidade
        {
            get
            {
                return new ForeignKey()
                {
                    NameTable = "TiposDocumentos",
                    NameEntity = "Tipo",
                    NameFieldOrigin = "codigo",
                    NameFieldThis = "CodTipoDocumento"
                };
            }
        }
        public string Numero { get; set; }
        public string Emissao { get; set; }
        public string Validade { get; set; }
    }
}
