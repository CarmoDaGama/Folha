using Folha.Domain.Interfaces.Application.Documentos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Folha.Domain.Models.Documentos;
using Folha.Domain.ViewModels.Documentos;
using Folha.Domain.Interfaces.Repository.Documentos;

namespace Folha.Driver.Application.Documentos
{
    public class CondicoesPagamentoApp : ICondicoesPagamentoApp
    {
        private readonly ICondicoesPagamentoRepository _Repository;

        public CondicoesPagamentoApp(ICondicoesPagamentoRepository Repository)
        {
            _Repository = Repository;

        }

        public void Delete(CondicoesPagamento entity)
        {
            _Repository.Delete(entity);
        }

        public List<CondicoesPagamentoViewModel> GetAll()
        {
            return (List<CondicoesPagamentoViewModel>)_Repository.GetAll(new CondicoesPagamentoViewModel());
        }

        public void Insert(CondicoesPagamento entity)
        {
            _Repository.Insert(entity);
        }

        public IEnumerable<CondicoesPagamento> Listar(string criterios, bool Pesquisa)
        {
            return (List<CondicoesPagamento>)_Repository.Listar(criterios);
        }

        public void Update(CondicoesPagamento entity)
        {
            _Repository.Update(entity);
        }

        public bool VerificarDup(string nomeTabela, Dictionary<string, object> dicionario)
        {
            return _Repository.VerificarDup(nomeTabela, dicionario);
        }
    }
}
