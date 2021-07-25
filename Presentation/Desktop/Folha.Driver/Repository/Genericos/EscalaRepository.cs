using Folha.Driver.Repository.Data;
using Folha.Driver.Repository;
using Folha.Domain.Models.Genericos;
using Folha.Domain.ViewModels.Genericos;
using Folha.Domain.Models.Db;
using Folha.Domain.Helpers;
using Folha.Domain.Interfaces.Repository.Generico;
using System;
using System.Collections.Generic;
using System.Data;

namespace Folha.Driver.Repository.Genericos
{
    public class EscalaRepository : RepositoryBase<DbDTO>, IEscalaRepository
    {
        public void Insert(Escala Dados)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Escala> Listar(string Descricao)
        {
            var result = new List<Escala>();

            DataTable dtEspecialidade = new DataTable();
            string[] tabelas = { "Escala" };
            string[] campos = { "Codigo", "Descricao","HorasSemanal" };
            string[] cri = { "Descricao Like '" + Descricao + "%'" };

            Object ob = Conexao.ClienteSql.SELECT(tabelas, campos, cri);
            try
            {
                result = Folha.Domain.Helpers.DataTableHelper.DataTableToList<Escala>((DataTable)ob);
                return result;
            }
            catch (Exception)
            {
                throw new Exception("Erro a Carregar a Lista de Escala\n");
            }
        }
        public IEnumerable<DiasSemana> ListDiasSemana()
        {
            DataTable DtDados = new DataTable();
            try
            {
                string SQL = "SELECT * FROM DiasSemana";

                var result = new List<DiasSemana>();
               
                    var ob = Conexao.ClienteSql.SELECT(SQL);

                    DtDados = (DataTable)ob;
                    result = DataTableHelper.DataTableToList<DiasSemana>(DtDados);
                    return result;
              
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar Dias Semana\n" + ex.Message);
            }
        }
        public List<DiasSemana01ViewModel> CarregarDiasSemana()
        {
            DataTable DtDados = new DataTable();
            try
            {
                string SQL = "SELECT * FROM DiasSemana";

                var result = new List<DiasSemana01ViewModel>();

                var ob = Conexao.ClienteSql.SELECT(SQL);

                DtDados = (DataTable)ob;
                result = DataTableHelper.DataTableToList<DiasSemana01ViewModel>(DtDados);
                return result;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar Dias Semana\n" + ex.Message);
            }
        }
        public IEnumerable<EscalaConfig01ViewModel> ListEscalaConfig(string CodEscala)
        {
           
            try
            {
                DataTable DtDados = new DataTable();
                string SQL = "SELECT EscalaConfig.Codigo,  DiasSemana.DescricaoDias, EscalaConfig.Entrada, EscalaConfig.Saida, EscalaConfig.Checa from DiasSemana join EscalaConfig on DiasSemana.IDDias=EscalaConfig.CodDia WHERE EscalaConfig.CodEscala='" + CodEscala+"'";
                var result = new List<EscalaConfig01ViewModel>();

                var ob = Conexao.ClienteSql.SELECT(SQL);
                DtDados = (DataTable)ob;
                result = DataTableHelper.DataTableToList<EscalaConfig01ViewModel>(DtDados);
                return result;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar Dias Semana\n" + ex.Message);
            }
        }
        public IEnumerable<EscalaConfig01ViewModel> ListEscalaDisponivel(string CodDia, string HoraInicial)
        {
            try
            {
                DataTable DtDados = new DataTable();
                string SQL = "SELECT EscalaConfig.Codigo,EscalaConfig.CodEscala,  DiasSemana.DescricaoDias, EscalaConfig.Entrada, EscalaConfig.Saida, EscalaConfig.Checa from DiasSemana join EscalaConfig on DiasSemana.IDDias=EscalaConfig.CodDia WHERE EscalaConfig.CodDia='"+CodDia+"' and ('"+HoraInicial+"' between CONVERT(TIME, EscalaConfig.Entrada) and CONVERT(TIME, EscalaConfig.Saida))";
                var result = new List<EscalaConfig01ViewModel>();

                var ob = Conexao.ClienteSql.SELECT(SQL);
                DtDados = (DataTable)ob;
                result = DataTableHelper.DataTableToList<EscalaConfig01ViewModel>(DtDados);
                return result;

            }
            catch (Exception)
            {
                throw new Exception("Erro ao listar Escala Disponível\n");
            }
        }

        public void Update(Escala Dados)
        {
            throw new NotImplementedException();
        }


