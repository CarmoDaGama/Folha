using Folha.Driver.Repository;
using Folha.Domain.Models.Db;
using Folha.Domain.Interfaces.Repository.Entidades;
using Folha.Domain.ViewModels.Entidades;
using Folha.Driver.Repository.Data;
using System.Data;
using System;
using System.Collections.Generic;
using Folha.Domain.Helpers;

namespace Folha.Driver.Repository.Entidades
{
    public class ComissoesRepository : RepositoryBase<DbDTO>, IComissoesRepository
    {
        public bool VerificarSeExisteEntidadeNaComissao(int entidadeId, int documentoId)
        {
            DataTable tabelaComissoes = Conexao.BuscarTabela_com_Criterio("Comissoes", "CodEntidade='" + entidadeId + "' and codDocumento='" + documentoId + "'");

            return tabelaComissoes.Rows.Count > 0;
        }
        public List<ComissaoViewModel> CarregaComissoes(int documentoId)
        {
            DataTable tabelaComissoes = new DataTable();
            var listRetorno = new List<ComissaoViewModel>();
            string SQL = "Select Comissoes.Codigo as Codigo, Entidades.Codigo as CodEntidade, Entidades.Nome as Nome From Comissoes ";
            SQL = SQL + " join Entidades on Comissoes.CodEntidade = Entidades.Codigo where Comissoes.CodDocumento='" + documentoId + "'";

            Object ob = Conexao.ClienteSql.SELECT(SQL);

            try
            {
                tabelaComissoes = (DataTable)ob;
                listRetorno = DataTableHelper.DataTableToList<ComissaoViewModel>(tabelaComissoes);
                return listRetorno;
            }
            catch (Exception ER)
            {
               throw new Exception("Erro a Carregar Comissões \n" + ER.Message);
            }
        }

        #region CRUD GENERICO
        public void Delete(ComissoesViewModel comissao)
        {
            Db.Delete(comissao);
        }

        public object Get(ComissoesViewModel comissao)
        {
            return Db.GetById<ComissoesViewModel>(comissao.codigo);
        }

        public object GetAll(ComissoesViewModel comissao)
        {
            return Db.GetEntities<ComissoesViewModel>();
        }
       
        public void Insert(ComissoesViewModel comissao)
        {
            Db.Add(comissao);
        }

        public void Update(ComissoesViewModel comissao)
        {
            Db.Update(comissao);
        }
        #endregion
    }
}
