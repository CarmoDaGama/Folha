using Folha.Domain.Interfaces.Repository.Hospitalar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Folha.Domain.Models.Hospitalar;
using Folha.Domain.Models.Db;
using Folha.Driver.Repository.Data;
using System.Data;
using Folha.Domain.Helpers;
using Folha.Domain.ViewModels.Hospitalar;
using Folha.Domain.Models.Inventario;

namespace Folha.Driver.Repository.Hospitalar
{
    public class AtendimentoHospitalarRepository : IAtendimentoHospitalarRepository
    {
        public void Insert(AtendimentoHospitalar Dados)
        {
            try
            {
                Object _CodTipoConsulta;
                if (Dados.CodTipoConsulta == 0)
                    _CodTipoConsulta = DBNull.Value;
                else
                    _CodTipoConsulta = Dados.CodTipoConsulta;

                DbDTO dto = new DbDTO()
                {
                    Nome = "AtendimentoHospitalar",
                    Campos = new string[] { "CodPaciente", "Data", "Facturado", "status", "CodTipoConsulta","CodUsuario" },
                    Valores = new Object[] { Dados.CodPaciente, DateTime.Now,Dados.Facturado,Dados.status, _CodTipoConsulta, Dados.CodUsuario}
                };
                Conexao.ClienteSql.INSERT(dto.Nome, dto.Campos, dto.Valores);
            }
            catch (Exception ex) { throw new Exception("Erro ao Cadastrar Atendimento"+ex.Message); }
        }
        public void Update(AtendimentoHospitalar Dados)
        {
            try
            {
                DbDTO dto = new DbDTO()
                {
                    Nome = "AtendimentoHospitalar",
                    Campos = new string[] { "CodPaciente", "Data", "Facturado", "status", "CodUsuario" },
                    Valores = new Object[] { Dados.CodPaciente, Dados.Data, Dados.Facturado, Dados.status, UtilidadesGenericas.UsuarioCodigo }
                };
                Conexao.ClienteSql.UPDATE(dto.Nome, dto.Campos, dto.Valores,"Codigo='"+Dados.Codigo);
            }
            catch (Exception) { throw new Exception("Erro ao Cadastrar Atendimento"); }
        }
        public void FecharAtendimento(AtendimentoHospitalar Dados)
        {
            try
            {
                DbDTO dto = new DbDTO()
                {
                    Nome = "AtendimentoHospitalar",
                    Campos = new string[] { "Facturado" },
                    Valores = new Object[] { Dados.Facturado}
                };
                Conexao.ClienteSql.UPDATE(dto.Nome, dto.Campos, dto.Valores, "Codigo='" + Dados.Codigo + "'");
            }
            catch (Exception) { throw new Exception("Erro ao Cadastrar Atendimento"); }
        }

        public void InsertExames(List<ExamesAtendimento> Lista)
        {
           
        }

        public void DeleteExames(List<ExamesAtendimento> Lista)
        {
            try
            {
                if (Lista[0].Codigo != 0)
                {
                    Conexao.ClienteSql.DELETE("ExamesAtendimento", "Codigo ='" + Lista[0].Codigo + "'");
                }
            }
            catch (Exception)
            { throw new Exception("Erro ao Deletar Exame \n"); }
        }

        public IEnumerable<ExamesAtendimento> CarregaExames(string CodPaciente, string data)
        {
            try
            {
                string SQL = "SELECT * FROM ExamesAtendimento WHERE CodPaciente=" + CodPaciente + " and Data>='" + data + "'";
                Object ob = Conexao.ClienteSql.SELECT(SQL);
                DataTable DtExame= (DataTable)ob;
                var result = DataTableHelper.DataTableToList<ExamesAtendimento>(DtExame);
                return result;
            }
            catch (Exception) { throw new Exception("Erro listar Exames"); }
        }
        //######################################################################################################## Grafico
        IEnumerable<AtendimentoHospitalarGraficViewModel> IAtendimentoHospitalarRepository.TotalAtendimento(string dataInicial, string dataFinal, bool faturado)
        {
            try
            {
                String SQL = "select Data,Total from AtendimentoHospitalar where AtendimentoHospitalar.[Data] between '" + dataInicial + "' and '" + dataFinal + "'";
                if (faturado)
                    SQL += " and AtendimentoHospitalar.Facturado = 'Sim'";
                else
                    SQL += " and AtendimentoHospitalar.Facturado = 'Não'";

                Object ob = Conexao.ClienteSql.SELECT(SQL);
                DataTable DtAtendimento = (DataTable)ob;
                var result = DataTableHelper.DataTableToList<AtendimentoHospitalarGraficViewModel>(DtAtendimento);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao carregar formas \n" + ex);
            }
        }
        /*public int TotalAtendimento(string dataInicial, string dataFinal,bool faturado)
        {
            try
            {
                String SQL = "select * from AtendimentoHospitalar where AtendimentoHospitalar.[Data] between '" + dataInicial + "' and '"+dataFinal+"'";
                   if(faturado)
                   SQL+= " and AtendimentoHospitalar.Facturado = 'Sim'";
                   else
                    SQL += " and AtendimentoHospitalar.Facturado = 'Não'";

                Object ob = Conexao.ClienteSql.SELECT(SQL);
                DataTable DtAtendimento = (DataTable)ob;
                return DtAtendimento.Rows.Count;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao carregar formas \n" + ex);
            }
        }*/

