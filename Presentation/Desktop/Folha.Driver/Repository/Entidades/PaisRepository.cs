using Folha.Driver.Repository;
using Folha.Domain.Models.Db;
using Folha.Domain.Interfaces.Repository.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using Folha.Domain.Models.Genericos;
using Folha.Driver.Repository.Data;
using System.Data;

namespace Folha.Driver.Repository.Entidades
{
    public class PaisRepository : RepositoryBase<DbDTO>, IPaisRepository
    {
        public void Delete(Pais pais)
        {
            Conexao.ClienteSql.DELETE("Pais", "codigo ='" + pais.codigo + "'");
        }

        public object Get(Pais pais)
        {
            var obj = Conexao.ClienteSql.SELECT("SELECT * FROM Pais");

            DataTable dtadados = (DataTable)obj;

            var result = Folha.Domain.Helpers.DataTableHelper.DataTableToList<Pais>(dtadados).Where(p => p.codigo == pais.codigo).FirstOrDefault();

            return result;
        }

        public object GetAll(Pais pais)
        {
            var result = new List<Pais>();

            var obj = Conexao.ClienteSql.SELECT("SELECT * FROM Pais WHERE codigo < 5");

            DataTable dtadados = (DataTable)obj;

            result = Folha.Domain.Helpers.DataTableHelper.DataTableToList<Pais>(dtadados);

            return result;

        }

        public void Insert(Pais pais)
        {
            DbDTO dto = new DbDTO()
            {
                Nome = "Pais",
                Campos = new string[] {
                    "Descricao"
                },
                Valores = new Object[] {
                    pais.Descricao
                }
            };
            Conexao.ClienteSql.INSERT(dto.Nome, dto.Campos, dto.Valores);
        }

        public void Update(Pais pais)
        {
            DbDTO dto = new DbDTO()
            {
                Nome = "Pais",
                Campos = new string[] {
                    "Descricao"
                },
                Valores = new Object[] {
                    pais.Descricao
                }
            };
            Conexao.ClienteSql.UPDATE(dto.Nome, dto.Campos, dto.Valores, "codigo ='" + pais.codigo + "'");
        }
    }
}
