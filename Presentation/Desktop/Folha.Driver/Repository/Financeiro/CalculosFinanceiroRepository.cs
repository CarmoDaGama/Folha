using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Folha.Driver.Repository;
using Folha.Domain.Models.Db;
using Folha.Domain.Interfaces.Repository.Financeiro;
using Folha.Domain.Models.Financeiro;
using Folha.Domain.ViewModels.Financeiro;
using Folha.Domain.Helpers;
using Folha.Domain.ViewModels.Report;

namespace Folha.Driver.Repository.Data.Repositories.Financeiro
{
    public class CalculosRepository : RepositoryBase<DbDTO>, ICalculosRepository
    {
        public double TaxadeCambio(int CodCambio)
        {
            try
            {
                double Taxa = 0;
                DataTable DtCambios = Conexao.BuscarTabela_com_Criterio("Cambios", "Codigo='" + CodCambio + "'");
                if (DtCambios.Rows.Count > 0)
                {
                    Taxa = double.Parse(DtCambios.Rows[0]["Cambio"].ToString());
                }

                return Taxa;
            }
            catch { return 0; }
        }
       
        IEnumerable<FluxoCaixaViewModel> ICalculosRepository.ListarFluxo(string dtInicio, string dtFim, string CodCaixa, string CodConta,string Tipo)
        {
            string TipoOp = (Tipo == "Crédito") ? ("CREDITO") : ("DEBITO");
            string SQL = "SELECT Pagamentos.Data as DATA,Pagamentos.Hora as HORA,Pagamentos.Descricao, Pagamentos.Tipo AS TIPO, Pagamentos.Valor from Pagamentos Where Pagamentos.Data between '" + dtInicio + "' and '" + dtFim + "' ";
            if (!string.IsNullOrEmpty(CodCaixa))
            {
                SQL += " And Pagamentos.CodCaixa ='" + CodCaixa + "'";
                if (!string.IsNullOrEmpty(Tipo)&&Tipo!="Todos")
                    SQL += " And Pagamentos.Tipo='" + TipoOp + "'";
                SQL += " Order By Pagamentos.Codigo Desc ";
            }else if(!string.IsNullOrEmpty(CodConta))
            {
                SQL += " And Pagamentos.CodConta ='" + CodConta + "'";
                if (!string.IsNullOrEmpty(Tipo) && Tipo != "Todos")
                    SQL += " And Pagamentos.Tipo='" + TipoOp + "'";
                SQL += " Order By Pagamentos.Codigo Desc ";
            }

            try
            {
                object x = Conexao.ClienteSql.SELECT(SQL);
                DataTable DtDados = (DataTable)x;

                var fluxo = DataTableHelper.DataTableToList<Folha.Domain.ViewModels.Financeiro.FluxoCaixaViewModel>(DtDados);
                return fluxo;
            }
            catch (Exception)
            {

                throw new Exception("Erro ao Carregar Fluxo");
            }
        
        }
        public double Saldo_Conta(int CodCliente,string dataInicio,string dataFim)
        {

            Double Credito = 0;
            Double Debito = 0;
            Double Total = 0;
            string Criterio;
            string Criterio2;
            if (!string.IsNullOrEmpty(dataInicio) && !string.IsNullOrEmpty(dataFim))
            {
                Criterio = " and Operacoes.Nome<> 'NOTA DE PAGAMENTO' and Pagamentos.[Data] between '" + dataInicio + "' and '" + dataFim + "'";
                Criterio2 = " and Operacoes.Nome<> 'RECIBO' and Documentos.[Data] between '" + dataInicio + "' and '" + dataFim + "'";
            }
            else
            {
                Criterio = " and Operacoes.Nome<> 'NOTA DE PAGAMENTO'";
                Criterio2 = " and Operacoes.Nome<> 'RECIBO'";
            }
            

            if (CodCliente > 3)
            {

                string SQL = null;
                object x = null;

                SQL = "SELECT Pagamentos.[Data],Pagamentos.Hora as HORA,Pagamentos.Descricao as DESCRICAO, Pagamentos.Tipo AS TIPO, Pagamentos.Valor AS VALOR, Usuarios.Nome as USUARIO from Pagamentos";
                SQL += " join Turnos on Turnos.Codigo=Pagamentos.CodTurno join Usuarios on Usuarios.Codigo=Turnos.CodUsuario join Documentos on Documentos.Codigo=Pagamentos.CodDocumento join Operacoes on Operacoes.Codigo=Documentos.CodOperacao";
                SQL += " WHERE Documentos.CodEntidade ='" + CodCliente + "' " + Criterio + "";
                x = Conexao.ClienteSql.SELECT(SQL);

                DataTable DtPagamentos = (DataTable)x;

                SQL = "SELECT Documentos.Data as DATA,Documentos.Hora as HORA,Operacoes.Nome as DESCRICAO,Operacoes.MovFin as TIPO, Documentos.Total as VALOR, Documentos.Codigo as NUMERO, Operacoes.Nome as OPERACAO, Usuarios.Nome as USUARIO from Documentos ";
                SQL += " LEFT OUTER JOIN Operacoes on Operacoes.Codigo=Documentos.CodOperacao join Usuarios on Usuarios.Codigo=Documentos.CodUsuario";
                SQL += " WHERE Documentos.CodEntidade ='" + CodCliente + "' And Operacoes.Entidade='CLIENTE' And Operacoes.Movfin='CREDITO' and Documentos.Estado like 'FECHADO' " + Criterio2 + "";
                x = Conexao.ClienteSql.SELECT(SQL);

                DataTable DtOperacoes = (DataTable)x;

                foreach (DataColumn col in DtOperacoes.Columns) col.ReadOnly = false;

                for (int i = 0; i < DtOperacoes.Rows.Count; i++)
                {
                    string Descricao = DtOperacoes.Rows[i]["DESCRICAO"].ToString();

                    DtOperacoes.Rows[i]["DESCRICAO"] = DtOperacoes.Rows[i]["DESCRICAO"] + " Nº: " + DtOperacoes.Rows[i]["NUMERO"];
                    if (!Descricao.Trim().Equals("RECIBO"))
                    {
                        DtOperacoes.Rows[i]["TIPO"] = "DEBITO";
                    }

                }

                DtOperacoes.Columns.RemoveAt(5);
                DataTable DtDados = DtOperacoes.Clone();
                for (int i = 0; i < DtPagamentos.Rows.Count; i++)
                {
                    DtDados.ImportRow(DtPagamentos.Rows[i]);
                }

                for (int i = 0; i < DtOperacoes.Rows.Count; i++)
                {
                    DtDados.ImportRow(DtOperacoes.Rows[i]);
                }

                for (int i = 0; i < DtDados.Rows.Count; i++)
                {

                    string Tipo = DtDados.Rows[i]["TIPO"].ToString();
                    if (Tipo.Equals("CREDITO")) Credito += double.Parse(DtDados.Rows[i]["VALOR"].ToString());
                    if (Tipo.Equals("DEBITO")) Debito += double.Parse(DtDados.Rows[i]["VALOR"].ToString());
                }
                Total = Credito - Debito;
            }
            return Total;

            //catch(Exception ex) { MessageBox.Show("Erro \n" + ex); return 0; }
        }
        IEnumerable<FluxoCaixaViewModel> ICalculosRepository.buscarContaCorrente(string dataInicio, string dataFim, int codEntidade)
        {
            string SQL = null;
            object x = null;
            DataTable DtDados = new DataTable();

            SQL = "SELECT Pagamentos.Data as DATA,Pagamentos.Hora as HORA,Pagamentos.Descricao as DESCRICAO, Pagamentos.Tipo AS TIPO, Pagamentos.Valor AS VALOR, Usuarios.Nome as USUARIO from Pagamentos";
            SQL += " join Turnos on Turnos.Codigo=Pagamentos.CodTurno join Usuarios on Usuarios.Codigo=Turnos.CodUsuario join Documentos on Documentos.Codigo=Pagamentos.CodDocumento join Operacoes on Operacoes.Codigo=Documentos.CodOperacao";
            SQL += " WHERE Documentos.CodEntidade ='" + codEntidade + "'";
            SQL += " AND Pagamentos.Data between  '" + dataInicio+ "' and '" + dataFim + "' and Operacoes.Nome<> 'NOTA DE PAGAMENTO'";
            x = Conexao.ClienteSql.SELECT(SQL);
            DataTable DtPagamentos = (DataTable)x;


            SQL = "SELECT Documentos.Data as DATA,Documentos.Hora as HORA,Operacoes.Nome as DESCRICAO,Operacoes.MovFin as TIPO, Documentos.Total as VALOR, Documentos.Codigo as NumeroDoc, Operacoes.Nome as OPERACAO, Usuarios.Nome as USUARIO from Documentos ";
            SQL += " LEFT OUTER JOIN Operacoes on Operacoes.Codigo=Documentos.CodOperacao join Usuarios on Usuarios.Codigo=Documentos.CodUsuario";
            SQL += " WHERE Documentos.CodEntidade ='" + codEntidade + "' And Operacoes.Entidade='CLIENTE' And Operacoes.Movfin='CREDITO' ";
            SQL += " AND Documentos.Data between '" + dataInicio + "' and '" + dataFim + "' and Operacoes.Nome<> 'RECIBO'";

            x = Conexao.ClienteSql.SELECT(SQL);
            DataTable DtOperacoes = (DataTable)x;

            foreach (DataColumn col in DtOperacoes.Columns) col.ReadOnly = false;


            for (int i = 0; i < DtOperacoes.Rows.Count; i++)
            {
                DtOperacoes.Rows[i]["Descricao"] = DtOperacoes.Rows[i]["Descricao"] + " Nº: " + DtOperacoes.Rows[i]["NumeroDoc"];
                DtOperacoes.Rows[i]["TIPO"] = "DEBITO";
            }

            DtOperacoes.Columns.RemoveAt(5);
            DtDados = DtOperacoes.Clone();

            for (int i = 0; i < DtPagamentos.Rows.Count; i++)
            {
                DtDados.ImportRow(DtPagamentos.Rows[i]);
            }

            for (int i = 0; i < DtOperacoes.Rows.Count; i++)
            {
                DtDados.ImportRow(DtOperacoes.Rows[i]);
            }

            DtDados.Columns[0].SetOrdinal(0);
            DtDados.Columns[1].SetOrdinal(1);

            var fluxo = DataTableHelper.DataTableToList<FluxoCaixaViewModel>(DtDados);
            return fluxo;
        }

