using Folha.Domain.Models.UtilitariosConfiguracoes;
using Folha.Domain.ViewModels.Hospitalar;
using System;

namespace Folha.Domain.Models.Hospitalar
{
    public class Laboratorio
    {
        public int Codigo { get; set; }
        public int CodPaciente { get; set; }
        public string Nome { get; set; }
        public int CodExame { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public int CodAtendimento { get; set; }
        public int CodProfissional { get; set; }
        public string TipoResultado { get; set; }
        public string Estado { get; set; }
        public int status { get; set; }
        public Paciente Paciente { get; set; } = new Paciente();
        public ExamesHospitalar Exame { get; set; } = new ExamesHospitalar();
        public AtendimentoHospitalar Atendimento { get; set; } = new AtendimentoHospitalar();
        public ProfissinalSaude Profissional { get; set; } = new ProfissinalSaude();
        public Usuarios Usuario { get; set; } = new Usuarios();

        // Novos Dados
        public string Medico { get; set; }
        public string NumeroProcesso { get; set; }
        public string NumeroAmostra { get; set; }
        public string ViaDocumento { get; set; }
        public string Unidade { get; set; }
        public string VReferencia { get; set; }
        ///



    }
}
