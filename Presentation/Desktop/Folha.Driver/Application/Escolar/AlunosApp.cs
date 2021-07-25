using Folha.Domain.Interfaces.Application.Escolar;
using Folha.Domain.Models.Escolar;
using Folha.Domain.Interfaces.Repository.Escolar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Folha.Domain.ViewModels.Escolar;

namespace Folha.Driver.Application.Escolar
{
    public class AlunosApp: IAlunosApp
    {
        private readonly IAlunosRepository _AlunosRepository;

        public AlunosApp(IAlunosRepository AlunosRepository)
        {
            _AlunosRepository = AlunosRepository;
        }
        public void Insert(Alunos Dados)
        {
            _AlunosRepository.Insert(Dados);
        }

        public IEnumerable<AlunosViewModel> ListarAlunos(string ano)
        {
            return _AlunosRepository.ListarAlunos(ano);
        }

        public IEnumerable<AlunoCursoViewModel> ListarConfirmacao(string codEntidade)
        {
            return _AlunosRepository.ListarConfirmacao(codEntidade);
        }

        public IEnumerable<PagamentoPropinaViewModel> ListarPagamento(int codAluno)
        {
            return _AlunosRepository.ListarPagamento(codAluno);
        }

        public string RetornaAno()
        {
            return _AlunosRepository.RetornaAno();
        }

        public void Update(Alunos Dados)
        {
            _AlunosRepository.Update(Dados);
        }
    }
}
