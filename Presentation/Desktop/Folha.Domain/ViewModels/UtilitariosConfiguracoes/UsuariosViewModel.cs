using Folha.Domain.ViewModels.Entidades;

namespace Folha.Domain.ViewModels.UtilitariosConfiguracoes
{
    public  class UsuariosViewModel
    {
        public int codigo { get; set; }
        public string NameKey { get { return "codigo"; } }
        public string Login { get; set; }
        public int CodEntidade { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public int CodPerfil { get; set; }
        public PerfilViewModel Perfil { get; set; } = new PerfilViewModel();
        public ForeignKey FKeyPerfil
        {
            get
            {
                return new ForeignKey()
                {
                    NameTable = "Perfil",
                    NameEntity = "Perfil",
                    NameFieldThis = "CodPerfil",
                    NameFieldOrigin = "Codigo"
                };
            }
        }
         public EntidadesViewModel Entidades { get; set; } = new EntidadesViewModel();
        public ForeignKey FKeyEntidades
        {
            get
            {
                return new ForeignKey()
                {
                    NameTable = "Entidades",
                    NameEntity = "Entidades",
                    NameFieldThis = "CodEntidade",
                    NameFieldOrigin = "Codigo"
                };
            }
        }

    }
}
