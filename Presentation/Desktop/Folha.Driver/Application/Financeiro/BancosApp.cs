using Folha.Domain.Interfaces.Application.Financeiro;
using System.Collections.Generic;
using Folha.Domain.Models.Financeiro;
using Folha.Domain.Interfaces.Repository.Financeiro;
using System;
using Folha.Domain.ViewModels.Financeiro;

namespace Folha.Driver.Application.Financeiro
{
    public class BancosApp : IBancosApp
    {
        private readonly IBancosRepository _BancosRepository;
        public BancosApp(IBancosRepository BancosRepository)
        {
            _BancosRepository = BancosRepository;
        }
        public List<BancosViewModel> Listar(string criterios)
        {
            return (List<BancosViewModel>)_BancosRepository.GetAll(new BancosViewModel());

        }
        public void addBanco(BancosViewModel entity)
        {
            _BancosRepository.Insert(entity);
        }

        public void updateBanco(BancosViewModel banco,string criterios)
        {
            _BancosRepository.UpdateBanco(banco, criterios);
        }

        public void deleteBanco(BancosViewModel banco)
        {
            _BancosRepository.Delete(banco);
        }

        public void update(BancosViewModel banco)
        {
            _BancosRepository.Update(banco);
        }

        public IEnumerable<BancosViewModel> ListarTudo(string criterios)
        {
            return (List<BancosViewModel>)_BancosRepository.Listar(criterios);
        }
    }
}
