using Folha.Domain.Interfaces.Application.Financeiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Folha.Domain.ViewModels.Frame.Financeiro;
using Folha.Domain.Interfaces.Repository.Financeiro;

namespace Folha.Driver.Application.Financeiro
{
    public class VendasApp : IVendasApp
    {
        private readonly IVendasRepository _VendasRepository;
        public VendasApp(IVendasRepository VendasRepository)
        {
            _VendasRepository = VendasRepository;
        }

        public IEnumerable<PagamentosViewModel> ListarPagamentos(string criterios)
        {
            return _VendasRepository.ListarPagamentos(criterios);
        }

        public IEnumerable<RegistoVendasViewModel> ListarRegistoVendas(string criterios)
        {
            return _VendasRepository.ListarRegistoVendas(criterios);
        }
    }
}
