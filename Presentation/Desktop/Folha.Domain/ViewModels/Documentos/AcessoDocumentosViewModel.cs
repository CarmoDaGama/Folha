using Folha.Domain.Models.Sistema;
using Folha.Domain.ViewModels.Sistema;

namespace Folha.Domain.ViewModels.Documentos
{
    public class AcessoDocumentosViewModel
    {
        public int codigo { get; set; }
        public string NameKey { get { return "codigo"; } }
        public int CodUsuario { get; set; }
        public UsuariosViewModel Usuario { get; set; } = new UsuariosViewModel();
        public ForeignKey FKUsuario {
            get {
                return new ForeignKey()
                {
                    NameTable = "Usuarios",
                    NameEntity = "Usuario",
                    NameFieldOrigin = "codigo",
                    NameFieldThis = "CodUsuario"
                };
            }
        }
        public int CodOperacao { get; set; }
        public OperacoesViewModel Operacao { get; set; } = new OperacoesViewModel();
        public ForeignKey FKOperacao
        {
            get
            {
                return new ForeignKey()
                {
                    NameTable = "Operacoes",
                    NameEntity = "Operacao",
                    NameFieldOrigin = "codigo",
                    NameFieldThis = "CodOperacao"
                };
            }
        }
    }
}
