using Folha.Domain.Interfaces.Repository;
using Folha.Domain.Models.Hospitalar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Interfaces.Repository.Hospitalar
{
    public interface IEspecialidadesRepository : IRepositoryBase<Especialidades>
    {
        IEnumerable<Especialidades> Listar(string criterios);
    }
}
