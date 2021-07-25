using Folha.Driver.Repository.Data;
using Folha.Domain.Models.Hospitalar;
using Folha.Domain.ViewModels.Hospitalar;
using Folha.Domain.Models.Db;
using Folha.Domain.Helpers;
using Folha.Domain.Interfaces.Repository.Hospitalar;
using System;
using System.Collections.Generic;
using System.Data;

namespace Folha.Driver.Repository.Hospitalar
{
    public class ConsultaHospitalarRepository : IConsultaHospitalarRepository
    {
        public void Insert(ConsultaHospitalar Dados)
        {
            try
            {
                #region VerificaCampoNulo
                Object _CodMotivoIsencao;
                if (Dados.CodMotivoIsencao == 0)
                    _CodMotivoIsencao = DBNull.Value;
                else
                    _CodMotivoIsencao = Dados.CodMotivoIsencao;

                Object _CodImposto;
                if (Dados.CodImposto == 0)
                    _CodImposto = DBNull.Value;
                else
                    _CodImposto = Dados.CodImposto;
                #endregion

                if (Dados.Codigo==0)
                    {
                        DbDTO dto = new DbDTO()
                        {
                            Nome = "ConsultaHospitalar",
                            Campos = new string[] {
                                "CodPaciente",
                                "CodTipoConsulta",
                                "Data",
                                "HoraInicial",
                                "TempoEstimado",
                                "ValorConsulta",
                                "CodPrioridade",
                                "CodTipoServico",
                                "CodMedico",
                                "status",
                                "Atendido",
                                "Observacao",
                                "CodImposto",
                                "CodMotivoIsencao"
                            },
                            Valores = new Object[] {
                                Dados.CodPaciente,
                                Dados.CodTipoConsulta,
                                Dados.Data,
                                Dados.HoraInicial,
                                Dados.TempoEstimado,
                                Dados.ValorConsulta,
                                Dados.CodPrioridade,
                                Dados.CodTipoServico,
                                Dados.CodMedico,
                                Dados.status,
                                Dados.Atendido,
                                Dados.Observacao,
                                _CodImposto,
                                _CodMotivoIsencao
                            }
                        };
                        Conexao.ClienteSql.INSERT(dto.Nome, dto.Campos, dto.Valores);
                    }
            }
            catch (Exception ex) { throw new Exception("Erro na Marcação de Consulta"+ex.Message); }
        }

        public void Update(ConsultaHospitalar Dados)
        {
            try
            {
                #region VerificaCampoNulo
                Object _CodMotivoIsencao;
                if (Dados.CodMotivoIsencao == 0)
                    _CodMotivoIsencao = DBNull.Value;
                else
                    _CodMotivoIsencao = Dados.CodMotivoIsencao;

                Object _CodImposto;
                if (Dados.CodImposto == 0)
                    _CodImposto = DBNull.Value;
                else
                    _CodImposto = Dados.CodImposto;
                #endregion

                if (Dados.Codigo != 0)
                {
                    DbDTO dto = new DbDTO()
                    {
                        Nome = "ConsultaHospitalar",
                        Campos = new string[] {
                            "CodTipoConsulta",
                            "Data",
                            "HoraInicial",
                            "TempoEstimado",
                            "ValorConsulta",
                            "CodPrioridade",
                            "CodTipoServico",
                            "CodMedico",
                            "Observacao",
                            "CodImposto",
                            "CodMotivoIsencao"
                        },
                        Valores = new Object[] {
                            Dados.CodTipoConsulta,
                            Dados.Data,
                            Dados.HoraInicial,
                            Dados.TempoEstimado,
                            Dados.ValorConsulta,
                            Dados.CodPrioridade,
                            Dados.CodTipoServico,
                            Dados.CodMedico,
                            Dados.Observacao,
                            _CodImposto,
                            _CodMotivoIsencao
                        }
                    };
                    Conexao.ClienteSql.UPDATE(dto.Nome, dto.Campos, dto.Valores, "Codigo=" + Dados.Codigo);
                } 
            }
            catch (Exception ex) { throw new Exception("Erro na Actualizacao da Consulta" + ex.Message); }
        }

