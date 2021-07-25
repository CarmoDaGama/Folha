using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Models.UtilitariosConfiguracoes
{
    public class PeriodoBackup
    {
        public int Codigo { get; set; }
        public string Periodo { get; set; }
        public string Caminho { get; set; }
        public int Intervalo { get; set; }
        public DateTime Data { get; set; }
        

    }
}
