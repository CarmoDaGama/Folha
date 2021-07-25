using Folha.Domain.Interfaces.Application.Inventario;
using Folha.Domain.Interfaces.Repository.Inventario;
using Folha.Domain.Models.Inventario;
using Folha.Domain.ViewModels.Inventario;
using Folha.Domain.Helpers;
using System;
using System.Collections.Generic;

namespace Folha.Driver.Application.Inventario
{

    public class CategoriaApp : ICategoriaApp
    {
        private readonly ICategoriasRepository _categoriaRepository;
   
        public CategoriaApp(ICategoriasRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
          
        }
        public void Delete(Categoria categoria)
        {
            _categoriaRepository.Delete(categoria);
        }

        public List<CategoriaViewModel> GetAll()
        {
            return (List<CategoriaViewModel>)_categoriaRepository.GetAll(new CategoriaViewModel());
        }

        public Categoria GetById(int codigo)
        {
            throw new NotImplementedException();
        }

        public List<CardCategoriaViewModel> GetCategorias()
        {
            var list = (List<Categoria>)Listar(null, false);
            return Mapper<Categoria, CardCategoriaViewModel>.Map(list);

        }

        public void Insert(Categoria entity)
        {
            _categoriaRepository.Insert(entity);
        }

        public IEnumerable<Categoria> ListarPopular(int Codigo)
        {
            return (List<Categoria>)_categoriaRepository.ListarPopular(Codigo);
        }

        public IEnumerable<Categoria> Listar(string criterios, bool pesquisar)
        {
            return (List<Categoria>)_categoriaRepository.Listar(criterios);
        }

        public void Update(Categoria entity)
        {
            _categoriaRepository.Update(entity);
        }

        public bool VerificarDup(string nomeTabela, Dictionary<string, object> dicionario)
        {
            return _categoriaRepository.VerificarDup(nomeTabela, dicionario);
        }
    }
}
