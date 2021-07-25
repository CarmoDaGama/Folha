using Folha.Domain.ViewModels.Documentos;

namespace Folha.Domain.ViewModels.Entidades
{
    public class ComissoesViewModel
    {
        public int codigo { get; set; }
        public string NameKey { get { return "codigo"; } }
        public int codDocumento { get; set; }
        public DocumentosViewModel Documento { get; set; }
        public ForeignKey FKeyDocumento
        {
            get
            {
                return new ForeignKey()
                {
                    NameTable = "Documentos",
                    NameEntity = "Documento",
                    NameFieldThis = "codDocumento",
                    NameFieldOrigin = "codigo"
                };
            }
        }
        public int CodEntidade { get; set; }
        public EntidadesViewModel Entidade { get; set; }
        public ForeignKey FKeyEntidade
        {
            get
            {
                return new ForeignKey()
                {
                    NameTable = "Entidades",
                    NameEntity = "Entidade",
                    NameFieldThis = "CodEntidade",
                    NameFieldOrigin = "Codigo"
                };
            }
        }

    }
}
