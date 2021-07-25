using System;
using System.Data;
using System.Collections.Generic;
using Folha.Domain.Models.Financeiro;
using Folha.Driver.Repository;
using Folha.Domain.Models.Db;
using Folha.Domain.Interfaces.Repository.Financeiro;
using System.Linq;
using Folha.Domain.ViewModels.Frame.Financeiro;
using Folha.Domain.Helpers;
using Folha.Domain.ViewModels.Documentos;
using Folha.Domain.Enuns.Documentos;
using Folha.Domain.ViewModels.Report;

namespace Folha.Driver.Repository.Data.Repositories.Financeiro
{
    public class CaixaRepository : RepositoryBase<DbDTO>, ICaixasRepository
    {

        public IEnumerable<Caixas> Listar(string criterios)
        {
            var result = new List<Caixas>();

            DataTable dtCaixa = new DataTable();
            string[] tabelas = { "Caixas" };
            string[] campos = { "codigo", "Descricao" };
            string[] cri = { "Descricao Like '" + criterios + "%'" };

            Object ob = Conexao.ClienteSql.SELECT(tabelas, campos, cri);
            try
            {
                result = Folha.Domain.Helpers.DataTableHelper.DataTableToList<Caixas>((DataTable)ob);
                return result;
            }
            catch (Exception)
            {
                throw new Exception("Erro a Carregar a Lista de Unidades Caixas\n");
            }
        }

        public List<CaixaViewModel> BuscarTotal(int usuarioID, string turnoID, string Sigla, string comissionarioID)
        {
            List<CaixaViewModel> caixas = new List<CaixaViewModel>();
            try
            {
                TurnoActualViewModel caixa = LerTurnoActual(usuarioID, turnoID);
                string SQL = string.Empty;

                if (string.IsNullOrEmpty(comissionarioID)) SQL = "select Operacoes.Nome, sum(Documentos.Total) as Total from Documentos join Operacoes on Operacoes.codigo = Documentos.CodOperacao"
                              + " where Documentos.CodTurno='" + turnoID + "' and Operacoes.MovFin!='ISENTO' and Documentos.Estado='FECHADO' group by Operacoes.Nome ORDER BY Operacoes.Nome";

                else SQL = "select Operacoes.Nome, sum(Documentos.Total) as Total from Documentos join Operacoes on Operacoes.codigo = Documentos.CodOperacao join comissoes "
                             + " where Documentos.CodTurno='" + turnoID + "' and Operacoes.MovFin!='ISENTO' and Documentos.Estado='FECHADO' And Comissoes.CodEntidade = '" + comissionarioID + "' group by Operacoes.Nome ORDER BY Operacoes.Nome";

                var objTable = Conexao.ClienteSql.SELECT(SQL);
                DataTable TabeleOperacoes = (DataTable)objTable;

               var formas =  buscarFormas(caixa.codigo.ToString());

                caixas.Add(new CaixaViewModel( "Nº", caixa.codigo.ToString()));
                caixas.Add(new CaixaViewModel("USUÁRIO", caixa.NOME));
                caixas.Add(new CaixaViewModel("ESTADO", caixa.ESTADO));
                caixas.Add(new CaixaViewModel("DATA ABERTURA", caixa.ABERTURA.ToShortDateString()));
                if (UtilidadesGenericas.InEnumStdDoc(caixa.ESTADO) == TipoEstadoDocumento.FECHADO)
                {
                    caixas.Add(new CaixaViewModel("DATA FECHO", caixa.FECHO.ToShortDateString()));

                }
                caixas.Add(new CaixaViewModel("SALDO INÍCIAL", caixa.INICIAL.ToString("N2") + " " + Sigla));

                for (int i = 0; i < TabeleOperacoes.Rows.Count; i++)
                {
                    caixas.Add(new CaixaViewModel(TabeleOperacoes.Rows[i]["Nome"].ToString(), double.Parse(TabeleOperacoes.Rows[i]["Total"].ToString()).ToString("N2") + " " + Sigla));
                }
                for (int x = 0; x < formas.Count; x++)
                {
                    caixas.Add(new CaixaViewModel(formas[x].Descricao + " (" + formas[x].Tipo+ ") ", double.Parse(formas[x].TOTAL.ToString("N2")) + " " + formas[x].Sigla));
                }
                caixas.Add(new CaixaViewModel("SALDO TOTAL", getTotal(formas, caixa.TOTAL) + " " + Sigla));
                caixas.Add(new CaixaViewModel("SALDO INFORMADO", caixa.INFORMADO.ToString("N2") + " " + Sigla));
                caixas.Add(new CaixaViewModel("QUEBRA DE CAIXA", caixa.QUEBRA.ToString("N2") + " " + Sigla));
                return caixas;
            }
            catch (Exception ex)
            {
               throw new Exception("Erro a carregar totais " + ex.Message);
            }
          
        }

