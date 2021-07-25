using Folha.Domain.Models.Escolar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Interfaces.Application.Escolar
{
    public interface ISalasApp
    {
        IEnumerable<Salas> Listar(string criterios);
        void addSala(Salas Sala);
    }
}
