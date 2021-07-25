using Folha.Domain.Interfaces.Application.Escolar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Folha.Domain.Models.Escolar;
using Folha.Domain.Interfaces.Repository.Escolar;

namespace Folha.Driver.Application.Escolar
{
    public class DisciplinaApp : IDisciplinaApp
    {
        private readonly IDisciplinaRepository _DisciplinaRepository;
        public DisciplinaApp(IDisciplinaRepository DisciplinaRepository)
        {
            _DisciplinaRepository = DisciplinaRepository;
        }
        public void addDisciplina(Disciplina Disciplina)
        {
            //_DisciplinaRepository.Insert(Disciplina);
        }

        public IEnumerable<Disciplina> Listar(string criterios)
        {
            //return _DisciplinaRepository.Listar(criterios);

            return null;
        }
    }
}
