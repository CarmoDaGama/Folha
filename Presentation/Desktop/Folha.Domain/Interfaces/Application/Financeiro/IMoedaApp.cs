using Folha.Domain.Models.Financeiro;
using Folha.Domain.ViewModels.Financeiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Interfaces.Application.Financeiro
{
    public interface IMoedaApp
    {
        IEnumerable<MostraMoedasViewModel> Listar();
        void addMoeda(Moedas banco);
        void deleteMoeda(Moedas Moeda);
        void updateMoeda(Moedas Moeda);
        IEnumerable<Moedas> ListarMoedaCambio();
        IEnumerable<Moedas> ListarCriterio(string text);
        bool VerificarDup(string nomeTabela, Dictionary<string, object> dicionario);
        void UpdateMoedaPadrao(Moedas Dados);
    }
}
