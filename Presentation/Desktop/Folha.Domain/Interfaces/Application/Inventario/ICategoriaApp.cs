using Folha.Domain.Models.Inventario;
using Folha.Domain.ViewModels.Inventario;
using System.Collections.Generic;

namespace Folha.Domain.Interfaces.Application.Inventario
{
    public interface ICategoriaApp
    {
        Categoria GetById(int codigo);
        IEnumerable<Categoria> Listar(string criterios, bool pesquisar);
        List<CardCategoriaViewModel> GetCategorias();
        void Insert(Categoria entity);
        void Update(Categoria entity);
        void Delete(Categoria categria);
        List<CategoriaViewModel> GetAll();
        IEnumerable<Categoria> ListarPopular(int Codigo);

        bool VerificarDup(string nomeTabela, Dictionary<string, object> dicionario);



    }
}
