using System;

namespace Folha.Domain.Models.Hospitalar
{
    public class AtendimentoHospitalar
    {
        public int Codigo { get; set; }
        public int CodPaciente{ get; set; }
        public int CodTipoConsulta { get; set; }
        public int CodUsuario { get; set; }
        public int CodDocumento { get; set; }
        public DateTime Data { get; set; }
        public string Facturado { get; set; }
        public int status { get; set; }

        public string Medico { get; set; }
        public string NumeroProcesso { get; set; }
        public string NumeroAmostra { get; set; }
        public string ViaDocumento { get; set; }
        public string Unidade { get; set; }
        public string VReferencia { get; set; }
    }
}
