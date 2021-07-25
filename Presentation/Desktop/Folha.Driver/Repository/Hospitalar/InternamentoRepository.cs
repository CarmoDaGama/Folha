using Folha.Driver.Repository.Data;
using Folha.Driver.Repository;
using Folha.Domain.Models.Hospitalar;
using Folha.Domain.ViewModels.Hospitalar;
using Folha.Domain.Models.Db;
using Folha.Domain.Helpers;
using Folha.Domain.Interfaces.Repository.Hospitalar;
using System;
using System.Collections.Generic;
using System.Data;
using Folha.Domain.Models.Financeiro;

namespace Folha.Driver.Repository.Hospitalar
{
    public class InternamentoRepository : RepositoryBase<DbDTO>, IInternamentoRepository
    {
       
        public MovHospitalarViewModel Gravar(MovHospitalarViewModel hospital)
        {
            string tabela = "MovHospitalar";
            string[] campos = { "CodDocumento", "CodQuartosHospitalar", "CodTarifaHospitalar", "Checkin", "Horas", "Quantidade", "Preco" };
            Object[] valores = { hospital.CodDocumento, hospital.CodQuartosHospitalar, hospital.CodTarifaHospitalar, hospital.Checkin,  hospital.Horas, hospital.Quantidade, hospital.Preco };
            string[] critX = { "Codigo = '" + hospital.Codigo + "'" };
            Conexao.ClienteSql.INSERT(tabela, campos, valores);
            return hospital;
        }
        public MovHospitalarViewModel LerMovHospi(MovHospitalarViewModel hospital)
        {
            string[] campos = { " MovHospitalar.Codigo", " MovHospitalar.CodDocumento", " QuartosHospitalar.Descricao as Quarto", "TarifaHospitalar.Descricao " +
                    "as Tarifa", "MovHospitalar.Checkin", " MovHospitalar.CheckOut", " MovHospitalar.Horas", "MovHospitalar.Quantidade", " MovHospitalar.Horas", "MovHospitalar.Preco", "MovHospitalar.Total"};
            string tabelas = "MovHospitalar";
            string[] CriteriosTodos = { "MovHospitalar on MovHospitalar.Codigo = MovHospitalar.CodQuartosHospitalar" };
            string[] criterios = { "MovHospitalar.CodDocumento='" + hospital + "'" };
            var ob = Conexao.ClienteSql.INNERJOIN(tabelas, campos, CriteriosTodos, criterios);
            return hospital;
        }      
        public List<CamasQuartosHospitalarViewModel> GetCamas(int codQuartos)
        {
            string SQL = " SELECT CamasQuartosHospitalar.Codigo, CamasQuartosHospitalar.CodQuartosHospitalar, CamasHospitalar.Descricao,TiposCamasHospitalar.Descricao as Tipo,  CamasQuartosHospitalar.CodCamasHospitalar from CamasQuartosHospitalar ";
            SQL += " Left Outer Join CamasHospitalar on CamasHospitalar.Codigo= CamasQuartosHospitalar.CodCamasHospitalar ";
            SQL += " Left Outer Join TiposCamasHospitalar on TiposCamasHospitalar.Codigo= CamasHospitalar.CodTiposCamasHospitalar ";
            SQL += " WHERE  CamasQuartosHospitalar.CodQuartosHospitalar='" + codQuartos + "' and CamasHospitalar.Ocupado = 'Não'";
            Object obj = Conexao.ClienteSql.SELECT(SQL);
            DataTable dtadados = (DataTable)obj;
            var result = DataTableHelper.DataTableToList<CamasQuartosHospitalarViewModel>(dtadados);
            return result;
        }
        public PacienteInternadoViewModel GravarInternado(PacienteInternadoViewModel paciente)
        {
            string tabela = "PacienteInternado";
            string[] campos = { "CodDocumento", "CodQuartosHospitalar", "CodCamasHospitalar", "Estado", "DataEntrada", "DataSaida", "Valor"};
            Object[] valores = {  paciente.CodQuartosHospitalar, paciente.CodCamasHospitalar, paciente.Estado, paciente.DataEntrada, paciente.DataSaida, paciente.Valor };
            string[] critX = { "Codigo = '" + paciente.Codigo + "'" };
            Conexao.ClienteSql.INSERT(tabela, campos, valores);
            return paciente;
        }
        public void DeleteInternado(PacienteInternado paciente)
        {
            DbDTO dto = new DbDTO()
            {
                Nome = "PacienteInternado"
            };
            Conexao.ClienteSql.DELETE(dto.Nome, "Codigo ='" + paciente.Codigo + "'");
        }
        public IEnumerable<MovHospitalar> Listar(string criterios)
        {
            DataTable DtDados = new DataTable();
            try
            {
                string SQL = "SELECT  MovHospitalar.Codigo, MovHospitalar.CodDocumento, MovHospitalar.CodQuartosHospitalar, QuartosHospitalar.Descricao as Quarto," +
                    " TarifaHospitalar.Descricao as Tarifa, MovHospitalar.Checkin,  MovHospitalar.Horas, " +
                    "MovHospitalar.Quantidade,MovHospitalar.Preco FROM MovHospitalar  Left Outer Join QuartosHospitalar" +
                    " on MovHospitalar.CodQuartosHospitalar = QuartosHospitalar.Codigo Left Outer Join TarifaHospitalar on MovHospitalar." +
                    "CodTarifaHospitalar = TarifaHospitalar.Codigo";
                if (string.IsNullOrEmpty(criterios))
                {
                    var ob = Conexao.ClienteSql.SELECT(SQL);
                    DtDados = (DataTable)ob;
                    var result = DataTableHelper.DataTableToList<MovHospitalar>(DtDados);
                    return result;
                }
                else
                {
                    SQL += " Where MovHospitalar.CodDocumento='" + criterios + "'";
                    var ob = Conexao.ClienteSql.SELECT(SQL);
                    DtDados = (DataTable)ob;
                    var result = DataTableHelper.DataTableToList<MovHospitalar>(DtDados);
                    return result;
                }
            }
            catch (Exception) { throw new Exception("Erro ao Listar "); }
        }
        public IEnumerable<TiposQuartosHospitalarViewModel> ListaTipoQuarto(string criterios)
        {
            var result = new List<TiposQuartosHospitalarViewModel>();
            string[] tabelas = { "TiposQuartosHospitalar" };
            string[] campos = { "Codigo", "Descricao" };
            string[] cri = { "Descricao Like '%" + criterios + "%'" };
            var ob = Conexao.ClienteSql.SELECT(tabelas, campos, cri);
            DataTable dtadados = (DataTable)ob;
            result = DataTableHelper.DataTableToList<TiposQuartosHospitalarViewModel>((DataTable)dtadados);
            return result;
        }
        public IEnumerable<TarifaHospitalarViewModel> ListaTarifa(int criterios)
        {
            DataTable DtDados = new DataTable();
            try
            {
                string SQL = "SELECT *FROM TarifaHospitalar";
                SQL += " Where TarifaHospitalar.CodTiposQuartosHospitalar='" + criterios + "'";
                var ob = Conexao.ClienteSql.SELECT(SQL);
                DtDados = (DataTable)ob;
                var result = DataTableHelper.DataTableToList<TarifaHospitalarViewModel>(DtDados);
                return result;
            }
            catch (Exception) { throw new Exception("Erro ao Listar "); }
        }
        public IEnumerable<QuartosHospitalarViewModel> ListaQuarto(int criterios)
        {
            DataTable DtDados = new DataTable();
            try
            {
                string SQL = "SELECT *FROM QuartosHospitalar";
                SQL += " Where QuartosHospitalar.CodTiposQuartosHospitalar='" + criterios + "'";
                var ob = Conexao.ClienteSql.SELECT(SQL);
                DtDados = (DataTable)ob;
                var result = DataTableHelper.DataTableToList<QuartosHospitalarViewModel>(DtDados);
                return result;
            }
            catch (Exception) { throw new Exception("Erro ao Listar "); }
        }
        public IEnumerable<PacienteInternado> ListarInternado(string paciente)
        {

            string SQL = " SELECT PacienteInternado.Codigo, PacienteInternado.CodDocumento, PacienteInternado.CodQuartosHospitalar, PacienteInternado.CodCamasHospitalar, Entidades.Nome as Paciente, QuartosHospitalar.Descricao as Quarto, CamasHospitalar.Descricao  as Cama, PacienteInternado.Estado, PacienteInternado.DataEntrada, PacienteInternado.DataSaida, PacienteInternado.Valor, PacienteInternado.Estado from PacienteInternado ";
            SQL += " lEFT Join QuartosHospitalar on QuartosHospitalar.Codigo= PacienteInternado.CodQuartosHospitalar ";
            SQL += " lEFT Join CamasHospitalar on CamasHospitalar.Codigo= PacienteInternado.CodCamasHospitalar ";
            SQL += " lEFT Join Pacientes on Pacientes.Codigo = PacienteInternado.CodPaciente ";
            SQL += " lEFT Join EntidadesPessoa on EntidadesPessoa.CodEntidade = Pacientes.CodPessoa ";
            SQL += " lEFT Join Entidades on Entidades.Codigo = EntidadesPessoa.CodEntidade ";
            SQL += " WHERE  PacienteInternado.CodDocumento ='" + paciente + "'";

            Object obj = Conexao.ClienteSql.SELECT(SQL);
            DataTable dtadados = (DataTable)obj;
            var result = DataTableHelper.DataTableToList<PacienteInternado>(dtadados);
            return result;
        }
        public IEnumerable<PacienteInternado> ListarTudo(string paciente)
        {
            DataTable DtDados = new DataTable();
            string SQL = " SELECT PacienteInternado.Codigo, PacienteInternado.CodDocumento, Entidades.Nome as Paciente, QuartosHospitalar.Descricao as Quarto, CamasHospitalar.Descricao  as Cama, PacienteInternado.Estado, PacienteInternado.DataEntrada, PacienteInternado.DataSaida from PacienteInternado ";
            SQL += " lEFT Join QuartosHospitalar on QuartosHospitalar.Codigo= PacienteInternado.CodQuartosHospitalar ";
            SQL += " lEFT Join CamasHospitalar on CamasHospitalar.Codigo= PacienteInternado.CodCamasHospitalar ";
            SQL += " lEFT Join Pacientes on Pacientes.Codigo = PacienteInternado.CodPaciente ";
            SQL += " lEFT Join EntidadesPessoa on EntidadesPessoa.CodEntidade = Pacientes.CodPessoa ";
            SQL += " lEFT Join Entidades on Entidades.Codigo = EntidadesPessoa.CodEntidade ";
            if (string.IsNullOrEmpty(paciente))
            {
                var ob = Conexao.ClienteSql.SELECT(SQL);
                DtDados = (DataTable)ob;
                var result = DataTableHelper.DataTableToList<PacienteInternado>(DtDados);
                return result;
            }
            else
            {
                SQL += " Where PacienteInternado.CodDocumento='" + paciente + "'";
                var ob = Conexao.ClienteSql.SELECT(SQL);
                DtDados = (DataTable)ob;
                var result = DataTableHelper.DataTableToList<PacienteInternado>(DtDados);
                return result;
            }
        }
        public IEnumerable<Pagamentos> Listarpagamentos(string documento)
        {
            string SQL = " SELECT Pagamentos.codigo , Pagamentos.Descricao, Pagamentos.CodDocumento, Documentos.Descritivo as NomeDocumento, Pagamentos.Data as data, Pagamentos.Hora, Pagamentos.Valor, Moedas.Descricao as NomeMoeda, Pagamentos.Estado from Pagamentos ";
            SQL += " lEFT Join Documentos on Documentos.Codigo = Pagamentos.CodDocumento  ";
            SQL += " lEFT Join Moedas on Moedas.Codigo = Pagamentos.CodMoeda  ";
            SQL += " WHERE  Pagamentos.CodDocumento ='" + documento + "'";

            Object obj = Conexao.ClienteSql.SELECT(SQL);
            DataTable dtadados = (DataTable)obj;
            var result = DataTableHelper.DataTableToList<Pagamentos>(dtadados);
            return result;
        }
        public decimal Preco(string paciente)
        {
            DataTable DtDados = new DataTable();
            try
            {
                string SQL = "SELECT SUM(Valor) As Valor FROM PacienteInternado";
                if (paciente == null)
                {
                    var ob = Conexao.ClienteSql.SELECT(SQL);
                    DtDados = (DataTable)ob;
                    if (DtDados.Rows.Count == 0)
                        return 0.0m;
                    return Convert.ToDecimal(DtDados.Rows[0]["Valor"]);
                }
                else
                {
                    SQL += " Where PacienteInternado.CodDocumento='" + paciente + "'";
                    var ob = Conexao.ClienteSql.SELECT(SQL);
                    DtDados = (DataTable)ob;
                    if (DtDados.Rows.Count == 0)
                        return 0.0m;
                    return Convert.ToDecimal(DtDados.Rows[0]["Valor"]);
                }
                
                
            }
            catch (Exception) { throw new Exception("Erro ao Listar "); }
        }
        public decimal Pago(string paciente)
        {
            DataTable DtDados = new DataTable();
            try
            {
                string SQL = "SELECT SUM(Valor) As Valor FROM Pagamentos";
                if (paciente == null)
                {
                    var ob = Conexao.ClienteSql.SELECT(SQL);
                    DtDados = (DataTable)ob;
                    if (DtDados.Rows.Count == 0)
                        return 0.0m;
                    return Convert.ToDecimal(DtDados.Rows[0]["Valor"]);
                }
                else
                {
                    SQL += " Where Pagamentos.CodDocumento='" + paciente + "'";
                    var ob = Conexao.ClienteSql.SELECT(SQL);
                    DtDados = (DataTable)ob;
                    if (DtDados.Rows.Count == 0)
                        return 0.0m;
                    return Convert.ToDecimal(DtDados.Rows[0]["Valor"]);
                  
                }


            }
            catch (Exception) { throw new Exception("Erro ao Listar ") ; }
        }
        public void Delete(MovHospitalarViewModel tabela)
        {
            throw new NotImplementedException();
        }
        public object GetAll(MovHospitalarViewModel tabela)
        {
            throw new NotImplementedException();
        }
        public void Insert(MovHospitalarViewModel tabela)
        {
            throw new NotImplementedException();
        }
        public void Update(MovHospitalarViewModel tabela)
        {
            throw new NotImplementedException();
        }
        public void Update(PacienteInternado entity)
        {
            DbDTO dto = new DbDTO()
            {
                Nome = "PacienteInternado",
                Campos = new string[] { "Facturado" },
                Valores = new Object[] { entity.Facturado }
            };
            Conexao.ClienteSql.UPDATE(dto.Nome, dto.Campos, dto.Valores, "Codigo ='" + entity.Codigo + "'");
        }
        public void Delete(MovHospitalar hospital)
        {
            DbDTO dto = new DbDTO()
            {
                Nome = "MovHospitalar"
            };
            Conexao.ClienteSql.DELETE(dto.Nome, "Codigo ='" + hospital.Codigo + "'");
        }
        public bool VerificarDup(string nomeTabela, Dictionary<string, object> dicionario)
        {
            return VerificarDuplicacaoDoRegistro(nomeTabela, dicionario);
        }
        public object Get(MovHospitalarViewModel tabela)
        {
            return Db.GetById<MovHospitalarViewModel>(tabela.Codigo);
        }
        public int GetCodigoInternamento(int codigo)
        {
            
            throw new NotImplementedException();

        }
    }
}
