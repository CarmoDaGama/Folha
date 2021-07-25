using Folha.Domain.Models.Inventario;
using Folha.Domain.ViewModels.Inventario;
using System.Collections.Generic;

namespace Folha.Domain.Interfaces.Repository.Inventario
{
    public interface  ICategoriasRepository : IRepositoryBase<CategoriaViewModel>
    {
        IEnumerable<Categoria> Listar(string criterios);
        IEnumerable<Categoria> ListarPopular(int Codigo);
        void Insert(Categoria entity);
        void Update(Categoria categoria);
        void Delete(Categoria categoria);
        bool VerificarDup(string nomeTabela, Dictionary<string, object> dicionario);
    }
}
