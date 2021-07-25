using Folha.Domain.Interfaces.Application.Inventario;
using Folha.Domain.Models.Inventario;
using Folha.Domain.ViewModels.Inventario;
using Folha.Domain.Interfaces.Repository.Inventario;
using System;
using System.Collections.Generic;

namespace Folha.Driver.Application.Inventario
{
    public class ImpostoApp : IImpostoApp
    {

        private readonly IImpostoRepository _impostoRepository;

        public ImpostoApp(IImpostoRepository impostoRepository)
        {
            _impostoRepository = impostoRepository;

        }
        public void Delete(ImpostoViewModel imposto)
        {
            _impostoRepository.Delete(imposto);
        }

        public ImpostoViewModel GetById(int codigo)
        {
            return (ImpostoViewModel) _impostoRepository.Get(new ImpostoViewModel() { Codigo = codigo });
        }

        public void Insert(ImpostoViewModel entity)
        {
            _impostoRepository.Insert(entity);

        }

        public IEnumerable<Imposto> Listar(string criterios, bool Pesquisa)
        {
            return (List<Imposto>)_impostoRepository.Listar(criterios);
        }

        public List<ImpostoViewModel> GetAll()
        {
            return (List<ImpostoViewModel>)_impostoRepository.GetAll(new ImpostoViewModel());
        }
        public void Update(ImpostoViewModel entity)
        {
            _impostoRepository.Update(entity);
        }
        public bool VerificarDup(string nomeTabela, Dictionary<string, object> dicionario)
        {
            return _impostoRepository.VerificarDup(nomeTabela, dicionario);
        }
    }
}
