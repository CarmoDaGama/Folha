using Folha.Driver.Repository;
using Folha.Domain.Models.Db;
using Folha.Domain.Interfaces.Repository.Entidades;
using System;
using Folha.Domain.Models.Entidades;
using System.Collections.Generic;
using System.Data;
using Folha.Driver.Repository.Data;
using Folha.Domain.Helpers;

namespace Folha.Driver.Repository.Entidades
{
    public class FornecedoresRepository : RepositoryBase<DbDTO>, IFornecedoresRepository
    {
        public void Delete(Fornecedores fornecedor)
        {
            Db.Delete(fornecedor);
        }

        public object Get(Fornecedores fornecedor)
        {
            return Db.GetById<Fornecedores>(fornecedor.codigo);
        }

        public object GetAll(Fornecedores fornecedor)
        {
            return Db.GetEntities<Fornecedores>();
        }

        public void Insert(Fornecedores fornecedor)
        {
            Db.Add(fornecedor); 
        }

        public IEnumerable<FornecedorBusca> ListarFornecedor(string criterios)
        {
            DataTable DtDados = new DataTable();
            try
            {
                string SQL = "select Fornecedores.codigo, Entidades.Nome, Entidades.Codigo from Fornecedores, Entidades where Fornecedores.CodEntidade = Entidades.Codigo";

                var ob = Conexao.ClienteSql.SELECT(SQL);
                DtDados = (DataTable)ob;
                var result = DataTableHelper.DataTableToList<FornecedorBusca>(DtDados);
                return result;
            }
            catch (Exception) { throw new Exception("Erro ao Listar"); }
        }

        public void Update(Fornecedores fornecedor)
        {
            Db.Update(fornecedor);
        }
    }
}
