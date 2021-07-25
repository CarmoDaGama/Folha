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
    public class QuartosHospitalarRepository : RepositoryBase<DbDTO>, IQuartosHospitalarRepository
    {
        public void Delete(QuartosHospitalar entity)
        {
            DbDTO dto = new DbDTO()
            {
                Nome = "QuartosHospitalar"
            };
            Conexao.ClienteSql.DELETE(dto.Nome, "Codigo ='" + entity.Codigo + "'");
        }
        public void DeleteCama(CamasQuartosHospitalarViewModel delete)
        {
            DbDTO dto = new DbDTO()
            {
                Nome = "CamasQuartosHospitalar"
            };
            Conexao.ClienteSql.DELETE(dto.Nome, "Codigo ='" + delete.Codigo + "'");
        }
        public object Get(QuartosHospitalarViewModel tabela)
        {
            return Db.GetById<QuartosHospitalarViewModel>(tabela.Codigo);
        }
        public QuartosHospitalar Gravar(QuartosHospitalar quarto)
        {
            string tabela = "QuartosHospitalar";
            string[] campos = { "CodAreasHospitalar", "Descricao", "CodTiposQuartosHospitalar", "Manutencao" };
            Object[] valores = { quarto.CodAreasHospitalar, quarto.Descricao, quarto.CodTiposQuartosHospitalar, quarto.Manutencao };
            string[] critX = { "Codigo = '" + quarto.Codigo + "'" };
            if (quarto.Codigo == 0)
            {
                Conexao.ClienteSql.INSERT(tabela, campos, valores);
            }
            else
            {
                Conexao.ClienteSql.UPDATE(tabela, campos, valores, critX);
            }
            string sql = "Select Codigo from QuartosHospitalar where Descricao like '" + quarto.Descricao + "'";
            object ob = Conexao.ClienteSql.SELECT(sql);
            DataTable dt = (DataTable)ob;
            quarto.Codigo = int.Parse(dt.Rows[0][0].ToString());
            GravaTudo(quarto);
            return quarto;
        }
        private void GravaTudo(QuartosHospitalar quarto)
        {
            if (quarto.CamasdoQuarto != null)
            {
                foreach (var item in quarto.CamasdoQuarto) item.CodQuartosHospitalar = quarto.Codigo;
                GravaCamas(quarto.CamasdoQuarto);
            }
        }
        private void GravaCamas(List<CamasQuartosHospitalarViewModel> lista)
        {
            for (int i = 0; i < lista.Count; i++)
            {
                string Codigo = lista[i].Codigo.ToString();
                string codquarto = lista[i].CodQuartosHospitalar.ToString();
                string codCama = lista[i].CodCamasHospitalar.ToString();
                string[] campos = { "CodQuartosHospitalar", "CodCamasHospitalar" };
                object[] Valores = { codquarto, codCama };
                string[] Criterio = { "Codigo = '" + Codigo + "'" };

                if (int.Parse(Codigo) == 0)
                {
                    Conexao.ClienteSql.INSERT("CamasQuartosHospitalar", campos, Valores);
                }
                else
                {
                    Conexao.ClienteSql.UPDATE("CamasQuartosHospitalar", campos, Valores, Criterio);
                }
            }
        }
        public IEnumerable<QuartosHospitalar> Listar(string criterios)
        {
            DataTable DtDados = new DataTable();
            try
            {
                string SQL = "select QuartosHospitalar.Codigo, AreasHospitalar.Descricao as Area," +
                    "  QuartosHospitalar.Descricao, TiposQuartosHospitalar.Descricao as Tipo," +
                    " QuartosHospitalar.Manutencao from QuartosHospitalar, AreasHospitalar," +
                    " TiposQuartosHospitalar where QuartosHospitalar.CodTiposQuartosHospitalar" +
                    " = TiposQuartosHospitalar.Codigo and QuartosHospitalar.CodAreasHospitalar = AreasHospitalar.Codigo";

                var ob = Conexao.ClienteSql.SELECT(SQL);
                DtDados = (DataTable)ob;
                var result = DataTableHelper.DataTableToList<QuartosHospitalar>(DtDados);
                return result;

            }
            catch (Exception) { throw new Exception("Erro ao Listar"); }
        }
        public bool VerificarDup(string nomeTabela, Dictionary<string, object> dicionario)
        {
            return VerificarDuplicacaoDoRegistro(nomeTabela, dicionario);
        }
        public List<CamasQuartosHospitalarViewModel> GetCamas(int codQuartos)
        {
            string SQL = " SELECT CamasQuartosHospitalar.Codigo, CamasQuartosHospitalar.CodQuartosHospitalar, CamasHospitalar.Descricao,TiposCamasHospitalar.Descricao as Tipo,  CamasQuartosHospitalar.CodCamasHospitalar from CamasQuartosHospitalar ";
            SQL += " Left Outer Join CamasHospitalar on CamasHospitalar.Codigo= CamasQuartosHospitalar.CodCamasHospitalar ";
            SQL += " Left Outer Join TiposCamasHospitalar on TiposCamasHospitalar.Codigo= CamasHospitalar.CodTiposCamasHospitalar ";
            SQL += " WHERE  CamasQuartosHospitalar.CodQuartosHospitalar='" + codQuartos + "'";
            Object obj = Conexao.ClienteSql.SELECT(SQL);
            DataTable dtadados = (DataTable)obj;
            var result = DataTableHelper.DataTableToList<CamasQuartosHospitalarViewModel>(dtadados);
            return result;
        }

  
        #region MyRegion
        public object GetAll(QuartosHospitalarViewModel tabela)
        {
            throw new NotImplementedException();
        }
        public void Delete(QuartosHospitalarViewModel tabela)
        {
            throw new NotImplementedException();
        }

        public void Update(QuartosHospitalarViewModel tabela)
        {
            throw new NotImplementedException();
        }
        public void Insert(QuartosHospitalarViewModel tabela)
        {
            throw new NotImplementedException();
        }

     


        #endregion
    }
}
