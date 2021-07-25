using Folha.Driver.Repository;
using Folha.Domain.Models.Db;
using Folha.Domain.Interfaces.Repository.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Folha.Domain.Models.Entidades;
using Folha.Driver.Repository.Data;
using System.Data;
using Folha.Domain.Helpers;
using Folha.Domain.ViewModels.Entidades;

namespace Folha.Driver.Repository.Entidades
{
    public class EntidadesContasRepository : RepositoryBase<DbDTO>, IEntidadesContasRepository
    {
        #region CRUD GENÉRICO
        public void Insert(EntidadesContasViewModel conta)
        {
            Db.Add(conta);
        }

        public object Get(EntidadesContasViewModel conta)
        {
            return Db.GetEntities<EntidadesContasViewModel>();
        }
        public void Update(EntidadesContasViewModel conta)
        {
            Db.Update(conta);
        }

        public void Delete(EntidadesContasViewModel conta)
        {
            Conexao.ClienteSql.DELETE("EntidadesContas", "codigo ='" + conta.codigo + "'");
        }

        public List<EntidadeConta> Listar(string criterios)
        {
            List<EntidadeConta> result = new List<EntidadeConta>();

            string SQL = "SELECT * From ContasBancarias " + criterios;

            Object obj = Conexao.ClienteSql.SELECT(SQL);

            DataTable dtadados = (DataTable)obj;

            result = Folha.Domain.Helpers.DataTableHelper.DataTableToList<EntidadeConta>(dtadados);

            return result;
        }

        public object GetAll(EntidadesContasViewModel tabela)
        {
            return Db.GetEntities<EntidadesContasViewModel>();
        }

        public List<EntidadesContasViewModel> GetAllForNorm(int entidadeId)
        {
            return Db.GetEntities<EntidadesContasViewModel>().Where(c => c.CodEntidade == entidadeId).ToList();
        }
        #endregion
    }
}
