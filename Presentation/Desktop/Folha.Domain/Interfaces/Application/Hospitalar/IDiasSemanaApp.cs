using Folha.Domain.Models.Hospitalar;
using System.Collections.Generic;

namespace Folha.Domain.Interfaces.Application.Hospitalar
{
    public interface IDiasSemanaApp
    {
        IEnumerable<DiasSemanas> Listar();
    }
}
