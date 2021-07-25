using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Models.UtilitariosConfiguracoes
{
    public class Usuarios
    {
        public int codigo { get; set; }
        public string Login { get; set; }
        public int CodEntidade { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Perfil { get; set; }
        public int CodPerfil { get; set; }
        public int Alterado { get; set; }

        public Empresa.Empresa CabecalhoEmpresa { get; set; }

    }
}
