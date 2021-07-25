using Folha.Driver.Repository.Data;
using Folha.Driver.Repository;
using Folha.Domain.Models.UtilitariosConfiguracoes;
using Folha.Domain.ViewModels.UtilitariosConfiguracoes;
using Folha.Domain.Models.Db;
using Folha.Domain.Helpers;
using Folha.Domain.Interfaces.Repository.UtilitariosConfiguracoes;
using System;
using System.Collections.Generic;
using System.Data;

namespace Folha.Driver.Repository.UtilitariosConfiguracoes
{
    public class UsuarioNovoRepository : RepositoryBase<DbDTO>, IUsuarioNovoRepository
    {
  
        public List<UsuariosViewModel> GetAll()
        {
            throw new NotImplementedException();
        }
        public Usuarios Gravar(Usuarios usuario)
        {
            string tabela = "Usuarios";
            string[] critX = { "codigo = '" + usuario.codigo + "'" };

            if (usuario.codigo == 0)
            {
                string[] campos = { "Login", "CodEntidade", "Nome", "Senha", "CodPerfil", "Alterado"};
                Object[] valores = { usuario.Login, usuario.CodEntidade, usuario.Nome, usuario.Senha, usuario.CodPerfil, usuario.Alterado};
                Conexao.ClienteSql.INSERT(tabela, campos, valores);
            }
            else
            {
                string[] campos = { "Login", "CodEntidade", "Nome", "Senha", "CodPerfil", "Alterado" };
                Object[] valores = { usuario.Login, usuario.CodEntidade, usuario.Nome, usuario.Senha, usuario.CodPerfil, usuario.Alterado  };
                Conexao.ClienteSql.UPDATE(tabela, campos, valores, critX);
            }
            //string sql = "Select codigo from Usuarios where Login like '" + usuario.Login + "'";
            //object ob = Conexao.ClienteSql.SELECT(sql);
            //DataTable dt = (DataTable)ob;
            //usuario.codigo = int.Parse(dt.Rows[0][0].ToString());
            //GravarAlterado(usuario.codigo);
            return usuario;
        }
        public void  GravarAlterado(int codigo)
        {
            string tabela = "Usuarios";
            string[] campos = { "Alterado" };
            Object[] valores = { true };
            string[] critX = { "codigo = '" + codigo + "'" };

            Conexao.ClienteSql.UPDATE(tabela, campos, valores, critX);
        }
        public bool UsuarioAlterado(int codUsuario)
        {
            string sql = "Select Alterado from Usuarios where codigo = '" + codUsuario + "'";
            object ob = Conexao.ClienteSql.SELECT(sql);
            DataTable dt = (DataTable)ob;
            var alterado = int.Parse(dt.Rows[0]["Alterado"].ToString());
            return Equals(alterado, 1);
        }
        public void Delete(Usuarios usuario)
        {
            DbDTO dto = new DbDTO()
            {
                Nome = "Usuarios",
                Campos = new string[] { "codigo", "Login", "CodEntidade", "Nome", "Senha", "CodPerfil" },
                Valores = new Object[] { usuario.codigo, usuario.Login, usuario.CodEntidade, usuario.Senha, usuario.CodPerfil }
            };
            Conexao.ClienteSql.DELETE(dto.Nome, "codigo ='" + usuario.codigo + "'");
        }
        public IEnumerable<Usuarios> Listar(string criterios)
        {
            DataTable DtDados = new DataTable();
            try
            {
                string SQL = "SELECT Usuarios.codigo, Usuarios.Login, Usuarios.Nome, Perfil.Descricao as Perfil From Usuarios join Perfil on usuarios.codPerfil = Perfil.codigo";

                if (string.IsNullOrEmpty(criterios))
                {
                    var ob = Conexao.ClienteSql.SELECT(SQL);
                    DtDados = (DataTable)ob;
                    var result = DataTableHelper.DataTableToList<Usuarios>(DtDados);
                    return result;
                }
                else
                {
                    SQL += " Where Usuarios.Login Like '%" + criterios + "%'";
                    var ob = Conexao.ClienteSql.SELECT(SQL);
                    DtDados = (DataTable)ob;
                    var result = DataTableHelper.DataTableToList<Usuarios>(DtDados);
                    return result;
                }
            }
            catch (Exception) { throw new Exception("Erro ao Listar Usuarios"); }
    }

        #region Repositorio base

        public void Insert(UsuariosViewModel tabela)
        {
            throw new NotImplementedException();
        }
        public object GetAll(UsuariosViewModel tabela)
        {
            throw new NotImplementedException();
        }

        public object Get(UsuariosViewModel tabela)
        {
            return Db.GetById<UsuariosViewModel>(tabela.codigo);
        }
        public void Delete(UsuariosViewModel tabela)
        {
            throw new NotImplementedException();
        }
        public void Update(UsuariosViewModel tabela)
        {
            throw new NotImplementedException();
        }

        public bool VerificarDup(string nomeTabela, Dictionary<string, object> dicionario)
        {
            return VerificarDuplicacaoDoRegistro(nomeTabela, dicionario);
        }

        #endregion
    }
}