        public void UpdateConsultorio(ConsultaHospitalar Dados)
        {
            try
            {
                if (Dados.Codigo != 0)
                {
                    DbDTO dto = new DbDTO()
                    {
                        Nome = "ConsultaHospitalar",
                        Campos = new string[] {
                            "Anaminizes",
                            "QueixaPrincipal",
                            "EvolucaoTratamento",
                            "Atendido",
                    },
                        Valores = new Object[] {
                            Dados.Anaminizes,
                            Dados.QueixaPrincipal,
                            Dados.EvolucaoTratamento,
                            Dados.Atendido
                        }
                    };
                    Conexao.ClienteSql.UPDATE(dto.Nome, dto.Campos, dto.Valores, "Codigo=" + Dados.Codigo);
                }
            }
            catch (Exception ex) { throw new Exception("Erro na Actualizacao da Consulta" + ex.Message); }
        }
        public void FecharFacturar(ConsultaHospitalar Dados)
        {
            try
            {

                if (Dados.Codigo != 0)
                {
                    DbDTO dto = new DbDTO()
                    {
                        Nome = "ConsultaHospitalar",
                        Campos = new string[] {
                            "Facturado"
                        },
                        Valores = new Object[] {
                            Dados.Facturado
                        }
                    };
                    Conexao.ClienteSql.UPDATE(dto.Nome, dto.Campos, dto.Valores, "Codigo=" + Dados.Codigo);
                }
            }
            catch (Exception ex) { throw new Exception("Erro na Actualizacao da Consulta" + ex.Message); }
        }

        public int LastCodConsulta()
        {
            var result = new List<ConsultaHospitalar>();
            try
            {
                DataTable DtDados = new DataTable();
                string SQL = "SELECT * FROM ConsultaHospitalar";
                var ob = Conexao.ClienteSql.SELECT(SQL);
                DtDados = (DataTable)ob;
                result = DataTableHelper.DataTableToList<ConsultaHospitalar>(DtDados);

            }
            catch (Exception) { }
   
            return result[result.Count-1].Codigo;
        }

        public IEnumerable<ConsultaHospitalarViewModel> Listar(string CodAtendimento, string CodConsulta)
        {
            var result = new List<ConsultaHospitalarViewModel>();
            try
            {
                string SQL = "Select ConsultaHospitalar.Codigo, TipoConsultas.Codigo as CodTipoConsulta, TipoConsultas.Descricao as TipoConsulta,TipoConsultas.CodEspecialidade, Prioridade.Codigo as CodPrioridade," +
                    "Prioridade.Descricao as Prioridade, TipoServico.Codigo as CodTipoServico, TipoServico.Descricao as TipoServico, ConsultaHospitalar.CodMedico, Entidades.Codigo as CodEntidade," +
                    "Entidades.Nome as NomeMedico, ConsultaHospitalar.CodAtendimento, ConsultaHospitalar.Atendido, ConsultaHospitalar.[Data], ConsultaHospitalar.HoraInicial,ConsultaHospitalar.TempoEstimado," +
                    "ConsultaHospitalar.ValorConsulta,ConsultaHospitalar.Observacao, Imposto.Codigo as CodImposto, Imposto.Descricao as Imposto, Imposto.Percentagem, MotivoIsencao.Codigo as CodMotivoIsencao, MotivoIsencao.Descricao as MotivoIsecao from ConsultaHospitalar join TipoConsultas " +
                    "on TipoConsultas.Codigo=ConsultaHospitalar.CodTipoConsulta join Prioridade on Prioridade.Codigo=ConsultaHospitalar.CodPrioridade join TipoServico " +
                    "on TipoServico.Codigo=ConsultaHospitalar.CodTipoServico  join Medicos on Medicos.Codigo=ConsultaHospitalar.CodMedico join Entidades on Entidades.Codigo=Medicos.CodPessoa left join Imposto on Imposto.Codigo=ConsultaHospitalar.CodImposto left join MotivoIsencao on MotivoIsencao.Codigo=ConsultaHospitalar.CodMotivoIsencao ";
                    
                if (CodAtendimento == "0")
                    SQL += "WHERE ConsultaHospitalar.Codigo=" + CodConsulta;
                else
                    SQL += "WHERE ConsultaHospitalar.CodAtendimento=" + CodAtendimento + " and ConsultaHospitalar.Codigo=" + CodConsulta;

                DataTable DtDados = new DataTable();              
                var ob = Conexao.ClienteSql.SELECT(SQL);
                DtDados = (DataTable)ob;
                result = DataTableHelper.DataTableToList<ConsultaHospitalarViewModel>(DtDados);

            }
            catch (Exception) { }

            return result;
        }

