using System;

namespace Folha.Domain.ViewModels.Hospitalar
{
    public class MarcacaoConsultaViewModel
    {
        public int Codigo { get; set; }
        public int CodMedico { get; set; }
        public int CodEntidade { get; set; }
        public int CodAtendimento { get; set; }
        public int CodPaciente { get; set; }
        public int CodTipoConsulta { get; set; }
        public string TipoConsulta { get; set; }
        public string Medico { get; set; }
        public string Atendido { get; set; }
        public string Carteira { get; set; }
        public string HoraMarcada { get; set; }
        public string Facturado { get; set; }
        //public string Preco { get; set; }
        public decimal ValorConsulta { get; set; }
        public string Prioridade { get; set; }
        public string NomePaciente { get; set; }
        public DateTime Data { get; set; }
        public string HoraInicial { get; set; }
        public string TempoEstimado { get; set; }

        public string Anaminizes { get; set; }
        public string QueixaPrincipal { get; set; }
        public string EvolucaoTratamento { get; set; }
        public bool Editar { get; set; } = false;

    }
}
