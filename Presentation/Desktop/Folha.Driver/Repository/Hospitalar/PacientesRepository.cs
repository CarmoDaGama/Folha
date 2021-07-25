using Folha.Driver.Repository;
using Folha.Domain.Models.Db;
using Folha.Domain.Interfaces.Repository.Hospitalar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Folha.Domain.Models.Hospitalar;
using Folha.Driver.Repository.Data;
using System.Data;
using System.Windows.Forms;
using Folha.Domain.ViewModels.Hospitalar;
using Folha.Domain.Helpers;
using Folha.Domain.Models.Entidades;

namespace Folha.Driver.Repository.Hospitalar
{
    using Folha.Domain.Models.Entidades;
    using Folha.Domain.Interfaces.Application.Entidades;
    using Folha.Domain.ViewModels.Frame.Entidades;

    public class PacientesRepository : RepositoryBase<DbDTO>, IPacienteRepository
    {
        private readonly IEntidadesApp _EntidadesApp;
        public void Delete(Paciente tabela)
        {
            int Cod;
            try
            {
                string tabelaPacientes = "Pacientes";
                string[] camposPacientes = { "status" };
                Object[] valoresPacientes = { tabela.status };
                Cod = tabela.CodPessoa;
                Conexao.ClienteSql.UPDATE(tabelaPacientes, camposPacientes, valoresPacientes, "CodPessoa='" + tabela.CodPessoa + "'");

                string tabelaEntidades = "Entidades";
                string[] camposEntidades = { "status" };
                Object[] valoresEntidades = { 0 };
                Conexao.ClienteSql.UPDATE(tabelaEntidades, camposEntidades, valoresEntidades, "Codigo='" + Cod + "'");
            }
            catch (Exception) { }
        }

        public object Get(Paciente tabela)
        {
            throw new NotImplementedException();
        }

        public object GetAll(Paciente tabela)
        {
            throw new NotImplementedException();
        }
        
        public List<PacienteViewModel> GetAll(PacienteViewModel pacienteViewModel,string criterios)
        {
            List<PacienteViewModel> pacientes = new List<PacienteViewModel>();
            try
            {
                if (criterios != null)
                {
                    String SQL = "SELECT Pacientes.Codigo as Codigo, " +
                                         "Pacientes.CodPessoa as CodEntidade," +
                                         "Pacientes.CodGrupoSanguineos," +
                                         " Entidades.Nome as Nome ," +
                                         "Sexo.descricao as Sexo," +
                                         "GrupoSanguineos.Descricao as Descricao," +
                                         "EntidadesPessoa.DataNascimento as DataNascimento," +
                                         "Habilitacoes.Descricao as Descricao," +
                                         "Pacientes.status," +
                                         "Profissao.Descricao as Descricao " +
                                 "from Pacientes, EntidadesPessoa, Entidades,Sexo,GrupoSanguineos,Habilitacoes," +
                                 "Profissao where Pacientes.CodPessoa = Entidades.Codigo and EntidadesPessoa.CodEntidade = Entidades.Codigo and " +
                                 "EntidadesPessoa.CodSexo = Sexo.codigo and GrupoSanguineos.Codigo=Pacientes.CodGrupoSanguineos and " +
                                 "Habilitacoes.Codigo = EntidadesPessoa.CodHabilitacao and Profissao.Codigo = EntidadesPessoa.CodProfissao and" +
                                 " (Entidades.Nome Like '%" + criterios + "%' OR Entidades.Codigo Like '" + criterios + "')";

                    object obj = Conexao.ClienteSql.SELECT(SQL);
                    DataTable dtFornmas = (DataTable)obj;

                    pacientes = DataTableHelper.DataTableToList<PacienteViewModel>(dtFornmas);
                    return pacientes;
                }
                else
                {
                    String SQL = "SELECT Pacientes.Codigo as Codigo, Pacientes.CodPessoa as CodEntidade, Entidades.Nome as Nome ,Sexo.descricao as Sexo,GrupoSanguineos.Descricao as Descricao,EntidadesPessoa.DataNascimento as DataNascimento,Habilitacoes.Descricao as Descricao,Profissao.Descricao as Descricao from Pacientes Left Outer Join Entidades on Entidades.Codigo = Pacientes.CodPessoa Left Outer Join EntidadesPessoa on EntidadesPessoa.CodEntidade = Entidades.Codigo Left Outer Join Sexo on Sexo.codigo = EntidadesPessoa.CodSexo Left Outer Join GrupoSanguineos on GrupoSanguineos.Codigo = Pacientes.CodGrupoSanguineos Left Outer Join Habilitacoes on Habilitacoes.Codigo = EntidadesPessoa.CodHabilitacao Left Outer Join Profissao on Profissao.Codigo = EntidadesPessoa.CodProfissao WHERE Pacientes.status = 1";
                    object obj = Conexao.ClienteSql.SELECT(SQL);
                    DataTable dtFornmas = (DataTable)obj;

                    pacientes = DataTableHelper.DataTableToList<PacienteViewModel>(dtFornmas);
                    return pacientes;
                }
               
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao carregar formas \n" + ex);
            }
        }
        
