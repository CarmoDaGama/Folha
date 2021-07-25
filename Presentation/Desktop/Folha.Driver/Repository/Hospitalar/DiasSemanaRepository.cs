using System;
using System.Collections.Generic;
using Folha.Driver.Repository;
using Folha.Domain.Models.Hospitalar;
using Folha.Domain.Models.Db;
using Folha.Domain.Interfaces.Repository.Hospitalar;
using System.Data;
using Folha.Driver.Repository.Data;

namespace Folha.Driver.Repository.Hospitalar
{
    public class DiasSemanaRepository : RepositoryBase<DbDTO>, IDiasSemanaRepository
    {
        public void Delete(DiasSemanas tabela)
        {
            throw new NotImplementedException();
        }

        public object Get(DiasSemanas tabela)
        {
            throw new NotImplementedException();
        }

        public object GetAll(DiasSemanas tabela)
        {
            throw new NotImplementedException();
        }

        public void Insert(DiasSemanas tabela)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DiasSemanas> Listar()
        {
            string SQL = "SELECT *from DiasSemana";
            Object obj = Conexao.ClienteSql.SELECT(SQL);
            DataTable dtadados = (DataTable)obj;
            var result = Folha.Domain.Helpers.DataTableHelper.DataTableToList<DiasSemanas>(dtadados);
            return result;
        }

        public void Update(DiasSemanas tabela)
        {
            throw new NotImplementedException();
        }
    }
}
