using Folha.Domain.Models.Escolar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Interfaces.Repository.Escolar
{
    public interface IDisciplinaRepository : IRepositoryBase<Disciplina>
    {
        IEnumerable<Disciplina> Listar(string criterios);
    }
}
