using MySql.Data.MySqlClient;
using Folha.Domain.Enuns.Genericos;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using Folha.Domain.Models.Db;
using System.IO;

namespace Folha.Driver.Repository.Data
{
    using System.Diagnostics;
    using System.Windows.Forms;
    public class DataBase
    {
        private ETipoBancoDados tipoBanco;
        private string StrConexao;
        private SqlConnection SQL;
        private MySqlConnection MYSQL;

        public string Banco;
        public string Senha;
        public DataBase(ConexaoDTO conexaoDTO)
        {
            switch (conexaoDTO.tipoBancoDados)
            {
                case ETipoBancoDados.MySQL:
                    {
                        StrConexao = "Server=" + conexaoDTO.Servidor + " ;Port=" + conexaoDTO.Porta + ";DataBase='" + conexaoDTO.DataBase + "';uid=" + conexaoDTO.Usuario + ";Pwd=" + conexaoDTO.Senha;
                        tipoBanco = ETipoBancoDados.MySQL;
                        break;
                    }
                case ETipoBancoDados.SQLServer:
                    {
                      StrConexao = "Data Source=" + conexaoDTO.Servidor+ " ;Initial Catalog="+conexaoDTO.DataBase+";User ID="+conexaoDTO.Usuario+"; Password="+conexaoDTO.Senha+"";
                        tipoBanco = ETipoBancoDados.SQLServer;
                        SQL = new SqlConnection(StrConexao);
                        break;
                    }
                    throw new Exception("tipo de banco de dados não reconhecido");
            }
        }

        public string INSERT_GET_CODIGO(string Tabela, string[] Campos, object[] Valores)
        {
            if (Campos.Length != Valores.Length)
            {
                return "Campos e Valores Não Conferem !";
            }

            string[] Parametros = new string[Campos.Length];
            string _Campos = "";

            for (int i = 0; i < Campos.Length; i++)
            {
                if (tipoBanco == ETipoBancoDados.SQLServer) Parametros[i] = "@" + Campos[i];
                else Parametros[i] = "?" + Campos[i] + "";

                _Campos = _Campos + Campos[i];
                if (i < Campos.Length - 1) _Campos = _Campos + ",";
            }

            string _Valores = "";
            for (int i = 0; i < Campos.Length; i++)
            {
                _Valores = _Valores.Trim() + Parametros[i];
                if (i < Campos.Length - 1) _Valores = _Valores + ",";
            }

            string Sql = "INSERT INTO " + Tabela + "(" + _Campos + ")VALUES(" + _Valores + ")";

            try
            {
                AbrirConexao();
                MySqlCommand Cmd2 = new MySqlCommand(Sql, GetConexaoMySQL());
                SqlCommand Cmd = new SqlCommand(Sql, GetConexaoSQL());

                for (int i = 0; i < Campos.Length; i++)
                {

                    if (Valores[i].GetType().ToString() == "System.Drawing.Bitmap" && Valores[i] != null)
                    {
                        Image Imagem;

                        if (Valores[i] != null) Imagem = (System.Drawing.Image)Valores[i];
                        else Imagem = null;

                        MySqlParameter mparam = new MySqlParameter();
                        mparam.ParameterName = Parametros[i];
                        mparam.Value = Folha.Domain.Helpers.Imagens.Imagem_Byte(Imagem);
                        Cmd2.Parameters.Add(mparam);


                        SqlParameter sparam = new SqlParameter();
                        sparam.ParameterName = Parametros[i];
                        sparam.Value = Folha.Domain.Helpers.Imagens.Imagem_Byte(Imagem);
                        Cmd.Parameters.Add(sparam);
                    }
                    else
                    {
                        MySqlParameter mparam = new MySqlParameter();
                        SqlParameter sparam = new SqlParameter();
                        sparam.ParameterName = Parametros[i];
                        sparam.Value = Valores[i];
                        mparam.ParameterName = Parametros[i];
                        mparam.Value = Valores[i];
                        Cmd.Parameters.Add(sparam);
                        Cmd2.Parameters.Add(mparam);
                    }

                }

                var parametros = Cmd.Parameters;

                object Resposta = null;
                if (tipoBanco == ETipoBancoDados.SQLServer) Resposta = Cmd.ExecuteNonQuery();
                if (tipoBanco == ETipoBancoDados.MySQL) Resposta = Cmd2.ExecuteNonQuery();


                DataTable RESULT = CONSULTA_DATATABLE("select max(codigo) from " + Tabela);
                return RESULT.Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                FecharConexao();
            }

        }

