using System;

namespace Folha.Domain.ViewModels.Financeiro
{
    public class CambiosViewModel
    {
        public int codigo { get; set; }
        public string NameKey { get { return "codigo"; } }
        public string Moeda1 { get; set; }
        public string Moeda2 { get; set; }
        public decimal cambio { get; set; }
        public DateTime data { get; set; }
        public int estado { get; set; }
        public string Padrao { get; set; }
        public string Pretendida { get; set; }

    }
}
