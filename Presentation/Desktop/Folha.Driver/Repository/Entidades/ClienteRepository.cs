using System;
using Folha.Domain.Models.Db;
using Folha.Domain.Interfaces.Repository.Entidades;
using Folha.Domain.Models.Vendas;

namespace Folha.Driver.Repository.Data.Repositories.Entidades
{
    public class ClienteRepository : RepositoryBase<DbDTO>, IClienteRepository
    {
        public void Delete(Cliente tabela)
        {
            throw new NotImplementedException();
        }

        public object Get(Cliente tabela)
        {
            throw new NotImplementedException();
        }

        public object GetAll(Cliente tabela)
        {
            throw new NotImplementedException();
        }

        public void Insert(Cliente tabela)
        {
            throw new NotImplementedException();
        }

        public void Update(Cliente tabela)
        {
            throw new NotImplementedException();
        }
    }
}
