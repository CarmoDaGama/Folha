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

namespace Folha.Driver.Repository.Hospitalar
{
    public class ExamesHospitalarRepository : IExamesHospitalarRepository
    {
        public void Insert(ExamesHospitalar Dados)
        {
            Object _CodMotivoIsencao;
            if (Dados.CodMotivoIsencao == 0)
                _CodMotivoIsencao = DBNull.Value;
            else
                _CodMotivoIsencao = Dados.CodMotivoIsencao;

            try
            {
                DbDTO dto = new DbDTO()
                {
                    Nome = "ExamesHospitalar",
                    Campos = new string[] { "Descricao", "CodImposto", "CodMotivoIsencao", "CodSubCategoria", "Custo", "Preco", "Lucro", "PrecoVenda", "Foto", "status"},
                    Valores = new Object[] { Dados.Descricao, Dados.CodImposto, _CodMotivoIsencao, Dados.CodSubCategoria,Dados.Custo,Dados.Preco,Dados.Lucro,Dados.PrecoVenda,Dados.Foto,Dados.Status }
                };
                Conexao.ClienteSql.INSERT(dto.Nome, dto.Campos, dto.Valores);
            }
            catch (Exception) { throw new Exception("Erro ao Cadastrar Exame"); }
        }

        public IEnumerable<ExamesViewModel> ListarAtendimento(string CodAtendimento)
        {
            var result = new List<ExamesViewModel>();
            try
            {
                string SQL = "SELECT ExamesAtendimento.Codigo as CodExameAtendimento,ExamesHospitalar.Codigo as CodExame, ExamesAtendimento.CodPaciente, ExamesHospitalar.Descricao,ExamesHospitalar.Preco, ExamesAtendimento.TipoResultado, ExamesAtendimento.Data FROM ExamesAtendimento JOIN ExamesHospitalar" +
                    " on ExamesHospitalar.Codigo=ExamesAtendimento.CodExame  Where ExamesAtendimento.CodAtendimento=" + CodAtendimento;

                DataTable DtDados = new DataTable();
                var ob = Conexao.ClienteSql.SELECT(SQL);
                DtDados = (DataTable)ob;
                result = DataTableHelper.DataTableToList<ExamesViewModel>(DtDados);

            }
            catch (Exception) { }

            return result;
        }

        public IEnumerable<ExamesViewModel> ListarExamesHospitalar(string CodExame)
        {
            var result = new List<ExamesViewModel>();
            try
            {
                string SQL = "SELECT ExamesHospitalar.Codigo as CodExame, ExamesHospitalar.Descricao,ExamesHospitalar.CodImposto, Imposto.Descricao as Imposto,ExamesHospitalar.CodMotivoIsencao, " +
                    "MotivoIsencao.Descricao as MotivoIsencao, Imposto.Percentagem, ExamesHospitalar.CodSubCategoria,ExamesHospitalar.Custo, ExamesHospitalar.Preco, ExamesHospitalar.Lucro," +
                    "ExamesHospitalar.PrecoVenda,ExamesHospitalar.Foto,ExamesHospitalar.[status] from ExamesHospitalar LEFT JOIN Imposto on Imposto.Codigo=ExamesHospitalar.CodImposto LEFT JOIN " +
                    "MotivoIsencao on MotivoIsencao.Codigo=ExamesHospitalar.CodMotivoIsencao";
                if (!string.IsNullOrEmpty(CodExame))
                    SQL += " WHERE ExamesHospitalar.Codigo=" + CodExame;
                DataTable DtDados = new DataTable();
                var ob = Conexao.ClienteSql.SELECT(SQL);
                DtDados = (DataTable)ob;
                result = DataTableHelper.DataTableToList<ExamesViewModel>(DtDados);

            }
            catch (Exception) { }

            return result;
        }

