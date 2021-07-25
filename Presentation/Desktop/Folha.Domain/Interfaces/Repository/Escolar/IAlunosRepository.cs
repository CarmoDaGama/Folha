using Folha.Domain.Models.Escolar;
using Folha.Domain.ViewModels.Escolar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Interfaces.Repository.Escolar
{
    public interface IAlunosRepository
    {
        void Insert(Alunos Dados);
        void Update(Alunos Dados);
        string RetornaAno();
        IEnumerable<AlunosViewModel> ListarAlunos(string ano);
        IEnumerable<PagamentoPropinaViewModel> ListarPagamento(int codAluno);
        IEnumerable<AlunoCursoViewModel> ListarConfirmacao(string codEntidade);
    }
}
