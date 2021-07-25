using Folha.Domain.Models.Vendas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Interfaces.Application.Vendas
{
    public interface IClientesApp
    {
        IEnumerable<Cliente> ListarClientes();
    }
}
