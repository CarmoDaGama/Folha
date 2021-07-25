using Folha.Domain.Models.Financeiro;
using Folha.Domain.ViewModels.Financeiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Interfaces.Repository.Financeiro
{
    public interface IMoedaRepository : IRepositoryBase<Moedas>
    {
        IEnumerable<MostraMoedasViewModel> Listar();
        IEnumerable<Moedas> ListarCriterio(string criterios);
        IEnumerable<Moedas> ListarMoedaCambio();
        bool VerificarDup(string nomeTabela, Dictionary<string, object> dicionario);
        void UpdateMoedaPadrao(Moedas Dados);

    }
}
