using Folha.Driver.Repository;
using Folha.Domain.Models.Db;
using Folha.Domain.Interfaces.Repository.Hospitalar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Folha.Domain.Models.Hospitalar;
using Folha.Driver.Repository.Data;
using System.Data;
using Folha.Domain.Models.Financeiro;

namespace Folha.Driver.Repository.Hospitalar
{
    public class EspecialidadesRepository : RepositoryBase<DbDTO>, IEspecialidadesRepository
    {
        public void Delete(Especialidades tabela)
        {
            try
            {
                Conexao.ClienteSql.DELETE("Especialidades", "Codigo ='" + tabela.Codigo+ "'");
            }
            catch (Exception) { throw new Exception("Erro ao Deletar Especialidade"); } 
            
        }

        public object Get(Especialidades tabela)
        {
            throw new NotImplementedException();
        }

        public object GetAll(Especialidades tabela)
        {
            throw new NotImplementedException();
        }

        public void Insert(Especialidades tabela)
        {
            try
            {
                DbDTO dto = new DbDTO()
                {
                    Nome = "Especialidades",
                    Campos = new string[] { "Descricao" },
                    Valores = new Object[] { tabela.Descricao }
                };
                Conexao.ClienteSql.INSERT(dto.Nome, dto.Campos, dto.Valores);
            }
            catch (Exception) { throw new Exception("Erro ao Especialidade"); }
        }

        public IEnumerable<Especialidades> Listar(string criterios)
        {
            var result = new List<Especialidades>();

            DataTable dtEspecialidade = new DataTable();
            string[] tabelas = { "Especialidades" };
            string[] campos = { "Codigo", "Descricao" };
            string[] cri = { "Descricao Like '" + criterios + "%'" };

            Object ob = Conexao.ClienteSql.SELECT(tabelas, campos, cri);
            try
            {
                result = Folha.Domain.Helpers.DataTableHelper.DataTableToList<Especialidades>((DataTable)ob);
                return result;
            }
            catch (Exception)
            {
                throw new Exception("Erro a Carregar a Lista de Especialidades\n");
            }
        }

        public void Update(Especialidades tabela)
        {
            try
            {
                DbDTO dto = new DbDTO()
                {
                    Nome = "Especialidades",
                    Campos = new string[] { "Descricao" },
                    Valores = new Object[] { tabela.Descricao }
                };
                Conexao.ClienteSql.UPDATE(dto.Nome, dto.Campos, dto.Valores, "Codigo ='" + tabela.Codigo + "'");

            }
            catch (Exception) { throw new Exception("Erro ao Actualizar Especialidade"); }
        }

       
    }
}
