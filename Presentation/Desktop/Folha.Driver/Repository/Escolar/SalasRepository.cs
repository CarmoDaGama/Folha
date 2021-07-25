using Folha.Domain.Models.Db;
using Folha.Domain.Interfaces.Repository.Escolar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Folha.Domain.Models.Escolar;
using System.Data;
using Folha.Driver.Repository.Data;
using System.Windows.Forms;

namespace Folha.Driver.Repository.Escolar
{
    public class SalasRepository : RepositoryBase<DbDTO>, ISalasRepository
    {
        IEnumerable<Salas> ISalasRepository.Listar(string criterios)
        {
            var result = new List<Salas>();

            DataTable dtBanco = new DataTable();
            string[] tabelas = { "Salas" };
            string[] campos = { "codigo","Descricao"};
            string[] cri = { "Descricao Like '" + criterios + "%'" };

            Object ob = Conexao.ClienteSql.SELECT(tabelas, campos, cri);
            try
            {
                result = Folha.Domain.Helpers.DataTableHelper.DataTableToList<Salas>((DataTable)ob);
            }
            catch (Exception)
            {
                throw new Exception("Erro a Carregar a Lista de Salas\n");
            }


            return result;
        }
        public void Delete(Salas tabela)
        {
            throw new NotImplementedException();
        }

        public object Get(Salas tabela)
        {
            throw new NotImplementedException();
        }

        public object GetAll(Salas tabela)
        {
            throw new NotImplementedException();
        }

        public void Insert(Salas tabela)
        {
            DbDTO dto = new DbDTO()
            {
                Nome = "Salas",
                Campos = new string[] { "Descricao" },
                Valores = new Object[] { tabela.Descricao}
            };
            Conexao.ClienteSql.INSERT(dto.Nome, dto.Campos, dto.Valores);
            MessageBox.Show("Sala Adicionada","Mensagem", MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

       
        public void Update(Salas tabela)
        {
            throw new NotImplementedException();
        }
    }
}
