using Folha.Domain.Interfaces.Repository.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Folha.Domain.Models.Inventario;
using Folha.Domain.Models.Db;
using Folha.Driver.Repository;
using System.Data;
using Folha.Driver.Repository.Data;
using Folha.Domain.ViewModels.Inventario;
using Folha.Domain.ViewModels.Report;

namespace Folha.Driver.Repository.Inventario
{
    public class ArtigoStockRepository : RepositoryBase<DbDTO>, IArtigoStockRepository
    {
        public IEnumerable<RelListagemArtigosViewModel> StoquePorProdutos(int CodArmazem)
        {
            string SQL = "SELECT Produtos.Codigo as Codigo, Produtos.Descricao, ProdutoStock.Qtde As Quantidade, Categoria.Descricao as Familia";
            SQL += " FROM Produtos JOIN ProdutoStock on ProdutoStock.CodProduto=Produtos.Codigo join Categoria on Categoria.Codigo=Produtos.CodCategoria";
            SQL += " WHERE Produtos.Codigo=ProdutoStock.CodProduto And ProdutoStock.CodArmazem='" +CodArmazem + "' And Produtos.movimentaStock='1' and Produtos.status=1";
            SQL += " Order by Produtos.Descricao";

            object x = Conexao.ClienteSql.SELECT(SQL);
            DataTable DtDados = (DataTable)x;
            var result = Folha.Domain.Helpers.DataTableHelper.DataTableToList<RelListagemArtigosViewModel>(DtDados);
            return result;
        }
       
        public void Delete(ProdutoStockViewModel tabela)
        {
            Db.Delete(tabela);
        }

        public object Get(ProdutoStockViewModel tabela)
        {
            return Db.GetById<ProdutoStockViewModel>(tabela.codigo);
        }

        public object GetAll(ProdutoStockViewModel tabela)
        {
            return Db.GetEntities<ProdutoStockViewModel>();
        }

        public List<ProdutoStockViewModel> GetTodosPorCodArtigo(int codArtigo)
        {
            return Db.GetEntities<ProdutoStockViewModel>("WHERE ProdutoStock.CodProduto = '" + codArtigo + "'");
        }
        public object GetCodLast()
        {
            var obj = Conexao.ClienteSql.SELECT("Select  MAX(Codigo) As Codigo From Produtos");

            DataTable dtadados = (DataTable)obj;

            var result = Folha.Domain.Helpers.DataTableHelper.DataTableToList<Produtos>(dtadados).ToList();

            return result[0].Codigo;
        }

        public void Insert(ProdutoStockViewModel tabela)
        {
            Db.Add(tabela);
        }

        public void Update(ProdutoStockViewModel tabela)
        {
            Db.Update(tabela);
        }

        public IEnumerable<RelListagemArtigosViewModel> RupturaStock(string CodArmazem)
        {
            string SQL = "SELECT ProdutoStock.CodProduto as Codigo, Produtos.descricao as Descricao, ProdutoStock.stockMin, ProdutoStock.qtde as Quantidade FROM ProdutoStock INNER JOIN Produtos ON ProdutoStock.CodProduto = Produtos.Codigo";
            SQL += " WHERE (ProdutoStock.stockMin <> 0) AND (ProdutoStock.qtde <= ProdutoStock.stockMin)  AND (Produtos.status=1) ";
            if (!string.IsNullOrEmpty(CodArmazem))
                SQL += " AND(ProdutoStock.CodArmazem = '" + CodArmazem + "')";
            SQL += " order by Produtos.Descricao";

            object x = Conexao.ClienteSql.SELECT(SQL);
            DataTable DtDados = (DataTable)x;
            var result = Folha.Domain.Helpers.DataTableHelper.DataTableToList<RelListagemArtigosViewModel>(DtDados);
            return result;
        }

        public  IEnumerable<RelListagemArtigosViewModel> ApoioContagem (int CodArmazem)
        {
            
            string SQL = "SELECT Produtos.Codigo, Produtos.Descricao, Categoria.Descricao as Familia, ProdutoStock.Qtde As Quantidade";
            SQL += " FROM Produtos join ProdutoStock on Produtos.Codigo=ProdutoStock.CodProduto join Categoria on Categoria.codigo=Produtos.CodCategoria";
            SQL += " WHERE Produtos.movimentaStock='1' And ProdutoStock.CodArmazem='" + CodArmazem+ "' and Produtos.status=1";
            SQL += " Order by Produtos.Descricao";

            object x = Conexao.ClienteSql.SELECT(SQL);
            DataTable DtDados = (DataTable)x;
            var result = Folha.Domain.Helpers.DataTableHelper.DataTableToList<RelListagemArtigosViewModel>(DtDados);
            return result;
        }

    }
}