        public IEnumerable<SaldoClienteViewModel> BuscarSaldoClientes(string dataInicio, string dataFim)
        {
            List<SaldoClienteViewModel> LtSaldo = new List<SaldoClienteViewModel>();
            string SQL = "SELECT Entidades.Codigo, Entidades.Nome from Entidades";

            object x = Conexao.ClienteSql.SELECT(SQL);
            DataTable DtDados = (DataTable)x;

            for (int i = 0; i < DtDados.Rows.Count; i++)
            {
                int CodCliente = int.Parse(DtDados.Rows[i][0].ToString());
                if(!string.IsNullOrEmpty(dataInicio) && !string.IsNullOrEmpty(dataInicio))
                {
                    if (Saldo_Conta(CodCliente, dataInicio, dataFim) > 0)
                    {
                        LtSaldo.Add(new SaldoClienteViewModel() { Codigo = int.Parse(DtDados.Rows[i][0].ToString()), NomeCliente = DtDados.Rows[i][1].ToString(), Valor = Saldo_Conta(CodCliente, dataInicio, dataFim).ToString("N2") });
                    }
                }
                else
                {
                    if (Saldo_Conta(CodCliente,null, null) > 0)
                    {
                        LtSaldo.Add(new SaldoClienteViewModel() { Codigo = int.Parse(DtDados.Rows[i][0].ToString()), NomeCliente = DtDados.Rows[i][1].ToString(), Valor = Saldo_Conta(CodCliente, null, null).ToString("N2") });
                    }
                }
                
            }
            return LtSaldo;
        }

