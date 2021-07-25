using Folha.Domain.Interfaces.Repository;
using Folha.Domain.Models.Entidades;
using System.Collections.Generic;

namespace Folha.Domain.Interfaces.Repository.Entidades
{
    public interface IFornecedoresRepository : IRepositoryBase<Fornecedores>
    {
        IEnumerable<FornecedorBusca> ListarFornecedor(string criterios);
    }
}
