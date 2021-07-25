using Folha.Domain.Models.Inventario;
using System.Collections.Generic;
using Folha.Domain.ViewModels.Inventario;
using Folha.Domain.ViewModels.Report;

namespace Folha.Domain.Interfaces.Application.Inventario
{
    public interface IArmazemApp
    {
        ArmazensViewModel GetById(int codigo);
        IEnumerable<Armazens> Listar(string criterios, bool Pesquisa);
        void Insert(Armazens entity);
        void Update(Armazens entity);
        void Delete(Armazens armazem);
        List<ArmazensViewModel> GetAll();

        bool VerificarDup(string nomeTabela, Dictionary<string, object> dicionario);
        IEnumerable<Armazens> Meus_Armazens();

    }
}
