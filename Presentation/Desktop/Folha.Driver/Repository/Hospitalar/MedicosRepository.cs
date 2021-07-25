using Folha.Domain.Interfaces.Repository.Hospitalar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Folha.Domain.Models.Hospitalar;
using Folha.Driver.Repository;
using Folha.Domain.Models.Db;
using Folha.Driver.Repository.Data;
using System.Data;
using Folha.Domain.ViewModels.Frame.Hospitalar;
using Folha.Domain.Helpers;

namespace Folha.Driver.Repository.Hospitalar
{
    public class MedicosRepository : RepositoryBase<DbDTO>, IMedicosRepository
    {
        public void AddMedicoEspecialidade(List<MedicosEspecialidades> Lista)
        {
            try
            {
                for (int i = 0; i < Lista.Count; i++)
                {
                    if (Lista[0].Codigo == 0)
                    {
                        DbDTO dto = new DbDTO()
                        {
                            Nome = "MedicosEspecialidades",
                            Campos = new string[] { "CodMedico", "CodEspecialidade" },
                            Valores = new Object[] { Lista[i].CodMedico, Lista[i].CodEspecialidade }
                        };
                        Conexao.ClienteSql.INSERT(dto.Nome, dto.Campos, dto.Valores);
                    }
                }
            }
            catch (Exception) { throw new Exception("Erro ao Especialidade"); }

        }
        public Medicos Eliminar(Medicos medico)
        {
            string tabela = "Medicos";
            string[] campos = { "status" };
            Object[] valores = { 0 };
            string[] critX = { "Codigo = '" + medico.Codigo + "'" };
            Conexao.ClienteSql.UPDATE(tabela, campos, valores, critX);
            return medico;

        }
        public void Delete(Medicos tabela)
        {
            throw new NotImplementedException();
        }

        public object Get(Medicos tabela)
        {
            throw new NotImplementedException();
        }

        public object GetAll(Medicos tabela)
        {
            var result = new List<MedicosEspecialidades>();

            var obj = Conexao.ClienteSql.SELECT("SELECT * FROM MedicosEspecialidades");

            DataTable dtadados = (DataTable)obj;

            result = Folha.Domain.Helpers.DataTableHelper.DataTableToList<MedicosEspecialidades>(dtadados);

            return result;
        }

        public IEnumerable<Medicos> GetMedico(string CodPessoa)
        {
            var result = new List<Medicos>();

            string[] tabelas = { "Medicos" };
            string[] campos = { "Codigo", "CodPessoa", "NumeroCarteira", "CodEscala" };

            if (CodPessoa != null)
            {
                string[] cri = { "CodPessoa = '" + CodPessoa + "'" };
                Object ob = Conexao.ClienteSql.SELECT(tabelas, campos, cri);
                try
                {
                    result = Folha.Domain.Helpers.DataTableHelper.DataTableToList<Medicos>((DataTable)ob);
                    return result;
                }
                catch (Exception)
                {
                    throw new Exception("Erro a Carregar Tabela Medicos\n");
                }
            }
            else
            {
                Object ob = Conexao.ClienteSql.SELECT(tabelas, campos, null);
                try
                {
                    result = Folha.Domain.Helpers.DataTableHelper.DataTableToList<Medicos>((DataTable)ob);
                    return result;
                }
                catch (Exception)
                {
                    throw new Exception("Erro a Carregar Tabela Medicos\n");
                }
            }
        }

        public IEnumerable<MedicosEspecialidades> GetAllMedicoEspecialidade(string CodMedico)
        {
            var result = new List<MedicosEspecialidades>();

            string[] tabelas = { "MedicosEspecialidades" };
            string[] campos = { "Codigo", "CodMedico", "CodEspecialidade" };

            if (CodMedico != null)
            { 
            string[] cri = { "CodMedico = '" + CodMedico + "'" };
            Object ob = Conexao.ClienteSql.SELECT(tabelas, campos, cri);
                try
                {
                    result = Folha.Domain.Helpers.DataTableHelper.DataTableToList<MedicosEspecialidades>((DataTable)ob);
                    return result;
                }
                catch (Exception)
                {
                    throw new Exception("Erro a Carregar Tabela Medicos\n");
                }
            }
            else
            {
                string[] cri = { "CodMedico = '" + CodMedico + "'" };
                Object ob = Conexao.ClienteSql.SELECT(tabelas, campos, null);
                try
                {
                    result = Folha.Domain.Helpers.DataTableHelper.DataTableToList<MedicosEspecialidades>((DataTable)ob);
                    return result;
                }
                catch (Exception)
                {
                    throw new Exception("Erro a Carregar Tabela Medicos\n");
                }
            }
        }

