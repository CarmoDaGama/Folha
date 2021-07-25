using Folha.Domain.Interfaces.Application.Hospitalar;
using Folha.Domain.Models.Hospitalar;
using Folha.Domain.Interfaces.Repository.Hospitalar;
using System.Collections.Generic;

namespace Folha.Driver.Application.Hospitalar
{
    public class DiasSemanaApp : IDiasSemanaApp
    {

        private readonly IDiasSemanaRepository _Repository;

        public DiasSemanaApp(IDiasSemanaRepository Repository)
        {
            _Repository = Repository;
        }

        public IEnumerable<DiasSemanas> Listar()
        {
            return (List<DiasSemanas>)_Repository.Listar();
        }

    }
}
