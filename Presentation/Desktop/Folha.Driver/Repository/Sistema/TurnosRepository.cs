using System;
using System.Collections.Generic;
using Folha.Domain.Models.Db;
using Folha.Domain.ViewModels.Frame.Sistema;
using Folha.Driver.Repository;
using Folha.Domain.Interfaces.Repository.Sistema;
using System.Data;
using Folha.Domain.Helpers;
using Folha.Domain.ViewModels.Frame.Financeiro;
using Folha.Domain.Models.Sistema;
using Folha.Domain.ViewModels.Sistema;
using System.Linq;

namespace Folha.Driver.Repository.Data.Repositories.Sistema
{
    public class TurnosRepository : RepositoryBase<DbDTO>, ITurnosRepository

    {
       
        public bool ContemTurnosComCaixasNulos(int codTurno)
        {
            DataTable tabelaTurno = (DataTable)Conexao.ClienteSql.SELECT(" Select * From Turnos Where Confirmado = 'NÃO' and Codigo ='" + codTurno + "'");

            return tabelaTurno.Rows.Count > 0;
        }
        public IEnumerable<TurnosVendedoresViewModel> ListarTurnoVendedores(string criterios)
        {

            DataTable DtDados = new DataTable();
            try
            {
                string SQL;
         
                if (!string.IsNullOrEmpty(criterios))
                {
                    SQL = "SELECT Turnos.Codigo as Codigo, " +
                        "Turnos.Estado as Estado," +
                        " Usuarios.Nome as Usuario," +
                        " Turnos.DataAbertura, " +
                        " Turnos.DataFecho as Fecho," +
                        " Turnos.SaldoInicial as Inicial," +
                        " Turnos.SaldoInformado as Informado," +
                        " Turnos.SaldoVendas as Vendas, " +
                        "Turnos.SaldoTotal as Total, " +
                        "Turnos.QuebraCaixa as Quebra, " +
                        "Turnos.CodUsuario,Caixas.Descricao as Caixa," +
                        "Usuarios.Nome as Supervisor," +
                        " Turnos.DataConfirmacao," +
                        "Turnos.Confirmado " +
                        " from Turnos ";
                    SQL += " Left Outer Join Caixas on Turnos.CodCaixa=Caixas.codigo ";
                    SQL += " Left Outer Join Usuarios on Turnos.CodUsuario=Usuarios.Codigo Where Usuarios.Nome Like '" + criterios + "%' Order by Codigo Desc";

                    var ob = Conexao.ClienteSql.SELECT(SQL);
                    DtDados = (DataTable)ob;
                    var result = DataTableHelper.DataTableToList<TurnosVendedoresViewModel>(DtDados);
                    return result;
                }
                else
                {
                    SQL = "SELECT Turnos.Codigo as Codigo," +
                        " Turnos.Estado as Estado," +
                        " Usuarios.Nome as Usuario," +
                        " Turnos.DataAbertura as Abertura, " +
                        " Turnos.DataFecho as Fecho, " +
                        "Turnos.SaldoInicial as Inicial," +
                        " Turnos.SaldoInformado as Informado," +
                        " Turnos.SaldoVendas as Vendas," +
                        " Turnos.SaldoTotal as Total," +
                        " Turnos.QuebraCaixa as Quebra," +
                        " Turnos.CodUsuario," +
                        "Caixas.Descricao as Caixa," +
                        "Usuarios.Nome as Supervisor," +
                        " Turnos.DataConfirmacao," +
                        "Turnos.Confirmado " +
                        " from Turnos ";
                    SQL += " Left Outer Join Caixas on Turnos.CodCaixa=Caixas.codigo ";
                    SQL += " Left Outer Join Usuarios on Turnos.CodUsuario=Usuarios.Codigo Order by Codigo Desc";

                    var ob = Conexao.ClienteSql.SELECT(SQL);
                    DtDados = (DataTable)ob;
                    var result = DataTableHelper.DataTableToList<TurnosVendedoresViewModel>(DtDados);
                    return result;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar Turnos\n" + ex.Message);
            }
        }

        public IEnumerable<Turnos> ListarTurno()
        {
            DataTable DtDados = new DataTable();
            try
            {
  
                var ob = Conexao.BuscarTabela("Turnos");
                DtDados = (DataTable)ob;
                var result = DataTableHelper.DataTableToList<Turnos>(DtDados);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar Turnos\n" + ex.Message);
            }
        }

        public int AbrirTurno(decimal saldoInicial)
        {
            try
            {
                double valor = 0;
                String[] Campos = { "CodUsuario", "DataAbertura", "SaldoInicial", "Estado", "SaldoInformado", "SaldoTotal", "SaldoVendas", "QuebraCaixa", "CodCaixa" , "Confirmado" };
                Object[] Valores = { UtilidadesGenericas.UsuarioCodigo, DateTime.Now, saldoInicial, "ABERTO", valor, valor, valor, valor, 1, "NÃO"};
                Conexao.ClienteSql.INSERT("Turnos", Campos, Valores);
                UtilidadesGenericas.Alterou = true;
                UtilidadesGenericas.EstadoTurnoSistema = true;
                return 0;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        public void FecharTurno(decimal SaldoTotal, decimal Informado, decimal SaldoVendas, decimal SaldoHospedagem, int CodTurno)
        {
            decimal QuebraCaixa = SaldoTotal - Informado;
            try
            {
                String[] Campos = { "DataFecho", "Estado", "SaldoInformado", "SaldoTotal", "SaldoVendas", "SaldoHospedagem", "QuebraCaixa" };
                Object[] Valores = { DateTime.Now, "FECHADO", Informado, SaldoTotal, SaldoVendas, SaldoHospedagem, QuebraCaixa };
                string[] criterios = { "Codigo='" + CodTurno + "'" };
                Conexao.ClienteSql.UPDATE("Turnos", Campos, Valores, criterios);

                UtilidadesGenericas.Alterou = true;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        public string VerificaEstadoDoTurno(int usuarioID)
        {
            var listTurno = (List<TurnosViewModel>)GetAll(new TurnosViewModel());
            var turno = listTurno.Where(t => t.CodUsuario == usuarioID).LastOrDefault();
            Db.GetEntities<TurnosViewModel>(" WHERE CodUsuario = '" + usuarioID + "'");
            if (Equals(turno, null))
            {
                return "FECHADO";
            }
            Db.GetEntities<TurnosViewModel>(" WHERE CodUsuario = '" + usuarioID + "'");
            return turno.Estado;
        }
        public int BuscaCodigoTurno(int usuarioID)
        {
            var listTurno = (List<TurnosViewModel>)GetAll(new TurnosViewModel());
            var turno = listTurno.Where(t => t.CodUsuario == usuarioID).LastOrDefault();

            return !Equals(turno, null) && turno.Estado == "ABERTO"? turno.codigo : 0;
        }
        public void ConfirmarTurno(int codCaixa, int codSuperVisor, int codTurno)
        {
            string[] campos2 = { "CodCaixa", "CodSuperVisor", "DataConfirmacao" , "Confirmado" };
            object[] valores2 = { codCaixa.ToString(), codSuperVisor.ToString(), DateTime.Now, "SIM" };
            string cri = "codigo='" + codTurno + "'";
            Conexao.ClienteSql.UPDATE("Turnos", campos2, valores2, cri);
        } 

        #region CRUD GENERICO
        public void Delete(TurnosViewModel tabela)
        {
            Db.Delete(tabela);
        }

        public object Get(TurnosViewModel tabela)
        {
            return Db.GetById<TurnosViewModel>(tabela.codigo);
        }

        public object GetAll(TurnosViewModel tabela)
        {
            return Db.GetEntities<TurnosViewModel>();
        }

        public void Insert(TurnosViewModel tabela)
        {
            Db.Add(tabela);
        }

        public void Update(TurnosViewModel tabela)
        {
            Db.Update(tabela);
        }
        #endregion
    }
}
