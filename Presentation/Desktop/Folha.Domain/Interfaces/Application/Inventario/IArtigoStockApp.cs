using Folha.Domain.Models.Inventario;
using Folha.Domain.ViewModels.Inventario;
using Folha.Domain.ViewModels.Report;
using Folha.Domain.ViewModels.Sistema;
using Folha.Domain.ViewModels.Frame.Inventario;
using System.Collections.Generic;

namespace Folha.Domain.Interfaces.Application.Inventario
{
    public interface IArtigoStockApp
    {
        ProdutoStockViewModel GetArtigoQtdTotal(int codArtigo);
        bool PodeMudarQtdArtigoComposicao(ProdutoStockViewModel artigoStock, OperacoesViewModel operacao);
        void MudarQtdComposicao(MovProdutosViewModel movArtigo);
        List<ProdutoStockViewModel> GetTodos();
        List<CardArtigoViewModel> GetArtigoCards();
        void Insert(ProdutoStockViewModel artigo);
        void Update(ProdutoStockViewModel artigo);
        void Delete(ProdutoStockViewModel artigo);
        ProdutoStockViewModel GetById(int id);
        List<ProdutoStockViewModel> GetAll();
        List<ArtigoViewModel> GetArtigos();
        List<ArtigoViewModel> GetTodosArtigos();

        int GetCodLastEntity();
        IEnumerable<RelListagemArtigosViewModel> StoquePorProdutos(int CodArmazem);
        IEnumerable<RelListagemArtigosViewModel> RupturaStock(string CodArmazem);
        IEnumerable<RelListagemArtigosViewModel> ApoioContagem(int CodArmazem);
    }
}
