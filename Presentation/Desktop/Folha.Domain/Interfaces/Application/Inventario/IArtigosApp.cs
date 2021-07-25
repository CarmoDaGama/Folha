using Folha.Domain.Models.Inventario;
using Folha.Domain.ViewModels.Inventario;
using Folha.Domain.ViewModels.Report;
using Folha.Domain.ViewModels.Frame.Inventario;
using System.Collections.Generic;

namespace Folha.Domain.Interfaces.Application.Inventario
{
    public interface IArtigosApp
    {
        void GravaComposicao(List<ComposicaoProdutosViewModel> lista);
        void addArtigo(ProdutosViewModel entity);
        Artigo Gravar(Artigo artigo);
        Artigo Eliminar(Artigo artigo);
        void EliminarArmazem(ProdutoStock armazem);
        Artigo Restaurar(Artigo artigo);
        List<ProdutosViewModel> GetAll();
        void EditArtigo(ProdutosViewModel entity);
        void RemoverArtigo(ProdutosViewModel artigo);
        ProdutosViewModel GetById(int codigo);
        List<SubistitutoViewModel> GetSubstitutos(int CodProduto);
        List<ArmazenProdutosViewModel> GetArmazens(int CodProduto);
        List<ComposicaoProdutosViewModel> GetComposicao(int CodProduto);
        List<FornecedorProdutosViewModel> GetFornecedores(int CodProduto);

        bool VerificarDup(string nomeTabela, Dictionary<string, object> dicionario);


        void DeleteArmazem(ArmazenProdutosViewModel delete);
        void DeleteFornecedor(FornecedorProdutosViewModel delete);
        void DeleteComposicao(ComposicaoProdutosViewModel delete);
        void DeleteSubstituto(SubistitutoViewModel delete);
        IEnumerable<RelListagemArtigosViewModel> ListagemArtigos(string Preco, int Index, int CodArmazem);
        IEnumerable<RelMovArtigosViewModel> RelMovArtigos(string dataInicial, string dataFinal, int CodArmazem);
        DataViewModel RetornaDataMovArtigo(int CodArmazem);
        IEnumerable<RelMovArtigosViewModel> ArtigosVendidos(int CodArmazem);
        DataViewModel RetornaDataArtigosVendidos(int CodArmazem);
        IEnumerable<RelListagemArtigosViewModel> SemControloStock(int CodArmazem);
        IEnumerable<RelListagemArtigosViewModel> TabelaPreco(int CodArmazem, string Preco);
        IEnumerable<RelListagemArtigosViewModel> ListaPreco(int CodArmazem);
        IEnumerable<RelListagemArtigosViewModel> ListagemRetenção(string dataInicial, string dataFinal, int CodArmazem);
        DataViewModel RetornaDataRetencao(int CodArmazem);
        void UpdateStok(ProdutoStock entity);

    }

}