        public Escala Gravar(Escala escala)
        {
            string tabela = "Escala";
            string[] campos = { "Descricao", "HorasSemanal" };
            Object[] valores = { escala.Descricao, escala.HorasSemanal};
            string[] critX = { "Codigo = '" + escala.Codigo + "'" };

            if (escala.Codigo == 0)
            {
                Conexao.ClienteSql.INSERT(tabela, campos, valores);
            }
            else
            {
                Conexao.ClienteSql.UPDATE(tabela, campos, valores, critX);
            }
            string sql = "Select Codigo from Escala where Descricao like '" + escala.Descricao + "'";
            object ob = Conexao.ClienteSql.SELECT(sql);
            DataTable dt = (DataTable)ob;
            escala.Codigo = int.Parse(dt.Rows[0][0].ToString());

            GravaTudo(escala);
            return escala;
        }
        private void GravaTudo(Escala escala)
        {
            if (escala.EscalaConfig != null)
            {
                foreach (var item in escala.EscalaConfig) item.CodEscala = escala.Codigo;
                GravaEscalaconfig(escala.EscalaConfig);
            }
        }
        private void GravaEscalaconfig(List<EscalaConfigViewModel> lista)
        {
            for (int i = 0; i < lista.Count; i++)
            {
                string Codigo = lista[i].Codigo.ToString();
                string CodEscala = lista[i].CodEscala.ToString();
                string codDia = lista[i].CodDia.ToString();
                string Entrada = lista[i].Entrada.ToString();
                string Saida = lista[i].Saida.ToString();
                int Checa = lista[i].Checa;
                string[] campos = { "CodEscala", "codDia", "Entrada", "Saida", "Checa" };
                object[] Valores = { CodEscala, codDia, Entrada, Saida, Checa};
                string[] Criterio = { "Codigo = '" + Codigo + "'" };

                if (int.Parse(Codigo) == 0)
                {
                    Conexao.ClienteSql.INSERT("EscalaConfig", campos, Valores);
                }
                else
                {
                    Conexao.ClienteSql.UPDATE("EscalaConfig", campos, Valores, Criterio);
                }
            }
        }
        public List<EscalaConfigViewModel> GetEscalaConfig(int codigo)
        {
            string SQL = "  SELECT EscalaConfig.Codigo, DiasSemana.DescricaoDias as Semanas, EscalaConfig.Entrada, EscalaConfig.Saida, EscalaConfig.Checa from  EscalaConfig ";
            SQL += " Left Outer Join DiasSemana on DiasSemana.IDDias = EscalaConfig.CodDia  ";
            SQL += " WHERE EscalaConfig.CodEscala='" + codigo + "'";
            Object obj = Conexao.ClienteSql.SELECT(SQL);
            DataTable dtadados = (DataTable)obj;
            var result = DataTableHelper.DataTableToList<EscalaConfigViewModel>(dtadados);
            return result;
        }
        public void DeleteEscalaConfig(EscalaConfigViewModel delete)
        {
            //DbDTO dto = new DbDTO()
            //{
            //    Nome = "EscalaConfig"
            //};
            Conexao.ClienteSql.DELETE("EscalaConfig", "Codigo ='" + delete.Codigo + "'");
        }
        public Escala Eliminar(Escala escala)
        {
            throw new NotImplementedException();
        }
        public bool VerificarDup(string nomeTabela, Dictionary<string, object> dicionario)
        {
            return VerificarDuplicacaoDoRegistro(nomeTabela, dicionario);
        }
        public void Delete(EscalaViewModel tabela)
        {
            Conexao.ClienteSql.DELETE("Escala", "Codigo ='" + tabela.Codigo + "'");
        }
        public object Get(EscalaViewModel tabela)
        {
            return Db.GetById<EscalaViewModel>(tabela.Codigo);
        }


        public object GetAll(EscalaViewModel tabela)
        {
            throw new NotImplementedException();
        }

        public object Select(string query)
        {
            throw new NotImplementedException();
        }

        public void Insert(EscalaViewModel tabela)
        {
            throw new NotImplementedException();
        }

        public void Update(EscalaViewModel tabela)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Query(string query)
        {
            throw new NotImplementedException();
        }

        public EscalaViewModel GetById(int codigo)
        {
            throw new NotImplementedException();
        }

        public void Apagar(EscalaViewModel apagar)
        {
            Conexao.ClienteSql.DELETE("Escala", "Codigo ='" + apagar.Codigo + "'");
        }

        public void UpdateHora(Escala var)
        {
            throw new NotImplementedException();
        }

        public int HoraTrabalho(int Codigo)
        {
            int t = 0;
            DataTable DtDados = new DataTable();

            string SQL = "SELECT  SUM((CONVERT(int,SUBSTRING(Entrada, 1, 2)) + CONVERT(int,SUBSTRING(Saida, 1, 2)))) As Hora FROM EscalaConfig where CodEscala=" + Codigo;

            var ob = Conexao.ClienteSql.SELECT(SQL);
            DtDados = (DataTable)ob;
            if (DtDados.Rows.Count == 0)
                t = Convert.ToInt16(DtDados.Rows[0]["Hora"]);
            return t;
        }
    }
}
