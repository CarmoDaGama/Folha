using Folha.Domain.Interfaces.Application.Financeiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Folha.Domain.Models.Financeiro;
using Folha.Domain.Interfaces.Repository.Financeiro;

namespace Folha.Driver.Application.Financeiro
{
    public class CambioApp : ICambioApp
    {
        private readonly ICambioRepository _CambioRepository;

        public CambioApp(ICambioRepository CambioRepository)
        {
            _CambioRepository = CambioRepository;
        }
        public IEnumerable<Cambio> Listar()
        {
            return _CambioRepository.Listar();
        }
    }
}
