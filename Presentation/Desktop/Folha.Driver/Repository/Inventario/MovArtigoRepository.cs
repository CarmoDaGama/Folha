

using System;
using System.Collections.Generic;
using System.Linq;

using System.Data;
using Folha.Domain.Models.Inventario;
using Folha.Domain.Models.Db;
using Folha.Domain.Interfaces.Repository.Inventario;
using Folha.Domain.ViewModels.Frame.Inventario;
using Folha.Domain.Helpers;

namespace Folha.Driver.Repository.Inventario
{
    using Folha.Domain.ViewModels.Inventario;
    using Folha.Domain.ViewModels.Documentos;
    using Folha.Domain.ViewModels.Financeiro;
    using Folha.Domain.ViewModels.Frame.Documentos;
    using Folha.Domain.Interfaces.Repository.Financeiro;
    using Data;

    public class MovArtigoRepository : RepositoryBase<DbDTO>, IMovArtigoRepository
    {
        private readonly IPagamentosRepository _pagamentoRepository;
        public MovArtigoRepository(IPagamentosRepository pagamentoRepository)
        {
            _pagamentoRepository = pagamentoRepository;
        }
        //TODO: MMMM
        //TODO: RRRRRRR
        //TODO: TTTTT
        private ContasBancariasViewModel GetPagamento(int codigo)
        {
            var pagamentos = _pagamentoRepository.GetAllPorIdDocumento(codigo);
            PagamentosViewModel pagamento = new PagamentosViewModel() { Forma = new fPagamentosViewModel() {
                Conta = new ContasBancariasViewModel()
                {
                    Banco = new BancosViewModel() { descricao = "Caixa" },
                    Numero = "Numerário"
                }
            } };
            for (int i = pagamentos.Count - 1; i >= 0; i--)
            {
                var conta = pagamentos[i].Forma.Conta;
                if (!Equals(conta, null) && conta.codigo > 0)
                {
                    pagamento = null;
                    pagamento = pagamentos[i];
                }
            }
            return pagamento.Forma.Conta;
        }
        public void LancarProdutoCyber(int NumeroVenda, MovArtigo movArtigo) { }

        public void LancarProdutoHotel(int NumeroVenda, MovArtigo movArtigo, Guid quartoID) { }

        public void LancarProdutoOrdemServico(int NumeroVenda, MovArtigo movArtigo, Guid equipamentoID) { }

        public void LancarProdutoVenda(int NumeroVenda, MovArtigo movArtigo, bool variasLinhas) { }

