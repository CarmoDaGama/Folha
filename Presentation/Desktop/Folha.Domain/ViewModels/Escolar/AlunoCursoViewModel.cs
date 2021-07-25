using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.ViewModels.Escolar
{
    public class AlunoCursoViewModel
    {
        public int CodConfirmacao { get; set; }
        public int CodTurma { get; set; }
        public string Turma { get; set; }
        public string Curso { get; set; }
        public string Classe { get; set; }
        public string AnoLectivo { get; set; }
    }
}
