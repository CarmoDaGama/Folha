using System;

namespace Folha.Domain.ViewModels.Frame.Financeiro
{
    public class PagamentosViewModel
    {
        public int Numero { get; set; }
        public DateTime Data { get; set; }
        public string Descricao { get; set; }
        public string Forma { get; set; }
        public string Tipo { get; set; }
        public double Valor { get; set; }
        public string Estado { get; set; }
        public string Sigla { get; set; }
        public int Cambio { get; set; }
        public double TOTAL { get; set; }
    }
}
