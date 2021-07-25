using Folha.Domain.Models.Financeiro;
using Folha.Domain.ViewModels.Financeiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Interfaces.Application.Financeiro
{
    public interface ITipoSaidaApp
    {
        IEnumerable<TipoSaidaViewModel> Listar(string criterios);
      
        void addTipoSaida(TipoSaida TipoSaida);
        void updateTipoSaida(TipoSaida TipoSaida);
        void deleteTipoSaida(TipoSaida TipoSaida);
    }
}