        public void Update(ExamesHospitalar Dados)
        {
            try
            {
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

                DbDTO dto = new DbDTO()
                {
                    Nome = "ExamesHospitalar",
                    Campos = new string[] { "Descricao", "CodImposto", "CodMotivoIsencao", "CodSubCategoria", "Custo", "Preco", "Lucro", "Foto", "status" },
                    Valores = new Object[] { Dados.Descricao, _CodImposto,_CodMotivoIsencao, Dados.CodSubCategoria, Dados.Custo, Dados.Preco, Dados.Lucro, Dados.Foto, Dados.Status }
                };
                Conexao.ClienteSql.UPDATE(dto.Nome, dto.Campos, dto.Valores,"Codigo='"+Dados.Codigo+"'");
            }
            catch (Exception) { throw new Exception("Erro ao Actualizar Exame"); }
        }
        public void FecharFacturar(ExamesHospitalar Dados)
        {
            try
            {

                DbDTO dto = new DbDTO()
                {
                    Nome = "ExamesAtendimento",
                    Campos = new string[] { "Facturado" },
                    Valores = new Object[] { Dados.Facturado }
                };
                Conexao.ClienteSql.UPDATE(dto.Nome, dto.Campos, dto.Valores, "Codigo='" + Dados.Codigo + "'");
            }
            catch (Exception) { throw new Exception("Erro ao Actualizar Exame"); }
        }

        public void InsertUpdateExamesAtendimento(List<ExamesViewModel> Lista)
        {
            //try
            //{
                for (int i = 0; i < Lista.Count; i++)
                {
                    if(Lista[i].CodExameAtendimento == 0)
                    {
                        DbDTO dto = new DbDTO()
                        {
                            Nome = "ExamesAtendimento",
                            Campos = new string[] {
                                "CodPaciente",
                                "CodExame",
                                "Data",
                                "CodAtendimento",
                                "TipoResultado",
                                "status",
                                "Medico",
                                "NumeroProcesso",
                                "NumeroAmostra",
                                "ViaDocumento",

                            },
                            Valores = new Object[] {
                                Lista[i].CodPaciente,
                                Lista[i].CodExame,
                                DateTime.Now.Date.ToString("yyyy-MM-dd"),
                                Lista[i].CodAtendimento,
                                Lista[i].TipoResultado,
                                1,
                                Lista[i].Medico,
                                Lista[i].NumeroProcesso,
                                Lista[i].NumeroAmostra,
                                Lista[i].ViaDocumento
                            }
                        };
                        Conexao.ClienteSql.INSERT(dto.Nome, dto.Campos, dto.Valores);
                        Lista[i].CodExameAtendimento = Conexao.LastCodGeral("ExamesAtendimento");
                    }
                    else
                    {

                        DbDTO dto = new DbDTO()
                        {
                            Nome = "ExamesAtendimento",
                            Campos = new string[] {
                                "CodPaciente",
                                "CodExame",
                                "CodAtendimento",
                                "TipoResultado",
                                "Medico",
                                "NumeroProcesso",
                                "NumeroAmostra",
                                "ViaDocumento",
                            },
                            Valores = new Object[] {
                                Lista[i].CodPaciente,
                                Lista[i].CodExame,
                                Lista[i].CodAtendimento,
                                Lista[i].TipoResultado,
                                Lista[i].Medico,
                                Lista[i].NumeroProcesso,
                                Lista[i].NumeroAmostra,
                                Lista[i].ViaDocumento
                            }
                        };
                        Conexao.ClienteSql.UPDATE(dto.Nome, dto.Campos, dto.Valores, " Codigo = '"+ Lista[i].CodExameAtendimento + "'");
                    }
                    
                }
            
            //}
            //catch (Exception ex) { throw new Exception("Erro ao gravar ExamesAtendimento"); }
        }

        public void DeleteExamesAtendimento(ExamesAtendimento Dados)
        {
            try
            {
                 Conexao.ClienteSql.DELETE("ExamesAtendimento", "Codigo ='" + Dados.Codigo + "'");
            }
            catch (Exception){ throw new Exception("Erro ao Deletar Farmacos \n"); }
        }
    }
}