        private string getTotal(List<PagamentosViewModel> formas, decimal total)
        {
            decimal newTotal = 0.0m;
            decimal saldoDebito = 0.0m;
            decimal saldoCredito= 0.0m;
            if (total == 0)
            {
                foreach (var item in formas)
                {
                    if (item.Tipo.Contains("DEBITO"))
                    {
                        saldoDebito += (decimal)item.TOTAL;
                    }
                    else if (item.Tipo.Contains("CREDITO"))
                    {
                        saldoCredito += (decimal)item.TOTAL;
                    }
                }
            }
            else
            {
                return total.ToString("N2");
            }
            newTotal = saldoCredito - saldoDebito;
            return newTotal.ToString("N2");
        }

        private List<PagamentosViewModel> buscarFormas( string Numero)
        {
            List<PagamentosViewModel> pagamentos = new List<PagamentosViewModel>();
            try
            {
                string SQL = "SELECT Moedas.Descricao As Descricao, Pagamentos.Tipo As Tipo, Moedas.Sigla As Sigla, SUM(Pagamentos.Valor) AS TOTAL FROM Pagamentos JOIN Moedas ON Moedas.codigo=Pagamentos.CodMoeda"
                + " WHERE Pagamentos.CodTurno='" + Numero + "' GROUP BY Moedas.Descricao, Pagamentos.Tipo, Moedas.Sigla";

                object obj = Conexao.ClienteSql.SELECT(SQL);
                DataTable dtFornmas = (DataTable)obj;

                pagamentos = DataTableHelper.DataTableToList<PagamentosViewModel>(dtFornmas);
                return pagamentos;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao carregar formas \n" + ex);
            }
           
        }
        public TurnoActualViewModel LerTurnoActual(int usuarioID, string turnoID)
        {
            Object obj;
            DataTable GradeDados = new DataTable();

            GradeDados.Rows.Clear();
            try
            {

                string[] campos = { "Turnos.codigo as codigo", "Turnos.Estado AS ESTADO", "Turnos.CodUsuario AS CODUSUARIO", "Turnos.QuebraCaixa AS QUEBRA", "Usuarios.Nome AS NOME", "Turnos.DataAbertura AS ABERTURA", "Turnos.DataFecho AS FECHO", "Turnos.SaldoInicial AS INICIAL", "Turnos.SaldoInformado AS INFORMADO", "Turnos.SaldoVendas AS VENDAS", "Turnos.SaldoHospedagem as HOSPEDAGEM", "Turnos.SaldoTotal AS TOTAL " };
                string tabelasTodos = "Turnos";
                string[] criterioTodos = { "Usuarios on Turnos.CodUsuario=Usuarios.codigo" };
                string[] criterio = { "Turnos.CodUsuario='" + usuarioID + "' order by Turnos.codigo desc" };
                string[] criterio2 = { "Turnos.codigo='" + turnoID + "'" };
                if (turnoID.ToString() == "")
                {
                    obj = Conexao.ClienteSql.LEFTJOIN(tabelasTodos, campos, criterioTodos, criterio);

                }
                else
                {
                    obj = Conexao.ClienteSql.LEFTJOIN(tabelasTodos, campos, criterioTodos, criterio2);

                }

                GradeDados = (DataTable)obj;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro A Carregar os Turnos\n " + ex.Message);
            }
            TurnoActualViewModel turno = new TurnoActualViewModel();
            if (GradeDados.Rows.Count > 0)
            {
                try
                {
                    //turno.Numero = int.Parse(GradeDados.Rows[0][0].ToString()).ToString();
                    //turno.Estado = GradeDados.Rows[0]["ESTADO"].ToString();
                    //turno.DataAbertura = Convert.ToDateTime(GradeDados.Rows[0]["ABERTURA"]);
                    //turno.Nome = GradeDados.Rows[0]["NOME"].ToString();
                    //turno.DataFecho = Convert.ToDateTime(GradeDados.Rows[0]["FECHO"].ToString());
                    //turno.SaldoInicial = decimal.Parse(GradeDados.Rows[0]["INICIAL"].ToString());
                    //turno.SaldoInformado = decimal.Parse(GradeDados.Rows[0]["INFORMADO"].ToString());
                    //turno.SaldoTotal = decimal.Parse(GradeDados.Rows[0]["TOTAL"].ToString());
                    //turno.SaldoVendas = decimal.Parse(GradeDados.Rows[0]["VENDAS"].ToString());
                    //turno.SaldoQuebra = decimal.Parse(GradeDados.Rows[0]["QUEBRA"].ToString());
                    //turno.CodUsuario = int.Parse(GradeDados.Rows[0]["CODUSUARIO"].ToString());
                    //turno.Estado = "ABERTO";
                    var turnos = DataTableHelper.DataTableToList<TurnoActualViewModel>(GradeDados);
                    turno = turnos[0];
                    //tabVendas.Visible = true;
                    //tabPagamentos.Visible = true;
                    //tabProdutos.Visible = true;
                }
                catch { }
            }
            else
            {
                //caixa.Estado = "FECHADO";
                //tabVendas.Visible = false;
                //tabPagamentos.Visible = false;
                //tabProdutos.Visible = false;
                //tbProdutosVendidos.Visible = false;
                //tbHospedagem.Visible = false;

            }

            if (turno.ESTADO == "FECHADO" && turnoID== "")
            {
                //Super.Visible = false;
                //CmdFechar.Enabled = false;
                //tabVendas.Visible = false;
                //tbHospedagem.Visible = false;
                //tabPagamentos.Visible = false;
                //tbProdutosVendidos.Visible = false;
                //tabProdutos.Visible = false;
                //cmdAbrir.Enabled = true;
                //cmdImprimir.Enabled = false;
                //CmdConfirmar.Enabled = false;
                //if (Sistema == true)
                //{
                //    Conexao.Busca.Turno_Sistema_Estado = "FECHADO";
                //}
            }

            if (turno.ESTADO == "ABERTO")
            {
                //Super.Visible = true;
                //CmdFechar.Enabled = true;
                //cmdAbrir.Enabled = false;
                //cmdImprimir.Enabled = false;
                //tbProdutosVendidos.Visible = true;
                //CmdConfirmar.Enabled = false;
                //Geral.Busca.Turno_Sistema_Numero = Numero;

                //if (Sistema == true)
                //{
                //    Geral.Busca.Turno_Sistema_Estado = "ABERTO";
                //    Geral.Busca.Turno_Sistema_Numero = Numero;
                //}


            }

            return turno;
        }

