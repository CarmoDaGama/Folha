using System;
using Folha.Domain.Enuns.Genericos;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Folha.Domain.Models.Db;

namespace Folha.Driver.Repository.Data
{
    public class Conexao
    {
        public static DataBase ClienteSql;

        public static int VersaoBd = 2;
        public static int ContaChaves;
        public static int ContaTabelas;

        public static Object UsuarioCodigo = "";
        //public static int UsuarioCodigo ;

        public static bool AProcessar = true;
        public static class MoedaPadrao
        {
            public static String Codigo = null;
            public static String Descricao = null;
            public static String Sigla = null;
        }
        public static class Busca
        {

            //variaveis Global
            public static bool Alterou { get; set; }
          
        }

        //milton

        public void DiminuirStock(Object codigoProduto, Object armaz, Double qtde)
        {
            //try
            //{
                string SQL = "SELECT ProdutoStock.qtde FROM Produtos INNER JOIN ProdutoStock ON Produtos.Codigo = ProdutoStock.CodProduto WHERE Produtos.Codigo = '" + codigoProduto + "' AND ProdutoStock.CodArmazem = '" + armaz + "' OR ProdutoStock.CodArmazem = '" + armaz + "' AND Produtos.Barra LIKE '" + codigoProduto + "'";
                Object obj = ClienteSql.SELECT(SQL);

                DataTable dt = (DataTable)obj;
                double stAntigo = double.Parse(dt.Rows[0][0].ToString());

                double Total = stAntigo - qtde;


                string[] camposs = { "qtde" };
                string[] criterios = { "CodArmazem = " + armaz, "CodProduto = '" + codigoProduto + "'" };
                Object[] valoress = { Total };
                /*string ob =*/ ClienteSql.UPDATE("ProdutoStock", camposs, valoress, criterios);



            //}
            //catch (Exception ex)
            //{
            //    return;
            //}

        }




