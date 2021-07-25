using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.ViewModels.Documentos
{
    public class CondicoesPagamentoViewModel
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public int Dias { get; set; }
    }
}