        public IEnumerable<SaldoClienteViewModel> BuscarDividasClientes( string dataInicio, string dataFim)
        {
            List<SaldoClienteViewModel> LtSaldo = new List<SaldoClienteViewModel>();
            string SQL = "SELECT Entidades.Codigo, Entidades.Nome from Entidades";

            object x = Conexao.ClienteSql.SELECT(SQL);
            DataTable DtDados = (DataTable)x;

            for (int i = 0; i < DtDados.Rows.Count; i++)
            {
                int CodCliente = int.Parse(DtDados.Rows[i][0].ToString());

                if(!string.IsNullOrEmpty(dataInicio) && !string.IsNullOrEmpty(dataFim))
                {
                    double Saldo = Saldo_Conta(CodCliente, dataInicio, dataFim) * (-1);
                    if (Saldo_Conta(CodCliente, dataInicio, dataFim) < 0)
                    {
                        LtSaldo.Add(new SaldoClienteViewModel() { Codigo = int.Parse(DtDados.Rows[i][0].ToString()), NomeCliente = DtDados.Rows[i][1].ToString(), Valor = Saldo.ToString("N2") });
                    }
                }else
                {
                    double Saldo = Saldo_Conta(CodCliente, null, null) * (-1);
                    if (Saldo_Conta(CodCliente, null, null) < 0)
                    {
                        LtSaldo.Add(new SaldoClienteViewModel() { Codigo = int.Parse(DtDados.Rows[i][0].ToString()), NomeCliente = DtDados.Rows[i][1].ToString(), Valor = Saldo.ToString("N2") });
                    }
                }
                

            }
            return LtSaldo;
        }

