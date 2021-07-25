using Folha.Domain.Models.Financeiro;
using Folha.Domain.ViewModels.Documentos;
using Folha.Domain.ViewModels.Financeiro;
using Folha.Domain.ViewModels.Report;
using Folha.Domain.ViewModels.Frame.Financeiro;
using System.Collections.Generic;

namespace Folha.Domain.Interfaces.Repository.Financeiro
{
    public  interface ICaixasRepository:IRepositoryBase<Caixas>
    {

        IEnumerable<Caixas> Listar(string criterios);
        List<CaixaViewModel> BuscarTotal(int usuarioID, string turnoID, string Sigla, string comissionarioID);
        TurnoActualViewModel LerTurnoActual(int usuarioID, string turnoID);
        void UpdateCaixa(Caixas Caixa, string criterios);
        IEnumerable<Caixas> Meus_Caixas();
        double buscarSaldoCaixa(int codCaixa);
       DataViewModel RetortaDataSaldoCaixa();
    }
}
