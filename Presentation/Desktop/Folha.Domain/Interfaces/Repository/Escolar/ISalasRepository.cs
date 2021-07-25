using Folha.Domain.Models.Escolar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Interfaces.Repository.Escolar
{
    public interface ISalasRepository : IRepositoryBase<Salas>
    {
        IEnumerable<Salas> Listar(string criterios);
    }
}
