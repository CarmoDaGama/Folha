using System;
using System.Collections.Generic;
using Folha.Domain.Interfaces.Application.Inventario;
using Folha.Domain.Models.Inventario;
using Folha.Domain.Interfaces.Repository.Inventario;

namespace Folha.Driver.Application.Inventario
{
    public class MotivoIsencaoApp : IMotivoIsencaoApp
    {

        private readonly IMotivoIsencaoRepository _motivoIsencaoRepository;

        public MotivoIsencaoApp(IMotivoIsencaoRepository motivoIsencaoRepository)
        {
            _motivoIsencaoRepository = motivoIsencaoRepository;

        }
        public MotivoIsencao GetById(int codigo)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MotivoIsencao> Listar(string criterios, bool Pesquisa)
        {
            return (List<MotivoIsencao>)_motivoIsencaoRepository.Listar(criterios);
        }
    }
}
