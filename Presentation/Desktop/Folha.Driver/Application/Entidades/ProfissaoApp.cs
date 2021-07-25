using Folha.Domain.Interfaces.Application.Entidades;
using System;
using System.Collections.Generic;
using Folha.Domain.Models.Entidades;
using Folha.Domain.Interfaces.Repository.Entidades;

namespace Folha.Driver.Application.Entidades
{
    public class ProfissaoApp : IProfissaoApp
    {
        private readonly IProfissaoRepository _Repository;

        public ProfissaoApp(IProfissaoRepository Repository)
        {
            _Repository = Repository;
        }

        public void Delete(Profissao profissao)
        {
            _Repository.Delete(profissao);
        }

        public Profissao GetById(int id)
        {
            return (Profissao)_Repository.Get(new Profissao() { Codigo = id });
        }

        public void Insert(Profissao profissao)
        {
            _Repository.Insert(profissao);
        }

        public List<Profissao> Listar()
        {
            return (List<Profissao>)_Repository.GetAll(new Profissao());
        }

        public void Update(Profissao profissao)
        {
            _Repository.Update(profissao);
        }
    }
}
