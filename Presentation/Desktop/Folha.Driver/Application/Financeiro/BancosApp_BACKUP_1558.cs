using Enterprise.Application.Contract.Financeiro;
using System.Collections.Generic;
using Enterprise.Domain.Financeiro;
using Enterprise.Data.Repository.Contract.Financeiro;
using System;

namespace Enterprise.Application.Financeiro
{
    public class BancosApp : IBancosApp
    {
        private readonly IBancosRepository _BancosRepository;
        public BancosApp(IBancosRepository BancosRepository)
        {
            _BancosRepository = BancosRepository;
        }
        public List<Banco> Listar(string criterios)
        {
            return (List<Banco>)_BancosRepository.GetAll(new Banco());

        }
        public void addBanco(Banco entity)
        {
            _BancosRepository.Insert(entity);
        }

        public void updateBanco(Banco banco)
        {
<<<<<<< HEAD
            _BancosRepository.Update(banco);
=======
            //_BancosRepository.Update_Banco(banco,criterios);
>>>>>>> 4fae640b84c71ed693bdee976db19dc0c6d42c8b
        }

        public void deleteBanco(Banco banco)
        {
            _BancosRepository.Delete(banco);
        }
    }
}