        public void Insert(Medicos tabela)
        {
            try
            {
                DbDTO dto = new DbDTO()
                {
                    Nome = "Medicos",
                    Campos = new string[] { "CodPessoa","NumeroCarteira","CodEscala","status" },
                    Valores = new Object[] { tabela.CodPessoa,tabela.NumeroCarteira,tabela.CodEscala, 1}
                };
                Conexao.ClienteSql.INSERT(dto.Nome, dto.Campos, dto.Valores);

            }
            catch (Exception) { throw new Exception("Erro ao Cadastrar Médico"); }
        }

        public List<MedicoEspecialidadeViewModel> ListarMedicoEspecialidade(string CodMedico)
        {
            var result = new List<MedicoEspecialidadeViewModel>();
            try
            {
                
                DataTable DtDados = new DataTable();

                string SQL = "SELECT MedicosEspecialidades.Codigo, Especialidades.Codigo AS CodEspecialidade, Especialidades.Descricao from MedicosEspecialidades join Especialidades on Especialidades.Codigo=MedicosEspecialidades.CodEspecialidade where MedicosEspecialidades.CodMedico='" + CodMedico + "'";
                var ob = Conexao.ClienteSql.SELECT(SQL);
                DtDados = (DataTable)ob;
                result = DataTableHelper.DataTableToList<MedicoEspecialidadeViewModel>(DtDados);
                
            }
            catch(Exception) { }

            return result;
        }

        public List<MedicosViewModel> ListarMedicosDisponiveis(string Nome, string CodEscala, string CodEspecialidade, string hora, string data)
        {
            var medicos = (List<MedicosViewModel>)ListarMedicos(Nome, CodEscala, CodEspecialidade);
            for(int i = medicos.Count -1; i > -1; i--)
            {
                if (existeCosulta(medicos[i].CodMedico, hora, data))
                {
                    medicos.RemoveAt(i);
                }
            }
            return medicos;
        }

        private bool existeCosulta(int codMedico, string hora, string data)
        {
            string query = "SELECT * FROM ConsultaHospitalar WHERE CodMedico = " + codMedico + " AND HoraInicial = '" + hora + "' AND [Data] = '" + Convert.ToDateTime(data).ToString("yyyy-MM-dd") + "'";
            var objectData = Conexao.ClienteSql.SELECT(query);
            DataTable tabelaConsultaHospitalar = (DataTable)objectData;

            return tabelaConsultaHospitalar.Rows.Count > 0;
        }

        public IEnumerable<MedicosViewModel> ListarMedicos(string Nome, string CodEscala,string CodEspecialidade)
        {                      
            DataTable DtDados = new DataTable();
            try
            {
                List<MedicosViewModel> resultado = new List<MedicosViewModel>();
                string SQL = "SELECT Medicos.CodEscala, Medicos.Codigo AS CodMedico, Entidades.Codigo as CodEntidade, Entidades.Nome, Medicos.status From Medicos join Entidades on Entidades.Codigo = Medicos.CodPessoa";

                if (!string.IsNullOrEmpty(CodEscala) && !string.IsNullOrEmpty(CodEspecialidade))
                {
                    List<MedicosEspecialidades> LtMedicosEspecialidades;

                    SQL = "SELECT * FROM MedicosEspecialidades WHERE CodEspecialidade=" + CodEspecialidade;
                    DataTable DtDadosEspecialidade = new DataTable();
                    var obEspecialidade = Conexao.ClienteSql.SELECT(SQL);
                    DtDadosEspecialidade = (DataTable)obEspecialidade;
                    LtMedicosEspecialidades = DataTableHelper.DataTableToList<MedicosEspecialidades>(DtDadosEspecialidade);
                   
                    for (int i = 0; i < LtMedicosEspecialidades.Count; i++)
                    {
                        SQL = "SELECT Medicos.CodEscala, Medicos.Codigo AS CodMedico, Entidades.Codigo as CodEntidade, Entidades.Nome,  Medicos.status From Medicos join Entidades on Entidades.Codigo = Medicos.CodPessoa Where Medicos.CodEscala=" + CodEscala+" and Medicos.Codigo="+LtMedicosEspecialidades[i].CodMedico;
                        var ob = Conexao.ClienteSql.SELECT(SQL);
                        DtDados = (DataTable)ob;
                        var result = DataTableHelper.DataTableToList<MedicosViewModel>(DtDados);
                        if(result.Count>0)
                        resultado.Add(result[0]);
                    }

                    return resultado;

                }else if (string.IsNullOrEmpty(Nome))
                {
                    var ob = Conexao.ClienteSql.SELECT(SQL);
                    DtDados = (DataTable)ob;
                    var result = DataTableHelper.DataTableToList<MedicosViewModel>(DtDados);
                    return result;
                }
                else 
                {
                    SQL += " Where Entidades.Nome Like '%" + Nome + "%'";
                    var ob = Conexao.ClienteSql.SELECT(SQL);
                    DtDados = (DataTable)ob;
                    var result = DataTableHelper.DataTableToList<MedicosViewModel>(DtDados);
                    return result;
                }
            }
            catch(Exception ex) { throw new Exception("Erro ao Listar Medicos"+ex.Message); }
            }

