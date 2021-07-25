using Folha.Domain.ViewModels.Documentos;
using Folha.Domain.ViewModels.Principal;
using System.Collections.Generic;

namespace Folha.Domain.Interfaces.Application.Inteligente
{
    public interface IInteligenteApp
    {
        void Insert(InteligenteViewModel inteligente);
        void Delete(InteligenteViewModel inteligente);
        void Update(InteligenteViewModel inteligente);
        InteligenteViewModel GetById(InteligenteViewModel inteligente);
        List<InteligenteViewModel> GetAll(string nomeTabela);
        bool VerificarDuplicacaoDoRegistro(string Nometabela, Dictionary<string, object> dicionario);

        void InsertDoc(DocumentoPagamentoViewModel doc);
        void UpdateDoc(DocumentoPagamentoViewModel doc);
        void DeleteDoc(DocumentoPagamentoViewModel doc);
        List<DocumentoPagamentoViewModel> GetTodosDocs();
        List<DocumentoPagamentoViewModel> GetTodosDocsPorRecibo(int codCRecibo);
    }
}
