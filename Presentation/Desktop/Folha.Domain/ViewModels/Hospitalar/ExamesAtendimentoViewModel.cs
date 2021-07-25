using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.ViewModels.Hospitalar
{
     public class ExamesAtendimentoViewModel
    {

        public int Codigo { get; set; }
        public string NameKey { get { return "Codigo"; } }
        public int CodPaciente { get; set; }
        public int CodExame { get; set; }
        public DateTime Data { get; set; }
        public int CodAtendimento { get; set; }
        public int CodProfissionalSaude { get; set; }
        //public int CodUsuario { get; set; }
        public string TipoResultado { get; set; }
        public string Estado { get; set; }
        public int status { get; set; }
        public ProfissionalSaudeViewModel ProfissionalSaude { get; set; } = new ProfissionalSaudeViewModel();
        public ForeignKey FKeyProfissional
        {
            get
            {
                return new ForeignKey()
                {
                    NameTable = "ProfissionalSaude",
                    NameEntity = "ProfissionalSaude",
                    NameFieldThis = "CodProfissionalSaude",
                    NameFieldOrigin = "Codigo"
                };
            }
        }
        public ExamesHospitalarViewModel ExamesHospitalar { get; set; } = new ExamesHospitalarViewModel();
        public ForeignKey FKeyExamesHospitalar
        {
            get
            {
                return new ForeignKey()
                {
                    NameTable = "ExamesHospitalar",
                    NameEntity = "ExamesHospitalar",
                    NameFieldThis = "CodExame",
                    NameFieldOrigin = "Codigo"
                };
            }
        }
        public PacientesViewModel Pacientes { get; set; } = new PacientesViewModel();
        public ForeignKey FKeyPacientes
        {
            get
            {
                return new ForeignKey()
                {
                    NameTable = "Pacientes",
                    NameEntity = "Pacientes",
                    NameFieldThis = "CodPaciente",
                    NameFieldOrigin = "Codigo"
                };
            }
        }


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
