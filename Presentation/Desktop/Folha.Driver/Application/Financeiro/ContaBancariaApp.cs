using Folha.Domain.Interfaces.Application.Financeiro;
using Folha.Domain.Interfaces.Repository.Financeiro;
using Folha.Domain.Models.Financeiro;
using Folha.Domain.ViewModels.Financeiro;
using System;
using System.Collections.Generic;
using Folha.Domain.ViewModels.Report;

namespace Folha.Driver.Application.Financeiro
{
    public class ContaBancariaApp:IContaBancariaApp
    {
        private readonly IContaBancariaRepository _ContaBancariaRepository;
        public ContaBancariaApp(IContaBancariaRepository ContaBancariaRepository)
        {
            _ContaBancariaRepository = ContaBancariaRepository;
        }

        public void addContaBancaria(ContasBancarias ContaBancaria)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ContasBancarias> Listar(string criterios,bool Pesquisa)
        {
            return _ContaBancariaRepository.Listar(criterios,Pesquisa);
        }
        public void Insert(ContasBancarias entity)
        {
            _ContaBancariaRepository.Insert(entity);
        }

        public void Update(ContasBancarias entity, string criterios)
        {
            _ContaBancariaRepository.Update(entity,criterios);
        }

        public IEnumerable<MostraContasViewModel> Minhas_ContasBancarias()
        {
            return _ContaBancariaRepository.Minhas_ContasBancarias();
        }

        public double buscarSaldoBanco(int CodBanco)
        {
            return _ContaBancariaRepository.buscarSaldoBanco(CodBanco);
        }

        public DataViewModel RetortaDataSaldoConta()
        {
            return _ContaBancariaRepository.RetortaDataSaldoConta();
        }

        public void Delete(int Codconta)
        {
            _ContaBancariaRepository.Delete(Codconta);
        }
        

    }
}