        public void Update(Medicos tabela)
        {
            try
            {
                DbDTO dto = new DbDTO()
                {
                    Nome = "Medicos",
                    Campos = new string[] { "NumeroCarteira","CodEscala","status" },
                    Valores = new Object[] {tabela.NumeroCarteira,tabela.CodEscala,1 }
                };
                Conexao.ClienteSql.UPDATE(dto.Nome, dto.Campos, dto.Valores, "Codigo ='" + tabela.Codigo + "'");

            }
            catch (Exception ex) { throw new Exception("Erro ao Actualizar Médico"+ex.Message); }
        }

        public void UpdateMedicoEspecialidade(MedicosEspecialidades Dados)
        {
            try
            {
                DbDTO dto = new DbDTO()
                {
                    Nome = "MedicosEspecialidades",
                    Campos = new string[] { "CodEspecialidade" },
                    Valores = new Object[] {  Dados.CodEspecialidade }
                };
                Conexao.ClienteSql.UPDATE(dto.Nome, dto.Campos, dto.Valores, "Codigo ='" + Dados.Codigo+ "'");
            }
            catch (Exception ex) { throw new Exception("Erro ao Actualizar Especialidade"+ex.Message); }
        }

        public void DeleteListEspecialidade(List<MedicoEspecialidadeViewModel> Lista)
        {
            try
            {
                for (int i = 0; i < Lista.Count; i++)
                {
                    Conexao.ClienteSql.DELETE("MedicosEspecialidades", "Codigo ='" + Lista[i].Codigo + "'");
                }
            }
            catch (Exception x)
            {
                throw new Exception("Erro ao Deletar Especialidade do Médico\n" + x);
            }
        }

        public int GetIdMedico (string CodEntidade)
        {
            string[] tabelas = { "Medicos" };
            string[] campos = { "Codigo", "CodPessoa", "NumeroCarteira" };   
            string[] cri = { "CodPessoa = '" + CodEntidade + "'" };
            DataTable ob = (DataTable)Conexao.ClienteSql.SELECT(tabelas, campos, cri);
            if (ob.Rows.Count == 0)
            {
                return 0;
            }
            return Convert.ToInt16(ob.Rows[0]["Codigo"]);
        }

        public int GetLastIdMedico()
        {
            var result = new List<Medicos>();

            string[] tabelas = { "Medicos" };
            string[] campos = { "Codigo", "CodPessoa", "NumeroCarteira" };
            try
            {
                Object ob = Conexao.ClienteSql.SELECT(tabelas, campos, null);
                result = Folha.Domain.Helpers.DataTableHelper.DataTableToList<Medicos>((DataTable)ob);
                    return result[result.Count-1].Codigo;
            }
            catch (Exception)
            {
                    throw new Exception("Erro a Carregar LastCodigo\n");
            }    
            
        }

        public List<MedicosViewModel> ListarMedicoFiltrado(string criterio)
        {
            var result = new List<MedicosViewModel>();
            try
            {
                DataTable DtDados = new DataTable();
                string SQL = "SELECT MedicosEspecialidades.CodMedico,Entidades.Nome,Medicos.NumeroCarteira,Especialidades.Descricao as Especialidade From Medicos,Especialidades,MedicosEspecialidades,Entidades Where Medicos.Codigo=MedicosEspecialidades.CodMedico and Especialidades.Codigo=MedicosEspecialidades.CodEspecialidade and Entidades.Codigo=Medicos.CodPessoa";
                if (criterio!=null)
                {
                    SQL = "SELECT MedicosEspecialidades.CodMedico,Entidades.Nome,Medicos.NumeroCarteira,Especialidades.Descricao as Especialidade From Medicos,Especialidades,MedicosEspecialidades,Entidades Where Medicos.Codigo=MedicosEspecialidades.CodMedico and Especialidades.Codigo=MedicosEspecialidades.CodEspecialidade and Entidades.Codigo=Medicos.CodPessoa and Especialidades.Descricao='" + criterio + "'";
                }
                
                var ob = Conexao.ClienteSql.SELECT(SQL);
                DtDados = (DataTable)ob;
                result = DataTableHelper.DataTableToList<MedicosViewModel>(DtDados);

            }
            catch (Exception) { }

            return result;
        }
    }
}
