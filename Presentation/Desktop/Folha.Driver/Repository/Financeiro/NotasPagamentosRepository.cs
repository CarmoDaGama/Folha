using System.Data;
using System.Collections.Generic;
using Folha.Driver.Repository;
using Folha.Domain.Models.Db;
using Folha.Domain.Interfaces.Repository.Financeiro;
using Folha.Domain.Models.Financeiro;
using System;
using Folha.Domain.ViewModels.Frame.Financeiro;
using Folha.Domain.Helpers;
using Folha.Driver.Repository.Data;
using Folha.Domain.ViewModels.Financeiro;

namespace Folha.Driver.Repository.Data.Repositories.Financeiro
{
    public class NotasPagamentosRepository : RepositoryBase<DbDTO>, INotasPagamentosRepository
    {
        public void Delete(NotaPagamento tabela)
        {
            throw new NotImplementedException();
        }

        public object Get(NotaPagamento tabela)
        {
            throw new NotImplementedException();
        }

        public object GetAll(NotaPagamento tabela)
        {
            throw new NotImplementedException();
        }

        public void Insert(NotaPagamento tabela)
        {

            DbDTO dto = new DbDTO()
            {
                Nome = "NotaSaida",
                Campos = new string[] { "CodDocumento", "Descricao", "CodTipoSaida" },
                Valores = new Object[] { tabela.Documento.codigo, tabela.Descricao, tabela.TipoSaida.Codigo }
            };
            string Criterio = "CodDocumento='" + tabela.Documento.codigo + "'";
           
            Conexao.ClienteSql.INSERT(dto.Nome, dto.Campos, dto.Valores);

            DataTable dtOS = Conexao.BuscarTabela_com_Criterio("NotaSaida", "CodDocumento='" + tabela.Documento.codigo + "'");
            if (dtOS.Rows.Count > 0)
            {
                Conexao.ClienteSql.UPDATE("NotaSaida", dto.Campos, dto.Valores, Criterio);
            }
            else
            {
                Conexao.ClienteSql.INSERT("NotaSaida", dto.Campos, dto.Valores);
            }

        }
    
        public List<NotaPagamentoViewModel> ListarNotasPagamentos(int cod)
        {
            List<NotaPagamentoViewModel> result = new List<NotaPagamentoViewModel>();
            DataTable DtDados = new DataTable();

            var criterio = "Pagamentos.CodDocumento='" + cod+ "'";
            string[] campos = { "Pagamentos.Codigo as Codigo", "Pagamentos.Data as Data", "Pagamentos.Descricao as Descricao", "fPagamentos.Descricao as Forma", "Pagamentos.Tipo as Tipo", "Pagamentos.Valor as Valor", "Moedas.Sigla as Moeda", "Pagamentos.Estado as Estado", "Pagamentos.CodCambio" };
            string[] criterioJoin = { "fPagamentos on Pagamentos.CodForma = fPagamentos.Codigo", "Documentos on Documentos.Codigo=Pagamentos.CodDocumento", "Comissoes on Documentos.Codigo=Comissoes.CodDocumento", "Operacoes on Documentos.CodOperacao=Operacoes.Codigo", "Moedas on Moedas.Codigo=Pagamentos.CodMoeda" };
            string[] criterios2 = { criterio };

            Object ob = Conexao.ClienteSql.LEFTJOIN("Pagamentos", campos, criterioJoin, criterios2);
            try
            {
                DtDados = (DataTable)ob;
                result = DataTableHelper.DataTableToList<NotaPagamentoViewModel>(DtDados);
            }
            catch (Exception)
            {
                throw new Exception("Erro a Carregar Pagamentos\n" + (string)ob);
            }
            
            
            return result;
        }
        
        public void Update(NotaPagamento tabela)
        {
            throw new NotImplementedException();
        }

        public List<BuscaDocNotaPagamentoViewModel> BuscarDocumento(string Criterio)
        {
        
            DataTable DtDados = new DataTable();
            try
            {
                string SQL = "Select Entidades.Codigo, Entidades.Nome as Entidade, Documentos.Data, Documentos.Hora, Documentos.Estado, Usuarios.Nome as Usuario from Entidades join Documentos on Documentos.CodEntidade = Entidades.codigo join Usuarios on Usuarios.Codigo=Documentos.CodUsuario where Documentos.Codigo='" + Criterio + "'";

                var x = Conexao.ClienteSql.SELECT(SQL);

                DtDados = (DataTable)x;
                var result = DataTableHelper.DataTableToList<BuscaDocNotaPagamentoViewModel>(DtDados);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar Documento\n" + ex.Message);
            }



        }

        public List<NotaPagamento> BuscarTabela_com_Criterio(string criterios)
        {
            List<NotaPagamento> result = new List<NotaPagamento>();
            DataTable DtDados = new DataTable();
            Object ob = null;

            try
            {
                ob = Conexao.BuscarTabela_com_Criterio("NotaSaida", "CodDocumento='" + criterios + "'");
                DtDados = (DataTable)ob;
                result = DataTableHelper.DataTableToList<NotaPagamento>(DtDados);
            }
            catch (Exception) { throw new Exception("Erro a Carregar Dados" + (string)ob); }

            return result;
        }
    }
}