        public void INSERT(string Tabela, string[] Campos, object[] Valores)
        {

            if (Campos.Length != Valores.Length)
            {
                throw new Exception("Campos e Valores Não Conferem !");
            }

            string[] Parametros = new string[Campos.Length];
            string _Campos = "";

            for (int i = 0; i < Campos.Length; i++)
            {
                if (tipoBanco == ETipoBancoDados.SQLServer) Parametros[i] = "@" + Campos[i];
                else Parametros[i] = "?" + Campos[i] + "";

                _Campos = _Campos + Campos[i];
                if (i < Campos.Length - 1) _Campos = _Campos + ",";
            }

            string _Valores = "";
            for (int i = 0; i < Campos.Length; i++)
            {
                _Valores = _Valores.Trim() + Parametros[i];
                if (i < Campos.Length - 1) _Valores = _Valores + ",";
            }

            string Sql = "INSERT INTO " + Tabela + "(" + _Campos + ")VALUES(" + _Valores + ")";

            try
            {
                AbrirConexao();
                MySqlCommand Cmd2 = new MySqlCommand(Sql, GetConexaoMySQL());
                SqlCommand Cmd = new SqlCommand(Sql, GetConexaoSQL());

                for (int i = 0; i < Campos.Length; i++)
                {

                    if (Valores[i].GetType().ToString() == "System.Drawing.Bitmap" && Valores[i] != null)
                    {
                        Image Imagem;

                        if (Valores[i] != null) Imagem = (System.Drawing.Image)Valores[i];
                        else Imagem = null;

                        MySqlParameter mparam = new MySqlParameter();
                        mparam.ParameterName = Parametros[i];
                        mparam.Value = Folha.Domain.Helpers.Imagens.Imagem_Byte(Imagem);
                        Cmd2.Parameters.Add(mparam);


                        SqlParameter sparam = new SqlParameter();
                        sparam.ParameterName = Parametros[i];
                        sparam.Value = Folha.Domain.Helpers.Imagens.Imagem_Byte(Imagem);
                        Cmd.Parameters.Add(sparam);
                    }
                    else
                    {
                        MySqlParameter mparam = new MySqlParameter();
                        SqlParameter sparam = new SqlParameter();
                        sparam.ParameterName = Parametros[i];
                        sparam.Value = Valores[i];
                        mparam.ParameterName = Parametros[i];
                        mparam.Value = Valores[i];
                        Cmd.Parameters.Add(sparam);
                        Cmd2.Parameters.Add(mparam);
                    }

                }

                var parametros = Cmd.Parameters;

                object Resposta = null;
                if (tipoBanco == ETipoBancoDados.SQLServer) Resposta = Cmd.ExecuteNonQuery();
                if (tipoBanco == ETipoBancoDados.MySQL) Resposta = Cmd2.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("Erro a Inserir Dados: \n "+ ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        public void UPDATE(string Tabela, string[] Campos, object[] Valores, string[] Criterios)
        {
            if (string.IsNullOrEmpty(Tabela))
            {
                throw new Exception("Não foi informada a Tabela");
            }


            if (Campos.Length != Valores.Length)
            {
                throw new Exception("Campos e Valores Não Conferem !");
            }

            string Criterio = DESFAZ_AND(Criterios);


            string[] Parametros = new string[Campos.Length];
            string Dados = "";

            for (int i = 0; i < Campos.Length; i++)
            {
                if (tipoBanco == ETipoBancoDados.SQLServer) Parametros[i] = "@" + Campos[i];
                else Parametros[i] = "?" + Campos[i] + "";

                if (tipoBanco == ETipoBancoDados.SQLServer) Dados += Campos[i] + "=@" + Campos[i] + ",";
                else Dados += Campos[i] + "=?" + Campos[i] + ",";
            }

            Dados = Folha.Domain.Helpers.Strings.Left(Dados, Dados.Length - 1);
            string Sql = "UPDATE " + Tabela + " SET " + Dados + " WHERE " + Criterio;

            try
            {
                AbrirConexao();
                MySqlCommand Cmd2 = new MySqlCommand(Sql, GetConexaoMySQL());
                SqlCommand Cmd = new SqlCommand(Sql, GetConexaoSQL());

                for (int i = 0; i < Campos.Length; i++)
                {

                    if (Valores[i].GetType().ToString() == "System.Drawing.Bitmap" && Valores[i] != null)
                    {
                        Image Imagem;

                        if (Valores[i] != null) Imagem = (System.Drawing.Image)Valores[i];
                        else Imagem = null;

                        MySqlParameter mparam = new MySqlParameter();
                        mparam.ParameterName = Parametros[i];
                        mparam.Value = Folha.Domain.Helpers.Imagens.Imagem_Byte(Imagem);
                        Cmd2.Parameters.Add(mparam);


                        SqlParameter sparam = new SqlParameter();
                        sparam.ParameterName = Parametros[i];
                        sparam.Value = Folha.Domain.Helpers.Imagens.Imagem_Byte(Imagem);
                        Cmd.Parameters.Add(sparam);
                    }
                    else
                    {
                        MySqlParameter mparam = new MySqlParameter();
                        SqlParameter sparam = new SqlParameter();
                        sparam.ParameterName = Parametros[i];
                        sparam.Value = Valores[i];
                        mparam.ParameterName = Parametros[i];
                        mparam.Value = Valores[i];
                        Cmd.Parameters.Add(sparam);
                        Cmd2.Parameters.Add(mparam);
                    }

                }

                var parametros = Cmd2.Parameters;
                object Resposta = null;

                if (tipoBanco == ETipoBancoDados.SQLServer) Resposta = Cmd.ExecuteNonQuery();
                if (tipoBanco == ETipoBancoDados.MySQL) Resposta = Cmd2.ExecuteNonQuery();

                //return Resposta.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro do Servidor: " + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        public void UPDATE(string Tabela, string[] Campos, object[] Valores, string Criterios)
        {

            if (string.IsNullOrEmpty(Tabela))
            {
                throw new Exception("Não foi informada a Tabela");
            }

            if (Campos.Length != Valores.Length)
            {
                throw new Exception("Campos e Valores Não Conferem !");
            }

            string[] Parametros = new string[Campos.Length];
            string Dados = "";

            for (int i = 0; i < Campos.Length; i++)
            {
                if (tipoBanco == ETipoBancoDados.SQLServer) Parametros[i] = "@" + Campos[i];
                else Parametros[i] = "?" + Campos[i] + "";

                if (tipoBanco == ETipoBancoDados.SQLServer) Dados += Campos[i] + "=@" + Campos[i] + ",";
                else Dados += Campos[i] + "=?" + Campos[i] + ",";
            }

            string Sql;
            Dados = Folha.Domain.Helpers.Strings.Left(Dados, Dados.Length - 1);
            if (string.IsNullOrEmpty(Criterios))
            {
                Sql = "UPDATE " + Tabela + " SET " + Dados;
            }
            else
            {
                Sql = "UPDATE " + Tabela + " SET " + Dados + " WHERE " + Criterios;
            }

                try
            {
                AbrirConexao();
                MySqlCommand Cmd2 = new MySqlCommand(Sql, GetConexaoMySQL());
                SqlCommand Cmd = new SqlCommand(Sql, GetConexaoSQL());

                for (int i = 0; i < Campos.Length; i++)
                {

                    if (Valores[i].GetType().ToString() == "System.Drawing.Bitmap" && Valores[i] != null)
                    {
                        Image Imagem;

                        if (Valores[i] != null) Imagem = (System.Drawing.Image)Valores[i];
                        else Imagem = null;

                        MySqlParameter mparam = new MySqlParameter();
                        mparam.ParameterName = Parametros[i];
                        mparam.Value = Folha.Domain.Helpers.Imagens.Imagem_Byte(Imagem);
                        Cmd2.Parameters.Add(mparam);


                        SqlParameter sparam = new SqlParameter();
                        sparam.ParameterName = Parametros[i];
                        sparam.Value = Folha.Domain.Helpers.Imagens.Imagem_Byte(Imagem);
                        Cmd.Parameters.Add(sparam);
                    }
                    else
                    {
                        MySqlParameter mparam = new MySqlParameter();
                        SqlParameter sparam = new SqlParameter();
                        sparam.ParameterName = Parametros[i];
                        sparam.Value = Valores[i];
                        mparam.ParameterName = Parametros[i];
                        mparam.Value = Valores[i];
                        Cmd.Parameters.Add(sparam);
                        Cmd2.Parameters.Add(mparam);
                    }

                }

                var parametros = Cmd.Parameters;

                object Resposta = null;
                if (tipoBanco == ETipoBancoDados.SQLServer) Resposta = Cmd.ExecuteNonQuery();
                if (tipoBanco == ETipoBancoDados.MySQL) Resposta = Cmd2.ExecuteNonQuery();

                //return Resposta.ToString();

            }
            catch (Exception ex)
            {
                throw new Exception("Erro a Inserir Dados: \n " + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        public string COMANDO(string SQL)
        {
            try
            {
                AbrirConexao();
                MySqlCommand Cmd2 = new MySqlCommand(SQL, GetConexaoMySQL());
                SqlCommand Cmd = new SqlCommand(SQL, GetConexaoSQL());

                object Resultado = null;
                if (tipoBanco == ETipoBancoDados.MySQL) Resultado = Cmd2.ExecuteNonQuery();
                if (tipoBanco == ETipoBancoDados.SQLServer) Resultado = Cmd.ExecuteNonQuery();

                return Resultado.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro do Servidor: " + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }
        
        public DataTable SELECT(string[] Tabelas, string[] Campos, string[] Criterios)
        {

            string _Campos = DesfazVector(Campos);
            string _Criterios = null;
            string _Tabelas = DesfazVector(Tabelas);

            string Sql = "SELECT " + _Campos;
            Sql = Sql + " FROM " + _Tabelas;

            if (Criterios != null && Criterios.Length > 0)
            {
                _Criterios = ADICIONAAND(Criterios);
                Sql = Sql + " WHERE " + _Criterios;
            }

            //MessageBox.Show(Sql.ToString());
            //return Sql;
            try
            {
                AbrirConexao();

                DataTable DtDados = new DataTable();
                if (tipoBanco == ETipoBancoDados.MySQL)
                {
                    using (MySqlDataAdapter sda = new MySqlDataAdapter(Sql, GetConexaoMySQL()))
                    {
                        sda.SelectCommand.CommandType = CommandType.Text;

                        sda.Fill(DtDados);
                    }
                }
                if (tipoBanco == ETipoBancoDados.SQLServer)
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(Sql, GetConexaoSQL()))
                    {
                        sda.SelectCommand.CommandType = CommandType.Text;

                        sda.Fill(DtDados);
                    }
                }
                return DtDados;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        public Object SELECT(String Sql)
        {
            try
            {
                AbrirConexao();

                DataTable DtDados = new DataTable();
                if (tipoBanco == ETipoBancoDados.MySQL)
                {
                    using (MySqlDataAdapter sda = new MySqlDataAdapter(Sql, GetConexaoMySQL()))
                    {
                        sda.SelectCommand.CommandType = CommandType.Text;

                        sda.Fill(DtDados);
                    }
                }
                if (tipoBanco == ETipoBancoDados.SQLServer)
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(Sql, GetConexaoSQL()))
                    {
                        sda.SelectCommand.CommandType = CommandType.Text;

                        sda.Fill(DtDados);
                    }
                }



                return DtDados;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                FecharConexao();
            }
        }



        private string DESFAZ_INNER(string[] InnerJoin)
        {
            string Resultado = null;

            for (int i = 0; i < InnerJoin.Length; i++)
            {
                Resultado = Resultado + " INNER JOIN " + InnerJoin[i];
                //if (i < InnerJoin.Length - 1) Resultado = Resultado + ",";
            }

            return Resultado;
        }

        private string DESFAZ_AND(string[] CRITERIOS)
        {
            string Resultado = null;

            for (int i = 0; i < CRITERIOS.Length; i++)
            {
                Resultado = Resultado + CRITERIOS[i];
                if (i < CRITERIOS.Length - 1) Resultado = Resultado + " AND ";
            }

            return Resultado;
        }

        private string DESFAZ_LEFT(string[] InnerJoin)
        {
            string Resultado = null;

            for (int i = 0; i < InnerJoin.Length; i++)
            {
                Resultado = Resultado + " LEFT OUTER JOIN " + InnerJoin[i];
                //if (i < InnerJoin.Length - 1) Resultado = Resultado + ",";
            }

            return Resultado;
        }

        public Object INNERJOIN(string Tabela_Mae, string[] Campos, string[] InnerJoin, string[] Crit)
        {
            // string _Tabelas = DesfazVector(Tabelas);
            string _Campos = DesfazVector(Campos);
            string _LeftJoin = null;
            string Criterios = null;

            string Sql = "SELECT " + _Campos;
            Sql = Sql + " FROM " + Tabela_Mae;

            if (InnerJoin != null && InnerJoin.Length > 0)
            {
                _LeftJoin = DESFAZ_INNER(InnerJoin);
                Sql = Sql + _LeftJoin;
            }

            if (Crit != null && Crit.Length > 0)
            {
                Criterios = ADICIONAAND(Crit);
                Sql = Sql + " WHERE " + Criterios;
            }

            try
            {
                AbrirConexao();


                DataTable DtDados = new DataTable();
                if (tipoBanco == ETipoBancoDados.MySQL)
                {
                    using (MySqlDataAdapter sda = new MySqlDataAdapter(Sql, GetConexaoMySQL()))
                    {
                        sda.SelectCommand.CommandType = CommandType.Text;

                        sda.Fill(DtDados);
                    }
                }
                if (tipoBanco == ETipoBancoDados.SQLServer)
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(Sql, GetConexaoSQL()))
                    {
                        sda.SelectCommand.CommandType = CommandType.Text;

                        sda.Fill(DtDados);
                    }
                }

                return DtDados;
            }
            catch (Exception ex)
            {
                return "Erro de Inner Join :\n" + ex.Message;
            }
            finally
            {
                FecharConexao();
            }
        }
        public Object LEFTJOIN(string Tabela_Mae, string[] Campos, string[] LeftJoin, string[] Crit)
        {
            // string _Tabelas = DesfazVector(Tabelas);
            string _Campos = DesfazVector(Campos);
            string _LeftJoin = null;
            string Criterios = null;

            string Sql = "SELECT " + _Campos;
            Sql = Sql + " FROM " + Tabela_Mae;

            if (LeftJoin != null && LeftJoin.Length > 0)
            {
                _LeftJoin = DESFAZ_LEFT(LeftJoin);
                Sql = Sql + _LeftJoin;
            }

            if (Crit != null && Crit.Length > 0)
            {
                Criterios = ADICIONAAND(Crit);
                Sql = Sql + " WHERE " + Criterios;
            }

            try
            {
                AbrirConexao();

                DataTable DtDados = new DataTable();

                if (tipoBanco == ETipoBancoDados.MySQL)
                {
                    using (MySqlDataAdapter sda = new MySqlDataAdapter(Sql, GetConexaoMySQL()))
                    {
                        sda.SelectCommand.CommandType = CommandType.Text;

                        sda.Fill(DtDados);
                    }
                }
                if (tipoBanco == ETipoBancoDados.SQLServer)
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(Sql, GetConexaoSQL()))
                    {
                        sda.SelectCommand.CommandType = CommandType.Text;

                        sda.Fill(DtDados);
                    }
                }
                return DtDados;


            }
            catch (Exception ex)
            {
                //MessageBox.Show("Erro do Left Join :\n" + ex.Message);
                return "Erro do Left Join :\n" + ex.Message;
            }
            finally
            {
                FecharConexao();
            }
        }

        private string DesfazVector(String[] Vector)
        {
            string Resultado = null;

            for (int i = 0; i < Vector.Length; i++)
            {
                Resultado = Resultado + Vector[i];
                if (i < Vector.Length - 1) Resultado = Resultado + ",";
            }

            return Resultado;
        }

        private string ADICIONAAND(String[] Vector)
        {
            string Resultado = null;

            for (int i = 0; i < Vector.Length; i++)
            {
                Resultado = Resultado + Vector[i];
                if (i < Vector.Length - 1) Resultado = Resultado + " AND ";
            }

            return Resultado;
        }

        public String TestarConexao()
        {
            string Resposta = null;
            try
            {
                return AbrirConexao();
            }
            catch (Exception x)
            {
                Resposta = x.Message.ToString();
                return Resposta;
            }
        }

        private string ADICIONA_CAMPO(string NomeTabela, string Campo)
        {
            string Sql = null;
            AbrirConexao();
            MySqlCommand Cmd2 = new MySqlCommand(); ;
            SqlCommand Cmd = new SqlCommand();

            if (tipoBanco == ETipoBancoDados.MySQL) Cmd2 = new MySqlCommand(Sql, GetConexaoMySQL());
            if (tipoBanco == ETipoBancoDados.SQLServer) Cmd = new SqlCommand(Sql, GetConexaoSQL());

            try
            {
                Sql = "ALTER TABLE " + NomeTabela + " ADD " + Campo;

                if (NomeTabela.ToUpper().Trim() == "DEFGERAL")
                {
                    var k = NomeTabela;
                }
                if (tipoBanco == ETipoBancoDados.SQLServer)
                {
                    Sql = Sql.Replace("?", "@");
                    Sql = Sql.Replace("longBlob", "Image");
                    Sql = Sql.Replace("auto_increment", "identity");
                    Sql = Sql.Replace("int(11)", "int");
                }

                Cmd.CommandText = Sql;
                Cmd2.CommandText = Sql;
                if (tipoBanco == ETipoBancoDados.SQLServer)
                {

                    var resp = Cmd.ExecuteNonQuery().ToString();
                    return resp;
                }
                else
                {

                    var resp = Cmd2.ExecuteNonQuery().ToString();
                    return resp;
                }

            }
            catch (Exception ex)
            {
                return ex.Message;

            }
            finally
            {
                FecharConexao();
            }
        }

        public void ADICIONA_CAMPOS(string NomeTabela, string[] Campos)
        {
            for (int i = 0; i < Campos.Length; i++)
            {
                string resp = ADICIONA_CAMPO(NomeTabela, Campos[i]);

            }

        }

        public string CREATE_TABLE(string NomeTabela, string[] Campos, string Chave)
        {
            string campos = DesfazVector(Campos);           

            string Sql = "Create table " + NomeTabela + "(" + Chave + "," + campos;
            Sql = Sql + ")";
            if (tipoBanco == ETipoBancoDados.SQLServer)
            {
                Sql = Sql.Replace("longBlob", "Image");
                Sql = Sql.Replace("LongBlob", "Image");
                Sql = Sql.Replace("auto_increment", "identity");
                Sql = Sql.Replace("int(11)", "int");
            }

            string zx = Sql;

            if (tipoBanco == ETipoBancoDados.MySQL) Sql += "ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8;";

            //MessageBox.Show(Sql);
            try
            {

                AbrirConexao();
                MySqlCommand Cmd2 = new MySqlCommand(Sql, GetConexaoMySQL());
                SqlCommand Cmd = new SqlCommand(Sql, GetConexaoSQL());


                object x = null;
                if (tipoBanco == ETipoBancoDados.SQLServer) x = Cmd.ExecuteNonQuery();
                if (tipoBanco == ETipoBancoDados.MySQL) x = Cmd2.ExecuteNonQuery();

                FecharConexao();
                return x.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                FecharConexao();
            }


        }

        public string DELETE(String Tabela, String Criterio_Unico)
        {
            DataTable DtDados = new DataTable();
            String Sql = "DELETE FROM " + Tabela + " WHERE " + Criterio_Unico;

            try
            {
                AbrirConexao();
                object Res = null;
                MySqlCommand Cmd2 = new MySqlCommand(Sql, GetConexaoMySQL());
                SqlCommand Cmd = new SqlCommand(Sql, GetConexaoSQL());

                if (tipoBanco == ETipoBancoDados.SQLServer) Res = Cmd.ExecuteNonQuery();
                if (tipoBanco == ETipoBancoDados.MySQL) Res = Cmd2.ExecuteNonQuery();
                return Res.ToString();
            }
            catch (Exception ex)
            {
                return "Erro :" + ex.Message;
            }
            finally
            {
                FecharConexao();
            }
        }

        public string ADD_CAMPO(string Tabela, string Campos)
        {
            string Sql = "Alter table " + Tabela + " ADD " + Campos;
            if (tipoBanco == ETipoBancoDados.SQLServer)
            {
                Sql = Sql.Replace("longBlob", "Image");
                Sql = Sql.Replace("auto_increment", "identity");
                Sql = Sql.Replace("int(11)", "int");
            }
            try
            {
                AbrirConexao();
                MySqlCommand Cmd2 = new MySqlCommand(Sql, GetConexaoMySQL());
                SqlCommand Cmd = new SqlCommand(Sql, GetConexaoSQL());
                Cmd.CommandText = Sql;
                Cmd2.CommandText = Sql;
                if (tipoBanco == ETipoBancoDados.SQLServer) Cmd.ExecuteNonQuery();
                if (tipoBanco == ETipoBancoDados.MySQL) Cmd2.ExecuteNonQuery();
                string txt = "\n1; Sucesso ao adicionar campo a tabela " + Tabela + "\n. Campo: " + Campos;
                return txt;
            }

            catch (MySqlException er)
            {
                string txt = "\n0; Erro ao adicionar campo a tabela " + Tabela + "\n. Campo: " + Campos + "\n. Erro: " + er.Message;
                return txt;
            }
            finally
            {
                FecharConexao();
            }
        }

        public string ADD_CAMPOS(string Tabela, string[] Campos)
        {
            if (Campos == null) return null;
            for (int i = 0; i < Campos.Length; i++)
            {
                ADD_CAMPO(Tabela, Campos[i]);
            }
            return "";
        }

        public void ELIMINAREGISTO(string Tabela, int Codigo)
        {
            try
            {
                AbrirConexao();
                string MSQL = "DELETE FROM " + Tabela + " where Codigo=?Codigo";
                string SSQL = "DELETE FROM " + Tabela + " where Codigo=@Codigo";

                MySqlCommand Cmd2 = new MySqlCommand(MSQL, GetConexaoMySQL());
                SqlCommand Cmd = new SqlCommand(SSQL, GetConexaoSQL());

                Cmd2.Parameters.AddWithValue("?Codigo", Codigo);
                Cmd.Parameters.AddWithValue("@Codigo", Codigo);

                if (tipoBanco == ETipoBancoDados.SQLServer) Cmd.ExecuteNonQuery();
                if (tipoBanco == ETipoBancoDados.MySQL) Cmd2.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao Actualizar Usuario: \n" + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        public DataTable CONSULTA_DATATABLE(string Sql)
        {
            DataTable DtDados = new DataTable();
            try
            {
                AbrirConexao();

                if (tipoBanco == ETipoBancoDados.MySQL)
                {
                    using (MySqlDataAdapter sda = new MySqlDataAdapter(Sql, GetConexaoMySQL()))
                    {
                        sda.SelectCommand.CommandType = CommandType.Text;

                        sda.Fill(DtDados);
                    }
                }
                if (tipoBanco == ETipoBancoDados.SQLServer)
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(Sql, GetConexaoSQL()))
                    {
                        sda.SelectCommand.CommandType = CommandType.Text;

                        sda.Fill(DtDados);
                    }
                }

                return DtDados;
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao Pesquisar Consulta: \n" + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }
        public string ContaRegistos(string Sql)
        {
            DataTable DtDados = new DataTable();
            try
            {
                AbrirConexao();
                if (tipoBanco == ETipoBancoDados.MySQL)
                {
                    using (MySqlDataAdapter sda = new MySqlDataAdapter(Sql, GetConexaoMySQL()))
                    {
                        sda.SelectCommand.CommandType = CommandType.Text;

                        sda.Fill(DtDados);
                    }
                }
                if (tipoBanco == ETipoBancoDados.SQLServer)
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(Sql, GetConexaoSQL()))
                    {
                        sda.SelectCommand.CommandType = CommandType.Text;

                        sda.Fill(DtDados);
                    }
                }
            }
            catch (Exception ex)
            {

                return "Erro: \n" + ex.Message;
            }
            finally
            {
                FecharConexao();
            }

            return DtDados.Rows.Count.ToString();
        }


        public SqlConnection GetConexaoSQL()
        {
            return SQL;
        }

        public MySqlConnection GetConexaoMySQL()
        {
            return MYSQL;
        }

        private string AbrirConexao()
        {
            try
            {
                if (tipoBanco == ETipoBancoDados.MySQL)
                {
                    MYSQL = new MySqlConnection(StrConexao);
                    if (MYSQL.State == ConnectionState.Closed)
                    {
                        MYSQL.Open();
                        return "1";
                    }
                    else
                    {
                        FecharConexao();
                        MYSQL.Open();
                    }
                }

                if (tipoBanco == ETipoBancoDados.SQLServer)
                {
                    try
                    {
                        SQL = new SqlConnection(StrConexao);
                        if (SQL.State == ConnectionState.Closed)
                        {
                            SQL.Open();
                            return "1";
                        }
                        else
                        {
                            FecharConexao();
                            SQL.Open();
                        }

                    }
                    catch (Exception ex)
                    {
                        return ex.Message;
                    }
                }


            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return null;

        }

        private string FecharConexao()
        {
            try
            {
                if (tipoBanco == ETipoBancoDados.MySQL)
                {
                    if (MYSQL.State == ConnectionState.Open)
                    {
                        MYSQL.Close();
                        return "1";
                    }
                }

                if (tipoBanco == ETipoBancoDados.SQLServer)
                {
                    if (SQL.State == ConnectionState.Open)
                    {
                        SQL.Close();
                        return "1";
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return null;
        }

        #region BACKUP

        private string GetNomeFileBackup()
        {
            var nome = "backup";
            var data = DateTime.Now.ToString("yyyy-MM-ddThh").Replace("-", "_").Replace(":", string.Empty);
            return nome + data;
        }
        public string GerarBackup(string dados)
        {
            //TODO: Implementar metodo GERARBACKUP 
            /*
                Comando para gerar backup: mysqldump -u root -p FolhaERP > C:\Users\TestBACKUP\backup.sql
                Comando para restaurar backup: mysql -u root -p FolhaRest < C:\Users\TestBACKUP\backup.sql
            */
            /**string caminho = Application.StartupPath + "\\Folha_Backup";
            if (!Directory.Exists(caminho))
            {
                Directory.CreateDirectory(caminho);
            }

            string hashNameFile = GetNomeFileBackup();
            string file = caminho + "\\" + hashNameFile + ".sql";

            // ======================= Criar o ficheiro ==========================================
            // ======================= End Criar o ficheiro ==========================================
            string executavelSSL = "\"" + Application.StartupPath + "\\OpenSSL-Win64\\bin\\openssl.exe\"";
            if (!File.Exists(Application.StartupPath + "\\OpenSSL-Win64\\bin\\openssl.exe"))
            {
                executavelSSL = "\"C:\\Program Files\\OpenSSL-Win64\\bin\\openssl.exe\"";
            }
            // ---------------------------------- CMD Proccess --------------------------------------------------------------------
            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true; // Não preciso
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();

            cmd.StandardInput.WriteLine("cd " + caminho); // Recebe o caminho da pasta criada em documentos para que toda operação seja feita lá
            cmd.StandardInput.WriteLine(executavelSSL + " dgst -sha1 -sign Key_Private.pem -out " + hashNameFile + ".sha1 " + hashNameFile + ".txt");
            cmd.StandardInput.WriteLine(executavelSSL + " enc -base64 -in " + hashNameFile + ".sha1 -out " + hashNameFile + ".b64 -A");
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();
            // ---------------------------------- END CMD Proccess --------------------------------------------------------------------

            StreamReader readH = File.OpenText(fileResulHash);

            string hashGerada = readH.ReadToEnd();
            readH.Close();
            EliminarFicheirosHash(caminho + "\\" + hashNameFile);
            return hashGerada;*/
            return string.Empty;
        }
        #endregion
    }
}