        public IEnumerable<AtendimentoHospitalarViewModel> ListarAtendimentos(string dtInicio, string dtFim, string CodPaciente)
        {
            try
            {
                string SQL = "SELECT AtendimentoHospitalar.Codigo, AtendimentoHospitalar.CodPaciente,Entidades.Codigo as CodEntidade, Entidades.Nome,TipoConsultas.Descricao as TipoConsulta, " +
                    "AtendimentoHospitalar.Facturado,AtendimentoHospitalar.Total,AtendimentoHospitalar.[Data] FROM AtendimentoHospitalar " +
                    " Left join Pacientes on Pacientes.Codigo=AtendimentoHospitalar.CodPaciente left join Entidades on " +
                    "Entidades.Codigo = Pacientes.CodPessoa Left join TipoConsultas on TipoConsultas.Codigo = AtendimentoHospitalar.CodTipoConsulta  WHERE AtendimentoHospitalar.[Data] between '" + dtInicio + "' and '" + dtFim + "'";
             
                if (!string.IsNullOrEmpty(CodPaciente)) SQL += " WHERE AtendimentoHospitalar.CodPaciente=" + CodPaciente;
                Object ob = Conexao.ClienteSql.SELECT(SQL);
                DataTable DtExame = (DataTable)ob;
                var result = DataTableHelper.DataTableToList<AtendimentoHospitalarViewModel>(DtExame);
                return result;
            }
            catch (Exception ex) { throw new Exception("Erro listar Atendimentos"+ex.Message); }
        }

        public IEnumerable<AtendimentoHospitalarViewModel> ListarAtendimentosRecepcao(string CodPaciente)
        {
            try
            {
                string SQL = "SELECT AtendimentoHospitalar.Codigo, AtendimentoHospitalar.CodPaciente,Entidades.Codigo as CodEntidade, Entidades.Nome, " +
                    "AtendimentoHospitalar.Facturado,AtendimentoHospitalar.Total,AtendimentoHospitalar.[Data] FROM AtendimentoHospitalar " +
                    " Left join Pacientes on Pacientes.Codigo=AtendimentoHospitalar.CodPaciente left join Entidades on " +
                    "Entidades.Codigo = Pacientes.CodPessoa ";

                if (!string.IsNullOrEmpty(CodPaciente)) SQL += " WHERE AtendimentoHospitalar.CodPaciente=" + CodPaciente;
                Object ob = Conexao.ClienteSql.SELECT(SQL);
                DataTable DtExame = (DataTable)ob;
                var result = DataTableHelper.DataTableToList<AtendimentoHospitalarViewModel>(DtExame);
                return result;
            }
            catch (Exception ex) { throw new Exception("Erro listar Atendimentos" + ex.Message); }
        }

        #region LISTAGEM ATENDIMENTO HOSPITALAR
        public IEnumerable<AtendimentoHospitalarViewModel> ListarAtendimentosSemFiltro()
        {
            try
            {
                string SQL = "SELECT AtendimentoHospitalar.Codigo, AtendimentoHospitalar.CodPaciente,Entidades.Codigo as CodEntidade, Entidades.Nome,TipoConsultas.Descricao as TipoConsulta, " +
                    "AtendimentoHospitalar.Facturado,AtendimentoHospitalar.Total,AtendimentoHospitalar.[Data] FROM AtendimentoHospitalar " +
                    " Left join Pacientes on Pacientes.Codigo=AtendimentoHospitalar.CodPaciente left join Entidades on " +
                    "Entidades.Codigo = Pacientes.CodPessoa Left join TipoConsultas on TipoConsultas.Codigo = AtendimentoHospitalar.CodTipoConsulta ";
                
                Object ob = Conexao.ClienteSql.SELECT(SQL);
                DataTable DtExame = (DataTable)ob;
                var result = DataTableHelper.DataTableToList<AtendimentoHospitalarViewModel>(DtExame);
                return result;
            }
            catch (Exception ex) { throw new Exception("Erro listar Atendimentos" + ex.Message); }
        }
        public IEnumerable<AtendimentoHospitalarViewModel> ListarAtendimentosComFiltro(string valor,string dtInicial,string dtFim)
        {
            try
            {
                string SQL = "SELECT AtendimentoHospitalar.Codigo, AtendimentoHospitalar.CodPaciente,Entidades.Codigo as CodEntidade, Entidades.Nome,TipoConsultas.Descricao as TipoConsulta, " +
                    "AtendimentoHospitalar.Facturado,AtendimentoHospitalar.Total,AtendimentoHospitalar.[Data] FROM AtendimentoHospitalar " +
                    " Left join Pacientes on Pacientes.Codigo=AtendimentoHospitalar.CodPaciente left join Entidades on " +
                    "Entidades.Codigo = Pacientes.CodPessoa Left join TipoConsultas on TipoConsultas.Codigo = AtendimentoHospitalar.CodTipoConsulta Where AtendimentoHospitalar.[Data] Between '" + dtInicial+ "'and '"+dtFim+ "' and AtendimentoHospitalar.Facturado='"+valor+"'";
              

                Object ob = Conexao.ClienteSql.SELECT(SQL);
                DataTable DtExame = (DataTable)ob;
                var result = DataTableHelper.DataTableToList<AtendimentoHospitalarViewModel>(DtExame);
                return result;
            }
            catch (Exception ex) { throw new Exception("Erro listar Atendimentos" + ex.Message); }
        }
        public bool GetEstadoAtendimento(int codAtendimento)
        {
            string query = "Select AtendimentoHospitalar.Codigo As Codigo," +
                           "AtendimentoHospitalar.Facturado," +
                           "AtendimentoHospitalar.Data, " +
                           "AtendimentoHospitalar.Total As TotalAtendimento," +
                           "AtendimentoHospitalar.CodPaciente " +
                        " From AtendimentoHospitalar  Join Usuarios On AtendimentoHospitalar.CodUsuario = Usuarios.Codigo " +
                        " Where AtendimentoHospitalar.Codigo = '" + codAtendimento + "'";

            DataTable tabelaAtendimento = (DataTable)Conexao.ClienteSql.SELECT(query);
            if (tabelaAtendimento.Rows.Count == 0)
            {
                return false;
            }
            var facturado = tabelaAtendimento.Rows[0]["Facturado"].ToString(); 
            return facturado.ToLower() != "sim";
        }
        #endregion
        public List<AtendimentoDocViewModel> ListarAtendimentosNãoFacturadosPorUsuario(int usuarioId, int pacienteId)
        {
            string query = "Select AtendimentoHospitalar.Codigo As Codigo,"+  
                           "AtendimentoHospitalar.Facturado,"+
	                       "AtendimentoHospitalar.Data, "+
                           "AtendimentoHospitalar.Total As TotalAtendimento," +
                           "AtendimentoHospitalar.CodPaciente,"+
                           "Documentos.NumeroOrdem," +
	                       "Documentos.CodUsuario,"+
	                       "Documentos.Estado As EstadoDoc,"+
                           "Documentos.Descritivo,"+
	                       "Documentos.Mascara,"+
	                       "Documentos.Total As TotalDocumento," +
                           "Operacoes.Nome As NomeOperacao,"+
                           "Operacoes.codigo As CodOperacao "+
                        "From AtendimentoHospitalar  Join Usuarios On AtendimentoHospitalar.CodUsuario = Usuarios.Codigo" +
                        " Join Documentos On AtendimentoHospitalar.CodDocumento = Documentos.Codigo "+
                        " Join Operacoes On Documentos.CodOperacao = Operacoes.Codigo " +
                        "Where AtendimentoHospitalar.Facturado Like 'não' And " +
                              "Documentos.CodUsuario = '" + usuarioId + "' And " +
                              "AtendimentoHospitalar.CodPaciente = '" + pacienteId + "'";

            DataTable tabelaAtendimento = (DataTable)Conexao.ClienteSql.SELECT(query);

            return DataTableHelper.DataTableToList<AtendimentoDocViewModel>(tabelaAtendimento);
        }

