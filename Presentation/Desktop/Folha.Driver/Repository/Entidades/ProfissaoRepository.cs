using Folha.Driver.Repository;
using Folha.Domain.Models.Db;
using Folha.Domain.Interfaces.Repository.Entidades;
using System;
using Folha.Domain.Models.Entidades;
using Folha.Driver.Repository.Data;
using System.Data;
using System.Collections.Generic;
using System.Linq;

namespace Folha.Driver.Repository.Entidades
{
    public class ProfissaoRepository : RepositoryBase<DbDTO>, IProfissaoRepository
    {
        public void Delete(Profissao profissao)
        {
            Conexao.ClienteSql.DELETE("Profissao", "Codigo ='" + profissao.Codigo + "'");
        }
        
        public object Get(Profissao profissao)
        {
            var obj = Conexao.ClienteSql.SELECT("SELECT * FROM Profissao");

            DataTable dtadados = (DataTable)obj;

            var result = Folha.Domain.Helpers.DataTableHelper.DataTableToList<Profissao>(dtadados).Where(p => p.Codigo == profissao.Codigo).FirstOrDefault();

            return result;
        }

        public object GetAll(Profissao profissao)
        {
            var result = new List<Profissao>();

            var obj = Conexao.ClienteSql.SELECT("SELECT * FROM Profissao");

            DataTable dtadados = (DataTable)obj;

            result = Folha.Domain.Helpers.DataTableHelper.DataTableToList<Profissao>(dtadados);

            return result;
        }

        public void Insert(Profissao profissao)
        {
            DbDTO dto = new DbDTO()
            {
                Nome = "Profissao",
                Campos = new string[] {
                    "Descricao"
                },
                Valores = new Object[] {
                    profissao.Descricao
                }
            };
            Conexao.ClienteSql.INSERT(dto.Nome, dto.Campos, dto.Valores);
        }

        public void Update(Profissao profissao)
        {
            DbDTO dto = new DbDTO()
            {
                Nome = "Profissao",
                Campos = new string[] {
                    "Descricao"
                },
                Valores = new Object[] {
                    profissao.Descricao
                }
            };
            Conexao.ClienteSql.UPDATE(dto.Nome, dto.Campos, dto.Valores, "Codigo ='" + profissao.Codigo + "'");

        }
    }
}
