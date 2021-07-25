using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.ViewModels.Entidades
{
    public class PacienteDocumentoVeiwModel
    {
        public int codigo { get; set; }
        public int CodEntidade { get; set; }
        public int CodTipoDocumento { get; set; }
        public TiposDocumentosViewModel Tipo { get; set; }
        public string NomeTipo { get { return Equals(Tipo, null) ? string.Empty : Tipo.descricao; } }
        public string Numero { get; set; }
        public string Emissao { get; set; }
        public string Validade { get; set; }
    }
}
