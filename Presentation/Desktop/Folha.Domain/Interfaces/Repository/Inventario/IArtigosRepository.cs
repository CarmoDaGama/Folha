using Folha.Domain.Models.Inventario;
using Folha.Domain.ViewModels.Inventario;
using Folha.Domain.ViewModels.Report;
using System.Collections.Generic;


namespace Folha.Domain.Interfaces.Repository.Inventario
{
    public  interface IArtigosRepository: IRepositoryBase<ProdutosViewModel>
    {
        void GravaComposicao(List<ComposicaoProdutosViewModel> lista);
        Artigo Gravar(Artigo artigo);
        Artigo Eliminar (Artigo artigo);
        void EliminarArmazem(ProdutoStock armazem);
        Artigo Restaurar(Artigo artigo);
        IEnumerable<Artigo> Listar(string criterios);
        List<ComposicaoProdutosViewModel> GetComposicao(int CodProduto);
        List<FornecedorProdutosViewModel> GetFornecedores(int CodProduto);
        List<SubistitutoViewModel> GetSubstitutos(int CodProduto);
        List<ArmazenProdutosViewModel> GetArmazens(int CodProduto);
        bool VerificarDup(string nomeTabela, Dictionary<string, object> dicionario);
        void DeleteArmazem(ArmazenProdutosViewModel delete);
        void DeleteFornecedor(FornecedorProdutosViewModel delete);
        void DeleteComposicao(ComposicaoProdutosViewModel delete);
        void DeleteSubstituto(SubistitutoViewModel delete);
        IEnumerable<RelListagemArtigosViewModel> ListagemArtigos(string Preco, int IndexPreco, int CodArmazem);
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
