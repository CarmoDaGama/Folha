using Folha.Domain.Interfaces.Repository;
using Folha.Domain.Models.Inventario;
using Folha.Domain.ViewModels.Inventario;
using System.Collections.Generic;

namespace Folha.Domain.Interfaces.Repository.Inventario
{
    public interface ITransferenciaProdutoRepository: IRepositoryBase<TransferenciaProduto>
    {
        int GetCodigoStock(int CodArmazem, int CodProduto);
        IEnumerable<TransferenciaProdutoViewModel> Listar(string criterios);
        TransferenciaProduto LerTransferencia(TransferenciaProduto Transferencia);
        TransferenciaProdutoViewModel Gravar(TransferenciaProdutoViewModel transferencia);
        void Delete(TransferenciaProduto transferencia);
        AlterarStockViewModel DiminuirStock(AlterarStockViewModel diminuir);
        bool ExisteNoArmazem(AlterarStockViewModel existe);
        AlterarStockViewModel AumentaStock(AlterarStockViewModel aumentar);
        AlterarStockViewModel InserirQtdadeArmazem(AlterarStockViewModel inserir);

    }
}
