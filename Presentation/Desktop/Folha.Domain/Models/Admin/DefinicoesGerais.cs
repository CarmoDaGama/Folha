using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Models.Administrador
{
    public class DefinicoesGerais 
    {

        public int codigo { get; set; }
        public bool VenderSemStock { get; set; }
        public bool HospedagemAberta { get; set; }
        public bool LucroPos { get; set; }
        public bool Documento { get; set; }
        public bool Cliente { get; set; }
        public bool ObrigatorioComissionario { get; set; }
        public bool ImprimirComissionarios { get; set; }
        public bool VariasLinhas { get; set; }

    }
}
