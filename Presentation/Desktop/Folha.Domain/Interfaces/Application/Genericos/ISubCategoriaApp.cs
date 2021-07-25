using Folha.Domain.Models.Genericos;
using Folha.Domain.ViewModels.Genericos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Interfaces.Application.Genericos
{
    public interface ISubCategoriaApp
    {
        void Insert(SubCategoria Dados);
        void Update(SubCategoria Dados);
        IEnumerable<SubCategoriaViewModel> Listar(string descricao);
        SubCategoriaViewModel GetSubCategoria(int codSubCategoria);
    }
}
