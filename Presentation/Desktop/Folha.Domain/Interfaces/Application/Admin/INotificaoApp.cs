using Folha.Domain.ViewModels.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Interfaces.Application.Admin
{
    public interface INotificaoApp
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

        decimal TotalPagar();
        decimal TotalReceber ();
        decimal TotalRotura ();




        #endregion
    }
}
