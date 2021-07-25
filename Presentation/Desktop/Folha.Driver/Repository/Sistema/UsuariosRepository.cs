using Folha.Domain.Models.Sistema;
using Folha.Domain.Models.Db;
using Folha.Driver.Repository;
using Folha.Domain.Interfaces.Repository.Sistema;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Folha.Domain.ViewModels.Frame.Admin;
using Folha.Domain.ViewModels.Sistema;
using Folha.Domain.Helpers;
using System.Windows.Forms;

namespace Folha.Driver.Repository.Data.Repositories.Sistema
{
    public class UsuariosRepository : RepositoryBase<DbDTO>, IUsuariosRepository
    {
        #region CRUD GENÉRICO
        public void Insert(UsuariosViewModel entity)
        {
            Db.Add(entity);
        }

        public object Get(UsuariosViewModel entity)
        {
            return Db.GetById<UsuariosViewModel>(entity.codigo);
        }

        public object GetAll(UsuariosViewModel entity)
        {
           return Db.GetEntities<UsuariosViewModel>();
        }

        public void Update(UsuariosViewModel entity)
        {
            Db.Update(entity);
        }
        public bool UsuarioAlterado(int codUsuario)
        {
            return Db.GetById<UsuariosViewModel>(codUsuario).Alterado == 1;
        }
        public void Delete(UsuariosViewModel entity)
        { 
            Db.Delete(entity);
        }

        public bool CredenciasDoUsuarioValidas(string login, string senha)
        {
            var PassWord = UtilidadesGenericas.Encriptar(senha);
            try
            {
                object objData = Conexao.ClienteSql.SELECT("SELECT * FROM Usuarios WHERE Login = '" + login + "' AND Senha = '" + senha + "'");
                if (objData.GetType().Name.Trim().ToLower() == "string")
                {
                    UtilidadesGenericas.MesagemTest = objData.ToString();
                    UtilidadesGenericas.MsgShow(UtilidadesGenericas.MesagemTest, MessageBoxIcon.Error);
                    return false;
                }
                else
                {
                    DataTable tabelaUsuarios = (DataTable)objData;
                    return tabelaUsuarios.Rows.Count > 0;

                }
            }
            catch (Exception ex)
            {
                UtilidadesGenericas.MsgShow(ex.Message, MessageBoxIcon.Error);
                return false;
            }

        }
        public int GetCodigoUsuarioPorSenhaAndLogin(string login, string senha)
        {
            DataTable tabelaUsuarios = (DataTable)Conexao.ClienteSql.SELECT("SELECT * FROM Usuarios WHERE Login = '" + login + "' AND Senha = '" + senha + "'");
            var codigoUsuario = 0;
            if (tabelaUsuarios.Rows.Count > 0)
            {
                codigoUsuario = Convert.ToInt16(tabelaUsuarios.Rows[0]["codigo"]);
            }
            return codigoUsuario;
        }
        public string GetNomeUsuarioPorSenhaAndLogin(string login, string senha)
        {
            DataTable tabelaUsuarios = (DataTable)Conexao.ClienteSql.SELECT("SELECT * FROM Usuarios WHERE Login = '" + login + "' AND Senha = '" + senha + "'");
            string NomeUsuario="";
            if (tabelaUsuarios.Rows.Count > 0)
            {
                NomeUsuario =tabelaUsuarios.Rows[0]["Login"].ToString();
            }
            return NomeUsuario;
        }
        public List<Usuarios> ListarUsuarios(string criterios)
        {
            throw new NotImplementedException();
        }
        public UsuariosViewModel GetUsuarioPor(string login, string senha)
        {
            return Db.GetEntities<UsuariosViewModel>(" WHERE Login = '" + login + "' AND Senha = '" + senha + "'").FirstOrDefault();
        }
        List<UsuarioViewModel> IUsuariosRepository.ListarUsuarios(string criterios)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
