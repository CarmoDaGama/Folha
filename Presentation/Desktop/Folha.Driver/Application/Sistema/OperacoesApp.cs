using Folha.Domain.Interfaces.Application.Sistema;
using Folha.Domain.ViewModels.Frame.Sistema;
using Folha.Domain.Interfaces.Repository.Sistema;
using System.Collections.Generic;
using Folha.Domain.Helpers;
using Folha.Domain.ViewModels.Sistema;
using System;

namespace Folha.Driver.Application.Sistema
{
    public class OperacoesApp : IOperacoesApp
    {
        private readonly IOperacoesRepository Repository;
        public OperacoesApp(IOperacoesRepository repository)
        {
            Repository = repository;
        }

        public void Delete(OperacoesViewModel operacao)
        {
            Repository.Delete(operacao);
        }

        public List<OperacoesViewModel> GetAll()
        {
            return (List<OperacoesViewModel>)Repository.GetAll(new OperacoesViewModel());
        }

        public OperacoesViewModel GetById(int operacaoId)
        {
            return (OperacoesViewModel)Repository.Get(new OperacoesViewModel() { codigo = operacaoId });
        }
        public OperacoesViewModel GetByApp(string app)
        {
            return Repository.GetByApp(app);
        }

        public int GetCodigoOperacaPorNome(string Nome)
        {
            return Repository.GetCodigoOperacaPorNome(Nome);
        }

        public OperacoesViewModel GetOperacaPorNome(string Nome)
        {
            return Repository.GetOperacaPorNome(Nome);
        }

        public void Insert(OperacoesViewModel operacao)
        {
            Repository.Insert(operacao);
        }

        public List<OperacaoViewModel> Listar(string Criterios)
        {
            return Mapper<OperacoesViewModel, OperacaoViewModel>.Map((List<OperacoesViewModel>)Repository.GetAll(new OperacoesViewModel()));
        }

        public void Update(OperacoesViewModel operacao)
        {
            Repository.Update(operacao);
        }
        public bool ContemDuplicacao(string nomeTabela, Dictionary<string, object> dicionario)
        {
            return Repository.VerificarDuplicacaoDoRegistro(nomeTabela, dicionario);
        }
    }
}
