using Folha.Domain.Models.Servicos;
using Folha.Domain.Models.Db;
using Folha.Driver.Repository;
using Folha.Domain.Interfaces.Repository.Servicos;
using System;
using System.Collections.Generic;
using System.Data;

namespace Folha.Driver.Repository.Data.Repositories.Servicos
{
    public class MovServicosRepository : RepositoryBase<DbDTO>, IMovServicoRepository
    {
        public void LancarServicosNotaSaida(int NumeroVenda, MovServico movService)
        {

            Double Total = (double)(movService.Qtdade * movService.Preco);
            //int x = int.Parse(Geral.UsuarioCodigo.ToString());

            try
            {

                string[] Campos = { "CodDocumento", "CodServico", "Descricao", "Preco", "Qtdade", "Total" };
                Object[] Valores = { NumeroVenda, movService.ID, movService.Descricao, movService.Preco.ToString("N2"), movService.Qtdade.ToString("N2"), Total.ToString("N2") };

                /*string GravarDados =*/ Conexao.ClienteSql.INSERT("MovServico", Campos, Valores);

            }
            catch (Exception ex)
            {
                throw new Exception("Erro a Lançar o Servicos \n " + ex.Message);
            }

        }

        public void LancarServicosVenda(int NumeroVenda, MovServico movService)
        {

            Double Total = (double)(movService.Qtdade * movService.Preco);
            //int x = int.Parse(Conexao.UsuarioCodigo.ToString());

            try
            {

                string[] Campos = { "CodDocumento", "CodEquipamento", "CodServico", "Descricao", "Preco", "Qtdade", "Total" };
                Object[] Valores = { NumeroVenda, movService.Equimento.ID, movService.ID, movService.Descricao, movService.Preco, movService.Qtdade, Total };
                // Busca.setInsert(Geral.CaminhoBd, "MovProdutos", Campos, Valores);

                /*string GravarDados =*/ Conexao.ClienteSql.INSERT("MovServico", Campos, Valores);

            }
            catch (Exception ex)
            {
                throw new Exception("Erro a Lançar o Servicos \n " + ex.Message);
            }

        }

        public IEnumerable<MovServico> MostrarMovServicos(int NumeroDocumento, Guid equipamentoID)
        {
            DataTable DtDados = new DataTable();
            List<MovServico> Services = new List<MovServico>();
            string Crite = null;
            Crite = " where MovServico.CodDocumento='" + NumeroDocumento + "'";
            if (string.IsNullOrEmpty(equipamentoID.ToString()) == false)
            {
                Crite += " and MovServico.CodEquipamento='" + equipamentoID + "'";
            }

            string SQL = "Select MovServico.Codigo, MovServico.Descricao, MovServico.Preco, MovServico.Qtdade, MovServico.Total from MovServico";
            SQL = SQL + " join Equipamento on Equipamento.Codigo=MovServico.CodEquipamento join Documentos on Documentos.Codigo = MovServico.CodDocumento " + Crite;

            Object ob = Conexao.ClienteSql.SELECT(SQL);

            try
            {
                DtDados = (DataTable)ob;
            }
            catch (Exception ex) {
                throw new Exception ("Erro a Ler Serviços Movimentados \n " + ex.Message);
            }

            return Services;
        }

        public IEnumerable<MovServico> MostrarMovServicosSaidas(Guid documentoID, Guid equipamentoID)
        {
            List<MovServico> result = new List<MovServico>();

            string Crite = null;
            Crite = " where MovServico.CodDocumento='" + documentoID.ToString() + "'";
            if (equipamentoID!=null)
            {
                Crite += " and MovServico.CodEquipamento='" + equipamentoID.ToString() + "'";
            }

            string SQL = "Select MovServico.Codigo, MovServico.Descricao, MovServico.Preco, MovServico.Qtdade, MovServico.Total from MovServico";
            SQL = SQL + " join Equipamento on Equipamento.Codigo=MovServico.CodEquipamento join Documentos on Documentos.Codigo = MovServico.CodDocumento " + Crite;

            Object ob = Conexao.ClienteSql.SELECT(SQL);

            try
            {
              DataTable  DtDados = (DataTable)ob;

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro a Ler Serviços Movimentados \n " + ex.Message);
            }

        }
    }
}
