using Folha.Domain.Interfaces.Application.Genericos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Folha.Domain.Models.Genericos;
using Folha.Domain.Interfaces.Repository.Generico;
using Folha.Domain.ViewModels.Genericos;

namespace Folha.Driver.Application.Genericos
{
    public class SubCategoriaApp : ISubCategoriaApp
    {
        private readonly ISubCategoriaRepository _SubCategoriaRepository;

        public SubCategoriaApp(ISubCategoriaRepository SubCategoriaRepository)
        {
            _SubCategoriaRepository = SubCategoriaRepository;
        }

        public SubCategoriaViewModel GetSubCategoria(int codSubCategoria)
        {
            return _SubCategoriaRepository.GetById(codSubCategoria);
        }

        public void Insert(SubCategoria Dados)
        {
            _SubCategoriaRepository.Insert(Dados);
        }

        public IEnumerable<SubCategoriaViewModel> Listar(string descricao)
        {
            return _SubCategoriaRepository.Listar(descricao);
        }

        public void Update(SubCategoria Dados)
        {
            _SubCategoriaRepository.Update(Dados);
        }
    }
}
