using Folha.Domain.Models.Db;
using Folha.Driver.Repository;
using Folha.Domain.Interfaces.Repository.Restaurante;
using System;

namespace Folha.Driver.Repository.Data.Repositories.Restaurante
{
    public class MesaRepository : RepositoryBase<DbDTO>, IMesaRepository
    {
        public void Ocupa_DesocupaMesa(Guid mesaID, Guid documentoVenda)
        {
            string[] campos = { "Venda" };
            Object[] valores = { documentoVenda };
            string[] crit = { "Codigo ='" + mesaID + "'" };
            Conexao.ClienteSql.UPDATE("Mesas", campos, valores, crit);
        }
    }
}