        public IEnumerable<Caixas> Meus_Caixas()
        {
            DataTable DtCaixas = new DataTable();
            try
            {
                if (UtilidadesGenericas.UsuarioCodigo > 1)
                {
                    string SQL = "SELECT Caixas.Codigo,Caixas.Descricao from Caixas join AcessoCaixas on Caixas.Codigo=AcessoCaixas.CodCaixa";
                    SQL += " WHERE AcessoCaixas.CodUsuario='" + UtilidadesGenericas.UsuarioCodigo + "'";
                    var ob = Conexao.ClienteSql.SELECT(SQL);

                    DtCaixas = (DataTable)ob;
                    var result = DataTableHelper.DataTableToList<Caixas>(DtCaixas);
                    return result;
                }
                else
                {
                    string SQL = "SELECT Caixas.Codigo,Caixas.Descricao from Caixas";
                    var ob = Conexao.ClienteSql.SELECT(SQL);
                    DtCaixas = (DataTable)ob;
                    var result = DataTableHelper.DataTableToList<Caixas>(DtCaixas);
                    return result;
                }

            }
            catch (Exception ex) { throw new Exception("Erro a Carregar Caixas \n" + ex.Message); }

        }
        #region CRUD GENÉRICO
        public void Insert(Caixas entity)
        {
            try
            { 
            DbDTO dto = new DbDTO()
            {
                Nome = "Caixas",
                Campos = new string[] { "Descricao" },
                Valores = new Object[] { entity.Descricao }
            };
            Conexao.ClienteSql.INSERT(dto.Nome, dto.Campos, dto.Valores);

            }catch (Exception) { throw new Exception("Erro ao Cadastrar Caixa"); }
        }

