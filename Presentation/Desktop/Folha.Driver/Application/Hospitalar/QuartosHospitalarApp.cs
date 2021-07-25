using Folha.Domain.Interfaces.Application.Hospitalar;
using Folha.Domain.Interfaces.Repository.Hospitalar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Folha.Domain.Models.Hospitalar;
using Folha.Domain.ViewModels.Hospitalar;

namespace Folha.Driver.Application.Hospitalar
{
   public class QuartosHospitalarApp : IQuartosHospitalarApp
    {
        private readonly IQuartosHospitalarRepository _repository;
        public QuartosHospitalarApp(IQuartosHospitalarRepository repository)
        {
            _repository = repository;
        }

        public void Delete(QuartosHospitalar entity)
        {
            _repository.Delete(entity);
        }

        public void DeleteCama(CamasQuartosHospitalarViewModel delete)
        {
            _repository.DeleteCama(delete);
        }

        public void EditQuarto(QuartosHospitalarViewModel entity)
        {
            _repository.Update(entity);
        }

        public QuartosHospitalarViewModel GetById(int codigo)
        {
            return (QuartosHospitalarViewModel)_repository.Get(new QuartosHospitalarViewModel() { Codigo = codigo });
        }

        public List<CamasQuartosHospitalarViewModel> GetCamas(int codQuartos)
        {
            return _repository.GetCamas(codQuartos);
        }

   

        public QuartosHospitalar Gravar(QuartosHospitalar quarto)
        {
            return _repository.Gravar(quarto);
        }

        public IEnumerable<QuartosHospitalar> Listar(string criterios)
        {
            return (List<QuartosHospitalar>)_repository.Listar(criterios);
        }

   

        public bool VerificarDup(string nomeTabela, Dictionary<string, object> dicionario)
        {
            return _repository.VerificarDup(nomeTabela, dicionario);
        }
    }
}
