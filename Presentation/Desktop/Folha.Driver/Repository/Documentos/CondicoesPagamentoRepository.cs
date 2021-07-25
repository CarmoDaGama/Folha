using Folha.Driver.Repository.Data;
using Folha.Driver.Repository;
using Folha.Domain.Models.Documentos;
using Folha.Domain.ViewModels.Documentos;
using Folha.Domain.Models.Db;
using Folha.Domain.Interfaces.Repository.Documentos;
using System;
using System.Collections.Generic;
using System.Data;

namespace Folha.Driver.Repository.Documentos
{
    public class CondicoesPagamentoRepository : RepositoryBase<DbDTO>, ICondicoesPagamentoRepository
    {
        public void Delete(CondicoesPagamento entity)
        {
            DbDTO dto = new DbDTO()
            {
                Nome = "CondicoesPagamentos",
            };

            Conexao.ClienteSql.DELETE(dto.Nome, "Codigo ='" + entity.Codigo + "'");
        }

        public void Delete(CondicoesPagamentoViewModel tabela)
        {
            throw new NotImplementedException();
        }

        public object Get(CondicoesPagamentoViewModel tabela)
        {
            throw new NotImplementedException();
        }

        public object GetAll(CondicoesPagamentoViewModel tabela)
        {
            throw new NotImplementedException();
        }

        public void Insert(CondicoesPagamento entity)
        {
            DbDTO dto = new DbDTO()
            {
                Nome = "CondicoesPagamentos",
                Campos = new string[] { "Descricao", "Dias" },
                Valores = new Object[] { entity.Descricao, entity.Dias }
            };
            Conexao.ClienteSql.INSERT(dto.Nome, dto.Campos, dto.Valores);

        }

        public void Insert(CondicoesPagamentoViewModel tabela)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CondicoesPagamento> Listar(string criterios)
        {
            var result = new List<CondicoesPagamento>();

            string[] tabelas = { "CondicoesPagamentos" };
            string[] campos = { "Codigo", "Descricao", "Dias" };
            string[] cri = { "Descricao Like '" + criterios + "%'" }; ;

            var ob = Conexao.ClienteSql.SELECT(tabelas, campos, cri);

            DataTable dtadados = (DataTable)ob;

            result = Folha.Domain.Helpers.DataTableHelper.DataTableToList<CondicoesPagamento>((DataTable)dtadados);

            return result;
        }

        public void Update(CondicoesPagamento entity)
        {
            DbDTO dto = new DbDTO()
            {
                Nome = "CondicoesPagamentos",
                Campos = new string[] { "Descricao", "Dias" },
                Valores = new Object[] { entity.Descricao, entity.Dias }
            };
            Conexao.ClienteSql.UPDATE(dto.Nome, dto.Campos, dto.Valores, "Codigo ='" + entity.Codigo + "'");
        }

        public void Update(CondicoesPagamentoViewModel tabela)
        {
            throw new NotImplementedException();
        }

        public bool VerificarDup(string nomeTabela, Dictionary<string, object> dicionario)
        {
            return VerificarDuplicacaoDoRegistro(nomeTabela, dicionario);
        }
    }
}
