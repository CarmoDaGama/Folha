using Folha.Domain.Interfaces.Application.Hospitalar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Folha.Domain.Models.Hospitalar;
using Folha.Domain.Interfaces.Repository.Hospitalar;
using Folha.Domain.ViewModels.Hospitalar;
using Folha.Domain.ViewModels.Report;

namespace Folha.Driver.Application.Hospitalar
{
    public class TriagemApp : ITriagemApp
    {
        private readonly ITriagemRepository _TriagemRepository;

        public TriagemApp(ITriagemRepository TriagemRepository)
        {
            _TriagemRepository = TriagemRepository;
        }
        public void Insert(Triagem Dados)
        {
            _TriagemRepository.Insert(Dados);
        }

        public IEnumerable<TriagemViewModel> Listar(string CodPaciente)
        {
            return _TriagemRepository.Listar(CodPaciente);
        }

        public IEnumerable<TriagemViewModel> ListarComFiltro(string dataInicial, string dataFinal, int CodPaciente)
        {
            return _TriagemRepository.ListarComFiltro(dataInicial, dataFinal, CodPaciente);
        }

        public DataViewModel RetornaDataTriagem(int CodPaciente)
        {
            return _TriagemRepository.RetornaDataTriagem(CodPaciente);
        }

        public void Update(Triagem Dados)
        {
            _TriagemRepository.Update(Dados);
        }
    }
}
