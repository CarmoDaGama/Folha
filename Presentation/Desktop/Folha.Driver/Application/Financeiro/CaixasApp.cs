using Folha.Domain.Interfaces.Repository.Financeiro;
using System.Collections.Generic;
using Folha.Domain.Models.Financeiro;
using Folha.Domain.Interfaces.Application.Financeiro;
using System;
using Folha.Domain.ViewModels.Frame.Financeiro;
using Folha.Domain.ViewModels.Financeiro;
using Folha.Domain.ViewModels.Report;

namespace Folha.Driver.Application.Financeiro
{
    public class CaixasApp : ICaixasApp
    {
        private readonly ICaixasRepository _CaixasRepository;
        public CaixasApp(ICaixasRepository CaixasRepository)
        {
            _CaixasRepository = CaixasRepository;
        }

        public void addCaixa(Caixas entity)
        {
            _CaixasRepository.Insert(entity);
        }

        
        public IEnumerable<Caixas> Listar(string criterios)
        {
            return _CaixasRepository.Listar(criterios);
        }

        

        public List<CaixaViewModel>BuscarTotal(int usuarioID, string turnoID, string Sigla, string comissionarioID)
        {
            return _CaixasRepository.BuscarTotal(usuarioID, turnoID, Sigla, comissionarioID);
        }

        public void updateCaixa(Caixas caixa,string cri)
        {
            _CaixasRepository.UpdateCaixa(caixa,cri);
        }

        public void deleteCaixa(Caixas caixa)
        {
            _CaixasRepository.Delete(caixa);
        }
        
        public IEnumerable<Caixas> Meus_Caixas()
        {
            return _CaixasRepository.Meus_Caixas();
        }

        public double buscarSaldoCaixa(int codCaixa)
        {
            return _CaixasRepository.buscarSaldoCaixa(codCaixa);
        }

        public DataViewModel RetortaDataSaldoCaixa()
        {
            return _CaixasRepository.RetortaDataSaldoCaixa();
        }
    }
}