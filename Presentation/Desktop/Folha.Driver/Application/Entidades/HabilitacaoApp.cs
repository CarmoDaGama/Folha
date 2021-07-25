using Folha.Domain.Interfaces.Application.Entidades;
using System;
using System.Collections.Generic;
using Folha.Domain.Models.Entidades;
using Folha.Domain.Interfaces.Repository.Entidades;

namespace Folha.Driver.Application.Entidades
{
    public class HabilitacaoApp : IHabilitacaoApp
    {
        private readonly IHabilitacaoRepository _Repository;

        public HabilitacaoApp(IHabilitacaoRepository Repository)
        {
            this._Repository = Repository;
        }

        public Habilitacoes GetById(int id)
        {
            return (Habilitacoes)_Repository.Get(new Habilitacoes() { Codigo = id });
        }

        public void Insert(Habilitacoes habilitacao)
        {
            _Repository.Insert(habilitacao);  
        }

        public List<Habilitacoes> Listar()
        {
            return (List<Habilitacoes>)_Repository.GetAll(new Habilitacoes());
        }

        public void Update(Habilitacoes habilitacao)
        {
            _Repository.Update(habilitacao);
        }
        public void Delete(Habilitacoes habilitacao)
        {
            _Repository.Delete(habilitacao);
        }
    }
}
