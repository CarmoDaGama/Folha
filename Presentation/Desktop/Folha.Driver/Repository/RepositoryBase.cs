using System;
using Folha.Driver.Repository.Data;
using Folha.Domain.Models.Db;
using System.Collections.Generic;
using System.Data;
using Folha.Domain.Interfaces.Repository;
using Folha.Domain.Enuns.Genericos;
using Folha.Domain.Helpers;

namespace Folha.Driver.Repository
{

    public class RepositoryBase<T> : IDisposable, IRepositoryBase<T> where T : DbDTO
    {
        protected DbCostum Db { get; set; }
        public bool NaoTipoString(object objData)
        {
            return objData.GetType().Name.Trim().ToLower() != "string";
        }
        public RepositoryBase()
        {
            Db = new DbCostum(UtilidadesGenericas.ConexaoCorrente.tipoBancoDados);
        }
        public void Delete(T tabela)
        {
            Conexao.ClienteSql.DELETE(tabela.Nome, tabela.Criterios);
        }

        public object Get(T tabela)
        {
           return Conexao.ClienteSql.SELECT(string.Format("SELECT*FROM " + tabela.Nome + "Where Id='{0}'", tabela.Id));
        }

        public object  GetAll(T tabela)
        {
            var a = Conexao.ClienteSql.SELECT(tabela.Nomes, tabela.Campos, tabela.Criterios2);
            return a;
        }

        public object Select(string query)
        {
           var result = Conexao.ClienteSql.SELECT(query);
            return result;
        }

        public void Insert(T tabela)
        {
            Conexao.ClienteSql.INSERT(tabela.Nome, tabela.Campos, tabela.Valores);
        }

        public void Update(T tabela)
        {
            Conexao.ClienteSql.UPDATE(tabela.Nome, tabela.Campos, tabela.Valores, tabela.Criterios);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Query(string query)
        {
            Conexao.ClienteSql.COMANDO(query);
        }
        public bool ContemDuplicado<Entity>(Entity objEntity) where Entity : class, new()
        {
            Dictionary<string, object> dicionario = new Dictionary<string, object>();
            foreach (var field in objEntity.GetType().GetProperties())
            {
                var valueField = field.GetValue(objEntity);
                dicionario.Add(field.Name, valueField);
            }

            var nomeTabela = objEntity.GetType().Name.Replace("ViewModel", string.Empty);

            return VerificarDuplicacaoDoRegistro(nomeTabela, dicionario);
        }
        public bool VerificarDuplicacaoDoRegistro(string Nometabela, Dictionary<string, object> dicionario)
        {
            string query = "SELECT * FROM " + Nometabela;
            string criterio = "";
            foreach (var item in dicionario)
            {
                if (!string.IsNullOrEmpty(item.Key) && !Equals(item.Value, null))
                {
                    if (string.IsNullOrEmpty(criterio))
                    {
                        criterio += item.Key + " = '" + item.Value + "'";
                    }
                    else
                    {
                        criterio += " OR " + item.Key + " = '" + item.Value + "'";
                    }
                }
            }
            if (string.IsNullOrEmpty(criterio))
            {
                var result = (DataTable)Conexao.ClienteSql.SELECT(query);
                if (result.Rows.Count > 0)
                {
                    return true;
                }

            }
            else
            {
                query += " WHERE " + criterio;
                var result = (DataTable)Conexao.ClienteSql.SELECT(query);
                if (result.Rows.Count > 0)
                {
                    return true;
                }

            }
            return false;
        }

    }
}