        public IEnumerable<MarcacaoConsultaViewModel> ListConsultaMarcadas(string CodAtendimento)
        {
            var result = new List<MarcacaoConsultaViewModel>();
            try
            {
                DataTable DtDados = new DataTable();
                string SQL = "Select ConsultaHospitalar.Codigo, ConsultaHospitalar.CodMedico, TipoConsultas.CodEspecialidade as CodEspecialidade, TipoConsultas.Descricao as TipoConsulta, Entidades.Nome as Medico,ConsultaHospitalar.HoraInicial as HoraMarcada," +
                    " ConsultaHospitalar.Atendido, ConsultaHospitalar.CodPaciente from ConsultaHospitalar join TipoConsultas on TipoConsultas.Codigo=ConsultaHospitalar.CodTipoConsulta " +
                    "join Medicos on Medicos.Codigo=ConsultaHospitalar.CodMedico " +
                    "join  Entidades on Entidades.Codigo=Medicos.CodPessoa " +
                    " Where ConsultaHospitalar.CodAtendimento= " + CodAtendimento;
                var ob = Conexao.ClienteSql.SELECT(SQL);
                DtDados = (DataTable)ob;
                result = DataTableHelper.DataTableToList<MarcacaoConsultaViewModel>(DtDados);

            }
            catch (Exception) { }

            return result;
        }

        public IEnumerable<MarcacaoConsultaViewModel> ListConsultaIndividual(string Codigo)
        {
            var result = new List<MarcacaoConsultaViewModel>();
            try
            {
                DataTable DtDados = new DataTable();
                string SQL = "SELECT * FROM ConsultaHospitalar WHERE ConsultaHospitalar.Codigo= " + Codigo;
                var ob = Conexao.ClienteSql.SELECT(SQL);
                DtDados = (DataTable)ob;
                result = DataTableHelper.DataTableToList<MarcacaoConsultaViewModel>(DtDados);

            }
            catch (Exception) { }

            return result;
        }

        public void UpdateAtendimento(List<ConsultaHospitalar> Lista)
        {
            try
            {
                for (int i = 0; i < Lista.Count; i++)
                {
                    if (Lista[i].Codigo!=0)
                    {
                        if (Lista[i].CodPaciente == 0 && Lista[i].CodTipoConsulta == 0 && Lista[i].HoraInicial == null)
                        {
                            string Nome = "ConsultaHospitalar";
                            string[] Campos = { "CodAtendimento" };
                            Object[] Valores = { Lista[i].CodAtendimento };
                            Conexao.ClienteSql.UPDATE(Nome, Campos, Valores, "Codigo ='" + Lista[i].Codigo + "'");
                        }
                       
                    }
                }
            }
            catch (Exception) { throw new Exception("Erro na Actualizacao de Consulta"); }
        }

        public IEnumerable<MarcacaoConsultaViewModel> ListarConsultaMedico(int Codigo, string Data, string DataFim)
        {
            var result = new List<MarcacaoConsultaViewModel>();
            try
            {
                var Data1 = Convert.ToDateTime(Data).ToString("yyyy-MM-dd");
                var Data2 = Convert.ToDateTime(DataFim).ToString("yyyy-MM-dd");


                DataTable DtDados = new DataTable();
                string SQL =
                    " SELECT  ConsultaHospitalar.Codigo, ConsultaHospitalar.CodAtendimento , TipoConsultas.Descricao as TipoConsulta, " +
                              " Prioridade.Descricao as Prioridade, ConsultaHospitalar.CodMedico, " +
                              " ConsultaHospitalar.CodPaciente,  Entidades.Codigo as CodEntidade, " +
                              " Entidades.Nome as NomePaciente, ConsultaHospitalar.[Data], " +
                              " ConsultaHospitalar.HoraInicial,  ConsultaHospitalar.TempoEstimado, ConsultaHospitalar.Atendido " +
                    " FROM    ConsultaHospitalar" +
                              " join TipoConsultas on TipoConsultas.Codigo = ConsultaHospitalar.CodTipoConsulta " +
                              " join Prioridade on Prioridade.Codigo = ConsultaHospitalar.CodPrioridade " +
                              " join TipoServico  on TipoServico.Codigo = ConsultaHospitalar.CodTipoServico " +
                              " join Pacientes on Pacientes.Codigo = ConsultaHospitalar.CodPaciente " +
                              " join Entidades on Entidades.Codigo = Pacientes.CodPessoa " +
                              " WHERE ConsultaHospitalar.CodMedico = " + Codigo + " AND ConsultaHospitalar.[Data]  between '" + Data1 + "' and '" + Data2 + "'";

                var ob = Conexao.ClienteSql.SELECT(SQL);
                DtDados = (DataTable)ob;
                result = DataTableHelper.DataTableToList<MarcacaoConsultaViewModel>(DtDados);

            }
            catch (Exception) { }

            return result;
        }