        public static bool IsNumeric(string num)
        {
            try
            {
                double x = Convert.ToDouble(num);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static int BuscarOrdemDocumento(int CodOperacao)
        {
            int Ordem = 1;
            try
            {
                DataTable dtOrdem = Conexao.BuscarTabela_com_Criterio("Documentos", "CodOperacao='" + CodOperacao + "' order by Codigo desc");
                if (dtOrdem.Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(dtOrdem.Rows[0]["NumeroOrdem"].ToString()))
                    {
                        Ordem = int.Parse(dtOrdem.Rows[0]["NumeroOrdem"].ToString()) + 1;
                    }
                }
            }
            catch { }
            return Ordem;
        }

        public Conexao(ConexaoDTO conexaoDTO)
        {
            ClienteSql = new DataBase(conexaoDTO);
        }

        public static int ContaRegisto(String Tabela, string criterio)
        {
            int Result = 0;
            string[] campos;
                campos = new string[1] { "Codigo" };

            if(Tabela=="DiasSemana")
                campos = new string[1] { "IDDias" };

            if (Tabela == "Turno")
                campos = new string[1] { "IDTurno" };

            if (Tabela == "TurnoDias")
                campos = new string[1] { "IDTurnoDias" };

            string[] tabelas = { Tabela };
            string[] Criterios = { criterio };
            Object ob;

            if (criterio == null)
                ob = ClienteSql.SELECT(tabelas, campos, null);
            else
                ob = ClienteSql.SELECT(tabelas, campos, Criterios);
            try
            {
                DataTable dt = (DataTable)ob;
                Result = dt.Rows.Count;
            }
            catch (Exception) { }

            return Result;
        }

        public static DataTable BuscarTabela(string Tabela)
        {
            DataTable DtDados = new DataTable();
            Object ob = ClienteSql.SELECT("SELECT * FROM " + Tabela);
            try
            {
                DtDados = (DataTable)ob;
            }
            catch (Exception a)
            {
                throw new Exception(a.Message);
            }
            return DtDados;
        }

        public static DataTable BuscarTabela_com_Criterio(string Tabela, string criterios)
        {
            DataTable DtDados = new DataTable();
            Object ob = null;

            try
            {
                ob = ClienteSql.SELECT("SELECT*FROM " + Tabela + " WHERE " + criterios);
                if (ob.GetType() == typeof(string))
                {
                    throw new Exception("Houve um erro a processar o pedido " + ob.ToString());
                }
                DtDados = (DataTable)ob;
                return DtDados;
            }
            catch (Exception a)
            {
                throw new Exception(a.Message);
            }
        }

        public static DataTable BuscarDataTable(String Tabela, String[] Campos, String Criterio)
        {
            DataTable DtDados = new DataTable();


            string[] tabelas = { Tabela };
            String[] Criterios = { Criterio };
            Object ob;

            if (Criterio != null)
                ob = ClienteSql.SELECT(tabelas, Campos, Criterios);
            else
                ob = ClienteSql.SELECT(tabelas, Campos, null);

            try
            {
                if (ob.GetType() == typeof(string))
                {
                    throw new Exception("Houve um erro \n" + ob.ToString());
                }

                DtDados = (DataTable)ob;
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro \n" + ex.Message);
            }

            return DtDados;
        }

        public static DataTable BuscarCodigoeDescricao(String Tabela)
        {
            DataTable DtDados = new DataTable();
            string[] tabelas = { Tabela };
            string[] campos = { "Codigo", "Descricao" };

            Object ob = ClienteSql.SELECT(tabelas, campos, null);
            try
            {
                DtDados = (DataTable)ob;
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro a carregar dados " + ex.Message);

            }

            return DtDados;
        }

        public static String BuscarDescricaoPorCodigo(String Tabela, String Codigo)
        {
            DataTable DtDados = new DataTable();
            string[] tabelas = { Tabela };
            string[] campos = { "Codigo", "Descricao" };
            string[] criterios = { "Codigo='" + int.Parse(Codigo) + "'" };
            Object ob = ClienteSql.SELECT(tabelas, campos, criterios);
            try
            {
                DtDados = (DataTable)ob;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro a Carregar Dados na Tabea \n" + Tabela + "\n" + ex.Message);

            }
            return DtDados.Rows[0][1].ToString();
        }

        public static String BuscarCodigoPorDescricao(String Tabela, String Descricao)
        {
            DataTable DtDados = new DataTable();
            string[] tabelas = { Tabela };
            string[] campos = { "Codigo", "Descricao" };
            string[] criterios = { "Descricao like '" + Descricao + "'" };
            Object ob = ClienteSql.SELECT(tabelas, campos, criterios);
            try
            {
                DtDados = (DataTable)ob;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro a Carregar Dados na Tabea \n" + Tabela + "\n" + ex.Message);

            }
           return DtDados.Rows[0][0].ToString();
        }

        public static bool VerificarRegisto(String Tabela, String Campo, String ParametroBusca)
        {
            DataTable DtDados = new DataTable();
            string[] tabelas = { Tabela };
            string[] campos = { Campo };
            string[] criterios = { Campo+" = '" + ParametroBusca + "'" };
            Object ob = ClienteSql.SELECT(tabelas, campos, criterios);
            try
            {
                DtDados = (DataTable)ob;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro a Carregar Dados na Tabela \n" + Tabela + "\n" + ex.Message);

            }

            if (DtDados.Rows.Count > 0) return true;
            else
            return false;
        }

        public static int BuscarCodigo(String Tabela, String Campo, String ParametroBusca)
        {
            DataTable DtDados = new DataTable();
            string SQL = "SELECT * FROM " + Tabela + " WHERE " + Campo + " = '" + ParametroBusca + "'";
            Object ob = ClienteSql.SELECT(SQL);
            try
            {
                DtDados = (DataTable)ob;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro a Carregar Dados na Tabela \n" + Tabela + "\n" + ex.Message);

            }

            if (DtDados.Rows.Count == 1) return int.Parse( DtDados.Rows[0][0].ToString());
            else
                return 0;
        }

        public static int LastCodGeral(String Tabela)
        {
            DataTable DtDados = new DataTable();
            string SQL = "SELECT * FROM " + Tabela;
            Object ob = ClienteSql.SELECT(SQL);
            try
            {
                DtDados = (DataTable)ob;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro a Carregar Dados na Tabela \n" + Tabela + "\n" + ex.Message);

            }

            if (DtDados.Rows.Count > 0) return int.Parse(DtDados.Rows[DtDados.Rows.Count-1][0].ToString());
            else
                return 0;
        }
    }
}
