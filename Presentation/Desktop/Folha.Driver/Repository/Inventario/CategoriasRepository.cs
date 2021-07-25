using System;
using System.Data;
using System.Collections.Generic;
using Folha.Domain.Interfaces.Repository.Inventario;
using Folha.Driver.Repository;
using Folha.Domain.Models.Db;
using Folha.Domain.Models.Inventario;
using Folha.Domain.ViewModels.Inventario;
using Folha.Driver.Repository.Data;

namespace Folha.Driver.Repository.Inventario
{
    public class CategoriasRepository  : RepositoryBase<DbDTO>, ICategoriasRepository
    {
        #region CRUD 
        public void Delete(Categoria entity)
        {
            DbDTO dto = new DbDTO()
            {
                Nome = "Categoria",             
            };

            Conexao.ClienteSql.DELETE(dto.Nome, "codigo ='" + entity.codigo + "'");
        }
        public void Update(Categoria entity)
        {
            DbDTO dto = new DbDTO()
            {
                Nome = "Categoria",
                Campos = new string[] { "descricao", "Vender", "Foto" },
                Valores = new Object[] { entity.descricao, entity.Vender, entity.Foto }
            };
            Conexao.ClienteSql.UPDATE(dto.Nome, dto.Campos, dto.Valores, "Codigo ='" + entity.codigo + "'");
        }
        public IEnumerable<Categoria> Listar(string criterios)
        {

            var result = new List<Categoria>();

            string[] tabelas = { "Categoria" };
            string[] campos = { "Codigo", "Descricao", "Vender", "Foto" };
            string[] cri = { "Descricao Like '" + criterios + "%'" }; ;

            var ob = Conexao.ClienteSql.SELECT(tabelas, campos, cri);

            DataTable dtadados = (DataTable)ob;

            result = Folha.Domain.Helpers.DataTableHelper.DataTableToList<Categoria>((DataTable)dtadados);

            return result;

        }
        public IEnumerable<Categoria> ListarPopular(int Codigo)
        {

            var result = new List<Categoria>();

            string[] tabelas = { "Categoria" };
            string[] campos = { "Codigo", "Descricao", "Vender", "Foto" };
            string[] cri = { "codigo = '" + Codigo + "'" }; ;

            var ob = Conexao.ClienteSql.SELECT(tabelas, campos, cri);

            DataTable dtadados = (DataTable)ob;

            result = Folha.Domain.Helpers.DataTableHelper.DataTableToList<Categoria>((DataTable)dtadados);

            return result;

        }
        public void Insert(Categoria categoria)
        {
            DbDTO dto = new DbDTO()
            {
                Nome = "Categoria",
                Campos = new string[] { "descricao", "Vender" , "Foto" },
                Valores = new Object[] { categoria.descricao, categoria.Vender, categoria.Foto }
            };
            Conexao.ClienteSql.INSERT(dto.Nome, dto.Campos, dto.Valores);

        }

        public void Delete(CategoriaViewModel tabela)
        {
            throw new NotImplementedException();
        }

        public object Get(CategoriaViewModel tabela)
        {
            throw new NotImplementedException();
        }

        public object GetAll(CategoriaViewModel tabela)
        {
            return Db.GetEntities<CategoriaViewModel>();
        }

        public void Insert(CategoriaViewModel tabela)
        {
            throw new NotImplementedException();
        }

        public void Update(CategoriaViewModel tabela)
        {
            throw new NotImplementedException();
        }

        public bool VerificarDup(string nomeTabela, Dictionary<string, object> dicionario)
        {
            return VerificarDuplicacaoDoRegistro(nomeTabela, dicionario);
        }
        #endregion
    }
}