        public object Get(Caixas entity)
        {
            var obj = Conexao.ClienteSql.SELECT("SELECT * FROM Caixas Where codigo = " + entity.codigo);

            DataTable dtadados = (DataTable)obj;

            var result = DataTableHelper.DataTableToList<Caixas>(dtadados)[0];

            return result;
        }

        public object GetAll(Caixas entity)
        {
            var result = new List<Bancos>();

            var obj = Conexao.ClienteSql.SELECT("SELECT * FROM Caixas");

            DataTable dtadados = (DataTable)obj;

            result = Folha.Domain.Helpers.DataTableHelper.DataTableToList<Bancos>(dtadados);

            return result;
        }

        public void Update(Caixas entity)
        {
            try
            {
                DbDTO dto = new DbDTO()
            {
                Nome = "Caixas",
                Campos = new string[] { "codigo", "Descricao" },
                Valores = new Object[] { entity.codigo, entity.Descricao }

            };
            Conexao.ClienteSql.UPDATE(dto.Nome, dto.Campos, dto.Valores, "");
        }catch (Exception) { throw new Exception("Erro ao Cadastrar Caixa");
    }
}

        public void Delete(Caixas entity)
        {
            DbDTO dto = new DbDTO()
            {
                Nome = "Caixas",
                Campos = new string[] { "codigo", "Descricao" },
                Valores = new Object[] { entity.codigo, entity.Descricao }

            };
            Conexao.ClienteSql.DELETE("Caixas", "codigo ='" + entity.codigo + "'");
        }

        public void UpdateCaixa(Caixas Caixa, string criterios)
        {

                DbDTO dto = new DbDTO()
                {
                    Nome = "Caixas",
                    Campos = new string[] {  "Descricao" },
                    Valores = new Object[] {  Caixa.Descricao }

                };
                Conexao.ClienteSql.UPDATE(dto.Nome, dto.Campos, dto.Valores, "codigo ='" + criterios + "'");
            
        }

        public double buscarSaldoCaixa(int codCaixa)
        {
            DataTable dtPagamento = Conexao.BuscarTabela_com_Criterio("Pagamentos", "CodCaixa='" + codCaixa + "'");

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
       
        public DataViewModel RetortaDataSaldoCaixa()
        {
            string SQL = "select Min([Data]) as DataInicial,Max([Data]) as DataFinal from Pagamentos WHERE CodCaixa>=1";
            DataViewModel result;
            var obj = Conexao.ClienteSql.SELECT(SQL);
            DataTable dtPagamento = (DataTable)obj;
            string dtInicial = dtPagamento.Rows[0]["DataInicial"].ToString();
            string dtFinal = dtPagamento.Rows[0]["DataFinal"].ToString();

            if (!string.IsNullOrEmpty(dtInicial) && !string.IsNullOrEmpty(dtFinal))
            {
                result = new DataViewModel() { DataInicial = Convert.ToDateTime(dtInicial), DataFinal = Convert.ToDateTime(dtInicial) };
                return result;
            }
            else { return result = null; }
        }
        #endregion


    }

}

