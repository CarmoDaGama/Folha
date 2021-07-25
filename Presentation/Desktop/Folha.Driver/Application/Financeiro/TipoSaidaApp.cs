using Folha.Domain.Interfaces.Application.Financeiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Folha.Domain.Models.Financeiro;
using Folha.Domain.Interfaces.Repository.Financeiro;
using Folha.Domain.ViewModels.Financeiro;

namespace Folha.Driver.Application.Financeiro
{
    public class TipoSaidaApp : ITipoSaidaApp
    {
        private readonly ITipoSaidaRepository _TipoSaidaRepository;
        public TipoSaidaApp(ITipoSaidaRepository TipoSaidaRepository)
        {
            _TipoSaidaRepository = TipoSaidaRepository;
        }
        public void addTipoSaida(TipoSaida TipoSaida)
        {
            _TipoSaidaRepository.Insert(TipoSaida);
        }

        public void deleteTipoSaida(TipoSaida TipoSaida)
        {
            _TipoSaidaRepository.Delete(TipoSaida);
        }

        public IEnumerable<TipoSaidaViewModel> Listar(string criterios)
        {
            return _TipoSaidaRepository.Listar(criterios);
        }

        public void updateTipoSaida(TipoSaida TipoSaida)
        {
            _TipoSaidaRepository.Update(TipoSaida);
        }
    }
}
