
using Folha.Domain.Models.Vendas;
using Folha.Domain.Models.Db;
using Folha.Domain.Interfaces.Repository.Vendas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Driver.Repository.Vendas
{
    public class ClientesRepository : RepositoryBase<DbDTO>, IClientesRepository
    {
        public IEnumerable<Cliente> ListarClientes()
        {
            throw new NotImplementedException();
        }  
    }
}