        public bool TemConsultasPorFacturar(int atendimentoId)
        {
            string query = "SELECT * FROM ConsultaHospitalar Join TipoConsultas On ConsultaHospitalar.CodTipoConsulta = TipoConsultas.Codigo " +
                                " Join Imposto On TipoConsultas.CodImposto = Imposto.Codigo " +
                            " Where ConsultaHospitalar.CodAtendimento = '" + atendimentoId + "' AND (ConsultaHospitalar.Atendido LIKE 'Não' OR ConsultaHospitalar.Facturado LIKE 'Não')";
            DataTable tabelaConsulta = (DataTable)Conexao.ClienteSql.SELECT(query);

            return tabelaConsulta.Rows.Count > 0;
        }
        public ConsultaViewModel GetConsultaPorIdAtendimento(int codConsulta)
        {
            string query = "SELECT  ConsultaHospitalar.Codigo," +
                            "ConsultaHospitalar.CodAtendimento," +
                            "ConsultaHospitalar.Data As DataConsulta," +
                            "ConsultaHospitalar.Observacao," +
                            "ConsultaHospitalar.TempoEstimado," +
                            "ConsultaHospitalar.ValorConsulta," +
                            "ConsultaHospitalar.Atendido," +
                            "Imposto.Descricao As DescricaoImposto," +
                            "Imposto.Percentagem As ImpostoPercentagem," +
                            "TipoConsultas.Descricao As TipoConsultasDescricao" +
                            " FROM ConsultaHospitalar Join TipoConsultas On ConsultaHospitalar.CodTipoConsulta = TipoConsultas.Codigo " +
                                " Join Imposto On TipoConsultas.CodImposto = Imposto.Codigo " +
                            "Where ConsultaHospitalar.Codigo = '" + codConsulta + "'";

            DataTable tabelaConsulta = (DataTable)Conexao.ClienteSql.SELECT(query);

            return DataTableHelper.DataTableToList<ConsultaViewModel>(tabelaConsulta).FirstOrDefault();
        }
        public MotivoIsencao GetMotivoPorIdConsulta(int codConsulta)
        {
            string query = "SELECT MotivoIsencao.Codigo, MotivoIsencao.Descricao, MotivoIsencao.Referencia" +
                            " FROM ConsultaHospitalar " +
                                " Join MotivoIsencao On ConsultaHospitalar.CodMotivoIsencao = MotivoIsencao.Codigo " +
                            "Where ConsultaHospitalar.Codigo = '" + codConsulta + "'";

            DataTable tabelaConsulta = (DataTable)Conexao.ClienteSql.SELECT(query);

            return DataTableHelper.DataTableToList<MotivoIsencao>(tabelaConsulta).FirstOrDefault();
        }
        public List<ConsultaViewModel> ListasConsultasPorIdAtendimento(int atendimentoId)
        {
            string query = "SELECT  ConsultaHospitalar.Codigo,"+
                            "ConsultaHospitalar.CodAtendimento," +
                            "ConsultaHospitalar.Data As DataConsulta," +
                            "ConsultaHospitalar.Observacao," +
                            "ConsultaHospitalar.TempoEstimado," +
                            "ConsultaHospitalar.ValorConsulta," +
                            "ConsultaHospitalar.Atendido," +
                            "ConsultaHospitalar.Facturado," +
                            "Imposto.Descricao As DescricaoImposto," +
                            "Imposto.Percentagem As ImpostoPercentagem," +
                            "Imposto.Sigla As CodImposto," +
                            "Imposto.Descricao As DetalheImposto," +
                            "TipoImposto.Sigla As TipoImposto," +
                            "TipoConsultas.Descricao As TipoConsultasDescricao " +
                            " FROM ConsultaHospitalar Join TipoConsultas On ConsultaHospitalar.CodTipoConsulta = TipoConsultas.Codigo " + 
                                " Join Imposto On TipoConsultas.CodImposto = Imposto.Codigo "+
                                " Join TipoImposto On TipoImposto.Codigo = Imposto.CodTipo " +
                            "Where ConsultaHospitalar.CodAtendimento = " + atendimentoId;
            DataTable tabelaConsulta = (DataTable)Conexao.ClienteSql.SELECT(query);

            return DataTableHelper.DataTableToList<ConsultaViewModel>(tabelaConsulta);
        }
        public List<ExameViewModel> ListarExamesPorIdAtendimento(int atendimentoId)
        {
            string query = "SELECT ExamesAtendimento.Codigo," +
                            "ExamesAtendimento.CodExame," +
                            "ExamesAtendimento.Data As DataExame," +
                            "ExamesHospitalar.Descricao," +
                            "ExamesHospitalar.Lucro," +
                            "ExamesHospitalar.Preco," +
                            "ExamesAtendimento.Facturado," +
                            "ExamesHospitalar.PrecoVenda," +
                            "ExamesAtendimento.CodAtendimento," +
                            "ExamesAtendimento.Estado As EstadoAtendimento," +
                            "ExamesAtendimento.TipoResultado," +
                            "Imposto.Descricao As DescricaoImposto," +
                            "Imposto.Percentagem As ImpostoPercentagem," +
                            "Imposto.Sigla As CodImposto," +
                            "Imposto.Descricao As DetalheImposto," +
                            "TipoImposto.Sigla As TipoImposto " +
                            " FROM ExamesHospitalar Join ExamesAtendimento On ExamesHospitalar.Codigo = ExamesAtendimento.CodExame " +
                                                    " Join Imposto On ExamesHospitalar.CodImposto = Imposto.Codigo " +
                                                    " Join TipoImposto On TipoImposto.Codigo = Imposto.CodTipo " +
                                                    "Where ExamesAtendimento.CodAtendimento = " + atendimentoId;

            DataTable tabelaExames = (DataTable)Conexao.ClienteSql.SELECT(query);
            return DataTableHelper.DataTableToList<ExameViewModel>(tabelaExames);
        }
        public List<InternaViewModel> ListarInternamentoPorIdAtendimento(int codAntendimnto)
        {
            string query = "SELECT PacienteInternado.Codigo," +
                               "PacienteInternado.DataEntrada, " +
                               "PacienteInternado.Facturado," +
                               "PacienteInternado.Total, " +
                               "TarifaHospitalar.Descricao, " +
                               "Imposto.Percentagem, " +
                               "Imposto.Descricao  as ImpostoDescricao," +
                            "Imposto.Sigla As CodImposto," +
                            "Imposto.Descricao As DetalheImposto," +
                            "TipoImposto.Sigla As TipoImposto " +
                        " FROM PacienteInternado JOIN TarifaHospitalar on PacienteInternado.CodTarifaHospitalar = TarifaHospitalar.Codigo " +
                        " JOIN Imposto on TarifaHospitalar.CodImposto = Imposto.Codigo " +
                        " Join TipoImposto On TipoImposto.Codigo = Imposto.CodTipo " +
                        " WHERE PacienteInternado.CodAtendimentoHospitalar = '" +codAntendimnto+"'";
            DataTable tabelaInternamentos = (DataTable)Conexao.ClienteSql.SELECT(query);

            return DataTableHelper.DataTableToList<InternaViewModel>(tabelaInternamentos);
        }
        public bool TemExamesPorFacturar(int atendimentoId)
        {
            string query = "SELECT * FROM ExamesHospitalar Join ExamesAtendimento On ExamesHospitalar.Codigo = ExamesAtendimento.CodExame " +
                                                    //" Join Motivoisencao On ExamesHospitalar.CodMotivoIsencao = MotivoIsencao.Codigo " +
                                                    " Join Imposto On ExamesHospitalar.CodImposto = Imposto.Codigo " +
                                                    " Where ExamesAtendimento.CodAtendimento = " + atendimentoId + " AND (ExamesAtendimento.Facturado LIKE 'Não' OR ExamesAtendimento.status = 1)";

            DataTable tabelaExames = (DataTable)Conexao.ClienteSql.SELECT(query);
            return tabelaExames.Rows.Count > 0;
        }
        public ExameViewModel GetExamePorIdAtendimento(int codExame)
        {
            string query = "SELECT ExamesAtendimento.Codigo," +
                            "ExamesAtendimento.CodExame," +
                            "ExamesAtendimento.Data As DataExame," +
                            "ExamesHospitalar.Descricao," +
                            "ExamesHospitalar.Lucro," +
                            "ExamesHospitalar.Preco," +
                            "ExamesAtendimento.Facturado," +
                            "ExamesHospitalar.PrecoVenda," +
                            "ExamesAtendimento.CodAtendimento," +
                            "ExamesAtendimento.Estado As EstadoAtendimento," +
                            "ExamesAtendimento.TipoResultado," +
                            "Imposto.Descricao As DescricaoImposto," +
                            "Imposto.Percentagem As ImpostoPercentagem " +
                            " FROM ExamesHospitalar Join ExamesAtendimento On ExamesHospitalar.Codigo = ExamesAtendimento.CodExame " +
                                                    " Join Imposto On ExamesHospitalar.CodImposto = Imposto.Codigo " +
                                                    " Where ExamesAtendimento.Codigo = '" + codExame + "'";


            DataTable tabelaExames = (DataTable)Conexao.ClienteSql.SELECT(query);
            return DataTableHelper.DataTableToList<ExameViewModel>(tabelaExames).FirstOrDefault();
        }
        public MotivoIsencao GetMotivoPorIdExame(int codExame)
        {
            string query = "SELECT MotivoIsencao.Codigo, MotivoIsencao.Descricao, MotivoIsencao.Referencia " +
                            " FROM ExamesHospitalar Join ExamesAtendimento On ExamesHospitalar.Codigo = ExamesAtendimento.CodExame " +
                                " Join MotivoIsencao On ExamesHospitalar.CodMotivoIsencao = MotivoIsencao.Codigo " +
                                                    " Where ExamesAtendimento.Codigo = '" + codExame + "'";


            DataTable tabelaExames = (DataTable)Conexao.ClienteSql.SELECT(query);
            return DataTableHelper.DataTableToList<MotivoIsencao>(tabelaExames).FirstOrDefault();
        }
        public bool TemInternamentoPorFacturar(int codAntendimnto)
        {
            string query = "SELECT * FROM PacienteInternado JOIN TarifaHospitalar on PacienteInternado.CodTarifaHospitalar = TarifaHospitalar.Codigo " +
                        " JOIN Imposto on TarifaHospitalar.CodImposto = Imposto.Codigo " +
                        " WHERE PacienteInternado.CodAtendimentoHospitalar = '" + codAntendimnto + "' AND (PacienteInternado.Estado = 'INTERNADO' Or PacienteInternado.Facturado LIKE 'Não')";
            DataTable tabelaInternamentos = (DataTable)Conexao.ClienteSql.SELECT(query);

            return tabelaInternamentos.Rows.Count > 0;
        }
        public InternaViewModel GetInternamentoPorIdAtendimento(int codInternamento)
        {
            string query = "SELECT PacienteInternado.Codigo," +
                               "PacienteInternado.DataEntrada, " +
                               "PacienteInternado.Facturado," +
                               "PacienteInternado.Total, " +
                               "TarifaHospitalar.Descricao, " +
                               "Imposto.Percentagem, " +
                               "Imposto.Descricao as ImpostoDescricao" +
                        " FROM PacienteInternado JOIN TarifaHospitalar on PacienteInternado.CodTarifaHospitalar = TarifaHospitalar.Codigo " +
                        " JOIN Imposto on TarifaHospitalar.CodImposto = Imposto.Codigo " +
                        " WHERE PacienteInternado.Codigo = '" + codInternamento + "'";

            DataTable tabelaInternamentos = (DataTable)Conexao.ClienteSql.SELECT(query);

            return DataTableHelper.DataTableToList<InternaViewModel>(tabelaInternamentos).FirstOrDefault();
        }
        public MotivoIsencao GetMotivoPorIdInternamento(int codInternamento)
        {
            string query = "SELECT MotivoIsencao.Codigo, MotivoIsencao.Descricao, MotivoIsencao.Referencia " +
                        " FROM PacienteInternado JOIN TarifaHospitalar on PacienteInternado.CodTarifaHospitalar = TarifaHospitalar.Codigo " +
                        " JOIN MotivoIsencao on TarifaHospitalar.CodMotivoIsencao = MotivoIsencao.Codigo " +
                        " WHERE PacienteInternado.Codigo = '" + codInternamento + "'";

            DataTable tabelaInternamentos = (DataTable)Conexao.ClienteSql.SELECT(query);

            return DataTableHelper.DataTableToList<MotivoIsencao>(tabelaInternamentos).FirstOrDefault();
        }
        #region Internamento Alcino
        public IEnumerable<PacienteInternado> ListarInternado(string paciente)
        {
            string SQL = " SELECT PacienteInternado.Codigo, PacienteInternado.CodAtendimentoHospitalar, PacienteInternado.CodQuartosHospitalar, PacienteInternado.CodTarifaHospitalar, PacienteInternado.CodCamasHospitalar,TarifaHospitalar.Descricao as Tarifa, Entidades.Nome as Paciente, QuartosHospitalar.Descricao as Quarto, CamasHospitalar.Descricao  as Cama, PacienteInternado.Estado, PacienteInternado.DataEntrada, PacienteInternado.DataSaida, PacienteInternado.Valor, PacienteInternado.Estado, PacienteInternado.Dias,PacienteInternado.Total, PacienteInternado.Facturado from PacienteInternado ";
            SQL += " lEFT Join QuartosHospitalar on QuartosHospitalar.Codigo= PacienteInternado.CodQuartosHospitalar  ";
            SQL += " lEFT Join CamasHospitalar on CamasHospitalar.Codigo= PacienteInternado.CodCamasHospitalar  ";
            SQL += " lEFT Join TarifaHospitalar on TarifaHospitalar.Codigo= PacienteInternado.CodTarifaHospitalar  ";
            SQL += " lEFT Join AtendimentoHospitalar on AtendimentoHospitalar.Codigo= PacienteInternado.CodAtendimentoHospitalar ";
            SQL += " lEFT Join Pacientes on Pacientes.Codigo = AtendimentoHospitalar.CodPaciente  ";
            SQL += " lEFT Join EntidadesPessoa on EntidadesPessoa.CodEntidade = Pacientes.CodPessoa   ";
            SQL += " lEFT Join Entidades on Entidades.Codigo = EntidadesPessoa.CodEntidade   ";
            SQL += " WHERE  PacienteInternado.CodAtendimentoHospitalar ='" + paciente + "'";

            Object obj = Conexao.ClienteSql.SELECT(SQL);
            DataTable dtadados = (DataTable)obj;
            var result = DataTableHelper.DataTableToList<PacienteInternado>(dtadados);
            return result;
        }

