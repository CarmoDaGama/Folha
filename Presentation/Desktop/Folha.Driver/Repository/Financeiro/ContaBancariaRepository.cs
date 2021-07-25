using System;
using System.Data;
using System.Collections.Generic;
using Folha.Driver.Repository;
using Folha.Domain.Models.Db;
using Folha.Domain.Interfaces.Repository.Financeiro;
using Folha.Domain.Models.Financeiro;
using System.Linq;
using Folha.Domain.Helpers;
using Folha.Domain.ViewModels.Financeiro;
using Folha.Domain.ViewModels.Report;

namespace Folha.Driver.Repository.Data.Repositories.Financeiro
{
    public class ContaBancariaRepository : RepositoryBase<DbDTO>, IContaBancariaRepository
    {
        public IEnumerable<ContasBancarias> ContasBancariasAcessoPorUsuario(Guid usuarioID, bool admin)
        {
            List<ContasBancarias> result = new List<ContasBancarias>();
            DataTable DtCaixas = new DataTable();
            if (admin)
            {
                string SQL = "SELECT ContasBancarias.Codigo,ContasBancarias.Numero, Bancos.Descricao as Banco from ContaBancaria,AcessoContas,Bancos WHERE ";
                SQL += "ContasBancarias.Codigo=AcessoContas.CodContaBancaria And Bancos.Codigo=ContasBancarias.CodBanco And AcessoContas.CodUsuario='" + usuarioID.ToString() + "'";

                object x = Conexao.ClienteSql.SELECT(SQL);

                DtCaixas = (DataTable)x;
            }
            else
            {
                string SQL = "SELECT ContasBancarias.Codigo,ContasBancarias.Numero, Bancos.Descricao as Banco ";
                SQL += "From ContasBancarias,Bancos WHERE ContasBancarias.CodBanco=Bancos.Codigo";
                object x = Conexao.ClienteSql.SELECT(SQL);
                DtCaixas = (DataTable)x;
            }

            for(int i=0; i<DtCaixas.Rows.Count; i++)
            {

            }

            return result;
        }
        public IEnumerable<MostraContasViewModel> Minhas_ContasBancarias()
        {
            DataTable DtConta = new DataTable();
            if (int.Parse(UtilidadesGenericas.UsuarioCodigo.ToString()) > 1)
            {
                string SQL = "SELECT ContasBancarias.Codigo,ContasBancarias.Numero, Bancos.Descricao as BancoDescricao from ContasBancarias,AcessoContas,Bancos WHERE ";
                SQL += "ContasBancarias.Codigo=AcessoContas.CodContaBancaria And Bancos.Codigo=ContasBancarias.CodBanco And AcessoContas.CodUsuario='" + UtilidadesGenericas.UsuarioCodigo.ToString() + "'";

                object x = Conexao.ClienteSql.SELECT(SQL);
                DtConta = (DataTable)x;
                var conta = DataTableHelper.DataTableToList<MostraContasViewModel>(DtConta);
                return conta;
            }
            else
            {
                string SQL = "SELECT ContasBancarias.Codigo,ContasBancarias.Numero, Bancos.Descricao as BancoDescricao ";
                SQL += "From ContasBancarias,Bancos WHERE ContasBancarias.CodBanco=Bancos.Codigo";
                object x = Conexao.ClienteSql.SELECT(SQL);
                DtConta = (DataTable)x;
                var conta = DataTableHelper.DataTableToList<MostraContasViewModel>(DtConta);
                return conta;
            }
     
        }

        public double buscarSaldoBanco(int CodBanco)
        {

            try
            {
                DataTable dtPagamento = Conexao.BuscarTabela_com_Criterio("Pagamentos", "CodConta='" + CodBanco + "'");
                double credito = 0;
                double debido = 0;

                for (int i = 0; i < dtPagamento.Rows.Count; i++)
                {

                    if (dtPagamento.Rows[i]["Tipo"].ToString() == "CREDITO")
                    {
                        credito = credito + double.Parse(dtPagamento.Rows[i]["Valor"].ToString());
                    }
                    else
                    {
                        debido = debido + double.Parse(dtPagamento.Rows[i]["Valor"].ToString());
                    }
                }

                double Saldo = credito - debido;

                return Saldo;

            }
            catch (Exception)
            {
                return 0;
            }

        }