        public IEnumerable<LerProdutosViewModel> ListarProdutos_RP(string crit,string dtInicial, string dtFinal)
        {
            DataTable DtDados = new DataTable();
            List<LerProdutosViewModel> result = new List<LerProdutosViewModel>();

            string[] tabelas = { "MovProdutos" }; //, "", "" };
            string[] campos = { "MovProdutos.CodDocumento", "MovProdutos.CodProduto as CodProd", "MovProdutos.Descricao as Nome", "MovProdutos.Preco as Preco", "Armazens.Descricao as Armazem", "MovProdutos.Qtdade as Quantidade", "MovProdutos.Total as Total", "MovProdutos.Custo as Custo", "MovProdutos.Imposto as Imposto", "MovProdutos.Desconto" };
            string[] criteriosTodos = { "Armazens on MovProdutos.CodArmazem=Armazens.codigo", "Documentos on Documentos.Codigo=MovProdutos.CodDocumento" };

            string[] criterios = { crit };

            string SQL = "SELECT SUM(MovProdutos.Qtdade) as Quantidade FROM MovProdutos INNER JOIN Armazens on MovProdutos.CodArmazem=Armazens.codigo INNER JOIN Documentos on Documentos.Codigo=MovProdutos.CodDocumento WHERE Documentos.CodOperacao<'4' and Documentos.Data between '"+dtInicial+"' and '"+dtFinal+"' And Documentos.Estado<>'ANULADO'  GROUP BY MovProdutos.CodProduto order by MovProdutos.CodProduto";
            object x = Conexao.ClienteSql.SELECT(SQL);
            DataTable DtQtd = (DataTable)x;

            if (string.IsNullOrEmpty(crit))
            {
                var ob = Conexao.ClienteSql.INNERJOIN(tabelas[0].ToString(), campos, criteriosTodos, null);
                try
                {

                    DtDados = (DataTable)ob;
                    for (int i = 0; i < DtDados.Rows.Count; i++)
                    {
                        var contem = result.Where(r => r.Nome == DtDados.Rows[i]["Nome"].ToString()).FirstOrDefault();
                        if (Equals(contem, null))
                        {
                            result.Add(new LerProdutosViewModel()
                            {
                                CodDocumento = int.Parse(DtDados.Rows[i]["CodDocumento"].ToString()),
                                CodProd = int.Parse(DtDados.Rows[i]["CodProd"].ToString()),
                                Nome = DtDados.Rows[i]["Nome"].ToString(),
                                Preco = Convert.ToDouble(DtDados.Rows[i]["Preco"].ToString()),
                                Armazem = DtDados.Rows[i]["Armazem"].ToString(),
                                Quantidade = Convert.ToDouble(DtDados.Rows[i]["Quantidade"].ToString()),
                                Total = Convert.ToDouble(DtDados.Rows[i]["Total"].ToString()),
                                Custo = Convert.ToDouble(DtDados.Rows[i]["Custo"].ToString()),
                                Imposto = Convert.ToDouble(DtDados.Rows[i]["Imposto"].ToString()),
                                Desconto = Convert.ToDouble(DtDados.Rows[i]["Desconto"].ToString())

                            });
                        }
                    }
                    return result;
                }
                catch (Exception ex) { throw new Exception("Erro a Ler Produto \n " + ex.Message); }
            }
            else
            {
                var ob = Conexao.ClienteSql.INNERJOIN(tabelas[0].ToString(), campos, criteriosTodos, criterios);
                try
                {
  
                    DtDados = (DataTable)ob;

                    for (int i = 0; i < DtDados.Rows.Count; i++)
                    {
                        var contem = result.Where(r => r.Nome== DtDados.Rows[i]["Nome"].ToString()).FirstOrDefault();
                        if (Equals(contem, null))
                        {
                            result.Add(getAdd(DtDados, i));
                        }
                    }
                    if(DtDados.Rows.Count>0)
                    {
                        for (int i = 0; i < DtQtd.Rows.Count; i++)
                        {
                            result[i].Quantidade = Convert.ToDouble(DtQtd.Rows[i]["Quantidade"].ToString());
                        }
                    }
                    
                    return result;
                }
                catch (Exception ex) { throw new Exception("Erro a Ler Produto \n " + ex.Message); }
            }



        }

        private static LerProdutosViewModel getAdd(DataTable DtDados, int i)
        {
            return new LerProdutosViewModel()
            {
                CodDocumento = int.Parse(DtDados.Rows[i]["CodDocumento"].ToString()),
                CodProd = int.Parse(DtDados.Rows[i]["CodProd"].ToString()),
                Nome = DtDados.Rows[i]["Nome"].ToString(),
                Preco = Convert.ToDouble(DtDados.Rows[i]["Preco"].ToString()),
                Armazem = DtDados.Rows[i]["Armazem"].ToString(),
                Quantidade = Convert.ToDouble(DtDados.Rows[i]["Quantidade"].ToString()),
                Total = Convert.ToDouble(DtDados.Rows[i]["Total"].ToString()),
                Custo = Convert.ToDouble(DtDados.Rows[i]["Custo"].ToString()),
                Imposto = Convert.ToDouble(DtDados.Rows[i]["Imposto"].ToString()),
                Desconto = Convert.ToDouble(DtDados.Rows[i]["Desconto"].ToString())

            };
        }

