using Folha.Domain.Models.Financeiro;
using Folha.Domain.ViewModels.Financeiro;
using System.Collections.Generic;

namespace Folha.Domain.Interfaces.Application.Financeiro
{
    public interface IBancosApp
    {
        IEnumerable<BancosViewModel> ListarTudo(string criterios);
        List<BancosViewModel> Listar(string criterios);
        void addBanco(BancosViewModel banco);
        void update(BancosViewModel banco);
        void updateBanco(BancosViewModel banco,string criterios);
        void deleteBanco(BancosViewModel banco);
    }
}
