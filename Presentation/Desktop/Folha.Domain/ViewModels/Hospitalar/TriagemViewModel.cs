using Folha.Domain.Models.Hospitalar;
using System;

namespace Folha.Domain.ViewModels.Hospitalar
{
    public class TriagemViewModel:Triagem
    {
        public DateTime Data { get; set; }
        public string Hora { get; set; }
    }
}
