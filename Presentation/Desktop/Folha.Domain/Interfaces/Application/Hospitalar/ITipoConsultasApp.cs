using Folha.Domain.Models.Hospitalar;
using Folha.Domain.ViewModels.Hospitalar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folha.Domain.Interfaces.Application.Hospitalar
{
    public interface ITipoConsultasApp
    {
        void Insert(TipoConsultas Dados);
        IEnumerable<TipoConsultaViewModel> Listar(string Descricao);
        void Update(TipoConsultas Dados);
        void Delete(TipoConsultas Dados);
    }
}
