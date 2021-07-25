using Folha.Driver.Repository;
using Folha.Domain.Interfaces.Repository.Inventario;
using Folha.Domain.Models.Inventario;
using Folha.Domain.ViewModels.Inventario;
using Folha.Domain.ViewModels.Report;
using Folha.Domain.Models.Db;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Folha.Driver.Repository.Data.Repositories.Inventario
{
    public class ArtigosRepository : RepositoryBase<DbDTO>, IArtigosRepository
    {
        public void Delete(ProdutosViewModel tabela)
        {
            Db.Delete(tabela);
        }

        public object Get(ProdutosViewModel tabela)
        {
            return Db.GetById<ProdutosViewModel>(tabela.Codigo);
        }

        public object GetAll(ProdutosViewModel tabela)
        {
            return Db.GetEntities<ProdutosViewModel>();
        }

        public void Insert(Produtos tabela)
        {
            Db.Add(tabela);
        }
        public void Update(Produtos tabela)
        {
            Db.Update(tabela);
        }
        public Artigo Gravar(Artigo artigo)
        {
            string tabela = "Produtos";
            string[] campos = { "Descricao", "CodCategoria", "preco1", "preco2", "preco3", "custo", "movimentaStock", "vender", "Data_Fabrico", "Data_Validade", "Imagem", "Barra", "status", "CodImposto", "MotivoIsencao", "Retencao" };
            Object[] valores = { artigo.Descricao, artigo.Codcategoria, artigo.Preco1, artigo.Preco2, artigo.Preco3, artigo.Custo, artigo.movimentaStock, artigo.Vender, "", "", artigo.Imagem, artigo.Barra, "1", artigo.CodImposto, artigo.MotivoIsencao, artigo.Retencao };
            string[] critX = { "codigo = '" + artigo.Codigo + "'" };

            if (artigo.Codigo == 0)
            {
                Conexao.ClienteSql.INSERT(tabela, campos, valores);
            }
            else
            {
                Conexao.ClienteSql.UPDATE(tabela, campos, valores, critX);
            }
            string sql = "Select Codigo from Produtos where Descricao like '" + artigo.Descricao + "'";
            object ob = Conexao.ClienteSql.SELECT(sql);
            DataTable dt = (DataTable)ob;
            artigo.Codigo = int.Parse(dt.Rows[0][0].ToString());
            GravaTudo(artigo);
            return artigo;
        }
        public Artigo Eliminar(Artigo artigo)
        {
            string tabela = "Produtos";
            string[] campos = { "status" };
            Object[] valores = { "0" };
            string[] critX = { "codigo = '" + artigo.Codigo + "'" };
            Conexao.ClienteSql.UPDATE(tabela, campos, valores, critX);
            return artigo;

        }
        public Artigo Restaurar(Artigo artigo)
        {
            string tabela = "Produtos";
            string[] campos = { "status" };
            Object[] valores = { "1" };
            string[] critX = { "codigo = '" + artigo.Codigo + "'" };
            Conexao.ClienteSql.UPDATE(tabela, campos, valores, critX);
            return artigo;

        }
        private void GravaTudo(Artigo artigo)
        {
            foreach (var item in artigo.Armazens) item.CodProduto = artigo.Codigo;

            if (artigo.Substitutos != null)
            {
                foreach (var item in artigo.Substitutos) item.CodNovo = artigo.Codigo;
                GravaSubtitutos(artigo.Substitutos);
            }

            if (artigo.Composicao != null)
            {
                foreach (var item in artigo.Composicao) item.CodArtigo = artigo.Codigo;
                GravaComposicao(artigo.Composicao);
            }

            if (artigo.Fornecedores != null)
            {
                foreach (var item in artigo.Fornecedores) item.CodProduto = artigo.Codigo;
                GravaFornecedores(artigo.Fornecedores);
            }

            if (artigo.Armazens == null)
            {
                throw new Exception();
            }

            GravaStock(artigo.Armazens);

        }
        public void Insert(ProdutosViewModel tabela)
        {
            Db.Add(tabela);
        }
        public void Update(ProdutosViewModel tabela)
        {
            Db.Update(tabela);
        }


        private void GravaStock(List<ProdutoStock> lista)
        {
            for (int i = 0; i < lista.Count; i++)
            {
                string codStock = lista[i].Codigo.ToString();
                string CodArmazem = lista[i].CodArmazem.ToString();
                string CodProduto = lista[i].CodProduto.ToString();
                double Qtde = double.Parse(lista[i].Quantidade.ToString());

                string[] campos = { "CodArmazem", "CodProduto", "Qtde", "StockMin", "StockMax", };
                object[] Valores = { CodArmazem, CodProduto, Qtde, lista[i].StockMin, lista[i].StockMax };
                string[] campos2 = { "StockMin", "StockMax", };
                object[] Valores2 = { lista[i].StockMin, lista[i].StockMax };
                string[] Criterio = { "Codigo = '" + codStock + "'" };

                if (int.Parse(codStock) == 0)
                {
                    Conexao.ClienteSql.INSERT("ProdutoStock", campos, Valores);
                }
                else
                {
                    Conexao.ClienteSql.UPDATE("ProdutoStock", campos2, Valores2, Criterio);
                }
            }
        }
        private void GravaSubtitutos(List<SubistitutoViewModel> lista)
        {
            for (int i = 0; i < lista.Count; i++)
            {
                string Codigo = lista[i].Codigo.ToString();
                string CodigoProduto = lista[i].CodigoSubstituto.ToString();
                string CodProduto = lista[i].CodNovo.ToString();
                string[] campos = { "CodigoProduto", "CodProduto", };
                object[] Valores = { CodigoProduto, CodProduto };
                string[] Criterio = { "Codigo = '" + Codigo + "'" };

                if (int.Parse(Codigo) == 0)
                {
                    Conexao.ClienteSql.INSERT("ProdutosSubstitutos", campos, Valores);
                }
                else
                {
                    Conexao.ClienteSql.UPDATE("ProdutosSubstitutos", campos, Valores, Criterio);
                }
            }
        }
        private void GravaFornecedores(List<FornecedorProdutosViewModel> lista)
        {
            for (int i = 0; i < lista.Count; i++)
            {

                string Codigo = lista[i].Codigo.ToString();
                string CodProduto = lista[i].CodProduto.ToString();
                string CodFornecedor = lista[i].CodFornecedor.ToString();
                double Custo = double.Parse(lista[i].Custo.ToString());

                string[] campos = { "CodProduto", "CodFornecedor", "Custo" };
                object[] Valores = { CodProduto, CodFornecedor, Custo };
                string[] Criterio = { "codigo = '" + Codigo + "'" };


                if (int.Parse(Codigo) == 0)
                {
                    Conexao.ClienteSql.INSERT("ProdutoFornecedor", campos, Valores);
                }
                else
                {
                    Conexao.ClienteSql.UPDATE("ProdutoFornecedor", campos, Valores, Criterio);
                }
            }
        }
        public void GravaComposicao(List<ComposicaoProdutosViewModel> lista)
        {
            for (int i = 0; i < lista.Count; i++)
            {
                string Codigo = lista[i].Codigo.ToString();
                string CodigoProduto = lista[i].CodArtigoComponente.ToString();
                string CodProduto = lista[i].CodArtigo.ToString();
                double Qtdade = double.Parse(lista[i].Qtde.ToString());
                string[] campos = { "CodigoProduto", "CodProduto", "Qtde" };
                object[] Valores = { CodigoProduto, CodProduto, Qtdade };
                string[] Criterio = { "Codigo = '" + Codigo + "'" };

                if (int.Parse(Codigo) <= 0)
                {
                    Conexao.ClienteSql.INSERT("ProdutosComposicao", campos, Valores);
                }
                else
                {
                    Conexao.ClienteSql.UPDATE("ProdutosComposicao", campos, Valores, Criterio);
                }
            }
        }
        public List<Artigo> Listar(string criterios)
        {
            throw new NotImplementedException();
        }
        IEnumerable<Artigo> IArtigosRepository.Listar(string criterios)
        {
            throw new NotImplementedException();
        }
        public List<ComposicaoProdutosViewModel> GetComposicao(int CodProduto)
        {
            string SQL = "SELECT ProdutosComposicao.Codigo, "+
                                 "ProdutosComposicao.CodProduto As CodArtigo, " +
                                 "Produtos.Descricao as Nome, "+
                                 "ProdutosComposicao.Qtde, "+
                                 "ProdutosComposicao.CodigoProduto As CodArtigoComponente " +
                         "from ProdutosComposicao ";
            SQL += "Left Outer Join Produtos on Produtos.Codigo=ProdutosComposicao.CodigoProduto ";
            SQL += "WHERE ProdutosComposicao.CodProduto='" + CodProduto + "' ";
            Object obj = Conexao.ClienteSql.SELECT(SQL);

            DataTable dtadados = (DataTable)obj;

            var result = Folha.Domain.Helpers.DataTableHelper.DataTableToList<ComposicaoProdutosViewModel>(dtadados);

            return result;
        }
        public List<FornecedorProdutosViewModel> GetFornecedores(int CodProduto)
        {
            string SQL = "SELECT ProdutoFornecedor.Codigo, ProdutoFornecedor.CodFornecedor as CodFornecedor, Entidades.Nome, ProdutoFornecedor.Custo from ProdutoFornecedor";
            SQL += " Join  Fornecedores on ProdutoFornecedor.CodFornecedor=Fornecedores.Codigo ";
            SQL += " Join Entidades On Entidades.Codigo=Fornecedores.CodEntidade ";
            SQL += " WHERE ProdutoFornecedor.CodProduto='" + CodProduto + "'";

            Object obj = Conexao.ClienteSql.SELECT(SQL);

            DataTable dtadados = (DataTable)obj;

            var result = Folha.Domain.Helpers.DataTableHelper.DataTableToList<FornecedorProdutosViewModel>(dtadados);

            return result;
        }
        public List<SubistitutoViewModel> GetSubstitutos(int CodProduto)
        {
            string SQL = "SELECT ProdutosSubstitutos.Codigo, ProdutosSubstitutos.CodProduto As CodNovo, Produtos.Descricao as Nome, ProdutosSubstitutos.CodigoProduto As CodigoSubstituto  from ProdutosSubstitutos";
            SQL += " Left Outer Join Produtos on Produtos.Codigo=ProdutosSubstitutos.CodProduto ";
            SQL += " Left Outer Join Categoria On Produtos.CodCategoria=Categoria.Codigo ";
            SQL += " WHERE ProdutosSubstitutos.CodProduto='" + CodProduto + "'";

            Object obj = Conexao.ClienteSql.SELECT(SQL);
            DataTable dtadados = (DataTable)obj;
            foreach (DataRow item in dtadados.Rows)
            {
                var codigoSubstituto = Convert.ToInt16(item["CodigoSubstituto"]);
                if (codigoSubstituto <= 0)
                {
                    continue;
                }
                item["Nome"] = ((ProdutosViewModel)Get(new ProdutosViewModel() { Codigo = codigoSubstituto })).descricao;
            }
            var result = Folha.Domain.Helpers.DataTableHelper.DataTableToList<SubistitutoViewModel>(dtadados);

            return result;
        }
        public List<ArmazenProdutosViewModel> GetArmazens(int CodProduto)
        {
            string SQL = "SELECT ProdutoStock.Codigo, ProdutoStock.CodArmazem, Armazens.Descricao as Nome, ProdutoStock.Qtde as Quantidade, ProdutoStock.StockMin as StockMin, ProdutoStock.StockMax as StockMax from ProdutoStock";
            SQL += " Left Outer Join Armazens on Armazens.Codigo=ProdutoStock.CodArmazem ";
            SQL += " WHERE ProdutoStock.CodProduto='" + CodProduto + "'";

            Object obj = Conexao.ClienteSql.SELECT(SQL);

            DataTable dtadados = (DataTable)obj;

            var result = Folha.Domain.Helpers.DataTableHelper.DataTableToList<ArmazenProdutosViewModel>(dtadados);

            return result;
        }
        public void EliminarArmazem(ProdutoStock armazem)
        {
            DbDTO dto = new DbDTO()
            {
                Nome = "ProdutoStock"
            };
            Conexao.ClienteSql.DELETE(dto.Nome, "Codigo ='" + armazem.Codigo + "'");
        }
        public void DeleteArmazem(ArmazenProdutosViewModel delete)
        {
            DbDTO dto = new DbDTO()
            {
                Nome = "ProdutoStock"
            };
            Conexao.ClienteSql.DELETE(dto.Nome, "Codigo ='" + delete.Codigo + "'");
        }
        public void DeleteFornecedor(FornecedorProdutosViewModel delete)
        {
            DbDTO dto = new DbDTO()
            {
                Nome = "ProdutoFornecedor"
            };
            Conexao.ClienteSql.DELETE(dto.Nome, "Codigo ='" + delete.Codigo + "'");
        }
        public void DeleteComposicao(ComposicaoProdutosViewModel delete)
        {
            DbDTO dto = new DbDTO()
            {
                Nome = "ProdutosComposicao"
            };
            Conexao.ClienteSql.DELETE(dto.Nome, "Codigo ='" + delete.Codigo + "'");
        }
        public void DeleteSubstituto(SubistitutoViewModel delete)
        {
            DbDTO dto = new DbDTO()
            {
                Nome = "ProdutosSubstitutos"
            };
            Conexao.ClienteSql.DELETE(dto.Nome, "Codigo ='" + delete.Codigo + "'");
        }

        public bool VerificarDup(string nomeTabela, Dictionary<string, object> dicionario)
        {
            return VerificarDuplicacaoDoRegistro(nomeTabela, dicionario);
        }
        public IEnumerable<RelListagemArtigosViewModel> ListagemArtigos(string Preco, int IndexTipoStock, int CodArmazem)
        {
            string SQL = "SELECT Produtos.Codigo as CODIGO, Produtos.Descricao as DESCRICAO,Produtos." + Preco + " As PRECO, ProdutoStock.Qtde As Quantidade, Produtos.Custo";
            SQL += " FROM Produtos, ProdutoStock ";
            SQL += " WHERE Produtos.Codigo=ProdutoStock.CodProduto And ProdutoStock.CodArmazem='" + CodArmazem + "' and Produtos.status=1";
            if (IndexTipoStock == 1) SQL += " And Produtos.movimentaStock='1'";
            if (IndexTipoStock == 2) SQL += " And Produtos.movimentaStock='0'";
            SQL += " order by Produtos.Descricao";

            object x = Conexao.ClienteSql.SELECT(SQL);
            DataTable DtDados = (DataTable)x;
            var result = Folha.Domain.Helpers.DataTableHelper.DataTableToList<RelListagemArtigosViewModel>(DtDados);
            return result;
        }
        private bool VerificaExiste(int CodProduto, List<RelMovArtigosViewModel> Dados)
        {
            bool res = false;
            for (int i = 0; i < Dados.Count; i++)
            {
                if (CodProduto == Dados[i].Codigo)
                    res = true;
            }

            return res;
        }
        public IEnumerable<RelMovArtigosViewModel> RelMovArtigos(string dataInicial, string dataFinal, int CodArmazem)
        {
            var LtMovArtigo = new List<RelMovArtigosViewModel>();
            string SQL = "SELECT Produtos.Codigo, Produtos.Descricao, Operacoes.MovStk as TIPO, MovProdutos.Qtdade";
            SQL += " FROM MovProdutos";
            SQL += " Join Produtos on Produtos.Codigo=MovProdutos.CodProduto join Documentos on MovProdutos.CodDocumento = Documentos.Codigo join Operacoes on Operacoes.Codigo = Documentos.CodOperacao";
            SQL += " WHERE MovProdutos.CodArmazem='" + CodArmazem + "' and MovProdutos.CodDocumento= Documentos.codigo";
            if (!string.IsNullOrEmpty(dataInicial) && !string.IsNullOrEmpty(dataFinal))
                SQL += " and Documentos.Data between '" + dataInicial + "' and '" + dataFinal + "'";

            object x = Conexao.ClienteSql.SELECT(SQL);
            DataTable DtDados = (DataTable)x;

            for (int i = 0; i < DtDados.Rows.Count; i++)
            {
                int CodProduto = int.Parse(DtDados.Rows[i]["Codigo"].ToString());
                string tipo = DtDados.Rows[i]["TIPO"].ToString();
                if (VerificaExiste(CodProduto, LtMovArtigo) == false)
                {
                    int codigo = int.Parse(DtDados.Rows[i]["CODIGO"].ToString());
                    string descricao = DtDados.Rows[i]["Descricao"].ToString();


                    string qtdade = DtDados.Rows[i]["QTDADE"].ToString();
                    double entrada = 0;
                    double saida = 0;
                    double stock = 0;
                    if (tipo == "CREDITO")
                    {
                        entrada = double.Parse(DtDados.Rows[i]["QTDADE"].ToString());
                    }
                    if (tipo == "DEBITO")
                    {
                        saida = double.Parse(DtDados.Rows[i]["QTDADE"].ToString());

                    }
                    stock = entrada - saida;

                    LtMovArtigo.Add(new RelMovArtigosViewModel() { Codigo = codigo, Descricao = descricao, Tipo = tipo, Quantidade = Convert.ToDouble(qtdade), Entradas = entrada, Saidas = saida, Stock = stock });

                }
                else
                {
                    double qt = double.Parse(DtDados.Rows[i]["QTDADE"].ToString());
                    for (int j = 0; j < LtMovArtigo.Count; j++)
                    {
                        if (CodProduto == LtMovArtigo[j].Codigo)
                        {

                            if (tipo == "CREDITO")
                            {
                                double q_Antigo = LtMovArtigo[j].Entradas;
                                LtMovArtigo[j].Entradas = qt + q_Antigo;
                            }
                            if (tipo == "DEBITO")
                            {

                                double q_Antigo = LtMovArtigo[j].Saidas;
                                LtMovArtigo[j].Saidas = qt + q_Antigo;
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < LtMovArtigo.Count; i++)
            {
                double entrada = LtMovArtigo[i].Entradas;
                double saida = LtMovArtigo[i].Saidas;
                double stock = entrada - saida;
                LtMovArtigo[i].Stock = stock;
            }
            return LtMovArtigo;
        }
        public DataViewModel RetornaDataMovArtigo(int CodArmazem)
        {
            string SQL = "SELECT Min(Documentos.[Data]) as DataInicial, Max(Documentos.[Data]) as DataFinal";
            SQL += " FROM MovProdutos";
            SQL += " Join Produtos on Produtos.Codigo=MovProdutos.CodProduto join Documentos on MovProdutos.CodDocumento = Documentos.Codigo join Operacoes on Operacoes.Codigo = Documentos.CodOperacao";
            SQL += " WHERE MovProdutos.CodArmazem='" + CodArmazem + "' and MovProdutos.CodDocumento= Documentos.codigo";
            DataViewModel Data = null;

            object x = Conexao.ClienteSql.SELECT(SQL);
            DataTable DtDados = (DataTable)x;

            string dtInicial = DtDados.Rows[0]["DataInicial"].ToString();
            string dtFinal = DtDados.Rows[0]["DataFinal"].ToString();

            if (!string.IsNullOrEmpty(dtInicial) && !string.IsNullOrEmpty(dtFinal))
                Data = new DataViewModel() { DataInicial = Convert.ToDateTime(dtInicial), DataFinal = Convert.ToDateTime(dtFinal) };
            return Data;
        }

        public DataViewModel RetornaDataArtigosVendidos(int CodArmazem)
        {
            string SQL = " SELECT Min(Documentos.[Data]) as DataInicial, Max(Documentos.[Data]) as DataFinal FROM MovProdutos INNER JOIN Documentos ON Documentos.codigo = MovProdutos.CodDocumento INNER JOIN" +
               " Produtos ON Produtos.Codigo = MovProdutos.CodProduto WHERE(Documentos.CodOperacao = 1) AND(MovProdutos.CodArmazem = '" + CodArmazem + "')  and Produtos.status = 1";
            DataViewModel Data = null;

            object x = Conexao.ClienteSql.SELECT(SQL);
            DataTable DtDados = (DataTable)x;

            string dtInicial = DtDados.Rows[0]["DataInicial"].ToString();
            string dtFinal = DtDados.Rows[0]["DataFinal"].ToString();

            if (!string.IsNullOrEmpty(dtInicial) && !string.IsNullOrEmpty(dtFinal))
                Data = new DataViewModel() { DataInicial = Convert.ToDateTime(dtInicial), DataFinal = Convert.ToDateTime(dtFinal) };
            return Data;
        }

        public IEnumerable<RelMovArtigosViewModel> ArtigosVendidos(int CodArmazem)
        {
            List<RelMovArtigosViewModel> result = new List<RelMovArtigosViewModel>();
            try
            {
                string SQL = "SELECT  SUM(MovProdutos.Qtdade) AS Quantidade, Produtos.Descricao FROM MovProdutos INNER JOIN Documentos ON Documentos.codigo = MovProdutos.CodDocumento INNER JOIN";
                SQL += " Produtos ON Produtos.Codigo = MovProdutos.CodProduto WHERE (Documentos.CodOperacao = 1) AND (MovProdutos.CodArmazem='" + CodArmazem + "') and Produtos.status=1 GROUP BY MovProdutos.CodProduto, Produtos.descricao";
                SQL += " ORDER BY Quantidade DESC";
                object x = Conexao.ClienteSql.SELECT(SQL);
                DataTable DtDados = (DataTable)x;
                result = Folha.Domain.Helpers.DataTableHelper.DataTableToList<RelMovArtigosViewModel>(DtDados);
            }
            catch (Exception)
            {
            }
            return result;
        }
        public IEnumerable<RelListagemArtigosViewModel> SemControloStock(int CodArmazem)
        {
            string SQL = "SELECT Produtos.Codigo , Produtos.Descricao";
            SQL += " FROM Produtos join ProdutoStock on Produtos.Codigo=ProdutoStock.CodProduto";
            SQL += " WHERE Produtos.movimentaStock='0' And ProdutoStock.CodArmazem='" + CodArmazem + "' and Produtos.status=1";
            SQL += " order by Produtos.Descricao";
            object x = Conexao.ClienteSql.SELECT(SQL);
            DataTable DtDados = (DataTable)x;
            var result = Folha.Domain.Helpers.DataTableHelper.DataTableToList<RelListagemArtigosViewModel>(DtDados);
            return result;
        }

        public IEnumerable<RelListagemArtigosViewModel> TabelaPreco(int CodArmazem, string Preco)
        {
            string SQL = "SELECT Produtos.Codigo as CODIGO, Produtos.Descricao ,Produtos." + Preco + " AS Preco";
            SQL += " FROM Produtos join ProdutoStock on Produtos.Codigo=ProdutoStock.CodProduto";
            SQL += " WHERE ProdutoStock.CodArmazem='" + CodArmazem + "' and Produtos.status=1";
            SQL += " order by Produtos.Descricao";

            object x = Conexao.ClienteSql.SELECT(SQL);
            DataTable DtDados = (DataTable)x;
            var result = Folha.Domain.Helpers.DataTableHelper.DataTableToList<RelListagemArtigosViewModel>(DtDados);
            return result;
        }

        public IEnumerable<RelListagemArtigosViewModel> ListaPreco(int CodArmazem)
        {
            string SQL = "SELECT Produtos.Codigo, Produtos.Descricao, Produtos.Preco1, Produtos.Preco2, Produtos.Preco3";
            SQL += " FROM Produtos join ProdutoStock on Produtos.Codigo=ProdutoStock.CodProduto";
            SQL += " WHERE ProdutoStock.CodArmazem='" + CodArmazem + "' and Produtos.status=1";
            SQL += " order by Produtos.Descricao";

            object x = Conexao.ClienteSql.SELECT(SQL);
            DataTable DtDados = (DataTable)x;
            var result = Folha.Domain.Helpers.DataTableHelper.DataTableToList<RelListagemArtigosViewModel>(DtDados);
            return result;
        }
        public IEnumerable<RelListagemArtigosViewModel> ListagemRetenção(string dataInicial,string dataFinal,int CodArmazem)
        {
            var result = new List<RelListagemArtigosViewModel>();
            try
            {
               string SQL = "SELECT MovProdutos.CodProduto as Codigo, MovProdutos.Qtdade,MovProdutos.Descricao, MovProdutos.Preco as PRECO, MovProdutos.Retencao as RETENCAO FROM MovProdutos INNER JOIN Documentos ON Documentos.codigo = MovProdutos.CodDocumento INNER JOIN";
                SQL += " Produtos ON Produtos.Codigo = MovProdutos.CodProduto WHERE (Documentos.CodOperacao = 1) AND (MovProdutos.CodArmazem='" + CodArmazem + "' and MovProdutos.CodDocumento= Documentos.codigo)";

                if (!string.IsNullOrEmpty(dataInicial) && !string.IsNullOrEmpty(dataFinal))
                    SQL += " and (Documentos.Data between '" + dataInicial + "' and '" + dataFinal + "')";

                SQL += " and Produtos.status=1 and MovProdutos.Retencao>0";
               SQL += " ORDER BY Qtdade DESC";
               object x = Conexao.ClienteSql.SELECT(SQL);
               DataTable DtDados = (DataTable)x;

                string SQL2 = "SELECT  SUM(MovProdutos.Qtdade) AS Qtdade FROM MovProdutos INNER JOIN Documentos ON Documentos.codigo = MovProdutos.CodDocumento INNER JOIN";
                SQL2 += " Produtos ON Produtos.Codigo = MovProdutos.CodProduto WHERE (Documentos.CodOperacao = 1) AND (MovProdutos.CodArmazem='" + CodArmazem + "' and MovProdutos.CodDocumento= Documentos.codigo)";

                if (!string.IsNullOrEmpty(dataInicial) && !string.IsNullOrEmpty(dataFinal))
                    SQL2 += " and (Documentos.Data between '" + dataInicial + "' and '" + dataFinal + "')";

                SQL2 += " and Produtos.status=1 and MovProdutos.Retencao>0 GROUP BY MovProdutos.CodProduto, Produtos.descricao";
                SQL2 += " ORDER BY Qtdade DESC";
                object y = Conexao.ClienteSql.SELECT(SQL2);
                DataTable DtDados2 = (DataTable)y;

                for (int i = 0; i < DtDados.Rows.Count; i++)
                {
                    var contem = result.Where(r => r.Descricao == DtDados.Rows[i]["Descricao"].ToString()).FirstOrDefault();
                    if (Equals(contem, null))
                    {
                            result.Add(new RelListagemArtigosViewModel()
                            {
                                Codigo = int.Parse(DtDados.Rows[i]["Codigo"].ToString()),
                                Descricao = DtDados.Rows[i]["Descricao"].ToString(),
                                Preco = Convert.ToDouble(DtDados.Rows[i]["Preco"].ToString()),
                                Retencao = Convert.ToDouble(DtDados.Rows[i]["RETENCAO"].ToString())
                            });
                    }
                }

                for (int i = 0; i < DtDados2.Rows.Count; i++)
                {
                    result[i].Quantidade = Convert.ToDouble(DtDados2.Rows[i]["Qtdade"].ToString());
                }
  
            }
            catch (Exception){}
            return result;
        }
        public DataViewModel RetornaDataRetencao(int CodArmazem)
        {
            DataViewModel Data = null;
            string SQL = "SELECT Min(Documentos.[Data]) as DataInicial, Max(Documentos.[Data]) as DataFinal FROM MovProdutos INNER JOIN Documentos ON Documentos.codigo = MovProdutos.CodDocumento INNER JOIN";
            SQL += " Produtos ON Produtos.Codigo = MovProdutos.CodProduto WHERE (Documentos.CodOperacao = 1) AND (MovProdutos.CodArmazem='" + CodArmazem + "' and MovProdutos.CodDocumento= Documentos.codigo) and Produtos.status=1 and MovProdutos.Retencao>0";
            object x = Conexao.ClienteSql.SELECT(SQL);
            DataTable DtDados = (DataTable)x;

            string dtInicial = DtDados.Rows[0]["DataInicial"].ToString();
            string dtFinal = DtDados.Rows[0]["DataFinal"].ToString();

            if (!string.IsNullOrEmpty(dtInicial) && !string.IsNullOrEmpty(dtFinal))
                Data = new DataViewModel() { DataInicial = Convert.ToDateTime(dtInicial), DataFinal = Convert.ToDateTime(dtFinal) };
            return Data;
        }

        public void UpdateStok(ProdutoStock entity)
        {
            DbDTO dto = new DbDTO()
            {
                Nome = "ProdutoStock",
                Campos = new string[] { "stockMax", "stockMin" },
                Valores = new Object[] { entity.StockMax, entity.StockMin }
            };
            Conexao.ClienteSql.UPDATE(dto.Nome, dto.Campos, dto.Valores, "codigo ='" + entity.Codigo + "'");
        }
    }
}
