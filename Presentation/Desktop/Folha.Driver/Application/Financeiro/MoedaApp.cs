using Folha.Domain.Interfaces.Application.Financeiro;
using System;
using System.Collections.Generic;
using Folha.Domain.Models.Financeiro;
using Folha.Domain.Interfaces.Repository.Financeiro;
using Folha.Domain.ViewModels.Financeiro;

namespace Folha.Driver.Application.Financeiro
{
    public class MoedaApp : IMoedaApp
    {
        private readonly IMoedaRepository _MoedaRepository;
        public MoedaApp(IMoedaRepository MoedaRepository)
        {
            _MoedaRepository = MoedaRepository;
        }
        public void addMoeda(Moedas banco)
        {
            _MoedaRepository.Insert(banco);
        }

        public void deleteMoeda(Moedas Moeda)
        {
            _MoedaRepository.Delete(Moeda);
        }

        public IEnumerable<MostraMoedasViewModel> Listar()
        {
            return _MoedaRepository.Listar();
        }

        public IEnumerable<Moedas> ListarCriterio(string text)
        {
            return _MoedaRepository.ListarCriterio(text);
        }

        public IEnumerable<Moedas> ListarMoedaCambio()
        {
            return _MoedaRepository.ListarMoedaCambio();
        }

        public void updateMoeda(Moedas tabela)
        {
            _MoedaRepository.Update(tabela);
        }

        public void UpdateMoedaPadrao(Moedas Dados)
        {
            _MoedaRepository.UpdateMoedaPadrao(Dados);
        }

        public bool VerificarDup(string nomeTabela, Dictionary<string, object> dicionario)
        {
            return _MoedaRepository.VerificarDup(nomeTabela, dicionario);
        }
    }
}
