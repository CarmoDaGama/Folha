using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.ViewModels.Frame.Entidades
{
    public class ContactoViewModel 
    {
        public string Codigo { get; set; }
        public string CodEntidade { get; set; }
        public string CodTipoContacto { get; set; }
        public string TipoContacto { get; set; }
        public string Descricao { get; set; }
    }
}
