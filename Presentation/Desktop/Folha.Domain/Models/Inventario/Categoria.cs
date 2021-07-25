using Folha.Domain.ViewModels.Sistema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Models.Inventario
{
    public class Categoria
    {
        public int codigo { get; set; }
        public string NameKey { get { return "codigo"; } }
        public string descricao { get; set; }
        public string Vender { get; set; }
        public byte[] Foto { get; set; }

        public Empresa.Empresa CabecalhoEmpresa { get; set; }

    }
}
