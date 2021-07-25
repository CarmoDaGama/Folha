using Folha.Domain.Models.Inventario;
using Folha.Domain.ViewModels.Inventario;
using System.Collections.Generic;

namespace Folha.Domain.Interfaces.Application.Inventario
{
    public interface ITransferenciaProdutoApp
    {
        int GetCodigoStock(int CodArmazem, int CodProduto);
        IEnumerable<TransferenciaProdutoViewModel> Listar(string criterios, bool Pesquisa);
        TransferenciaProduto GetById(int codigo);
        TransferenciaProduto LerTransferencia(TransferenciaProduto Transferencia);
        TransferenciaProdutoViewModel Gravar(TransferenciaProdutoViewModel transferencia);
        void Delete(TransferenciaProduto transferencia);

        AlterarStockViewModel DiminuirStock(AlterarStockViewModel diminuir);
        bool ExisteNoArmazem(AlterarStockViewModel existe);
        AlterarStockViewModel AumentaStock(AlterarStockViewModel aumentar);
        AlterarStockViewModel InserirQtdadeArmazem(AlterarStockViewModel inserir);


    }
}
