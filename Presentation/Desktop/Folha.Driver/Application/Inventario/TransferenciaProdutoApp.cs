using Folha.Domain.Interfaces.Application.Inventario;
using Folha.Domain.Models.Inventario;
using Folha.Domain.Interfaces.Repository.Inventario;
using System.Collections.Generic;
using Folha.Domain.ViewModels.Inventario;

namespace Folha.Driver.Application.Inventario
{
    public class TransferenciaProdutoApp : ITransferenciaProdutoApp
    {
        private readonly ITransferenciaProdutoRepository _transRepository;
       
        public TransferenciaProdutoApp(ITransferenciaProdutoRepository transProdutoRepository)
        {
            _transRepository = transProdutoRepository;
        }

        public TransferenciaProduto GetById(int codigo)
        {
            return (TransferenciaProduto)_transRepository.Get(new TransferenciaProduto() { codigo = codigo });
        }
        public TransferenciaProdutoViewModel Gravar(TransferenciaProdutoViewModel transferencia)
        {
            return _transRepository.Gravar(transferencia);
        }
        public void Delete(TransferenciaProduto transferencia)
        {
            _transRepository.Delete(transferencia);

        }
        public TransferenciaProduto LerTransferencia(TransferenciaProduto Transferencia)
        {
            return _transRepository.LerTransferencia(Transferencia);
        }
        public IEnumerable<TransferenciaProdutoViewModel> Listar(string criterios, bool Pesquisa)
        {
            return (List<TransferenciaProdutoViewModel>)_transRepository.Listar(criterios);
        }

        public AlterarStockViewModel DiminuirStock(AlterarStockViewModel diminuir)
        {
            return _transRepository.DiminuirStock(diminuir);

        }

        public bool ExisteNoArmazem(AlterarStockViewModel existe)
        {
            return _transRepository.ExisteNoArmazem(existe);
        }

        public AlterarStockViewModel AumentaStock(AlterarStockViewModel aumentar)
        {
            return _transRepository.AumentaStock(aumentar);
        }

        public AlterarStockViewModel InserirQtdadeArmazem(AlterarStockViewModel inserir)
        {
            return _transRepository.InserirQtdadeArmazem(inserir);
        }

        public int GetCodigoStock(int CodArmazem, int CodProduto)
        {
            return _transRepository.GetCodigoStock(CodArmazem, CodProduto);
        }
    }
}
