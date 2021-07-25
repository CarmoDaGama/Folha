using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.ViewModels.Sistema
{

    public class DadosEmpresaViewModel
    {
        public int DocumentoId { get; set; }
        public string NomeFuncionario { get; set; }
        public DateTime DataHora { get; set; }
        public string Moeda { get; set; }
        public string Cambio { get; set; }
    }
}