        #region Filtrar Relatorio Consultorio
        public IEnumerable<ConsultaHospitalarViewModel> ListarSemFiltro()
        {
            var result = new List<ConsultaHospitalarViewModel>();
            try
            {
                string SQL = "Select ConsultaHospitalar.Codigo, TipoConsultas.Codigo as CodTipoConsulta, TipoConsultas.Descricao as TipoConsulta,TipoConsultas.CodEspecialidade, Prioridade.Codigo as CodPrioridade," +
                    "Prioridade.Descricao as Prioridade, TipoServico.Codigo as CodTipoServico, TipoServico.Descricao as TipoServico, ConsultaHospitalar.CodMedico, Entidades.Codigo as CodEntidade," +
                    "Entidades.Nome as NomeMedico, ConsultaHospitalar.CodAtendimento, ConsultaHospitalar.Atendido, ConsultaHospitalar.[Data], ConsultaHospitalar.HoraInicial,ConsultaHospitalar.TempoEstimado," +
                    "ConsultaHospitalar.ValorConsulta,ConsultaHospitalar.Observacao, Imposto.Codigo as CodImposto, Imposto.Descricao as Imposto, Imposto.Percentagem, MotivoIsencao.Codigo as CodMotivoIsencao, MotivoIsencao.Descricao as MotivoIsecao from ConsultaHospitalar join TipoConsultas " +
                    "on TipoConsultas.Codigo=ConsultaHospitalar.CodTipoConsulta join Prioridade on Prioridade.Codigo=ConsultaHospitalar.CodPrioridade join TipoServico " +
                    "on TipoServico.Codigo=ConsultaHospitalar.CodTipoServico  join Medicos on Medicos.Codigo=ConsultaHospitalar.CodMedico join Entidades on Entidades.Codigo=Medicos.CodPessoa left join Imposto on Imposto.Codigo=ConsultaHospitalar.CodImposto left join MotivoIsencao on MotivoIsencao.Codigo=ConsultaHospitalar.CodMotivoIsencao ";

                DataTable DtDados = new DataTable();
                var ob = Conexao.ClienteSql.SELECT(SQL);
                DtDados = (DataTable)ob;
                result = DataTableHelper.DataTableToList<ConsultaHospitalarViewModel>(DtDados);

            }
            catch (Exception) { }

            return result;
        }
        public IEnumerable<ConsultaHospitalarViewModel> ListarComFiltro(string valor, string dtInicoEst, string dtFim)
        {
            var result = new List<ConsultaHospitalarViewModel>();
            try
            {
                
                string SQL = "Select ConsultaHospitalar.Codigo, TipoConsultas.Codigo as CodTipoConsulta, TipoConsultas.Descricao as TipoConsulta,TipoConsultas.CodEspecialidade, Prioridade.Codigo as CodPrioridade," +
                "Prioridade.Descricao as Prioridade, TipoServico.Codigo as CodTipoServico, TipoServico.Descricao as TipoServico, ConsultaHospitalar.CodMedico, Entidades.Codigo as CodEntidade," +
                "Entidades.Nome as NomeMedico, ConsultaHospitalar.CodAtendimento, ConsultaHospitalar.Atendido, ConsultaHospitalar.[Data], ConsultaHospitalar.HoraInicial,ConsultaHospitalar.TempoEstimado," +
                "ConsultaHospitalar.ValorConsulta,ConsultaHospitalar.Observacao, Imposto.Codigo as CodImposto, Imposto.Descricao as Imposto, Imposto.Percentagem, MotivoIsencao.Codigo as CodMotivoIsencao, MotivoIsencao.Descricao as MotivoIsecao from ConsultaHospitalar join TipoConsultas " +
                "on TipoConsultas.Codigo=ConsultaHospitalar.CodTipoConsulta join Prioridade on Prioridade.Codigo=ConsultaHospitalar.CodPrioridade join TipoServico " +
                "on TipoServico.Codigo=ConsultaHospitalar.CodTipoServico  join Medicos on Medicos.Codigo=ConsultaHospitalar.CodMedico join Entidades on Entidades.Codigo=Medicos.CodPessoa left join Imposto on Imposto.Codigo=ConsultaHospitalar.CodImposto left join MotivoIsencao on MotivoIsencao.Codigo=ConsultaHospitalar.CodMotivoIsencao " +
                "WHERE ConsultaHospitalar.[Data] between '"+dtInicoEst+ "' and '"+dtFim+ "' and ConsultaHospitalar.Atendido = '"+ valor+"'";
                
                DataTable DtDados = new DataTable();
                var ob = Conexao.ClienteSql.SELECT(SQL);
                DtDados = (DataTable)ob;
                result = DataTableHelper.DataTableToList<ConsultaHospitalarViewModel>(DtDados);

            }
            catch (Exception) { }

            return result;
        }

        
        #endregion

    }
}
