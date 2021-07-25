using Folha.Domain.Models.Financeiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Interfaces.Repository.Financeiro
{
    public interface ICambioRepository
    {
        IEnumerable<Cambio> Listar();
    }
}
