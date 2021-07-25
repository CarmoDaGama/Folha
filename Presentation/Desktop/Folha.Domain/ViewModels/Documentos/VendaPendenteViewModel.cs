namespace Folha.Domain.ViewModels.Documentos
{
    public class VendaPendenteViewModel
    {
        public int Codigo { get; set; }
        public int CodDocumento { get; set; }
        public DocumentosViewModel Documento { get; set; }
        public ForeignKey FKeyDocumento
        {
            get
            {
                return new ForeignKey()
                {
                    NameTable = "Documentos",
                    NameEntity = "Documento",
                    NameFieldThis = "CodDocumento",
                    NameFieldOrigin = "codigo"
                };
            }
        }

    }
}
