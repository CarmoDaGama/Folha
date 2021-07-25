using Folha.Domain.Interfaces.Application.Inteligente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Folha.Domain.ViewModels.Principal;
using Folha.Domain.Interfaces.Repository.Inteligente;
using Folha.Domain.ViewModels.Documentos;

namespace Folha.Driver.Application.Inteligente
{
    public class InteligenteApp : IInteligenteApp
    {
        private readonly IInteligenteRepository _repository;

        public InteligenteApp(IInteligenteRepository repository)
        {
            _repository = repository;
        }
        public void Delete(InteligenteViewModel inteligente)
        {
            _repository.Delete(inteligente);
        }

        public void DeleteDoc(DocumentoPagamentoViewModel doc)
        {
            _repository.InsertDoc(doc);
        }

        public List<InteligenteViewModel> GetAll(string nomeTabela)
        {
            return (List<InteligenteViewModel>)_repository.GetAll(new InteligenteViewModel() { NomeTabela = nomeTabela });
        }

        public InteligenteViewModel GetById(InteligenteViewModel inteligente)
        {
            return (InteligenteViewModel)_repository.Get(inteligente);
        }

        public List<DocumentoPagamentoViewModel> GetTodosDocs()
        {
            return _repository.GetTodosDocs();
        }

        public List<DocumentoPagamentoViewModel> GetTodosDocsPorRecibo(int codCRecibo)
        {
            return _repository.GetTodosDocsPorRecibo(codCRecibo);
        }

        public void Insert(InteligenteViewModel inteligente)
        {
            _repository.Insert(inteligente);
        }

        public void InsertDoc(DocumentoPagamentoViewModel doc)
        {
            _repository.InsertDoc(doc);
        }

        public void Update(InteligenteViewModel inteligente)
        {
            _repository.Update(inteligente);
        }

        public void UpdateDoc(DocumentoPagamentoViewModel doc)
        {
            _repository.UpdateDoc(doc);
        }

        public bool VerificarDuplicacaoDoRegistro(string Nometabela, Dictionary<string, object> dicionario)
        {
            return _repository.VerificarDuplicacaoDoRegistro(Nometabela, dicionario);
        }
    }
}
