using System;
using System.Collections.Generic;
using Folha.Domain.Interfaces.Application.Entidades;
using Folha.Domain.ViewModels.Entidades;
using Folha.Domain.Interfaces.Repository.Entidades;

namespace Folha.Driver.Application.Entidades
{
    public class ComissoesApp : IComissoesApp
    {
        private readonly IComissoesRepository _repository;

        public ComissoesApp(IComissoesRepository repository)
        {
            _repository = repository;
        }

        public List<ComissaoViewModel> CarregaComissoes(int documentoId)
        {
            return _repository.CarregaComissoes(documentoId);
        }

        public void Delete(ComissoesViewModel comissao)
        {
            _repository.Delete(comissao);
        }

        public void Insert(ComissoesViewModel comissao)
        {
            _repository.Insert(comissao);
        }

        public bool VerificarSeExisteEntidadeNaComissao(int entidadeId, int documentoId)
        {
            return _repository.VerificarSeExisteEntidadeNaComissao(entidadeId, documentoId);
        }
    }
}
