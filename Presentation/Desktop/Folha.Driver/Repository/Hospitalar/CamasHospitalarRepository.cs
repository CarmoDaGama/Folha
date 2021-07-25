using Folha.Driver.Repository;
using Folha.Domain.Models.Db;
using Folha.Domain.Interfaces.Repository.Hospitalar;
using System;
using System.Collections.Generic;
using Folha.Domain.Models.Hospitalar;
using Folha.Driver.Repository.Data;
using System.Data;
using Folha.Domain.Helpers;
using Folha.Domain.ViewModels.Hospitalar;

namespace Folha.Driver.Repository.Hospitalar
{
    public class CamasHospitalarRepository : RepositoryBase<DbDTO>, ICamasHospitalarRepository
    {
        public void Delete(CamasHospitalar entity)
        {
            DbDTO dto = new DbDTO()
            {
                Nome = "CamasHospitalar"
            };
            Conexao.ClienteSql.DELETE(dto.Nome, "Codigo ='" + entity.Codigo + "'");
        }

        public void Delete(CamasHospitalarViewModel tabela)
        {
            throw new NotImplementedException();
        }

        public object Get(CamasHospitalarViewModel tabela)
        {
            return Db.GetById<CamasHospitalarViewModel>(tabela.Codigo);
        }

        public List<CamasHospitalarViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public object GetAll(CamasHospitalarViewModel tabela)
        {
            return Db.GetEntities<CamasHospitalarViewModel>();
        }

        public CamasHospitalar Gravar(CamasHospitalar cama)
        {
            string tabela = "CamasHospitalar";
            string[] campos = { "Descricao","CodTiposCamasHospitalar","Ocupado"};
            Object[] valores = { cama.Descricao, cama.CodTiposCamasHospitalar, "Não" };
            string[] critX = { "Codigo = '" + cama.Codigo + "'" };

            if (cama.Codigo == 0)
            {
                Conexao.ClienteSql.INSERT(tabela, campos, valores);
            }
            else
            {
                Conexao.ClienteSql.UPDATE(tabela, campos, valores, critX);
            }
            string sql = "Select Codigo from CamasHospitalar where Descricao like '" + cama.Descricao + "'";
            object ob = Conexao.ClienteSql.SELECT(sql);
            DataTable dt = (DataTable)ob;
            cama.Codigo = int.Parse(dt.Rows[0][0].ToString());
            return cama;
        }

        public void Insert(CamasHospitalarViewModel tabela)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CamasHospitalar> Listar(string criterios)
        {
            DataTable DtDados = new DataTable();
            try
            {
                string SQL = "select  CamasHospitalar.Codigo, CamasHospitalar.Descricao, TiposCamasHospitalar.Descricao as Tipo, CamasHospitalar.Ocupado" +
                    "  from CamasHospitalar, TiposCamasHospitalar where CamasHospitalar.CodTiposCamasHospitalar = TiposCamasHospitalar.Codigo";

                var ob = Conexao.ClienteSql.SELECT(SQL);
                DtDados = (DataTable)ob;
                var result = DataTableHelper.DataTableToList<CamasHospitalar>(DtDados);
                return result;

            }
            catch (Exception) { throw new Exception("Erro ao Listar"); }
        }


        public void Update(CamasHospitalarViewModel tabela)
        {
            Db.Update(tabela);
        }

        public void Update(CamasHospitalar entity)
        {
            DbDTO dto = new DbDTO()
            {
                Nome = "CamasHospitalar",
                Campos = new string[] { "Ocupado" },
                Valores = new Object[] { entity.Ocupado }
            };
            Conexao.ClienteSql.UPDATE(dto.Nome, dto.Campos, dto.Valores, "Codigo ='" + entity.Codigo + "'");
        }

        public bool VerificarDup(string nomeTabela, Dictionary<string, object> dicionario)
        {
            return VerificarDuplicacaoDoRegistro(nomeTabela, dicionario);
        }

        CamasHospitalarViewModel ICamasHospitalarRepository.GetById(int codigo)
        {
            throw new NotImplementedException();
        }
    }
}