        public PacienteViewModel GetById(int id)
        {
            List<PacienteViewModel> pacientes = new List<PacienteViewModel>();
            try
            {
                String SQL = "SELECT Pacientes.Codigo as Codigo, " +
                                        "Pacientes.CodPessoa as CodEntidade," +
                                        " Entidades.Nome as Nome ," +
                                        "Sexo.descricao as Sexo," +
                                        "GrupoSanguineos.Descricao as Descricao," +
                                        "EntidadesPessoa.DataNascimento as DataNascimento," +
                                        "Habilitacoes.Descricao as Descricao," +
                                        "Profissao.Descricao as Descricao " +
                                "from Pacientes, EntidadesPessoa, Entidades,Sexo,GrupoSanguineos,Habilitacoes,Profissao where Pacientes.CodPessoa = Entidades.Codigo and EntidadesPessoa.CodEntidade = Entidades.Codigo and EntidadesPessoa.CodSexo = Sexo.codigo and GrupoSanguineos.Codigo=Pacientes.CodGrupoSanguineos and Habilitacoes.Codigo = EntidadesPessoa.CodHabilitacao and Profissao.Codigo = EntidadesPessoa.CodProfissao and Pacientes.status = 1 and  Pacientes.Codigo = '" + id + "'";

                object obj = Conexao.ClienteSql.SELECT(SQL);
                DataTable dtFornmas = (DataTable)obj;

                pacientes = DataTableHelper.DataTableToList<PacienteViewModel>(dtFornmas);
                if (UtilidadesGenericas.ListaNula(pacientes))
                {
                    return null;
                }
                return pacientes[0];

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao carregar formas \n" + ex);
            }
        }
        public string RetornaGrupoSanguines(string CodPaciente)
        {
            string Descricao=null;
            string SQL = "SELECT GrupoSanguineos.Descricao FROM Pacientes join  GrupoSanguineos on GrupoSanguineos.Codigo=Pacientes.CodGrupoSanguineos WHERE Pacientes.Codigo="+CodPaciente;
            object obj = Conexao.ClienteSql.SELECT(SQL);
            DataTable dtDados = (DataTable)obj;
            Descricao = dtDados.Rows[0][0].ToString();
            return Descricao;
        }
        public List<PacienteViewModel> RetornaGrupoSPaciente(string Codgrupo)
        {
            List<PacienteViewModel> pacientes = new List<PacienteViewModel>();
            try
            {
                String SQL = "SELECT Pacientes.Codigo as Codigo, Pacientes.CodPessoa as CodEntidade, Entidades.Nome as Nome ,Sexo.descricao as Sexo,GrupoSanguineos.Descricao as Descricao,EntidadesPessoa.DataNascimento as DataNascimento,Habilitacoes.Descricao as Descricao,Profissao.Descricao as Descricao from Pacientes, EntidadesPessoa, Entidades,Sexo,GrupoSanguineos,Habilitacoes,Profissao where Pacientes.CodPessoa = Entidades.Codigo and EntidadesPessoa.CodEntidade = Entidades.Codigo and EntidadesPessoa.CodSexo = Sexo.codigo and GrupoSanguineos.Codigo=Pacientes.CodGrupoSanguineos and Habilitacoes.Codigo = EntidadesPessoa.CodHabilitacao and Profissao.Codigo = EntidadesPessoa.CodProfissao and Pacientes.status = 1 and GrupoSanguineos.Descricao = '" + Codgrupo + "'";
                object obj = Conexao.ClienteSql.SELECT(SQL);
                DataTable dtFornmas = (DataTable)obj;

                pacientes = DataTableHelper.DataTableToList<PacienteViewModel>(dtFornmas);
                return pacientes;
            }
            catch (Exception)
            {

                throw;
            }
          
        }
        public void Insert(Paciente tabela)
        {
            try
            {
                string tabelaPacientes = "Pacientes";
                string[] camposPacientes = { "CodPessoa", "CodGrupoSanguineos" };
                Object[] valoresPacientes = { tabela.CodPessoa, tabela.CodGrupoSanguineos };
                Conexao.ClienteSql.INSERT(tabelaPacientes, camposPacientes, valoresPacientes);
            }
            catch (Exception) { }
        }

        public IEnumerable<Paciente> Listar(string criterios)
        {
            throw new NotImplementedException();
        }

        public List<GrupoSanguineos> ListarGrupoSanguineo(GrupoSanguineos GrupoSanguineo)
        {
            List<GrupoSanguineos> GrupoSanguineos = new List<GrupoSanguineos>();

            try
            {
                String SQL = "select * from GrupoSanguineos";
                object obj = Conexao.ClienteSql.SELECT(SQL);
                DataTable dtFornmas = (DataTable)obj;

                GrupoSanguineos = DataTableHelper.DataTableToList<GrupoSanguineos>(dtFornmas);
                return GrupoSanguineos;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void Update(Paciente tabela)
        {
            try
            {
                string tabelaPacientes = "Pacientes";
                string[] camposPacientes = { "CodGrupoSanguineos", "status" };
                Object[] valoresPacientes = { tabela.CodGrupoSanguineos, tabela.status };

                Conexao.ClienteSql.UPDATE(tabelaPacientes, camposPacientes, valoresPacientes, "CodPessoa='" + tabela.CodPessoa+"'");
            }
            catch (Exception) { }
        }

        public void UpdatePaciente(Paciente Paciente, string criterios)
        {
            throw new NotImplementedException();
        }
    }
}
