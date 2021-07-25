using Folha.Domain.Interfaces.Repository.Generico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Folha.Domain.Models.Genericos;
using Folha.Domain.Models.Db;
using Folha.Driver.Repository.Data;
using System.Data;
using Folha.Domain.ViewModels.Genericos;

namespace Folha.Driver.Repository.Genericos
{
    public class SubCategoriaRepository : ISubCategoriaRepository
    {
        public SubCategoriaViewModel GetById(int codSubCategoria)
        {
            return Listar(codSubCategoria.ToString()).FirstOrDefault();
        }

        public void Insert(SubCategoria Dados)
        {
            try
            {
                DbDTO dto = new DbDTO()
                {
                    Nome = "SubCategoria",
                    Campos = new string[] { "Descricao" ,"Categoria"},
                    Valores = new Object[] { Dados.Descricao,Dados.CodCategoria }
                };
                Conexao.ClienteSql.INSERT(dto.Nome, dto.Campos, dto.Valores);
            }
            catch (Exception) { throw new Exception("Erro ao Cadastrar Subcategoria"); }
        }

        public IEnumerable<SubCategoriaViewModel> Listar(string codigo)
        {
            var result = new List<SubCategoriaViewModel>();

            DataTable DtDados = new DataTable();
           
            try
            {
                string SQL = "SELECT SubCategoria.codigo as Codigo, SubCategoria.descricao as SubCategoria, Categoria.descricao as Categoria from SubCategoria, Categoria where SubCategoria.categoria = categoria.codigo";
           
                if (string.IsNullOrEmpty(codigo))
                { 
                    var ob = Conexao.ClienteSql.SELECT(SQL);
                    DtDados = (DataTable)ob;

                    result = Folha.Domain.Helpers.DataTableHelper.DataTableToList<SubCategoriaViewModel>((DataTable)ob);
                    return result;
                }
                else
                {
                    SQL += " And SubCategoria.codigo='" + codigo + "'";

                    var ob = Conexao.ClienteSql.SELECT(SQL);
                    DtDados = (DataTable)ob;

                    result = Folha.Domain.Helpers.DataTableHelper.DataTableToList<SubCategoriaViewModel>((DataTable)ob);
                    return result;
                }
            }
            catch (Exception)
            {
                throw new Exception("Erro a Carregar a Lista de SubCategoria\n");
            }
        }

        public void Update(SubCategoria Dados)
        {
            try
            {
                DbDTO dto = new DbDTO()
                {
                    Nome = "SubCategoria",
                    Campos = new string[] { "Descricao", "Categoria" },
                    Valores = new Object[] { Dados.Descricao, Dados.CodCategoria }
                };
                Conexao.ClienteSql.UPDATE(dto.Nome, dto.Campos, dto.Valores,"Codigo='"+Dados.codigo+"'");
            }
            catch (Exception) { throw new Exception("Erro ao Actualizar Subcategoria"); }
        }
    }
}
