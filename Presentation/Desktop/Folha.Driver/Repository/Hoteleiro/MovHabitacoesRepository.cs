using Folha.Domain.Models.Hoteleiro;
using Folha.Domain.Models.Db;
using Folha.Driver.Repository;
using Folha.Domain.Interfaces.Repository.Hoteleiro;
using System;
using System.Collections.Generic;



using System.Data;


namespace Folha.Driver.Repository.Data.Repositories.Hoteleiro
{
    public class MovHabitacoesRepository : RepositoryBase<DbDTO>, IMovHabitacaoRepository
    {

        public IEnumerable<MovHabitacao> ListarMovHabitacoes(Guid documentoID)
        {
            List<MovHabitacao> result = new List<MovHabitacao>();

            DataTable DtDados = new DataTable();

            string SQL = "Select Codigo, Descricao, Preco, Qtdade, Total from MovServico where CodDocumento='" + documentoID + "'";

            Object ob = Conexao.ClienteSql.SELECT(SQL);

            try
            {
                DtDados = (DataTable)ob;

            }
            catch (Exception ex)
            {
                throw new NotImplementedException("Erro a Ler Serviços Movimentados \n " + ex.Message);
            }

            return result;
        }

        public IEnumerable<MovHabitacao> MostrarMovHabitacoes(string crit)
        {
            DataTable DtDados = new DataTable();
            List<MovHabitacao> movHabitacoes = new List<MovHabitacao>();


            string[] tabelas = { "MovHabitacoes" }; //, "", "" };
            string[] campos = { "Habitacoes.Descricao as Quarto", "TiposHabitacoes.Descricao as Tipo", "TarifasHospedagens.Descricao as Tarifa", "MovHabitacoes.Checkin", "MovHabitacoes.CheckOut", "MovHabitacoes.Quantidade", "MovHabitacoes.Preco", "MovHabitacoes.Total", "MovHabitacoes.Codigo" };
            string[] criteriosTodos = { "Habitacoes on MovHabitacoes.CodHabitacao=Habitacoes.codigo", "TiposHabitacoes on Habitacoes.CodTipoHabitacao=TiposHabitacoes.codigo", "TarifasHospedagens on MovHabitacoes.CodTarifa=TarifasHospedagens.Codigo", "Documentos on Documentos.Codigo=MovHabitacoes.CodDocumento" };

            string[] criterios = { crit };
            // Busca.setSelectLeftJoin(Geral.CaminhoBd, tabelas, campos, criteriosTodos, criterios);

            try
            {
                Object ob = Conexao.ClienteSql.LEFTJOIN(tabelas[0].ToString(), campos, criteriosTodos, criterios);
                //MessageBox.Show(ob.ToString());
                DtDados = (DataTable)ob;
            }
            catch (Exception ex) {
                throw new Exception ("Erro a Ler  Movimentos de Habitações  " + ex.Message); }
            //movHabitacoes = DtDados.AsEnumerable<MovHabitacao>().ToList<MovHabitacao>();

            return movHabitacoes;
        }

        public bool VerificaDisponivel(Guid habitacaoID, DateTime checkin, DateTime ckeckout)
        {

            bool Result = false;

            DataTable DtDados = new DataTable();
            DtDados.Rows.Clear();


            try
            {
                DtDados = Conexao.BuscarTabela_com_Criterio("MovHabitacoes", "CodHabitacao='" + habitacaoID + "'");
                if (DtDados.Rows.Count > 0)
                {
                    DateTime Entrada, Saida;

                    for (int i = 0; i < DtDados.Rows.Count; i++)
                    {
                        Entrada = DateTime.Parse(DtDados.Rows[i]["Checkin"].ToString());
                        Saida = DateTime.Parse(DtDados.Rows[i]["CheckOut"].ToString());

                        if (checkin >= Entrada && ckeckout <= Saida)
                        {
                            Result = true;
                        }
                    }
                }
            }
            catch (Exception ex) {
                throw new NotImplementedException("Erro a Ler  Movimentos de Habitações  " + ex.Message);
            }

            return Result;
        }
    }
}
