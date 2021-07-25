using Folha.Domain.Interfaces.Application.Vendas;
using Folha.Domain.Models.Vendas;
using Folha.Domain.Interfaces.Repository.Vendas;
using System;
using System.Collections.Generic;

namespace Folha.Driver.Application.Vendas
{
    public class ClientesApp : IClientesApp
    {
        private readonly IClientesRepository _clientesRepository;

        public ClientesApp(IClientesRepository clientesRepository)
        {
            _clientesRepository = clientesRepository;
        }

        public IEnumerable<Cliente> ListarClientes()
        {
            return _clientesRepository.ListarClientes();
        }
    }
}
