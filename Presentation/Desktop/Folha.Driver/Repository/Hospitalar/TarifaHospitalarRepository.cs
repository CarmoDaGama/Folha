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
    public class TarifaHospitalarRepository : RepositoryBase<DbDTO>, ITarifaHospitalarRepository
    {
        public void Delete(TarifaHospitalar entity)
        {
            DbDTO dto = new DbDTO()
            {
                Nome = " TarifaHospitalar"
            };
            Conexao.ClienteSql.DELETE(dto.Nome, "Codigo ='" + entity.Codigo + "'");
        }

        public void Delete(TarifaHospitalarViewModel tabela)
        {
            throw new NotImplementedException();
        }

        public object Get(TarifaHospitalarViewModel tabela)
        {
            return Db.GetById<TarifaHospitalarViewModel>(tabela.Codigo);
        }

        public object GetAll(TarifaHospitalarViewModel tabela)
        {
            return Db.GetEntities<TarifaHospitalarViewModel>();
        }

        public TarifaHospitalarViewModel GetById(int codigo)
        {
            throw new NotImplementedException();
        }

        public TarifaHospitalar Gravar(TarifaHospitalar tarifa)
        {
            Object _CodMotivoIsencao;
            if (tarifa.CodMotivoIsencao == 0)
                _CodMotivoIsencao = DBNull.Value;
            else
                _CodMotivoIsencao = tarifa.CodMotivoIsencao;


            string tabela = "TarifaHospitalar";
            string[] campos = { "CodTiposQuartosHospitalar", "CodTiposCamasHospitalar", "TipoTarifa", "Descricao", "Horas", "Valor", "CodImposto", "CodMotivoIsencao" };
            Object[] valores = {tarifa.CodTiposQuartosHospitalar, tarifa.CodTiposCamasHospitalar, tarifa.TipoTarifa, tarifa.Descricao, tarifa.Horas, tarifa.Valor, tarifa.CodImposto, _CodMotivoIsencao };
            string[] critX = { "Codigo = '" + tarifa.Codigo + "'" };

            if (tarifa.Codigo == 0)
            {
                Conexao.ClienteSql.INSERT(tabela, campos, valores);
            }
            else
            {
                Conexao.ClienteSql.UPDATE(tabela, campos, valores, critX);
            }
            string sql = "Select Codigo from TarifaHospitalar where Descricao like '" + tarifa.Descricao + "'";
            object ob = Conexao.ClienteSql.SELECT(sql);
            DataTable dt = (DataTable)ob;
            tarifa.Codigo = int.Parse(dt.Rows[0][0].ToString());
            return tarifa;
        }

        public void Insert(TarifaHospitalarViewModel tabela)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TarifaHospitalar> Listar(string criterios)
        {
            DataTable DtDados = new DataTable();
            try
            {
                string SQL = "SELECT TarifaHospitalar.Codigo, TarifaHospitalar.Descricao, TiposQuartosHospitalar.Descricao" +
                    " AS TipoQuarto,TiposCamasHospitalar.Descricao AS TipoCama, TarifaHospitalar.Horas, TarifaHospitalar.Valor," +
                    " Imposto.Descricao AS TipoImposto, MotivoIsencao.Descricao as NomeIsencao , TarifaHospitalar.TipoTarifa from" +
                    "  TarifaHospitalar  Left Outer Join TiposQuartosHospitalar on TiposQuartosHospitalar.Codigo = " +
                    "TarifaHospitalar.CodTiposQuartosHospitalar Left Outer Join TiposCamasHospitalar on TiposCamasHospitalar.Codigo" +
                    "  = TarifaHospitalar.CodTiposCamasHospitalar Left Outer Join Imposto on Imposto.Codigo = TarifaHospitalar.CodImposto " +
                    "Left Outer Join MotivoIsencao on MotivoIsencao.Codigo = TarifaHospitalar.CodMotivoIsencao";
                var ob = Conexao.ClienteSql.SELECT(SQL);
                DtDados = (DataTable)ob;
                var result = DataTableHelper.DataTableToList<TarifaHospitalar>(DtDados);
                return result;
            }
            catch (Exception) { throw new Exception("Erro ao Listar"); }
        }

        public void Update(TarifaHospitalarViewModel tabela)
        {
            throw new NotImplementedException();
        }

        public bool VerificarDup(string nomeTabela, Dictionary<string, object> dicionario)
        {
            return VerificarDuplicacaoDoRegistro(nomeTabela, dicionario);
        }
    }
}
