using Folha.Domain.Models.Sistema;
using Folha.Domain.Models.Db;
using Folha.Driver.Repository;
using Folha.Domain.Interfaces.Repository.Sistema;
using System;
using System.Collections.Generic;
using System.Data;

namespace Folha.Driver.Repository.Data.Repositories.Sistema
{
    public class PerfisRepository : RepositoryBase<DbDTO>, IPerfilRepository
    {
        public List<Perfil> ListarPerfis(string[] criterios)
        {
            var result = new List<Perfil>();

            string[] tabelas = { "Perfil" };
            string[] campos = { "codigo", "Descricao" };

            try
            {
                object ob = Conexao.ClienteSql.SELECT(tabelas, campos, criterios);
               DataTable  DtaDados = (DataTable)ob;
                return result;
            }
            catch (Exception er)
            {
                throw new Exception("Erro ao buscar perfil do usuarios\n" + er.Message);

            }

        
        }
    }
}
