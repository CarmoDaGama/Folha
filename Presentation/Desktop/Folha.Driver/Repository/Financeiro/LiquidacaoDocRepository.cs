using Folha.Domain.Models.Db;
using Folha.Domain.Interfaces.Repository.Financeiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Folha.Domain.ViewModels.Frame.Financeiro;
using Folha.Driver.Repository;
using Folha.Driver.Repository.Data;
using System.Data;
using Folha.Domain.Helpers;

namespace Folha.Driver.Repository.Financeiro
{
    public class LiquidacaoDocRepository : RepositoryBase<DbDTO>, ILiquidacaoDocRepository
    {
        public void Delete(LiquidacaoDocViewModel delete)
        {
            Conexao.ClienteSql.DELETE("Documentos", "Codigo ='" + delete.Codigo + "'");
        }

        public IEnumerable<LiquidacaoDocViewModel> Listar(string CodEntidade)
        {
            DataTable DtDados = new DataTable();
            try
            {
                string SQL = "Select Documentos.Codigo as Codigo, Documentos.Data as Data , Entidades.Codigo as CodEntidade, Documentos.Hora as Hora, Operacoes.Nome as Documento, Entidades.Nome as Entidade, Documentos.Total as Total from Documentos join Entidades on Entidades.Codigo=Documentos.CodEntidade join Operacoes on Operacoes.Codigo= Documentos.CodOperacao left Join Pagamentos on Pagamentos.CodDocumento=Documentos.Codigo where Pagamentos.CodDocumento is Null and Operacoes.MovFin like 'CREDITO' and  Documentos.Total>0 and Documentos.Estado='FECHADO'";
                if(!string.IsNullOrEmpty(CodEntidade))
                SQL = SQL + " And Documentos.CodEntidade ='" + CodEntidade + "'";
                SQL += " order by Documentos.Codigo";
                var x = Conexao.ClienteSql.SELECT(SQL);

                DtDados = (DataTable)x;
                var result = DataTableHelper.DataTableToList<LiquidacaoDocViewModel>(DtDados);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar Dívidas\n" + ex.Message);
            }
        }


        public IEnumerable<LiquidacaoDocViewModel> ListarContasReceber(string CodEntidade)
        {
            DataTable DtDados = new DataTable();
            try
            {
                string SQL = "Select Documentos.Codigo as Codigo, Documentos.Data as Data , Entidades.Codigo as CodEntidade, Documentos.Hora as Hora, Operacoes.Nome as Documento, Entidades.Nome as Entidade, Documentos.Total as Total from Documentos join Entidades on Entidades.Codigo=Documentos.CodEntidade join Operacoes on Operacoes.Codigo= Documentos.CodOperacao left Join Pagamentos on Pagamentos.CodDocumento=Documentos.Codigo where Pagamentos.CodDocumento is Null and Operacoes.MovFin like 'DEBITO' and  Documentos.Total>0 and Documentos.Estado='FECHADO'";
                if (!string.IsNullOrEmpty(CodEntidade))
                    SQL = SQL + " And Documentos.CodEntidade ='" + CodEntidade + "'";
                SQL += " order by Documentos.Codigo";



                var x = Conexao.ClienteSql.SELECT(SQL);

                DtDados = (DataTable)x;
                var result = DataTableHelper.DataTableToList<LiquidacaoDocViewModel>(DtDados);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar Dívidas\n" + ex.Message);
            }
        }

        public IEnumerable<LiquidacaoDocViewModel> ListarContaPagar()
        {
            DataTable DtDados = new DataTable();
            try
            {
                string SQL = "Select Documentos.Codigo, Documentos.Estado, Documentos.Data as DATA, Documentos.Hora as HORA, Operacoes.Nome as Documento, Entidades.Nome As Entidade," +
                     "Documentos.Total as TOTAL, Documentos.CodEntidade from Documentos join Entidades on Entidades.Codigo = Documentos.CodEntidade join Operacoes"
                     + " on Operacoes.Codigo = Documentos.CodOperacao where Operacoes.MovFin like 'DEBITO' and (Documentos.Estado = 'ABERTO' or Documentos.Estado = 'PENDENTE') order by Documentos.Codigo";


                 //"Select Documentos.Codigo, Documentos.Estado, Documentos.Data as DATA, Documentos.Hora as HORA, Operacoes.Nome as Documento, Entidades.Nome As Entidade," +
                 //" Documentos.Total as TOTAL, Documentos.CodEntidade from Documentos join Entidades on Entidades.Codigo=Documentos.CodEntidade join Operacoes" +
                 //" on Operacoes.Codigo= Documentos.CodOperacao where  Operacoes.MovFin like 'DEBITO' and  Documentos.Total>0 and Documentos.Estado='ABERTO' or Documentos.Estado='PENDENTE' order by Documentos.Codigo";

                 var x = Conexao.ClienteSql.SELECT(SQL);

                DtDados = (DataTable)x;
                var result = DataTableHelper.DataTableToList<LiquidacaoDocViewModel>(DtDados);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar Conta A Pagar\n");
            }
        }
    }
    }
