using Folha.Domain.Models.Db;
using Folha.Domain.Interfaces.Repository.Financeiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Folha.Domain.Models.Financeiro;
using System.Data;
using Folha.Driver.Repository.Data;
using Folha.Domain.ViewModels.Financeiro;

namespace Folha.Driver.Repository.Financeiro
{
    public class TipoSaidaRepository : RepositoryBase<DbDTO>, ITipoSaidaRepository
    {
        public void Delete(TipoSaida tabela)
        {
            Conexao.ClienteSql.DELETE("TipoSaida", "codigo ='" + tabela.Codigo + "'");
        }

        public object Get(TipoSaida tabela)
        {
            throw new NotImplementedException();
        }

        public object GetAll(TipoSaida tabela)
        {
            throw new NotImplementedException();
        }

        public void Insert(TipoSaida tabela)
        {
            DbDTO dto = new DbDTO()
            {
                Nome = "TipoSaida",
                Campos = new string[] { "Descricao"},
                Valores = new Object[] { tabela.Descricao }
            };
            Conexao.ClienteSql.INSERT(dto.Nome, dto.Campos, dto.Valores);
        }

       IEnumerable<TipoSaidaViewModel> ITipoSaidaRepository.Listar(string criterios)
        {
            var result = new List<TipoSaidaViewModel>();

            DataTable dtTipoSaida = new DataTable();
            string[] tabelas = { "TipoSaida" };
            string[] campos = {"codigo", "Descricao" };
            string[] cri = { "Descricao Like '" + criterios + "%'" };

            Object ob = Conexao.ClienteSql.SELECT(tabelas, campos, cri);
            try
            {
                result = Folha.Domain.Helpers.DataTableHelper.DataTableToList<TipoSaidaViewModel>((DataTable)ob);
                return result;
            }
            catch (Exception)
            {
                throw new Exception("Erro a Carregar a Lista de Formas de Saídas de Valores\n");
            }
           
        }

        public void Update(TipoSaida tabela)
        {

            DbDTO dto = new DbDTO()
            {
                Nome = "TipoSaida",
                Campos = new string[] { "Descricao" },
                Valores = new Object[] { tabela.Descricao }
            };
            Conexao.ClienteSql.UPDATE(dto.Nome, dto.Campos, dto.Valores, "codigo ='" + tabela.Codigo + "'");
        }

        public IEnumerable<TipoSaida> BuscarPorCod(string Codigo)
        {
            var result = new List<TipoSaida>();

            DataTable dtTipoSaida = new DataTable();
           
            Object ob = Conexao.BuscarCodigoPorDescricao("TipoSaida",Codigo);
            try
            {
                result = Folha.Domain.Helpers.DataTableHelper.DataTableToList<TipoSaida>((DataTable)ob);
            }
            catch (Exception)
            {
                throw new Exception("Erro a Carregar a Lista de Formas de Saídas de Valores\n");
            }


            return result;
        }
    }
}