        public PacienteInternadoViewModel GravarInternado(PacienteInternadoViewModel paciente)
        {
            string tabela = "PacienteInternado";
            string[] campos = { "CodAtendimentoHospitalar", "CodQuartosHospitalar", "CodCamasHospitalar", "CodTarifaHospitalar", "Estado", "DataEntrada", "DataSaida", "Valor", "Facturado", "Total", "Dias" };
            Object[] valores = { paciente.CodAtendimentoHospitalar, paciente.CodQuartosHospitalar,  paciente.CodCamasHospitalar, paciente.CodTarifaHospitalar, paciente.Estado, paciente.DataEntrada, paciente.DataSaida, paciente.Valor, paciente.Facturado, paciente.Total, paciente.Dias };
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
           
                string SQL = "SELECT *FROM QuartosHospitalar";
                SQL += " Where QuartosHospitalar.CodTiposQuartosHospitalar='" + criterios + "'";
                var ob = Conexao.ClienteSql.SELECT(SQL);
                DtDados = (DataTable)ob;
                var result = DataTableHelper.DataTableToList<QuartosHospitalarViewModel>(DtDados);
                return result;
        
        }
        public IEnumerable<CamasQuartosHospitalarViewModel> ListaCama(int codQuartos)
        {
            DataTable DtDados = new DataTable();
       
                string SQL = " SELECT CamasQuartosHospitalar.Codigo, CamasQuartosHospitalar.CodQuartosHospitalar, CamasHospitalar.Descricao,CamasQuartosHospitalar.CodCamasHospitalar from CamasQuartosHospitalar ";
                SQL += " Left Outer Join CamasHospitalar on CamasHospitalar.Codigo= CamasQuartosHospitalar.CodCamasHospitalar ";
                SQL += " WHERE  CamasQuartosHospitalar.CodQuartosHospitalar='" + codQuartos + "' and CamasHospitalar.Ocupado = 'Não'"; var ob = Conexao.ClienteSql.SELECT(SQL);
                DtDados = (DataTable)ob;
                var result = DataTableHelper.DataTableToList<CamasQuartosHospitalarViewModel>(DtDados);
                return result;
           
        }

