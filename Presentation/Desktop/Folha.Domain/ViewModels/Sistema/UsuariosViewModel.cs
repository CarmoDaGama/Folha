using Folha.Domain.ViewModels.Entidades;

namespace Folha.Domain.ViewModels.Sistema
{
  public  class UsuariosViewModel 
    {
        public int codigo { get; set; }
        public string Nome { get; set; }
        public string NameKey { get { return "codigo"; } }
        public string Login { get; set; }
        public int CodEntidade { get; set; }
        public EntidadesViewModel Entidade { get; set; } = new EntidadesViewModel();
        public ForeignKey FKEntidade { 
            get
            {
                return new ForeignKey()
                {
                    NameTable = "Entidades",
                    NameEntity = "Entidade", 
                    NameFieldOrigin = "Codigo",
                    NameFieldThis = "CodEntidade"
                };
            }
        }
        public int CodPerfil { get; set; }
        public PerfilViewModel Perfil { get; set; } = new PerfilViewModel();
        public ForeignKey FKPerfil
        {
            get
            {
                return new ForeignKey()
                {
                    NameTable = "Perfil",
                    NameEntity = "Perfil",
                    NameFieldOrigin = "codigo",
                    NameFieldThis = "CodPerfil"
                };
            }
        }
        public string Senha { get; set; }
        public int Alterado { get; set; }
    }
}
