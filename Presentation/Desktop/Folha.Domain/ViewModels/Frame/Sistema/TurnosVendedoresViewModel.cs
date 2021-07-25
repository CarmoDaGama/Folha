using System;

namespace Folha.Domain.ViewModels.Frame.Sistema
{
    public class TurnosVendedoresViewModel
    {
        public int Codigo { get; set; }
        public string Estado{ get; set; }
        public string Usuario { get; set; }
        public string Caixa { get; set; }
        public DateTime Abertura { get; set; }
        public string StrAbertura {
            get {
                return Abertura == new DateTime() ? "INDEFINIDA" : Abertura.ToShortDateString();
            }
        }
        public DateTime Fecho { get; set; }
        public string StrFecho {
            get {
                return Fecho == new DateTime() ? "INDEFINIDA" : Fecho.ToShortDateString();
            }
        }
        public decimal Inicial { get; set; }
        public decimal Informado { get; set; }
        public decimal Vendas { get; set; }
        public decimal Total { get; set; }
        public decimal Quebra { get; set; }
        public string Supervisor { get; set; }
        public DateTime DataConfirmacao { get; set; }
        public string StrDataConfirmacao {
            get {
                return DataConfirmacao == new DateTime()? "INDEFINIDA" : DataConfirmacao.ToShortDateString();
            }
        }
        public string Confirmado { get; set; }
    }
}