        public List<CamasQuartosHospitalarViewModel> GetCamas(int codQuartos)
        {
            string SQL = " SELECT CamasQuartosHospitalar.Codigo, CamasQuartosHospitalar.CodQuartosHospitalar, CamasHospitalar.Descricao,CamasQuartosHospitalar.CodCamasHospitalar from CamasQuartosHospitalar ";
            SQL += " Left Outer Join CamasHospitalar on CamasHospitalar.Codigo= CamasQuartosHospitalar.CodCamasHospitalar ";
            SQL += " WHERE  CamasQuartosHospitalar.CodQuartosHospitalar='" + codQuartos + "' and CamasHospitalar.Ocupado = 'Não'";
            Object obj = Conexao.ClienteSql.SELECT(SQL);
            DataTable dtadados = (DataTable)obj;
            var result = DataTableHelper.DataTableToList<CamasQuartosHospitalarViewModel>(dtadados);
            return result;
        }

        public decimal Total(string criterio)
        {
            DataTable DtDados = new DataTable();
            try
            {
                string SQL = "SELECT SUM(Total) As Total FROM PacienteInternado";
                if (criterio == null)
                {
                    var ob = Conexao.ClienteSql.SELECT(SQL);
                    DtDados = (DataTable)ob;
                    if (DtDados.Rows.Count == 0)
                        return 0.0m;
                    return Convert.ToDecimal(DtDados.Rows[0]["Total"]);
                }
                else
                {
                    SQL += " Where PacienteInternado.CodAtendimentoHospitalar='" + criterio + "' AND PacienteInternado.Facturado ='Não'";
                    var ob = Conexao.ClienteSql.SELECT(SQL);
                    DtDados = (DataTable)ob;
                    if (DtDados.Rows.Count == 0 || Equals(DtDados.Rows[0]["Total"], DBNull.Value))
                        return 0.0m;
                    return Convert.ToDecimal(DtDados.Rows[0]["Total"]);
                }
            }
            catch (Exception) { throw new Exception("Erro ao Listar "); }
        }

