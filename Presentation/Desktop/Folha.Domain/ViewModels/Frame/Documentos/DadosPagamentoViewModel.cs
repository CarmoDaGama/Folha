using System;

namespace Folha.Domain.ViewModels.Frame.Documentos
{
    public class DadosPagamentoViewModel
    {
        public int Codigo { get; set; }
        public int CodCaixa { get; set; }
        public int CodDoc { get; set; }
        public int CodCaixaOrigem { get; set; }
        public int CodCaixaDestino { get; set; }
        public int CodForma { get; set; }
        public int CodTurno { get; set; }
        public int CodCambio { get; set; }
        public int CodMoeda { get; set; }
        public int CodBanco { get; set; }
        public int CodConta { get; set; }
        public DateTime Data { get; set; }
        public double Valor { get; set; }
        public string Descricao { get; set; }
        public string Banco { get; set; }

    }
}