        public List<MovArtigoViewModel> LiastarMovArtigos(int documentoId, string criterios)
        {
            DataTable tabelaMovProdutos = new DataTable();
            List<MovArtigoViewModel> listReturn = new List<MovArtigoViewModel>();

            string[] tabelas = { "MovProdutos" }; //, "", "" };
            string[] campos = { "MovProdutos.CodProduto as CODIGO", "MovProdutos.Descricao as NOME", "MovProdutos.Preco as PRECO", "MovProdutos.Desconto", "MovProdutos.Imposto", "Armazens.Descricao as ARMAZEM", "MovProdutos.Qtdade as QTDADE", "MovProdutos.Total as TOTAL", "MovProdutos.CODIGO as LINHA", "MovProdutos.codArmazem as CODARMAZEM" };

            Object objctData;

            if (criterios == null)
            {
                string[] criteriosTodos = { " Armazens on MovProdutos.CodArmazem=Armazens.codigo" };
                string[] arrayCriterios = { "MovProdutos.CodDocumento ='" + documentoId + "'" };
                // Busca.setSelectLeftJoin(Geral.CaminhoBd, tabelas, campos, criteriosTodos, criterios);
                objctData = Conexao.ClienteSql.LEFTJOIN(tabelas[0].ToString(), campos, criteriosTodos, arrayCriterios);
            }
            else
            {
                string[] criteriosTodos = { " Armazens on MovProdutos.CodArmazem=Armazens.codigo" };
                string[] arrayCriterios = { "MovProdutos.CodDocumento ='" + documentoId + "' ", criterios };
                //Busca.setSelectLeftJoin(Geral.CaminhoBd, tabelas, campos, criteriosTodos, criterios);
                objctData = Conexao.ClienteSql.LEFTJOIN(tabelas[0].ToString(), campos, criteriosTodos, arrayCriterios);
            }
            try
            {
                // MessageBox.Show(ob.ToString());

                tabelaMovProdutos = (DataTable)objctData;
                listReturn = DataTableHelper.DataTableToList<MovArtigoViewModel>(tabelaMovProdutos);
            }
            catch (Exception ex) {

                throw new Exception("Erro a Ler Produtos Movimentos de Produtos \n " + ex.Message);
            }
            return listReturn;
        }
        public List<MovArtigo> MostrarMovProdutos(int NumeroDocumento, string Criterios)
        {
            DataTable DtDados = new DataTable();
            List<MovArtigo> movArtigos = new List<MovArtigo>();


            string[] tabelas = { "MovProdutos" }; //, "", "" };
            string[] campos = { "MovProdutos.CodProduto as CODIGO", "MovProdutos.Descricao as NOME", "MovProdutos.Preco as PRECO", "MovProdutos.Desconto", "MovProdutos.Imposto", "Armazens.Descricao as ARMAZEM", "MovProdutos.Qtdade as QTDADE", "MovProdutos.Total as TOTAL", "MovProdutos.CODIGO as LINHA", "MovProdutos.codArmazem as CODARMAZEM" };

            Object ob;

            if (Criterios == null)
            {
                string[] criteriosTodos = { " Armazens on MovProdutos.CodArmazem=Armazens.codigo" };
                string[] criterios = { "MovProdutos.CodDocumento ='" + NumeroDocumento + "'" };
                // Busca.setSelectLeftJoin(Geral.CaminhoBd, tabelas, campos, criteriosTodos, criterios);
                ob = Conexao.ClienteSql.LEFTJOIN(tabelas[0].ToString(), campos, criteriosTodos, criterios);
            }
            else
            {
                string[] criteriosTodos = { " Armazens on MovProdutos.CodArmazem=Armazens.codigo" };
                string[] criterios = { "MovProdutos.CodDocumento ='" + NumeroDocumento + "' ", Criterios };
                //Busca.setSelectLeftJoin(Geral.CaminhoBd, tabelas, campos, criteriosTodos, criterios);
                ob = Conexao.ClienteSql.LEFTJOIN(tabelas[0].ToString(), campos, criteriosTodos, criterios);
            }

            try
            {
                // MessageBox.Show(ob.ToString());

                DtDados = (DataTable)ob;
                movArtigos = DtDados.AsEnumerable().Select(linha => new MovArtigo
                {
                    ID = linha.Field<Guid>("CodProduto"),
                    Nome = linha.Field<String>("Descricao")
                }).ToList<MovArtigo>();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro a Ler Produtos Movimentos de Produtos \n " + ex.Message);
            }
            return null;
        }
        public List<MovArtigoViewModel> ListarMovArtigo(string ComissionarioID, string armazemID, string CodTurno)
        {

            string SQL = null;

            if (string.IsNullOrEmpty(ComissionarioID))
            {
                if (string.IsNullOrEmpty(armazemID))
                {
                    SQL = "select MovProdutos.codigo as CODIGO," +
                        " MovProdutos.Descricao as NOME, " +
                        "MovProdutos.Preco as PRECO," +
                        " sum(MovProdutos.Qtdade) as Qtdade, " +
                        "sum(MovProdutos.Qtdade * MovProdutos.Preco) as TOTAL," +
                        " MovProdutos.Retencao as Retencao " +
                    " from MovProdutos join Documentos on Documentos.codigo= MovProdutos.CodDocumento " +
                                     " join Operacoes on Operacoes.Codigo=Documentos.CodOperacao " +
                    " where Documentos.CodTurno='" + CodTurno + "' and " +
                            "Documentos.Estado='FECHADO' and " +
                            "Operacoes.Codigo=1 group by MovProdutos.codigo, MovProdutos.Descricao, MovProdutos.Preco, MovProdutos.Retencao";
                }
                else
                {
                    SQL = "select MovProdutos.codigo as CODIGO, " +
                            "MovProdutos.Descricao as NOME, " +
                            "MovProdutos.Preco as PRECO," +
                            " sum(MovProdutos.Qtdade) as Qtdade," +
                            " sum(MovProdutos.Qtdade * MovProdutos.Preco) as TOTAL, " +
                            "MovProdutos.Retencao as Retencao" +
                        " from MovProdutos join Documentos on Documentos.codigo= MovProdutos.CodDocumento " +
                                           "join Operacoes on Operacoes.Codigo=Documentos.CodOperacao " +
                        "where Documentos.CodTurno='" + CodTurno + "'  and MovProdutos.CodArmazem='" + armazemID + "' and Documentos.Estado='FECHADO' and Operacoes.Codigo=1 group by MovProdutos.codigo, MovProdutos.Descricao, MovProdutos.Preco,MovProdutos.Retencao";
                }
            }
            else
            {
                if (string.IsNullOrEmpty(armazemID))
                {
                    SQL = "select MovProdutos.CodProduto, MovProdutos.Descricao, MovProdutos.Preco as PRECO, sum(MovProdutos.Qtdade) as Qtdade, sum(MovProdutos.Qtdade * MovProdutos.Preco) as TOTAL, MovProdutos. as Retencao from MovProdutos"
                 + " join Documentos on Documentos.codigo= MovProdutos.CodDocumento join Operacoes on Operacoes.Codigo=Documentos.CodOperacao join comissoes on Comissoes.CodDocumento=Documentos.Codigo where Documentos.CodTurno='" + CodTurno + "' And Comissoes.CodEntidade = '" + ComissionarioID + "' and Documentos.Estado='FECHADO' and Operacoes.Codigo=1 group by MovProdutos.CodProduto, MovProdutos.Descricao, MovProdutos.Preco,MovProdutos.Retencao";
                }
                else
                {
                    SQL = "select MovProdutos.CodProduto, MovProdutos.Descricao, MovProdutos.Preco as PRECO, sum(MovProdutos.Qtdade) as Qtdade, sum(MovProdutos.Qtdade * MovProdutos.Preco) as TOTAL, MovProdutos..Retencao as Retencao from MovProdutos"
              + " join Documentos on Documentos.codigo= MovProdutos.CodDocumento join Operacoes on Operacoes.Codigo=Documentos.CodOperacao join comissoes on Comissoes.CodDocumento=Documentos.Codigo where Documentos.CodTurno='" + CodTurno + "' And Comissoes.CodEntidade = '" + ComissionarioID + "' and MovProdutos.CodArmazem='" + armazemID + "' And Documentos.Estado='FECHADO' and Operacoes.Codigo=1 group by MovProdutos.CodProduto, MovProdutos.Descricao, MovProdutos.Preco,MovProdutos.Retencao";
                }
            }

            object obj = Conexao.ClienteSql.SELECT(SQL);
            DataTable dtProdutosVendidos = (DataTable)obj;
            List<MovArtigoViewModel> result = DataTableHelper.DataTableToList<MovArtigoViewModel>(dtProdutosVendidos);
            return result;
        }
        public List<MovArtigoViewModel> ListarMovArtigo(int CodDocumento)
        {

            string SQL = null;

            SQL = "select MovProdutos.codigo as CODIGO," +
                " MovProdutos.Descricao as NOME, " +
                "MovProdutos.Preco as PRECO," +
                "MovProdutos.Qtdade as Qtdade, " +
                "(MovProdutos.Qtdade * MovProdutos.Preco) as TOTAL," +
                "MovProdutos.Retencao as Retencao " +
            " from MovProdutos join Documentos on Documentos.codigo= MovProdutos.CodDocumento " +
                                " join Operacoes on Operacoes.Codigo=Documentos.CodOperacao " +
            " where Documentos.Codigo='" + CodDocumento + "' and " +
                    " Documentos.Estado='FECHADO' ";
            object obj = Conexao.ClienteSql.SELECT(SQL);
            DataTable dtProdutosVendidos = (DataTable)obj;
            List<MovArtigoViewModel> result = DataTableHelper.DataTableToList<MovArtigoViewModel>(dtProdutosVendidos);
            return result;
        }
        #region CRUD
        public void Delete(MovProdutosViewModel movArtigo)
        {
            Db.Delete(movArtigo);
        }

