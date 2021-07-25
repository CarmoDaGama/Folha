using System;
using Folha.Driver.Repository;
using Folha.Domain.Models.Entidades;
using Folha.Domain.Models.Db;
using Folha.Domain.Interfaces.Repository.Entidades;
using Folha.Driver.Repository.Data;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using Folha.Domain.Helpers;
using Folha.Domain.ViewModels.Entidades;

namespace Folha.Driver.Repository.Entidades
{
    public class EntidadePessoasRepository : RepositoryBase<DbDTO>, IEntidadePessoasRepository
    {
        public void Delete(EntidadesPessoaViewModel pessoa)
        {
            Conexao.ClienteSql.DELETE("EntidadesPessoa", "CodEntidade ='" + pessoa.CodEntidade + "'");
        }

        public object Get(EntidadesPessoaViewModel pessoa)
        {
            return Db.GetById<EntidadesPessoaViewModel>(pessoa.CodEntidade);
        }

        public object GetAll(EntidadesPessoaViewModel pessoa)
        {

            return Db.GetEntities<EntidadesPessoa>();
        }

        public void Insert(EntidadesPessoaViewModel pessoa)
        {
            Db.Add(pessoa);
        }
      
        public void Update(EntidadesPessoaViewModel pessoa)
        { 
            
            DbDTO dto = new DbDTO()
            {
                Nome = "EntidadesPessoa", Campos = new string[] {"CodEntidade","CodSexo","CodEstadoCivil","DataNascimento","CodHabilitacao","NomePai","NomeMae"},
                Valores = new Object[] {pessoa.CodEntidade, pessoa.CodSexo,pessoa.CodEstadoCivil,pessoa.DataNascimento,pessoa.CodHabilitacao, pessoa.NomePai,pessoa.NomeMae}
            };
                Conexao.ClienteSql.UPDATE(dto.Nome, dto.Campos, dto.Valores,"CodEntidade='"+pessoa.CodEntidade+"'");
            
        }

        
    }
}
