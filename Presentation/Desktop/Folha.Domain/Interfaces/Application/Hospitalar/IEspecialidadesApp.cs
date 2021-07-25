using Folha.Domain.Models.Hospitalar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Interfaces.Application.Hospitalar
{
    public interface IEspecialidadesApp
    {
        void Insert(Especialidades Dados);
        void Update(Especialidades Dados);
        void Delete(Especialidades Dados);
        IEnumerable<Especialidades> Listar(string criterios);
    }
}
