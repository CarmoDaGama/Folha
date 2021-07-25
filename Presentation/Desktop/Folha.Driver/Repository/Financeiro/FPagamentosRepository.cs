using System;
using System.Data;
using System.Collections.Generic;
using Folha.Domain.Models.Financeiro;
using Folha.Driver.Repository;
using Folha.Domain.Models.Db;
using Folha.Domain.Interfaces.Repository.Financeiro;
using Folha.Domain.ViewModels.Financeiro;
using Folha.Domain.Helpers;

namespace Folha.Driver.Repository.Data.Repositories.Financeiro
{
    public class FPagamentosRepository : RepositoryBase<DbDTO>, IFPagamentosRepository
    {
        public void Delete(fPagamentosViewModel forma)
        {
            Db.Delete(forma);
        }

        public object Get(fPagamentosViewModel forma)
        {
            return Db.GetById<fPagamentosViewModel>(forma.codigo);
        }

        public object GetAll(fPagamentosViewModel forma)
        {
            return Db.GetEntities<fPagamentosViewModel>();
        }

        public void Insert(fPagamentosViewModel forma)
        {
            Db.Add(forma);
        }

        public void InsertFPagamentos(fPagamentos tabela, string Criterios)
        {
            DbDTO dto = new DbDTO()
            {
                Nome = "fPagamentos",
                Campos = new string[] { "Descricao", "Movimentar", "CodConta", "Sistema" },
                Valores = new Object[] { tabela.descricao, tabela.Movimentar, tabela.CodConta, 0 }

            };
            try
            {
                if (string.IsNullOrEmpty(Criterios))
                {
                    Conexao.ClienteSql.INSERT(dto.Nome, dto.Campos, dto.Valores);
                }
                else
                {
                    Conexao.ClienteSql.UPDATE(dto.Nome, dto.Campos, dto.Valores, Criterios);
                }

            }
            catch (Exception ex) { throw new Exception("Erro ao Gravar \n" + ex); }
        

         }
        public fPagamentos GetByCodConta(int CodConta)
        {
            fPagamentos dados = null;
            string SQL="SELECT * FROM fPagamentos WHERE CodConta="+CodConta;
            Object ob = Conexao.ClienteSql.SELECT(SQL);
            DataTable dtDados = (DataTable)ob;
            var result = DataTableHelper.DataTableToList<fPagamentos>(dtDados);
            if (result.Count > 0)
                dados = new fPagamentos() { codigo = result[0].codigo, descricao = result[0].descricao, CodConta = result[0].CodConta, Movimentar = result[0].Movimentar };
            return dados;
        }
        public IEnumerable<fPagamentos> ListarFormasdePagamentos(string[] Criterios)
        {
            var result = new List<fPagamentos>();

            try
            {
                string tabela = "fPagamentos";
                string[] tabelas = { "fPagamentos", };
                string[] campos = { "fPagamentos.Codigo", "fPagamentos.Descricao", "fPagamentos.Movimentar", "ContasBancarias.Numero as ContaBancaria", "Bancos.Descricao as Banco", "fPagamentos.CodConta" };
                string[] criterios = { "ContasBancarias on fPagamentos.CodConta=ContasBancarias.Codigo", "Bancos on ContasBancarias.CodBanco=Bancos.Codigo" };

                Object ob = Conexao.ClienteSql.LEFTJOIN(tabela, campos, criterios, Criterios);
                DataTable dtDados = (DataTable)ob;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro a Carregar Formas de Pagamentos \n" + ex);
            }
            return result;

           
        }

        public void Update(fPagamentosViewModel forma)
        {
            Db.Update(forma);
        }
    }
}
