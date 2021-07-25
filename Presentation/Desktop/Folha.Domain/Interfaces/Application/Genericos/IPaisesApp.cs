using Folha.Domain.Models.Genericos;
using System.Collections.Generic;

namespace Folha.Domain.Interfaces.Application.Genericos
{
    public interface IPaisesApp
    {
        IEnumerable<Pais> ListarPaises();
    }
}
