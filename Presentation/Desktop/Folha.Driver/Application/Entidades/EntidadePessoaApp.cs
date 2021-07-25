using Folha.Domain.Interfaces.Application.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Folha.Domain.ViewModels.Entidades;
using Folha.Domain.Interfaces.Repository.Entidades;
using Folha.Domain.Models.Entidades;
using Folha.Domain.Helpers;

namespace Folha.Driver.Application.Entidades
{
    public class EntidadePessoaApp : IEntidadePessoaApp
    {
        private readonly IEntidadePessoasRepository Repository;
        public EntidadePessoaApp(IEntidadePessoasRepository repository)
        {
            Repository = repository;
        }

        public EntidadesPessoaViewModel GetById(int id)
        {
            return (EntidadesPessoaViewModel)Repository.Get(new EntidadesPessoaViewModel() { CodEntidade = id });
        }

        public List<PessoaViewModel> GetPessoas()
        {
            var pessoas = (List<EntidadesPessoaViewModel>)Repository.GetAll(new EntidadesPessoaViewModel());
            var pessoasView = Mapper<EntidadesPessoaViewModel, PessoaViewModel>.Map(pessoas);
            return pessoasView;
        }

        public void Insert(EntidadesPessoaViewModel pessoa)
        {
            Repository.Insert(pessoa);
        }

        public void Update(EntidadesPessoaViewModel pessoa)
        {
            Repository.Update(pessoa);
        }
    }
}
