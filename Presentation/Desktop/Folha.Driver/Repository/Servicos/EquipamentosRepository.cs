using System;
using System.Collections.Generic;
using System.Data;
using Folha.Driver.Repository;
using Folha.Domain.Models.Db;
using Folha.Domain.Interfaces.Repository.Servicos;
using Folha.Domain.Models.Servicos;

namespace Folha.Driver.Repository.Data.Repositories.Servicos
{
    public class EquipamentosRepository : RepositoryBase<DbDTO>, IEquipamentoRepository
    {
        public void LancarEquipamento(int codDocumento, int CodEquipamneto, string Modelo, string Fabricante, string Matricula)
        {
            try
            {
                DataTable dt = Conexao.BuscarTabela_com_Criterio("MovEquipamento", "CodEquipamento='" + CodEquipamneto + "' and CodDocumento='" + codDocumento + "'");
                if (dt.Rows.Count > 0)
                {
                    //MessageBox.Show("Viatura já adicionada", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string[] campos = { "CodEquipamento", "CodDocumento", "Descricao", "Fabricante", "Matricula" };
                object[] Valores = { CodEquipamneto, codDocumento, Modelo, Fabricante, Matricula };
                /*string x =*/ Conexao.ClienteSql.INSERT("MovEquipamento", campos, Valores);
            }
            catch (Exception ex)
            {
                //MessageBox.Show("erro .: \n " + ex, "Errdo do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        public void LançarEquipamento(Guid documentoID, MovEquipamento a)
        {
            try
            {
                DataTable dt = Conexao.BuscarTabela_com_Criterio("MovEquipamento", "CodEquipamento='" + a.Equipamento.ID + "' and CodDocumento='" + documentoID + "'");
                if (dt.Rows.Count > 0)
                {
                    throw new Exception("Equipamento já lançado");
                }
                string[] campos = { "CodEquipamento", "CodDocumento", "Descricao", "Fabricante", "Matricula" };
                object[] Valores = { a.Equipamento.ID, documentoID, a.Equipamento.Modelo.ID,  a.Equipamento.Fabricante,  a.Equipamento.Matricula };
                 Conexao.ClienteSql.INSERT("MovEquipamento", campos, Valores);
            }
            catch (Exception ex)
            {
                throw new Exception("erro.: \n " +ex.Message);
            }
        }

        public List<Equipamento> ListarEquipamentos()
        {
            throw new NotImplementedException();
        }

        public List<MovEquipamento> ListarMovEquipamentos(Guid documentoID)
        {
            var result = new List<MovEquipamento>();

            string SQL = "Select CodEquipamento , fabricante, Descricao, Matricula, Codigo from MovEquipamento";
            SQL += " where CodDocumento='" + documentoID + "'";
            try
            {
                object obj = Conexao.ClienteSql.SELECT(SQL);
               DataTable  dtDdos = (DataTable)obj;
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro a trazer os dados " + ex.Message);

            }

        }
    }
}
