using Folha.Domain.Models.Financeiro;
using Folha.Domain.ViewModels.Financeiro;
using System.Collections.Generic;

namespace Folha.Domain.Interfaces.Repository.Financeiro
{
    public interface IBancosRepository : IRepositoryBase<BancosViewModel>
    {
        void UpdateBanco(BancosViewModel Banco, string criterios);
        IEnumerable<BancosViewModel> Listar(string criterios);
    } 
}