        public DataViewModel RetortaDataSaldoConta()
        {
            string SQL = "select Min([Data]) as DataInicial,Max([Data]) as DataFinal from Pagamentos WHERE CodConta>=1";
            string dtInicial = null;
            string dtFinal = null;
            DataViewModel result;
            var obj = Conexao.ClienteSql.SELECT(SQL);
            DataTable dtPagamento = (DataTable)obj;

            if (dtPagamento.Rows.Count > 0)
            {
                dtInicial = dtPagamento.Rows[0]["DataInicial"].ToString();
                dtFinal = dtPagamento.Rows[0]["DataFinal"].ToString();
            }
            if (!string.IsNullOrEmpty(dtInicial) && !string.IsNullOrEmpty(dtFinal))
            {
                result = new DataViewModel() { DataInicial = Convert.ToDateTime(dtPagamento.Rows[0]["DataInicial"]), DataFinal = Convert.ToDateTime(dtPagamento.Rows[0]["DataFinal"]) };
                return result;
            }
            else { return result = null; }
        }
        #region CRUD GENÉRICO
        public void Insert(ContasBancarias conta)
        {
            DbDTO dto = new DbDTO()
            {
                Nome = "ContasBancarias",
                Campos = new string[] {
                    "CodBanco",
                    "Numero",
                    "Natureza",
                    "Sequencia",
                    "Iban",
                    "Swift",
                    
                },
                Valores = new Object[] {
                    conta.CodBanco,
                    conta.Numero,
                    conta.Natureza,
                    conta.Sequencia,
                    conta.Iban,
                    conta.Swift,
                  
                }

            };
            Conexao.ClienteSql.INSERT(dto.Nome, dto.Campos, dto.Valores);
        }

        public object Get(ContasBancarias conta)
        {
            var obj = Conexao.ClienteSql.SELECT("SELECT * FROM ContasBancarias");

            DataTable dtadados = (DataTable)obj;

            var result = Folha.Domain.Helpers.DataTableHelper.DataTableToList<ContasBancarias>(dtadados).Where(e => e.codigo == conta.codigo).FirstOrDefault();

            return result;
        }
        public void Update(ContasBancarias conta, string criterios)
        {
            
            DbDTO dto = new DbDTO()
            {
                Nome = "ContasBancarias",
                Campos = new string[] {
                    "CodBanco",
                    "Numero",
                    "Natureza",
                    "Sequencia",
                    "Iban",
                    "Swift",

                },
                Valores = new Object[] {
                    conta.CodBanco,
                    conta.Numero,
                    conta.Natureza,
                    conta.Sequencia,
                    conta.Iban,
                    conta.Swift, }

            };
            Conexao.ClienteSql.UPDATE(dto.Nome, dto.Campos, dto.Valores, "codigo ='" + criterios+ "'");
        }

        public void Delete(int Codconta)
        {
            try
            {
                Conexao.ClienteSql.DELETE("ContasBancarias", "codigo ='" + Codconta + "'");
            }
            catch (Exception){}
            
        }

        public List<ContasBancarias> Listar(string criterios,bool Pesquisa)
        {
            List<ContasBancarias> result = new List<ContasBancarias>();
            string SQL;
              SQL = "SELECT " +
                "Bancos.Codigo as CodBanco, " +
                   "ContasBancarias.Codigo, " +
                   "ContasBancarias.Numero," +
                   " ContasBancarias.Natureza, " +
                   "ContasBancarias.Sequencia," +
                   " Bancos.Descricao, " +
                   "ContasBancarias.Iban," +
                   " ContasBancarias.Swift ";
            if(Pesquisa && criterios!=null)
                SQL += "From ContasBancarias,Bancos WHERE (ContasBancarias.CodBanco=Bancos.Codigo) and (ContasBancarias.Numero LIKE '%"+criterios+ "%') order by ContasBancarias.Codigo";
           else if (!Pesquisa && criterios==null)
                SQL += "From ContasBancarias,Bancos WHERE ContasBancarias.CodBanco=Bancos.Codigo order by ContasBancarias.Codigo";


            Object obj = Conexao.ClienteSql.SELECT(SQL);

            DataTable dtadados = (DataTable)obj;

            result = Folha.Domain.Helpers.DataTableHelper.DataTableToList<ContasBancarias>(dtadados);

            return result;
        }
        #endregion
    }
}
