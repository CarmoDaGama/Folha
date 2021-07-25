using Folha.Driver.Repository;
using Folha.Domain.Models.Db;
using Folha.Domain.Interfaces.Repository.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Folha.Domain.Models.Inventario;
using Folha.Driver.Repository.Data;
using System.Data;
using Folha.Domain.ViewModels.Inventario;

namespace Folha.Driver.Repository.Inventario
{
    public class MotivoIsencaoRepository : RepositoryBase<DbDTO>, IMotivoIsencaoRepository
    {
        public List<MovProdutosViewModel> GetMovsPorDescricao(string descricao)
        {
            return Db.GetEntities<MovProdutosViewModel>("WHERE MovProdutos.Descricao = '" + descricao + "'");
        }

        public IEnumerable<MotivoIsencao> Listar(string criterios)
        {
            var result = new List<MotivoIsencao>();

            string[] tabelas = { "MotivoIsencao" };
            string[] campos = { "Codigo", "Descricao" };
            string[] cri = { "Descricao Like '" + criterios + "%'" }; ;

            var ob = Conexao.ClienteSql.SELECT(tabelas, campos, cri);

            DataTable dtadados = (DataTable)ob;

            result = Folha.Domain.Helpers.DataTableHelper.DataTableToList<MotivoIsencao>((DataTable)dtadados);

            return result;
        }
        public MotivoIsencao GetMotivoPorDescricao(string descricao)
        {
            var result = new List<MotivoIsencao>();

            string[] tabelas = { "MotivoIsencao" };
            string[] campos = { "Codigo", "Descricao","Referencia" };
            string[] cri = { "Descricao Like '" + descricao + "'" }; ;

            var ob = Conexao.ClienteSql.SELECT(tabelas, campos, cri);

            DataTable dtadados = (DataTable)ob;

            result = Folha.Domain.Helpers.DataTableHelper.DataTableToList<MotivoIsencao>((DataTable)dtadados);

            return result.FirstOrDefault();
        }
        public MotivoIsencao GetMotivoPorCodigo(int codMotivo)
        {
            var result = new List<MotivoIsencao>();

            string[] tabelas = { "MotivoIsencao" };
            string[] campos = { "Codigo", "Descricao", "Referencia" };
            string[] cri = { "Codigo = '" + codMotivo + "'" }; ;

            var ob = Conexao.ClienteSql.SELECT(tabelas, campos, cri);

            DataTable dtadados = (DataTable)ob;

            result = Folha.Domain.Helpers.DataTableHelper.DataTableToList<MotivoIsencao>((DataTable)dtadados);

            return result.FirstOrDefault();
        }
    }
}
