using Folha.Domain.Models.Financeiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Interfaces.Application.Financeiro
{
    public interface ICambioApp
    {
        IEnumerable<Cambio> Listar();
    }
}
