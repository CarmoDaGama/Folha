using Folha.Domain.Models.Db;
using Folha.Domain.Interfaces.Repository.Financeiro;
using System;
using System.Collections.Generic;
using Folha.Domain.Models.Financeiro;
using System.Data;
using System.Linq;
using Folha.Domain.ViewModels.Financeiro;
using Folha.Driver.Repository.Data;

namespace Folha.Driver.Repository.Financeiro
{
    public class BancosRepository : RepositoryBase<DbDTO>, IBancosRepository
    {
        

        #region CRUD GENÉRICO
        public void Insert(BancosViewModel banco)
        {
            DbDTO dto = new DbDTO()
            {
                Nome = "Bancos",
                Campos = new string[] { "descricao" },
                Valores = new Object[] { banco.descricao }
            };
            Conexao.ClienteSql.INSERT(dto.Nome, dto.Campos, dto.Valores);
        }

        public object Get(BancosViewModel banco)
        {
            return Db.GetById<BancosViewModel>(banco.codigo);
        }

        public object GetAll(BancosViewModel entity)
        {
            return Db.GetEntities<BancosViewModel>();
        }
        IEnumerable<BancosViewModel> IBancosRepository.Listar(string criterios)
        {
            var result = new List<BancosViewModel>();
           
            string[] tabelas = { "Bancos" };
            string[] campos = { "Codigo", "Descricao" };
            string[] cri = { "Descricao Like '%" + criterios + "%'" };

            var ob = Conexao.ClienteSql.SELECT(tabelas, campos, cri);

           DataTable dtadados = (DataTable)ob;

            result = Folha.Domain.Helpers.DataTableHelper.DataTableToList<BancosViewModel>((DataTable)dtadados);

            return result;

        }

        public void Delete(BancosViewModel entity)
        {
            Conexao.ClienteSql.DELETE("Bancos", "codigo ='" + entity.codigo + "'");
        }

        public void UpdateBanco(BancosViewModel entity,string criterios)
        {
            DbDTO dto = new DbDTO()
            {
                Nome = "Bancos",
                Campos = new string[] { "descricao" },
                Valores = new Object[] { entity.descricao }
            };
            Conexao.ClienteSql.UPDATE(dto.Nome, dto.Campos, dto.Valores, "Codigo ='" + criterios + "'");
        }

        public void Update(BancosViewModel entity)
        {
            DbDTO dto = new DbDTO()
            {
                Nome = "Bancos",
                Campos = new string[] { "descricao" },
                Valores = new Object[] { entity.descricao }
            };
            Conexao.ClienteSql.UPDATE(dto.Nome, dto.Campos, dto.Valores, "Codigo ='" + entity.codigo + "'");
        }
        #endregion
    }

      
    }
