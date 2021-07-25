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
    public class SalasApp : ISalasApp
    {
        private readonly ISalasRepository _SalasRepository;
        public SalasApp(ISalasRepository SalasRepository)
        {
            _SalasRepository = SalasRepository;
        }
        public void addSala(Salas Sala)
        {
            _SalasRepository.Insert(Sala);
        }

        public IEnumerable<Salas> Listar(string criterios)
        {
            return _SalasRepository.Listar(criterios);
        }
    }
}
