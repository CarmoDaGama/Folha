using System;

namespace Folha.Domain.ViewModels.UtilitariosConfiguracoes
{
    public class PeriodoBackupViewModel
    {
        public int Codigo { get; set; }
        public string NameKey { get { return "Codigo"; } }
        public string Periodo { get; set; }
        public string Caminho { get; set; }
        
        public int Intervalo { get; set; }
        public DateTime Data { get; set; }
    }
}
