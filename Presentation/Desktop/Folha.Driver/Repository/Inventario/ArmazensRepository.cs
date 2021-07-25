using System;
using System.Data;
using System.Collections.Generic;
using Folha.Domain.Interfaces.Repository.Inventario;
using Folha.Driver.Repository;
using Folha.Domain.Models.Db;
using Folha.Domain.Models.Inventario;
using System.Linq;
using Folha.Domain.ViewModels.Inventario;
using Folha.Domain.Helpers;
using Folha.Domain.ViewModels.Report;
using Folha.Driver.Repository.Data;

namespace Folha.Driver.Repository.Inventario
{
    public class ArmazensRepository : RepositoryBase<DbDTO>, IArmazensRepository
    {

        #region CRUD GENÉRICO

        
        public void Insert(Armazens armazem)
        {
            DbDTO dto = new DbDTO()
            {
                Nome = "Armazens",
                Campos = new string[] {"descricao" },
                Valores = new Object[] {  armazem.descricao }

            };
            Conexao.ClienteSql.INSERT(dto.Nome, dto.Campos, dto.Valores);
        }
        public object Get(Armazens armazem)
        {
            var obj = Conexao.ClienteSql.SELECT("SELECT * FROM Armazens");

            DataTable dtadados = (DataTable)obj;

            var result = Folha.Domain.Helpers.DataTableHelper.DataTableToList<Armazens>(dtadados).Where(e => e.codigo == armazem.codigo).FirstOrDefault();

            return result;
        }
        public void Update(Armazens armazem)
        {

            DbDTO dto = new DbDTO()
            {
                Nome = "Armazens",
                Campos = new string[] {
                    "descricao",

                },
                Valores = new Object[] {
                    armazem.descricao,
                     }

            };
            Conexao.ClienteSql.UPDATE(dto.Nome, dto.Campos, dto.Valores, "codigo ='" + armazem.codigo + "'");
        }

        public void Delete(Armazens armazem)
        {
            Conexao.ClienteSql.DELETE("Armazens", "codigo ='" + armazem.codigo + "'");
        }
     
        public IEnumerable<Armazens> Listar(string criterios)
        {
            var result = new List<Armazens>();

            string[] tabelas = { "Armazens" };
            string[] campos = { "codigo", "descricao" };
            string[] cri = { "descricao Like '%" + criterios + "%'" };

            var ob = Conexao.ClienteSql.SELECT(tabelas, campos, cri);

            DataTable dtadados = (DataTable)ob;

            result = Folha.Domain.Helpers.DataTableHelper.DataTableToList<Armazens>((DataTable)dtadados);

            return result;
        }

        public void Delete(ArmazensViewModel tabela)
        {
            Db.Delete(tabela);
        }

        public object Get(ArmazensViewModel tabela)
        {
            return Db.GetById<ArmazensViewModel>(tabela.codigo);
        }

        public object GetAll(ArmazensViewModel tabela)
        {
            return Db.GetEntities<ArmazensViewModel>();
        }

        public void Insert(ArmazensViewModel tabela)
        {
            Db.Add(tabela);
        }

        public void Update(ArmazensViewModel tabela)
        {
            Db.Update(tabela);
        }

        public bool VerificarDup(string nomeTabela, Dictionary<string, object> dicionario)
        {
            return VerificarDuplicacaoDoRegistro(nomeTabela, dicionario);
        }
        #endregion

        public IEnumerable<Armazens> Meus_Armazens()
        {
            List<Armazens> result = new List<Armazens>();
            DataTable Dados = new DataTable();
            if (UtilidadesGenericas.UsuarioPerfilCodigo > 1)
            {
                string SQL = "SELECT Armazens.Codigo,Armazens.Descricao from Armazens,AcessoArmazens WHERE ";
                SQL += "Armazens.Codigo=AcessoArmazens.CodArmazem And AcessoArmazens.CodUsuario='" + UtilidadesGenericas.UsuarioCodigo + "'";

                object x = Conexao.ClienteSql.SELECT(SQL);
                Dados = (DataTable)x;
            }
            else
            {
                Dados = Conexao.BuscarTabela("Armazens");
            }

            result = DataTableHelper.DataTableToList<Armazens>((DataTable)Dados);
            return result;
           
        }
    }
}