        public object Get(MovProdutosViewModel movArtigo)
        {
            return Db.GetById<MovProdutosViewModel>(movArtigo.codigo);
        }

        public object GetAll(MovProdutosViewModel movArtigo)
        {
            return Db.GetEntities<MovProdutosViewModel>();
        }

        public List<MovProdutosViewModel> GetAllByIdDocumento(int documentoId)
        {
            return Db.GetEntities<MovProdutosViewModel>(" WHERE Documentos.codigo = '" + documentoId + "'");
        }
        public List<VendaViewModel> GetMovVendaByIdDocumento(int documentoId)
        {
            var movs = Db.GetEntities<MovProdutosViewModel>(" WHERE Documentos.codigo = '" + documentoId + "'");
            var vendas = new List<VendaViewModel>();
            var contaPagamento = GetPagamento(documentoId);
            foreach (var item in movs)
            {
                vendas.Add(new VendaViewModel()
                {
                    codigo=item.codigo,
                    MovArtigo = item,
                    qtde = item.Qtdade,
                    NomeCliente =item .Documento.NomeCliente,
                    ContaPagamento = contaPagamento
                });
            }
            return vendas;
        }
        public void Insert(MovProdutosViewModel movArtigo)
        {
            Db.Add(movArtigo);
        }

        public void Update(MovProdutosViewModel movArtigo)
        {
            Db.Update(movArtigo);
        }

