using Folha.Domain.Models.Financeiro;
using Folha.Domain.Models.Db;
using Folha.Driver.Repository;
using Folha.Domain.Interfaces.Repository.Financeiro;
using System;
using System.Collections.Generic;
using Folha.Domain.ViewModels.Frame.Financeiro;
using System.Data;
using System.Windows.Forms;
using Folha.Domain.Helpers;
using Folha.Domain.ViewModels.Frame;
using System.Linq;
using Folha.Domain.ViewModels.Frame.Documentos;

namespace Folha.Driver.Repository.Data.Repositories.Financeiro
{
    public class PagamentosRepository : RepositoryBase<DbDTO>, IPagamentosRepository

    {


        public IEnumerable<Pagamentos> BuscarPagamentosEntcodigoade(string crit)
        {
            DataTable DtDados = new DataTable();
            List<Pagamentos> pagamentos = new List<Pagamentos>();


            string[] tabelas = { "Pagamentos" }; //, "", "" };
            string[] campos = { "Pagamentos.Data", "Pagamentos.Hora", "Pagamentos.Descricao", "Pagamentos.Tipo", "Pagamentos.Valor as Total" };
            //string[] criteriosTodos = { "Armazens on MovProdutos.CodArmazem=Armazens.codigo", "Documentos on Documentos.Codigo=MovProdutos.CodDocumento", "Operacoes on Operacoes.codigo = Documentos.CodOperacao" };
            Object ob;

            string[] criterios = { crit };

            if (string.IsNullOrEmpty(crit))
            {
                //Busca.setSelectInnerJoin(Geral.CaminhoBd, tabelas, campos, null);
                ob = Conexao.ClienteSql.INNERJOIN(tabelas[0].ToString(), campos, null, null);
            }
            else
            {
                //Busca.setSelectInnerJoin(Geral.CaminhoBd, tabelas, campos, null, criterios);
                ob = Conexao.ClienteSql.INNERJOIN(tabelas[0].ToString(), campos, null, criterios);
            }

            try
            {

                //MessageBox.Show(ob.ToString());
                DtDados = (DataTable)ob;
                //pagamentos = DtDados.AsEnumerable<Pagamento>().ToList<Pagamento>();

                // MessageBox.Show(DtDados.Rows.Count.ToString());
            }
            catch (Exception ex)
            {
                throw new NotImplementedException("Erro a Ler Produtos  " + ex.Message);
            }
            return pagamentos;
        }

