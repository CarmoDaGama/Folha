using Folha.Driver.Repository.Data;
using Folha.Domain.Models.Db;
using System;
using System.Data;
using Folha.Domain.Models.Genericos;
using Folha.Domain.Helpers;
using Folha.Domain.Interfaces.Repository.Db;

namespace Folha.Driver.Repository.Db
{
    public  class DbRepository : IDbRepository
    {
        public void ActualizarTabelas()
        {
            new Motor().CriaouActualizaTabelas();
        }

        public void RegistarConexao(ConexaoDTO conexaoDTO)
        {
            Conexao.ClienteSql = new DataBase(conexaoDTO);
        }
        public void SalvarDadosTemporarios(DadosTemporarios dados)
        {
            try
            {
                if (Conexao.ContaRegisto("DadosTemporarios", null) < 1)
                {
                    Conexao.ClienteSql.COMANDO("INSERT INTO DadosTemporarios (Login, Servidor)VALUES('" + dados.Login + "' ,'" + dados.Servidor + "'");
                }
                else
                {
                    Conexao.ClienteSql.COMANDO("UPDATE DadosTemporarios SET Login='" + dados.Login + "' ,Servidor='" + dados.Servidor + "'");
                }
            }
            catch (Exception)
            {
            }
        }
        public DadosTemporarios BuscarDadosTemporarios()
        {
            try
            {
                DataTable tabelaTemporarios = (DataTable)Conexao.ClienteSql.SELECT("SELECT * FROM DadosTemporarios");
                var dados = DataTableHelper.DataTableToList<DadosTemporarios>(tabelaTemporarios);
                if (UtilidadesGenericas.ListaNula(dados))
                {
                    return null;
                }
                return dados[0];

            }
            catch (Exception)
            {
                return null;
            }
        }
        public string TestarConexao()
        {
            try
            {
                string x = Conexao.ClienteSql.TestarConexao();
                if (x.Equals("1")) return ("1");
                else return x;
            }
            catch (Exception x)
            {
                throw new Exception("Houve um erro \n" + x.Message);
            }
        }
        public void actualizarMovProdutos()
        {
            var objData = Conexao.ClienteSql.SELECT("SELECT * FROM ProdutoStock");
            DataTable tabelaStock = (DataTable)objData;
            foreach (DataRow item in tabelaStock.Rows)
            {
                var criterio = "CodProduto ='" + item["CodProduto"] + "' AND CodArmazem = '" + item["CodArmazem"] + "'";
                Conexao.ClienteSql.UPDATE("MovProdutos", new string[] {"CodStock" }, new object[] { item["codigo"] }, criterio);
            }
        }
    }
}
