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
using System.Windows.Forms;

namespace Folha.Driver.Repository.UtilitariosConfiguracoes
{
    public class PerfisNovoRepository : RepositoryBase<DbDTO>, IPerfilNovoRepository
    {
        public void Delete(Perfil perfil)
        {
            DbDTO dto = new DbDTO()
            {

                Nome = "Perfil",
                Campos = new string[] { "Descricao", "Acessos" },
                Valores = new Object[] { perfil.Descricao, perfil.Acessos }
            };

            Conexao.ClienteSql.DELETE(dto.Nome, "codigo ='" + perfil.codigo + "'");
        }
        public void Insert(Perfil entity)
        {
            DbDTO dto = new DbDTO()
            {
                Nome = "Perfil",
                Campos = new string[] { "Descricao", "Acessos" },
                Valores = new Object[] { entity.Descricao, entity.Acessos }
            };
            Conexao.ClienteSql.INSERT(dto.Nome, dto.Campos, dto.Valores);
        }
        public IEnumerable<Perfil> Listar(string criterios)
        {
            var result = new List<Perfil>();

            string[] tabelas = { "Perfil" };
            string[] campos = { "codigo", "Descricao", "Acessos" };
            string[] cri = { "Descricao Like '" + criterios + "%'" }; ;

            var ob = Conexao.ClienteSql.SELECT(tabelas, campos, cri);

            DataTable dtadados = (DataTable)ob;

            result = Folha.Domain.Helpers.DataTableHelper.DataTableToList<Perfil>((DataTable)dtadados);

            return result;
        }

        public void Update(Perfil perfil)
        {
            DbDTO dto = new DbDTO()
            {
                Nome = "Perfil",
                Campos = new string[] { "Descricao", "Acessos" },
                Valores = new Object[] { perfil.Descricao, perfil.Acessos }
            };
            Conexao.ClienteSql.UPDATE(dto.Nome, dto.Campos, dto.Valores, "Codigo ='" + perfil.codigo + "'");
        }

        public void Delete(PerfilViewModel tabela)
        {
            throw new NotImplementedException();
        }

        public object Get(PerfilViewModel tabela)
        {
            throw new NotImplementedException();
        }

        public object GetAll(PerfilViewModel tabela)
        {
            return Db.GetEntities<PerfilViewModel>();

        }
        public void Insert(PerfilViewModel tabela)
        {
            throw new NotImplementedException();
        }
        public void Update(PerfilViewModel tabela)
        {
            throw new NotImplementedException();
        }
        public List<string> CarregarAcessos(string login, string senha)
        {
            var PassWord = UtilidadesGenericas.Encriptar(senha);

            string SQL = "SELECT Usuarios.Login, Usuarios.Nome, Usuarios.Codigo, Usuarios.Senha, Usuarios.CodPerfil, Perfil.Acessos as Acessos " +
                "from Usuarios,Perfil ";
            SQL += " WHERE Usuarios.CodPerfil=Perfil.Codigo And login='" + login + "' And " + "senha = '" + senha + "'";
            try
            {
                Object ob = Conexao.ClienteSql.SELECT(SQL);
                DataTable tabela = (DataTable)ob;
                if (ob.GetType().Name.Trim().ToLower() == "string")
                {
                    UtilidadesGenericas.MesagemTest = ob.ToString();
                    UtilidadesGenericas.MsgShow(UtilidadesGenericas.MesagemTest, MessageBoxIcon.Error);
                    return new List<string>();
                }

                if (tabela.Rows.Count > 0)
                {
                    UtilidadesGenericas.UsuarioPerfil = tabela.Rows[0]["CodPerfil"].ToString();

                    string Texto = tabela.Rows[0]["Acessos"].ToString();

                    int codPerfil = int.Parse(UtilidadesGenericas.UsuarioPerfil.ToString());
                    if (Equals(UtilidadesGenericas.ListaAcesso, null))
                    {
                        UtilidadesGenericas.ListaAcesso = new List<string>();
                    }
                    else
                    {
                        UtilidadesGenericas.ListaAcesso.Clear();
                    }
                    if (codPerfil > 1)
                    {
                        string[] Listas = Texto.Split('*');
                        for (int i = 0; i < Listas.Length; i++)
                        {
                            UtilidadesGenericas.ListaAcesso.Add(Listas[i]);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                UtilidadesGenericas.MsgShow(ex.Message, MessageBoxIcon.Error);
            }
            

            
            return UtilidadesGenericas.ListaAcesso;
        }
    }
}
