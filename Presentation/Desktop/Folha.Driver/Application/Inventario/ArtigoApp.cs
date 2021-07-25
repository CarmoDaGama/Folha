using Folha.Domain.Interfaces.Application.Inventario;
using Folha.Domain.Interfaces.Repository.Inventario;
using Folha.Domain.Models.Inventario;
using Folha.Domain.ViewModels.Inventario;
using System.Collections.Generic;
using System;
using Folha.Domain.ViewModels.Report;
using Folha.Domain.Helpers;
using Folha.Domain.Enuns.Documentos;

namespace Folha.Driver.Application.Inventario
{
    public class ArtigoApp: IArtigosApp
    {
        private readonly IArtigosRepository _artigosRepository;
      
        public  ArtigoApp(IArtigosRepository artigosRepository)
        {
            this._artigosRepository = artigosRepository;
        }
        void IArtigosApp.addArtigo(ProdutosViewModel entity)
        {
            _artigosRepository.Insert(entity);
        }
        public List<ProdutosViewModel> GetAll()
        {
            return (List<ProdutosViewModel>)_artigosRepository.GetAll(new ProdutosViewModel()); 
        }

        public void RemoverArtigo(ProdutosViewModel artigo)
        {
            _artigosRepository.Delete(artigo);
        }

        public void EditArtigo(ProdutosViewModel entity)
        {
            _artigosRepository.Update(entity);
        }

        public ProdutosViewModel GetById(int codigo)
        {
            return (ProdutosViewModel)_artigosRepository.Get(new ProdutosViewModel() { Codigo = codigo });
        }

        public Artigo Gravar(Artigo artigo)
        {
            return _artigosRepository.Gravar(artigo);
        }
        public Artigo Eliminar(Artigo artigo)
        {
            return _artigosRepository.Eliminar(artigo);
        }


        public List<SubistitutoViewModel> GetSubstitutos(int CodProduto)
        {
            return _artigosRepository.GetSubstitutos(CodProduto);
        }

        public List<ArmazenProdutosViewModel> GetArmazens(int CodProduto)
        {
            return _artigosRepository.GetArmazens(CodProduto);
        }

        public List<ComposicaoProdutosViewModel> GetComposicao(int CodProduto)
        {
            return _artigosRepository.GetComposicao(CodProduto);
        }

        public List<FornecedorProdutosViewModel> GetFornecedores(int CodProduto)
        {
            return _artigosRepository.GetFornecedores(CodProduto);
        }

        public Artigo Restaurar(Artigo artigo)
        {
            return _artigosRepository.Restaurar(artigo);
        }
        public void EliminarArmazem(ProdutoStock armazem)
        {
            _artigosRepository.EliminarArmazem(armazem);
        }

        public void DeleteArmazem(ArmazenProdutosViewModel delete)
        {
            _artigosRepository.DeleteArmazem(delete);
        }

        public void DeleteFornecedor(FornecedorProdutosViewModel delete)
        {
            _artigosRepository.DeleteFornecedor(delete);
        }

        public void DeleteComposicao(ComposicaoProdutosViewModel delete)
        {
            _artigosRepository.DeleteComposicao(delete);
        }

        public void DeleteSubstituto(SubistitutoViewModel delete)
        {
            _artigosRepository.DeleteSubstituto(delete);
        }

        public bool VerificarDup(string nomeTabela, Dictionary<string, object> dicionario)
        {
            return _artigosRepository.VerificarDup(nomeTabela, dicionario);
        }

        public IEnumerable<RelListagemArtigosViewModel> ListagemArtigos(string Preco, int IndexPreco, int CodArmazem)
        {
            return _artigosRepository.ListagemArtigos(Preco, IndexPreco, CodArmazem);
        }

        public IEnumerable<RelMovArtigosViewModel> RelMovArtigos(string dataInicial, string dataFinal, int CodArmazem)
        {
            return _artigosRepository.RelMovArtigos(dataInicial, dataFinal, CodArmazem);
        }

        public DataViewModel RetornaDataMovArtigo(int CodArmazem)
        {
            return _artigosRepository.RetornaDataMovArtigo(CodArmazem);
        }

        public IEnumerable<RelMovArtigosViewModel> ArtigosVendidos( int CodArmazem)
        {
            return _artigosRepository.ArtigosVendidos(CodArmazem);
        }

        public DataViewModel RetornaDataArtigosVendidos(int CodArmazem)
        {
            return _artigosRepository.RetornaDataArtigosVendidos(CodArmazem);
        }

        public IEnumerable<RelListagemArtigosViewModel> SemControloStock(int CodArmazem)
        {
            return _artigosRepository.SemControloStock(CodArmazem);
        }

        public IEnumerable<RelListagemArtigosViewModel> TabelaPreco(int CodArmazem, string Preco)
        {
            return _artigosRepository.TabelaPreco(CodArmazem, Preco);
        }

        public IEnumerable<RelListagemArtigosViewModel> ListaPreco(int CodArmazem)
        {
            return _artigosRepository.ListaPreco(CodArmazem);
        }

        public IEnumerable<RelListagemArtigosViewModel> ListagemRetenção(string dataInicial, string dataFinal, int CodArmazem)
        {
            return _artigosRepository.ListagemRetenção(dataInicial, dataFinal, CodArmazem);
        }

        public DataViewModel RetornaDataRetencao(int CodArmazem)
        {
            return _artigosRepository.RetornaDataRetencao(CodArmazem);
        }

        public void UpdateStok(ProdutoStock entity)
        {
            _artigosRepository.UpdateStok(entity);
        }
        public void GravaComposicao(List<ComposicaoProdutosViewModel> lista)
        {
            _artigosRepository.GravaComposicao(lista);
        }
    }
}
