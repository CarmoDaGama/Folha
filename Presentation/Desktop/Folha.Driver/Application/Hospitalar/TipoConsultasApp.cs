using Folha.Domain.Interfaces.Application.Hospitalar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Folha.Domain.Models.Hospitalar;
using Folha.Domain.Interfaces.Repository.Hospitalar;
using Folha.Domain.ViewModels.Hospitalar;

namespace Folha.Driver.Application.Hospitalar
{
    public class TipoConsultasApp : ITipoConsultasApp
    {
        private readonly ITipoConsultasRepository _ITipoConsultasRepository;

        public TipoConsultasApp(ITipoConsultasRepository ITipoConsultasRepository)
        {
            _ITipoConsultasRepository = ITipoConsultasRepository;
        }
        public void Delete(TipoConsultas Dados)
        {
            _ITipoConsultasRepository.Delete(Dados);
        }

        public void Insert(TipoConsultas Dados)
        {
            _ITipoConsultasRepository.Insert(Dados);
        }
        
        public void Update(TipoConsultas Dados)
        {
            _ITipoConsultasRepository.Update(Dados);
        }

        IEnumerable<TipoConsultaViewModel> ITipoConsultasApp.Listar(string Descricao)
        {
            return _ITipoConsultasRepository.Listar(Descricao);
        }
    }
}
