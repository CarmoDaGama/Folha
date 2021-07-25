using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.ViewModels.Hospitalar
{
    public class TipoConsultaViewModel
    {
        public int Codigo { get; set; }
        public int CodEspecialidade { get; set; }
        public int CodImposto { get; set; }
        public int CodMotivoIsencao { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public string Tempo { get; set; }
        public string Especialidade { get; set; }
        public string Imposto { get; set; }
        public string MotivoIsencao { get; set; }
        public string Percentagem { get; set; }

    }
}
