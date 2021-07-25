using Folha.Driver.Repository;
using Folha.Domain.Models.Db;
using Folha.Domain.Interfaces.Repository.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Folha.Domain.Models.Entidades;

namespace Folha.Driver.Repository.Entidades
{
    public class FuncionariosRepository : RepositoryBase<DbDTO>, IFuncionariosRepository
    {
        public void Delete(Funcionarios funcionario)
        {
            Db.Delete(funcionario);
        }

        public object Get(Funcionarios funcionario)
        {
            return Db.GetById<Funcionarios>(funcionario.IDPessoa);
        }

        public object GetAll(Funcionarios funcionario)
        {
            return Db.GetEntities<Funcionarios>();
        }

        public void Insert(Funcionarios funcionario)
        {
            Db.Add(funcionario);
        }

        public void Update(Funcionarios funcionario)
        {
            Db.Update(funcionario);
        }
    }
}