        public IEnumerable<RelNotasPagamentosViewModel> BuscarNotasPagamentos(string dataInicio, string dataFim)
        {
            string SQL = "Select NotaSaida.Codigo, Documentos.[Data], Documentos.Hora, Operacoes.Nome as NomeOperacao, Entidades.Nome as Entidade, TipoSaida.Descricao as Finalidade, Documentos.Total as Valor, Usuarios.Nome as Usuario from NotaSaida";
            SQL += " join Documentos on Documentos.Codigo=NotaSaida.CodDocumento join Operacoes on Operacoes.Codigo=Documentos.CodOperacao join Entidades on Entidades.Codigo=Documentos.CodEntidade";
            SQL += " join TipoSaida on TipoSaida.Codigo=NotaSaida.CodTipoSaida join Usuarios on Usuarios.Codigo=Documentos.CodUsuario";

            if(!string.IsNullOrEmpty(dataInicio) && !string.IsNullOrEmpty(dataFim))
            SQL += " Where Documentos.Data between '" + dataInicio + "' and '" + dataFim + "'";

            object obj = Conexao.ClienteSql.SELECT(SQL);
            DataTable DtDados = (DataTable)obj;

            var result = DataTableHelper.DataTableToList<RelNotasPagamentosViewModel>(DtDados);
            return result;
        }

