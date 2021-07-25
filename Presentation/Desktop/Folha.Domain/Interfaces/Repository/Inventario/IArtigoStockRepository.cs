using Folha.Domain.Interfaces.Repository;
using Folha.Domain.Models.Inventario;
using Folha.Domain.ViewModels.Inventario;
using Folha.Domain.ViewModels.Report;
using System.Collections.Generic;

namespace Folha.Domain.Interfaces.Repository.Inventario
{
    public interface IArtigoStockRepository : IRepositoryBase<ProdutoStockViewModel>
    {
        List<ProdutoStockViewModel> GetTodosPorCodArtigo(int codArtigo);
        object GetCodLast(); 
        IEnumerable<RelListagemArtigosViewModel> StoquePorProdutos(int CodArmazem);
        IEnumerable<RelListagemArtigosViewModel> RupturaStock(string CodArmazem);
        IEnumerable<RelListagemArtigosViewModel> ApoioContagem(int CodArmazem);
    }
}
