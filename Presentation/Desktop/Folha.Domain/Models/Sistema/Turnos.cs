using System;

namespace Folha.Domain.Models.Sistema
{
    public class Turnos
    {
        public int codigo { get; set; }
        public DateTime DataAbertura { get; set; }
        public DateTime DataFecho { get; set; }
        public decimal SaldoInicial { get; set; }
        public decimal SaldoInformado { get; set; }
        public decimal SaldoTotal { get; set; }
        public decimal SaldoVendas { get; set; }
        public decimal SaldoHospedagem { get; set; }
        public decimal QuebraCaixa { get; set; }
        public string Estado { get; set; }
        public int CodCaixa { get; set; }
        public int CodUsuario { get; set; }
        public Usuarios Usuario { get; set; }
        public ForeignKey FKeyUsuario
        {
            get
            {
                return new ForeignKey()
                {
                    NameTable = "Usuarios",
                    NameEntity = "Usuario",
                    NameFieldThis = "CodUsuario",
                    NameFieldOrigin = "codigo"
                };
            }
        }
        public int CodSuperVisor { get; set; }
        public DateTime DataConfirmacao { get; set; }

    }
}
