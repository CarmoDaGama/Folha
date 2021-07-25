using Folha.Domain.ViewModels.Sistema;
using Folha.Domain.ViewModels.Frame.Sistema;
using System.Collections.Generic;

namespace Folha.Domain.Interfaces.Application.Sistema
{
    public interface IOperacoesApp
    {
        OperacoesViewModel GetByApp(string app);
        OperacoesViewModel GetOperacaPorNome(string Nome);
        int GetCodigoOperacaPorNome(string Nome);
        List<OperacaoViewModel> Listar(string Criterios);
        OperacoesViewModel GetById(int operacaoId);
        void Insert(OperacoesViewModel operacao);
        void Update(OperacoesViewModel operacao);
        void Delete(OperacoesViewModel operacao);
        List<OperacoesViewModel> GetAll();
        bool ContemDuplicacao(string nomeTabela, Dictionary<string, object> dicionario);
    }
}
