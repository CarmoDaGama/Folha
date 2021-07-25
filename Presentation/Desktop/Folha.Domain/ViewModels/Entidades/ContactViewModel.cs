using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.ViewModels.Entidades
{
    public class ContactViewModel
    { 
        public int codigo { get; set; }
        public int CodTipoContacto { get; set; }
        public TipoContactoViewModel Tipo { get; set; }
        public string NomeTipo { get { return Equals(Tipo, null) ? string.Empty : Tipo.descricao; } }
        public int CodEntidade { get; set; }
        public string descricao { get; set; }
    }
}
