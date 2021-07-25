using Folha.Domain.Interfaces.Repository;
using Folha.Domain.Models.Documentos;
using Folha.Domain.ViewModels.Documentos;
using System.Collections.Generic;

namespace Folha.Domain.Interfaces.Repository.Documentos
{
    public interface ICondicoesPagamentoRepository : IRepositoryBase<CondicoesPagamentoViewModel>
    {
        IEnumerable<CondicoesPagamento> Listar(string criterios);
        void Insert(CondicoesPagamento entity);
        void Update(CondicoesPagamento entity);
        void Delete(CondicoesPagamento entity);
        bool VerificarDup(string nomeTabela, Dictionary<string, object> dicionario);
    }
}
