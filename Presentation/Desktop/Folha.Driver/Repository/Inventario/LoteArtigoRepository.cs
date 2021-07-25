using Folha.Driver.Repository.Data;
using Folha.Driver.Repository;
using Folha.Domain.Models.Inventario;
using Folha.Domain.ViewModels.Inventario;
using Folha.Domain.Models.Db;
using Folha.Domain.Helpers;
using Folha.Domain.Interfaces.Repository.Inventario;
using System;
using System.Collections.Generic;
using System.Data;

namespace Folha.Driver.Repository.Inventario
{
    public class LoteArtigoRepository : RepositoryBase<DbDTO>, ILoteArtigoRepository
    {
        public void Delete(LoteViewModel tabela)
        {
            Db.Delete(tabela);
        }

        public void DeleteLoteArtigo(LoteArtigosViewModel delete)
        {
            DbDTO dto = new DbDTO()
            {
                Nome = "LoteArtigos"
            };
            Conexao.ClienteSql.DELETE(dto.Nome, "Codigo ='" + delete.Codigo + "'");
        }

        public object Get(LoteViewModel tabela)
        {
            return Db.GetById<LoteViewModel>(tabela.Codigo);
        }

        public List<LoteViewModel> GetAll()
        {
            return Db.GetEntities<LoteViewModel>();
        }

        public object GetAll(LoteViewModel tabela)
        {
            return Db.GetEntities<LoteViewModel>();
        }

        public List<LoteArtigosViewModel> GetLoteArtigo(int CodLote)
        {
            string SQL = "SELECT LoteArtigos.Codigo, LoteArtigos.CodProduto, Produtos.Descricao,  LoteArtigos.CodLote from LoteArtigos ";
            SQL += " Left Outer Join Produtos on Produtos.Codigo= LoteArtigos.CodProduto ";
            SQL += " WHERE LoteArtigos.CodLote='" + CodLote + "'";
            Object obj = Conexao.ClienteSql.SELECT(SQL);
            DataTable dtadados = (DataTable)obj;
            var result = Folha.Domain.Helpers.DataTableHelper.DataTableToList<LoteArtigosViewModel>(dtadados);
            return result;
        }

        public Lote Gravar(Lote lote)
        {
            string tabela = "Lote";
            string[] campos = { "Descricao", "DataValidade", "DataVencimento" };
            Object[] valores = { lote.Descricao, lote.DataValidade, lote.DataVencimento };
            string[] critX = { "Codigo = '" + lote.Codigo + "'" };

            if (lote.Codigo == 0)
            {
                Conexao.ClienteSql.INSERT(tabela, campos, valores);
            }
            else
            {
                Conexao.ClienteSql.UPDATE(tabela, campos, valores, critX);
            }
            string sql = "Select Codigo from Lote where Descricao like '" + lote.Descricao + "'";
            object ob = Conexao.ClienteSql.SELECT(sql);
            DataTable dt = (DataTable)ob;
            lote.Codigo = int.Parse(dt.Rows[0][0].ToString());

            GravaTudo(lote);
            return lote;
        }
        private void GravaTudo(Lote lote)
        {
            if (lote.LoteArtigos != null)
            {
                foreach (var item in lote.LoteArtigos) item.CodLote = lote.Codigo;
                gravarLoteArtigo(lote.LoteArtigos);
            }
        }
        private void gravarLoteArtigo(List<LoteArtigosViewModel> lista)
        {
            for (int i = 0; i < lista.Count; i++)
            {
                string Codigo = lista[i].Codigo.ToString();
                string codLote = lista[i].CodLote.ToString();
                string CodProduto = lista[i].CodProduto.ToString();

                string[] campos = { "codLote", "CodProduto" };
                object[] Valores = { codLote, CodProduto };
                string[] Criterio = { "Codigo = '" + Codigo + "'" };

                if (int.Parse(Codigo) == 0)
                {
                    Conexao.ClienteSql.INSERT("LoteArtigos", campos, Valores);
                }
                else
                {
                    Conexao.ClienteSql.UPDATE("LoteArtigos", campos, Valores, Criterio);
                }
            }
        }
        public void Insert(LoteViewModel tabela)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Lote> Listar(string criterios)
        {
            DataTable DtDados = new DataTable();
            try
            {
                string SQL = "SELECT *FROM Lote";

                var ob = Conexao.ClienteSql.SELECT(SQL);
                DtDados = (DataTable)ob;
                var result = DataTableHelper.DataTableToList<Lote>(DtDados);
                return result;

            }
            catch (Exception) { throw new Exception("Erro ao Listar"); }
        }

        public void Update(LoteViewModel tabela)
        {
            throw new NotImplementedException();
        }

        public bool VerificarDup(string nomeTabela, Dictionary<string, object> dicionario)
        {
            return VerificarDuplicacaoDoRegistro(nomeTabela, dicionario);
        }
    }
}
