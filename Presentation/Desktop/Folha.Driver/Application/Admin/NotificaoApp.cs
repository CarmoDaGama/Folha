using Folha.Domain.Interfaces.Application.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Folha.Domain.ViewModels.Admin;
using Folha.Domain.Interfaces.Repository.Admin;

namespace Folha.Driver.Application.Admin
{
    public class NotificaoApp : INotificaoApp
    {
        private readonly INotificacaoRepository _notificacaoRepository;
        public NotificaoApp(INotificacaoRepository notificacaoRepository)
        {
            _notificacaoRepository = notificacaoRepository;
        }

        public List<NotificaoQuartoViewModel> Backup(string Criterio)
        {
            return _notificacaoRepository.Backup(null);
        }

        public List<NotificaoDocumentoViewModel> ListarApagar(string Criterio)
        {
            return _notificacaoRepository.ListarApagar(null);
        }
        public List<NotificaoGraficoVendasViewModel> ListarGrafico(string Criterio)
        {
            return _notificacaoRepository.ListarGrafico(null);
        }
        public List<NotificaoManutencaoViewModel> ListarManutencao(string Criterio)
        {
            return _notificacaoRepository.ListarManutencao(null);
        }
        public List<NotificaoQuartoViewModel> ListarQuartos(string Criterio)
        {
            return _notificacaoRepository.ListarQuartos(null);
        }
        public List<NotificaoDocumentoViewModel> ListarReceber(string Criterio)
        {
            return _notificacaoRepository.ListarReceber(null);
        }
        public List<NotificaoRuturaViewModel> ListarRotura(string Criterio)
        {
            return _notificacaoRepository.ListarRotura(null);
        }
        public List<NotificaoTarefasViewModel> ListarTarefas(string Criterio)
        {
            return _notificacaoRepository.ListarTarefas(null);
        }

        public decimal TotalPagar()
        {
            return _notificacaoRepository.TotalPagar();
        }

        public decimal TotalReceber()
        {
            return _notificacaoRepository.TotalReceber();
        }

        public decimal TotalRotura()
        {
            return _notificacaoRepository.TotalRotura();
        }
    }
}
