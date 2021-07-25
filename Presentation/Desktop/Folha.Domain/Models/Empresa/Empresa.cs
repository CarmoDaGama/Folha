using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Models.Empresa
{
    public class Empresa
    {
        public int codigo { get; set; }
        public string Nome { get; set; }
        public string NIF { get; set; }
        public string Morada { get; set; }
        public string Telefones { get; set; }
        public string WebSite { get; set; }
        public string Email { get; set; }
        public byte[] Logotipo { get; set; }
        public int Validou { get; set; }


        public string TipoEmpresa { get; set; }
        public string Responsavel { get; set; }
        public string Slogan { get; set; }


    }
}