        public IEnumerable<Pagamentos> BuscarPagamentosPorEntcodigoade(string crit)
        {
            List<Pagamentos> result = new List<Pagamentos>();

            DataTable DtDados = new DataTable();


            string[] tabelas = { "Pagamentos" }; //, "", "" };
            string[] campos = { "Pagamentos.Data", "Pagamentos.Hora", "Pagamentos.Descricao", "Pagamentos.Tipo", "Pagamentos.Valor as Total" };

            Object ob;

            string[] criterios = { crit };

            if (string.IsNullOrEmpty(crit))
            {
                ob = Conexao.ClienteSql.INNERJOIN(tabelas[0].ToString(), campos, null, null);
            }
            else
            {
                ob = Conexao.ClienteSql.INNERJOIN(tabelas[0].ToString(), campos, null, criterios);
            }

            try
            {

                DtDados = (DataTable)ob;

                for (int i = 0; i < DtDados.Rows.Count; i++)
                {

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


            return result;
        }

        public double buscarSaldoBanco(Guid bancocodigo)
        {
            try
            {

                DataTable dtPagamento = Conexao.BuscarTabela_com_Criterio("Pagamentos", "CodConta='" + bancocodigo + "'");
                double credito = 0;
                double debcodigoo = 0;

                for (int i = 0; i < dtPagamento.Rows.Count; i++)
                {

                    if (dtPagamento.Rows[i][7].ToString() == "CREDITO")
                    {
                        credito = credito + double.Parse(dtPagamento.Rows[i][6].ToString());
                    }
                    else
                    {
                        debcodigoo = debcodigoo + double.Parse(dtPagamento.Rows[i][6].ToString());
                    }
                }

                double Saldo = credito - debcodigoo;

                return Saldo;

            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro a processar \n" + ex.Message);
            }

        }

        public void EfectuarPagamentosBn(DadosPagamentoViewModel dados)
        {
            string Hora = DateTime.Now.ToShortTimeString();
            try
            {
                String[] Campos = { "Descricao", "Data", "Hora", "CodForma", "Valor", "Tipo", "CodDocumento", "CodConta", "CodTurno", "Estado", "CodMoeda"/*, "CodCambio" */};
                Object[] Valores = { dados.Descricao, dados.Data, Hora, 2, dados.Valor, "DEBITO", dados.CodDoc, dados.CodConta, UtilidadesGenericas.CodigoTurno, "FECHADO", dados.CodMoeda/*, dados.CodCambio */};

                Conexao.ClienteSql.INSERT("Pagamentos", Campos, Valores);

            }
            catch (Exception) { throw new Exception("Erro a receber pagamento"); }
        }

        public void EfectuarPagamentosCx(DadosPagamentoViewModel dados)
        {
            string Hora = DateTime.Now.ToShortTimeString();

            try
            {
                String[] Campos = { "Descricao", "Data", "Hora", "CodForma", "Valor", "Tipo", "CodDocumento", "CodCaixa", "CodTurno", "Estado", "CodMoeda"/*, "CodCambio"*/ };
                Object[] Valores = { dados.Descricao, dados.Data, Hora, 1, dados.Valor, "DEBITO", dados.CodDoc, dados.CodCaixa, UtilidadesGenericas.CodigoTurno, "FECHADO", dados.CodMoeda/*, CodCambio */};
                Conexao.ClienteSql.INSERT("Pagamentos", Campos, Valores);

            }
            catch (Exception) { throw new Exception("Erro a receber pagamento"); }
        }


        public IEnumerable<ListarMovBancariosViewModel> ListarMovBancarios(string criterios)
        {
            DataTable DtDados = new DataTable();
            string SQL = "SELECT Pagamentos.Codigo, Pagamentos.Data as DATA, Pagamentos.Hora as HORA, Pagamentos.Descricao as DESCRICAO, Entidades.Nome as Entidade,  Pagamentos.Valor AS VALOR, Pagamentos.Tipo AS TIPO, Pagamentos.CodDocumento, Bancos.Descricao as Banco, Pagamentos.Estado, Moedas.Sigla, Pagamentos.CodCambio from Pagamentos";
            SQL += " join Documentos on Documentos.Codigo=Pagamentos.CodDocumento Left Outer Join Entidades on Documentos.CodEntidade=Entidades.codigo Left Outer Join FPagamentos on FPagamentos.codigo=Pagamentos.CodForma Left Outer Join ContasBancarias on FPagamentos.CodConta=ContasBancarias.Codigo Left Outer Join Bancos on ContasBancarias.CodBanco=Bancos.codigo left join Moedas on Moedas.Codigo=Pagamentos.CodMoeda";
            SQL += " WHERE Pagamentos.CodForma !=1";
            SQL += criterios;
            SQL += " Order By Pagamentos.Codigo Desc ";

            try
            {
                var x = Conexao.ClienteSql.SELECT(SQL);

                DtDados = (DataTable)x;
                var result = DataTableHelper.DataTableToList<ListarMovBancariosViewModel>(DtDados);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar Pagamentos\n" + ex.Message);
            }

        }

        public IEnumerable<Pagamentos> MostraPagamentosBn(string criterios)
        {

            DataTable DtDados = new DataTable();
            List<Pagamentos> pagamentos = new List<Pagamentos>();
            string[] tabelas = { "Pagamentos" };
            string[] campos = { "Pagamentos.codigo", "Pagamentos.Data", "Pagamentos.Hora", "Pagamentos.Descricao", "fPagamentos.Descricao", "Entcodigoades.Nome", "Pagamentos.Valor as VALOR", "Pagamentos.Tipo as TIPO", "Pagamentos.CodDocumento", "Caixas.Descricao", "Bancos.Descricao", "Pagamentos.Estado", };
            string[] criterioTabelas = { "fPagamentos on Pagamentos.CodForma=fPagamentos.Codigo", "Entcodigoades on Pagamentos.CodEntcodigoade=Entcodigoades.codigo", "ContasBancarias on fPagamentos.CodConta=ContasBancarias.Codigo", "Bancos on ContasBancarias.CodBanco=Bancos.codigo" };
            string[] criterioFilro = { criterios };
            Object ob;
            try
            {
                if (string.IsNullOrEmpty(criterios))
                {
                    ob = Conexao.ClienteSql.LEFTJOIN(tabelas[0].ToString(), campos, criterioTabelas, null);
                }
                else
                {
                    ob = Conexao.ClienteSql.LEFTJOIN(tabelas[0].ToString(), campos, criterioTabelas, criterioFilro);
                }

                DtDados = (DataTable)ob;

                decimal SaldoCredor = 0, SaldoDevedor = 0;
                for (int i = 0; i < DtDados.Rows.Count; i++)
                {
                    if (DtDados.Rows[i]["TIPO"].ToString().Equals("CREDITO")) SaldoCredor = SaldoCredor + decimal.Parse(DtDados.Rows[i]["VALOR"].ToString());
                    else SaldoDevedor = SaldoDevedor + decimal.Parse(DtDados.Rows[i]["VALOR"].ToString());
                }

                decimal SaldoTotal = SaldoCredor - SaldoDevedor;

            }
            catch (Exception ex) { }
            return pagamentos;
        }

        public IEnumerable<Pagamentos> MostraPagamentosCx(string criterios)
        {


            DataTable DtDados = new DataTable();
            List<Pagamentos> pagamentos = new List<Pagamentos>();
            string[] tabelas = { "Pagamentos" };
            string[] campos = { "Pagamentos.codigo", "Pagamentos.Data", "Pagamentos.Hora", "Pagamentos.Descricao", "fPagamentos.Descricao", "Entcodigoades.Nome", "Pagamentos.Valor as VALOR", "Pagamentos.Tipo as TIPO", "Pagamentos.CodDocumento", "Caixas.Descricao", "Bancos.Descricao", "Pagamentos.Estado", };
            string[] criterioTabelas = { "fPagamentos on Pagamentos.CodForma=fPagamentos.Codigo", "Entcodigoades on Pagamentos.CodEntcodigoade=Entcodigoades.codigo", "Caixas on Pagamentos.CodCaixa=Caixas.codigo", "ContasBancarias on fPagamentos.CodConta=ContasBancarias.Codigo", "Bancos on ContasBancarias.CodBanco=Bancos.codigo" };
            string[] criterioFilro = { criterios };
            Object ob;
            try
            {
                if (string.IsNullOrEmpty(criterios))
                {
                    ob = Conexao.ClienteSql.LEFTJOIN(tabelas[0].ToString(), campos, criterioTabelas, null);
                }
                else
                {
                    ob = Conexao.ClienteSql.INNERJOIN(tabelas[0].ToString(), campos, criterioTabelas, criterioFilro);
                }

                DtDados = (DataTable)ob;

            }
            catch (Exception ex) { }
            return pagamentos;

        }

        public string ReceberContaCorrente(Pagamentos pagamento, bool forma, int Turno_Sistema_Numero)
        {

            if (pagamento.Descricao.Equals("")) { throw new Exception("Informe a Descrição do pagamento"); return null; }
            if (pagamento.Valor == 0) { throw new Exception("Informe o Valor do Pagamento Invalcodigoo"); return null; }

            string Hora = DateTime.Now.ToShortTimeString();
            string GravarDados = null;
            int codConta;
            if (forma)
            {
                DataTable dt = Conexao.BuscarTabela_com_Criterio("fPagamentos", "Codigo='" + pagamento.Forma.codigo + "'");
                codConta = int.Parse(dt.Rows[0][3].ToString());
                try
                {

                    String[] Campos = { "CodDocumento", "Descricao", "Data", "Hora", "CodForma", "Valor", "Tipo", "CodConta", "CodTurno", "Estado", "CodMoeda", "CodCambio" };
                    Object[] Valores = { pagamento.Documento.codigo, pagamento.Descricao, pagamento.Data, Hora, pagamento.Forma.codigo, pagamento.Valor, "CREDITO", pagamento.Conta.codigo, Turno_Sistema_Numero, "FECHADO", pagamento.Moeda.codigo, pagamento.Cambio.codigo };

                    /*GravarDados =*/
                    Conexao.ClienteSql.INSERT("Pagamentos", Campos, Valores);
                }
                catch (Exception ex) { throw new Exception("Erro a receber pagamento \n" + ex.Message + GravarDados); }
            }
            else
            {

                try
                {

                    String[] Campos = { "CodDocumento", "Descricao", "Data", "Hora", "CodForma", "Valor", "Tipo", "CodTurno", "Estado", "CodMoeda", "CodCambio" };
                    Object[] Valores = { pagamento.Documento.codigo, pagamento.Descricao, pagamento.Data, Hora, pagamento.Forma.codigo, pagamento.Valor, "CREDITO", pagamento.Conta.codigo, Turno_Sistema_Numero, "FECHADO", pagamento.Moeda.codigo, pagamento.Cambio.codigo };

                    /*GravarDados =*/
                    Conexao.ClienteSql.INSERT("Pagamentos", Campos, Valores);
                }
                catch (Exception ex) { throw new Exception("Erro a receber pagamento \n" + ex.Message + GravarDados); }


            }
            return GravarDados;
        }

        public string ReceberPagamentos(Pagamentos pagamento, bool forma, int Turno_Sistema_Numero)
        {

            if (pagamento.Descricao.Equals("")) { throw new Exception("Informe a Descrição do pagamento"); return null; }
            //if (Valor == 0) { MessageBox.Show("Informe o Valor do Pagamento Invalcodigoo", "", MessageBoxButtons.OK, MessageBoxIcon.Error); return null; }
            string Hora = DateTime.Now.ToShortTimeString();
            int codConta;
            string GravarDados = null;
            if (forma)
            {
                DataTable dt = Conexao.BuscarTabela_com_Criterio("fPagamentos", "Codigo='" + pagamento.Forma.codigo + "'");
                codConta = int.Parse(dt.Rows[0][3].ToString());

                try
                {

                    String[] Campos = { "Descricao", "Data", "Hora", "CodForma", "Valor", "Tipo", "CodDocumento", "CodConta", "CodTurno", "Estado", "CodMoeda", "CodCambio" };
                    Object[] Valores = { pagamento.Descricao, pagamento.Data, Hora, pagamento.Forma.codigo, pagamento.Valor, "CREDITO", pagamento.Documento.codigo, pagamento.Conta.codigo, Turno_Sistema_Numero, "FECHADO", pagamento.Moeda.codigo, pagamento.Cambio.codigo };

                    /*GravarDados =*/
                    Conexao.ClienteSql.INSERT("Pagamentos", Campos, Valores);
                }
                catch (Exception ex) { throw new Exception("Erro a receber pagamento \n" + ex.Message + GravarDados); }
            }
            else
            {
                try
                {

                    String[] Campos = { "Descricao", "Data", "Hora", "CodForma", "Valor", "Tipo", "CodDocumento", "CodTurno", "Estado", "CodMoeda", "CodCambio" };
                    Object[] Valores = { pagamento.Descricao, pagamento.Data, Hora, pagamento.Forma.codigo, pagamento.Valor, "CREDITO", pagamento.Documento.codigo, pagamento.Conta.codigo, Turno_Sistema_Numero, "FECHADO", pagamento.Moeda.codigo, pagamento.Cambio.codigo };

                    /*GravarDados =*/
                    Conexao.ClienteSql.INSERT("Pagamentos", Campos, Valores);
                }
                catch (Exception ex) { throw new Exception("Erro a receber pagamento \n" + ex.Message + GravarDados); }
            }
            return GravarDados;
        }

        public string ReceberTroco(Pagamentos pagamento, int Turno_Sistema_Numero)
        {

            if (pagamento.Descricao.Equals("")) { throw new Exception("Informe a Descrição do pagamento"); return null; }
            if (pagamento.Valor == 0) { throw new Exception("Informe o Valor do Pagamento Invalcodigoo"); return null; }

            string Hora = DateTime.Now.ToShortTimeString();
            string GravarDados = null;
            try
            {

                String[] Campos = { "CodDocumento", "Descricao", "Data", "Hora", "CodForma", "Valor", "Tipo", "CodTurno", "Estado", "CodMoeda", "CodCambio" };
                Object[] Valores = { pagamento.Documento, pagamento.Descricao, pagamento.Data, Hora, 1, pagamento.Valor, "DEBITO", Turno_Sistema_Numero, "FECHADO", pagamento.Moeda.codigo, pagamento.Cambio.codigo };

                /*GravarDados =*/
                Conexao.ClienteSql.INSERT("Pagamentos", Campos, Valores);
            }
            catch (Exception ex) { throw new Exception("Erro a receber pagamento \n" + ex.Message + GravarDados); }

            return GravarDados;
        }

        public double Saldo_Conta(Guid Clientecodigo, bool admin)
        {

            Double Credito = 0;
            Double Debito = 0;
            Double Total = 0;
            string Criterio = " and Operacoes.Nome<> 'NOTA DE PAGAMENTO'";
            string Criterio2 = " and Operacoes.Nome<> 'RECIBO'";

            if (admin)
            {

                string SQL = null;
                object x = null;

                SQL = "SELECT Pagamentos.Data as DATA,Pagamentos.Hora as HORA,Pagamentos.Descricao as DESCRICAO, Pagamentos.Tipo AS TIPO, Pagamentos.Valor AS VALOR, Usuarios.Nome as USUARIO from Pagamentos";
                SQL += " join Turnos on Turnos.Codigo=Pagamentos.CodTurno join Usuarios on Usuarios.Codigo=Turnos.CodUsuario join Documentos on Documentos.Codigo=Pagamentos.CodDocumento join Operacoes on Operacoes.Codigo=Documentos.CodOperacao";
                SQL += " WHERE Documentos.CodEntcodigoade ='" + Clientecodigo + "' " + Criterio + "";
                x = Conexao.ClienteSql.SELECT(SQL);

                DataTable DtPagamentos = (DataTable)x;

                SQL = "SELECT Documentos.Data as DATA,Documentos.Hora as HORA,Operacoes.Nome as DESCRICAO,Operacoes.MovFin as TIPO, Documentos.Total as VALOR, Documentos.Codigo as NUMERO, Operacoes.Nome as OPERACAO, Usuarios.Nome as USUARIO from Documentos ";
                SQL += " LEFT OUTER JOIN Operacoes on Operacoes.Codigo=Documentos.CodOperacao join Usuarios on Usuarios.Codigo=Documentos.CodUsuario";
                SQL += " WHERE Documentos.CodEntcodigoade ='" + Clientecodigo + "' And Operacoes.Entcodigoade='CLIENTE' And Operacoes.Movfin='CREDITO' and Documentos.Estado like 'FECHADO' " + Criterio2 + "";
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

        public IEnumerable<MovimentosCaixaViewModel> ListarMovCaixa(string criterios)
        {

            var result = new List<MovimentosCaixaViewModel>();
            string SQL = "SELECT Pagamentos.codigo, Pagamentos.Data, Pagamentos.Hora, Pagamentos.Descricao, fPagamentos.Descricao as Forma, Entidades.Nome as Entidade, Pagamentos.Valor as VALOR, Pagamentos.Tipo as TIPO, Pagamentos.CodDocumento, Caixas.Descricao as Caixa, Bancos.Descricao as Banco, Pagamentos.Estado, Moedas.Sigla, Pagamentos.CodCambio from Pagamentos ";
            SQL += " join Documentos on Documentos.Codigo=Pagamentos.CodDocumento Left Join fPagamentos on Pagamentos.CodForma=fPagamentos.Codigo Left Join Entidades on Documentos.CodEntidade=Entidades.codigo Left Join Caixas on Pagamentos.CodCaixa=Caixas.codigo Left Join ContasBancarias on fPagamentos.CodConta=ContasBancarias.Codigo Left Join Bancos on ContasBancarias.CodBanco=Bancos.codigo left join Moedas on Moedas.Codigo=Pagamentos.CodMoeda";

            Object ob;
            try
            {
                if (!string.IsNullOrEmpty(criterios))
                {

                    SQL += " WHERE " + criterios + " order by Pagamentos.Codigo desc";
                    ob = Conexao.ClienteSql.SELECT(SQL);
                }
                else
                {
                    SQL = SQL + " order by Pagamentos.Codigo desc";
                    ob = Conexao.ClienteSql.SELECT(SQL);
                }

                result = DataTableHelper.DataTableToList<MovimentosCaixaViewModel>((DataTable)ob);

                //for (int i = 0; i < Dados.DtDados.Rows.Count; i++)
                //{
                //    if (Dados.DtDados.Rows[i]["Tipo"].ToString() == ("CREDITO")) Dados.Sal_Credito = Dados.Sal_Credito + double.Parse(Dados.DtDados.Rows[i]["Valor"].ToString());
                //    if (Dados.DtDados.Rows[i]["Tipo"].ToString() == ("DEBITO")) Dados.Sal_Debito = Dados.Sal_Credito + double.Parse(Dados.DtDados.Rows[i]["Valor"].ToString());
                //}

                //Dados.Sal_Total = Dados.Sal_Credito - Dados.Sal_Debito;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return result;
        }

        public IEnumerable<Caixas> Meus_Caixas()
        {
            List<Caixas> result = new List<Caixas>();
            DataTable DtCaixas = new DataTable();
            //if (int.Parse(Conexao.UsuarioPerfil.ToString()) > 1)
            //{
            //    //string SQL = "SELECT Caixas.Codigo,Caixas.Descricaofrom Caixas join AcessoCaixas on Caixas.Codigo=AcessoCaixas.CodCaixa";
            //    //SQL += " WHERE AcessoCaixas.CodUsuario='" + Conexao.UsuarioCodigo.ToString() + "'";
            //    //object x = Conexao.ClienteSql.SELECT(SQL);

            //    //DtCaixas = (DataTable)x;
            //}
            //else
            //{

            //}
            string SQL = "SELECT Caixas.Codigo , Caixas.Descricao from Caixas order by Caixas.Codigo";
            object x = Conexao.ClienteSql.SELECT(SQL);


            DtCaixas = (DataTable)x;

            result = DataTableHelper.DataTableToList<Caixas>(DtCaixas);
            return result;
        }

        public List<PagamentosViewModel> ListarPagamentos(string critarios)
        {
            DataTable DtDados = new DataTable();
            string[] campos = { "Pagamentos.Codigo As Numero", "Pagamentos.Data As Data", "Pagamentos.Descricao As Descricao", "fPagamentos.Descricao as Forma", "Pagamentos.Tipo As Tipo", "Pagamentos.Valor As Valor", "Moedas.Sigla As Sigla", "Pagamentos.Estado As Estado", "Pagamentos.CodCambio As Cambio" };
            string[] criterioJoin = { "fPagamentos on Pagamentos.CodForma = fPagamentos.Codigo", "Documentos on Documentos.Codigo=Pagamentos.CodDocumento", "Comissoes on Documentos.Codigo=Comissoes.CodDocumento", "Operacoes on Documentos.CodOperacao=Operacoes.Codigo", "Moedas on Moedas.Codigo=Pagamentos.CodMoeda" };
            string[] criterios2 = { critarios };

            Object ob = Conexao.ClienteSql.LEFTJOIN("Pagamentos", campos, criterioJoin, criterios2);
            try
            {
                DtDados = (DataTable)ob;
            }
            catch (Exception)
            {
                MessageBox.Show("Erro a Carregar Pagamentos\n" + (string)ob);
            }
            //MessageBox.Show(DtDados.Rows.Count.ToString());
            return DataTableHelper.DataTableToList<PagamentosViewModel>(DtDados);
        }

        public IEnumerable<Pagamentos> BuscarPagamentosEntidade(string crit)
        {
            throw new NotImplementedException();
        }

        public object GetCodLast()
        {
            var obj = Conexao.ClienteSql.SELECT("Select  MAX(codigo) As Codigo From Pagamentos");

            DataTable dtadados = (DataTable)obj;

            var result = Folha.Domain.Helpers.DataTableHelper.DataTableToList<Pagamentos>(dtadados).ToList();

            return result[0].codigo;
        }
        public int GetUltimoNumeroPagamentoRecibo()
        {
            var obj = Conexao.ClienteSql.SELECT("Select  MAX(NumeroOrdem) As Codigo From Pagamentos WHERE Descricao = 'PAGAMENTO DE FACTURA Nº'");

            DataTable dtadados = (DataTable)obj;

            var numero = 0;
            if (dtadados.Rows.Count > 0)
            {
                if (Equals(dtadados.Rows[0][0], DBNull.Value))
                {
                    numero = 1;
                }
                else
                {
                    numero = Convert.ToInt16(dtadados.Rows[0][0]);
                }
            }
            return numero;
        }
        public int GetUltimoNumeroPagamentoNotaCredito()
        {
            var obj = Conexao.ClienteSql.SELECT("Select  MAX(NumeroOrdem) As Codigo From Pagamentos WHERE Descricao LIKE '%Nota de Credito Para anulação%'");

            DataTable dtadados = (DataTable)obj;

            var numero = 0;
            if (dtadados.Rows.Count > 0)
            {
                if (Equals(dtadados.Rows[0][0], DBNull.Value))
                {
                    numero = 1;
                }
                else
                {
                    numero = Convert.ToInt16(dtadados.Rows[0][0]);
                }
            }
            return numero;
        }
        #region CRUD GENERICO
        public void Delete(Folha.Domain.ViewModels.Financeiro.PagamentosViewModel pagamento)
        {
            Db.Delete(pagamento);
        }

        public object Get(Folha.Domain.ViewModels.Financeiro.PagamentosViewModel pagamento)
        {
            return Db.GetById<Folha.Domain.ViewModels.Financeiro.PagamentosViewModel>(pagamento.codigo);
        }

        public Folha.Domain.ViewModels.Financeiro.PagamentosViewModel GetPorIdDocumento(int codDocumento)
        {
            return Db.GetEntities<Folha.Domain.ViewModels.Financeiro.PagamentosViewModel>("WHERE Pagamentos.CodDocumento = '" + codDocumento + "'").FirstOrDefault();
        }
        public List<Folha.Domain.ViewModels.Financeiro.PagamentosViewModel> GetAllPorIdDocumento(int codDocumento)
        {
            return Db.GetEntities<Folha.Domain.ViewModels.Financeiro.PagamentosViewModel>("WHERE Pagamentos.CodDocumento = '" + codDocumento + "'");
        }
        public List<Folha.Domain.ViewModels.Financeiro.PagamentosViewModel> GetAllCreditosAbertos(int CodCliente)
        {
            return Db.GetEntities<Folha.Domain.ViewModels.Financeiro.PagamentosViewModel>(" WHERE Documentos.CodEntidade = '" + CodCliente + "' AND Pagamentos.Estado = 'ABERTO' AND Tipo = 'CREDITO'");
        }
        public object GetAll(Folha.Domain.ViewModels.Financeiro.PagamentosViewModel pagamento)
        {
            return Db.GetEntities<Folha.Domain.ViewModels.Financeiro.PagamentosViewModel>();
        }

        public void Insert(Folha.Domain.ViewModels.Financeiro.PagamentosViewModel pagamento)
        {
            Db.Add(pagamento);
        }

        public void Update(Folha.Domain.ViewModels.Financeiro.PagamentosViewModel pagamento)
        {
            Db.Update(pagamento);
        }

        public List<Folha.Domain.ViewModels.Financeiro.PagamentosViewModel> GetMovFinDeDocumentosRecibo(DateTime dataInicio, DateTime datafim)
        {

            var criterio = " Pagamentos.Data between '" + dataInicio.ToString("yyyy-MM-dd") + "' and " +
                "'" + datafim.ToString("yyyy-MM-dd") + "' And " +
                "(Documentos.Estado != 'ABERTO' OR Documentos.Estado != 'PENDENTE') And (Operacoes.APP = 'FR' OR Operacoes.APP = 'VD') ";
            //+" And Operacoes.Entidade = 'CLIENTE'";

            try
            {
                return Db.GetEntities<Folha.Domain.ViewModels.Financeiro.PagamentosViewModel>(" WHERE " + criterio);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        public decimal GetTotalMovFinDeDocumentosRecibo(DateTime dataInicio, DateTime datafim, string movFin)
        {
            var criterio = " Pagamentos.Data between ('" + dataInicio.ToString("yyyy-MM-dd") + "' and " +
                   "'" + datafim.ToString("yyyy-MM-dd") + "') And " +
                   "Documentos.Estado != 'ABERTO' And Documentos.Estado != 'PENDENTE' And Documentos.Estado != 'ANULADO' And " +
                   "(Operacoes.APP = 'FR' OR Operacoes.APP = 'VD') And " +
                   //" Operacoes.Entidade = 'CLIENTE' And " +
                   " Pagamentos.Tipo = '" + movFin + "' "; ;

            DataTable DtDados = new DataTable();

            try
            {
                string SQL = "SELECT Sum(Pagamentos.Valor) from Pagamentos INNER JOIN Operacoes On Documentos.CodOperacao = Operacoes.codigo " +
                                                                " INNER JOIN Documentos On Pagamentos.CodDocumento = Documentos.codigo";

                if (!string.IsNullOrEmpty(criterio))
                {
                    SQL = SQL + " Where " + criterio;
                }


                //SQL += " Order by Documentos.Codigo desc ";
                var ob = Conexao.ClienteSql.SELECT(SQL);
                if (NaoTipoString(ob))
                {

                    DtDados = (DataTable)ob;
                    if (DtDados.Rows.Count == 0)
                    {
                        return 0.0m;
                    }
                    return Convert.ToDecimal(DtDados.Rows[0][0]);
                }
                else
                {
                    return 0.0m;
                }

            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        public IEnumerable<PagamentosViewModel> CarregarPagamentos(string crit)
        {
            throw new NotImplementedException();
        }

        public List<Folha.Domain.ViewModels.Financeiro.PagamentosViewModel> GetAllCriditoByDoc(int codDocumento)
        {
            return Db.GetEntities<Folha.Domain.ViewModels.Financeiro.PagamentosViewModel>(" WHERE Pagamentos.CodDocumento = '" + codDocumento + "' AND Pagamentos.Tipo = 'CREDITO'");
        }
        public List<Folha.Domain.ViewModels.Financeiro.PagamentosViewModel> GetAllByDoc(int codDocumento, string movFin)
        {
            return Db.GetEntities<Folha.Domain.ViewModels.Financeiro.PagamentosViewModel>(" WHERE Pagamentos.CodDocumento = '" + codDocumento + "' AND Pagamentos.Tipo = '"+ movFin + "'");
        }
        #endregion
    }
}
