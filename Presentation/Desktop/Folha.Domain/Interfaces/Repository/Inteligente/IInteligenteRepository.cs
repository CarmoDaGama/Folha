using Folha.Domain.Interfaces.Repository;
using Folha.Domain.ViewModels.Documentos;
using Folha.Domain.ViewModels.Principal;
using System.Collections.Generic;

namespace Folha.Domain.Interfaces.Repository.Inteligente
{
    public interface IInteligenteRepository : IRepositoryBase<InteligenteViewModel>
    {
        bool VerificarDuplicacaoDoRegistro(string Nometabela, Dictionary<string, object> dicionario);
        void InsertDoc(DocumentoPagamentoViewModel doc);
        void UpdateDoc(DocumentoPagamentoViewModel doc);
        void DeleteDoc(DocumentoPagamentoViewModel doc);
        List<DocumentoPagamentoViewModel> GetTodosDocs();
        List<DocumentoPagamentoViewModel> GetTodosDocsPorRecibo(int codCRecibo);
    }
}
