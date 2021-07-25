using Folha.Domain.ViewModels.Frame.Financeiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Interfaces.Repository.Financeiro
{
    public interface IVendasRepository
    {
        IEnumerable<RegistoVendasViewModel> ListarRegistoVendas(string criterios);
        IEnumerable<PagamentosViewModel> ListarPagamentos(string criterios);
    }
}
