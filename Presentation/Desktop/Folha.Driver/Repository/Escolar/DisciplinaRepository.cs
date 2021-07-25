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
using Folha.Domain.Models.Financeiro;
using System.Windows.Forms;

namespace Folha.Driver.Repository.Escolar
{
    public class DisciplinaRepository : RepositoryBase<DbDTO>, IDisciplinaRepository
    {

        IEnumerable<Disciplina> IDisciplinaRepository.Listar(string criterios)
        {
            var result = new List<Disciplina>();

            DataTable dtBanco = new DataTable();
            string[] tabelas = { "Disciplinas" };
            string[] campos = { "Descricao", "Abreviatura" };
            string[] cri = { "Descricao Like '" + criterios + "%'" };

            Object ob = Conexao.ClienteSql.SELECT(tabelas, campos, cri);
            try
            {
                result = Folha.Domain.Helpers.DataTableHelper.DataTableToList<Disciplina>((DataTable)ob);
            }
            catch (Exception)
            {
                throw new Exception("Erro a Carregar a Lista de Disciplinas\n");
            }


            return result;
        }
        public void Delete(Disciplina tabela)
        {
            throw new NotImplementedException();
        }

        public object Get(Disciplina tabela)
        {
            throw new NotImplementedException();
        }

        public object GetAll(Disciplina tabela)
        {
            throw new NotImplementedException();
        }

        public void Insert(Disciplina tabela)
        {
            DbDTO dto = new DbDTO()
            {
                Nome = "Disciplinas",
                Campos = new string[] { "Descricao", "Abreviatura" },
                Valores = new Object[] { tabela.Descricao, tabela.Abreviatura }
               
        };
            Conexao.ClienteSql.INSERT(dto.Nome, dto.Campos, dto.Valores);
            MessageBox.Show("Disciplina Adicionada", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

      

        public void Update(Disciplina tabela)
        {
            throw new NotImplementedException();
        }
    }
}
