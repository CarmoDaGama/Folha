using Folha.Domain.Interfaces.Repository;
using Folha.Domain.Models.Hospitalar;
using System.Collections.Generic;

namespace Folha.Domain.Interfaces.Repository.Hospitalar
{
    public interface IDiasSemanaRepository : IRepositoryBase<DiasSemanas>
    {
        IEnumerable<DiasSemanas> Listar();
    }
}
