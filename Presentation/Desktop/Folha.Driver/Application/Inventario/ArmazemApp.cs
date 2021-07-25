using Folha.Domain.Interfaces.Application.Inventario;
using Folha.Domain.Interfaces.Repository.Inventario;
using Folha.Domain.Models.Inventario;
using System.Collections.Generic;
using System;
using Folha.Domain.ViewModels.Inventario;
using Folha.Domain.ViewModels.Report;

namespace Folha.Driver.Application.Inventario
{
    public class ArmazemApp : IArmazemApp
    {
        private readonly IArmazensRepository _armazensRepository;

        public ArmazemApp(IArmazensRepository armazensRepository)
        {
            _armazensRepository = armazensRepository;
        }
        public void Delete(Armazens armazem)
        {
            _armazensRepository.Delete(armazem);
        }

        public List<ArmazensViewModel> GetAll()
        {
            return (List<ArmazensViewModel>)_armazensRepository.GetAll(new ArmazensViewModel());
        }

        public ArmazensViewModel GetById(int codigo)
        {
            return (ArmazensViewModel)_armazensRepository.Get(new ArmazensViewModel() { codigo = codigo });
        }

        public void Insert(Armazens entity)
        {
            _armazensRepository.Insert(entity);
        }

        public IEnumerable<Armazens> Listar(string criterios, bool Pesquisa)
        {
            return (List<Armazens>)_armazensRepository.Listar(criterios);
        }

        public IEnumerable<Armazens> Meus_Armazens()
        {
            return _armazensRepository.Meus_Armazens();
        }

        public void Update(Armazens entity)
        {
            _armazensRepository.Update(entity);
        }

        public bool VerificarDup(string nomeTabela, Dictionary<string, object> dicionario)
        {
            return _armazensRepository.VerificarDup(nomeTabela, dicionario);
        }
    }
}
