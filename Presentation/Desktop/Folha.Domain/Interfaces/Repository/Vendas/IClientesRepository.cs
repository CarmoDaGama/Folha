using Folha.Domain.Models.Vendas;
using System.Collections.Generic;

namespace Folha.Domain.Interfaces.Repository.Vendas
{
    public interface IClientesRepository
    {
        IEnumerable<Cliente> ListarClientes();
    }
}
