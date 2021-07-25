using Folha.Driver.Repository.Data;
using Folha.Driver.Repository;
using Folha.Domain.Models.UtilitariosConfiguracoes;
using Folha.Domain.ViewModels.UtilitariosConfiguracoes;
using Folha.Domain.Models.Db;
using Folha.Domain.Helpers;
using Folha.Domain.Interfaces.Repository.UtilitariosConfiguracoes;
using System;
using System.Collections.Generic;
using System.Data;

namespace Folha.Driver.Repository.UtilitariosConfiguracoes
{
    public class PeriodoBackupRepository : RepositoryBase<DbDTO>, IPeriodoBackupRepository
    {
        public void Delete(PeriodoBackupViewModel tabela)
        {
            throw new NotImplementedException();
        }

        public object Get(PeriodoBackupViewModel tabela)
        {
            return Db.GetById<PeriodoBackupViewModel>(tabela.Codigo);
        }

        public List<PeriodoBackupViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public object GetAll(PeriodoBackupViewModel tabela)
        {
            throw new NotImplementedException();
        }

        public PeriodoBackupViewModel GetById(int Codigo)
        {
            throw new NotImplementedException();
        }

        public PeriodoBackup Gravar(PeriodoBackup var)
        {
            string tabela = "PeriodoBackup";
            string[] campos = { "Periodo", "Intervalo", "Data","Caminho"};
            Object[] valores = { var.Periodo,var.Intervalo,var.Data, var.Caminho};
            string[] critX = { "Codigo = '" + var.Codigo + "'" };

            if (var.Codigo == 0)
            {
                Conexao.ClienteSql.INSERT(tabela, campos, valores);
            }
            else
            {
                Conexao.ClienteSql.UPDATE(tabela, campos, valores, critX);
            }
            string sql = "SELECT Periodo FROM PeriodoBackup WHERE Periodo LIKE '" + var.Periodo + "'";
            object ob = Conexao.ClienteSql.SELECT(sql);
            DataTable dt = (DataTable)ob;
            //var.Codigo = int.Parse(dt.Rows[0][0].ToString());
            return var;
        }

        public void Insert(PeriodoBackupViewModel tabela)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PeriodoBackup> Listar()
        {
            DataTable DtDados = new DataTable();
            string SQL = "SELECT *FROM PeriodoBackup ";
            var ob = Conexao.ClienteSql.SELECT(SQL);
            DtDados = (DataTable)ob;
            var result = DataTableHelper.DataTableToList<PeriodoBackup>(DtDados);
            return result;
        }

        public void Update(PeriodoBackupViewModel tabela)
        {
            throw new NotImplementedException();
        }
    }
}
