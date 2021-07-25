using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.ViewModels.Admin
{
    public class DefinicoesGeraisViewModel
    {
        public int codigo { get; set; }
        public int VenderSemStock { get; set; }

        public bool StateVenderSemStock { get { return VenderSemStock == 1; } }

        public int HospedagemAberta { get; set; }
        public bool StateHospedagemAberta { get { return HospedagemAberta == 1; } }

        public int LucroPos { get; set; }
        public bool StateLucroPos { get { return LucroPos == 1; } }
        
        public int Documento { get; set; }
        public bool StateDocumento { get { return Documento == 1; } }

        public int Cliente { get; set; }
        public bool StateCliente { get { return Cliente == 1; } }

        public int ObrigatorioComissionario { get; set; }
        public bool StatComissionario { get { return ObrigatorioComissionario == 1; } }

        public int ImprimirComissionarios { get; set; }
        public bool StateImprimir { get { return ImprimirComissionarios == 1; } }

        public int VariasLinhas { get; set; }
        public bool StateLinhas { get { return VariasLinhas == 1; } }

    }
}
