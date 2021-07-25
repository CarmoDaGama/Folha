using Enterprise.Application.Contract.Inventario;
using Enterprise.Domain.Inventario;
using Enterprise.Framework.ViewModels.Inventario;
using Enterprise.Repository.Contract.Inventario;
using Enterprise.Repository.Inventario;
using System.Collections.Generic;
using System;

namespace Enterprise.Application.Inventario
{
    public class TransProdutoApp : ITransProdutoApp
    {
        private readonly ITransProdutoRepository _transProdutoRepository;
        public TransProdutoApp(ITransProdutoRepository transProdutoRepository)
        {
            _transProdutoRepository = transProdutoRepository;
        }

        public void Delete(TransProduto transProduto)
        {
            _transProdutoRepository.Delete(transProduto);
        }

        public void Insert(TransProduto entity)
        {
            _transProdutoRepository.Insert(entity);
        }

        public IEnumerable<TransProduto> Listar(string criterios, bool Pesquisa)
        {
            return _transProdutoRepository.Listar(criterios, Pesquisa);
        }

        public void Update(TransProduto entity, string criterios)
        {
            _transProdutoRepository.Update(entity, criterios);
        }
    }
}
