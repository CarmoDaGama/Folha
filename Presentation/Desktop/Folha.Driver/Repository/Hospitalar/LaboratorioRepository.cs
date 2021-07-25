using Folha.Driver.Repository;
using Folha.Domain.Models.Db;
using Folha.Domain.Interfaces.Repository.Hospitalar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Folha.Domain.Models.Hospitalar;
using Folha.Domain.ViewModels.Hospitalar;
using Folha.Driver.Repository.Data;
using System.Data;
using Folha.Domain.Helpers;
using Folha.Domain.ViewModels.Entidades;
using Folha.Driver.Repository.Entidades;

namespace Folha.Driver.Repository.Hospitalar
{
    public class LaboratorioRepository : RepositoryBase<DbDTO>, ILaboratorioRepository
    {
        public void Delete(Laboratorio lab)
        {
            DbDTO dto = new DbDTO()
            {
                Nome = "ExamesAtendimento",
            };
            Conexao.ClienteSql.DELETE(dto.Nome, "Codigo ='" + lab.Codigo + "'");
        }

        public void Delete(ExamesAtendimentoViewModel tabela)
        {
            throw new NotImplementedException();
        }
        
        public object Get(ExamesAtendimentoViewModel tabela)
        {
            return Db.GetById<ExamesAtendimentoViewModel>(tabela.Codigo);
        }

        public List<ExamesAtendimentoViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public object GetAll(ExamesAtendimentoViewModel tabela)
        {
            throw new NotImplementedException();
        }


        public Laboratorio Gravar(Laboratorio lab)
        {


        string tabela = "ExamesAtendimento";
            string[] campos = { "CodProfissionalSaude", "Estado", "status", "VReferencia", "Unidade", "NumeroAmostra" };
            Object[] valores = { lab.CodProfissional, lab.Estado, lab.status, lab.VReferencia, lab.Unidade, lab.NumeroAmostra};
            string[] critX = { "Codigo = '" + lab.Codigo + "'" };

            if (lab.Codigo == 0)
            {
                Conexao.ClienteSql.INSERT(tabela, campos, valores);
            }
            else
            {
                Conexao.ClienteSql.UPDATE(tabela, campos, valores, critX);
            }
            return lab;
        }

        public void Insert(ExamesAtendimentoViewModel tabela)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Laboratorio> Listar(string criterios)
        {
            DataTable DtDados = new DataTable();
            try
            {
                string SQL = "SELECT ExamesAtendimento.Codigo, Entidades.Nome, ExamesHospitalar.Descricao," +
                    " ExamesAtendimento.Data,ExamesAtendimento.CodAtendimento, ExamesAtendimento.TipoResultado, ExamesAtendimento.Estado," +
                    "ExamesAtendimento.status from ExamesAtendimento " +
                    "Join Pacientes on Pacientes.Codigo =ExamesAtendimento.CodPaciente " +
                    "Join ExamesHospitalar on ExamesHospitalar.Codigo=ExamesAtendimento.CodExame " +
                    "Join EntidadesPessoa on Pacientes.CodPessoa = EntidadesPessoa.CodEntidade " +
                    "Join Entidades on Entidades.Codigo = EntidadesPessoa.CodEntidade";
                
                    var ob = Conexao.ClienteSql.SELECT(SQL);
                    DtDados = (DataTable)ob;
                    var result = DataTableHelper.DataTableToList<Laboratorio>(DtDados);
                    return result;
            }
            catch (Exception) { throw new Exception("Erro ao Listar"); }
        }
        #region filtrar os dados do Laboratorio (Dados hospitalar) ==================================================================
        public IEnumerable<Laboratorio> FiltrarLaboratorioEstadoData(string valor,string dtInicoEst, string dtFim)
        {
            DataTable DtDados = new DataTable();
            try
            {
                //Estado
                string SQL = "SELECT ExamesAtendimento.Codigo, Entidades.Nome, ExamesHospitalar.Descricao," +
               " ExamesAtendimento.Data,ExamesAtendimento.CodAtendimento, ExamesAtendimento.TipoResultado, ExamesAtendimento.Estado," +
               "ExamesAtendimento.status from ExamesAtendimento " +
               "Join Pacientes on Pacientes.Codigo =ExamesAtendimento.CodPaciente " +
               "Join ExamesHospitalar on ExamesHospitalar.Codigo=ExamesAtendimento.CodExame " +
               "Join EntidadesPessoa on Pacientes.CodPessoa = EntidadesPessoa.CodEntidade " +
               "Join Entidades on Entidades.Codigo = EntidadesPessoa.CodEntidade Where ExamesAtendimento.Estado='" + dtInicoEst + "'";
                
                if (valor == "Nenhum")
                {
                    //Data
                     SQL = "SELECT ExamesAtendimento.Codigo, Entidades.Nome, ExamesHospitalar.Descricao," +
                        " ExamesAtendimento.Data,ExamesAtendimento.CodAtendimento, ExamesAtendimento.TipoResultado, ExamesAtendimento.Estado," +
                        "ExamesAtendimento.status from ExamesAtendimento " +
                        "Join Pacientes on Pacientes.Codigo =ExamesAtendimento.CodPaciente " +
                        "Join ExamesHospitalar on ExamesHospitalar.Codigo=ExamesAtendimento.CodExame " +
                        "Join EntidadesPessoa on Pacientes.CodPessoa = EntidadesPessoa.CodEntidade " +
                        "Join Entidades on Entidades.Codigo = EntidadesPessoa.CodEntidade Where ExamesAtendimento.Data between '" + dtInicoEst + "' and '" + dtFim + "'";
                }

                var ob = Conexao.ClienteSql.SELECT(SQL);
                DtDados = (DataTable)ob;
                var result = DataTableHelper.DataTableToList<Laboratorio>(DtDados);
                return result;
            }
            catch (Exception) { throw new Exception("Erro ao Listar"); }
        }
        #endregion ============================================================================================================

        public void Update(ExamesAtendimentoViewModel tabela)
        {
            throw new NotImplementedException();
        }

        public ContactosViewModel GetContactoByEntidade(string CodEntidade)
        {
            return new ContactoRepository().GetContactoByEntidade(int.Parse(CodEntidade));
        }

    }
}
