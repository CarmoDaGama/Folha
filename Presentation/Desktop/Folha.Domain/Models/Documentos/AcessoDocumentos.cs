using Folha.Domain.Models.Sistema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Models.Documentos
{
    public class AcessoDocumentos
    {
        public int codigo { get; set; }
        public string NameKey { get { return "codigo"; } }
        public int CodUsuario { get; set; }
        public Usuarios Usuario { get; set; } = new Usuarios();
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
        public Operacoes Operacao { get; set; } = new Operacoes();
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
