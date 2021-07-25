using Folha.Domain.Models.Db;
using Folha.Domain.Interfaces.Repository.Financeiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Folha.Domain.ViewModels.Frame.Financeiro;
using System.Data;
using Folha.Driver.Repository.Data;
using Folha.Domain.Helpers;

namespace Folha.Driver.Repository.Financeiro
{
    public class VendasRepository : RepositoryBase<DbDTO>, IVendasRepository
    {
        public IEnumerable<PagamentosViewModel> ListarPagamentos(string crit)
        {
            DataTable DtDados = new DataTable();
            try
            {

                string[] campos = { "Pagamentos.Codigo as Numero", "Pagamentos.Data", "Pagamentos.Descricao", "fPagamentos.Descricao as Forma", "Pagamentos.Tipo", "Pagamentos.Valor", "Moedas.Sigla", "Pagamentos.Estado", "Pagamentos.CodCambio" };
                string[] criterioJoin = { "fPagamentos on Pagamentos.CodForma = fPagamentos.Codigo", "Documentos on Documentos.Codigo=Pagamentos.CodDocumento", "Comissoes on Documentos.Codigo=Comissoes.CodDocumento", "Operacoes on Documentos.CodOperacao=Operacoes.Codigo", "Moedas on Moedas.Codigo=Pagamentos.CodMoeda" };
                string[] criterios2 = { crit };

                var ob = Conexao.ClienteSql.LEFTJOIN("Pagamentos", campos, criterioJoin, criterios2);
                DtDados = (DataTable)ob;
                var result = DataTableHelper.DataTableToList<PagamentosViewModel>(DtDados);

                return result;

                //string SQL = "SELECT Turnos.Codigo as Codigo, Turnos.Estado as Estado, Usuarios.Nome as Usuario, Turnos.DataAbertura as Abertura, Turnos.DataFecho as Fecho, Turnos.SaldoInicial as Inicial, Turnos.SaldoInformado as Informado, Turnos.SaldoVendas as Vendas, Turnos.SaldoTotal as Total, Turnos.QuebraCaixa as Quebra, Turnos.CodUsuario,Caixas.Descricao as Caixa,Usuarios.Nome as Supervisor,Turnos.DataConfirmacao as DataConfirmacao from Turnos ";
                //SQL += " Left Outer Join Caixas on Turnos.CodCaixa=Caixas.codigo ";
                //SQL += " Left Outer Join Usuarios on Turnos.CodUsuario=Usuarios.Codigo Order by Codigo Desc";

                //var ob = Conexao.ClienteSql.SELECT(SQL);
                //DtDados = (DataTable)ob;
                //var result = DataTableHelper.DataTableToList<PagamentosViewModel>(DtDados);
                //return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar Pagamentos\n" + ex.Message);
            }
        }

        public IEnumerable<RegistoVendasViewModel> ListarRegistoVendas(string criterios)
        {
            DataTable DtDados = new DataTable();
            try
            {
                string SQL = "SELECT Documentos.codigo as Codigo, Documentos.Data as Data, Documentos.Hora as Hora, Operacoes.Nome as NomeDocumento, Areas.descricao as Area, Entidades.Nome AS Entidade, Documentos.Total as Total, Documentos.Estado as Estado, Usuarios.Nome AS Usuario, Documentos.CodOperacao as CodOperacao, Documentos.CodEntidade as CodCliente, Operacoes.MovFin as Tipo, Documentos.Descritivo as Descritivo from Documentos";
                SQL = SQL + " JOIN Operacoes ON Operacoes.codigo = Documentos.CodOperacao JOIN Entidades ON Entidades.Codigo = Documentos.CodEntidade JOIN Usuarios ON Usuarios.codigo = Documentos.CodUsuario JOIN Areas ON Areas.codigo = Documentos.CodArea LEFT JOIN Comissoes ON Comissoes.CodDocumento = Documentos.Codigo ";

                if (!string.IsNullOrEmpty(criterios))
                {
                    SQL = SQL + " Where " + criterios;
                }


                SQL += " Order by Documentos.Codigo desc ";

                var ob = Conexao.ClienteSql.SELECT(SQL);
                DtDados = (DataTable)ob;
                var result = DataTableHelper.DataTableToList<RegistoVendasViewModel>(DtDados);
                return result;

               
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar Registos de Vendas\n" + ex.Message);
            }
       
        }
    }
}
