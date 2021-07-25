using Folha.Driver.Repository;
using Folha.Domain.Models.Db;
using Folha.Domain.Interfaces.Repository.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Folha.Domain.Models.Inventario;
using Folha.Driver.Repository.Data;
using System.Data;
using Folha.Domain.ViewModels.Inventario;

namespace Folha.Driver.Repository.Inventario
{
  public  class ImpostoRepository : RepositoryBase<DbDTO>, IImpostoRepository
    {
        public void Delete(Imposto entity)
        {
            DbDTO dto = new DbDTO()
            {
                Nome = "Imposto"
            };
            Conexao.ClienteSql.DELETE(dto.Nome, "Codigo ='" + entity.Codigo + "'");
        }

        public void Insert(Imposto imposto)
        {
            DbDTO dto = new DbDTO()
            {
                Nome = "Imposto",
                Campos = new string[] { "Descricao", "Percentagem" },
                Valores = new Object[] { imposto.Descricao, imposto.Percentagem }
            };
            Conexao.ClienteSql.INSERT(dto.Nome, dto.Campos, dto.Valores);

        }
        public bool VerificarDup(string nomeTabela, Dictionary<string, object> dicionario)
        {
            return VerificarDuplicacaoDoRegistro(nomeTabela, dicionario);
        }
        public IEnumerable<Imposto> Listar(string criterios)
        {
            var result = new List<Imposto>();

            string[] tabelas = { "Imposto" };
            string[] campos = { "Codigo", "Descricao", "Percentagem" };
            string[] cri = { "Descricao Like '" + criterios + "%'" }; ;

            var ob = Conexao.ClienteSql.SELECT(tabelas, campos, cri);

            DataTable dtadados = (DataTable)ob;

            result = Folha.Domain.Helpers.DataTableHelper.DataTableToList<Imposto>((DataTable)dtadados);

            return result;
        }

        public void Update(Imposto entity)
        {
            DbDTO dto = new DbDTO()
            {
                Nome = "Imposto",
                Campos = new string[] { "Descricao", "Percentagem" },
                Valores = new Object[] { entity.Descricao, entity.Percentagem }
            };
            Conexao.ClienteSql.UPDATE(dto.Nome, dto.Campos, dto.Valores, "Codigo ='" + entity.Codigo + "'");
        }

        public void Delete(ImpostoViewModel tabela)
        {
            Db.Delete(tabela);
        }

        public object Get(ImpostoViewModel tabela)
        {
            return Db.GetById<ImpostoViewModel>(tabela.Codigo);
        }

        public object GetAll(ImpostoViewModel tabela)
        {
            return Db.GetEntities<ImpostoViewModel>();
        }

        public void Insert(ImpostoViewModel tabela)
        {
            Db.Add(tabela);
        }

        public void Update(ImpostoViewModel tabela)
        {
            Db.Update(tabela);
        }
    }
}
