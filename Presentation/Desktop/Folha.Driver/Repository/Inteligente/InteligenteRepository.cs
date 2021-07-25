using Folha.Driver.Repository;
using Folha.Domain.Models.Db;
using Folha.Domain.Interfaces.Repository.Inteligente;
using System.Collections.Generic;
using System.Linq;
using Folha.Domain.ViewModels.Principal;
using Folha.Driver.Repository.Data;
using System.Data;
using Folha.Domain.Helpers;
using Folha.Domain.ViewModels.Documentos;

namespace Folha.Driver.Repository.Inteligente
{
    public class InteligenteRepository : RepositoryBase<DbDTO>, IInteligenteRepository
    {
        public void Delete(InteligenteViewModel inteligente)
        {
            Conexao.ClienteSql.DELETE(inteligente.NomeTabela, " Codigo = '" + inteligente.Codigo + "'");
        }

        public object Get(InteligenteViewModel inteligente)
        {
            DataTable tabelaInteligente = (DataTable)Conexao.ClienteSql.SELECT("SELECT Codigo, Descricao FROM " + inteligente.NomeTabela + " WHERE Codigo = '" + inteligente.Codigo + "' Order by Codigo");
            List<InteligenteViewModel> list = new List<InteligenteViewModel>();
            list = DataTableHelper.DataTableToList<InteligenteViewModel>(tabelaInteligente);
            return list.FirstOrDefault();
        }

        public object GetAll(InteligenteViewModel inteligente)
        {
            DataTable tabelaInteligente = (DataTable)Conexao.ClienteSql.SELECT("SELECT Codigo, Descricao FROM " + inteligente.NomeTabela + " Order by Codigo");
            List <InteligenteViewModel> list = new List<InteligenteViewModel>();
            list = DataTableHelper.DataTableToList<InteligenteViewModel>(tabelaInteligente);
            return list;
        }

        public void Insert(InteligenteViewModel inteligente)
        {
            Conexao.ClienteSql.INSERT(inteligente.NomeTabela, new string[] { "Descricao" }, new object[] { inteligente.Descricao});
        }

        public void Update(InteligenteViewModel inteligente)
        {
            Conexao.ClienteSql.UPDATE(inteligente.NomeTabela, new string[] { "Descricao" }, new object[] { inteligente.Descricao }, " Codigo = '" + inteligente.Codigo + "'");
        }

        #region DocumentosPagamento
        public void InsertDoc(DocumentoPagamentoViewModel doc)
        {
            Db.Add(doc);
        }

        public void UpdateDoc(DocumentoPagamentoViewModel doc)
        {
            Db.Update(doc);
        }

        public void DeleteDoc(DocumentoPagamentoViewModel doc)
        {
            Db.Update(doc);
        }
        public List<DocumentoPagamentoViewModel> GetTodosDocs()
        {
            return Db.GetEntities<DocumentoPagamentoViewModel>();
        }

        public List<DocumentoPagamentoViewModel> GetTodosDocsPorRecibo(int codCRecibo)
        {
            return Db.GetEntities<DocumentoPagamentoViewModel>(" WHERE CodRecibo ='" + codCRecibo + "'");
        }
        #endregion
    }
}
