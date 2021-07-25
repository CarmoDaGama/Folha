using Folha.Domain.Models.Inventario;
using Folha.Domain.ViewModels.Inventario;
using System.Collections.Generic;

namespace Folha.Domain.Interfaces.Application.Inventario
{
    public  interface IImpostoApp
    {
        List<ImpostoViewModel> GetAll();
        ImpostoViewModel GetById(int codigo);
        IEnumerable<Imposto> Listar(string criterios, bool Pesquisa);
        void Insert(ImpostoViewModel entity);
        void Update(ImpostoViewModel entity);
        void Delete(ImpostoViewModel categria);
        bool VerificarDup(string nomeTabela, Dictionary<string, object> dicionario);

    }
}