        public object GetCodLast()
        {
            var obj = Conexao.ClienteSql.SELECT("Select  MAX(codigo) As Codigo From MovProdutos");

            DataTable dtadados = (DataTable)obj;

            var result = DataTableHelper.DataTableToList<MovProdutos>(dtadados).ToList();

            return result[0].codigo;
        }

        public void InsertOld(MovProdutosViewModel movProdutosViewModel)
        {
            string[] campos = new string[] {
                "CodDocumento",
                "Custo",
                "Imposto",
                "Desconto",
                "Qtdade",
                "Preco",
                "Retencao",
                "Total",
                "Descricao",
                "ArtigoAbstrato",
                "DescontoGeral",
                "CodImposto",
                "TipoImposto",
                "DescricaoImposto"
            };
            object[] valores = new object[] {
                movProdutosViewModel.CodDocumento,
                movProdutosViewModel.Custo,
                movProdutosViewModel.Imposto,
                movProdutosViewModel.Desconto,
                movProdutosViewModel.Qtdade,
                movProdutosViewModel.Preco,
                movProdutosViewModel.Retencao,
                movProdutosViewModel.Total,
                movProdutosViewModel.Descricao,
                movProdutosViewModel.ArtigoAbstrato,
                movProdutosViewModel.DescontoGeral,
                movProdutosViewModel.CodImposto,
                movProdutosViewModel.TipoImposto,
                movProdutosViewModel.DescricaoImposto
            };
            Conexao.ClienteSql.INSERT("MovProdutos", campos, valores);
        }
        public void UpdateOld(MovProdutosViewModel movProdutosViewModel)
        {
            string[] campos = new string[] {
                "CodDocumento",
                "Custo",
                "Desconto",
                "Imposto",
                "Qtdade",
                "Preco",
                "Retencao",
                "Total",
                "Descricao",
                "ArtigoAbstrato",
                "DescontoGeral",
                "CodImposto",
                "TipoImposto",
                "DescricaoImposto"
            };
            object[] valores = new object[] {
                movProdutosViewModel.CodDocumento,
                movProdutosViewModel.Custo,
                movProdutosViewModel.Desconto,
                movProdutosViewModel.Imposto,
                movProdutosViewModel.Qtdade,
                movProdutosViewModel.Preco,
                movProdutosViewModel.Retencao,
                movProdutosViewModel.Total,
                movProdutosViewModel.Descricao,
                movProdutosViewModel.ArtigoAbstrato,
                movProdutosViewModel.DescontoGeral,
                movProdutosViewModel.CodImposto,
                movProdutosViewModel.TipoImposto,
                movProdutosViewModel.DescricaoImposto
            };
            Conexao.ClienteSql.UPDATE("MovProdutos", campos, valores, "Codigo = '" + movProdutosViewModel.codigo + "'");
        }

