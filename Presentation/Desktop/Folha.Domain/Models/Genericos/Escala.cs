using Folha.Domain.ViewModels.Genericos;
using System.Collections.Generic;

namespace Folha.Domain.Models.Genericos
{
    public class Escala
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public int HorasSemanal { get; set; }
        public List<EscalaConfigViewModel> EscalaConfig { get; set; }

    }
}