        public void UpdatePaciente(PacienteInternado entity)
        {
            DbDTO dto = new DbDTO()
            {
                Nome = "PacienteInternado",
                Campos = new string[] { "Estado", "Facturado" },
                Valores = new Object[] { entity.Estado, entity.Facturado }
            };
            Conexao.ClienteSql.UPDATE(dto.Nome, dto.Campos, dto.Valores, "Codigo ='" + entity.Codigo + "'");
        }

        public object GetCodLast(int criterio)
        {
            DataTable DtDados = new DataTable();
            try
            {
                string SQL = "SELECT MAX(Codigo) as Codigo From PacienteInternado ";
                //SQL += " WHERE  PacienteInternado.CodAtendimentoHospitalar ='" + criterio + "'";
                var ob = Conexao.ClienteSql.SELECT(SQL);
                DtDados = (DataTable)ob;
                var result = DataTableHelper.DataTableToList<PacienteInternado>(DtDados).ToList();
                return result[0].Codigo;
            }
            catch (Exception) { throw new Exception("Erro ao Listar "); }
        }
        public object BuscarUltimoRegistro(int Codigo)
        {
            string SQL = "SELECT *FROM PacienteInternado";
            SQL += " WHERE Codigo='" + Codigo + "'";
            Object obj = Conexao.ClienteSql.SELECT(SQL);
            DataTable dtadados = (DataTable)obj;
            var result = DataTableHelper.DataTableToList<PacienteInternado>(dtadados).ToList();
            return result[0].Codigo;
        }
        public List<PacienteInternado> ListaNova(int Codigo)
        {
            string SQL = " SELECT *from PacienteInternado";
            SQL += " WHERE  PacienteInternado.Codigo ='" + Codigo + "'";
            Object obj = Conexao.ClienteSql.SELECT(SQL);
            DataTable dtadados = (DataTable)obj;
            var result = DataTableHelper.DataTableToList<PacienteInternado>(dtadados);
            return result;
        }

