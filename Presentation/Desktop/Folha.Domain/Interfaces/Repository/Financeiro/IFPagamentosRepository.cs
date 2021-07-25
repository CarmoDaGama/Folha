using Folha.Domain.Models.Financeiro;
using Folha.Domain.ViewModels.Financeiro;
using System.Collections.Generic;

namespace Folha.Domain.Interfaces.Repository.Financeiro
{
    public interface IFPagamentosRepository : IRepositoryBase<fPagamentosViewModel>
    {
        IEnumerable<fPagamentos> ListarFormasdePagamentos(string[] criterios);
        void InsertFPagamentos(fPagamentos tabela, string Criterios);
        fPagamentos GetByCodConta(int CodConta);
    }
}
