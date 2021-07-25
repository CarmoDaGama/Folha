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
using Folha.Domain.ViewModels.Hospitalar;
using Folha.Domain.ViewModels.Report;

namespace Folha.Driver.Repository.Hospitalar
{
    public class TriagemRepository : ITriagemRepository
    {
        public void Insert(Triagem Dados)
        {
            try
            {
                DbDTO dto = new DbDTO()
                {
                    Nome = "Triagem",
                    Campos = new string[] { "CodPaciente", "Temperatura", "TemperaturaArterial", "Peso", "FrequenciaRespiratoria", "FrequenciaCardiaca","CodAtendimento","Data","Hora" },
                    Valores = new Object[] { Dados.CodPaciente,Dados.Temperatura,Dados.TemperaturaArterial,Dados.Peso,Dados.FrequenciaRespiratoria,Dados.FrequenciaCardiaca,Dados.CodAtendimento,DateTime.Now,DateTime.Now.ToShortTimeString() }
                };
                Conexao.ClienteSql.INSERT(dto.Nome, dto.Campos, dto.Valores);
            }
            catch (Exception) { throw new Exception("Erro ao Cadastrar Triagem"); }
        }

        public IEnumerable<TriagemViewModel> Listar(string CodAtendimento)
        {
            var result = new List<TriagemViewModel>();
            string SQL = "select * from Triagem join AtendimentoHospitalar on AtendimentoHospitalar.Codigo=Triagem.CodAtendimento where CodAtendimento=" + CodAtendimento;
    
            Object ob = Conexao.ClienteSql.SELECT(SQL);

            try
            {
                    result = Folha.Domain.Helpers.DataTableHelper.DataTableToList<TriagemViewModel>((DataTable)ob);
                    return result;
            }
            catch (Exception)
            {
                    throw new Exception("Erro a Carregar Tabela Triagem\n");
            }
            
        }

        public IEnumerable<TriagemViewModel> ListarComFiltro(string dataInicial, string dataFinal,int CodPaciente)
        {
            var result = new List<TriagemViewModel>();
            string SQL = "select * from Triagem  where Triagem.CodPaciente=" + CodPaciente;
            if(!string.IsNullOrEmpty(dataInicial)&&!string.IsNullOrEmpty(dataFinal))
            SQL +=" and Triagem.[Data] between '" + dataInicial + "' and '" + dataFinal + "'";
            Object ob = Conexao.ClienteSql.SELECT(SQL);

            try
            {
                result = Folha.Domain.Helpers.DataTableHelper.DataTableToList<TriagemViewModel>((DataTable)ob);
                return result;
            }
            catch (Exception)
            {
                throw new Exception("Erro a Carregar Tabela Triagem\n");
            }

        }
        public DataViewModel RetornaDataTriagem(int CodPaciente)
        {
            var result = new DataViewModel();
            string SQL = "select Min(Triagem.[Data]) as DataInicial, Max(Triagem.[Data]) as DataFinal from Triagem  where Triagem.CodPaciente=" + CodPaciente;
            Object ob = Conexao.ClienteSql.SELECT(SQL);
            DataTable Dados = (DataTable)ob;
            try
            {
                if (Dados.Rows.Count>0)
                {
                    result.DataInicial = Convert.ToDateTime(Dados.Rows[0]["DataInicial"]);
                    result.DataFinal = Convert.ToDateTime(Dados.Rows[0]["DataFinal"]);
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
        public void Update(Triagem Dados)
        {
            //try
            //{
                if(Dados.CodPaciente == 0 && Dados.Temperatura == 0 & Dados.TemperaturaArterial == "00/00")
                {
                    DbDTO dto = new DbDTO()
                    {
                        Nome = "Triagem",
                        Campos = new string[] { "CodAtendimento" },
                        Valores = new Object[] {Dados.CodAtendimento }
                    };
                    Conexao.ClienteSql.UPDATE(dto.Nome, dto.Campos, dto.Valores, "Codigo ='" + Dados.Codigo + "'");
                }
                else
                {
                    DbDTO dto = new DbDTO()
                    {
                        Nome = "Triagem",
                        Campos = new string[] { "Temperatura", "TemperaturaArterial", "Peso", "FrequenciaRespiratoria", "FrequenciaCardiaca" },
                        Valores = new Object[] { Dados.Temperatura, Dados.TemperaturaArterial, Dados.Peso, Dados.FrequenciaRespiratoria, Dados.FrequenciaCardiaca }
                    };
                    Conexao.ClienteSql.UPDATE(dto.Nome, dto.Campos, dto.Valores, "Codigo ='" + Dados.Codigo + "'");
                }
               
            //}
            //catch (Exception ex ) { throw new Exception("Erro ao Actualizar Triagem"); }
        }
    }
}
