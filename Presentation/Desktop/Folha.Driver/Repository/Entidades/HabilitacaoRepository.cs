using Folha.Driver.Repository;
using Folha.Domain.Models.Db;
using Folha.Domain.Interfaces.Repository.Entidades;
using System;
using Folha.Domain.Models.Entidades;
using Folha.Driver.Repository.Data;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using Folha.Domain.Helpers;

namespace Folha.Driver.Repository.Entidades
{
    public class HabilitacaoRepository : RepositoryBase<DbDTO>, IHabilitacaoRepository
    {
        public void Delete(Habilitacoes habilitacao)
        {
            Conexao.ClienteSql.DELETE("Habilitacoes", "Codigo ='" + habilitacao.Codigo + "'");
        }

        public object Get(Habilitacoes habilitacao)
        {
            var obj = Conexao.ClienteSql.SELECT("SELECT * FROM Habilitacoes");

            DataTable dtadados = (DataTable)obj;

            var result = Folha.Domain.Helpers.DataTableHelper.DataTableToList<Habilitacoes>(dtadados).Where(p => p.Codigo == habilitacao.Codigo).FirstOrDefault();

            return result;
        }

        public object GetAll(Habilitacoes pessoa)
        {
            var result = new List<Habilitacoes>();

            var obj = Conexao.ClienteSql.SELECT("SELECT * FROM Habilitacoes");

            DataTable dtadados = (DataTable)obj;

            result = DataTableHelper.DataTableToList<Habilitacoes>(dtadados);

            return result;
        }

        public void Insert(Habilitacoes habilitacao)
        {
            DbDTO dto = new DbDTO()
            {
                Nome = "Habilitacoes",
                Campos = new string[] {
                    "Descricao"
                },
                Valores = new Object[] {
                    habilitacao.Descricao
                }
            };
            Conexao.ClienteSql.INSERT(dto.Nome, dto.Campos, dto.Valores);
        }
        public void Update(Habilitacoes Habilitacao)
        {
            DbDTO dto = new DbDTO()
            {
                Nome = "Habilitacoes",
                Campos = new string[] {
                    "Descricao"
                },
                Valores = new Object[] {
                    Habilitacao.Descricao
                }
            };
            Conexao.ClienteSql.UPDATE(dto.Nome, dto.Campos, dto.Valores, "Codigo ='" + Habilitacao.Codigo + "'");
        }
    }
}
