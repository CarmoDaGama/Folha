using Folha.Driver.Repository.Data;
using Folha.Domain.Models.Genericos;
using Folha.Domain.Interfaces.Repository.Generico;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Driver.Repository.Genericos
{
    public class PaisesRepository : IPaisesRepository
    {
        public IEnumerable<Pais> Listar()
        {
            var result = new List<Pais>();

            var obj= Conexao.ClienteSql.SELECT("SELECT*FROM PAIS");

            DataTable dtadados = (DataTable)obj;

            result = Folha.Domain.Helpers.DataTableHelper.DataTableToList<Pais>(dtadados);

            return result;
        }
    }
}
