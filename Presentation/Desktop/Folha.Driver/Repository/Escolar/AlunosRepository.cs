using Folha.Domain.Interfaces.Repository.Escolar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Folha.Domain.Models.Escolar;
using Folha.Driver.Repository.Data;
using System.Data;
using Folha.Domain.ViewModels.Escolar;
using Folha.Domain.Helpers;

namespace Folha.Driver.Repository.Escolar
{
    public class AlunosRepository : IAlunosRepository
    {
        public void Insert(Alunos Dados)
        {
            try
            {
                String[] Campos = { "CodEntidade", "status", "DataRegisto" };
                Object[] Valores = { Dados.CodEntidade, Dados.status, Dados.DataRegisto };

                Conexao.ClienteSql.INSERT("Alunos", Campos, Valores);
            }
            catch (Exception){ throw new Exception("Erro ao gravar Aluno"); }
        }
        public void Update(Alunos Dados)
        {
            try
            {
                String[] Campos = {  "status" };
                Object[] Valores = {  Dados.status };

                Conexao.ClienteSql.UPDATE("Alunos", Campos, Valores,"Codigo ="+ Dados.Codigo);
            }
            catch (Exception) { throw new Exception("Erro ao editar Aluno"); }
        }
        public string RetornaAno()
        {
            string Data=null;
            string SQL = "Select min(DataRegisto) as Data from Alunos";
            object x = Conexao.ClienteSql.SELECT(SQL);
            DataTable DtDados = (DataTable)x;
            if (DtDados.Rows.Count > 0)
                Data = DtDados.Rows[0]["Data"].ToString();
       
            return Data;
        }

        public IEnumerable<AlunosViewModel> ListarAlunos(string ano)
        {
            try
            {
                string SQL = " select Alunos.codigo, Entidades.Codigo as CodEntidade, Entidades.Nome, EntidadesPessoa.DataNascimento as Data, Sexo.descricao as Sexo, Alunos.status from Alunos join Entidades on Entidades.Codigo=Alunos.CodEntidade join EntidadesPessoa on EntidadesPessoa.CodEntidade=Entidades.Codigo join Sexo on Sexo.codigo=EntidadesPessoa.CodSexo";
                SQL += " where Alunos.DataRegisto like '%" + ano + "%'";
                object ob = Conexao.ClienteSql.SELECT(SQL);
                DataTable dtDados = (DataTable)ob;
                var result = DataTableHelper.DataTableToList<AlunosViewModel>((DataTable)ob);
                return result;
            }
            catch (Exception)
            {
               throw new Exception ("Erro a Carregar Alunos \n");
            }
        }

        public IEnumerable<PagamentoPropinaViewModel> ListarPagamento(int codAluno)
        {
                try
                {
                    string SQL = "SELECT Propinas.Codigo, '0' as CodEmolumento, Propinas.Descricao, Propinas.Valor, Propinas.Multa, Desconto, Total, status FROM Propinas join Confirmacao on Confirmacao.Codigo = Propinas.codconfirmacao where CodAluno = " + codAluno + " and status = 0 order by propinas.codigo";
                    object ob = Conexao.ClienteSql.SELECT(SQL);
                    DataTable dtPagamentos = (DataTable)ob;
                    var result = DataTableHelper.DataTableToList<PagamentoPropinaViewModel>((DataTable)ob);
                    return result;
            }
                catch (Exception) { throw new Exception("Erro ao Listar Pagamento \n"); }

        }

        public IEnumerable<AlunoCursoViewModel> ListarConfirmacao(string codEntidade)
        {
            try
            {
                string SQL = "Select Confirmacao.Codigo as CodConfirmacao, Turmas.Codigo as CodTurma, Turmas.Descricao as Turma, Cursos.Descricao as Curso, Classes.Descricao as Classe, Turmas.AnoLectivo as AnoLectivo  from Confirmacao";
                SQL += " Join Turmas on Turmas.Codigo=Confirmacao.CodTurma  Join CursoClasses on CursoClasses.codigo = Turmas.CodCursoClasse join Cursos on Cursos.Codigo=CursoClasses.CodCurso";
                SQL += " join Alunos on Alunos.Codigo=Confirmacao.CodAluno join Classes on Classes.codigo=CursoClasses.CodClasse Where Alunos.CodEntidade ='" + codEntidade + "'";
                object ob = Conexao.ClienteSql.SELECT(SQL);
                DataTable dtTurmas = (DataTable)ob;
                var result = DataTableHelper.DataTableToList<AlunoCursoViewModel>((DataTable)ob);
                return result;
            }
            catch (Exception){ throw new Exception("Erro ao Listar Confirmacao \n"); }
           
           
        }
    }
}
