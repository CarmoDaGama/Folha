using Folha.Domain.Interfaces.Application.Hospitalar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Folha.Domain.Models.Hospitalar;
using Folha.Domain.Interfaces.Repository.Hospitalar;

namespace Folha.Driver.Application.Hospitalar
{
    public class EspecialidadesApp : IEspecialidadesApp
    {
        private readonly IEspecialidadesRepository _EspecialidadesRepository;

        public EspecialidadesApp(IEspecialidadesRepository EspecialidadesRepository)
        {
            _EspecialidadesRepository = EspecialidadesRepository;
        }
        public void Delete(Especialidades Dados)
        {
            _EspecialidadesRepository.Delete(Dados);
        }

        public void Insert(Especialidades Dados)
        {
            _EspecialidadesRepository.Insert(Dados);
        }

        public IEnumerable<Especialidades> Listar(string criterios)
        {
          return  _EspecialidadesRepository.Listar(criterios);
        }

        public void Update(Especialidades Dados)
        {
            _EspecialidadesRepository.Update(Dados);
        }
    }
}
