using Folha.Domain.Models.Db;
using Folha.Domain.Interfaces.Repository.Entidades;
using Folha.Domain.Models.Entidades;
using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using Folha.Domain.ViewModels.Entidades;
using Folha.Driver.Repository.Data;

namespace Folha.Driver.Repository.Entidades
{
    public class TipoDocumentoEntidadeRepository : RepositoryBase<DbDTO>, ITipoDocumentoEntidadeRepository
    {
        public void Delete(TiposDocumentosViewModel tipo)
        {
            Conexao.ClienteSql.DELETE("TiposDocumentos", "codigo ='" + tipo.codigo + "'");
        }

        public object Get(TiposDocumentosViewModel tipo)
        {
            var obj = Conexao.ClienteSql.SELECT("SELECT * FROM TiposDocumentos");

            DataTable dtadados = (DataTable)obj;

            var result = Folha.Domain.Helpers.DataTableHelper.DataTableToList<TipoDocumentoEntidade>(dtadados).Where(p => p.codigo == tipo.codigo).FirstOrDefault();

            return result;
        }

        public object GetAll(TiposDocumentosViewModel tipo)
        {
            var result = new List<TiposDocumentosViewModel>();

            var obj = Conexao.ClienteSql.SELECT("SELECT * FROM TiposDocumentos");

            DataTable dtadados = (DataTable)obj;

            result = Folha.Domain.Helpers.DataTableHelper.DataTableToList<TiposDocumentosViewModel>(dtadados);

            return result;
        }

        public void Insert(TiposDocumentosViewModel tipo)
        {
            DbDTO dto = new DbDTO()
            {
                Nome = "TiposDocumentos",
                Campos = new string[] {
                    "descricao"
                },
                Valores = new Object[] {
                    tipo.descricao
                }
            };
            Conexao.ClienteSql.INSERT(dto.Nome, dto.Campos, dto.Valores);

        }

        public void Update(TiposDocumentosViewModel tipo)
        {
            DbDTO dto = new DbDTO()
            {
                Nome = "TiposDocumentos",
                Campos = new string[] {
                    "descricao"
                },
                Valores = new Object[] {
                    tipo.descricao
                }
            };
            Conexao.ClienteSql.UPDATE(dto.Nome, dto.Campos, dto.Valores, "codigo ='" + tipo.codigo + "'");

        }
    }
}
