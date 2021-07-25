using Folha.Domain.Interfaces.Repository;
using Folha.Domain.ViewModels.Admin;
using System.Collections.Generic;

namespace Folha.Domain.Interfaces.Repository.Admin
{
    public interface INotificacaoRepository : IRepositoryBase<NotificaoDocumentoViewModel>
    {
        #region Trazer dados
        List<NotificaoDocumentoViewModel> ListarApagar(string Criterio);
        List<NotificaoDocumentoViewModel> ListarReceber(string Criterio);
        List<NotificaoGraficoVendasViewModel> ListarGrafico(string Criterio);
        List<NotificaoManutencaoViewModel> ListarManutencao(string Criterio);
        List<NotificaoRuturaViewModel> ListarRotura(string Criterio);
        List<NotificaoTarefasViewModel> ListarTarefas(string Criterio);
        List<NotificaoQuartoViewModel> ListarQuartos(string Criterio);
        List<NotificaoQuartoViewModel> Backup(string Criterio);

        decimal TotalRotura();
        decimal TotalPagar();
        decimal TotalReceber();



        #endregion
    }
}
