using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Models.Hospitalar
{
    public class Receitas
    {
        /*Receitas.Codigo As Codigo, " +
        "CodMedico," +
        " Entidades.Nome as NomeMEdico, " +
        "Observacao " */
        public int Codigo { get; set; }
        public int CodPaciente { get; set; }
        public int CodMedico { get; set; }
        public int CodConsulta { get; set; }
        public string Observacao { get; set; }
        public string Data { get; set; }
        public int CodAtendimento { get; set; }
    }
}
