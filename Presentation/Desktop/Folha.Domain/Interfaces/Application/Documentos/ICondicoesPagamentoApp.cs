using Folha.Domain.Models.Documentos;
using Folha.Domain.ViewModels.Documentos;
using System.Collections.Generic;

namespace Folha.Domain.Interfaces.Application.Documentos
{
    public interface ICondicoesPagamentoApp
    {
        IEnumerable<CondicoesPagamento> Listar(string criterios, bool Pesquisa);
        void Insert(CondicoesPagamento entity);
        void Update(CondicoesPagamento entity);
        void Delete(CondicoesPagamento entity);
        List<CondicoesPagamentoViewModel> GetAll();

        bool VerificarDup(string nomeTabela, Dictionary<string, object> dicionario);

    }
}
