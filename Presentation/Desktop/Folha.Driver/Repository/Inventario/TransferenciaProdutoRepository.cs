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
    public class TransferenciaProdutoRepository : RepositoryBase<DbDTO>, ITransferenciaProdutoRepository
    {
        public void Delete(TransferenciaProduto trans)
        {
            DbDTO dto = new DbDTO()
            {
                Nome = "TransferenciaProduto"
            };
            Conexao.ClienteSql.DELETE(dto.Nome, "Codigo ='" + trans.codigo + "'");
        }
        public TransferenciaProdutoViewModel Gravar(TransferenciaProdutoViewModel transferencia)
        {
            string tabela = "TransferenciaProduto";
            string[] campos = { "CodDocumento", "CodProduto", "Qtidade", "Origem", "Destino", "CodOrigem", "CodDestino" };
            Object[] valores = { transferencia.CodDocumento, transferencia.CodProduto, transferencia.Quantidade, transferencia.Origem, transferencia.Destino, transferencia.CodOrigem, transferencia.CodDestino };
            string[] critX = { "Codigo = '" + transferencia.Codigo + "'" };
            
            Conexao.ClienteSql.INSERT(tabela, campos, valores);
           
            return transferencia;
        }
        public TransferenciaProduto LerTransferencia(TransferenciaProduto Transferencia)
        {
            string[] campos = { "TransferenciaProduto.CodProduto", "Produtos.Descricao", "TransferenciaProduto.Qtidade", "TransferenciaProduto.Origem", "TransferenciaProduto.Destino", "TransferenciaProduto.CodOrigem", "TransferenciaProduto.CodDestino" };
            string tabelas = "TransferenciaProduto";
            string[] CriteriosTodos = { "Produtos on Produtos.Codigo=TransferenciaProduto.CodProduto" };
            string[] criterios = { "TransferenciaProduto.CodDocumento='" + Transferencia + "'" };
            var ob = Conexao.ClienteSql.INNERJOIN(tabelas, campos, CriteriosTodos, criterios);
            return Transferencia;
        }
        public IEnumerable<TransferenciaProdutoViewModel> Listar(string criterios)
        {
            DataTable DtDados = new DataTable();
            try
            {
                string SQL = "SELECT TransferenciaProduto.Codigo as Codigo, " +
                            "TransferenciaProduto.CodProduto as CodProduto, " +
                            "TransferenciaProduto.CodOrigem, " +
                            "TransferenciaProduto.CodDestino, " +
                            "TransferenciaProduto.CodDocumento," +
                            "Produtos.descricao as Descricao," +
                            "TransferenciaProduto.Qtidade as Quantidade," +
                            "TransferenciaProduto.Origem as Origem," +
                            "TransferenciaProduto.Destino as Destino," +
                            "Produtos.preco1 as Preco," +
                            "Produtos.custo as Custo" +
                    " From TransferenciaProduto Left Outer Join Produtos on TransferenciaProduto.CodProduto = Produtos.Codigo";
                if (string.IsNullOrEmpty(criterios))
                {
                    var ob = Conexao.ClienteSql.SELECT(SQL);
                    DtDados = (DataTable)ob;
                    var result = DataTableHelper.DataTableToList<TransferenciaProdutoViewModel>(DtDados);
                    return result;
                }
                else
                {
                    SQL += " Where TransferenciaProduto.CodDocumento='" + criterios + "'";
                    var ob = Conexao.ClienteSql.SELECT(SQL);
                    DtDados = (DataTable)ob;
                    var result = DataTableHelper.DataTableToList<TransferenciaProdutoViewModel>(DtDados);
                    return result;
                }
            }
            catch (Exception) { throw new Exception("Erro ao Listar Transferncia"); }

           
        }

        public int GetCodigoStock(int CodArmazem, int CodProduto)
        {
            var ob = Conexao.ClienteSql.SELECT("SELECT * From ProdutoStock Where CodArmazem = '" + CodArmazem + "' And CodProduto = '" + CodProduto +"'");
            DataTable DtDados = (DataTable)ob;
            if (DtDados.Rows.Count == 0)
            {
                return 0;
            }
            return Convert.ToInt32(DtDados.Rows[0][0]);

        }
        #region Metodos padrão
        public void Insert(TransferenciaProdutoViewModel tabela)
        {
            Db.Add(tabela);
        }
        public void Insert(TransferenciaProduto tabela)
        {
            throw new NotImplementedException();
        }
        public void Update(TransferenciaProduto tabela)
        {
            throw new NotImplementedException();
        }
        public object Get(TransferenciaProduto tabela)
        {
            throw new NotImplementedException();
        }
        public object GetAll(TransferenciaProduto tabela)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Alterar Stock

        public AlterarStockViewModel DiminuirStock(AlterarStockViewModel diminuir)
        {
                string SQL = "SELECT ProdutoStock.qtde FROM Produtos INNER JOIN ProdutoStock ON Produtos.Codigo = ProdutoStock.CodProduto WHERE Produtos.Codigo = '" + diminuir.codigoProduto + "' AND ProdutoStock.CodArmazem = '" + diminuir.armaz + "' OR ProdutoStock.CodArmazem = '" + diminuir.armaz + "' AND Produtos.Barra LIKE '" + diminuir.codigoProduto + "'";
                Object obj = Conexao.ClienteSql.SELECT(SQL);
                DataTable dt = (DataTable)obj;
                decimal stAntigo = decimal.Parse(dt.Rows[0][0].ToString());
                decimal Total = stAntigo - diminuir.Qtdade;
                string[] camposs = { "qtde" };
                string[] criterioss = { "CodArmazem = " + diminuir.armaz, "CodProduto = '" + diminuir.codigoProduto + "'" };
                Object[] valoress = { Total };
                Conexao.ClienteSql.UPDATE("ProdutoStock", camposs, valoress, criterioss);
                return diminuir;
        }

        public bool ExisteNoArmazem(AlterarStockViewModel existe)
        {
             bool Resultado = false;
             DataTable DtDados = new DataTable();

                string[] campos = { "Codigo" };
                string[] tabelasTodos = { "ProdutoStock" };
                string[] criterioTodos = { "CodProduto='" + existe.codigoProduto + "'", "CodArmazem='" + existe.CodDestino + "'" };

                Object obj = Conexao.ClienteSql.SELECT(tabelasTodos, campos, criterioTodos);
                DtDados = (DataTable)obj;
                if (DtDados.Rows.Count > 0) Resultado = true;
              return Resultado;
        }

        public AlterarStockViewModel AumentaStock(AlterarStockViewModel aumentar)
        {
            string[] criterios = { "CodArmazem = " + aumentar.CodDestino, "CodProduto = '" + aumentar.codigoProduto + "'" };
            string[] campos = { "qtde" };
            string[] tabelas = { "ProdutoStock" };

            Object obj = Conexao.ClienteSql.SELECT(tabelas, campos, criterios);
            DataTable dt = (DataTable)obj;

            decimal stAntigo = decimal.Parse(dt.Rows[0][0].ToString());
            decimal Total = stAntigo + aumentar.Qtdade;


            string[] camposs = { "qtde" };
            string[] criterioss = { "CodArmazem = " + aumentar.CodDestino, "CodProduto = '" + aumentar.codigoProduto + "'" };
            Object[] valoress = { Total };
            Conexao.ClienteSql.UPDATE("ProdutoStock", camposs, valoress, criterioss);

            return aumentar;
        }

        public AlterarStockViewModel InserirQtdadeArmazem(AlterarStockViewModel inserir)
        {
            
                string[] Campos = { "CodProduto", "CodArmazem", "qtde", "stockMin", "stockMax" };
                Object[] Valores = { inserir.codigoProduto, inserir.CodDestino, inserir.Qtdade, 0, 0 };
                Conexao.ClienteSql.INSERT("ProdutoStock", Campos, Valores);
                return inserir;

          
        }
        #endregion

    }
}
