using Folha.Domain.Interfaces.Repository.Financeiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Folha.Domain.Models.Financeiro;
using System.Data;
using Folha.Driver.Repository.Data;

namespace Folha.Driver.Repository.Financeiro
{
    public class CambioRepository : ICambioRepository
    {
        public IEnumerable<Cambio> Listar()
        {
            var result = new List<Cambio>();
           
            Object ob = (DataTable)Conexao.BuscarTabela_com_Criterio("Cambios", "estado=1");
            try
            {
                result = Folha.Domain.Helpers.DataTableHelper.DataTableToList<Cambio>((DataTable)ob);
            }
            catch (Exception)
            {
                throw new Exception("Erro ao Carregar Câmbio\n");
            }

            return result;
        }
    }
}
