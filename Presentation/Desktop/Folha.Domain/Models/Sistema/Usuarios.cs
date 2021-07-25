using Folha.Domain.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Models.Sistema
{
  public  class Usuarios 
    {
        public int codigo { get; set; }
        public string Nome { get; set; }
        public string NameKey { get { return "codigo"; } }
        public string Login { get; set; }
        public int CodEntidade { get; set; }
        public Entidades.Entidades Entidade { get; set; } = new Entidades.Entidades();
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
        public Perfil Perfil { get; set; } = new Perfil();
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
    }
}
