using Folha.Domain.ViewModels.Sistema;

namespace Folha.Domain.ViewModels.Documentos
{
    public class AnuladosViewModel
    {
        public int codigo { get; set; }
        public string NameKey { get { return "codigo"; } }
        public int Numero { get; set; }
        public int CodUsuario { get; set; }
        public UsuariosViewModel Usuario { get; set; } = new UsuariosViewModel();
        public ForeignKey FKeyUsuario
        {
            get
            {
                return new ForeignKey()
                {
                    NameTable = "Usuarios",
                    NameEntity = "Usuario",
                    NameFieldThis = "CodUsuario",
                    NameFieldOrigin = "codigo"
                };
            }
        }
        public string Data { get; set; }
        public string Hora { get; set; }
        public string Motivo { get; set; }
    }
}