        public List<MovProdutosViewModel> GetMovsPorDescricao(int codAtendimento)
        {
            return Db.GetEntities<MovProdutosViewModel>(" WHERE MovProdutos.Descricao LIKE '%?" + codAtendimento + "%'");
        }
        public List<DocumentoViewModel> GetDocumentosPor(int codAtendimento)
        {
            try
            {
                string SQL = "SELECT Documentos.codigo as Codigo, " +
                            "Documentos.Data as Data," +
                            " Documentos.Hora as Hora," +
                            " Operacoes.Nome as Documento" +
                            ", Areas.descricao as Area, " +
                            "Entidades.Nome AS Entidade, " +
                            "Documentos.Total as Total," +
                            " Documentos.Estado as Estado," +
                            " Usuarios.Nome AS Usuario, " +
                            "Documentos.CodOperacao as Documento," +
                            " Documentos.CodEntidade as CodCliente, " +
                            "Operacoes.MovFin as  MovFinanceiro," +
                            " Operacoes.MovStk as   MovInventario, " +
                            "Documentos.Descritivo as Descritivo," +
                            "MovProdutos.Descricao as NomeItem" +
                    " from Documentos JOIN Operacoes ON " +
                    " Operacoes.codigo = Documentos.CodOperacao " +
                    " JOIN Entidades ON Entidades.Codigo = Documentos.CodEntidade" +
                    " JOIN Usuarios ON Usuarios.codigo = Documentos.CodUsuario " +
                    " JOIN Areas ON Areas.codigo = Documentos.CodArea " +
                    " LEFT JOIN Comissoes ON Comissoes.CodDocumento = Documentos.Codigo " +
                    " LEFT JOIN MovProdutos ON MovProdutos.CodDocumento = Documentos.Codigo " +
                    " WHERE MovProdutos.ArtigoAbstrato LIKE '%?" + codAtendimento+"%'";

                //if (!string.IsNullOrEmpty(criterios))
                //{
                //    SQL = SQL + " Where " + criterios;
                //}

                SQL += " Order by Documentos.Codigo desc ";
                var ob = Conexao.ClienteSql.SELECT(SQL);
                DataTable DtDados = (DataTable)ob;
                var result = DataTableHelper.DataTableToList<DocumentoViewModel>(DtDados);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro a busca do Documento\n" + ex.Message);

            }

        }
        public List<DocumentoViewModel> GetDocumentosPor(int codAtendimento, int codItem)
        {
            try
            {
                string SQL = "SELECT Documentos.codigo as Codigo, " +
                            "Documentos.Data as Data," +
                            " Documentos.Hora as Hora," +
                            " Operacoes.Nome as Documento" +
                            ", Areas.descricao as Area, " +
                            "Entidades.Nome AS Entidade, " +
                            "Documentos.Total as Total," +
                            " Documentos.Estado as Estado," +
                            " Usuarios.Nome AS Usuario, " +
                            "Documentos.CodOperacao as Documento," +
                            " Documentos.CodEntidade as CodCliente, " +
                            "Operacoes.MovFin as  MovFinanceiro," +
                            " Operacoes.MovStk as   MovInventario, " +
                            "Documentos.Descritivo as Descritivo," +
                            "MovProdutos.Descricao as NomeItem" +
                    " from Documentos JOIN Operacoes ON " +
                    " Operacoes.codigo = Documentos.CodOperacao " +
                    " JOIN Entidades ON Entidades.Codigo = Documentos.CodEntidade" +
                    " JOIN Usuarios ON Usuarios.codigo = Documentos.CodUsuario " +
                    " JOIN Areas ON Areas.codigo = Documentos.CodArea " +
                    " LEFT JOIN Comissoes ON Comissoes.CodDocumento = Documentos.Codigo " +
                    " LEFT JOIN MovProdutos ON MovProdutos.CodDocumento = Documentos.Codigo " +
                    " WHERE MovProdutos.ArtigoAbstrato LIKE '%?" + codItem + "?" + codAtendimento + "%'";

                //if (!string.IsNullOrEmpty(criterios))
                //{
                //    SQL = SQL + " Where " + criterios;
                //}

                SQL += " Order by Documentos.Codigo desc ";
                var ob = Conexao.ClienteSql.SELECT(SQL);
                DataTable DtDados = (DataTable)ob;
                var result = DataTableHelper.DataTableToList<DocumentoViewModel>(DtDados);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro a busca do Documento\n" + ex.Message);

            }

        }
        public MovProdutosViewModel GetMovProduto(int codItem, int codAtendimento, string descricao)
        {
            return Db.GetEntities<MovProdutosViewModel>(" WHERE MovProdutos.ArtigoAbstrato LIKE '%?" + codItem + "?" + codAtendimento + "%' AND MovProdutos.Descricao = '" + descricao + "'").FirstOrDefault();
        }
        public List<MovProdutosViewModel> GetMovProdutosPor(DateTime dataInicio, DateTime datafim)
        {
            var criterio = " Documentos.Data between '" + dataInicio.ToString("yyyy-MM-dd") + "' and '" + datafim.ToString("yyyy-MM-dd") + "'";
            return Db.GetEntities<MovProdutosViewModel>(" WHERE " + criterio);
        }
        #endregion
    }
}
