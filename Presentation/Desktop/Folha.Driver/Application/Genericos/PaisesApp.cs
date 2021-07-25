using Folha.Domain.Interfaces.Application.Genericos;
using Folha.Domain.Models.Genericos;
using Folha.Domain.Interfaces.Repository.Generico;
using System.Collections.Generic;

namespace Folha.Driver.Application.Genericos
{
    public class PaisesApp : IPaisesApp
    {
        private readonly IPaisesRepository _paisesRepository;

        public PaisesApp(IPaisesRepository paisesRepository)
        {
            this._paisesRepository = paisesRepository;
        }

        public IEnumerable<Pais> ListarPaises()
        {
            return _paisesRepository.Listar();
        }
    }
}
