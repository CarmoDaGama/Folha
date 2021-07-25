using Folha.Domain.Interfaces.Repository.Hospitalar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Folha.Domain.Models.Hospitalar;
using Folha.Driver.Repository.Data;
using Folha.Domain.Models.Db;
using System.Data;
using Folha.Domain.ViewModels.Hospitalar;
using Folha.Domain.Helpers;

namespace Folha.Driver.Repository.Hospitalar
{
    public class TipoConsultasRepository : ITipoConsultasRepository
    {
        public void Insert(TipoConsultas Dados)
        {
            try
            {

                //Mudar para null o codigo
                Object _CodMotivoIsencao;
                if (Dados.CodMotivoIsencao == 0)
                    _CodMotivoIsencao = DBNull.Value;
                else
                    _CodMotivoIsencao = Dados.CodMotivoIsencao;

                Object _CodImposto;
                if (Dados.CodImposto== 0)
                    _CodImposto = DBNull.Value;
                else
                    _CodImposto = Dados.CodImposto;

                DbDTO dto = new DbDTO()
                {
                    Nome = "TipoConsultas",
                    Campos = new string[] { "Descricao","Valor","Tempo", "CodEspecialidade", "CodImposto", "CodMotivoIsencao" },
                    Valores = new Object[] { Dados.Descricao,Dados.Valor,Dados.Tempo,Dados.CodEspecialidade, _CodImposto, _CodMotivoIsencao }
                };
                Conexao.ClienteSql.INSERT(dto.Nome, dto.Campos, dto.Valores);
            }
            catch (Exception) { throw new Exception("Erro ao Cadastrar Tipo de Consulta"); }
        }

        public IEnumerable<TipoConsultaViewModel> Listar(string Descricao)
        {
            var result = new List<TipoConsultaViewModel>();

            try
            {
                string SQL = "SELECT TipoConsultas.Codigo, TipoConsultas.Descricao, TipoConsultas.Valor, TipoConsultas.Tempo, TipoConsultas.CodEspecialidade, " +
                    "Especialidades.Descricao as Especialidade, Imposto.Descricao as Imposto, MotivoIsencao.Descricao as MotivoIsencao, TipoConsultas.CodImposto, Imposto.Percentagem, " +
                    "TipoConsultas.CodMotivoIsencao from TipoConsultas JOIN Especialidades ON Especialidades.Codigo=TipoConsultas.CodEspecialidade LEFT JOIN Imposto ON " +
                    "Imposto.Codigo=TipoConsultas.CodImposto LEFT JOIN MotivoIsencao on MotivoIsencao.Codigo=TipoConsultas.CodMotivoIsencao";
                if (!string.IsNullOrEmpty(Descricao)) SQL += " WHERE TipoConsultas.Descricao LIKE '%" + Descricao + "%'";

                Object ob = Conexao.ClienteSql.SELECT(SQL);
                DataTable DtTipoConsulta = (DataTable)ob;
                result = DataTableHelper.DataTableToList<TipoConsultaViewModel>(DtTipoConsulta);
                return result;
            }
            catch (Exception)
            {
                throw new Exception("Erro a Carregar a Lista de Tipo de Consultas\n");
            }
        }
        public void Update(TipoConsultas Dados)
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
                    Nome = "TipoConsultas",
                    Campos = new string[] { "Descricao", "Valor", "Tempo", "CodEspecialidade", "CodImposto", "CodMotivoIsencao" },
                    Valores = new Object[] { Dados.Descricao, Dados.Valor, Dados.Tempo, Dados.CodEspecialidade, _CodImposto, _CodMotivoIsencao }
                };
                Conexao.ClienteSql.UPDATE(dto.Nome, dto.Campos, dto.Valores, "Codigo ='" + Dados.Codigo + "'");

            }
            catch (Exception) { throw new Exception("Erro ao Actualizar Tipo de Consultas"); }
        }


        public void Delete(TipoConsultas Dados)
        {
            try
            {
                Conexao.ClienteSql.DELETE("TipoConsultas", "Codigo ='" + Dados.Codigo + "'");
            }
            catch (Exception) { throw new Exception("Erro ao Deletar Especialidade"); }

        }
    }
}
