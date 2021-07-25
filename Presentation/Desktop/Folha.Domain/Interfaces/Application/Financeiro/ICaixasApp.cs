using Folha.Domain.Models.Financeiro;
using Folha.Domain.ViewModels.Report;
using Folha.Domain.ViewModels.Frame.Financeiro;
using System.Collections.Generic;

namespace Folha.Domain.Interfaces.Application.Financeiro
{
    public interface ICaixasApp
    {
        IEnumerable<Caixas> Listar(string criterios);
        void addCaixa(Caixas caixa);
        void updateCaixa(Caixas caixa, string criterios);
        void deleteCaixa(Caixas caixa);
        List<CaixaViewModel> BuscarTotal(int usuarioID, string turnoID, string Sigla, string comissionarioID);
        IEnumerable<Caixas> Meus_Caixas();
        double buscarSaldoCaixa(int codCaixa);
        DataViewModel RetortaDataSaldoCaixa();
    }
}
