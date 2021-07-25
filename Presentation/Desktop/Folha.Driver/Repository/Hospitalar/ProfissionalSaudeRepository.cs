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

namespace Folha.Driver.Repository.Hospitalar
{
    public class ProfissionalSaudeRepository : RepositoryBase<DbDTO>, IProfissinalSaudeRepository
    {
        public void Delete(ProfissionalSaudeViewModel tabela)
        {
            Db.Delete(tabela);
        }
        public void DeleteArea(AreaSaudeProfissinalViewModel delete)
        {
            DbDTO dto = new DbDTO()
            {
                Nome = "AreaSaudeProfissional"
            };
            Conexao.ClienteSql.DELETE(dto.Nome, "Codigo ='" + delete.Codigo + "'");
        }
        public ProfissinalSaude Eliminar(ProfissinalSaude profissinal)
        {
            string tabela = "ProfissionalSaude";
            string[] campos = { "status" };
            Object[] valores = { "0" };
            string[] critX = { "Codigo = '" + profissinal.Codigo + "'" };
            Conexao.ClienteSql.UPDATE(tabela, campos, valores, critX);
            return profissinal;
        }
        public object Get(ProfissionalSaudeViewModel tabela)
        {
            return Db.GetById<ProfissionalSaudeViewModel>(tabela.Codigo);
        }
        public List<ProfissionalSaudeViewModel> GetAll()
        {
            return Db.GetEntities<ProfissionalSaudeViewModel>();
        }
        public List<AreaSaudeProfissinalViewModel> GetArea(int codProfissional)
        {
            string SQL = " SELECT AreaSaudeProfissional.Codigo, AreaSaudeProfissional.CodAreaSaude, AreaSaude.Descricao,  AreaSaudeProfissional.CodProfissionalSaude from AreaSaudeProfissional ";
            SQL += " Left Outer Join AreaSaude on AreaSaude.Codigo= AreaSaudeProfissional.CodAreaSaude ";
            SQL += " WHERE AreaSaudeProfissional.CodProfissionalSaude='" + codProfissional + "'";
            Object obj = Conexao.ClienteSql.SELECT(SQL);
            DataTable dtadados = (DataTable)obj;
            var result = Folha.Domain.Helpers.DataTableHelper.DataTableToList<AreaSaudeProfissinalViewModel>(dtadados);
            return result;
        }
        public ProfissinalSaude Gravar(ProfissinalSaude profissinal)
        {
            string tabela = "ProfissionalSaude";
            string[] campos = { "CodEntidade", "status"};
            Object[] valores = { profissinal.CodEntidade, "1"};
            string[] critX = { "Codigo = '" + profissinal.Codigo + "'" };

            if (profissinal.Codigo == 0)
            {
                Conexao.ClienteSql.INSERT(tabela, campos, valores);
            }
            else
            {
                Conexao.ClienteSql.UPDATE(tabela, campos, valores, critX);
            }
            string sql = "Select Codigo from ProfissionalSaude where CodEntidade like '" + profissinal.CodEntidade + "'";
            object ob = Conexao.ClienteSql.SELECT(sql);
            DataTable dt = (DataTable)ob;
            profissinal.Codigo = int.Parse(dt.Rows[0][0].ToString());

            GravaTudo(profissinal);
            return profissinal;
        }
        private void GravaTudo(ProfissinalSaude profissional)
        {
            if (profissional.AreaSaude != null)
            {
                foreach (var item in profissional.AreaSaude) item.CodProfissional = profissional.Codigo;
                GravaArea(profissional.AreaSaude);
            }
        }
        private void GravaArea(List<AreaSaudeProfissinalViewModel> lista)
        {
            for (int i = 0; i < lista.Count; i++)
            {
                string Codigo = lista[i].Codigo.ToString();
                string CodProfissional = lista[i].CodProfissional.ToString();
                string CodArea = lista[i].CodAreaSaude.ToString();
                string[] campos = { "CodProfissionalSaude", "CodAreaSaude" };
                object[] Valores = { CodProfissional, CodArea };
                string[] Criterio = { "Codigo = '" + Codigo + "'" };

                if (int.Parse(Codigo) == 0)
                {
                    Conexao.ClienteSql.INSERT("AreaSaudeProfissional", campos, Valores);
                }
                else
                {
                    Conexao.ClienteSql.UPDATE("AreaSaudeProfissional", campos, Valores, Criterio);
                }
            }
        }
        public void Insert(ProfissionalSaudeViewModel tabela)
        {
            throw new NotImplementedException();
        }
        public void Update(ProfissionalSaudeViewModel tabela)
        {
            throw new NotImplementedException();
        }
        public object GetAll(ProfissionalSaudeViewModel tabela)
        {
            return Db.GetEntities<ProfissionalSaudeViewModel>();
        }
        public bool VerificarDup(string nomeTabela, Dictionary<string, object> dicionario)
        {
            return VerificarDuplicacaoDoRegistro(nomeTabela, dicionario);
        }
        IEnumerable<ProfissinalSaude> IProfissinalSaudeRepository.Listar(string criterios)
        {
            DataTable DtDados = new DataTable();
            try
            {
                string SQL = "Select ProfissionalSaude.Codigo, AreaSaude.Descricao as Descricao, Entidades.Nome, ProfissionalSaude.status from AreaSaudeProfissional" +
                             " Join ProfissionalSaude on ProfissionalSaude.Codigo = AreaSaudeProfissional.CodProfissionalSaude " +
                             "Join AreaSaude on AreaSaude.Codigo = AreaSaudeProfissional.CodAreaSaude " +
                             "Join Entidades on Entidades.Codigo = ProfissionalSaude.CodEntidade ";

                    var ob = Conexao.ClienteSql.SELECT(SQL);
                    DtDados = (DataTable)ob;
                    var result = DataTableHelper.DataTableToList<ProfissinalSaude>(DtDados);
                    return result;

            }
            catch (Exception) { throw new Exception("Erro ao Listar"); }
        }
    }
}