        public List<PacienteInternado> DatasInternamento(DateTime Data)
        {
            string SQL = " SELECT * FROM PacienteInternado WHERE Convert(date, DataSaida)";
            SQL += "< '" + Data.ToString("yyyy-MM-dd") + "' AND PacienteInternado.Estado = 'INTERNADO'";
            Object obj = Conexao.ClienteSql.SELECT(SQL);
            DataTable dtadados = (DataTable)obj;
            var result = DataTableHelper.DataTableToList<PacienteInternado>(dtadados);
            return result;
        }

        public IEnumerable<PacienteInternado> ListarTudo(string paciente)
        {
            string SQL = " SELECT PacienteInternado.Codigo, PacienteInternado.CodAtendimentoHospitalar, PacienteInternado.CodQuartosHospitalar, PacienteInternado.CodTarifaHospitalar, PacienteInternado.CodCamasHospitalar,TarifaHospitalar.Descricao as Tarifa, Entidades.Nome as Paciente, QuartosHospitalar.Descricao as Quarto, CamasHospitalar.Descricao  as Cama, PacienteInternado.Estado, PacienteInternado.DataEntrada, PacienteInternado.DataSaida, PacienteInternado.Valor, PacienteInternado.Estado, PacienteInternado.Dias,PacienteInternado.Total, PacienteInternado.Facturado from PacienteInternado ";
            SQL += " lEFT Join QuartosHospitalar on QuartosHospitalar.Codigo= PacienteInternado.CodQuartosHospitalar  ";
            SQL += " lEFT Join CamasHospitalar on CamasHospitalar.Codigo= PacienteInternado.CodCamasHospitalar  ";
            SQL += " lEFT Join TarifaHospitalar on TarifaHospitalar.Codigo= PacienteInternado.CodTarifaHospitalar  ";
            SQL += " lEFT Join AtendimentoHospitalar on AtendimentoHospitalar.Codigo= PacienteInternado.CodAtendimentoHospitalar ";
            SQL += " lEFT Join Pacientes on Pacientes.Codigo = AtendimentoHospitalar.CodPaciente  ";
            SQL += " lEFT Join EntidadesPessoa on EntidadesPessoa.CodEntidade = Pacientes.CodPessoa   ";
            SQL += " lEFT Join Entidades on Entidades.Codigo = EntidadesPessoa.CodEntidade   ";

            Object obj = Conexao.ClienteSql.SELECT(SQL);
            DataTable dtadados = (DataTable)obj;
            var result = DataTableHelper.DataTableToList<PacienteInternado>(dtadados);
            return result;
        }
        #endregion

        #region FILTRAR INTERNAMENTO 

