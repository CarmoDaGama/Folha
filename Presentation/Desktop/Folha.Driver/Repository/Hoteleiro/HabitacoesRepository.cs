using System;
using System.Data;
using System.Collections.Generic;


using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Folha.Domain.Models.Hoteleiro;
using Folha.Driver.Repository;
using Folha.Domain.Models.Db;
using Folha.Domain.Interfaces.Repository.Hoteleiro;

namespace Folha.Driver.Repository.Data.Repositories.Hoteleiro
{
    public class HabitacoesRepository : RepositoryBase<DbDTO>, IHabitacaoRepository
    {
        public List<Habitacao> MostrarMovHabitacoes(string crit)
        {
            DataTable DtDados = new DataTable();
            List<Habitacao> habitacoes = new List<Habitacao>();


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
            catch (Exception ex)
            {
                throw new Exception("Erro a Ler  Movimentos de Habitações  " + ex.Message);
            }
            //habitacoes = DtDados.AsEnumerable().ToList<Habitacao>();
            return habitacoes;
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
            catch (Exception ex)
            {
                throw new Exception("Erro a Ler  Movimentos de Habitações  " + ex.Message);
            }

            return Result;
        }
    }
}