       public string MostraTotal(string dataInicio, string dataFim, int CodTipoSaida)
        {
            string SQL = "SELECT Documentos.Total from Documentos join NotaSaida on NotaSaida.CodDocumento= Documentos.Codigo";
            if (!string.IsNullOrEmpty(dataInicio) && !string.IsNullOrEmpty(dataFim))
                SQL += " where Documentos.[Data] between '" + dataInicio + "' and '" + dataFim + "' And NotaSaida.CodTipoSaida='" + CodTipoSaida + "'";
            else
                SQL += " where NotaSaida.CodTipoSaida='" + CodTipoSaida + "'";

            object x = Conexao.ClienteSql.SELECT(SQL);
            DataTable DtTotal = (DataTable)x;
            double soma = 0;
            for (int i = 0; i < DtTotal.Rows.Count; i++)
            {
                soma += double.Parse(DtTotal.Rows[i][0].ToString());
            }

            return soma.ToString("N2"); ;
        }
        public DataViewModel RetortaDataSaldoCaixaConta()
        {
            DataViewModel result;
            string dtInicial=null;
            string dtFinal = null;
            string SQL = "select Min([Data]) as DataInicial,Max([Data]) as DataFinal from Pagamentos WHERE CodCaixa>=1 or CodConta>=1";
            var obj = Conexao.ClienteSql.SELECT(SQL);
            DataTable dtPagamento = (DataTable)obj;

            if(dtPagamento.Rows.Count>0)
            {
                dtInicial = dtPagamento.Rows[0]["DataInicial"].ToString();
                dtFinal = dtPagamento.Rows[0]["DataFinal"].ToString();
            }
           

            if (!string.IsNullOrEmpty(dtInicial)&& !string.IsNullOrEmpty(dtFinal))
            {
                result = new DataViewModel() { DataInicial = Convert.ToDateTime(dtInicial), DataFinal = Convert.ToDateTime(dtFinal) };
                return result;
            }
            else { return result=null; }
           
        }
        public  Saldos MostraSaldo(string data)
        {
            Saldos SaldoActual = new Saldos();
            DataTable DtCreditos = (DataTable)Conexao.ClienteSql.SELECT("SELECT Documentos.TOTAL FROM Documentos join Operacoes on Operacoes.Codigo=Documentos.CodOperacao where Operacoes.MovFin='CREDITO' and Documentos.Data between '" + data + "' and '" + data + "'");
            DataTable DtBebitos = (DataTable)Conexao.ClienteSql.SELECT("SELECT Documentos.TOTAL FROM Documentos join Operacoes on Operacoes.Codigo=Documentos.CodOperacao where Operacoes.MovFin='DEBITO' and Documentos.Data between '" + data + "' and '" + data + "'");

            for (int i = 0; i < DtCreditos.Rows.Count; i++)
            {
                SaldoActual.Credito += double.Parse(DtCreditos.Rows[i]["Total"].ToString());
            }
            for (int i = 0; i < DtBebitos.Rows.Count; i++)
            {
                SaldoActual.Debito += double.Parse(DtBebitos.Rows[i]["Total"].ToString());
            }
            return SaldoActual;
        }
        public DataViewModel RetornaDataDocumento()
        { 
            //string Criterio;
            string Criterio2;
            DataTable DtDados = new DataTable();
            DataViewModel result=null;

            //Criterio = " and Operacoes.Nome<> 'NOTA DE PAGAMENTO'";
            Criterio2 = " and Operacoes.Nome<> 'RECIBO'";

            string SQL = null;
            string dtInicial = null;
            string dtFinal = null;
            object x = null;
            try
            {
                    SQL = "SELECT  Min(Documentos.[Data]) as DataInicial,Max(Documentos.[Data]) as DataFinal from Documentos ";
                    SQL += " LEFT OUTER JOIN Operacoes on Operacoes.Codigo=Documentos.CodOperacao join Usuarios on Usuarios.Codigo=Documentos.CodUsuario";
                    SQL += " WHERE Documentos.CodEntidade >3  And Operacoes.Entidade='CLIENTE' And Operacoes.Movfin='CREDITO' and Documentos.Estado like 'FECHADO' " + Criterio2 + "";
                    x = Conexao.ClienteSql.SELECT(SQL);
                    DataTable DtOperacoes = (DataTable)x;
                    result = new DataViewModel();

                if (DtOperacoes.Rows.Count > 0)
                {
                    dtInicial = DtOperacoes.Rows[0]["DataInicial"].ToString();
                    dtFinal = DtOperacoes.Rows[0]["DataFinal"].ToString();
                }
                if (!string.IsNullOrEmpty(dtInicial) && !string.IsNullOrEmpty(dtFinal))
                    {
                                result.DataInicial = Convert.ToDateTime(dtInicial);
                                result.DataFinal = Convert.ToDateTime(dtFinal);
                    }
                    else
                    {
                        result.DataInicial = DateTime.Now;
                        result.DataFinal = DateTime.Now;
                    }
                
            }
            catch (Exception) { }
            return result;
        }
        public DataViewModel RetortaDataNotasPagamentos()
        {
            string SQL;
            string dtInicial = null;
            string dtFinal = null;
            DataViewModel result=new DataViewModel();
            try
            {
                 SQL = "Select Min(Documentos.[Data]) as DataInicial, Max(Documentos.[Data]) as DataFinal from NotaSaida";
                SQL += " join Documentos on Documentos.Codigo=NotaSaida.CodDocumento join Operacoes on Operacoes.Codigo=Documentos.CodOperacao join Entidades on Entidades.Codigo=Documentos.CodEntidade";
                SQL += " join TipoSaida on TipoSaida.Codigo=NotaSaida.CodTipoSaida join Usuarios on Usuarios.Codigo=Documentos.CodUsuario";
                
                var obj = Conexao.ClienteSql.SELECT(SQL);
                DataTable dtDados = (DataTable)obj;

                if (dtDados.Rows.Count > 0)
                {
                    dtInicial = dtDados.Rows[0]["DataInicial"].ToString();
                    dtFinal = dtDados.Rows[0]["DataFinal"].ToString();
                }
                if (!string.IsNullOrEmpty(dtInicial) && !string.IsNullOrEmpty(dtFinal))
                {
                    
                    result = new DataViewModel() { DataInicial = Convert.ToDateTime(dtInicial), DataFinal = Convert.ToDateTime(dtFinal) };
                    return result;
                }
                else
                {
                    result.DataInicial = DateTime.Now;
                    result.DataFinal = DateTime.Now;
                }
            }
            catch (Exception){}
            return result;
            

        }

    }
    }

