using Folha.Domain.Models.Hospitalar;
using Folha.Domain.ViewModels.Hospitalar;
using Folha.Domain.ViewModels.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Interfaces.Repository.Hospitalar
{
    public interface ITriagemRepository
    {
        void Insert(Triagem Dados);
        void Update(Triagem Dados);
        IEnumerable<TriagemViewModel> Listar(string CodAtendimento);
        IEnumerable<TriagemViewModel> ListarComFiltro(string dataInicial, string dataFinal, int CodPaciente);
        DataViewModel RetornaDataTriagem(int CodPaciente);
    }
}