        public IEnumerable<PacienteInternado> ListarInternadoSemFiltro()
        {
            string SQL = " SELECT PacienteInternado.Codigo, PacienteInternado.CodAtendimentoHospitalar, PacienteInternado.CodQuartosHospitalar, PacienteInternado.CodTarifaHospitalar, PacienteInternado.CodCamasHospitalar,TarifaHospitalar.Descricao as Tarifa, Entidades.Nome as Paciente, QuartosHospitalar.Descricao as Quarto, CamasHospitalar.Descricao  as Cama, PacienteInternado.Estado, PacienteInternado.DataEntrada, PacienteInternado.DataSaida, PacienteInternado.Valor, PacienteInternado.Estado, PacienteInternado.Dias,PacienteInternado.Total, PacienteInternado.Facturado from PacienteInternado ";
            SQL += " lEFT Join QuartosHospitalar on QuartosHospitalar.Codigo= PacienteInternado.CodQuartosHospitalar  ";
            SQL += " lEFT Join CamasHospitalar on CamasHospitalar.Codigo= PacienteInternado.CodCamasHospitalar  ";
            SQL += " lEFT Join TarifaHospitalar on TarifaHospitalar.Codigo= PacienteInternado.CodTarifaHospitalar  ";
            SQL += " lEFT Join AtendimentoHospitalar on AtendimentoHospitalar.Codigo= PacienteInternado.CodAtendimentoHospitalar ";
            SQL += " lEFT Join Pacientes on Pacientes.Codigo = AtendimentoHospitalar.CodPaciente  ";
            SQL += " lEFT Join EntidadesPessoa on EntidadesPessoa.CodEntidade = Pacientes.CodPessoa   ";
            SQL += " lEFT Join Entidades on Entidades.Codigo = EntidadesPessoa.CodEntidade   ";

            Object obj = Conexao.ClienteSql.SELECT(SQL);
            DataTable dtadados = (DataTable)obj;
            var result = DataTableHelper.DataTableToList<PacienteInternado>(dtadados);
            return result;
        }

        public IEnumerable<PacienteInternado> FiltrarPacienteInternado(string valor, string dtInicoEst, string dtFim)
        {
            DataTable DtDados = new DataTable();

            //Estado
            string SQL = " SELECT PacienteInternado.Codigo, PacienteInternado.CodAtendimentoHospitalar, PacienteInternado.CodQuartosHospitalar, PacienteInternado.CodTarifaHospitalar, PacienteInternado.CodCamasHospitalar,TarifaHospitalar.Descricao as Tarifa, Entidades.Nome as Paciente, QuartosHospitalar.Descricao as Quarto, CamasHospitalar.Descricao  as Cama, PacienteInternado.Estado, PacienteInternado.DataEntrada, PacienteInternado.DataSaida, PacienteInternado.Valor, PacienteInternado.Estado, PacienteInternado.Dias,PacienteInternado.Total, PacienteInternado.Facturado from PacienteInternado ";
            SQL += " lEFT Join QuartosHospitalar on QuartosHospitalar.Codigo= PacienteInternado.CodQuartosHospitalar  ";
            SQL += " lEFT Join CamasHospitalar on CamasHospitalar.Codigo= PacienteInternado.CodCamasHospitalar  ";
            SQL += " lEFT Join TarifaHospitalar on TarifaHospitalar.Codigo= PacienteInternado.CodTarifaHospitalar  ";
            SQL += " lEFT Join AtendimentoHospitalar on AtendimentoHospitalar.Codigo= PacienteInternado.CodAtendimentoHospitalar ";
            SQL += " lEFT Join Pacientes on Pacientes.Codigo = AtendimentoHospitalar.CodPaciente  ";
            SQL += " lEFT Join EntidadesPessoa on EntidadesPessoa.CodEntidade = Pacientes.CodPessoa   ";
            SQL += " lEFT Join Entidades on Entidades.Codigo = EntidadesPessoa.CodEntidade   ";
            SQL += " WHERE  PacienteInternado.Estado='" + dtInicoEst + "'";

          

            if (valor == "Nenhum")
            {
                //Data
                SQL = " SELECT PacienteInternado.Codigo, PacienteInternado.CodAtendimentoHospitalar, PacienteInternado.CodQuartosHospitalar, PacienteInternado.CodTarifaHospitalar, PacienteInternado.CodCamasHospitalar,TarifaHospitalar.Descricao as Tarifa, Entidades.Nome as Paciente, QuartosHospitalar.Descricao as Quarto, CamasHospitalar.Descricao  as Cama, PacienteInternado.Estado, PacienteInternado.DataEntrada, PacienteInternado.DataSaida, PacienteInternado.Valor, PacienteInternado.Estado, PacienteInternado.Dias,PacienteInternado.Total, PacienteInternado.Facturado from PacienteInternado ";
                SQL += " lEFT Join QuartosHospitalar on QuartosHospitalar.Codigo= PacienteInternado.CodQuartosHospitalar  ";
                SQL += " lEFT Join CamasHospitalar on CamasHospitalar.Codigo= PacienteInternado.CodCamasHospitalar  ";
                SQL += " lEFT Join TarifaHospitalar on TarifaHospitalar.Codigo= PacienteInternado.CodTarifaHospitalar  ";
                SQL += " lEFT Join AtendimentoHospitalar on AtendimentoHospitalar.Codigo= PacienteInternado.CodAtendimentoHospitalar ";
                SQL += " lEFT Join Pacientes on Pacientes.Codigo = AtendimentoHospitalar.CodPaciente  ";
                SQL += " lEFT Join EntidadesPessoa on EntidadesPessoa.CodEntidade = Pacientes.CodPessoa   ";
                SQL += " lEFT Join Entidades on Entidades.Codigo = EntidadesPessoa.CodEntidade   ";
                SQL += " WHERE  PacienteInternado.DataEntrada >= '" + dtInicoEst + "' and PacienteInternado.DataSaida =  '" + dtFim + "' and PacienteInternado.Estado='" + valor + "'";
            }

            var ob = Conexao.ClienteSql.SELECT(SQL);
            DtDados = (DataTable)ob;
            var result = DataTableHelper.DataTableToList<PacienteInternado>(DtDados);
            return result;

        }

        public IEnumerable<AtendimentoHospitalarViewModel> ListarAtendimentosSemFiltro(string valor, string dtInicial, string dtFim)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
